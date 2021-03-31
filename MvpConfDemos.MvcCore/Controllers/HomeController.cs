using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using MvpConfDemos.MvcCore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvpConfDemos.MvcCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMemoryCache _cache;

        public HomeController(ILogger<HomeController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public IActionResult Index()
        {
            //Verifica se existe ou não valor em um cache chamado "DataAtual"
            if (!_cache.TryGetValue("DataAtual", out DateTime dataAtual))
            {
                //Caso não exista, colocamos a data atual
                dataAtual = DateTime.Now;

                //Aqui configuramos as opções do cache
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromSeconds(10)); //Tempo de expiração do cache

                //Salvando :)
                _cache.Set("DataAtual", dataAtual, cacheEntryOptions);
            }

            ViewBag.DataAtual = dataAtual;

            return View();
        }

        public IActionResult GetOrCreateCache()
        {
            var dataAtual = _cache.GetOrCreate("DataAtual", dataCache =>
            {
                dataCache.SetSlidingExpiration(TimeSpan.FromSeconds(10));
                dataCache.SetPriority(CacheItemPriority.NeverRemove);
                return DateTime.Now;
            });

            ViewBag.DataAtual = dataAtual;

            return View();
        }

        public IActionResult RemoverCache()
        {
            _cache.Remove("DataAtual");
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
