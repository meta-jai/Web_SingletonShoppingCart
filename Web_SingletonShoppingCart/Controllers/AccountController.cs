using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web_SingletonShoppingCart.Models;

namespace Web_SingletonShoppingCart.Controllers
{
    public class AccountController : Controller
    {
        private UserList _userList;
        LoggedinCustomers loggedinCustomers;
        public AccountController()
        {
            _userList = new UserList();
            loggedinCustomers = new LoggedinCustomers();
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // POST: Account
        [HttpPost]
        public ActionResult Index(User user)
        {
            LoggedinCustomers loggedinCustomers = new LoggedinCustomers();
            if (_userList.GetUsers().FirstOrDefault(x => x.Name == user.Name) != null)
            {
                FormsAuthentication.SetAuthCookie(user.Name, false);
                LoginCustomer(loggedinCustomers, user.Name, user.Name);
                return this.RedirectToAction("Index", "Home");
            }

            return View();
        }

        private static Customer LoginCustomer(LoggedinCustomers loggedinCustomers, string username, string application)
        {
            //search if the entered customer is already logged in then use the object   
            var currentCustomer = loggedinCustomers.GetCustomer(username);
            //If the entered customer is not loggedin already then create a new instance   
            if (null == currentCustomer)
            {
                currentCustomer = new Customer(username);
                loggedinCustomers.AddCustomer(currentCustomer);
            }

            currentCustomer.InitializeCustomerLoginSession(application);
            Console.WriteLine("{0} logged in sucessfully from {1} !! Let's Start Shopping ", currentCustomer.CustomerName, application);


            return currentCustomer;
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return this.RedirectToAction("Index", "Account");
        }
    }
}