using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCorePlayground.Core
{
    public interface IAddressRepository
    {
        Data.Address GetAddress(int id);
        List<Data.Address> GetAddresses(int customerId);
        bool SaveAddress(Data.Address address);
    }
}