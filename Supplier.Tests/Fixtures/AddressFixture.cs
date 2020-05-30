using Bogus;
using SupplierProject.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SupplierProject.Tests.Fixtures
{
    [CollectionDefinition(nameof(AddressCollection))]
    public class AddressCollection : ICollectionFixture<AddressFixture> { }
    
    public class AddressFixture : IDisposable
    {
        public AddressDTO GetValidAddress()
        {
            var faker = new Faker();

            var address = new AddressDTO
            {
                Id = faker.Random.Guid(),
                PublicPlace = faker.Address.StreetName(),
                Complement = faker.Address.SecondaryAddress(),
                Number = faker.Address.BuildingNumber(),
                Zipcode = faker.Address.ZipCode(),
                Neighborhood = faker.Address.City(),
                City = faker.Address.City(),
                State = faker.Address.StateAbbr(),
                SupplierId = faker.Random.Guid()
            };

            return address;
        }

        public void Dispose()
        {

        }
    }
}
