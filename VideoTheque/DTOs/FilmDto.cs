namespace VideoTheque.DTOs
{
    public class FilmDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string FirstActor { get; set; }
        public string Director { get; set; }
        public string Scenarist { get; set; }
        public string AgeRating { get; set; }
        public string Genre { get; set; }
        public string Support { get; set; }

        public FilmDto(BluRayDto bluRayDto, string acteur, string directeur, string scenarist, string genre, string ageRating)
        {
            Id = bluRayDto.Id;
            Title = bluRayDto.Title;
            Duration = (int)bluRayDto.Duration;
            FirstActor = acteur;
            Director = directeur;
            Scenarist = scenarist;
            AgeRating = ageRating;
            Genre = genre;
        }
    }
}
