namespace WebApiHomeTask.Repositories.Abstract
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAllElements();
        T GetElement(int id);
        void AddElement(T element); 
        void DeleteElement(int id); 
        void UpdateElement(T element);
    }
}
