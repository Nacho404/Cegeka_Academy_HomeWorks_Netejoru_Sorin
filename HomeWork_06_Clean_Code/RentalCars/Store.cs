﻿using System;
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
            PriceModel priceModel = IdentifyPriceModel(priceCode);
            Cars.Add(new Car(priceModel, model, chassisSeries));
        }

        public void AddCustomer(string customerName, string cnp)
        {
            Customers.Add(new Customer(customerName, cnp));
        }

        public void AddRental(string cnp, string chassisSeries, int daysRented)
        {
            Customer customer = IdentifyCustomerByCNP(cnp);
            Car car = IdentifyCarByChassisSeries(chassisSeries);

            if (customer.frequentRenterPoints >= 3 
                && car.PriceModel._priceCode == "Luxury")
            {
                Rentals.Add(new Rental(customer, car, daysRented));
                return;
            }
           
            Rentals.Add(new Rental(customer, car, daysRented));
        }

        public Customer IdentifyCustomerByCNP(string cnp)
        {
            foreach (var customer in Customers)
            {
                if (customer._cnp == cnp)
                {
                    return customer;
                }
            }
            throw new InvalidOperationException("Customer not found! Try entering another CNP or add the customer if it does not exist");
        }

        public Car IdentifyCarByChassisSeries(string chassisSeries)
        {
            foreach (var car in Cars)
            {
                if (car._chassisSeries == chassisSeries)
                {
                    return car;
                }
            }
            throw new InvalidOperationException("Car not found! Try entering another Chassis Series or add the car if it does not exist");
        }

        public PriceModel IdentifyPriceModel(string priceCode)
        {
            foreach (var price in Prices)
            {
                if (price._priceCode == priceCode)
                {
                    return price;
                }
            }
            throw new InvalidOperationException("Price Code not found! Try entering another 'Price Code' or add the price model if it does not exist");
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
    }
}
