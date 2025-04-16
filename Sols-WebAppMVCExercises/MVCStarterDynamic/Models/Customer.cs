using System.ComponentModel;

namespace MVCStarterDynamic.Models {
    public class Customer {

        public Customer(int inputId) {
            Id = inputId;
        }

        public Customer(int id, string firstName, string lastName) : this(id) {
            FirstName = firstName;
            LastName = lastName;
        }

        [DisplayName("Customer no.")]
        public int Id { get; set; }

        [DisplayName("First name")]
        public string? FirstName { get; set; }

        [DisplayName("Last name")]
        public string? LastName { get; set; }


        public override string ToString() {
            return $"No: {Id} - {FirstName} {LastName} ";
        }

    }
}
