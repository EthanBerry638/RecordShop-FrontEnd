namespace RecordShop.Web.Services
{
    public class AlbumService (HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;

        private const string _baseApiUrl = "https://localhost:7091/api/Album";
    }
}
