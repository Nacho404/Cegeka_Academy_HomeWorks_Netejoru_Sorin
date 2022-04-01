using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars.StoreFunctionality
{
    public class DisplayMethods
    {
        public static void DisplayRecord(string storeName, List<Rental> Rentals)
        {
            double totalAmount = 0;

            var record = $"Rental Record for {storeName} \n";
            record += "------------------------------\n";

            foreach (var rental in Rentals)
            {
                record += $"{rental.Customer._name}\t{rental.Car._model}\t{rental._daysRented}d \t{rental.rentalAmount} EUR\n";
                totalAmount += rental.rentalAmount;
            }
            record += "------------------------------\n";
            record += $"Total revenue {totalAmount} EUR\n";

            Console.WriteLine(record);
        }

        public static void DisplayCarPreferences(string storeName, List<PriceModel> Prices)
        {
            var preferences = $"Car preferences for {storeName} Store \n";
            preferences += "/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/\n";

            foreach (var price in Prices)
            {
                preferences += $"{price._priceCode}\t{price.totalPriceOfPriceCodePreference} EUR\n";
            }
            preferences += "/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/\n";

            Console.WriteLine(preferences);
        }
    }
}
