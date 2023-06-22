using TemplateMethod.Common.Models;

namespace TemplateMethod.Common.Storage
{
    public class PeopleDataStore
    {
        public static List<Person> People { get; set; } = new List<Person>();
    }
}
