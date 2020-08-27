using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkSample.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime? CreateAt { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
