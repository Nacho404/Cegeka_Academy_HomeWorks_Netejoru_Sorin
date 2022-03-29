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
    }
}