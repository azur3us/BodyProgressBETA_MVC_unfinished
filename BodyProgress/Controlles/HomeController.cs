﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BodyProgress.Controlles
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Cos";

            return View();
        }
    }
}