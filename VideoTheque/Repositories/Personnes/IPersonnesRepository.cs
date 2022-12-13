using Microsoft.EntityFrameworkCore.ChangeTracking;
using VideoTheque.DTOs;

namespace VideoTheque.Repositories.Personnes
{
    public interface IPersonnesRepository
    {
        Task<List<PersonneDto>> GetPersonnes();

        ValueTask<PersonneDto?> GetPersonne(int id);

        Task InsertPersonne(PersonneDto Personne);

        Task UpdatePersonne(int id, PersonneDto Personne);

        Task DeletePersonne(int id);
    }
}
