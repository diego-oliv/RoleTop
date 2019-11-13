using System;

namespace project_RoleTopMVC.Models
{
    public class Agendamento
    {
        public Cliente Cliente {get; set;}
        public DateTime DataDoPedido {get; set;}
        public double PrecoTotal {get; set;}
    }
}