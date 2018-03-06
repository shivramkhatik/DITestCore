using System;
using DITestCore.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DITestCore.DAL
{
    public class DITestCoreContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private DbContextOptions<DITestCoreContext> _Options;

        public DbSet<Customer> Customers { get; set; }

        //public DITestCoreContext(DbContextOptions<DITestCoreContext> options) : base(options)
        //{
        //    _Options = options;

        //    InitializeDB();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var connection = @"Server =.\; Database = DITestCore; Trusted_Connection = True; MultipleActiveResultSets = true";
            optionsBuilder.UseSqlServer(connection);
        }

        public DITestCoreContext()
        {
        }

        private IServiceCollection _Container;
        public IServiceCollection Container
        {
            get
            {
                return _Container;
            }
            set
            {
                if(_Container != value)
                {
                    _Container = value;

                    InitializeDBFactories();
                }
            }
        }

        public void InitializeDB()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

            var cus1 = new Customer()
            {
                FirstName = "Robert",
                LastName = "Moranelli"
            };

            var cus2 = new Customer()
            {
                FirstName = "Shiv",
                LastName = "Ameria"
            };

            this.Customers.AddRange(cus1, cus2);
            this.SaveChanges();
        }

        private void InitializeDBFactories()
        {
            if (Container != null)
            {
                Container.AddScoped<ICustomerFactory, CustomerFactory>();
            }
        }

    }
}
