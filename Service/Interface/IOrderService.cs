using System.Threading.Tasks;
using StudentOneTOManyRelation.dto;
using StudentOneTOManyRelation.Entities;

namespace StudentOneTOManyRelation.Service.Interface
{
    public interface IOrderService
    {
        Task Create(OrderDto dto);
        Task Update(Order order,OrderDto dto);
        Task Remove(Order order);
    }
}