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
    if (!tarea.completed)
    {
        Console.WriteLine("\nTitulo:" + tarea.title + "\ncompletado:" + tarea.completed);
    }
}

System.Console.WriteLine("-----Completados: -----\n");
foreach (var tarea in lista_tareas)
{
    if (tarea.completed)
    {
        Console.WriteLine("\nTitulo:" + tarea.title + "\ncompletado:" + tarea.completed);
    }
}
string jsonString = JsonSerializer.Serialize(lista_tareas);





public class Tarea
{
    public int userId { get; set; }
    public int id { get; set; }
    public string title { get; set; }
    public bool completed { get; set; }
}


