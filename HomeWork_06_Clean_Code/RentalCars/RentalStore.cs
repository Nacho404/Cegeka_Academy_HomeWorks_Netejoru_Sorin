using System;
using System.Collections.Generic;

namespace RentalCars
{
    public class RentalStore
    {
        private readonly List<Rental> Rentals = new List<Rental>(); //lista de inchirieri

        private string _storeName;

        public RentalStore(string storeName)
        {
            _storeName = storeName;
        }


        public void AddRental(Rental rental)
        {
            Rentals.Add(rental);
        }

        public string Statement()
        {
            double pricePerDay = 20;// why is the price 20 euro for all car categories?
            double totalAmount = 0;
            var frequentRenterPoints = 0;

            var r = "Rental Record for " + _storeName + "\n";
            r += "------------------------------\n";

            foreach (var rental in Rentals)
            {
                double thisAmount = 0;// i must change the name of this variable

                // determines the amount for each line
                switch (rental.Car._priceCode)
                {
                    case PriceCode.Regular:
                        thisAmount += pricePerDay * 2;
                        if (rental._daysRented > 2)
                            thisAmount += (rental._daysRented - 2) * pricePerDay * 0.75;
                        break;
                    case PriceCode.Premium:
                        thisAmount += rental._daysRented * pricePerDay * 1.5;
                        break;
                    case PriceCode.Mini:
                        thisAmount += pricePerDay * 3 * 0.75; // here is the bug
                        if (rental._daysRented > 3)
                            thisAmount += (rental._daysRented - 3) * pricePerDay * 0.5;
                        break;
                }

                if (rental.Customer._frequentRenterPoints >= 5)
                {
                    thisAmount = thisAmount * 0.95;
                }

                frequentRenterPoints = 1;
                if (rental.Car._priceCode == PriceCode.Premium
                    && rental._daysRented > 1)
                    frequentRenterPoints++;

                rental.Customer._frequentRenterPoints += frequentRenterPoints;

                r += rental.Customer._customerName + "\t" + rental.Car._model + "\t" + rental._daysRented + "d \t" + thisAmount + " EUR\n";
                totalAmount += thisAmount;
            }
            r += "------------------------------\n";
            r += "Total revenue " + totalAmount + " EUR\n";

            return r;
        }
    }
}