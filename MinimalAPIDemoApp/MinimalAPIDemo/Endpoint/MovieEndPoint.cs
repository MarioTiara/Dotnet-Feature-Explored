namespace MinimalAPIDemo.Endpoint
{
    public class MovieEndPoint
    {
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
    }
}
