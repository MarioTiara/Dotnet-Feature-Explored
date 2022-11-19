using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class MovieData : IMovieData
    {
        private readonly ISqlDataAccess _db;
        public MovieData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<MovieModel>> GetMovies()
        {
            return await _db.LoadData<MovieModel, dynamic>("dbo.spMovie_GetAll", new { });
        }
        public async Task<MovieModel?> GetMovie(int id)
        {
            var result = await _db.LoadData<MovieModel, dynamic>("dbo.spMovie_Get", new
            {
                Id = id
            });

            return result.FirstOrDefault();
        }

        public Task InsertMovie(MovieModel movie) =>
            _db.SaveData("dbo.spMovie_Inset", new
            {
                movie.Title,
                movie.Description,
                movie.Rating
            });

        public Task UpdateUser(MovieModel movie) =>
            _db.SaveData("dbo.spMovie_Update", movie);
        public Task DeleteUser(int id) =>
            _db.SaveData("dbo.spMovie_Delete", new { Id = id });
    }
}
