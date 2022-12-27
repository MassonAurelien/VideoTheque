using VideoTheque.DTOs;

namespace VideoTheque.Businesses.Movies
{
    public interface IMoviesBusiness
    {
        Task<List<FilmDto>> GetMovies();

        Task<FilmDto> GetMovie(int id);

        FilmDto InsertMovie(FilmDto movie);

        void UpdateMovie(int id, FilmDto movie);

        void DeleteMovie(int id);
    }
}
