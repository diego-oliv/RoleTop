using Microsoft.AspNetCore.Mvc;
using project_RoleTopMVC.Controllers;
using project_RoleTopMVC.ViewModels;

namespace project_RoleTopMVC.Controllers
{
    public class GaleriaController : AbstractController
    {
        [HttpGet]
        public IActionResult Index()
        {
            GaleriaViewModel galeria = new GaleriaViewModel();
            return View(galeria);
        }
    }
}