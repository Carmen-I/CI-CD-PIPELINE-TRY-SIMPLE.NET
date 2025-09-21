using MVCStarterDynamic.Data;
using MVCStarterDynamic.Models;

using Microsoft.AspNetCore.Mvc;

namespace MVCStarterDynamic.Controllers {
    public class CustomersController : Controller {

        private readonly CustomerAccess _customerAccesss;

        // Constructor//test the containers
        public CustomersController() {
            _customerAccesss = CustomerAccess.Instance;     // Singleton
        }

        [HttpGet]
        // .. /customers/index
        public IActionResult Index() {
            List<Customer>? someCustomers = _customerAccesss.GetAllCustomers();
            return View(someCustomers);
        }

        [HttpGet]
        // .. /customers/details/2
        public IActionResult Details(int? id) {
            Customer? foundCustomer = null;
            // Conditional - based on id value - determine situation
            if (id != null) {
                int idValid = (int)id;
                if (id > 0) {
                    foundCustomer = _customerAccesss.GetCustomerById(idValid);
                    if (foundCustomer != null) {
                        ViewBag.Situation = EnumIdValidity.Valid;
                        ViewBag.SubHeadline = "Customer details";
                    } else {
                        ViewBag.Situation = EnumIdValidity.ValidNotFound;
                        ViewBag.SubHeadline = "Customer with " + idValid + " not found";
                    }
                } else {
                    ViewBag.Situation = EnumIdValidity.InvalidMissing;
                    ViewBag.SubHeadLine = "Id must be a positive integer";
                }
            } else {
                ViewBag.Situation = EnumIdValidity.InvalidMissing;
                ViewBag.SubHeadLine = "Id is required - must be a positive integer";
            }
            return View(foundCustomer);
        }

    }
}
