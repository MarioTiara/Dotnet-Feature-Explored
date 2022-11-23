using DataAccessLib.Models;

namespace DataAccessLib.Data
{
    public interface IUserData
    {
        Task<UsersModel?> GetUser(string email);
        Task<IEnumerable<UsersModel>> GetUsers();
        Task InsertUser(UsersModel user);
        Task UpdateUser(int id);
    }
}