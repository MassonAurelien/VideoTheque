using VideoTheque.DTOs;

namespace VideoTheque.Repositories.Movies
{
    public interface IMoviesRepository
    {
        Task<List<BluRayDto>> GetMovies();

        ValueTask<BluRayDto?> GetMovie(int id);

        Task InsertMovie(BluRayDto movie);

        Task UpdateMovie(int id, BluRayDto movie);

        Task DeleteMovie(int id);
    }
}
