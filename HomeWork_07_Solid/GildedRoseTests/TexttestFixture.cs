
using GildedRoseKata;
using GildedRoseKata.Items;
using System;
using System.Collections.Generic;

namespace GildedRoseTests
{
    public static class TexttestFixture
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var app = new GildedRose();

            app.AddItem(new DexterityVest {SellIn = 10, Quality = 20 });
            app.AddItem(new AgedBrie {SellIn = 2, Quality = 0 });
            app.AddItem(new ElixirOfTheMongoose { SellIn = 5, Quality = 7 });

            app.AddItem(new Sulfuras {SellIn = 0, Quality = 80 });
            app.AddItem(new Sulfuras {SellIn = -1, Quality = 80 });

            app.AddItem(new BackstagePasses {SellIn = 15, Quality = 20 });
            app.AddItem(new BackstagePasses {SellIn = 10, Quality = 49 });
            app.AddItem(new BackstagePasses {SellIn = 2, Quality = 49 });

            app.AddItem(new ConjuredManaCake {SellIn = 3, Quality = 30 });

            app.DisplayStatisticsOfItemsPerDays(7);
        }
    }
}
