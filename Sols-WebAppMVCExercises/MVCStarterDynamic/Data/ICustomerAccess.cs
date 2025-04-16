using MVCStarterDynamic.Models;

namespace MVCStarterDynamic.Data {
    public interface ICustomerAccess {

        List<Customer>? GetAllCustomers();

        Customer? GetCustomerById(int id);

    }
}
