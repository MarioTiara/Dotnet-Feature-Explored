using Microsoft.Extensions.Options;
using MinimalAPIDemo.Config;
using MinimalAPIDemo.Models;
using MinimalAPIDemo.Services;

namespace MinimalAPIDemo.Endpoint
{
    public class UserEndpoint : IUserEndpoint
    {
        public async Task<IResult> Login(ModelUserLogin user, IUserData data, IOptions<JwtConfig> options)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.Password))
                {
                    var loggedUser = await data.GetUser(user.UserName);
                    if (loggedUser is null) return Results.NotFound("User not found");
                    if (loggedUser.Password != user.Password) return Results.NotFound("UserName and Password is not Mattching");
                    string jwttoken = new AuthenticationService().GetToken(loggedUser, user, options);
                    return Results.Ok(jwttoken);
                }
                else
                {
                    return Results.NotFound();
                }

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public async Task<IResult> GetUsers(IUserData data)
        {
            try
            {

                return Results.Ok(await data.GetUsers());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public async Task<IResult> GetUserById(int id, IUserData data)
        {
            try
            {
                var results = await data.GetUser(id);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public async Task<IResult> GetUserByUserName(string UserName, IUserData data)
        {
            try
            {
                var results = await data.GetUser(UserName);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public async Task<IResult> InsertUser(UserModel user, IUserData data)
        {
            try
            {
                await data.InsertUser(user);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public async Task<IResult> UpdateUser(UserModel user, IUserData data)
        {
            try
            {
                await data.UpdateUser(user);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public async Task<IResult> DeleteUser(int id, IUserData data)
        {
            try
            {
                await data.DeleteUser(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }


    }
}
