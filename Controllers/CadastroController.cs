using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_RoleTopMVC.Models;
using RoleTop.Models;

namespace project_RoleTopMVC.Controllers
{
    public class CadastroController : Controller
    {
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
                form["senha"]);
                    return View("Sucesso");
            } catch(Exception e) {
                System.Console.WriteLine(e.StackTrace);
                return View("Falha");
            }
        }
    }
}