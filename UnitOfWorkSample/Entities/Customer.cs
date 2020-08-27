using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfWorkSample.Entities
{
    public  class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();


        // Lazy Loading using Value Holder Structure

        //not completed in implementation
        //public Lazy<byte[]> ProfilePictureValueHolder { get; set; }
        //public byte[] ProfilePicture
        //{
        //    get
        //    {
        //        return ProfilePictureValueHolder.Value;
        //    }
        //}


        public virtual byte[] ProfilePicture{ get; set; }
    }
}
