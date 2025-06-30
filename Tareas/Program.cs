// See https://aka.ms/new-console-template for more information
using System.Resources;
using System.Text.Json;
using System.Text.Json.Serialization;

HttpClient client = new HttpClient();
HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos");
response.EnsureSuccessStatusCode();
string responseBody = await response.Content.ReadAsStringAsync();
List<Tarea> lista_tareas = JsonSerializer.Deserialize<List<Tarea>>(responseBody);
System.Console.WriteLine("-----Pendientes: -----\n");
foreach (var tarea in lista_tareas)
{
    if (!tarea.Completed)
    {
        Console.WriteLine("\nTitulo:" + tarea.Title + "\ncompletado:" + tarea.Completed);
    }
}

System.Console.WriteLine("-----Completados: -----\n");
foreach (var tarea in lista_tareas)
{
    if (tarea.Completed)
    {
        Console.WriteLine("\nTitulo:" + tarea.Title + "\ncompletado:" + tarea.Completed);
    }
}
string jsonString = JsonSerializer.Serialize(lista_tareas);
GuardarArchivosTexto("textos", jsonString);



void GuardarArchivosTexto(string nombreArchivo,string datos)
{
    using (var archivo = new FileStream(nombreArchivo, FileMode.Create))
    {
        using (var strWriter = new StreamWriter(archivo))
        {
            strWriter.WriteLine("{0}", datos);
            strWriter.Close();
        }
    }
}



public class Tarea
{
    [JsonPropertyName("userId")]
    public int UserId { get; set; }
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("completed")]
    public bool Completed { get; set; }
}


