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
        public void AddCustomer(string customerName, string cnp)
        {
            Customers.Add(new Customer(customerName, cnp));
        }

        public void AddCar(string priceCode, string model, string chassisSeries)
        {
            PriceModel priceModel = IdentificationMethods.IdentifyPriceModel(priceCode, Prices);// modificat
            Cars.Add(new Car(priceModel, model, chassisSeries));
        }

        public void AddRental(string cnp, string chassisSeries, int daysRented)
        {
            Customer customer = IdentificationMethods.IdentifyCustomerByCNP(cnp, Customers);// modificat
            Car car = IdentificationMethods.IdentifyCarByChassisSeries(chassisSeries, Cars);// modificat

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


        public void AccessDisplayRecord()
        {
            DisplayMethods.DisplayRecord(_storeName, Rentals);
        }

        public void AccessDisplayCarPreferences()
        {
            DisplayMethods.DisplayCarPreferences(_storeName, Prices);
        }

    }
}
