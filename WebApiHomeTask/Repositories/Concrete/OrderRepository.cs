using WebApiHomeTask.Data;
using WebApiHomeTask.Entities;
using WebApiHomeTask.Repositories.Abstract;

namespace WebApiHomeTask.Repositories.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CommerceDbContext _dbContext;

        public OrderRepository(CommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddElement(Order element)
        {
            _dbContext.Orders.Add(element); 
            _dbContext.SaveChanges();
        }

        public void DeleteElement(int id)
        {
            var element = _dbContext.Orders.FirstOrDefault(o=>o.Id == id);
            _dbContext.Orders.Remove(element);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAllElements()
        {
            return _dbContext.Orders;
        }

        public Order GetElement(int id)
        {
            var order = _dbContext.Orders.FirstOrDefault(o=>o.Id == id);    
            return order;
        }

        public void UpdateElement(Order element)
        {
            _dbContext.Orders.Update(element);
            _dbContext.SaveChanges();
        }
    }
}
