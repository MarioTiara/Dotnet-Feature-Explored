internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

public class UserInterface
{
    public void GetData(){
        Console.WriteLine("Enter your username:");
        var userName=Console.ReadLine();

        Console.Write("Enter your password");
        var password = Console.ReadLine();

        IBusiness business= new Business2();
        business.SignUp(userName, password);

    }
}

public interface IBusiness
{
    void SignUp(string userName, string password);
}

public class Business : IBusiness

{
    public void SignUp(string userName, string password)
    {
        var dataAccess = new DataAccess();
        dataAccess.Store(userName, password);
    }
}

public class Business2 : IBusiness

{
    public void SignUp(string userName, string password)
    {
        var dataAccess = new DataAccess();
        dataAccess.Store(userName, password);
    }
}

public interface IDataAccess
{
    void Store(string userName, string password);
}

public class DataAccess : IDataAccess
{
    public void Store(string userName, string password)
    {

    }
}