using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VideoTheque.ViewModels
{
    public class MovieViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("realisateur")]
        [Required]
        public string Director { get; set; }

        [JsonPropertyName("scenariste")]
        [Required]
        public string Scenarist { get; set; }

        [JsonPropertyName("duree")]
        [Required]
        public int Duration { get; set; }

        [JsonPropertyName("support")]
        [Required]
        public string Support { get; set; }

        [JsonPropertyName("age-rating")]
        [Required]
        public string AgeRating { get; set; }

        [JsonPropertyName("genre")]
        [Required]
        public string Genre { get; set; }

        [JsonPropertyName("titre")]
        [Required]
        public string Title { get; set; }

        [JsonPropertyName("acteur")]
        [Required]
        public string FirstActor { get; set; }
    }
}
