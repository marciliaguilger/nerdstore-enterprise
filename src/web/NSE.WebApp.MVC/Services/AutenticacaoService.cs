using NSE.WebApp.MVC.Models;
using System.Text;
using System.Text.Json;

namespace NSE.WebApp.MVC.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = new StringContent(JsonSerializer.Serialize(usuarioLogin),
                Encoding.UTF8,
                "application/json");


            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var response = await _httpClient.PostAsync("https://localhost:44355/api/identidade/autenticar", loginContent);

            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        {
            var loginContent = new StringContent(JsonSerializer.Serialize(usuarioRegistro),
                Encoding.UTF8,
                "application/json");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var response = await _httpClient.PostAsync("https://localhost:44355/api/identidade/registrar", loginContent);

            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync(), options);
        }
    }
}
