using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using DictionaryProject.Helpers;
using DictionaryProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DictionaryProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IRepositoryWords _wordRepository;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _wordRepository = RepositoryFactory.CreateRepo("WORD");
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Words> liste = _wordRepository.List();
            
            return View(liste);
            
        }
        [HttpGet]
        public IActionResult CreateWord(int? id)
        {
            Words model = new Words();
            if (id.HasValue && id > 0)
            {
                List<Words> word = _wordRepository.List();
                model = word.First(c => c.Id == id);
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateWord(Words words)
        {
            _wordRepository.AddOrUpdate(words);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _wordRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy(KelimeTest kelime)
        {


            return View(kelime);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
