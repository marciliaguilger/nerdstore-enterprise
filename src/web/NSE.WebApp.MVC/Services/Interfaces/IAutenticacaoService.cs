using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Services.Interfaces
{
    public interface IAutenticacaoService
    {
        Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin);

        Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro);

    }
}
