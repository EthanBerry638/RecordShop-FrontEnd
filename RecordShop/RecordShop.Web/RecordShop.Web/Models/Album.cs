using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RecordShop.Web.Models
{
    public class Album
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        [Required]
        [MaxLength(150, ErrorMessage = "Title cannot exceed 150 characters")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        [Required][MaxLength(250, ErrorMessage = "Description cannot exceed 250 characters")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("releasedate")]
        public DateOnly? ReleaseDate { get; set; }

        [JsonPropertyName("price")]
        [Required][Range(0.01, 2000000.00, ErrorMessage = "Price must be between 0.01 and 2,000,000")]
        public decimal Price { get; set; }
    }
}
