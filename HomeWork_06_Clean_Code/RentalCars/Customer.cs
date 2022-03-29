using System.Collections.Generic;

namespace RentalCars
{
    public class Customer
    {
        public string _customerName;

        public Customer(string customerName)
        {
            _customerName = customerName;
        }


        public int FrequentRenterPoints { get; set; }

        public List<Rental> Rentals { get; } = new List<Rental>();

        public void AddRental(Rental rental)
        {
            Rentals.Add(rental);
        }
    }
}