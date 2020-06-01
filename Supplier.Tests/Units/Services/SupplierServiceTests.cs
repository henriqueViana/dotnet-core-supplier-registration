using Moq;
using SupplierProject.Tests.Fixtures;
using SupplierProject.Application.DTO;
using SupplierProject.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SupplierProject.Domain.Models;
using AutoMapper;
using SupplierProject.Domain.Services;
using FluentAssertions;
using SupplierProject.Tests.Config;
using Microsoft.AspNetCore.Mvc;

namespace SupplierProject.Tests.Units.Services
{
    [Collection(nameof(SupplierCollection))]
    public class SupplierServiceTests
    {
        private readonly SupplierFixture _supplierFixture;
        public SupplierServiceTests(SupplierFixture supplierFixture)
        {
            _supplierFixture = supplierFixture;
        }

        [Fact(DisplayName = "Should Return all Suppliers")]
        [Trait("SupplierService", "GetAll")]

        public async Task GetAll_SupplierDTOList_ShouldReturnSupplierDTOList()
        {
            // Arrange
            int supplierCount = 5;
            var mockRepo = new Mock<ISupplierRepository>();

            var suppliers = _supplierFixture.GetValidSupplierListModel(supplierCount);

            mockRepo.Setup(repo => repo.GetAll()).ReturnsAsync(suppliers);

            // Act
            SupplierService service = new SupplierService(mockRepo.Object, AutoMapperSingleton.Mapper);
            var result = await service.GetAll();

            // Assert
            result.Should().HaveCount(supplierCount)
                .And.ContainItemsAssignableTo<SupplierDTO>();
        }

        [Fact(DisplayName = "Shoud Return a specific Supplier by Id")]
        [Trait("SupplierService", "GetById")]
        public async Task GetById_SpecificSupplierDTO_ShouldReturnSupplierDTO()
        {
            // Arrange
            var mockRepo = new Mock<ISupplierRepository>();
            var supplier = _supplierFixture.GetValidSupplierModel();
            var supplierId = supplier.Id;

            mockRepo.Setup(repo => repo.GetById(supplierId)).ReturnsAsync(supplier);

            // Act
            SupplierService service = new SupplierService(mockRepo.Object, AutoMapperSingleton.Mapper);
            var result = await service.GetById(supplierId);
            
            // Assert
            result.Should().As<SupplierDTO>();
        }
    }
}
