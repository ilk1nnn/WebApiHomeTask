using WebApiHomeTask.Entities;
using WebApiHomeTask.Repositories.Abstract;
using WebApiHomeTask.Services.Abstract;

namespace WebApiHomeTask.Services.Concrete
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepo;

        public ProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public void AddElement(Product element)
        {
            _productRepo.AddElement(element);
        }

        public void DeleteElement(int id)
        {
            _productRepo.DeleteElement(id);
        }

        public IEnumerable<Product> GetAllElements()
        {
            return _productRepo.GetAllElements();
        }

        public Product GetElement(int id)
        {
            return _productRepo.GetElement(id);
        }

        public void UpdateElement(Product element)
        {
            _productRepo.UpdateElement(element);
        }
    }
}
