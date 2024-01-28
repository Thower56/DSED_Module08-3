﻿using DSED_Module08_Exercice3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DSED_Module08_Exercice3.Controllers
{
    public class AppelController: Controller
    {
        private readonly ILogger<AppelController> _logger;

        public AppelController(ILogger<AppelController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
