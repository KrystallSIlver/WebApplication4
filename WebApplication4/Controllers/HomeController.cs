﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication4.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Controllers;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/TodoViewModels/Index");
        }

        public IActionResult About()
        {
            return Redirect("/CategoryViewModels/Index");
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Miroslav Yaroschuk";

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
