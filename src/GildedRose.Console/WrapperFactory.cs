namespace GildedRose.Console
{
    public class WrapperFactory
    {
        public static ItemDecorator Create(Item item)
        {
            var itemWrapper = new ItemDecorator(item);
            if (item.Name==Program.BackstagePassesToATafkal80EtcConcert)
            {
                return new ConcertTicket(itemWrapper);
            }
            return itemWrapper;
        }
    }

    public class ConcertTicket : ItemDecorator
    {
        public override void AdjustQuality()
        {

            if (this.SellIn < 11)
            {
                this.Quality = this.Quality + 1;
            }

            if (this.SellIn < 6)
            {
                this.Quality = this.Quality + 1;
            }
            base.AdjustQuality();
        }

        public ConcertTicket(ItemDecorator item)
            : base(item)
        {
        }
    }

    public class CheeseThatAgesWell : ItemDecorator
    {
        public override void AdjustQuality()
        {

            if (this.SellIn < 11)
            {
                this.Quality = this.Quality + 1;
            }

            if (this.SellIn < 6)
            {
                this.Quality = this.Quality + 1;
            }
            base.AdjustQuality();
        }

        public ConcertTicket(ItemDecorator item)
            : base(item)
        {
        }
    }
}