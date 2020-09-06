using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web_SingletonShoppingCart.Models;

namespace Web_SingletonShoppingCart.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        LoggedinCustomers loggedinCustomers;

        public HomeController()
        {
            loggedinCustomers = new LoggedinCustomers();
        }

        public ActionResult Index()
        {
            var customer = LoginCustomer(loggedinCustomers, User.Identity.Name);
            StartShopping(customer, "001");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddItem(string ItemCode)
        {
            var customer = LoginCustomer(loggedinCustomers, User.Identity.Name);
            StartShopping(customer, ItemCode);
            return View();
        }

        private static Customer LoginCustomer(LoggedinCustomers loggedinCustomers, string username)
        {
            //search if the entered customer is already logged in then use the object   
            var currentCustomer = loggedinCustomers.GetCustomer(username);
            return currentCustomer;
        }

        private static void StartShopping(Customer customer, string itemCode)
        {
            customer.AddItemToShoppingCart(itemCode);
        }

        private static void PrintLoggedinCustomers(LoggedinCustomers loggedinCustomers)
        {
            var customers = loggedinCustomers.GetCustomers();
            if (0 >= customers.Count)
            {
                Console.WriteLine("No Customer is currently logged in to the application");
            }
            else
            {
                foreach (Customer customer in customers)
                {
                    //List<CustomerLoginSession> loginSessions = customer.GetCustomerLoginSessions();
                    //string applications = string.Join(", ", from item in loginSessions select item.ApplicationId);
                    //Console.WriteLine("{0} is currently logged in from {1}", customer.CustomerName, applications);
                    customer.PrintShoppingCartItem();
                }
            }
        }
    }
}