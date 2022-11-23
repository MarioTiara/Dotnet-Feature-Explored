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

        public async Task<UsersModel?> GetUser(string email)
        {
            var result = await _db.LoadData<UsersModel, dynamic>("dbo.spUser_Get", new { Email =email });
            return result.FirstOrDefault();
        }

        public Task InsertUser(UsersModel user) =>
            _db.SaveData("dbo.spUser_Insert", user);

        public Task UpdateUser(int id) =>
            _db.SaveData("dbo.spUser_Update", new { Id = id });
    }
}
