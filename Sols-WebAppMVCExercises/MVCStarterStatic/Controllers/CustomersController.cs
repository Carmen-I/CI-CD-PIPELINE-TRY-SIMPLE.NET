using Microsoft.AspNetCore.Mvc;
using MVCStarterStatic.Models;

namespace MVCStarterStatic.Controllers {

    public class CustomersController : Controller {
        public IActionResult Index() {
            Customer c1 = new Customer(1, "Bill", "Gates");
            Customer c2 = new Customer(2, "Paul", "Allen");
            Customer c3 = new Customer(3, "Anders", "Hejlsberg");
            List<Customer> custColl = [ c1, c2, c3 ];
            return View(custColl);
        }
    }

}
