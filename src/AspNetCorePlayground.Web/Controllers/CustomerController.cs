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

        public IActionResult List()
        {
            var customers = this.customerRepository.GetCustomers();
            var customerStatuses = this.customerRepository.GetCustomerStatuses();
            var viewModel = new CustomersViewModel
            {
                Customers = customers.Select(c => new CustomerViewModel
                {
                    CustomerId = c.CustomerId,
                    CustomerStatusId = c.CustomerStatusId,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    CustomerStatuses = customerStatuses.ToDictionary(s => s.CustomerStatusId, s => s.StatusText)
                }).ToList()
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
            var customer = this.customerRepository.GetCustomer(id) ?? new Core.Data.Customer
            {
                CustomerId = 0
            };
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

        [HttpPost]
        public IActionResult Edit(CustomerViewModel viewModel)
        {
            var customer = viewModel.CustomerId != 0
                ? this.customerRepository.GetCustomer(viewModel.CustomerId)
                : new Core.Data.Customer();
            customer.FirstName = viewModel.FirstName;
            customer.LastName = viewModel.LastName;
            customer.CustomerStatusId = viewModel.CustomerStatusId;
            this.customerRepository.SaveCustomer(customer);
            return RedirectToAction(nameof(List));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}