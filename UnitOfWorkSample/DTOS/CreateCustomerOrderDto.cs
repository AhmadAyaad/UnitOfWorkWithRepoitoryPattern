using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkSample.Entities;

namespace UnitOfWorkSample.DTOS
{
    public class CreateCustomerOrderDto
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public DateTime CreateAt { get; set; }
    }
}
