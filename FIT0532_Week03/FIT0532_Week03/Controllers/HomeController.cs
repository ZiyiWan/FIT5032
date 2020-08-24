using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT0532_Week03.HelloWorld;
using FIT0532_Week03.Exercise;

namespace FIT0532_Week03.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            Hello hello = new Hello();
            ViewBag.Message = hello.GetHello();

            Exercise.Student.ExampleDictionary ed = new Student.ExampleDictionary();
            ed.Example();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}