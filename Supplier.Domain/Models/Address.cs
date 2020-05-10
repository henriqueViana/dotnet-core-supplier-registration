using System;
using System.Collections.Generic;
using System.Text;

namespace SupplierProject.Domain.Models
{
    public class Address : Entity
    {
        public string PublicPlace { get; set; }
        public string Complement { get; set; }
        public string Number { get; set; }
        public string Zipcode { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Guid SupplierId { get; set; }

        // Relationship
        public Supplier Supplier { get; set; }
    }
}
