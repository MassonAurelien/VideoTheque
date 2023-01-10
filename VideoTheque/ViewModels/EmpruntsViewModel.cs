using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VideoTheque.DTOs;

namespace VideoTheque.ViewModels
{
    public class EmpruntsViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("realisateur")]
        [Required]
        public PersonneViewModel Director { get; set; }

        [JsonPropertyName("scenariste")]
        [Required]
        public PersonneViewModel Scenarist { get; set; }

        [JsonPropertyName("duree")]
        [Required]
        public int Duration { get; set; }

        [JsonPropertyName("support")]
        [Required]
        public string Support { get; set; }

        [JsonPropertyName("age-rating")]
        [Required]
        public AgeRatingModel AgeRating { get; set; }

        [JsonPropertyName("genre")]
        [Required]
        public GenreViewModel Genre { get; set; }

        [JsonPropertyName("titre")]
        [Required]
        public string Title { get; set; }

        [JsonPropertyName("acteur")]
        [Required]
        public PersonneViewModel FirstActor { get; set; }
    }
}
