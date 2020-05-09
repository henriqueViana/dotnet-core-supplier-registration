using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Supplier.Application.DTO.User
{
    public class RegisterUserDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório")]
        [MinLength(6, ErrorMessage = "O campo senha deve ter no mínimo 6 caracteres")]
        [MaxLength(50, ErrorMessage = "O campo senha deve ter no máximo 50 caracteres")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas devem ser iguais")]
        public string ConfirmPassword { get; set; }
    }
}
