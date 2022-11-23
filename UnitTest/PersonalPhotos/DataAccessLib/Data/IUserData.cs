using DataAccessLib.Models;

namespace DataAccessLib.Data
{
    public interface IUserData
    {
        Task<UsersModel?> GetUser(int id);
        Task<IEnumerable<UsersModel>> GetUsers();
        Task InsertMovie(UsersModel user);
        Task UpdateUser(int id);
    }
}