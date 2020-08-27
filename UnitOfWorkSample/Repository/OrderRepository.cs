using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkSample.Data;
using UnitOfWorkSample.Entities;

namespace UnitOfWorkSample.Repository
{
    public class OrderRepository : IRepostiory<Order>
    {

        readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(Order order)
        {
            _context.Orders.Add(order);
        }

        public void Delete(Order order)
        {
            _context.Orders.Remove(order);
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.Orders.AsNoTracking().ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public Task Update(Order order)
        {
            //First Way to handle sync code in this func

            //_context.Entry(customer).State = EntityState.Modified;
            // return Task.FromResult(true);

            //second Way
            return Task.Run(() => _context.Entry(order).State = EntityState.Modified);
        }
        public async Task<bool> AddAll(IEnumerable<Order> orders)
        {
            await _context.Orders.AddRangeAsync(orders);
            return await Task.FromResult(true);
        }
    }
}
