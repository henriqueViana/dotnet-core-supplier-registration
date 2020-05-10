using System;
using System.Collections.Generic;
using System.Text;

namespace Supplier.Domain.Models
{
    public class Supplier : Entity
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public Address Address { get; set; }
        public bool Active { get; set; }

        // Relationship
        public IEnumerable<Product> Products { get; set; }
    }
}
