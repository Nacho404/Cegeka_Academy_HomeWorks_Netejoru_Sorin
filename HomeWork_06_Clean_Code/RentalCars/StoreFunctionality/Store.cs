using RentalCars.StoreFunctionality;
using System;
using System.Collections.Generic;

namespace RentalCars
{
    public class Store
    {
        private readonly List<Rental> Rentals = new List<Rental>();
        public List<Customer> Customers = new List<Customer>();
        public List<Car> Cars = new List<Car>();
        public List<PriceModel> Prices = new List<PriceModel>();

        private string _storeName;

        public Store(string storeName)
        {
            _storeName = storeName;
        }

        public void AddPriceModel(string priceCode, double pricePerDay)
        {
            Prices.Add(new PriceModel(priceCode, pricePerDay));
        }

        public void AddCar(string priceCode, string model, string chassisSeries)
        {
            PriceModel priceModel = Identification.IdentifyPriceModel(priceCode, Prices);// modificat
            Cars.Add(new Car(priceModel, model, chassisSeries));
        }

        public void AddCustomer(string customerName, string cnp)
        {
            Customers.Add(new Customer(customerName, cnp));
        }

        public void AddRental(string cnp, string chassisSeries, int daysRented)
        {
            Customer customer = Identification.IdentifyCustomerByCNP(cnp, Customers);// modificat
            Car car = Identification.IdentifyCarByChassisSeries(chassisSeries, Cars);// modificat

            if (customer.frequentRenterPoints >= 3
                && car.PriceModel._priceCode == "Luxury")
            {
                Rentals.Add(new Rental(customer, car, daysRented));
                return;
            }

            if (car.PriceModel._priceCode == "Luxury"
                && customer.frequentRenterPoints < 3)
            {
                throw new InvalidOperationException($"The customer {customer._name} " +
                    $"have no enough points for rent a luxury car. " +
                    $"Current points are {customer.frequentRenterPoints}. " +
                    $"For rent a luxury car he need atleast 3 points");
            }

            Rentals.Add(new Rental(customer, car, daysRented));
        }



        public void DisplayRecord()
        {
            double totalAmount = 0;

            var record = $"Rental Record for {_storeName} \n";
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

        public void DisplayCarPreferences()
        {
            var preferences = $"Car preferences for {_storeName} Store \n";
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
