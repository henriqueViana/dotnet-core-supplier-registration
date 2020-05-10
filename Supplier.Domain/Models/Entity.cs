using System;
using System.Collections.Generic;
using System.Text;

namespace SupplierProject.Domain.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
