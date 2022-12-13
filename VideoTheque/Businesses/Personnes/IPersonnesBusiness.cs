using VideoTheque.DTOs;

namespace VideoTheque.Businesses.Personnes
{
    public interface IPersonnesBusiness
    {
        Task<List<PersonneDto>> GetPersonnes();

        PersonneDto GetPersonne(int id);

        PersonneDto InsertPersonne(PersonneDto Personne);

        void UpdatePersonne(int id, PersonneDto Personne);

        void DeletePersonne(int id);
    }
}
