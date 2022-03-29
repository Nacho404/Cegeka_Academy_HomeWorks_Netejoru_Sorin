using System;
using System.Collections.Generic;

namespace RentalCars
{
    public class RentalStore
    {
        private readonly List<Rental> _rentals = new List<Rental>(); //lista de inchirieri

        private string _storeName;

        public RentalStore(string storeName)
        {
            _storeName = storeName;
        }


        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
            rental.Customer.AddRental(rental);
        }

        public string Statement()
        {
            double pricePerDay = 20;
            double totalAmount = 0;
            var frequentRenterPoints = 0;

            var r = "Rental Record for " + _storeName + "\n";
            r += "------------------------------\n";

            foreach (var each in _rentals)
            {
                double thisAmount = 0;

                // determines the amount for each line
                switch (each.Car._priceCode)
                {
                    case PriceCode.Regular:
                        thisAmount += pricePerDay * 2;
                        if (each._daysRented > 2)
                            thisAmount += (each._daysRented - 2) * pricePerDay * 0.75;
                        break;
                    case PriceCode.Premium:
                        thisAmount += each._daysRented * pricePerDay * 1.5;
                        break;
                    case PriceCode.Mini:
                        thisAmount += pricePerDay * 3 * 0.75;
                        if (each._daysRented > 3)
                            thisAmount += (each._daysRented - 3) * pricePerDay * 0.5;
                        break;
                }

                if (each.Customer.FrequentRenterPoints >= 5)
                {
                    thisAmount = thisAmount * 0.95;
                }

                frequentRenterPoints = 1;
                if (each.Car._priceCode == PriceCode.Premium
                    && each._daysRented > 1)
                    frequentRenterPoints++;

                each.Customer.FrequentRenterPoints += frequentRenterPoints;

                r += each.Customer._customerName + "\t" + each.Car._model + "\t" + each._daysRented + "d \t" + thisAmount + " EUR\n";
                totalAmount += thisAmount;
            }
            r += "------------------------------\n";
            r += "Total revenue " + totalAmount + " EUR\n";

            return r;
        }
    }
}