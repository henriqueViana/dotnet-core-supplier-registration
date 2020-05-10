using System;
using System.Collections.Generic;
using System.Text;

namespace Supplier.Domain.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        protected Guid Id { get; set; }
    }
}
