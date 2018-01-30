using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCorePlayground.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Core.Data.StoreContext>(opt => opt.UseInMemoryDatabase("Store"));
            services.AddTransient<Core.ICustomerRepository, Core.Data.CustomerRepository>();
            services.AddTransient<Core.IAddressRepository, Core.Data.AddressRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            SeedDatabase(app.ApplicationServices.GetService<Core.Data.StoreContext>());

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }


        private void SeedDatabase(Core.Data.StoreContext storeContext)
        {
            storeContext.CustomerStatuses.AddRange(new[] {
                new Core.Data.CustomerStatus
                {
                    CustomerStatusId = 1,
                    StatusText = "Active"
                },
                new Core.Data.CustomerStatus
                {
                    CustomerStatusId = 2,
                    StatusText = "InActive"
                }
            });
            storeContext.SaveChanges();

            storeContext.Customers.AddRange(new[] {
                new Core.Data.Customer
                {
                    CustomerStatusId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    CreateDate = DateTime.Today.AddDays(-10)
                },
                new Core.Data.Customer
                {
                    CustomerStatusId = 1,
                    FirstName = "Jane",
                    LastName = "Doe",
                    CreateDate = DateTime.Today.AddDays(-5)
                },
                new Core.Data.Customer
                {
                    CustomerStatusId = 1,
                    FirstName = "Bob",
                    LastName = "Thomas",
                    CreateDate = DateTime.Today.AddDays(4)
                },
                new Core.Data.Customer
                {
                    CustomerStatusId = 1,
                    FirstName = "William",
                    LastName = "Wallace",
                    CreateDate = DateTime.Today.AddDays(3)
                },
                new Core.Data.Customer
                {
                    CustomerStatusId = 2,
                    FirstName = "Andrew",
                    LastName = "Willis",
                    CreateDate = DateTime.Today
                }
            });
            storeContext.SaveChanges();

            storeContext.Addresses.AddRange(new[] {
                new Core.Data.Address
                {
                    CustomerId = 1,
                    Street = "101 Main Street",
                    City = "Columbia",
                    State = "SC",
                    Zip = "29201"
                },
                new Core.Data.Address
                {
                    CustomerId = 1,
                    Street = "101 Physical Street",
                    City = "Columbia",
                    State = "SC",
                    Zip = "29201"
                }
            });
            storeContext.SaveChanges();
        }

    }
}
