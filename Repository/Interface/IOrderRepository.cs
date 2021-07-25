using System.Collections.Generic;
using System.Threading.Tasks;
using StudentOneTOManyRelation.Entities;

namespace StudentOneTOManyRelation.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<Order> FindAsync(long id);
        Task FlushAsync();
        Task Create(Order order);
        void Update(Order order);
        void Remove(Order order);
    }
}