using TemplateMethod.Common.Interfaces;
using TemplateMethod.Common.Models;
using TemplateMethod.Common.Storage;

namespace TemplateMethod.Common.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public void AddRange(IList<T> data)
        {
            if(typeof(T) == typeof(Person))
                PeopleDataStore.People.AddRange((IList<Person>)data);
        }
    }
}
