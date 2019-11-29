using Microsoft.AspNetCore.Mvc;
using project_RoleTopMVC.Enums;
using project_RoleTopMVC.Respositories;
using project_RoleTopMVC.ViewModels;

namespace project_RoleTopMVC.Controllers
{
    public class AdministradorController : AbstractController
    {
        AgendamentoRepository agendamentoRepository = new AgendamentoRepository();
        [HttpGet]
        public IActionResult dashboard()
        {
            var tipoUsuarioSession = uint.Parse(ObterUsuarioTipoSession());
            if(tipoUsuarioSession.Equals((uint) TiposUsuario.ADMINISTRADOR))
            {
            var agendamentos = agendamentoRepository.ObterTodos();
            DashboardViewModel dashboardViewModel = new DashboardViewModel();
            foreach(var agendamento in agendamentos)
            {
                switch(agendamento.Evento.Status)
                {
                case (uint) StatusPedido.REPROVADO:
                    dashboardViewModel.PedidosReprovados++;
                break;
                case (uint) StatusPedido.APROVADO:
                    dashboardViewModel.PedidosAprovados++;
                break;
                default:
                    dashboardViewModel.PedidosPendentes++;
                    dashboardViewModel.Agendamentos.Add(agendamento);
                break;
                }
            }
            dashboardViewModel.NomeView = "dashboard";
            dashboardViewModel.UsuarioEmail = ObterUsuarioSession();
            return View(dashboardViewModel);
            } else {
                return View("Falha", new RespostaViewModel(){
                    NomeView = "dashboard",
                    Mensagem = "Você não é digno de entrar nessa tela."
                });
            }
        } 
    }
}