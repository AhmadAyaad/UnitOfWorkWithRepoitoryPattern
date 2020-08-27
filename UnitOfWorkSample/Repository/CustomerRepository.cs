using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkSample.Data;
using UnitOfWorkSample.Entities;
using UnitOfWorkSample.Proxy;

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

        public async Task<IEnumerable<Customer>> GetAll()
        {

            var customers = _context.Customers.AsNoTracking().Select(MapToProxy).ToList();
            return await Task.FromResult(customers);
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


        private CustomerProxy MapToProxy(Customer customer)
        {
            return new CustomerProxy()
            {
                CustomerID = customer.CustomerID,
                Address = customer.Address,
                Name = customer.Name,
                Orders = customer.Orders
            };
        }
    }
}
