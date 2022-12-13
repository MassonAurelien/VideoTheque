using VideoTheque.Core;
using VideoTheque.DTOs;
using VideoTheque.Repositories.Movies;

namespace VideoTheque.Businesses.Movies
{
    public class MoviesBusiness : IMoviesBusiness
    {

        private readonly IMoviesRepository _moviesDao;

        public MoviesBusiness(IMoviesRepository moviesDao)
        {
            _moviesDao = moviesDao;
        }

        public Task<List<FilmDto>> GetMovies() => _moviesDao.GetMovies();

        

        public FilmDto GetMovie(int id)
        {
            var movies = _moviesDao.GetMovie(id).Result;

            if (movies == null)
            {
                throw new NotFoundException($"Movies '{id}' non trouvé");
            }

            return  movies;
        }

        public FilmDto InsertMovie(FilmDto movies)
        {
            if (_moviesDao.InsertMovie(movies).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de l'insertion du movie {movies.Title}");
            }

            return movies;
        }

        public void UpdateMovie(int id, FilmDto movies)
        {
            if (_moviesDao.UpdateMovie(id, movies).IsFaulted)
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
