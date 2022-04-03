namespace GildedRoseKata.Items
{
    public abstract class ItemModel
    {
        public string Name;
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public virtual void UpdateQuality()
        {
            if (Quality > 0 && SellIn >= 0)
            {
                Quality -= 1;
            }

            if (Quality > 0 && SellIn < 0)
            {
                Quality -= 2;
            }
        }

        public void DecreasSellIn()
        {
            if(Name != "Sulfuras, Hand of Ragnaros")
            {
                SellIn--;
            }
        }

    }
}
