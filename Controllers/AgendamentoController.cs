using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_RoleTopMVC.Respositories;
using project_RoleTopMVC.ViewModels;
using project_RoleTopMVC.Models;

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
            Cliente cliente = new Cliente();
            Evento evento = new Evento(form["tema"], form["data"], form["quantidade"], form["tipo"], form["servico"], form["descricao"]);
            agendamento.Cliente = cliente;
            agendamento.DataDoPedido = DateTime.Now;
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
    }
}