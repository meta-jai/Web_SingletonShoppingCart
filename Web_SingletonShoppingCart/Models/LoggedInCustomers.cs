using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_SingletonShoppingCart.Models
{
    public class LoggedinCustomers
    {
        private static readonly List<Customer> _customers = new List<Customer>();

        /// <summary>  
        /// This method is to get the customer from loggedin customer collection based on the customer name  
        /// </summary>  
        /// <param name="customerName">Customer Name</param>  
        /// <returns>An instance of customer</returns>  
        public Customer GetCustomer(string customerName)
        {
            Customer customer = _customers.FirstOrDefault(x => x.CustomerName == customerName);
            return customer;
        }

        /// <summary>  
        /// This method is to add customer into the loggedin customer collection  
        /// </summary>  
        /// <param name="customer">an instance of customer class</param>  
        public void AddCustomer(Customer customer)
        {
            _customers?.Add(customer);
        }

        /// <summary>  
        ///   
        /// </summary>  
        /// <returns></returns>  
        public List<Customer> GetCustomers()
        {
            return _customers;
        }
    }
}