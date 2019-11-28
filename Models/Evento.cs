using System;
using project_RoleTopMVC.Enums;

namespace project_RoleTopMVC.Models
{
    public class Evento
    {
        public uint Id {get;set;}
        public Cliente Cliente {get;set;}
        public string Tema {get; set;}
        public string DataDoAgendamento {get;set;}
        public string NumeroDePessoas {get;set;}
        public string TipoDoEvento {get;set;}
        public string Servicos {get;set;}
        public string Descricao {get;set;}
        public ushort Status {get;set;}

        public Evento(){
            //this.Cliente = new Cliente();
        }
        public Evento (string tema, string data, string quantidade, string tipo, string servicos, string descricao){
            this.Tema = tema;
            this.DataDoAgendamento = data;
            this.NumeroDePessoas = quantidade;
            this.TipoDoEvento = tipo;
            this.Servicos = servicos;
            this.Descricao = descricao;
            this.Cliente = new Cliente();
            this.Id = 0;
            this.Status = (ushort) StatusPedido.PEDENTE;
        }
    }
}