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
            ChangeQualityWhenSellInIsLessThen0();
            ChangeQualityWhenSellInIsGreaterOrEqualThen0();
        }
        private void ChangeQualityWhenSellInIsLessThen0()
        {
            if (Quality > 0 && SellIn < 0)
            {
                Quality -= 2;
            }
        }
        private void ChangeQualityWhenSellInIsGreaterOrEqualThen0()
        {
            if (Quality > 0 && SellIn >= 0)
            {
                Quality -= 1;
            }
        }

    }
}
