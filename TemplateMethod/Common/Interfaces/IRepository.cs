namespace TemplateMethod.Common.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public void AddRange(IList<T> data);
    }
}
