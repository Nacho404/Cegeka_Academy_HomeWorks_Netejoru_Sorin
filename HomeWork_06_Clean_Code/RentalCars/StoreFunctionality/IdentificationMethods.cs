using RentalCars.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars.StoreFunctionality
{
    public class IdentificationMethods
    {
        public static Customer IdentifyCustomerByCNP(string cnp, List<Customer> Customers)
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

        public static Car IdentifyCarByChassisSeries(string chassisSeries, List<Car> Cars)
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

        public static PriceModel IdentifyPriceModel(string priceCode, List<PriceModel> Prices)
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
    }
}
