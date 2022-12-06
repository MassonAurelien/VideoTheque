using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VideoTheque.DTOs;

namespace VideoTheque.ViewModels
{
    public class AgeRatingModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }

        [JsonPropertyName("abreviation")]
        [Required]
        public string Abreviation { get; set; }

    }
}
