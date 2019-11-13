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

        public Cliente(string nome, string cep, string endereco, string telefone, string cpfcnpj, string email, string senha, string complemento)
        {
            this.Nome = nome;
            this.CEP = cep;
            this.Endereco = endereco;
            this.Telefone = telefone;
            this.CpfCnpj = cpfcnpj;
            this.Email = email;
            this.Senha = senha;
            this.Complemento = complemento;
        }
    }
}