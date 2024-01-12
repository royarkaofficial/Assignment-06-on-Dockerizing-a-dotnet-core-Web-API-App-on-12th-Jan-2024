namespace MyWebAPIApp
{
    public class WeatherForecast
    {
        static async Task Main()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync("http://localhost:8080/api/tasks");
                Console.WriteLine(response);
            }
        }
    }
}
