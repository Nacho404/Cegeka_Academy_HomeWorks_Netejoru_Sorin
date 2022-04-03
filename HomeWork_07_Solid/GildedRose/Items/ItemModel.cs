namespace GildedRoseKata.Items
{
    public abstract class ItemModel
    {
        public string Name;
        public int SellIn { get; set; }
        public int Quality { get; set; }

    }
}
