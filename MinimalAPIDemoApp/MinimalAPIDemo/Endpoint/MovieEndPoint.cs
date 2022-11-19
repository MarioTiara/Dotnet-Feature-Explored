using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace MinimalAPIDemo.Endpoint
{
    public class MovieEndPoint
    {

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator, Standard")]
        public async Task<IResult> GetMovies(IMovieData data)
        {
            try
            {

                return Results.Ok(await data.GetMovies());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IResult> CreateMovie(MovieModel movie, IMovieData data)
        {
            try
            {
                await data.InsertMovie(movie);
                return Results.Ok("Movie Created");
                
            }catch(Exception ex)
            {
               return Results.Problem(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IResult> UpdateMovie(MovieModel movie, IMovieData data)
        {
            try
            {
                await data.UpdateMovie(movie);
                return Results.Ok("Movie Update");

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IResult> DeleteMovie(int id, IMovieData data)
        {
            try
            {
                await data.DeleteMovie(id);
                return Results.Ok($"Movie with id: {id} was deleted");

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
