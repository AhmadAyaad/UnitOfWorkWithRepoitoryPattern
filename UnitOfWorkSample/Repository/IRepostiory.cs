using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkSample.Repository
{
    public interface IRepostiory<T>
    {

        void Create(T t);
        void Delete(T t);
        Task Update(T t);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        public Task<bool> AddAll(IEnumerable<T> orders);
    }
}
