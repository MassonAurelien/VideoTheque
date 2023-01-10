namespace VideoTheque.DTOs
{
    public class BluRayDto
    {
        private int acteur;
        private int director;
        private int scenarist;
        private int ageRating;
        private int genre;
        private int partenaire;

        public BluRayDto(string title, int duration, int acteur, int director, int scenarist, int ageRating, int genre, int partenaire)
        {
            Title = title;
            Duration = duration;
            this.acteur = acteur;
            this.director = director;
            this.scenarist = scenarist;
            this.ageRating = ageRating;
            this.genre = genre;
            this.partenaire = partenaire;
        }

        public BluRayDto() { }  

        public int Id { get; set; }
        public string Title { get; set; }
        public long Duration { get; set; }
        public int IdFirstActor { get; set; }
        public int IdDirector { get; set; }
        public int IdScenarist { get; set; }
        public int IdAgeRating { get; set; }
        public int IdGenre { get; set; }
        public bool IsAvailable { get; set; }
        public int? IdOwner { get; set; }
    }

}
