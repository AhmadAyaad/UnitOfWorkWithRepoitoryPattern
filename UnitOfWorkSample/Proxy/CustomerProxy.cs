using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkSample.Entities;

namespace UnitOfWorkSample.Proxy
{
    public class CustomerProxy : Customer
    {
        public override byte[] ProfilePicture
        {
            get
            {
                if (base.ProfilePicture == null)
                    base.ProfilePicture = new byte[] { 1, 2 };
                return base.ProfilePicture;
            }
        }
    }
}
