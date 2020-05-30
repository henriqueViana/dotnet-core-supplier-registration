using Bogus;
using Bogus.Extensions.Brazil;
using SupplierProject.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Supplier.Tests.Fixtures
{
    [CollectionDefinition(nameof(SupplierCollection))]
    public class SupplierCollection : ICollectionFixture<SupplierFixture> { }

    public class SupplierFixture : IDisposable
    {
        public SupplierDTO GetValidSupplier()
        {
            var faker = new Faker();

            var supplier = new SupplierDTO
            {
                Id = faker.Random.Guid(),
                Name = faker.Company.CompanyName(),
                Document = faker.Company.Cnpj(),
                Address = null
            };

            return supplier;
        }

        public void Dispose()
        {
            
        }
    }
}
