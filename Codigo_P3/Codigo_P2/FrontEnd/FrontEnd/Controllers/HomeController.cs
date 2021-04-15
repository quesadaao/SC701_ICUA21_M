using FrontEnd.DAL;
using FrontEnd.Models;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private PeliculasRepository _peliculasRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _peliculasRepository = new PeliculasRepository();
        }

        //public IActionResult Index()
        //{
        //    //#1 Envio de informacion entre controller y vistas 
        //    ViewBag.Aux = Common.Helper.GetNombre();
        //    ViewData["Auxin"] = "Fabian Oconitrillo";

        //    //--------------------------------------------------
        //    return View();
        //}

        //// Index parte #2 // 
        //public IActionResult Index()
        //{
        //    return Content("Felipe");
        //}

        // Index parte #3 // 
        //public IActionResult Index()
        //{
        //    return Content("<b>Felipe</b>");
        //}

        //Index parte #4// formas de redireccionamiento 
        //public IActionResult Index()
        //{
        //    //4.1 redirect to external links  
        //    //return Redirect("http://google.com");

        //    //4.2 redirect to specific action in controllers
        //    return RedirectToAction("Index", "Customers");

        //    return Content("<b>Felipe</b>");
        //}

        //Index parte #5// impresion de status codes 
        //public HttpStatusCodeResult Index()
        //{
        //    return new HttpStatusCodeResult(401, statusDescription: "Holas 401");
        //}

        //QueryStrings
        public IActionResult Index(string nombre, int? edad)
        {
            ViewBag.Aux = Common.Helper.GetNombre();
            ViewData["Auxin"] = "Fabian Oconitrillo " + nombre + " "+ edad;
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
