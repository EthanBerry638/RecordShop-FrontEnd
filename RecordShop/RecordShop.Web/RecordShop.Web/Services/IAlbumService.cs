using RecordShop.Web.Models;

namespace RecordShop.Web.Services
{
    public interface IAlbumService
    {
        Task<List<Album>?> GetAllAlbumsAsync();
    }
}
