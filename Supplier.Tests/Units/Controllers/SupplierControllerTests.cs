using Microsoft.AspNetCore.Mvc;
using Moq;
using SupplierProject.Application.DTO;
using SupplierProject.Domain.Interfaces.Services;
using SupplierProject.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Net;
using SupplierProject.Tests.Fixtures;

namespace SupplierProject.Tests
{
    [Collection(nameof(SupplierCollection))]
    public class SupplierControllerTests
    {
        private readonly SupplierFixture _supplierFixture;
        public SupplierControllerTests(SupplierFixture supplierFixture)
        {
            _supplierFixture = supplierFixture;
        }

        [Fact(DisplayName = "Should Return all Suppliers")]
        [Trait("SupplierController", "GetAll")]
        public async Task GetAll_SupplierList_ShouldReturnSupplierList()
        {
            // Arrange
            int supplierCount = 5;
            var mock = new Mock<ISupplierService>();
            var suppliers = _supplierFixture.GetValidSupplierList(supplierCount);

            mock.Setup(service => service.GetAll()).ReturnsAsync(suppliers);

            // Act
            SupplierController controller = new SupplierController(mock.Object);
            var result = await controller.GetAll();

            // Arrange
            result.Should().Equal(suppliers)
                .And.HaveCount(supplierCount)
                .And.ContainItemsAssignableTo<SupplierDTO>();
        }

        [Fact(DisplayName = "Shoud Return a specific Supplier by Id")]
        [Trait("SupplierController", "GetById")]
        public async Task GetById_SpecificSupplier_ShouldReturnASupplier()
        {
            // Arrange
            var supplier = _supplierFixture.GetValidSupplier();
            var supplierId = supplier.Id;

            var mock = new Mock<ISupplierService>();
            mock.Setup(service => service.GetSupplierAndAddressAndProducts(supplierId)).ReturnsAsync(supplier);

            // Act
            SupplierController controller = new SupplierController(mock.Object);

            var actionResult = await controller.GetById(supplierId);
            var result = Assert.IsType<ActionResult<SupplierDTO>>(actionResult).Result;
            var okResult = result as OkObjectResult;

            // Assert
            okResult.Value.Should().BeSameAs(supplier);
            okResult.StatusCode.Equals(HttpStatusCode.OK);
        }

        [Fact(DisplayName = "Create a new Supplier with success")]
        [Trait("SupplierController", "Create")]
        public async Task CreateNewSupplier_SupplierCreated_ShouldReturnTheSupplierCreated()
        {
            // Arrange
            var mock = new Mock<ISupplierService>();
            var supplier = _supplierFixture.GetValidSupplier();

            mock.Setup(service => service.Create(supplier)).ReturnsAsync(true);

            // Act
            SupplierController controller = new SupplierController(mock.Object);
            
            var actionResult = await controller.Create(supplier);
            var result = Assert.IsType<ActionResult<SupplierDTO>>(actionResult).Result;
            var createdResult = result as CreatedResult;

            // Assert
            createdResult.Value.Should().BeSameAs(supplier);
            createdResult.StatusCode.Equals(HttpStatusCode.Created);
        }

        [Fact(DisplayName = "Create a new Supplier failed")]
        [Trait("SupplierController", "Create failed")]
        public async Task CreateNewSupplier_SupplierCreateFailed_ShouldReturnBadrequest()
        {
            // Arrange
            var mock = new Mock<ISupplierService>();
            var supplier = _supplierFixture.GetValidSupplier();

            mock.Setup(service => service.Create(supplier)).ReturnsAsync(false);

            // Act
            SupplierController controller = new SupplierController(mock.Object);

            var actionResult = await controller.Create(supplier);
            var result = Assert.IsType<ActionResult<SupplierDTO>>(actionResult).Result;
            var badRequestResult = result as BadRequestResult;

            // Assert
            badRequestResult.StatusCode.Equals(HttpStatusCode.BadRequest);

        }

