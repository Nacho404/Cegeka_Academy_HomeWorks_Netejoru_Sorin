using System.Collections.Generic;

namespace RentalCars
{
    public class Customer
    {
        public string _customerName;
        public int _frequentRenterPoints = 0;

        public Customer(string customerName)
        {
            _customerName = customerName;
        }
    }
}