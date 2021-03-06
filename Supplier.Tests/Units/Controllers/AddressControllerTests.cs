﻿using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SupplierProject.Tests.Fixtures;
using SupplierProject.Application.DTO;
using SupplierProject.Domain.Interfaces.Services;
using SupplierProject.Domain.Models;
using SupplierProject.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SupplierProject.Tests.Units
{
    [Collection(nameof(AddressCollection))]
    public class AddressControllerTests
    {
        private readonly AddressFixture _addressFixture;
        public AddressControllerTests(AddressFixture addressFixture)
        {
            _addressFixture = addressFixture;
        }

        [Fact(DisplayName = "Update Address ok")]
        [Trait("AddressController", "Update ok")]
        public async Task AddressUpdate_AddressCorrect_ShouldReturnNoContent()
        {
            // Arrange
            var mock = new Mock<IAddressService>();
            var address = _addressFixture.GetValidAddress();
            var addressId = address.Id;

            mock.Setup(service => service.Update(addressId, address)).ReturnsAsync(true);

            // Act
            AddressController controller = new AddressController(mock.Object);

            var actionResult = await controller.Update(addressId, address);
            var result = Assert.IsType<ActionResult<AddressDTO>>(actionResult).Result;
            var noContentResult = result as NoContentResult;

            // Assert
            noContentResult.Should().Equals(HttpStatusCode.NoContent);
        }

        [Fact(DisplayName = "Update Address id error")]
        [Trait("AddressController", "Update with id error")]
        public async Task AddressUpdate_AddressWithIdError_ShoudReturnBadRequest()
        {
            // Arrange
            var mock = new Mock<IAddressService>();
            var address = _addressFixture.GetValidAddress();
            var addressId = address.Id;

            mock.Setup(service => service.Update(addressId, address)).ReturnsAsync(false);

            // Act
            AddressController controller = new AddressController(mock.Object);

            var actionResult = await controller.Update(addressId, address);
            var result = Assert.IsType<ActionResult<AddressDTO>>(actionResult).Result;
            var badRequestResult = result as BadRequestResult;

            // Assert
            badRequestResult.Should().Equals(HttpStatusCode.BadRequest);
        }

        [Fact(DisplayName = "Address destroy success")]
        [Trait("AddressController", "Destroy Ok")]
        public async Task AddressDestroy_AddressOk_ShouldReturnOkResult()
        {
            // Arrange
            var mock = new Mock<IAddressService>();
            var addressId = Guid.NewGuid();

            mock.Setup(service => service.Destroy(addressId)).ReturnsAsync(true);

            // Act
            AddressController controller = new AddressController(mock.Object);

            var actionResult = await controller.Destroy(addressId);
            var result = Assert.IsType<ActionResult<AddressDTO>>(actionResult).Result;
            var okResult = result as OkResult;

            // Assert
            okResult.Should().Equals(HttpStatusCode.OK);
        }
    }
}
