using System.Threading.Tasks;
using System.Net.Http;
using System;
namespace Async
{
    public class TaksDemo
    {
        public static async Task <int> GetUrlContentLenghtAsync(){
            var client = new HttpClient();
            Task<string> getStringTask=client.GetStringAsync("https://docs.microsoft.com/dotnet");
            DoIndependentWork();
            string content=await getStringTask;
            return content.Length;
        }

        static void DoIndependentWork(){
            Console.WriteLine("working......");
        }
    }
}