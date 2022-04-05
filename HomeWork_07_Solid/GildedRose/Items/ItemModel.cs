namespace GildedRoseKata.Items
{
    public abstract class ItemModel
    {
        public string Name;
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public void DecreasSellIn()
        {
            if (Name != "Sulfuras, Hand of Ragnaros")
            {
                SellIn--;
            }
        }
        public virtual void UpdateQuality()
        {
            if(Quality == 0)
            {
                return;
            }

            ChangeQualityWhenSellInIsLessOrEqualThan0();
            ChangeQualityWhenSellInIsGreaterThan0();
        }
        private void ChangeQualityWhenSellInIsLessOrEqualThan0()
        {
            if(SellIn <= 0)
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
        private void ChangeQualityWhenSellInIsGreaterThan0()
        {
            if (Quality > 0 && SellIn > 0)
            {
                Quality--; 
            }
        }
    }
}
