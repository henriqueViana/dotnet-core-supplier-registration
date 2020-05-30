using Bogus;
using SupplierProject.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SupplierProject.Tests.Fixtures
{
    [CollectionDefinition(nameof(ProductCollection))]
    public class ProductCollection : ICollectionFixture<ProductFixture> { }

    public class ProductFixture : IDisposable
    {
        public ProductDTO GetValidProduct()
        {
            var faker = new Faker();

            var product = new ProductDTO
            {
                Id = faker.Random.Guid(),
                Name = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductAdjective(),
                Price = faker.Random.Decimal()
            };

            return product;
        }

        public void Dispose()
        {

        }
    }
}
