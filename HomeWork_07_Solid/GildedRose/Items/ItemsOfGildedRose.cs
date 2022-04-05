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
            if(Quality == 50)
            {
                return;
            }

            if (SellIn > 0)
            {
                Quality++;
                return;
            }

            if (SellIn <= 0)
            {
                Quality += 2;
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
            if (SellIn <= 0)
            {
                Quality = 0;
                return;
            }

            if (CheckIfQualityIs50()) { return; }

            ChangeQualityWhenSellInIsGreaterOrEqualThan0();
        }

        private void ChangeQualityWhenSellInIsGreaterOrEqualThan0()
        {
            Quality++;

            if (CheckIfQualityIs50()) { return; }

            if (SellIn < 11)
            {
                Quality++;
            }

            if (CheckIfQualityIs50()) { return; }

            if (SellIn < 6)
            {
                Quality++;
            }
        }

        private bool CheckIfQualityIs50()
        {
            if (Quality == 50)
            {
                return true;
            }
            return false;
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
            if(Quality == 0)
            {
                return;
            }

            ChangeQualityWhenSellInIsGreaterOrEqualThan0();
            ChangeQualityWhenSellInIsLessThan0();
        }
        private void ChangeQualityWhenSellInIsGreaterOrEqualThan0()
        {
            if(SellIn > 0)
            {
                if(Quality == 1)
                {
                    Quality = 0;
                    return;
                }

                if(Quality > 1)
                {
                    Quality -= 2;
                }
            }
        }
        private void ChangeQualityWhenSellInIsLessThan0()
        {
            if(SellIn <= 0)
            {
                if(Quality < 4)
                {
                    Quality = 0;
                    return;
                }

                if(Quality > 3)
                {
                    Quality -= 4;
                }
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
