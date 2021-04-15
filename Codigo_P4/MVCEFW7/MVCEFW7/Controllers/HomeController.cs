using MVCEFW7.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEFW7.Controllers
{
    public class HomeController : Controller
    {

        private PeliculasRepository _peliculasRepository;

        public HomeController() {
            _peliculasRepository = new PeliculasRepository();
        }
        //public ActionResult Index()
        //{            
        //    return View();
        //}

        //public ContentResult Index()
        //{
        //    // parte #3 
        //    return Content("Felipe");
        //    //return View();
        //}

        //public ContentResult Index()
        //{
        //    // parte #3 
        //    return Content("<b>Felipe</b>");
        //    //return View();
        //}

        //public ActionResult Index()
        //{            
        //    return View();
        //}

        // #parte 4
        //public RedirectResult Index()
        //public RedirectToRouteResult Index()
        public ActionResult Index()
        {
            //4.1
            //return Redirect("http://google.com");
            //4.2
            //return RedirectToAction("Register","Account");
            //4.3
            //return RedirectToRoute("Persona");
            return View();
        }

        //public ViewResult Index()
        //public FileResult Index()
        //{
        //    return View();
        //}

        // 5.1
        public HttpStatusCodeResult About()
        {
            //return new HttpStatusCodeResult(401,"Holas 401");
            return new HttpStatusCodeResult(301, "Holas");
        }

        // public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}


        //  6 descargar un archivo
        //public FileResult Contact()
        //{
        //    var ruta = Server.MapPath("Arhivo.pdf");

        //    ViewBag.Message = "Your contact page.";
        //    return File(ruta, "application/pdf","nombre.pdf");
        //    //return View();
        //}

        //7- querystring
        //public ActionResult Contact(string nombre)
        //{
        //    ViewBag.Message = "Your contact page." + nombre ;

        //    return View();
        //}

        // 7.2
        //public ActionResult Contact(string nombre, int edad)
        //{
        //    ViewBag.Message = "Your contact page." + nombre + edad.ToString();

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        //8 GET y POST 
        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            //9- VIEW BAG VIEW DATA
            ViewBag.UnInt = 45;
            ViewBag.Fecha = DateTime.Today;

            ViewData["Some"] = "tintin";

            return View();
        }

        // 8.2
        [HttpPost]
        public ActionResult Contact(int edad)
        {
            ViewBag.Message = "Your contact page." + edad;
            return View();
        }


        public ActionResult MiAction(string edad)
        {
            ViewBag.Message = "Test from mi action.";
            return View();
        }

        public ActionResult MisPeliculas()
        {
            ViewBag.Message = "Test from mi action.";
            var model = _peliculasRepository.GetPeliculas();
            return View(model);
        }

        public ActionResult MiDisplayTemplate()
        {
            var Persona = new PersonaTemp { Nombre= "Fulanito",Edad =88 , Empleado = true, Nacimiento = DateTime.Today};
            //ViewBag.Propiedad = "Probando Informacion"; // Parte 1 de Display 
            ViewBag.Propiedad = Persona; // Parte 2 de Display 
            return View();
        }

        public ActionResult MiDropDownList()
        {
            ViewBag.listado = _peliculasRepository.GetData();
            return View();
        }
    }

    public class PersonaTemp
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public bool Empleado { get; set; }
        public DateTime Nacimiento { get; set; }
    }
}

