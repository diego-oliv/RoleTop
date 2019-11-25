using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_RoleTopMVC.Respositories;
using project_RoleTopMVC.ViewModels;

namespace project_RoleTopMVC.Controllers
{
    public class AgendamentoController : AbstractController
    {
        ClienteRepository clienteRepository = new ClienteRepository();
        public IActionResult Index()
        {
            AgendamentoViewModel agendamento = new AgendamentoViewModel();

            var UsuarioLogado = ObterUsuarioSession();
            var NomeUsuarioLogado = ObterUsuarioNomeSession();
            if(!string.IsNullOrEmpty(NomeUsuarioLogado)){
                agendamento.NomeUsuario = NomeUsuarioLogado;
            }

            var ClienteLogado = clienteRepository.ObterPor(UsuarioLogado);
            if(ClienteLogado != null){
                agendamento.Cliente = ClienteLogado;
            }
            agendamento.NomeView = "Agendamento";
            agendamento.NomeUsuario = ObterUsuarioNomeSession();
            agendamento.UsuarioEmail = ObterUsuarioSession();
            return View(agendamento);
        }
        
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