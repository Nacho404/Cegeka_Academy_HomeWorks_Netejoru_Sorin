using GildedRoseKata;
using GildedRoseKata.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRoseTests
{
    public class DexterityVestTest
    {
        [Fact]
        public void GivenUpdateQuality_WhenQualityIs0_ThenQualityDoesNotChange()
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new DexterityVest { SellIn = 10, Quality = 0 });

            // Act
            app.Items[0].UpdateQuality();
            var quality = app.Items[0].Quality;

            // Assert
            Assert.Equal(0, quality);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GivenUpdateQuality_WhenSellInIsLessOrEqualThan0AndQualityIs1_ThenQualityIs0(int value)
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new DexterityVest { SellIn = value, Quality = 1 });

            // Act
            app.Items[0].UpdateQuality();
            var quality = app.Items[0].Quality;

            // Assert
            Assert.Equal(0, quality);
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(-1, 3)]
        [InlineData(-9, 30)]
        public void GivenUpdateQuality_WhenSellInIsLessOrEqualThan0AndQualityGreaterThan1_ThenQualityDecreasBy2(int sellInValue, int qualityValue)
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new DexterityVest { SellIn = sellInValue, Quality = qualityValue });

            // Act
            app.Items[0].UpdateQuality();
            var quality = app.Items[0].Quality;

            // Assert
            Assert.Equal((qualityValue - 2), quality);
        }

        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 1)]
        public void GivenUpdateQuality_WhenSellInAndQualityGreaterThan0_ThenQualityDecreasBy1(int sellInValue, int qualityValue)
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new DexterityVest { SellIn = sellInValue, Quality = qualityValue });

            // Act
            app.Items[0].UpdateQuality();
            var quality = app.Items[0].Quality;

            // Assert
            Assert.Equal((qualityValue - 1), quality);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(0)]
        [InlineData(-1)]
        public void GivenDecreasSellIn_WhenIsDexterityVest_ThenDecreasSellInBy1(int value)
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new DexterityVest { SellIn = value, Quality = 50 });

            // Act
            app.Items[0].DecreasSellIn();
            var sellIn = app.Items[0].SellIn;

            // Assert
            Assert.Equal((value - 1), sellIn);
        }
    }
}
