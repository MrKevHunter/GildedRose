namespace GildedRose.Console
{
    public interface IQualityUpdatingStrategy
    {
        ItemWrapper UpdateQuality(ItemWrapper item);
    }
}