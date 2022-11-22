namespace DataAccessLib.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U paramaters, string connectionId = "Default");
        Task SaveData<T>(string storedProcedures, T paramaters, string connectionId = "Default");
    }
}