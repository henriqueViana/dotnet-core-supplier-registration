using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SupplierProject.Application.DTO.User
{
    public class LoginUserDTO
    {
        [Required(ErrorMessage = "O campo email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo password é obrigatório")]
        [MinLength(6, ErrorMessage = "O campo password deve ter no mínimo 6 caracteres")]
        [MaxLength(50, ErrorMessage = "O campo password deve ter no máximo 50 caracteres")]
        public string Password { get; set; }
    }
}
