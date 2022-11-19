using MinimalAPIDemo.Services;
using MinimalAPIDemo.Models;
using Microsoft.Extensions.Options;
using MinimalAPIDemo.Config;
using MinimalAPIDemo.Endpoint;

namespace MinimalAPIDemo;

public static class EndPointMapping
{
    public static void Configureapi(this WebApplication app)
    {
        IUserEndpoint userendpoint = new UserEndpoint();
        // All of my USER API endpoint mapping
        app.MapPost("/Login", userendpoint.Login);
        app.MapGet("/Users", userendpoint.GetUsers);
        app.MapGet("/Users/{UserName}", userendpoint.GetUserByUserName);
        app.MapPost("/Users", userendpoint.InsertUser);
        app.MapPut("/Users", userendpoint.UpdateUser);
        app.MapDelete("/Users", userendpoint.DeleteUser);

        MovieEndPoint movieEndPoint = new MovieEndPoint();
        app.MapGet("/Movies", movieEndPoint.GetMovies);


    }

   
}
