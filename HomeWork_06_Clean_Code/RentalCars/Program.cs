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

            bucharestRentalsStore.AddCustomer("Sorin Netejoru", "Sorin6001004299856");
            bucharestRentalsStore.AddCustomer("Enache Catalin", "Enache1880508511799");
            bucharestRentalsStore.AddCustomer("Panait Valentin", "Panait2990302026576");

            bucharestRentalsStore.AddPriceModel("Mini", 25);
            bucharestRentalsStore.AddPriceModel("Regular", 30);
            bucharestRentalsStore.AddPriceModel("Premium", 40);
            bucharestRentalsStore.AddPriceModel("Luxury", 70);

            bucharestRentalsStore.AddCar("Luxury", "Range Rover Evoque", "RangeRUEL9XZC4272");
            bucharestRentalsStore.AddCar("Regular", "Opel Astra-H", "Opel2ZKZ44VU61304");
            bucharestRentalsStore.AddCar("Regular", "WV Arteon", "WvA62DM4M7EZM1754");
            bucharestRentalsStore.AddCar("Luxury", "Lamborghini", "LamboM4CPGNN03836");
            bucharestRentalsStore.AddCar("Mini", "Peugout 107", "PeugoutST5V0N4537");
            bucharestRentalsStore.AddCar("Mini", "Mini Cooper", "MiniCXB5M7FUT4200");
            bucharestRentalsStore.AddCar("Premium", "Mitsubishi Lancer", "MitsubishiL6T6223");
            bucharestRentalsStore.AddCar("Premium", "Mitsubishi", "MitsubishiEL27525");


            bucharestRentalsStore.AddRental("Panait2990302026576", "MitsubishiEL27525", 4);
            bucharestRentalsStore.AddRental("Panait2990302026576", "MiniCXB5M7FUT4200", 2);
            bucharestRentalsStore.AddRental("Panait2990302026576", "WvA62DM4M7EZM1754", 10);
            bucharestRentalsStore.AddRental("Sorin6001004299856", "WvA62DM4M7EZM1754", 2);
            bucharestRentalsStore.AddRental("Enache1880508511799", "MitsubishiEL27525", 1);
            bucharestRentalsStore.AddRental("Panait2990302026576", "LamboM4CPGNN03836", 3);
            bucharestRentalsStore.AddRental("Sorin6001004299856", "Opel2ZKZ44VU61304", 5);
            bucharestRentalsStore.AddRental("Panait2990302026576", "MiniCXB5M7FUT4200", 3);
            bucharestRentalsStore.AddRental("Sorin6001004299856", "PeugoutST5V0N4537", 1);
            bucharestRentalsStore.AddRental("Sorin6001004299856", "LamboM4CPGNN03836", 2);
            bucharestRentalsStore.AddRental("Enache1880508511799", "LamboM4CPGNN03836", 3);


            iasiRentalsStore.DisplayRecord();
            iasiRentalsStore.DisplayCarPreferences();
            bucharestRentalsStore.DisplayRecord();
            bucharestRentalsStore.DisplayCarPreferences();
            Console.ReadKey();
        }
    }
}
