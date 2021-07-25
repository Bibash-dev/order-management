using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentOneTOManyRelation.Data;
using StudentOneTOManyRelation.Entities;
using StudentOneTOManyRelation.Repository.Interface;

namespace StudentOneTOManyRelation.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> FindAsync(long id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task FlushAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Create(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
        }

        public void Remove(Order order)
        {
            _context.Orders.Remove(order);
        }
    }
}