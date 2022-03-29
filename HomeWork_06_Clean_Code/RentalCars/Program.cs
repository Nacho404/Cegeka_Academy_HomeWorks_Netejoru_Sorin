using System;

namespace RentalCars
{
    class Program
    {
        static void Main(string[] args)
        {
            Store iasiRentalsStore = new Store("Iasi Rentals");

            var ionPopescu = new Customer("Ion Popescu");
            var mihaiChirica = new Customer("Mihai Chirica");
            var gigiBecali = new Customer("Gigi Becali");

            var fordFocus = new Car(PriceCode.Regular, "Ford Focus");
            var renaultClio = new Car(PriceCode.Regular, "Renault Clio");
            var bmw330i = new Car(PriceCode.Premium, "BMW 330i");
            var volvoXC90 = new Car(PriceCode.Premium, "Volvo XC90");
            var toyotaAygo = new Car(PriceCode.Mini, "Toyota Aygo");
            var hyundaiI10 = new Car(PriceCode.Mini, "Hyundai i10");
            var mercedesE320 = new Car(PriceCode.Premium, "Mercedes E320");


            iasiRentalsStore.AddRental(new Rental(ionPopescu, fordFocus, 2));
            iasiRentalsStore.AddRental(new Rental(gigiBecali, renaultClio, 3));
            iasiRentalsStore.AddRental(new Rental(ionPopescu, bmw330i, 1));
            iasiRentalsStore.AddRental(new Rental(gigiBecali, volvoXC90, 3));
            iasiRentalsStore.AddRental(new Rental(mihaiChirica, toyotaAygo, 2));
            iasiRentalsStore.AddRental(new Rental(ionPopescu, hyundaiI10, 4));
            iasiRentalsStore.AddRental(new Rental(gigiBecali, volvoXC90, 2));
            iasiRentalsStore.AddRental(new Rental(gigiBecali, mercedesE320, 1));

            Console.WriteLine(iasiRentalsStore.Statement());
            Console.ReadKey();

        }
    }
}
