using System.Reflection;
using VideoTheque.Constants;

namespace VideoTheque.DTOs
{
    public class EmpruntsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public PersonneDto FirstActor { get; set; }
        public PersonneDto Director { get; set; }
        public PersonneDto Scenarist { get; set; }
        public AgeRatingDto AgeRating { get; set; }
        public GenreDto Genre { get; set; }
        public string Support { get; set; }


        public EmpruntsDto(FilmDto film, PersonneDto acteur, PersonneDto directeur, PersonneDto scenarist, GenreDto genre, AgeRatingDto ageRating)
        {
            Id = film.Id;
            Title = film.Title;
            Duration = (int)film.Duration;
            FirstActor = acteur;
            Director = directeur;
            Scenarist = scenarist;
            Genre = genre;
            AgeRating = ageRating;
            Support = EnumSupports.BluRays.ToString();
        }
    }

}
