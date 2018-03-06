using System;
using System.Collections.Generic;
using System.Text;
using DITestCore.Business;

namespace DITestCore.DAL
{
    public interface ICustomerFactory
    {
        IEnumerable<Customer> GetAll();
        void Add(Customer customer);
    }
}
