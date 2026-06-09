using RecordShop.Web.Models;

namespace RecordShop.Web.Services
{
    public class AlbumService(HttpClient httpClient, IConfiguration configuration) : IAlbumService
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly string _baseApiUrl = GetBaseApiUrl(configuration);

        private static string GetBaseApiUrl(IConfiguration configuration)
        {
            var baseUrl = configuration["RecordShopApi:BaseUrl"];
            var albumsExtension = configuration["RecordShopApi:AlbumsEndpointsExtension"];

            if (string.IsNullOrEmpty(baseUrl) || string.IsNullOrEmpty(albumsExtension))
            {
                throw new InvalidOperationException(
                    "RecordShopApi:BaseUrl and RecordShopApi:AlbumsEndpointsExtension must be configured in appsettings.json");
            }

            return $"{baseUrl}{albumsExtension}";
        }

        public async Task<List<Album>?> GetAllAlbumsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Album>>(_baseApiUrl);
        }

        public async Task<Album?> GetAlbumByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Album>($"{_baseApiUrl}/{id}");
        }

        public async Task<Album?> ReplaceAlbumByIdAsync(Album album, int id)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseApiUrl}/{id}", album);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Album>();
        }

        public async Task<Album?> AddAlbumAsync(Album album)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseApiUrl, album);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Album>();
        }

        public async Task DeleteAlbumAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseApiUrl}/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}
