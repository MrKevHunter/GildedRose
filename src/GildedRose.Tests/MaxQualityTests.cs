using Xunit;

namespace GildedRose.Tests
{
    using System.Collections.Generic;

    using GildedRose.Console;

    using Shouldly;

    public class TestAssemblyTests
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
}