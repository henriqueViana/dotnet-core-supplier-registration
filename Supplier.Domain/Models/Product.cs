﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SupplierProject.Domain.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
        public Guid SupplierId { get; set; }

        // Relationship
        public Supplier Supplier { get; set; }
    }
}
