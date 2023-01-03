using VideoTheque.DTOs;

namespace VideoTheque.Businesses.Movies
{
    public interface IMoviesBusiness
    {
        Task<List<FilmDto>> GetMovies();

        Task<List<FilmDto>> GetMovies(int idPartenaire);

        Task<FilmDto> GetMovie(int id);

        Task<FilmDto> GetMovie(int id, int idPartenaire);

        FilmDto InsertMovie(FilmDto movie);

        void UpdateMovie(int id, FilmDto movie);

        void DeleteMovie(int id);
    }
}