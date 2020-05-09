using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Supplier.Application.DTO
{
    public class AddressDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo endereço é obrigatório")]
        [MinLength(3, ErrorMessage = "O campo endereço deve ter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O campo endereço deve ter no máximo 100 caracteres")]
        public string PublicPlace { get; set; }

        public string Complement { get; set; }

        [Required(ErrorMessage = "O campo número é obrigatório")]
        [MinLength(1)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O campo número só aceita valores numéricos")]
        public string Number { get; set; }

        [Required(ErrorMessage = "O campo cep é obrigatório")]
        [MinLength(8, ErrorMessage = "O campo cep deve conter 8 caracteres")]
        [MaxLength(8, ErrorMessage = "O campo cep deve conter 8 caracteres")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O campo cep só aceita valores numéricos")]
        public string Zipcode { get; set; }

        [Required(ErrorMessage = "O campo bairro é obrigatório")]
        [MinLength(3, ErrorMessage = "O campo bairro deve ter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O campo bairro deve ter no máximo 100 caracteres")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "O campo cidade é obrigatório")]
        [MinLength(3, ErrorMessage = "O campo cidade deve ter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O campo cidade deve ter no máximo 100 caracteres")]
        public string City { get; set; }

        [Required(ErrorMessage = "O campo estado é obrigatório")]
        [MinLength(2, ErrorMessage = "O campo estado deve ter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O campo estado deve ter no máximo 100 caracteres")]
        public string State { get; set; }

        public Guid SupplierId { get; set; }
    }
}
