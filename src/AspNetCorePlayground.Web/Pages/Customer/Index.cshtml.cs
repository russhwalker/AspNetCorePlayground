using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCorePlayground.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCorePlayground.Web.Views.Customer
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerRepository customerRepository;

        public IndexModel(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public int CustomerCount { get; set; }

        public void OnGet()
        {
            this.CustomerCount = this.customerRepository.GetCustomers().Count;
        }

    }
}