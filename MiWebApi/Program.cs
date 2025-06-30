using System.Text.Json;
using System.Text.Json.Serialization; //para el propertyname
using Verdades;
HttpClient client = new HttpClient();
List<Hecho> Hechos = new List<Hecho>();
Hecho hecho = new Hecho();
string path_build = Directory.GetCurrentDirectory();
string path_relativo = Directory.GetParent(path_build).Parent.Parent.FullName;
string path_archivoJson = path_relativo + "\\HechosDeGatos.json";
string stringJson=string.Empty;
for (int i = 0; i < 5; i++)
{
    HttpResponseMessage response = await client.GetAsync("https://catfact.ninja/fact");
    response.EnsureSuccessStatusCode();
    string responseBody = await response.Content.ReadAsStringAsync();
    hecho = JsonSerializer.Deserialize<Hecho>(responseBody) ?? new Hecho();
    Console.WriteLine($"Hecho: {hecho.Fact}");
    Hechos.Add(hecho);
}

stringJson = JsonSerializer.Serialize(Hechos);
File.WriteAllText(path_archivoJson,stringJson);








namespace Verdades
{
    public class Hecho
    {
        [JsonPropertyName("fact")]
        public string Fact { set; get; } = string.Empty;
        [JsonPropertyName("length")]
        public int Length { set; get; } = 0;

        public Hecho() { }
    }
}