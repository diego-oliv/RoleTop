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
using project_RoleTopMVC.Enums;

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
            try{
                var usuario = form["email"];
                var senha = form["senha"];
                var cliente = clienteRepository.ObterPor(usuario);
                if(cliente != null)
                    {
                        if(cliente.Senha.Equals(senha)){
                            switch(cliente.TipoUsuario)
                            {
                                case (uint) TiposUsuario.CLIENTE:
                                    HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);
                                    HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);
                                    HttpContext.Session.SetString(SESSION_TIPO_USUARIO, cliente.TipoUsuario.ToString());
                                    return RedirectToAction("Historico", "Cliente");

                                case (uint) TiposUsuario.ADMINISTRADOR:
                                    HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);
                                    HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);
                                    HttpContext.Session.SetString(SESSION_TIPO_USUARIO, cliente.TipoUsuario.ToString());
                                    return RedirectToAction("Dashboard", "Administrador");
                            }
                        } else {
                            return View("Falha", new RespostaViewModel("A senha está incorreta."));
                        }
                    } else {
                        return View("Falha", new RespostaViewModel($"Usuário {usuario} não foi encontrado."));
                    }
            } catch(Exception e){
                System.Console.WriteLine(e.StackTrace);
                return View("Falha", new RespostaViewModel("Houve uma falha no processo."));
            } 
            return RedirectToAction("Index", "Home");
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