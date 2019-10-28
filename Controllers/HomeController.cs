using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using dojodachi.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace dojodachi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("dojodachi")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetObjectFromJson<Dojodachi>("Pet") == null){
                Dojodachi pet = new Dojodachi();
                HttpContext.Session.SetObjectAsJson("Pet", pet);
            }
            ViewBag.Message = TempData["Message"];
            ViewBag.End = TempData["End"];
            return View(HttpContext.Session.GetObjectFromJson<Dojodachi>("Pet"));
        }

        [HttpGet("/feed")]
        public IActionResult Feed()
        {
            Dojodachi pet = HttpContext.Session.GetObjectFromJson<Dojodachi>("Pet");
            TempData["Message"] = pet.Feed();
            TempData["End"] = pet.Check();
            HttpContext.Session.SetObjectAsJson("Pet", pet);
            return RedirectToAction("Index");
        }

        [HttpGet("/play")]
        public IActionResult Play()
        {
            Dojodachi pet = HttpContext.Session.GetObjectFromJson<Dojodachi>("Pet");
            TempData["Message"] = pet.Play();
            TempData["End"] = pet.Check();
            HttpContext.Session.SetObjectAsJson("Pet", pet);
            return RedirectToAction("Index");
        }

        [HttpGet("/work")]
        public IActionResult Work()
        {
            Dojodachi pet = HttpContext.Session.GetObjectFromJson<Dojodachi>("Pet");
            TempData["Message"] = pet.Work();
            HttpContext.Session.SetObjectAsJson("Pet", pet);
            return RedirectToAction("Index");
        }

        [HttpGet("/sleep")]
        public IActionResult Sleep()
        {
            Dojodachi pet = HttpContext.Session.GetObjectFromJson<Dojodachi>("Pet");
            TempData["Message"] = pet.Sleep();
            TempData["End"] = pet.Check();
            HttpContext.Session.SetObjectAsJson("Pet", pet);
            return RedirectToAction("Index");
        }
        [HttpGet("/restart")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
