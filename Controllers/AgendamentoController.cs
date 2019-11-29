using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_RoleTopMVC.Respositories;
using project_RoleTopMVC.ViewModels;
using project_RoleTopMVC.Models;
using project_RoleTopMVC.Enums;

namespace project_RoleTopMVC.Controllers
{
    public class AgendamentoController : AbstractController
    {
        ClienteRepository clienteRepository = new ClienteRepository();
        AgendamentoRepository agendamentoRepository = new AgendamentoRepository();

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
            Agendamento agendamento = new Agendamento();
            //Cliente cliente = new Cliente();
            Evento evento = new Evento(form["tema"], form["data"], form["quantidade"], form["tipo"], form["servico"], form["descricao"]);
            evento.Cliente = clienteRepository.ObterPor(ObterUsuarioSession());
            agendamento.Evento = evento;
            agendamento.Cliente = evento.Cliente;
            if(agendamentoRepository.Inserir(agendamento))
            {
                return View("Sucesso", new RespostaViewModel(){
                    Mensagem = "Aguarde a aprovação dos nosso administradores",
                    NomeView = "Sucesso",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            } else {
                return View("Falha", new RespostaViewModel(){
                    Mensagem = "Houve um erro ao processar seu pedido, tente novamente.",
                    NomeView = "Falha",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
        }
        public IActionResult Aprovar(uint id)
        {
            Agendamento agendamento = agendamentoRepository.ObterPor(id);
            agendamento.Evento.Status = (uint) StatusPedido.APROVADO;
            if (agendamentoRepository.Atualizar(agendamento))
            {
                return RedirectToAction("dashboard", "Administrador");
            } else {
                return View("Erro", new RespostaViewModel(){
                    Mensagem = "Houve um erro ao aprovar seu pedido.",
                    NomeView = "dashboard",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
            
        }
        public IActionResult Reprovar(uint id)
        {
            Agendamento agendamento = agendamentoRepository.ObterPor(id);
            agendamento.Evento.Status = (uint) StatusPedido.REPROVADO;
            if (agendamentoRepository.Atualizar(agendamento))
            {
                return RedirectToAction("dashboard", "Administrador");
            } else {
                return View("Erro", new RespostaViewModel(){
                    Mensagem = "Houve um erro ao reprovar seu pedido.",
                    NomeView = "dashboard",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
        }
    }
}