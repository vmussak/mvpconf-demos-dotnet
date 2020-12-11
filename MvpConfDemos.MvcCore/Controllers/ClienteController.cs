using Microsoft.AspNetCore.Mvc;
using MvpConfDemos.MvcCore.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvpConfDemos.MvcCore.Controllers
{
    public class ClienteController : Controller
    {
        private MvpConfContext _db;
        public ClienteController(MvpConfContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //var clientes = _db.ClienteMvp.ToList().Take(10);
            var clientes = _db.ClienteMvp.Take(10);

            return Ok(clientes);
        }

        public IActionResult GetByName(string nome)
        {
            var clientes = _db.ClienteMvp.Where(x => x.Nome == nome);

            return Ok(clientes);
        }
    }
}
