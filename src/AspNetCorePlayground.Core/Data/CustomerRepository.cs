using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCorePlayground.Core.Data
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly StoreContext storeContext;

        public CustomerRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public List<CustomerStatus> GetCustomerStatuses()
        {
            return this.storeContext.CustomerStatuses.ToList();
        }

        public List<Customer> GetCustomers()
        {
            return this.storeContext.Customers.ToList();
        }

        public Customer GetCustomer(int id)
        {
            return this.storeContext.Customers.Single(c => c.CustomerId == id);
        }

        public Customer SaveCustomer(Customer customer)
        {
            if (customer.CustomerId == 0)
            {
                this.storeContext.Customers.Add(customer);
            }
            else
            {
                this.storeContext.Customers.Attach(customer);
                this.storeContext.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            this.storeContext.SaveChanges();
            return customer;
        }

    }
}