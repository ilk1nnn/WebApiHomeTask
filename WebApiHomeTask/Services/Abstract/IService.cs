namespace WebApiHomeTask.Services.Abstract
{
    public interface IService<T>
    {
        IEnumerable<T> GetAllElements();
        T GetElement(int id);
        void AddElement(T element);
        void DeleteElement(int id);
        void UpdateElement(T element);
    }
}
