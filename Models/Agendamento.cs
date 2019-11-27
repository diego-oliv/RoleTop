using System;

namespace project_RoleTopMVC.Models
{
    public class Agendamento
    {
        public Cliente Cliente {get;set;}
        public Evento Evento {get;set;}

        public Agendamento()
        {
            this.Cliente = new Cliente();
            this.Evento = new Evento();
        }
    }
}