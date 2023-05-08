using WebApiHomeTask.Entities;
using WebApiHomeTask.Repositories.Abstract;
using WebApiHomeTask.Services.Abstract;

namespace WebApiHomeTask.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void AddElement(Order element)
        {
            _orderRepository.AddElement(element);
        }

        public void DeleteElement(int id)
        {
            _orderRepository.DeleteElement(id);
        }

        public IEnumerable<Order> GetAllElements()
        {
            return _orderRepository.GetAllElements();
        }

        public Order GetElement(int id)
        {
            return _orderRepository.GetElement(id);
        }

        public void UpdateElement(Order element)
        {
            _orderRepository.UpdateElement(element);
        }
    }
}
