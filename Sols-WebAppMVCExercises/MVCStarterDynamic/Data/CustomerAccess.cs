using MVCStarterDynamic.Models;

namespace MVCStarterDynamic.Data {
    public class CustomerAccess : ICustomerAccess {

        private static CustomerAccess? _instance;

        private readonly List<Customer>? _customers;

        // private constructor
        private CustomerAccess() {
            Customer c1 = new Customer(1, "Bill", "Gates");
            Customer c2 = new Customer(2, "Paul", "Allen");
            Customer c3 = new Customer(3, "Brad", "Smith");
            Customer c4 = new Customer(4, "Anders", "Hejlsberg");
            _customers = new List<Customer>() { c1, c2, c3, c4 };
        }

        // Singleton pattern 
        public static CustomerAccess Instance {
            get {
                if (_instance == null) {
                    _instance = new CustomerAccess();
                }
                // Alternative compound syntax: _instance ??= new CustomerAccess();
                return _instance;
            }
        }

        public List<Customer>? GetAllCustomers() {
            return _customers;
        }

        public Customer? GetCustomerById(int id) {
            Customer? foundCustomer = null;
            if (_customers != null) {
                foreach (Customer cust in _customers) {
                    if (cust.Id == id) {
                        foundCustomer = cust;
                    }
                }
            }
            return foundCustomer;
            ////Alternative:
            //return _customers?.FirstOrDefault(cust => cust.Id == id);
        }

    }
}
