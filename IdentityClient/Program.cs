using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IdentityClient
{
    class Program
    {
        static async Task Main()
        {
            var client = new HttpClient();

            // discover endpoints from metadata
            var discovery = await client.GetDiscoveryDocumentAsync("http://localhost:5000");

            if (discovery.IsError)
            {
                Console.WriteLine(discovery.Error);

                return;
            }

            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discovery.TokenEndpoint,

                ClientId = "applicationCON",

                ClientSecret = "prueba_CON",

                Scope = "rotuladores"
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);

                return;
            }

            Console.WriteLine(tokenResponse.Json);

            // API calls

            var apiClient = new HttpClient();

            Console.WriteLine();
            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||| IDENTITY CLAIM");
            Console.WriteLine();

            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var responseIdentity = await apiClient.GetAsync("https://localhost:44309/identity");

            if (!responseIdentity.IsSuccessStatusCode)
            {
                Console.WriteLine(responseIdentity.StatusCode);
            }
            else
            {
                var content = await responseIdentity.Content.ReadAsStringAsync();

                Console.WriteLine(JArray.Parse(content));
            }

            Console.WriteLine();
            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||| ROTULADORES GET");
            Console.WriteLine();

            var responseRotuladores = await apiClient.GetAsync("https://localhost:44309/api/rotuladores");

            if (!responseRotuladores.IsSuccessStatusCode)
            {
                Console.WriteLine(responseRotuladores.StatusCode);
            }
            else
            {
                var content = await responseRotuladores.Content.ReadAsStringAsync();

                Console.WriteLine(JArray.Parse(content));
            }

            Console.WriteLine();
            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||| ROTULADORES POST");
            Console.WriteLine();

            HttpContent bodyContent = new StringContent("{\"marca\": \"Carioca\", \"modelo\": \"1995\"}", Encoding.UTF8, "application/json");

            var responseRotuladorPost = await apiClient.PostAsync("https://localhost:44309/api/rotuladores", bodyContent);

            if (!responseRotuladorPost.IsSuccessStatusCode)
            {
                Console.WriteLine(responseRotuladorPost.StatusCode);
            }
            else
            {
                var content = await responseRotuladorPost.Content.ReadAsStringAsync();

                Console.WriteLine(JObject.Parse(content));
            }
        }
    }
}
