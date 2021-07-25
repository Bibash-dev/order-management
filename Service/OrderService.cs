using System.Threading.Tasks;
using System.Transactions;
using System.Xml;
using StudentOneTOManyRelation.dto;
using StudentOneTOManyRelation.Entities;
using StudentOneTOManyRelation.Repository.Interface;
using StudentOneTOManyRelation.Service.Interface;

namespace StudentOneTOManyRelation.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Create(OrderDto dto)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var order = new Order()
            {
               Department = dto.Department,
               Employee = dto.Employee,
               Name = dto.Name,
               Price = dto.Price,
               Product = dto.Product,
               
            };
            await _orderRepository.Create(order);
            await _orderRepository.FlushAsync();
            tsc.Complete();
        }

        public async Task Update(Order order, OrderDto dto)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            order.Department = dto.Department;
            order.Employee = dto.Employee;
            order.Name = dto.Name;
            order.Price = dto.Price;
            order.Product = dto.Product;
            _orderRepository.Update(order);
            await _orderRepository.FlushAsync();
            tsc.Complete();
        }


        public async Task Remove(Order order)
        {
            using var tsc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            _orderRepository.Remove(order);
            await _orderRepository.FlushAsync();
            tsc.Complete();

        }
    }
}