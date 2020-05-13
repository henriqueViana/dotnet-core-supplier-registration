using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SupplierProject.Application.DTO
{
    public class ProductDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O campo nome deve ter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O campo nome deve ter no máximo 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        [MinLength(3, ErrorMessage = "O campo nome deve ter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O campo nome deve ter no máximo 100 caracteres")]
        public string Description { get; set; }

        public string Image { get; set; }

        public string ImageUpload { get; set; }

        [Required(ErrorMessage = "O campo preço é obrigatório")]
        public decimal Price { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreatedAt { get; set; }

        public bool Active { get; set; }

        [Required(ErrorMessage = "O campo id do fornecedor é obrigatório")]
        public Guid SupplierId { get; set; } 

        [ScaffoldColumn(false)]
        public string SupplierName { get; set; }
    }
}
