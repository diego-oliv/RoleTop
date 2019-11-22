using System;

namespace project_RoleTopMVC.Models
{
    public class Cliente
    {
        public string Nome {get; set;}
        public string CEP {get; set;}
        public string Endereco {get; set;}
        public string Complemento {get; set;}
        public string Telefone {get; set;}
        public string CpfCnpj {get; set;}
        public string Email {get; set;}
        public string Senha {get; set;}
        public Cliente()
        {
        }
        public Cliente(string Nome, string CEP, string Endereco, string Telefone, string CpfCnpj, string Email, string Senha, string Complemento)
        {
            this.Nome = Nome;
            this.CEP = CEP;
            this.Endereco = Endereco;
            this.Telefone = Telefone;
            this.CpfCnpj = CpfCnpj;
            this.Email = Email;
            this.Senha = Senha;
            this.Complemento = Complemento;
        }
    }
}