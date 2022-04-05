using GildedRoseKata;
using GildedRoseKata.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRoseTests.Tests
{
    public class BackstageTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-20)]
        public void GivenUpdateQuality_WhenSellInIsLessOrEqualThan0_ThenQualityIs0(int value)
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new BackstagePasses { SellIn = value, Quality = 50 });

            // Act
            app.Items[0].UpdateQuality();
            var quality = app.Items[0].Quality;

            // Assert
            Assert.Equal(0, quality);
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
        [InlineData(11)]
        [InlineData(23)]
        [InlineData(100)]
        public void GivenUpdateQuality_WhenSellInIsGreaterThen10_ThenQualityIncreasesBy1(int value)
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new BackstagePasses { SellIn = value, Quality = 0 });

            // Act
            app.Items[0].UpdateQuality();
            var quality = app.Items[0].Quality;

            // Assert
            Assert.Equal(1, quality);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(8)]
        [InlineData(6)]
        public void GivenUpdateQuality_WhenSellInIsLessThan11_ThenQualityIncreasesBy2(int value)
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new BackstagePasses { SellIn = value, Quality = 10 });

            // Act
            app.Items[0].UpdateQuality();
            var quality = app.Items[0].Quality;

            // Assert
            Assert.Equal(12, quality);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(3)]
        [InlineData(1)]
        public void GivenUpdateQuality_WhenSellInIsLessThan6_ThenQualityIncreasesBy3(int value)
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new BackstagePasses { SellIn = value, Quality = 40 });

            // Act
            app.Items[0].UpdateQuality();
            var quality = app.Items[0].Quality;

            // Assert
            Assert.Equal(43, quality);
        }

        [Fact]
        public void GivenDecreasSellIn_WhenIsBackstagePasses_ThenSellInDecreasBy1()
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new BackstagePasses { SellIn = 10, Quality = 40 });

            // Act
            app.Items[0].DecreasSellIn();
            var sellIn = app.Items[0].SellIn;

            // Assert
            Assert.Equal(9, sellIn);
        }

    }
}
