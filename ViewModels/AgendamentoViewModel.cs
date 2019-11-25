using project_RoleTopMVC.Models;

namespace project_RoleTopMVC.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {
        public string NomeUsuario {get;set;}
        public Cliente Cliente {get;set;}
        public Evento Evento {get;set;}
        
        public AgendamentoViewModel(){
            this.NomeUsuario = "Consagradinho";
            this.Cliente = new Cliente();
            this.Evento = new Evento();
        }
    }
}