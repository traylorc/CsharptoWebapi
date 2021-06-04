using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CsharptoWebapi
{
    class Program
    {
        async Task Run()
        {//http client is what lets you talk to your API
            var http = new HttpClient();
            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                
            };
            var url = "http://localhost:41418/api/employees";

            var newEmpl = new Employee()
            {
                Id = 0,
                Firstname = "Jeff",
                Lastname = "North",
                Login = "JNorth",
                Password = "Bluwiz1!",
                IsManager = true
            };
            var json = JsonSerializer.Serialize<Employee>(newEmpl, jsonSerializerOptions);
            var httpContent2 = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var httpMessageRespone2 = await http.PostAsync(url, httpContent2);

            var httpMessageRespone = await http.GetAsync(url);
            var httpContent = await httpMessageRespone.Content.ReadAsStringAsync();
            var employees = JsonSerializer.Deserialize<Employee[]>(httpContent, jsonSerializerOptions);

            foreach(var e in employees)
            {
                Console.WriteLine($"{e.Id} | {e.Lastname}");
            }
        }

        async static Task Main(string[] args)
        {
            var pgm = new Program();
            await pgm.Run();
        }
    }
}
