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
        [InlineData(5)]
        [InlineData(10)]
        public void GivenUpdateQualityOnAgedBrie_WhenQualityLessThan50AndSellInGreaterOrEqualThan0_ThenQualityIncreasesBy1(int value)
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new AgedBrie { SellIn = value, Quality = 0 });

            // Act
            app.DecreasSellInAndUpdateQuality();
            var quality = app.Items[0].Quality;

            // Assert
            Assert.Equal(1, quality);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        public void GivenUpdateQualityOnAgedBrie_WhenQualityLessThan50AndSellInLessThan0_ThenQualityIncreasesBy2(int value)
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new AgedBrie { SellIn = value, Quality = 0 });

            // Act
            app.DecreasSellInAndUpdateQuality();
            var quality = app.Items[0].Quality;

            // Assert
            Assert.Equal(2, quality);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void GivenUpdateQualityOnAgedBrie_WhenQualityIs50AndSellInGreaterOrEqualThan0_ThenQualityDoesNotChange(int value)
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new AgedBrie { SellIn = value, Quality = 50 });

            // Act
            app.DecreasSellInAndUpdateQuality();
            var quality = app.Items[0].Quality;

            // Assert
            Assert.Equal(50, quality);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        public void GivenUpdateQualityOnAgedBrie_WhenQualityIs50AndSellInLessThan0_ThenQualityDoesNotChange(int value)
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new AgedBrie { SellIn = value, Quality = 50 });

            // Act
            app.DecreasSellInAndUpdateQuality();
            var quality = app.Items[0].Quality;

            // Assert
            Assert.Equal(50, quality);
        }
    }
}
