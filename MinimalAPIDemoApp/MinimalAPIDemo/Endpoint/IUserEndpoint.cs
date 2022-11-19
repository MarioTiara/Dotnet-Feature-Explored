using Microsoft.Extensions.Options;
using MinimalAPIDemo.Config;
using MinimalAPIDemo.Models;

namespace MinimalAPIDemo.Endpoint
{
    public interface IUserEndpoint
    {
        Task<IResult> DeleteUser(int id, IUserData data);
        Task<IResult> GetUserById(int id, IUserData data);
        Task<IResult> GetUserByUserName(string UserName, IUserData data);
        Task<IResult> GetUsers(IUserData data);
        Task<IResult> InsertUser(UserModel user, IUserData data);
        Task<IResult> Login(ModelUserLogin user, IUserData data, IOptions<JwtConfig> options);
        Task<IResult> UpdateUser(UserModel user, IUserData data);
    }
}