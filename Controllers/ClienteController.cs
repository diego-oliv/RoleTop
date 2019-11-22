using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_RoleTopMVC.Respositories;
using project_RoleTopMVC.ViewModels;

namespace RoleTop.Controllers
{
    public class ClienteController : Controller
    {
        private const string SESSION_CLIENTE_EMAIL = "email_cliente";
        private ClienteRepository clienteRepository = new ClienteRepository();
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(IFormCollection form)
        {
            ViewData["Action"] = "Login";
            try{
                var usuario = form["email"];
                var senha = form["senha"];
                var cliente = clienteRepository.ObterPor(usuario);
                if(cliente != null)
                {
                    HttpContext.Session.SetString("email_cliente", usuario);
                    HttpContext.Session.SetString("SESSION_CLIENTE_NOME", cliente.Nome);
                    if (cliente.Senha.Equals(usuario))
                    {
                        return RedirectToAction("Agendamento", "Cliente");
                    }else{
                        return View("Falha", new RespostaViewModel("Senha inválida."));
                    }
                } else{
                    return View("Falha", new RespostaViewModel($"Usuário {usuario} não foi encontrado."));
                }
            } catch(Exception e){
                System.Console.WriteLine(e.StackTrace);
                return View("Erro");
            }
        }
    }
}