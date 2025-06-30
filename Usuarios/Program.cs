
using System.Resources;
using System.Text.Json;
using System.Text.Json.Serialization;
HttpClient client = new HttpClient();
HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");
response.EnsureSuccessStatusCode();
string responseBody = await response.Content.ReadAsStringAsync();
List<Usuario> lista_usuarios = JsonSerializer.Deserialize<List<Usuario>>(responseBody)?? new List<Usuario>();
int i=0;
foreach (var usuario in lista_usuarios)
{
  
    {
        Console.WriteLine("\nNombre:" + usuario.Name + "\nCorreo:" + usuario.Email +
        "\n Ciudad:" + usuario.Address.City + "\n Calle: " + usuario.Address.Street +
        "\n Suite:" + usuario.Address.Suite);
    }
    if (i==4){ break; }
    i++;
}
public class Address
    {
        [JsonPropertyName("street")]
        public required string Street { get; set; }
        [JsonPropertyName("suite")]
        public required string Suite { get; set; }
        [JsonPropertyName("city")]
        public required string City { get; set; }

        [JsonPropertyName("zipcode")]
        public required string Zipcode { get; set; }

    }
public class Usuario
{

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("address")]
        public Address Address { get; set; }
 }

