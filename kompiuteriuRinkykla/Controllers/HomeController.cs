using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kompiuteriuRinkykla.Models;

namespace kompiuteriuRinkykla.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AssembleComputer()
        {
            //ViewData["Message"] = "";

            return View();
        }

        public IActionResult ChooseComputerByPurpose()
        {
            //ViewData["Message"] = "";

            return View();
        }

        public IActionResult ViewAssembledComputers()
        {
            return View();
        }

        public IActionResult ViewPartsList()
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
