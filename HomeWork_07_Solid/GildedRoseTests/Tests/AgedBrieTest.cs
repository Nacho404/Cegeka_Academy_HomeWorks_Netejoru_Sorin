using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using GildedRoseKata.Items;
using System;

namespace GildedRoseTests.Tests
{
    public class AgedBrieTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(9)]
        public void GivenUpdateQuality_WhenSellInGreaterThan0_ThenQualityIncreasesBy1(int value)
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new AgedBrie { SellIn = value, Quality = 0 });

            // Act
            app.Items[0].UpdateQuality();
            var quality = app.Items[0].Quality;

            // Assert
            Assert.Equal(1, quality);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-7)]
        public void GivenUpdateQuality_WhenSellInIsLessOrEqualThan0_ThenQualityIncreasesBy2(int value)
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new AgedBrie { SellIn = value, Quality = 0 });

            // Act
            app.Items[0].UpdateQuality();
            var quality = app.Items[0].Quality;

            // Assert
            Assert.Equal(2, quality);
        }

        [Fact]
        public void GivenUpdateQuality_WhenQualityIs50_ThenQualityDoesNotChange()
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new AgedBrie { SellIn = 10, Quality = 50 });

            // Act
            app.Items[0].UpdateQuality();
            var quality = app.Items[0].Quality;

            // Assert
            Assert.Equal(50, quality);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(0)]
        [InlineData(-1)]
        public void GivenDecreasSellIn_WhenIsAgedBrie_ThenDecreasSellInBy1(int value)
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new AgedBrie { SellIn = value, Quality = 50 });

            // Act
            app.Items[0].DecreasSellIn();
            var sellIn = app.Items[0].SellIn;

            // Assert
            Assert.Equal((value - 1), sellIn);
        }
    }
}
