using GildedRoseKata.Items;
using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<ItemModel> Items = new List<ItemModel>();

        public void AddItem(ItemModel item)
        {
            Items.Add(item);
        }

        public void DisplayStatisticsOfItemsPerDays(int days)
        {
            for (var i = 1; i <= days; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine(String.Format("{0,-42} | {1,8} | {2,8}", "Name", "SellIn", "Quality"));
                Console.WriteLine("-------------------------------------------------------------------");
                for (var j = 0; j < Items.Count; j++)
                {
                    Console.WriteLine(String.Format("{0,-42} | {1,8} | {2,8}", $"{Items[j].Name}", $"{Items[j].SellIn}", $"{Items[j].Quality}"));
                }
                DecreasSellInAndUpdateQuality();
                Console.WriteLine("");
            }
        }

        public void DecreasSellInAndUpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Items[i].DecreasSellIn();
                Items[i].UpdateQuality();
            }
        }
    }
}
