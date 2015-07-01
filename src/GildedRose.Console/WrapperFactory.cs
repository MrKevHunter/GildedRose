namespace GildedRose.Console
{
    public class WrapperFactory
    {
        public static ItemWrapper Create(Item item)
        {
            var itemWrapper = new ItemWrapper(item);
            if (item.Name==Program.BackstagePassesToATafkal80EtcConcert)
            {
                return new ConcertTicket();
            }
            return itemWrapper;
        }
    }

    public class ConcertTicket : ItemWrapper
    {

        public override void AdjustQuality()
        {
            base.AdjustQuality();
        }

        public ConcertTicket(Item item)
            : base(item)
        {
        }
    }
}