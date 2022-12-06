using VideoTheque.Core;
using VideoTheque.DTOs;
using VideoTheque.Repositories.Personnes;

namespace VideoTheque.Businesses.Personnes
{
    public class PersonnesBusiness : IPersonnesBusiness
    {
        private readonly IPersonnesRepository _PersonneDao;

        public PersonnesBusiness(IPersonnesRepository PersonneDao)
        {
            _PersonneDao = PersonneDao;
        }

        public Task<List<PersonneDto>> GetPersonnes() => _PersonneDao.GetPersonnes();

        public PersonneDto GetPersonne(int id)
        {
            var Personne = _PersonneDao.GetPersonne(id).Result;

            if (Personne == null)
            {
                throw new NotFoundException($"Personne '{id}' non trouvé");
            }

            return Personne;
        }

        public PersonneDto InsertPersonne(PersonneDto Personne)
        {
            if (_PersonneDao.InsertPersonne(Personne).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de l'insertion du Personne {Personne.FirstName + " " + Personne.LastName}");
            }

            return Personne;
        }

        public void UpdatePersonne(int id, PersonneDto Personne)
        {
            if (_PersonneDao.UpdatePersonne(id, Personne).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la modification du Personne {Personne.FirstName + " " + Personne.LastName}");
            }
        }
                

        public void DeletePersonne(int id)
        {
            if (_PersonneDao.DeletePersonne(id).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la suppression du Personne d'identifiant {id}");
            }
        }
    }
}
