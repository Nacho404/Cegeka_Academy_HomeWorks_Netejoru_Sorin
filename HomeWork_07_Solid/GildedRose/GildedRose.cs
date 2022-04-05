using GildedRoseKata.Items;
using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        public IList<ItemModel> Items = new List<ItemModel>();

        public void AddItem(ItemModel item)
        {
            Items.Add(item);
        }
        public void DisplayStatisticsOfItemsPerDays(int days)
        {
            string dayStatistic= "";
            for (var i = 1; i <= days; i++)
            {
                dayStatistic += $"--------------- day {i} ---------------\n";
                dayStatistic += String.Format("{0,-45} | {1,8} | {2,8}", "Name", "SellIn", "Quality\n");
                dayStatistic += "-------------------------------------------------------------------\n";
                foreach(var item in Items)
                {
                    dayStatistic += String.Format("{0,-45} | {1,8} | {2,8}",
                        $"-> {item.Name}", $"{item.SellIn}", $"{item.Quality}\n");
                }
                dayStatistic += "\n\n";
                DecreasSellInAndUpdateQuality();
            }
            Console.WriteLine(dayStatistic);
        }
        public void DecreasSellInAndUpdateQuality()
        {
            foreach(var item in Items)
            {
                item.DecreasSellIn();
                item.UpdateQuality();
            }
        }
    }
}
