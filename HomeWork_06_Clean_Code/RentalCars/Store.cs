using System;
using System.Collections.Generic;

namespace RentalCars
{
    public class Store
    {
        private readonly List<Rental> Rentals = new List<Rental>();
        public List<Customer> Customers = new List<Customer>();
        public List<Car> Cars = new List<Car>();

        private string _storeName;

        public Store(string storeName)
        {
            _storeName = storeName;
        }
         
        public void AddCar(PriceCode priceCode, string model, string chassisSeries)
        {
            Cars.Add(new Car(priceCode, model, chassisSeries));
        }

        public void AddCustomer(string customerName, string cnp)
        {
            Customers.Add(new Customer(customerName, cnp));
        }

        public void AddRental(string cnp, string chassisSeries, int daysRented)
        {
            Customer customer = IdentifyCustomerByCNP(cnp);
            Car car = IdentifyCarByChassisSeries(chassisSeries);

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

        public string Statement()
        {
            double totalAmount = 0;

            var r = "Rental Record for " + _storeName + "\n";
            r += "------------------------------\n";

            foreach (var rental in Rentals)
            {
                r += rental.Customer._name + "\t" + rental.Car._model + "\t" + rental._daysRented + "d \t" + rental.rentalAmount + " EUR\n";
                totalAmount += rental.rentalAmount;
            }
            r += "------------------------------\n";
            r += "Total revenue " + totalAmount + " EUR\n";

            return r;
        }
    }
}
