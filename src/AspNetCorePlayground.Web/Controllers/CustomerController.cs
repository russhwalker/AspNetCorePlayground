using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AspNetCorePlayground.Web.ViewModels;
using AspNetCorePlayground.Core;

namespace AspNetCorePlayground.Web.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            var viewModel = new CustomersViewModel
            {
            };
            return View(viewModel);
        }

        public IActionResult EditMany()
        {
            var customers = this.customerRepository.GetCustomers();
            var viewModel = new CustomersViewModel
            {
                Customers = customers.Select(c => new CustomerViewModel
                {
                    CustomerId = c.CustomerId,
                    CustomerStatusId = c.CustomerStatusId,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                }).ToList()
            };
            return View(viewModel);
        }

        public IActionResult Edit(int id = 0)
        {
            var customer = id == 0 ? new Core.Data.Customer
            {
                CustomerId = 0
            }
            : this.customerRepository.GetCustomer(id);
            var viewModel = new CustomerViewModel
            {
                CustomerId = customer.CustomerId,
                CustomerStatusId = customer.CustomerStatusId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                CustomerStatuses = this.customerRepository.GetCustomerStatuses()
                    .ToDictionary(s => s.CustomerStatusId, s => s.StatusText)
            };
            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}