using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_RoleTopMVC.Enums;

namespace project_RoleTopMVC.Controllers
{
    public class AbstractController : Controller
    {
        protected const string SESSION_CLIENTE_EMAIL = "email_cliente";
        protected const string SESSION_CLIENTE_NOME = "cliente_nome";
        protected const string SESSION_TIPO_USUARIO = "tipo_usuario";

        protected string ObterUsuarioSession(){
            var email = HttpContext.Session.GetString(SESSION_CLIENTE_EMAIL);
            if(!string.IsNullOrEmpty(email)) {
                return email;
            } else {
                return "";
            }
        }

        protected string ObterUsuarioNomeSession(){
            var nome = HttpContext.Session.GetString(SESSION_CLIENTE_NOME);
            if(!string.IsNullOrEmpty(nome)){
                return nome;
            } else{
                return "";
            }
        }

        protected string ObterUsuarioTipoSession(){
            var tipoUsuario = HttpContext.Session.GetString(SESSION_TIPO_USUARIO);
            if(!string.IsNullOrEmpty(tipoUsuario)){
                return tipoUsuario;
            } else{
                return "";
            }
        }
    }
}