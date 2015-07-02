using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;

        private static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program
            {
<<<<<<< HEAD
                var item = WrapperFactory.Create(i);

                item.AdjustQuality();

                DecreaseSellInValue(item);

                ProcessOutOfDateItems(item, i);
            }
        }

        private static void DecreaseSellInValue(ItemDecorator item)
        {
            if (item.Name != SulfurasHandOfRagnaros)
            {
                item.SellIn = item.SellIn - 1;
            }
        }

        private static void ProcessOutOfDateItems(ItemDecorator item, Item i)
        {
            if (item.SellIn < 0)
            {
                if (item.Name != AgedBrie)
                {
                    if (item.Name != BackstagePassesToATafkal80EtcConcert)
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != SulfurasHandOfRagnaros)
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    item.Quality = item.Quality + 1;
                }
                i.Quality = item.Item.Quality;
=======
                Items =
                    new List<Item>
                    {
                        new Item {Name = ProductNameConstants.DexterityVest, SellIn = 10, Quality = 20},
                        new Item {Name = ProductNameConstants.AgedBrie, SellIn = 2, Quality = 0},
                        new Item {Name = ProductNameConstants.ElixirOfTheMongoose, SellIn = 5, Quality = 7},
                        new Item {Name = ProductNameConstants.SulfurasHandOfRagnaros, SellIn = 0, Quality = 80},
                        new Item
                        {
                            Name = ProductNameConstants.BackstagePassesToATafkal80EtcConcert,
                            SellIn = 15,
                            Quality = 20
                        },
                        new Item {Name = ProductNameConstants.ConjuredManaCake, SellIn = 3, Quality = 6}
                    }
            };

            app.UpdateQuality();

            System.Console.ReadKey();
        }

        public void UpdateQuality()
        {
            foreach (var i in Items)
            {
                var item = WrapperFactory.Create(i);
                var qualityUpdatingStrategy = new QualityUpdatingStrategyFactory().Create(item);
                item = qualityUpdatingStrategy.UpdateQuality(item);
                i.Quality = item.Quality;
>>>>>>> strategyimp
                i.SellIn = item.SellIn;
            }
        }
    }
}