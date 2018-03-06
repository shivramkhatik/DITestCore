using System;
using System.ComponentModel.DataAnnotations;

namespace DITestCore.Business
{
    public class Customer
    {
        [Key]
        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }
    }
}
