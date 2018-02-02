using System;
using System.Collections.Generic;

namespace AspNetCorePlayground.Web.ViewModels
{
    public class CustomersViewModel
    {
        public CustomersViewModel()
        {
            this.Customers = new List<CustomerViewModel>();
        }

        public List<CustomerViewModel> Customers { get; set; }

    }
}