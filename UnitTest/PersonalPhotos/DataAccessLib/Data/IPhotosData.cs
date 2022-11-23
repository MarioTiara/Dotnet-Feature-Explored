using DataAccessLib.Models;

namespace DataAccessLib.Data
{
    public interface IPhotosData
    {
        Task<PhotosModel?> GetPhoto(int id);
        Task<IEnumerable<PhotosModel>> GetPhotos();
        Task InsertPhoto(PhotosModel photo, string email);
    }
}