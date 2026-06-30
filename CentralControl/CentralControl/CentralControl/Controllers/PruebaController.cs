using CentralControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CentralControl.Controllers
{
    public class PruebaController : Controller
    {
        SerialControl serial { get; set; }

        public PruebaController()
        {
            serial = new SerialControl("COM8");
        }
        // GET: Prueba
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string op)
        {
            if (!string.IsNullOrEmpty(op))
            {
                try
                {
                    serial.Open();
                    serial.Write(op);
                    serial.Close();
                }
                catch (Exception)
                {

                }
            }
            return View();
        }
    }
}