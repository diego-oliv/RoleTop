using System;

namespace project_RoleTopMVC.Models
{
    public class Evento
    {
        public Cliente Cliente {get;set;}
        public string Tema {get; set;}
        public DateTime DataDoAgendamento {get;set;}
        public string NumeroDePessoas {get;set;}
        public string TipoDoEvento {get;set;}
        public string Servicos {get;set;}
        public string Descricao {get;set;}

        public Evento(){
            this.Cliente = new Cliente();
        }
    }
}