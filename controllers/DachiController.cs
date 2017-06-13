using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
 
namespace dachi.Controllers
{
    public class DachiController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            Dachi retrieve = HttpContext.Session.GetObjectFromJson<Dachi>("dachi");
            if(retrieve == null){
                TempData["result"]="";
                Dachi dachi = new Dachi();
                HttpContext.Session.SetObjectAsJson("dachi", dachi);
                retrieve = dachi;
            }
            ViewBag.result = TempData["result"];
            ViewBag.status = TempData["status"];

            ViewBag.fullness = retrieve.fullness;
            if(retrieve.fullness < 1){ViewBag.fstatus = "red";}
            else{ViewBag.fstatus = "green";}

            ViewBag.happiness = retrieve.happiness;
            if(retrieve.happiness < 1){ViewBag.hstatus = "red";}
            else{ViewBag.hstatus = "green";}

            ViewBag.meals = retrieve.meals;
            if(retrieve.meals < 1){ViewBag.mstatus = "red";}
            else{ViewBag.mstatus = "green";}

            ViewBag.energy = retrieve.energy;
            if(retrieve.energy < 1){ViewBag.estatus = "red";}
            else{ViewBag.estatus = "green";}
            
            return View();
        }

        [HttpGet]
        [Route("action/{option}")]
        public IActionResult Action(int option){
            Dachi retrieve = HttpContext.Session.GetObjectFromJson<Dachi>("dachi");
            string[] result;
            switch(option)
            {
                case 1:
                    result = retrieve.Feed();
                    TempData["result"]=result[0];
                    TempData["status"]=result[1];
                    break;
                case 2:
                    result = retrieve.Play();
                    TempData["result"]=result[0];
                    TempData["status"]=result[1];
                    break;
                case 3:
                    result = retrieve.Work();
                    TempData["result"]=result[0];
                    TempData["status"]=result[1];
                    break;
                case 4:
                    result = retrieve.Sleep();
                    TempData["result"]=result[0];
                    TempData["status"]=result[1];
                    break;
                case 5:
                    result = retrieve.Reset();
                    TempData["result"]=result[0];
                    TempData["status"]=result[1];
                    break;
                default:
                    break;
            }
            HttpContext.Session.SetObjectAsJson("dachi", retrieve);
            return RedirectToAction("Index");
        }
    }
}