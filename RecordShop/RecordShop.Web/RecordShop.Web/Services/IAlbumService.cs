using RecordShop.Web.Models;

namespace RecordShop.Web.Services
{
    public interface IAlbumService
    {
        Task<List<Album>?> GetAllAlbumsAsync();
        Task<Album?> GetAlbumByIdAsync(int id);
        Task<Album?> ReplaceAlbumByIdAsync(Album album, int id);
    }
}
