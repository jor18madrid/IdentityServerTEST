using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Controllers
{
    public class LoginViewModel
    {
        [Required]
        [Compare("DefaultUser", ErrorMessage = "El usuario no existe.")]
        public string Username { get; set; }
        public string DefaultUser { get; set; } = "admin";

        [Required]
        [DataType(DataType.Password)]
        [Compare("DefaultPswd", ErrorMessage = "Contraseña incorrecta.")]

        public string Password { get; set; }
        public string DefaultPswd { get; set; } = "admin";


        [Required(ErrorMessage = "Error, tienes que ser un cliente externo para utilizar este login.")]
        public string ReturnUrl { get; set; }

        public IEnumerable<AuthenticationScheme> ExternalProviders { get; set; }
    }
}