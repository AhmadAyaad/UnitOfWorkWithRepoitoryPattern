using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkSample.Data;
using UnitOfWorkSample.Entities;
using UnitOfWorkSample.Repository;

namespace UnitOfWorkSample.UnitOfWork
{
    class UnitOFWork : IUnitOfWork
    {
        readonly DataContext _context;
        public UnitOFWork(DataContext context)
        {
            _context = context;
        }
        IRepostiory<Customer> customerRepo;
        IRepostiory<Order> orderRepo;

        public IRepostiory<Customer> CustomerRepo
        {
            get
            {
                if (customerRepo == null)
                    customerRepo = new CustomerRepository(_context);
                return customerRepo;
            }
        }
        public IRepostiory<Order> OrderRepo
        {
            get
            {
                if (orderRepo == null)
                    orderRepo = new OrderRepository(_context);
                return orderRepo;
            }
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
