using RecordShop.Web.Models;

namespace RecordShop.Web.Services
{
    public class AlbumService (HttpClient httpClient) : IAlbumService
    {
        private readonly HttpClient _httpClient = httpClient;

        private const string _baseApiUrl = "https://localhost:7091/api/Album";

        public async Task<List<Album>?> GetAllAlbumsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Album>>(_baseApiUrl);
        }

        public async Task<Album?> GetAlbumByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Album>($"_baseApiUrl/{id}");
        }
    }
}
