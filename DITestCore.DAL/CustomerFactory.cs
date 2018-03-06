using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DITestCore.Business;

namespace DITestCore.DAL
{
    public class CustomerFactory : ICustomerFactory
    {
        private readonly DITestCoreContext _DbContext;

        public CustomerFactory(DITestCoreContext dbContext)
        {
            _DbContext = dbContext;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _DbContext.Customers.AsEnumerable();
        }

        public void Add(Customer customer)
        {
            _DbContext.Customers.Add(customer);
            _DbContext.SaveChanges();
        }
    }
}
