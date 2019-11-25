using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace project_RoleTopMVC.Controllers
{
    public class AbstractController : Controller
    {
        protected const string SESSION_CLIENTE_EMAIL = "email_cliente";
        protected const string SESSION_CLIENTE_NOME = "cliente_nome";

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
    }
}