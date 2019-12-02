using System;
using System.IO;
using project_RoleTopMVC.Models;
using System.Collections.Generic;
using project_RoleTopMVC.Enums;

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
            var quantidadeLinhas = File.ReadAllLines(PATH).Length;
            agendamento.Evento.Id = (uint) ++quantidadeLinhas;
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
                agendamento.Evento.Id = uint.Parse(ExtrairValorDoCampo("id", linha));
                agendamento.Evento.Status = uint.Parse(ExtrairValorDoCampo("status_pedido", linha));
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

        public void AtualizarEstado(uint id,string NovoEstado){
            //TODO PEGA O AGENDAMENTO
            Agendamento agendamento = ObterPor(id);
            int linha = 0;

            //TODO MUDA O ESTADO DO AGENDAMENTO
            if(NovoEstado == "Aprovar"){
                agendamento.Evento.Status = (uint) StatusPedido.APROVADO;
            }else if(NovoEstado == "Reprovar")
            {
                agendamento.Evento.Status = (uint) StatusPedido.REPROVADO;
            }
            
            //Inserir(agendamento);

            //TODO PEGA A LINHA DO AGENDAMENTO
            var agendamentosTotais = ObterTodos();
            for(int i=0; i < agendamentosTotais.Count; i++)
            {
                if(agendamentosTotais[i].Evento.Id == id)
                {
                    linha = i;
                    break;
                }
            }
            //TODO PEGA TODO O ARQUIVO
            var linhas = File.ReadAllLines(PATH);
            
            //TODO PEGA APENAS A LINHA QUE EU QUERO MUDAR E PREPARA UM REGISTRO CSV
            linhas[linha] = PrepararRegistroCSV(agendamento);

            //TODO MANDA DE VOLTA TODAS AS MUDANÇAS PRO CSV
            File.WriteAllLines(PATH,linhas);

        }

        public bool Atualizar(Agendamento agendamento)
        {
            var agendamentosTotais = File.ReadAllLines(PATH);
            var agendamentoCSV = PrepararRegistroCSV(agendamento);
            var linhaAgendamento = -1;
            var resultado = false;
            var id = agendamento.Evento.Id;
            for(int i = 0 ; i < agendamentosTotais.Length ; i++)
            {
                var idConvertido = uint.Parse((ExtrairValorDoCampo("id", agendamentosTotais[i])));
                if(id.Equals(idConvertido))
                {
                    linhaAgendamento = i;
                    resultado = true;
                    break;
                }
            }
            if(!resultado)
            {
                agendamentosTotais[linhaAgendamento] = agendamentoCSV;
                File.WriteAllLines(PATH, agendamentosTotais);
            }
            return resultado;
        }

        private string PrepararRegistroCSV(Agendamento agendamento)
        {
            Cliente cliente = agendamento.Cliente;
            Evento evento = agendamento.Evento;

            return $"id={evento.Id};status_pedido={evento.Status};cliente_nome={cliente.Nome};cliente_cpfcnpj={cliente.CpfCnpj};cliente_telefone={cliente.Telefone};cliente_email={cliente.Email};evento_tema={evento.Tema};evento_data={evento.DataDoAgendamento};evento_quantidadePessoas={evento.NumeroDePessoas};evento_tipo={evento.TipoDoEvento};evento_servicos={evento.Servicos};evento_descricao={evento.Descricao}";
        }

        public Agendamento ObterPor(uint id)
        {
            var agendamentosTotais = ObterTodos();
            foreach(var agendamento in agendamentosTotais)
            {
                if(agendamento.Evento.Id == id)
                {
                    return agendamento;
                }
            }
            return null;
        }
    }
}