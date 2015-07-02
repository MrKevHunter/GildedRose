using System;

namespace GildedRose.Console
{
    public class ItemWrapper
    {
        private int MaximumQuality = 50;

        public Item Item { get; }

        public string Name => this.Item.Name;

        public int SellIn
        {
            get
            {
                return this.Item.SellIn;
            }
            set
            {
                this.Item.SellIn = value;
            }
        }

        public int Quality
        {
            get
            {
                return this.Item.Quality;
            }
            set
            {
                this.Item.Quality = Math.Min(value,MaximumQuality);
            }
        }

        public ItemWrapper(Item item)
        {
            this.Item = item;
        }
    }
}