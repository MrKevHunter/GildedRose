namespace GildedRose.Console
{
    using System;

    public class ItemDecorator
    {
        private int MaximumQuality = 50;

        public ItemDecorator Item { get; }

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
                this.Item.Quality = Math.Max(Math.Min(value,this.MaximumQuality),0);
            }
        }

        public virtual void AdjustQuality()
        {
            if (this.Name == Program.AgedBrie || this.Name == Program.BackstagePassesToATafkal80EtcConcert)
            {
                this.Quality = this.Quality + 1;
            }
            else
            {
                if (this.Quality > 0)
                {
                    if (this.Name != Program.SulfurasHandOfRagnaros)
                    {
                        this.Quality = this.Quality - 1;
                    }
                }
            }
        }

        public ItemDecorator(Item item)
        {
            this.Item = new ItemDecorator(item);
        }

        public ItemDecorator(ItemDecorator item)
        {
            this.Item = item;
        }
    }
}