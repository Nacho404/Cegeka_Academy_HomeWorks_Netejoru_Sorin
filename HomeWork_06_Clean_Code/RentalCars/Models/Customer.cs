using System.Collections.Generic;

namespace RentalCars
{
    public class Customer
    {
        public string _name;
        public string _cnp;
        public int frequentRenterPoints = 0;

        public Customer(string customerName, string cnp)
        {
            _name = customerName;
            _cnp = cnp;
        }

        public void SetCustomerPoints(string priceCode, int daysRented)
        {
            if (priceCode == "Premium" && daysRented > 1)
            {
                frequentRenterPoints++;
            }

            frequentRenterPoints++;
        }
    }
}