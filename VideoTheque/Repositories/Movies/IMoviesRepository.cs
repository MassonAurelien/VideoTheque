using VideoTheque.DTOs;

namespace VideoTheque.Repositories.Movies
{
    public interface IMoviesRepository
    {
        Task<List<FilmDto>> GetMovies();

        ValueTask<FilmDto?> GetMovie(int id);

        Task InsertMovie(FilmDto movie);

        Task UpdateMovie(int id, FilmDto movie);

        Task DeleteMovie(int id);
    }
}
