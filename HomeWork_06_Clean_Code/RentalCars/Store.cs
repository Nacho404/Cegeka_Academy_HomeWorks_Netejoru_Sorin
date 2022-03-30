using System;
using System.Collections.Generic;

namespace RentalCars
{
    public class Store
    {
        private readonly List<Rental> Rentals = new List<Rental>(); //lista de inchirieri

        private string _storeName;

        public Store(string storeName)
        {
            _storeName = storeName;
        }


        public void AddRental(Rental rental)
        {
            Rentals.Add(rental);
        }

        public string Statement()
        {
            double totalAmount = 0;

            var r = "Rental Record for " + _storeName + "\n";
            r += "------------------------------\n";

            foreach (var rental in Rentals)
            {
                r += rental.Customer._customerName + "\t" + rental.Car._model + "\t" + rental._daysRented + "d \t" + rental.rentalAmount + " EUR\n";
                totalAmount += rental.rentalAmount;
            }
            r += "------------------------------\n";
            r += "Total revenue " + totalAmount + " EUR\n";

            return r;
        }
    }
}