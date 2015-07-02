namespace GildedRose.Console
{
    public class WrapperFactory
    {
        public static ItemWrapper Create(Item item)
        {
            return new ItemWrapper(item);
        }
    }
}