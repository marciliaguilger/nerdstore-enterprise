using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NSE.Identity.API.Models
{
    public class UserViewModels
    {
    }


    public class UsuarioRegistro
    {
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage ="O campo {0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} está fora do padrão")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Senhas não conferem")]
        public string SenhaConfirmacao { get; set; }
    }

    public class UsuarioLogin
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} está fora do padrão")]
        public string Senha { get; set; }
    }


}
