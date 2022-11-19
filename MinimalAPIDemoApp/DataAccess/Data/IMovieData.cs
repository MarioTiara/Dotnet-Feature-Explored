using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IMovieData
    {
        Task DeleteUser(int id);
        Task<MovieModel?> GetMovie(int id);
        Task<IEnumerable<MovieModel>> GetMovies();
        Task InsertMovie(MovieModel movie);
        Task UpdateUser(MovieModel movie);
    }
}