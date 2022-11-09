using System;
using Microsoft.Extensions.DependencyInjection;
internal class Program
{
    private static void Main(string[] args)
    {
        var collection = new ServiceCollection();
        collection.AddScoped<IDataAccess, DataAccess>();
        collection.AddScoped<IBusiness, Business2>();

        var provider= collection.BuildServiceProvider();


        IDataAccess dal = provider.GetService<IDataAccess>();
        IBusiness biz= provider.GetService<IBusiness>();
        var userinterface= new UserInterface(biz);
        userinterface.GetData();
    }
}

public class UserInterface
{
    private  readonly IBusiness _business;
    public UserInterface (IBusiness business){
        _business=business;
    }
    public void GetData(){
        Console.WriteLine("Enter your username:");
        var userName=Console.ReadLine();

        Console.Write("Enter your password:");
        var password = Console.ReadLine();

        
        _business.SignUp(userName, password);

    }
}

public interface IBusiness
{
    void SignUp(string userName, string password);
}

public class Business : IBusiness
{
    private readonly IDataAccess _dataaccess;
    public Business(IDataAccess dataAccess){
        _dataaccess=dataAccess;
    }
    public void SignUp(string userName, string password)
    {
        
        _dataaccess.Store(userName, password);
    }
}

public class Business2 : IBusiness
{

    private readonly IDataAccess _dataaccess;
    public Business2(IDataAccess dataAccess){
        _dataaccess=dataAccess;
    }
    public void SignUp(string userName, string password)
    {
        var dataAccess = new DataAccess();
        _dataaccess.Store(userName, password);
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
        Console.WriteLine(userName+" "+password);
    }
}