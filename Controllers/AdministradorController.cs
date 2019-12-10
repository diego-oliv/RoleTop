using Microsoft.AspNetCore.Mvc;
using project_RoleTopMVC.Enums;
using project_RoleTopMVC.Repositories;
using project_RoleTopMVC.ViewModels;

namespace project_RoleTopMVC.Controllers
{
     public class AdministradorController : AbstractController
     {
          AgendamentoRepository agendamentoRepository = new AgendamentoRepository();
          [HttpGet]
          public IActionResult Dashboard()
          {
               var tipoUsuarioSession = uint.Parse(ObterUsuarioTipoSession());
               if (tipoUsuarioSession.Equals((uint)TiposUsuario.ADMINISTRADOR))
               {
                    var agendamentos = agendamentoRepository.ObterTodos();
                    DashboardViewModel dashboardViewModel = new DashboardViewModel();
                    foreach (var agendamento in agendamentos)
                    {
                         switch (agendamento.Evento.Status)
                         {
                              case (uint)StatusAgendamento.REPROVADO:
                                   dashboardViewModel.AgendamentosReprovados++;
                                   break;
                              case (uint)StatusAgendamento.APROVADO:
                                   dashboardViewModel.AgendamentosAprovados++;
                                   break;
                              default:
                                   dashboardViewModel.AgendamentosPendentes++;
                                   dashboardViewModel.Agendamentos.Add(agendamento);
                                   break;
                         }
                    }
                    dashboardViewModel.NomeView = "Dashboard";
                    dashboardViewModel.UsuarioEmail = ObterUsuarioSession();
                    return View(dashboardViewModel);
               }
               else
               {
                    return View("Falha", new RespostaViewModel()
                    {
                         NomeView = "Dashboard",
                         Mensagem = "Você não é digno de entrar nesta tela."
                    });
               }
          }
          public IActionResult Eventos()
          {
               var tipoUsuarioSession = uint.Parse(ObterUsuarioTipoSession());
               if (tipoUsuarioSession.Equals((uint)TiposUsuario.ADMINISTRADOR))
               {
                    var agendamentos = agendamentoRepository.ObterTodos();
                    DashboardViewModel dashboardViewModel = new DashboardViewModel();

                    foreach (var agendamento in agendamentos)
                    {
                         switch (agendamento.Evento.Status)
                         {
                              case (uint)StatusAgendamento.REPROVADO:
                                   dashboardViewModel.Agendamentos.Add(agendamento);
                                   break;
                              case (uint)StatusAgendamento.APROVADO:
                                   dashboardViewModel.Agendamentos.Add(agendamento);
                                   break;
                              default:
                                   dashboardViewModel.Agendamentos.Add(agendamento);
                                   break;
                         }
                    }

                    dashboardViewModel.NomeView = "Historico";
                    dashboardViewModel.UsuarioEmail = ObterUsuarioSession();
                    return View(dashboardViewModel);
               }
               else
               {
                    return View("Falha", new RespostaViewModel()
                    {
                         NomeView = "Dashboard",
                         Mensagem = "Você não é digno de entrar nesta página."
                    });
               }
          }
     }
}