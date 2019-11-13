using System.IO;
using project_RoleTopMVC.Models;

namespace project_RoleTopMVC.Respositories
{
    public class ClienteRepository
    {
        private const string PATH = "Database/Cliente.csv";
        public ClienteRepository()
        {
            if (!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }
        public bool Inserir(Cliente cliente)
        {
            var dadosCliente = new string[] {PrepararRegistroCSV(cliente)};
            File.AppendAllLines(PATH , dadosCliente);
            return true;
        }
        private string PrepararRegistroCSV(Cliente cliente)
        {
            return $"nome={cliente.Nome};email={cliente.Email};senha={cliente.Senha};telefone={cliente.Telefone};endereco={cliente.Endereco}; cep={cliente.CEP};cpfcnpj={cliente.CpfCnpj};complemento={cliente.Complemento}";
        }
    }
}