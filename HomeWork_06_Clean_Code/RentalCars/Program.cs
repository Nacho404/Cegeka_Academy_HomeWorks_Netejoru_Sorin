using System;

namespace RentalCars
{
    class Program
    {
        static void Main(string[] args)
        {
            RentalStore iasiRentalsStore = new RentalStore("Iasi Rentals");

            var ionPopescu = new Customer("Ion Popescu");
            var mihaiChirica = new Customer("Mihai Chirica");
            var gigiBecali = new Customer("Gigi Becali");

            iasiRentalsStore.AddRental(new Rental(ionPopescu, new Car(PriceCode.Regular, "Ford Focus"), 2));
            iasiRentalsStore.AddRental(new Rental(gigiBecali, new Car(PriceCode.Regular, "Renault Clio"), 3));
            iasiRentalsStore.AddRental(new Rental(ionPopescu, new Car(PriceCode.Premium, "BMW 330i"), 1));
            iasiRentalsStore.AddRental(new Rental(gigiBecali, new Car(PriceCode.Premium, "Volvo XC90"), 3));
            iasiRentalsStore.AddRental(new Rental(mihaiChirica, new Car(PriceCode.Mini, "Toyota Aygo"), 2));
            iasiRentalsStore.AddRental(new Rental(ionPopescu, new Car(PriceCode.Mini, "Hyundai i10"), 4));
            iasiRentalsStore.AddRental(new Rental(gigiBecali, new Car(PriceCode.Premium, "Volvo XC90"), 2));
            iasiRentalsStore.AddRental(new Rental(gigiBecali, new Car(PriceCode.Premium, "Mercedes E320"), 1));

            Console.WriteLine(iasiRentalsStore.Statement());
            Console.ReadKey();

        }
    }
}
