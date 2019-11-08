using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoleTop.Models;

namespace RoleTop.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}