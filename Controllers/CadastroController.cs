using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_RoleTopMVC.Models;
using project_RoleTopMVC.Respositories;
using project_RoleTopMVC.ViewModels;

namespace project_RoleTopMVC.Controllers
{
    public class CadastroController : AbstractController
    {
        ClienteRepository clienteRepository = new ClienteRepository();
        public IActionResult Index()
        {
            return View(new BaseViewModel(){
                NomeView = "Cadastro",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }
        public IActionResult CadastrarCliente(IFormCollection form)
        {
            ViewData["Action"] = "Cadastro";
            try{
                if(form["senha"] == form["confirmar-senha"]){
                    Cliente cliente = new Cliente(form["nome"], 
                    form["cep"], 
                    form["endereco"], 
                    form["telefone"], 
                    form["cpf/cnpj"], 
                    form["email"], 
                    form["senha"], 
                    form["complemento"]);
                    clienteRepository.Inserir(cliente);
                    return View("Sucesso", new RespostaViewModel("O cliente foi cadastrado com sucesso."));
                }
                return View("Falha", new RespostaViewModel("As senhas não são iguais."));

            } catch(Exception e) {
                System.Console.WriteLine(e.StackTrace);
                return View("Falha", new RespostaViewModel("O cadastro não pode ser concluído."));
            }
        }
    }
}