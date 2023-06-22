using TemplateMethod.Common.Models;
using TemplateMethod.Template;

var xmlImporter = new XmlImporter();
var csvImporter = new CsvImporter();
var jsonImporter = new JsonImporter();

var tasks = new List<Task>
{
    xmlImporter.ImportAsync<Person>("people.xml"),
    csvImporter.ImportAsync<Person>("people.csv"),
    jsonImporter.ImportAsync<Person>("people.json")
};

await Task.WhenAll(tasks);