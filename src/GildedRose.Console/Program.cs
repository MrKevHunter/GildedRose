namespace GildedRose.Console
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public const string AgedBrie = "Aged Brie";

        public const string DexterityVest = "+5 Dexterity Vest";

        public const string ElixirOfTheMongoose = "Elixir of the Mongoose";

        public const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";

        public const string BackstagePassesToATafkal80EtcConcert = "Backstage passes to a TAFKAL80ETC concert";

        public const string ConjuredManaCake = "Conjured Mana Cake";

        public IList<Item> Items;

        private static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var app = new Program
                          {
                              Items =
                                  new List<Item>
                                      {
                                          new Item { Name = DexterityVest, SellIn = 10, Quality = 20 },
                                          new Item { Name = AgedBrie, SellIn = 2, Quality = 0 },
                                          new Item { Name = ElixirOfTheMongoose, SellIn = 5, Quality = 7 },
                                          new Item { Name = SulfurasHandOfRagnaros, SellIn = 0, Quality = 80 },
                                          new Item { Name = BackstagePassesToATafkal80EtcConcert, SellIn = 15, Quality = 20 },
                                          new Item { Name = ConjuredManaCake, SellIn = 3, Quality = 6 }
                                      }
                          };

            app.UpdateQuality();

            Console.ReadKey();
        }

       

        public void UpdateQuality()
        {
            foreach (var i in this.Items)
            {
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
                i.SellIn = item.SellIn;
            }
        }
    }
}