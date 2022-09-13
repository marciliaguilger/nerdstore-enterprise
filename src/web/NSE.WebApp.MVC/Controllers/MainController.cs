using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Controllers
{
    public class MainController : Controller
    {
        protected bool ResponsePossuiErros(ResponseResult responseResult)
        {
            if(responseResult != null && responseResult.Errors.Mensagens.Any())
            {
                return true;
            }

            return false;
        }

    }
}
