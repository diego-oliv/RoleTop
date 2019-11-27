using System.Collections.Generic;
using project_RoleTopMVC.Models;
namespace project_RoleTopMVC.ViewModels
{
    public class HistoricoAgendamentoViewModel : BaseViewModel
    {
        public List<Agendamento> Eventos {get;set;}
    }
}