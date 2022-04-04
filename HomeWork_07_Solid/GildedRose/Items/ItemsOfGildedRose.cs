using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Items
{
    public class AgedBrie : ItemModel
    {
        public AgedBrie()
        {
            Name = "Aged Brie";
        }
        public override void UpdateQuality()
        {
            if (Quality < 50)
            {
                Quality++;
            }
        }
    }
    public class Sulfuras : ItemModel
    {
        public Sulfuras()
        {
            Name = "Sulfuras, Hand of Ragnaros";
        }
        public override void UpdateQuality()
        {
            return;// this item is Legendary -> never has to be sold or decreases in Quality
        }
    }
    public class BackstagePasses : ItemModel
    {
        public BackstagePasses()
        {
            Name = "Backstage passes to a TAFKAL80ETC concert";
        }
        public override void UpdateQuality()
        {
            ChangeQualityWhenSellInIsLessThen0();
            ChangeQualityWhenSellInIsGreaterOrEqualThen0();
        }
        private void ChangeQualityWhenSellInIsLessThen0()
        {
            if (SellIn < 0)
            {
                Quality = 0;
            }
        }

        private void ChangeQualityWhenSellInIsGreaterOrEqualThen0()
        {
            if (SellIn >= 0)
            {
                if (Quality < 50)
                {
                    Quality++;
                }

                if (Quality < 50 && SellIn <= 10)
                {
                    Quality++;
                }

                if (Quality < 50 && SellIn <= 5)
                {
                    Quality++;
                }
            }
        }
    }
    public class ConjuredManaCake : ItemModel
    {
        public ConjuredManaCake()
        {
            Name = "Conjured Mana Cake";
        }
        public override void UpdateQuality()
        {
            ChangeQualityWhenSellInIsGreaterOrEqualThen0();
            ChangeQualityWhenSellInIsLessThen0();
        }
        private void ChangeQualityWhenSellInIsGreaterOrEqualThen0()
        {
            if (Quality > 0 && SellIn >= 0)
            {
                Quality -= 2;
            }
        }
        private void ChangeQualityWhenSellInIsLessThen0()
        {
            if (Quality > 0 && SellIn < 0)
            {
                Quality -= 4;
            }
        }
    }
    public class DexterityVest : ItemModel
    {
        public DexterityVest()
        {
            Name = "+5 Dexterity Vest";
        }
        public override void UpdateQuality()
        {
            base.UpdateQuality();
        }
    }
    public class ElixirOfTheMongoose : ItemModel
    {
        public ElixirOfTheMongoose()
        {
            Name = "Elixir of the Mongoose";
        }
        public override void UpdateQuality()
        {
            base.UpdateQuality();
        }
    }
}
