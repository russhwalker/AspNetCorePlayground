using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCorePlayground.Core.Data
{
    public class AddressRepository : IAddressRepository
    {

        private readonly StoreContext storeContext;

        public AddressRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }
        
        public List<Address> GetAddresses(int customerId)
        {
            return this.storeContext.Addresses.Where(a => a.CustomerId == customerId).ToList();
        }

        public Address GetAddress(int id)
        {
            return this.storeContext.Addresses.Single(c => c.AddressId == id);
        }

        public bool SaveAddress(Address address)
        {
            if (address.AddressId == 0)
            {
                this.storeContext.Addresses.Add(address);
            }
            else
            {
                this.storeContext.Addresses.Attach(address);
                this.storeContext.Entry(address).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return this.storeContext.SaveChanges() > 0;
        }

    }
}