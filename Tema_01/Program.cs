using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_01
{
    class Program
    {
        static void Main(string[] args)
        {

            Set<string> phones = new Set<string>();
            Set<int> releaseYear = new Set<int>();
            Set<string> shippingFee = new Set<string>();
            Set<double> price = new Set<double>();


            phones.Insert("xiaomi");
            phones.Insert("Iphone 13 Pro");
            phones.Insert("Iphone 13 mini");
            phones.Insert("Iphone 13");
            phones.Insert("Samsung S22 Ultra");
            phones.Insert("Samsung S21 FE");
            phones.Insert("Samsung S22 Plus");
            phones.Insert("Samsung S20");


            releaseYear.Insert(2022);
            releaseYear.Insert(2010);
            releaseYear.Insert(2007);
            releaseYear.Insert(2007);
            releaseYear.Insert(2008);

            shippingFee.Insert("25 $");
            shippingFee.Insert("10 $");
            shippingFee.Insert("100 $");
            shippingFee.Insert("25 $");

            price.Insert(1250.99);
            price.Insert(943.89);
            price.Insert(2478.99);
            price.Insert(500);


            Set<string> filtredPhones = phones.filter(phones);

            Set<string> mergePhonesAndShipping = shippingFee.Merge(phones);

            phones.Remove("xiaomi");

            Console.WriteLine($"The Set of 'phones' {phones.DisplayList()}");
            Console.WriteLine($"The Set of 'releaseYear' {releaseYear.DisplayList()}");
            Console.WriteLine($"The Set of 'shippingFee' {shippingFee.DisplayList()}");
            Console.WriteLine($"The Set of 'mergePhonesAndShipping' {mergePhonesAndShipping.DisplayList()}");
            Console.WriteLine($"The Set of 'filtredPhones' {filtredPhones.DisplayList()}");
            Console.WriteLine($"The Set of 'price' {price.DisplayList()}");


            Console.WriteLine(phones.Contains("ihone"));

            Console.ReadKey();
        }
    }
}
