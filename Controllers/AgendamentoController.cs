using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace project_RoleTopMVC.Controllers
{
    public class AgendamentoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Agendar(IFormCollection form)
        {
            ViewData["Action"] = "Agendamento";
            try{
            return View("Sucesso");
            } catch (Exception e){
                System.Console.WriteLine(e.StackTrace);
                return View("Falha");
            }
        }
    }
}