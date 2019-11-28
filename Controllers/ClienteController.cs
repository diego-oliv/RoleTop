using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_RoleTopMVC.Controllers;
using project_RoleTopMVC.Respositories;
using project_RoleTopMVC.ViewModels;

namespace RoleTop.Controllers
{
    public class ClienteController : AbstractController
    {
        private ClienteRepository clienteRepository = new ClienteRepository();
        private AgendamentoRepository agendamentoRepository = new AgendamentoRepository();
        [HttpGet]
        public IActionResult Login()
        {
            return View(new BaseViewModel(){
                NomeView = "Login",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
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
                    if(cliente.Senha.Equals(senha)){
                        HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);
                        HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);
                        return RedirectToAction("Historico", "Cliente");
                    } else {
                        return View("Falha", new RespostaViewModel("A senha está incorreta."));
                    }
                } else {
                    return View("Erro", new RespostaViewModel($"Usuário {usuario} não foi encontrado"));
                }
            } catch(Exception e){
                System.Console.WriteLine(e.StackTrace);
                return View("Erro");
            }
        }
        public IActionResult Logoff()
        {
            HttpContext.Session.Remove(SESSION_CLIENTE_EMAIL);
            HttpContext.Session.Remove(SESSION_CLIENTE_NOME);
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Historico()
        {
            var emailCliente = ObterUsuarioSession();
            var eventos = agendamentoRepository.ObterTodosPorCliente(emailCliente);
            return View(new HistoricoAgendamentoViewModel()
            {
                Eventos = eventos,
                NomeView = "Historico",
                UsuarioNome = ObterUsuarioNomeSession(),
                UsuarioEmail = ObterUsuarioSession()
            });
        }
    }
}