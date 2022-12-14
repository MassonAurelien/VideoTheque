using VideoTheque.DTOs;

namespace VideoTheque.Businesses.Emprunts
{
    public interface IEmpruntsBusiness
    {
        Task<List<FilmDto>> GetFilms();

        Task<EmpruntsDto> PostFilm(int id);

        void DeleteFilm(string name);
    }
}
