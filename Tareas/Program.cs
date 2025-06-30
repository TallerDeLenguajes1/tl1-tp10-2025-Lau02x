// See https://aka.ms/new-console-template for more information
using System.Resources;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tareas;
HttpClient client = new HttpClient();
HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos");
response.EnsureSuccessStatusCode();
string responseBody = await response.Content.ReadAsStringAsync();
List<Tarea> lista_tareas = JsonSerializer.Deserialize<List<Tarea>>(responseBody) ?? new List<Tarea>();
List<Tarea> lista_tareas_ordenada = new List<Tarea>();
string path_build = Directory.GetCurrentDirectory();
string path_relativo = Directory.GetParent(path_build).Parent.Parent.FullName;
string path_archivoJson = path_relativo + "\\tareas.json";

System.Console.WriteLine("-----Pendientes: -----\n");
foreach (var tarea in lista_tareas)
{
    if (!tarea.Completed)
    {
        Console.WriteLine("\nTitulo:" + tarea.title + "\ncompletado:" + tarea.completed);
    }
}

System.Console.WriteLine("-----Completados: -----\n");
foreach (var tarea in lista_tareas)
{
    if (tarea.Completed)
    {
        Console.WriteLine("\nTitulo:" + tarea.title + "\ncompletado:" + tarea.completed);
    }
}
string jsonString = JsonSerializer.Serialize(lista_tareas);



namespace Tareas
{
public class Tarea
{
    public int userId { get; set; }
    public int id { get; set; }
    public string title { get; set; }
    public bool completed { get; set; }
}