        [Fact(DisplayName = "Update a Supplier")]
        [Trait("SupplierController", "Update")]
        public async Task UpdateSupplier_SupplierUpdated_ShouldReturnNoContent()
        {
            // Arrange
            var mock = new Mock<ISupplierService>();
            var supplier = _supplierFixture.GetValidSupplier();
            var supplierId = supplier.Id;

            mock.Setup(service => service.Update(supplierId, supplier)).ReturnsAsync(true);

            // Act
            SupplierController controller = new SupplierController(mock.Object);

            var actionResult = await controller.Update(supplierId, supplier);
            var result = Assert.IsType<ActionResult<SupplierDTO>>(actionResult).Result;
            var noContentResult = result as NoContentResult;

            // Assert
            noContentResult.Should().Equals(HttpStatusCode.NoContent);
        }

        [Fact(DisplayName = "Update Supplier not exist")]
        [Trait("SupplierController", "Update failed not found")]
        public async Task UpdateSupplier_SupplierNotFound_ShouldReturnNotFound()
        {
            // Arrange
            var mock = new Mock<ISupplierService>();
            var supplier = _supplierFixture.GetValidSupplier();
            var supplierId = supplier.Id;

            mock.Setup(service => service.IsExist(supplierId)).ReturnsAsync(false);

            // Act
            SupplierController controller = new SupplierController(mock.Object);

            var actionResult = await controller.Update(supplierId, supplier);
            var result = Assert.IsType<ActionResult<SupplierDTO>>(actionResult).Result;
            var notFoundResult = result as NotFoundResult;

            // Assert
            notFoundResult.StatusCode.Equals(HttpStatusCode.NotFound);
        }

        [Fact(DisplayName = "Update supplier id not equal")]
        [Trait("SupplierController", "Update Failed")]
        public async Task UpdateSupplier_SupplierIdNotEqual_ShouldReturnBadRequest()
        {
            // Arrange
            var mock = new Mock<ISupplierService>();
            var supplier = _supplierFixture.GetValidSupplier();
            var otherId = Guid.NewGuid();

            mock.Setup(service => service.Update(otherId, supplier)).ReturnsAsync(false);

            // Act
            SupplierController controller = new SupplierController(mock.Object);

            var actionResult = await controller.Update(otherId, supplier);
            var result = Assert.IsType<ActionResult<SupplierDTO>>(actionResult).Result;
            var badRequestResult = result as BadRequestResult;

            // Assert
            badRequestResult.Should().Equals(HttpStatusCode.BadRequest);
        }
        
        [Fact(DisplayName = "Destroy with error")]
        [Trait("SupplierController", "Destroy failed")]
        public async Task DestroySupplier_SupplierError_ShouldReturnBadRequest()
        {
            // Arrange
            var mock = new Mock<ISupplierService>();
            var supplierId = Guid.NewGuid();

            mock.Setup(service => service.Destroy(supplierId)).ReturnsAsync(false);

            // Act
            SupplierController controller = new SupplierController(mock.Object);

            var actionResult = await controller.Destroy(supplierId);
            var result = Assert.IsType<ActionResult<SupplierDTO>>(actionResult).Result;
            var badRequestResult = result as BadRequestResult;

            // Assert
            badRequestResult.Should().Equals(HttpStatusCode.BadRequest);
        }

        [Fact(DisplayName = "Destroy with supplier not found")]
        [Trait("SupplierController", "Destroy failed not found")]
        public async Task DestroySupplier_SupplierNotFound_ShouldReturnNotFound()
        {
            // Arrange
            var mock = new Mock<ISupplierService>();
            var supplierId = Guid.NewGuid();

            mock.Setup(service => service.GetById(supplierId)).Returns(Task.FromResult<SupplierDTO>(null));

            // Act
            SupplierController controller = new SupplierController(mock.Object);

            var actionResult = await controller.Destroy(supplierId);
            var result = Assert.IsType<ActionResult<SupplierDTO>>(actionResult).Result;
            var notFoundResult = result as NotFoundResult;

            // Assert
            notFoundResult.Should().Equals(HttpStatusCode.BadRequest);
        }
    }
}
