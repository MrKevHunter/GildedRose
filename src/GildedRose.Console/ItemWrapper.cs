namespace GildedRose.Console
{
    using System;

    public class ItemDecorator
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
                this.Item.Quality = Math.Max(Math.Min(value,this.MaximumQuality),0);
            }
        }

        public virtual void AdjustQuality()
        {
            if (this.Name == Program.AgedBrie || this.Name == Program.BackstagePassesToATafkal80EtcConcert)
            {
                this.Quality = this.Quality + 1;

                if (this.Name == Program.BackstagePassesToATafkal80EtcConcert)
                {
                    if (this.SellIn < 11)
                    {
                        this.Quality = this.Quality + 1;
                    }

                    if (this.SellIn < 6)
                    {
                        this.Quality = this.Quality + 1;
                    }
                }
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

        public ItemWrapper(Item item)
        {
            this.Item = item;
        }
    }
}