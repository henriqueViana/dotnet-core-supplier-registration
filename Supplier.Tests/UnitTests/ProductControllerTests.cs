using SupplierProject.Domain.Interfaces.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moq;
using SupplierProject.Domain.Models;
using SupplierProject.Application.DTO;
using SupplierProject.Services.Controllers;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace Supplier.Tests.UnitTests
{
    [TestFixture]
    public class ProductControllerTests
    {
        private Mock<IProductService> productServiceMock;
        private ProductController productController;

        [SetUp]
        public void init()
        {
            productServiceMock = new Mock<IProductService>();
            productController = new ProductController(productServiceMock.Object);
        }

        [Test]
        public async Task GetAll()
        {
            // Arrage
            List<ProductDTO> expectedResult = new List<ProductDTO>();
            productServiceMock.Setup(product => product.GetAll()).ReturnsAsync(expectedResult);

            // Act
            var allProducts = await productController.GetAll();

            //Assert
            allProducts.Should().Equal(expectedResult);
        }

        [Test]
        public async Task GetById()
        {
            // Arrage
            Guid Id = Guid.NewGuid();
            ProductDTO expectedResult = new ProductDTO();
            productServiceMock.Setup(product => product.GetById(Id)).ReturnsAsync(expectedResult);
            
            // Act
            var product = await productController.GetById(Id);

            //Assert
            product.Value.Should().Be(expectedResult);
        }
    }
}
