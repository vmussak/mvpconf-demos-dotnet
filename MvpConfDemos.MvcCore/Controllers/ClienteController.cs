using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var clientes = _db.Cliente.ToList().Take(10);
            //var clientes = _db.Cliente.Take(10);
            //var clientes = _db.Cliente.AsNoTracking().Take(10);
            //var clientes = _db.Cliente.Where(x => x.Nome == "Mussak");

            return Ok(clientes);
        }
    }
}
