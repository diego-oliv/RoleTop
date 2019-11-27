using System;
using System.IO;
using project_RoleTopMVC.Models;
using System.Collections.Generic;

namespace project_RoleTopMVC.Respositories
{
    public class AgendamentoRepository : RepositoryBase
    {
        private const string PATH = "Database/Evento.csv";
        public AgendamentoRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }
        
        public bool Inserir(Agendamento agendamento){
            var linha = new string[] {PrepararRegistroCSV(agendamento)};
            File.AppendAllLines(PATH, linha);
            return true;
        }
        public List<Agendamento> ObterTodos()
        {
            var linhas = File.ReadAllLines(PATH);
            List<Agendamento> agendamentos = new List<Agendamento>();
            foreach(var linha in linhas)
            {
                Agendamento agendamento = new Agendamento();
                agendamento.Cliente.Nome = ExtrairValorDoCampo("cliente_nome", linha);
                agendamento.Cliente.CpfCnpj = ExtrairValorDoCampo ("cliente_cpfcnpj", linha);
                agendamento.Cliente.Telefone = ExtrairValorDoCampo("cliente_telefone", linha);
                agendamento.Cliente.Email = ExtrairValorDoCampo("cliente_email", linha);
                agendamento.Evento.Tema = ExtrairValorDoCampo("evento_tema", linha);
                agendamento.Evento.DataDoAgendamento = ExtrairValorDoCampo("evento_data", linha);
                agendamento.Evento.NumeroDePessoas = ExtrairValorDoCampo("evento_quantidadePessoas", linha);
                agendamento.Evento.TipoDoEvento = ExtrairValorDoCampo("evento_tipo", linha);
                agendamento.Evento.Servicos = ExtrairValorDoCampo("evento_servicos", linha);
                agendamento.Evento.Descricao = ExtrairValorDoCampo("evento_descricao", linha);
                agendamentos.Add(agendamento);
            }
            return agendamentos;
        }

        public List<Agendamento> ObterTodosPorCliente(string email)
        {
            var agendamentosTotais = ObterTodos();
            List<Agendamento> agendamentosCliente = new List<Agendamento>();
            foreach(var agendamento in agendamentosTotais)
            {
                if(agendamento.Cliente.Email.Equals(email)){
                    agendamentosCliente.Add(agendamento);
                }
            }
                return agendamentosCliente;
        }

        private string PrepararRegistroCSV(Agendamento agendamento)
        {
            Cliente cliente = agendamento.Cliente;
            Evento evento = agendamento.Evento;

            return $"cliente_nome={agendamento.Evento.Cliente.Nome};cliente_cpfcnpj={agendamento.Evento.Cliente.CpfCnpj};cliente_telefone={agendamento.Evento.Cliente.Telefone};cliente_email={cliente.Email};evento_tema={evento.Tema};evento_data={evento.DataDoAgendamento};evento_quantidadePessoas={evento.NumeroDePessoas};evento_tipo={evento.TipoDoEvento};evento_servicos={evento.Servicos};evento_descricao={evento.Descricao}";
        }
    }
}