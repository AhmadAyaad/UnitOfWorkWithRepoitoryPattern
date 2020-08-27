using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkSample.Data;
using UnitOfWorkSample.Entities;

namespace UnitOfWorkSample.Repository
{
    public class CustomerRepository : IRepostiory<Customer>
    {

        readonly DataContext _context;
        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public Task<bool> AddAll(IEnumerable<Customer> orders)
        {
            throw new NotImplementedException();
        }

        public void Create(Customer customer)
        {
            _context.Add(customer);
        }

        public void Delete(Customer customer)
        {
            _context.Remove(customer);
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public Task Update(Customer customer)
        {
            //First Way to handle sync code in this func
            
            //_context.Entry(customer).State = EntityState.Modified;
            // return Task.FromResult(true);
            
            //second Way
            return Task.Run(() => _context.Entry(customer).State = EntityState.Modified);
        }
    }
}
