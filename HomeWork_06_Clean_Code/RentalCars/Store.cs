using System;
using System.Collections.Generic;

namespace RentalCars
{
    public class Store
    {
        private readonly List<Rental> Rentals = new List<Rental>(); //lista de inchirieri
        public List<Customer> Customers = new List<Customer>();
        public List<Car> Cars = new List<Car>();

        private string _storeName;

        public Store(string storeName)
        {
            _storeName = storeName;
        }

        public void AddCar(Car car)
        {
            Cars.Add(car);
        }

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        public void AddRental(Rental rental)
        {
            Rentals.Add(rental);
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
            return null;
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
            return null;
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