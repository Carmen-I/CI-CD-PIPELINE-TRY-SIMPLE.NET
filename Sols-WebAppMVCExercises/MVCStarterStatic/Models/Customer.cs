namespace MVCStarterStatic.Models {
    public class Customer {

        public Customer(int inId, string inFirstName, string inLastName) {
            Id = inId;
            FirstName = inFirstName;
            LastName = inLastName;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString() {
            return $"No: {Id} - {FirstName} {LastName} ";
        }
    }
}
