using Microsoft.AspNetCore.Http;

namespace DataAccessLib.Services
{
    public interface ILocalFileStorage
    {
        Task StoreFile(IFormFile file, string key);
    }
}