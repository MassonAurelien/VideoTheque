using VideoTheque.Core;
using VideoTheque.DTOs;
using VideoTheque.Repositories.Age_Rating;
using VideoTheque.Repositories.Genres;
using VideoTheque.Repositories.Movies;
using VideoTheque.Repositories.Personnes;

namespace VideoTheque.Businesses.Emprunts
{
    public class EmpruntsBusiness : IEmpruntsBusiness
    {
        private readonly IMoviesRepository _moviesDao;
        private readonly IPersonnesRepository _personnesDao;
        private readonly IGenresRepository _genresDao;
        private readonly IAgeRatingRepository _ageRatingDao;

        public EmpruntsBusiness(IMoviesRepository moviesDao, IPersonnesRepository personnesDao, IGenresRepository genresDao, IAgeRatingRepository ageRatingDao)
        {
            _moviesDao = moviesDao;
            _personnesDao = personnesDao;
            _genresDao = genresDao;
            _ageRatingDao = ageRatingDao;
        }

        public void DeleteFilm(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<EmpruntsDto> PostFilm(int id)
        {
            var movie = _moviesDao.GetMovie(id).Result;
            if (movie == null)
            {
                throw new NotFoundException($"Movies '{id}' non trouvé");
            }
            var scenarist = await _personnesDao.GetPersonne(movie.IdScenarist);
            var acteur = await _personnesDao.GetPersonne(movie.IdFirstActor);
            var directeur = await _personnesDao.GetPersonne(movie.IdDirector);
            var genre = await _genresDao.GetGenre(movie.IdGenre);
            var ageRating = await _ageRatingDao.GetAgeRating(movie.IdAgeRating);
            movie.IsAvailable = false;
            await _moviesDao.UpdateMovie(movie.Id,movie);
            FilmDto film = new FilmDto(movie, acteur.FirstName + ' ' + acteur.LastName, directeur.FirstName + ' ' + directeur.LastName, scenarist.FirstName + ' ' + scenarist.LastName, genre.Name, ageRating.Name);
            EmpruntsDto emprunts = new EmpruntsDto(film, acteur, directeur, scenarist, genre, ageRating);
            return emprunts;
        }

        public async Task<List<FilmDto>> GetFilms()
        {
            List<FilmDto> films = new List<FilmDto>();
            var brs = await _moviesDao.GetMovies();
            foreach (BluRayDto film in brs)
            {
                if(film.IdOwner == null && film.IsAvailable)
                {
                    var scenarist = await _personnesDao.GetPersonne(film.IdScenarist);
                    var acteur = await _personnesDao.GetPersonne(film.IdFirstActor);
                    var directeur = await _personnesDao.GetPersonne(film.IdDirector);
                    var genre = await _genresDao.GetGenre(film.IdGenre);
                    var ageRating = await _ageRatingDao.GetAgeRating(film.IdAgeRating);

                    films.Add(new FilmDto(film, acteur.FirstName + ' ' + acteur.LastName, directeur.FirstName + ' ' + directeur.LastName, scenarist.FirstName + ' ' + scenarist.LastName, genre.Name, ageRating.Name));
                }
            }
            return films;
        }
    }
}
