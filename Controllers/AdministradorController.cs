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
            var agendamentos = agendamentoRepository.ObterTodos();
            DashboardViewModel dashboardViewModel = new DashboardViewModel();
            foreach(var agendamento in agendamentos)
            {
                switch(agendamento.Evento.Status)
                {
                case (ushort) StatusPedido.REPROVADO:
                    dashboardViewModel.PedidosReprovados++;
                break;
                case (ushort) StatusPedido.APROVADO:
                    dashboardViewModel.PedidosAprovados++;
                break;
                default:
                    dashboardViewModel.PedidosPendentes++;
                    dashboardViewModel.Agendamentos.Add(agendamento);
                break;
                }
            }
            dashboardViewModel.NomeView = "Dashboard";
            dashboardViewModel.UsuarioEmail = ObterUsuarioSession();
            return View(dashboardViewModel);
        } 
    }
}