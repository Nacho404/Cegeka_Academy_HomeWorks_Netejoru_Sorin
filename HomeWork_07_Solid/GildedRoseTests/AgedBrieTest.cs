using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using GildedRoseKata.Items;
using System;

namespace GildedRoseTests
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
            app.DecreasSellInAndUpdateQuality();

            // Act
            var result = ReturnQualityOfAgedBrie(app);
            static int ReturnQualityOfAgedBrie(GildedRose app)
            {
                foreach(var item in app.Items)
                {
                    return item.Quality;
                }
                throw new InvalidOperationException("Something is wrong in 'foreach' of my 'app.Items'");
            }

            // Assert
            Assert.Equal(1, result);
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
            app.DecreasSellInAndUpdateQuality();

            // Act
            var result = ReturnQualityOfAgedBrie(app);
            static int ReturnQualityOfAgedBrie(GildedRose app)
            {
                foreach (var item in app.Items)
                {
                    return item.Quality;
                }
                throw new InvalidOperationException("Something is wrong in 'foreach' of my 'app.Items'");
            }

            // Assert
            Assert.Equal(2, result);
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
            app.DecreasSellInAndUpdateQuality();

            // Act
            var result = ReturnQualityOfAgedBrie(app);
            static int ReturnQualityOfAgedBrie(GildedRose app)
            {
                foreach (var item in app.Items)
                {
                    return item.Quality;
                }
                throw new InvalidOperationException("Something is wrong in 'foreach' of my 'app.Items'");
            }

            // Assert
            Assert.Equal(50, result);
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
            app.DecreasSellInAndUpdateQuality();

            // Act
            var result = ReturnQualityOfAgedBrie(app);
            static int ReturnQualityOfAgedBrie(GildedRose app)
            {
                foreach (var item in app.Items)
                {
                    return item.Quality;
                }
                throw new InvalidOperationException("Something is wrong in 'foreach' of my 'app.Items'");
            }

            // Assert
            Assert.Equal(50, result);
        }
    }
}
