using VideoTheque.DTOs;

namespace VideoTheque.Repositories.Age_Rating
{
    public interface IAgeRatingRepository
    {
        Task<List<AgeRatingDto>> GetAgeRatings();

        ValueTask<AgeRatingDto?> GetAgeRating(int id);

        Task InsertAgeRating(AgeRatingDto ageRating);

        Task UpdateAgeRating(int id, AgeRatingDto ageRating);

        Task DeleteAgeRating(int id);
    }
}
