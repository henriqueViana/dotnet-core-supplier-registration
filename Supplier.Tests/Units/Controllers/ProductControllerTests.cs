using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Supplier.Tests.Fixtures;
using SupplierProject.Application.DTO;
using SupplierProject.Domain.Interfaces.Services;
using SupplierProject.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Supplier.Tests.Units.Controllers
{
    [Collection(nameof(ProductCollection))]
    public class ProductControllerTests
    {
        private readonly ProductFixture _productFixture;
        public ProductControllerTests(ProductFixture productFixture)
        {
            _productFixture = productFixture;
        }

        [Fact(DisplayName = "Product getById success")]
        [Trait("ProductController","GetById success")]
        public async Task ProductController_GetProductById_ShouldReturnCorrectProduct()
        {
            // Arrange
            var mock = new Mock<IProductService>();
            var product = _productFixture.GetValidProduct();
            var productId = Guid.NewGuid();

            mock.Setup(service => service.GetById(productId)).ReturnsAsync(product);

            // Act
            ProductController controller = new ProductController(mock.Object);

            var actionResult = await controller.GetById(productId);
            var result = Assert.IsType<ActionResult<ProductDTO>>(actionResult).Result;
            var statusCode = result as OkResult;

            // Arrange
            result.Should().Equals(product);
            statusCode.Should().Equals(HttpStatusCode.OK);
        }
    }
}
