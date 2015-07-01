using System;

namespace GildedRose.Console
{
    public class ItemDecorator : Item
    {
        private readonly int MaximumQuality = 50;

        public ItemDecorator(Item item)
        {
            Item = item;
        }

        public Item Item { get; }
        public string Name => Item.Name;

        public int SellIn
        {
            get { return Item.SellIn; }
            set { Item.SellIn = value; }
        }

        public int Quality
        {
            get { return Item.Quality; }
            set { Item.Quality = Math.Max(Math.Min(value, MaximumQuality), 0); }
        }

        public virtual void AdjustQuality()
        {
            if (Quality > 0)
            {
                if (Name != Program.SulfurasHandOfRagnaros)
                {
                    Quality = Quality - 1;
                }
            }
        }
    }
}