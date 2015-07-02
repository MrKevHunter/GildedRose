namespace GildedRose.Console
{
    public class DefaultQualityUpdatingStrategy : IQualityUpdatingStrategy
    {
        protected virtual int QualityDecreaser => 1;

        public ItemWrapper UpdateQuality(ItemWrapper item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - QualityDecreaser;
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                    item.Quality = item.Quality - QualityDecreaser;
                }
            }
            return item;
        }
    }
}