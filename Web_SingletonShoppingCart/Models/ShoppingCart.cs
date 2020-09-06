using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_SingletonShoppingCart.Models
{
    /// <summary>  
    /// An abstract representation of Shopping Cart.  
    /// This class is the implementation of singleton design pattern   
    /// which restricts the instantiation of a class to one object  
    /// </summary>  
    public sealed class ShoppingCart
    {
        private static volatile ShoppingCart _instance; //A static variable which holds a reference to the single created instance  
        private static readonly object SyncRoot = new Object();
        private readonly List<string> _itemsAdded = new List<string>();


        /// <summary>  
        /// private and parameterless constructor that prevents other classes from instantiating it  
        /// </summary>  
        private ShoppingCart() { }

        /// <summary>  
        /// This method is to get the instance of ShoppingCart class   
        /// </summary>  
        /// <param name="bCreateInstance">This flag determines whether new instance is to be created or not</param>  
        /// <returns>An instance of ShoppingCart class</returns>  
        public static ShoppingCart Instance(bool bCreateInstance)
        {
            if ((_instance == null) || (bCreateInstance == true))
            {
                lock (SyncRoot)
                {
                    if ((_instance == null) || (bCreateInstance == true))
                        _instance = new ShoppingCart();
                }
            }
            return _instance;
        }

        /// <summary>  
        /// This method is to add item into the Shopping cart  
        /// </summary>  
        /// <param name="itemCode"></param>  
        public void AddItemToShoppingCart(string itemCode)
        {
            _itemsAdded.Add(itemCode);
        }

        /// <summary>  
        /// This method is to get the list of items added into the shopping cart  
        /// </summary>  
        /// <returns>A list of item added into the shopping cart</returns>  
        public List<string> GetShoppingCartItems()
        {
            return _itemsAdded;
        }
    }
}