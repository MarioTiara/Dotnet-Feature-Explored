using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IMovieData
    {
        Task DeleteMovie(int id);
        Task<MovieModel?> GetMovie(int id);
        Task<IEnumerable<MovieModel>> GetMovies();
        Task InsertMovie(MovieModel movie);
        Task UpdateMovie(MovieModel movie);
    }
}