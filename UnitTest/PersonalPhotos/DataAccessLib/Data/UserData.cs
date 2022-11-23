using DataAccessLib.DbAccess;
using DataAccessLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib.Data
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;
        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<UsersModel>> GetUsers()
        {
            return await _db.LoadData<UsersModel, dynamic>("dbo.spUser_GetAll", new { });
        }

        public async Task<UsersModel?> GetUser(int id)
        {
            var result = await _db.LoadData<UsersModel, dynamic>("dbo.spUser_Get", new { Id = id });
            return result.FirstOrDefault();
        }

        public Task InsertMovie(UsersModel user) =>
            _db.SaveData("dbo.spUser_Insert", user);

        public Task UpdateUser(int id) =>
            _db.SaveData("dbo.spUser_Update", new { Id = id });
    }
}
