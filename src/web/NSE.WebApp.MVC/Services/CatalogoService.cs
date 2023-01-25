using Microsoft.Extensions.Options;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services.Interfaces;

namespace NSE.WebApp.MVC.Services
{
    public class CatalogoService : Service, ICatalogoService
    {
        private readonly HttpClient _httpClient;

        public CatalogoService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CatalogoUrl);
        }

        public async Task<ProdutoViewModel> ObterPorId(Guid id)
        {
            var response = await _httpClient.GetAsync($"/catalogo/produtos/{id}");
            
            TratarErrosResponse(response);

            return await DeserializeResponseObject<ProdutoViewModel>(response);
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            var response = await _httpClient.GetAsync("/catalogo/produtos/");

            TratarErrosResponse(response);

            return await DeserializeResponseObject<IEnumerable<ProdutoViewModel>>(response);
        }
    }
}
