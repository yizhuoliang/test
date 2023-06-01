using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("\nChek1");
        // If the server uses a self-signed certificate
        // DO NOT use in production
        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
        var client = new HttpClient(handler);

        var requestBody = new { number = 5 };
        var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
        Console.WriteLine("\nChek2");
        try
        {
            HttpResponseMessage response = await client.PostAsync("https://localhost:5000/square", content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<dynamic>(responseBody);
            Console.WriteLine($"The square of {requestBody.number} is {data.result}");
        }
        catch(HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine($"Message: {e.Message}");
        }

        Console.WriteLine("\nChek3");
    }
}
