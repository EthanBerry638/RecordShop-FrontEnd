using System.Text.Json.Serialization;

namespace RecordShop.Web.Models
{
    public class Album
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("releasedate")]
        public DateOnly? ReleaseDate { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}
