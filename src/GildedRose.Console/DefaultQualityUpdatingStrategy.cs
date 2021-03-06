using GildedRose.Console;

public class DefaultQualityUpdatingStrategy : IQualityUpdatingStrategy
{
    public ItemWrapper UpdateQuality(ItemWrapper item)
    {
        if (item.Quality > 0)
        {
            item.Quality = item.Quality - 1;
        }

        item.SellIn = item.SellIn - 1;

        if (item.SellIn < 0)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
        }
        return item;
    }
}