using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_SingletonShoppingCart.Models
{
    public class CustomerLoginSession
    {
        // An instance of ShoppingCart  
        private readonly ShoppingCart _shoppingCartInstance = null;
        private readonly string _customerName;
        public string ApplicationId { get; set; }

        /// <summary>  
        /// Default Constructor to initialize Customer Session  
        /// </summary>  
        /// <param name="instance">An instance of singleton class which is passed as a parameter</param>  
        /// <param name="customerLoginApplicationId">Unique Login Session Identifier</param>  
        /// <param name="customerName">Customer Name</param>  
        public CustomerLoginSession(ShoppingCart instance, string customerLoginApplicationId, string customerName)
        {
            _shoppingCartInstance = instance;
            ApplicationId = customerLoginApplicationId;
            _customerName = customerName;
        }

        /// <summary>  
        /// This method is to the add item into the Shopping Cart  
        /// </summary>  
        /// <param name="itemCode">Item to be added into the shopping cart</param>  
        public void AddItemToShoppingCart(string itemCode)
        {
            _shoppingCartInstance.AddItemToShoppingCart(itemCode);
            Console.WriteLine("{0} added into {1} Cart from {2} ", itemCode, _customerName, ApplicationId);
        }
    }
}