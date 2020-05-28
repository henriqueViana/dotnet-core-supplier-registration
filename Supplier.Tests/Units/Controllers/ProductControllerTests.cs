using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
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
    public class ProductControllerTests
    {
        [Fact(DisplayName = "Product getById success")]
        [Trait("ProductController","GetById success")]
        public async Task ProductController_GetProductById_ShouldReturnCorrectProduct()
        {
            // Arrange
            var mock = new Mock<IProductService>();
            var productId = Guid.NewGuid();

            var product = new ProductDTO
            {
                Id = productId,
                Name = "Produto 2",
                Description = "Um novo produto",
                Price = 10
            };

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
