using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkSample.Entities;
using UnitOfWorkSample.Repository;

namespace UnitOfWorkSample.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepostiory<Customer> CustomerRepo { get; }
        IRepostiory<Order> OrderRepo { get; }

        Task<int> SaveChanges();
    }
}
