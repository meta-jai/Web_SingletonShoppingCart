using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Web_SingletonShoppingCart.Models
{
    /// <summary>  
    /// This class is a blueprint of a customer   
    /// </summary>  
    public class Customer
    {
        //A local variable to store an instance of ShoppingCart.  
        private readonly ShoppingCart _shoppingCartInstance = null;

        //A list of customer login sessions 
        private readonly List<CustomerLoginSession> _customerLoginSessions = new List<CustomerLoginSession>();

        private CustomerLoginSession CurrentCustomerLoginSession { get; set; }

        #region Properties  

        /// <summary>  
        /// Property to hold customer name  
        /// </summary>  
        public string CustomerName { get; set; }

        #endregion

        #region Constructor  
        /// <summary>  
        /// Constructor to initialize Customer Identifier and Customer Name  
        /// </summary>  
        /// <param name="customerName">Customer Name</param>  
        ///   
        public Customer(string customerName)
        {
            CustomerName = customerName;
            _shoppingCartInstance = ShoppingCart.Instance(true);
        }
        #endregion


        public void AddItemToShoppingCart(string itemCode)
        {
            CurrentCustomerLoginSession.AddItemToShoppingCart(itemCode);
        }

        public void InitializeCustomerLoginSession(string applicationId)
        {
            CustomerLoginSession loginSession = _customerLoginSessions.FirstOrDefault(x => x.ApplicationId == applicationId);

            if (null == loginSession)
            {
                loginSession = new CustomerLoginSession(_shoppingCartInstance, applicationId, CustomerName);
                _customerLoginSessions.Add(loginSession);
            }

            CurrentCustomerLoginSession = loginSession;
        }

        /// <summary>  
        /// This method is to print the items currently added into the shopping cart  
        /// </summary>  
        public void PrintShoppingCartItem()
        {
            List<string> itemsAdded = _shoppingCartInstance.GetShoppingCartItems();

            StringBuilder itemsAddedToShoppingCart = new StringBuilder();
            foreach (var item in itemsAdded)
            {
                if (itemsAddedToShoppingCart.Length > 0)
                    itemsAddedToShoppingCart.Append(", ");

                itemsAddedToShoppingCart.Append(item);
            }
            Console.WriteLine("Items Added in {0}'s Cart :  {1}", CustomerName, itemsAddedToShoppingCart.ToString());
        }
    }
}