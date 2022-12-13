using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using VideoTheque.Context;
using VideoTheque.DTOs;

namespace VideoTheque.Repositories.Personnes
{
    public class PersonnesRepository : IPersonnesRepository
    {
        private readonly VideothequeDb _db;

        public PersonnesRepository(VideothequeDb db)
        {
            _db = db;
        }

        public Task<List<PersonneDto>> GetPersonnes() => _db.Personnes.ToListAsync();

        public ValueTask<PersonneDto?> GetPersonne(int id) => _db.Personnes.FindAsync(id);

        public Task InsertPersonne(PersonneDto Personne) 
        {
            _db.Personnes.AddAsync(Personne);
            return _db.SaveChangesAsync();
        }

        public Task UpdatePersonne(int id, PersonneDto Personne)
        {
            var PersonneToUpdate = _db.Personnes.FindAsync(id).Result;

            if (PersonneToUpdate is null)
            {
                throw new KeyNotFoundException($"Personne '{id}' non trouvé");
            }

            PersonneToUpdate.FirstName = Personne.FirstName;
            PersonneToUpdate.LastName = Personne.LastName;
            PersonneToUpdate.Nationality = Personne.Nationality;
            PersonneToUpdate.BirthDay = Personne.BirthDay;
            return _db.SaveChangesAsync();
        }

        public Task DeletePersonne(int id)
        {
            var PersonneToDelete = _db.Personnes.FindAsync(id).Result;

            if (PersonneToDelete is null)
            {
                throw new KeyNotFoundException($"Personne '{id}' non trouvé");
            }

            _db.Personnes.Remove(PersonneToDelete);
            return _db.SaveChangesAsync();
        }
    }
}
