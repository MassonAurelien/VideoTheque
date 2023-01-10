using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VideoTheque.ViewModels
{
    public class MovieViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Director")]
        [Required]
        public string Director { get; set; }

        [JsonPropertyName("Scenarist")]
        [Required]
        public string Scenarist { get; set; }

        [JsonPropertyName("Duration")]
        [Required]
        public int Duration { get; set; }

        [JsonPropertyName("Support")]
        [Required]
        public string Support { get; set; }

        [JsonPropertyName("AgeRating")]
        [Required]
        public string AgeRating { get; set; }

        [JsonPropertyName("Genre")]
        [Required]
        public string Genre { get; set; }

        [JsonPropertyName("Title")]
        [Required]
        public string Title { get; set; }

        [JsonPropertyName("acteur")]
        [Required]
        public string FirstActor { get; set; }
    }
}
