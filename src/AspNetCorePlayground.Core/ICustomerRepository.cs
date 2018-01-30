using System.Collections.Generic;

namespace AspNetCorePlayground.Core
{
    public interface ICustomerRepository
    {
        List<Data.CustomerStatus> GetCustomerStatuses();
        List<Data.Customer> GetCustomers();
        Data.Customer GetCustomer(int id);
        Data.Customer SaveCustomer(Data.Customer customer);
    }
}