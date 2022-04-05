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
    public class ConjuredManaCakeTest
    {
        [Fact]
        public void GivenUpdateQuality_WhenQualityIs0_ThenQualityDoesNotChange()
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new ConjuredManaCake { SellIn = 10, Quality = 0 });

            // Act
            app.Items[0].UpdateQuality();
            var quality = app.Items[0].Quality;

            // Assert
            Assert.Equal(0, quality);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(20)]
        public void GivenUpdateQuality_WhenSellInGreaterThan0AndQualityIs1_ThenQualityIs0(int value)
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new ConjuredManaCake { SellIn = value, Quality = 1 });

            // Act
            app.Items[0].UpdateQuality();
            var quality = app.Items[0].Quality;

            // Assert
            Assert.Equal(0, quality);
        }

        [Theory]
        [InlineData(2, 10)]
        [InlineData(3, 3)]
        public void GivenUpdateQuality_WhenSellInGreaterThan0AndQualityGreaterThan1_ThenQualityDecreasBy2(int sellInValue, int qualityValue)
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new ConjuredManaCake { SellIn = sellInValue, Quality = qualityValue });

            // Act
            app.Items[0].UpdateQuality();
            var quality = app.Items[0].Quality;

            // Assert
            Assert.Equal((qualityValue - 2), quality);
        }

        [Theory]
        [InlineData(0, 3)]
        [InlineData(-1, 2)]
        [InlineData(-10, 1)]
        public void GivenUpdateQuality_WhenSellInIsLessOrEqualThan0AndQualityLessThan4_ThenQualityIs0(int sellInValue, int qualityValue)
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new ConjuredManaCake { SellIn = sellInValue, Quality = qualityValue });

            // Act
            app.Items[0].UpdateQuality();
            var quality = app.Items[0].Quality;

            // Assert
            Assert.Equal(0, quality);
        }

        [Theory]
        [InlineData(0, 4)]
        [InlineData(-1, 5)]
        [InlineData(-10, 37)]
        public void GivenUpdateQuality_WhenSellInIsLessOrEqualThan0AndQualityGreaterThan3_ThenQualityDecreasBy4(int sellInValue, int qualityValue)
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new ConjuredManaCake { SellIn = sellInValue, Quality = qualityValue });

            // Act
            app.Items[0].UpdateQuality();
            var quality = app.Items[0].Quality;

            // Assert
            Assert.Equal((qualityValue - 4), quality);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(0)]
        [InlineData(-1)]
        public void GivenDecreasSellIn_WhenIsConjuredManaCake_ThenDecreasSellInBy1(int value)
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new ConjuredManaCake { SellIn = value, Quality = 50 });

            // Act
            app.Items[0].DecreasSellIn();
            var sellIn = app.Items[0].SellIn;

            // Assert
            Assert.Equal((value - 1), sellIn);
        }
    }
}
