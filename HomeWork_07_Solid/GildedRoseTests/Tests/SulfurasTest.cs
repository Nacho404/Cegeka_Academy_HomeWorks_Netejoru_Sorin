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
    public class SulfurasTest
    {
        [Fact]
        public void GivenUpdateQuality_WhenIsSulfuras_ThenQualityDoesNotChange()
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new Sulfuras { SellIn = 0, Quality = 80 });

            // Act
            app.Items[0].UpdateQuality();
            var quality = app.Items[0].Quality;

            // Assert
            Assert.Equal(80, quality);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(21)]
        [InlineData(-5)]
        public void GivenDecreasSellIn_WhenIsSulfuras_ThenSellInDoesNotChange(int value)
        {
            // Arrange
            GildedRose app = new GildedRose();
            app.AddItem(new Sulfuras { SellIn = value, Quality = 80 });

            // Act
            app.Items[0].DecreasSellIn();
            var sellIn = app.Items[0].SellIn;

            // Assert
            Assert.Equal(value, sellIn);
        }
    }
}
