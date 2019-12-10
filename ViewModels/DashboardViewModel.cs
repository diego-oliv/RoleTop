using System.Collections.Generic;
using project_RoleTopMVC.Models;

namespace project_RoleTopMVC.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public List<Agendamento> Agendamentos {get;set;}
        public ushort AgendamentosAprovados {get;set;}
        public ushort AgendamentosPendentes {get;set;}
        public ushort AgendamentosReprovados {get;set;}
        public DashboardViewModel()
        {
            this.Agendamentos = new List<Agendamento>();
        }
    }  
}