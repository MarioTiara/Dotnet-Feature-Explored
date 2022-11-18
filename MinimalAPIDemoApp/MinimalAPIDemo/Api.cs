using MinimalAPIDemo.Services;
using MinimalAPIDemo.Models;


namespace MinimalAPIDemo;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        // All of my API endpoint mapping
        app.MapGet("/Users", GetUsers);
       // app.MapGet("/Users/{id}", GetUserById);
        app.MapGet("/Users/{UserName}", GetUserByUserName);
        app.MapPost("/Users", InsertUser);
        app.MapPut("/Users", UpdateUser);
        app.MapDelete("/Users", DeleteUser);
    }

    private static async Task<IResult> Login(ModelUserLogin user, IUserData data)
    {
        if (!string.IsNullOrEmpty(user.UserName)&& !string.IsNullOrEmpty(user.Password)){
            var loggedUser=await data.GetUser(user.UserName);
            if (loggedUser is null) return Results.NotFound("User not found");
            if (loggedUser.Password != user.Password) return Results.NotFound("UserName and Password is not Mattching");
            string jwttoken=Auth
        }
    }

    private static async Task<IResult> GetUsers(IUserData data)
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

    private static async Task<IResult> GetUserById(int id, IUserData data)
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

    private static async Task<IResult> GetUserByUserName(string UserName, IUserData data)
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

    private static async Task<IResult> InsertUser(UserModel user, IUserData data)
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

    private static async Task<IResult> UpdateUser(UserModel user, IUserData data)
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

    private static async Task<IResult> DeleteUser(int id, IUserData data)
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
