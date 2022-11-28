internal class Program
{
    private static HttpClient client= new HttpClient();
    private static async Task Main(string[] args)
    {
     try{
        HttpResponseMessage responsemessage= await client.GetAsync("https://jsonplaceholder.typicode.com/users");
        if(responsemessage.IsSuccessStatusCode){
            string responseBody= await responsemessage.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }else{
            Console.WriteLine(responsemessage.StatusCode);
        }

     }catch(HttpRequestException e){
        Console.WriteLine($"Exception Caught! Message{0}", e.Message);
     }
    }
}