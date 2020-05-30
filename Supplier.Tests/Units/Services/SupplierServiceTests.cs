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
    }
}
