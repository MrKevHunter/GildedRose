using Xunit;

namespace GildedRose.Tests
{
    using System.Collections.Generic;

    using GildedRose.Console;

    using Shouldly;

    public class MaxQualityTests
    {

        [Fact]
        public void Given_brie_When_processed_the_amount_should_reduce_by_one()
        {
            Program sut = new Program { Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 50 } } };
            sut.UpdateQuality();
            sut.Items[0].Name.ShouldBe("Aged Brie");
            sut.Items[0].Quality.ShouldBe(50);
        }


    }

    public class SellInTests
    {
        [Fact]
        public void Given_brie_When_processed_the_amount_should_reduce_by_one()
        {
            Program sut = new Program { Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 } } };
            sut.UpdateQuality();
            sut.Items[0].Name.ShouldBe("Aged Brie");
            sut.Items[0].Quality.ShouldBe(50);
        }

        [Fact]
        public void Given_mongoose_elixir_When_sell_in_date_is_0_should_reduce_by_on()
        {
            Program sut = new Program { Items = new List<Item> { new Item { Name = "Elixir of the Mongoose", SellIn = -1, Quality = 7 } } };
            sut.UpdateQuality();
            sut.Items[0].Name.ShouldBe("Elixir of the Mongoose");
            sut.Items[0].SellIn.ShouldBe(-2);
            sut.Items[0].Quality.ShouldBe(5);
        }

        [Fact]
        public void Given_backstage_passes_When_processed_after_sell_in_date_the_quality_should_be_zero()
        {
            Program sut = new Program { Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 20 } } };
            sut.UpdateQuality();
            sut.Items[0].Name.ShouldBe("Backstage passes to a TAFKAL80ETC concert");
            sut.Items[0].SellIn.ShouldBe(-2);
            sut.Items[0].Quality.ShouldBe(0);

        }

    }
}