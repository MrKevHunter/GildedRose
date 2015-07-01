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
            if (item.Name==Program.AgedBrie)
            {
                return  new CheeseThatAgesWell(itemWrapper);
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

        public ConcertTicket(Item item)
            : base(item)
        {
        }
    }

    public class CheeseThatAgesWell : ItemDecorator
    {
        public override void AdjustQuality()
        {
            this.Quality = this.Quality + 1;
            base.AdjustQuality();
        }

        public CheeseThatAgesWell(Item item)
            : base(item)
        {
        }
    }
}