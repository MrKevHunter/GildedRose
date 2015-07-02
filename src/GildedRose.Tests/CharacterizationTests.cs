using Xunit;

namespace GildedRose.Tests
{
    using System.Collections.Generic;

    using GildedRose.Console;

    using Shouldly;

    public class CharacterizationTests
    {
        [Fact]
        public void Given_a_vest_When_processed_the_amount_should_reduce_by_one()
        {
            Program sut = new Program { Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 } } };
            sut.UpdateQuality();
            sut.Items[0].Name.ShouldBe("+5 Dexterity Vest");
            sut.Items[0].SellIn.ShouldBe(9);
            sut.Items[0].Quality.ShouldBe(19);
        }

        [Fact]
        public void Given_brie_When_processed_the_amount_should_reduce_by_one()
        {
            Program sut = new Program { Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } } };
            sut.UpdateQuality();
            sut.Items[0].Name.ShouldBe("Aged Brie");
            sut.Items[0].SellIn.ShouldBe(1);
            sut.Items[0].Quality.ShouldBe(1);
        }

        [Fact]
        public void Given_mongoose_elixir_When_processed_the_amount_should_reduce_by_one()
        {
            Program sut = new Program { Items = new List<Item> { new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 } } };
            sut.UpdateQuality();
            sut.Items[0].Name.ShouldBe("Elixir of the Mongoose");
            sut.Items[0].SellIn.ShouldBe(4);
            sut.Items[0].Quality.ShouldBe(6);
        }

        [Fact]
        public void Given_ragnoros_hand_When_processed_the_amount_should_reduce_by_one()
        {
            Program sut = new Program { Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 50 } } };
            sut.UpdateQuality();
            sut.Items[0].Name.ShouldBe("Sulfuras, Hand of Ragnaros");
            sut.Items[0].SellIn.ShouldBe(0);
            sut.Items[0].Quality.ShouldBe(50);
        }

        [Fact]
        public void Given_backstage_passes_When_processed_the_amount_should_reduce_by_one()
        {
            Program sut = new Program { Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 } } };
            sut.UpdateQuality();
            sut.Items[0].Name.ShouldBe("Backstage passes to a TAFKAL80ETC concert");
            sut.Items[0].SellIn.ShouldBe(14);
            sut.Items[0].Quality.ShouldBe(21);
        }

        [Fact]
        public void Given_mana_cake_When_processed_the_amount_should_reduce_by_one()
        {
            Program sut = new Program { Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 } } };
            sut.UpdateQuality();
            sut.Items[0].Name.ShouldBe("Conjured Mana Cake");
            sut.Items[0].SellIn.ShouldBe(2);
            sut.Items[0].Quality.ShouldBe(5);
        }
    }
}