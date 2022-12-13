using Microsoft.EntityFrameworkCore;
using VideoTheque.Context;
using VideoTheque.DTOs;

namespace VideoTheque.Repositories.Movies
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly VideothequeDb _db;

        public MoviesRepository(VideothequeDb db)
        {
            _db = db;
        }
        public Task<List<FilmDto>> GetMovies() => _db.BluRays.ToListAsync();

        public ValueTask<FilmDto?> GetMovie(int id) => _db.BluRays.FindAsync(id);

        public Task InsertMovie(FilmDto movie)
        {
            _db.BluRays.AddAsync(movie);
            return _db.SaveChangesAsync();
        }

        public Task UpdateMovie(int id, FilmDto movie)
        {
            var movieToUpdate = _db.BluRays.FindAsync(id).Result;

            if (movieToUpdate is null)
            {
                throw new KeyNotFoundException($"Movie '{id}' non trouvé");
            }

            movieToUpdate.Title = movie.Title;
            movieToUpdate.Duration = movie.Duration;
            movieToUpdate.IdFirstActor = movie.IdFirstActor;
            movieToUpdate.IdDirector = movie.IdDirector;
            movieToUpdate.IdScenarist= movie.IdScenarist;
            movieToUpdate.IdAgeRating= movie.IdAgeRating;
            movieToUpdate.IdGenre = movie.IdGenre;
            movieToUpdate.IsAvailable= movie.IsAvailable;
            movieToUpdate.IdOwner= movie.IdOwner;
            return _db.SaveChangesAsync();
        }

        public Task DeleteMovie(int id)
        {
            var movieToDelete = _db.BluRays.FindAsync(id).Result;

            if (movieToDelete is null)
            {
                throw new KeyNotFoundException($"Movie '{id}' non trouvé");
            }

            _db.BluRays.Remove(movieToDelete);
            return _db.SaveChangesAsync();
        }
    }
}
