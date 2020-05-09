using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Supplier.Application.DTO
{
    public class SupplierDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O campo nome deve ter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O campo nome deve ter no máximo 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O camop documento é obrigatório")]
        [MinLength(11, ErrorMessage = "O campo documento deve ter no mínimo 11 caracteres")]
        [MaxLength(14, ErrorMessage = "O campo documento deve ter no máximo 14 caracteres")]
        public string Document { get; set; }

        public AddressDTO Address { get; set; }

        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
