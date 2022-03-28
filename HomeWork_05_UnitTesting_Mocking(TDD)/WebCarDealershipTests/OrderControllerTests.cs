﻿using Moq;
using System;
using System.Collections.Generic;
using WebCarDealership.Controllers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CarDealership.Data;
using CarDealership.Data.Models;
using WebCarDealership.Requests;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace WebCarDealershipTests
{
    public class OrderControllerTests
    {

        private readonly Mock<IRepository> repoMock;
        private readonly OrderController controllerSut;

        public OrderControllerTests()
        {
            repoMock = new Mock<IRepository>();
            controllerSut = new OrderController(repoMock.Object);
        }


        [Fact]
        public async Task GivenAnInvalidCarOfferId_WhenCallingPost_ThenGetNotFound()
        {
            // Arrange
            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync((CarOffer)null);
            var requestModel = new OrderRequestModel();

            // Act
            var result = await controllerSut.Post(requestModel);

            // Assert
            result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Fact]
        public async Task GivenQuantityBiggerThenAvailableStock_WhenCallingPost_ThenGetBadRequest()
        {

            // Arrange
            var offer = new CarOffer()
            {
                Id = 1,
                Model = "Opel",
                Make = "Astra H",
                AvailableStock = 10,
                UnitPrice = 2500

            };
            repoMock.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

            var requestModel = new OrderRequestModel()
            {
                CarOfferId = 1,
                CustomerId = 10,
                Quantity = 11
            };

            // Act
            var result = await controllerSut.Post(requestModel);

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }


        [Fact]
        public async Task Given_When_Then()
        {

        }
    }
}
