using DataAccessLib.DbAccess;
using DataAccessLib.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib.Data
{
    public class PhotosData : IPhotosData
    {
        private readonly ISqlDataAccess _db;
        public PhotosData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<PhotosModel>> GetPhotos()
        {
            return await _db.LoadData<PhotosModel, dynamic>("dbo.", new { });
        }

        public async Task<PhotosModel?> GetPhoto(int id)
        {
            return (await _db.LoadData<PhotosModel, dynamic>("dbo.spPhotos_Get", new { Id = id })).FirstOrDefault();
        }

        public Task InsertPhoto(PhotosModel photo, string email) =>
            _db.SaveData("dbo.spPhotos_Insert", new
            {
                Email = email,
                Description = photo.Description,
                FileName = photo.FileName
            });

    }
}
