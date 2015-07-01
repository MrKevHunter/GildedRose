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
                ItemWrapper item = WrapperFactory.Create(i);
                if (item.Name == AgedBrie || item.Name == BackstagePassesToATafkal80EtcConcert)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == BackstagePassesToATafkal80EtcConcert)
                    {
                        if (item.SellIn < 11)
                        {
                            item.Quality = item.Quality + 1;
                        }

                        if (item.SellIn < 6)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
                else
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != SulfurasHandOfRagnaros)
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                }

                if (item.Name != SulfurasHandOfRagnaros)
                {
                    item.SellIn = item.SellIn - 1;
                }

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

    public class ItemWrapper
    {
        private int MaximumQuality = 50;

        public Item Item { get; }

        public string Name
        {
            get
            {
                return this.Item.Name;
            }
        }

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
                this.Item.Quality = Math.Min(value,MaximumQuality);
            }
        }

        public ItemWrapper(Item item)
        {
            this.Item = item;
        }
    }

    public class WrapperFactory
    {
        public static ItemWrapper Create(Item item)
        {
            return new ItemWrapper(item);
        }
    }

    public class Item
    {
        public string Name { get; set; }

        //Number of time periods to sell in
        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}