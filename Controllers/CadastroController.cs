using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_RoleTopMVC.Models;
using project_RoleTopMVC.Respositories;

namespace project_RoleTopMVC.Controllers
{
    public class CadastroController : Controller
    {
        ClienteRepository clienteRepository = new ClienteRepository();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CadastrarCliente(IFormCollection form)
        {
            ViewData["Action"] = "Cadastro";
            try{
                Cliente cliente = new Cliente(form["nome"], 
                form["cep"], 
                form["endereco"], 
                form["telefone"], 
                form["cpf/cnpj"], 
                form["email"], 
                form["senha"], 
                form["complemento"]);
                clienteRepository.Inserir(cliente);
                    return View("Sucesso");
            } catch(Exception e) {
                System.Console.WriteLine(e.StackTrace);
                return View("Falha");
            }
        }
    }
}