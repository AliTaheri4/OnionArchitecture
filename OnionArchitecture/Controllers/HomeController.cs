using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnionArchitecture.DataAccess.ViewModels.CustomLogViewModel;
using OnionArchitecture.Models;
using OnionArchitecture.Service.SqlClient;

namespace OnionArchitecture.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISqlClient _uow;
        public HomeController(ILogger<HomeController> logger, ISqlClient uow)
        {
            _logger = logger;
            _uow = uow;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _uow.CustomLogService.GetList());
        }

        public async Task<IActionResult> Delete(int id)
        {
            var log= await _uow.CustomLogService.GetById(id);
            return View(log);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _uow.CustomLogService.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {        
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomLogViewModel model)
        {
            await _uow.CustomLogService.Add(model);
            return RedirectToAction("Index");
        }
     


        public async Task<IActionResult> Edit(int id)
        {
            return View(await _uow.CustomLogService.GetById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( CustomLogViewModel model)
        {
            await _uow.CustomLogService.Update(model);
            return RedirectToAction("Index");
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Detail(int id)
        {
            return View(await _uow.CustomLogService.GetById(id));
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
