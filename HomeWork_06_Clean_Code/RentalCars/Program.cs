using System;

namespace RentalCars
{
    class Program
    {
        static void Main(string[] args)
        {
            Store iasiRentalsStore = new Store("Iasi Rentals");

            iasiRentalsStore.AddCustomer("Gigi Becali", "CNP2960703337627");
            iasiRentalsStore.AddCustomer("Mihai Chirica", "CNP6010527528376");
            iasiRentalsStore.AddCustomer("Ion Popescu", "CNP5010630433634");

            iasiRentalsStore.AddPriceModel("Mini", 15);
            iasiRentalsStore.AddPriceModel("Regular", 20);
            iasiRentalsStore.AddPriceModel("Premium", 30);


            iasiRentalsStore.AddCar("Regular", "Ford Focus", "FordGCF2YHE3V9971");
            iasiRentalsStore.AddCar("Regular", "Renault Clio", "RenaultZV5KRF7469");
            iasiRentalsStore.AddCar("Premium", "BMW 330i", "BmwFEPZ4TB1P11176");
            iasiRentalsStore.AddCar("Premium", "Volvo XC90", "Volvo1XA9D2DF9517");
            iasiRentalsStore.AddCar("Mini", "Toyota Aygo", "ToyotaJ2E5DA76822");
            iasiRentalsStore.AddCar("Mini", "Hyundai i10", "Hyundai87L1XT1368");
            iasiRentalsStore.AddCar("Premium", "Mercedes E320", "MercedesZP4VM0688");

            iasiRentalsStore.AddRental("CNP5010630433634", "FordGCF2YHE3V9971", 2);
            iasiRentalsStore.AddRental("CNP2960703337627", "RenaultZV5KRF7469", 3);
            iasiRentalsStore.AddRental("CNP5010630433634", "BmwFEPZ4TB1P11176", 1);
            iasiRentalsStore.AddRental("CNP2960703337627", "Volvo1XA9D2DF9517", 3);
            iasiRentalsStore.AddRental("CNP6010527528376", "ToyotaJ2E5DA76822", 2);
            iasiRentalsStore.AddRental("CNP5010630433634", "Hyundai87L1XT1368", 4);
            iasiRentalsStore.AddRental("CNP2960703337627", "Volvo1XA9D2DF9517", 2);
            iasiRentalsStore.AddRental("CNP2960703337627", "MercedesZP4VM0688", 1);

            Store bucharestRentalsStore = new Store("Bucharest Rentals");

            bucharestRentalsStore.AddCustomer("Gigi Becali", "CNP2960703337627");

            bucharestRentalsStore.AddPriceModel("Luxury", 70);

            bucharestRentalsStore.AddCar("Luxury", "Ford Focus", "FordGCF2YHE3V9971");

            bucharestRentalsStore.AddRental("CNP2960703337627", "FordGCF2YHE3V9971", 10);


            Console.WriteLine(iasiRentalsStore.Statement());
            Console.WriteLine(bucharestRentalsStore.Statement());
            Console.ReadKey();
        }
    }
}
