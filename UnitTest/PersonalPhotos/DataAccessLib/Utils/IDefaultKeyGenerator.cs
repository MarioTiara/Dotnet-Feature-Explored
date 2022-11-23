namespace DataAccessLib.Utils
{
    public interface IDefaultKeyGenerator
    {
        string GetKey(string emailAddress);
    }
}