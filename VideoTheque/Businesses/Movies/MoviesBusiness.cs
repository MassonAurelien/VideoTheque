using VideoTheque.Core;
using VideoTheque.DTOs;
using VideoTheque.Repositories.Age_Rating;
using VideoTheque.Repositories.Genres;
using VideoTheque.Repositories.Movies;
using VideoTheque.Repositories.Personnes;

namespace VideoTheque.Businesses.Movies
{
    public class MoviesBusiness : IMoviesBusiness
    {

        private readonly IMoviesRepository _moviesDao;
        private readonly IPersonnesRepository _personnesDao;
        private readonly IGenresRepository _genresDao;
        private readonly IAgeRatingRepository _ageRatingDao;

        public MoviesBusiness(IMoviesRepository moviesDao, IPersonnesRepository personnesDao, IGenresRepository genresDao, IAgeRatingRepository ageRatingDao)
        {
            _moviesDao = moviesDao;
            _personnesDao = personnesDao;
            _genresDao = genresDao;
            _ageRatingDao = ageRatingDao;
        }

        public async Task<List<FilmDto>> GetMovies()
        {
            List<FilmDto> films = new List<FilmDto>();
            foreach (BluRayDto film in (await _moviesDao.GetMovies()))
            {
                var scenarist = await _personnesDao.GetPersonne(film.IdScenarist);
                var acteur = await _personnesDao.GetPersonne(film.IdFirstActor);
                var directeur = await _personnesDao.GetPersonne(film.IdDirector);
                var genre = await _genresDao.GetGenre(film.IdGenre);
                var ageRating = await _ageRatingDao.GetAgeRating(film.IdAgeRating);

                films.Add(new FilmDto(film, acteur.FirstName + ' ' + acteur.LastName, directeur.FirstName+ ' '+ directeur.LastName, scenarist.FirstName + ' ' + scenarist.LastName, genre.Name, ageRating.Name));
            }
            return films;
        }

        

        public FilmDto GetMovie(int id)
        {
            var movies = _moviesDao.GetMovie(id).Result;

            if (movies == null)
            {
                throw new NotFoundException($"Movies '{id}' non trouvé");
            }
            //var movieDto = new FilmDto(movies);
            //return  movies;
            return null;
        }

        public FilmDto InsertMovie(FilmDto movie)
        {
            //if (_moviesDao.InsertMovie(movie).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de l'insertion du movie {movie.Title}");
            }

            //return movie;
            return null;
        }

        public void UpdateMovie(int id, FilmDto movies)
        {
            //if (_moviesDao.UpdateMovie(id, movies).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la modification de l'host {movies.Title}");
            }
        }

        public void DeleteMovie(int id)
        {
            if (_moviesDao.DeleteMovie(id).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la suppression du movie : {id}");
            }
        }
    }
}
