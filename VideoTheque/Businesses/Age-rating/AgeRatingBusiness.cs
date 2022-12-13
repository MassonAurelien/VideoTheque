using Microsoft.AspNetCore.Razor.TagHelpers;
using VideoTheque.Core;
using VideoTheque.DTOs;
using VideoTheque.Repositories.Age_Rating;

namespace VideoTheque.Businesses.Age_rating
{
    public class AgeRatingBusiness : IAgeRatingBusiness
    {

        private readonly IAgeRatingRepository _ageRatingDao;

        public AgeRatingBusiness(IAgeRatingRepository ageRatingDao)
        {
            _ageRatingDao = ageRatingDao;
        }

        public Task<List<AgeRatingDto>> GetAgeRatings() => _ageRatingDao.GetAgeRatings();

        

        public AgeRatingDto GetAgeRating(int id)
        {
            var ageRating = _ageRatingDao.GetAgeRating(id).Result;

            if (ageRating == null)
            {
                throw new NotFoundException($"Age Rating '{id}' non trouvé");
            }

            return  ageRating;
        }

        public AgeRatingDto InsertAgeRating(AgeRatingDto ageRating)
        {
            if (_ageRatingDao.InsertAgeRating(ageRating).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de l'insertion de l'age rating {ageRating.Name}");
            }

            return ageRating;
        }

        public void UpdateAgeRating(int id, AgeRatingDto ageRating)
        {
            if (_ageRatingDao.UpdateAgeRating(id, ageRating).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la modification de l'age rating {ageRating.Name}");
            }
        }

        public void DeleteAgeRating(int id)
        {
            if (_ageRatingDao.DeleteAgeRating(id).IsFaulted)
            {
                throw new InternalErrorException($"Erreur lors de la suppression de l'age rating : {id}");
            }
        }
    }
}
