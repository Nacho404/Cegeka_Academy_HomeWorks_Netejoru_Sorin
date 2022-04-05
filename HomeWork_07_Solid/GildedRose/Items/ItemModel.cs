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
            ChangeQualityWhenSellInIsLessThan0();
            ChangeQualityWhenSellInIsGreaterOrEqualThan0();
        }
        private void ChangeQualityWhenSellInIsLessThan0()
        {
            if (Quality > 0 && SellIn < 0)
            {
                Quality -= 2;
            }
        }
        private void ChangeQualityWhenSellInIsGreaterOrEqualThan0()
        {
            if (Quality > 0 && SellIn >= 0)
            {
                Quality -= 1; 
            }
        }
    }
}
