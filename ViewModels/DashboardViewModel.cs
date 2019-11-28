using System.Collections.Generic;
using project_RoleTopMVC.Models;

namespace project_RoleTopMVC.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public List<Agendamento> Agendamentos {get;set;}
        public ushort PedidosAprovados {get;set;}
        public ushort PedidosPendentes {get;set;}
        public ushort PedidosReprovados {get;set;}
        public DashboardViewModel()
        {
            this.Agendamentos = new List<Agendamento>();
        }
    }  
}