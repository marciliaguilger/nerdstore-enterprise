using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NSE.WebApp.MVC.Models;
using System.Diagnostics;

namespace NSE.WebApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var errorModel = new ErrorViewModel();

            if(id == 500)
            {
                errorModel.Mensagem = "Ocorreu um erro. Tente novamente ou contate o suporte";
                errorModel.Titulo = "Ocorreu um erro";
                errorModel.ErrorCode = id;
            }else if (id == 404)
            {
                errorModel.Mensagem = "A página que está procurando não existe.";
                errorModel.Titulo = "Página não encontrada.";
                errorModel.ErrorCode = id;
            }else if (id == 403)
            {
                errorModel.Mensagem = "Acesso negado";
                errorModel.Titulo = "Acesso negado";
                errorModel.ErrorCode = id;
            }
            else 
            {
                return StatusCode(404);
            }

            return View("Error", errorModel);
        }
    }
}