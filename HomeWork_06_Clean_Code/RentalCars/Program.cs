using System;

namespace RentalCars
{
    class Program
    {
        static void Main(string[] args)
        {
            Store iasiRentalsStore = new Store("Iasi Rentals");

            iasiRentalsStore.AddCustomer(new Customer("Gigi Becali", "2960703337627"));
            iasiRentalsStore.AddCar(new Car(PriceCode.Premium, "Mercedes E320", "MercedesZP4VM0688"));

            iasiRentalsStore.AddRental(
                new Rental(
                    iasiRentalsStore.IdentifyCustomerByCNP("2960703337627"),
                    iasiRentalsStore.IdentifyCarByChassisSeries("MercedesZP4VM0688"), 
                    2
                    )
                );


            var ionPopescu = new Customer("Ion Popescu", "5010630433634");
            var mihaiChirica = new Customer("Mihai Chirica", "6010527528376");
            var gigiBecali = new Customer("Gigi Becali", "2960703337627");
            


            var fordFocus = new Car(PriceCode.Regular, "Ford Focus", "FordGCF2YHE3V9971");
            var renaultClio = new Car(PriceCode.Regular, "Renault Clio", "RenaultZV5KRF7469");
            var bmw330i = new Car(PriceCode.Premium, "BMW 330i", "BmwFEPZ4TB1P11176");
            var volvoXC90 = new Car(PriceCode.Premium, "Volvo XC90", "Volvo1XA9D2DF9517");
            var toyotaAygo = new Car(PriceCode.Mini, "Toyota Aygo", "ToyotaJ2E5DA76822");
            var hyundaiI10 = new Car(PriceCode.Mini, "Hyundai i10", "Hyundai87L1XT1368");
            var mercedesE320 = new Car(PriceCode.Premium, "Mercedes E320", "MercedesZP4VM0688");


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
