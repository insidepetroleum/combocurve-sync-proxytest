using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboCurve.Sync.Proxy.Client.Clients
{
    internal class ApiClient
    {
        public static async Task CallApi(Uri url)
        {
            Console.WriteLine($"\n---\nCalling API {url}...\n");

            using var client = new HttpClient
            {
                BaseAddress = url
            };

            var response = await client.GetAsync("/api/value");

            Console.WriteLine($"Response status code: {response.StatusCode}");
            
            var responseContent = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseContent);
        }
    }
}
