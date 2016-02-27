using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PushNotifictionTest.Models;

namespace PushNotifictionTest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(MyIndexModel model)
        {

            AndroidGCMPushNotification apnGCM = new AndroidGCMPushNotification();
            foreach (var zaDevice in MvcApplication.zaDevices)
            {
                string strResponse =
                apnGCM.SendNotification(zaDevice,model);
            }



            ViewBag.success = true;
            return View(model);
        }


        public ActionResult RegisterDevice(string id)
        {
            if (!MvcApplication.zaDevices.Any(x => x.Equals(id)))
            {
                MvcApplication.zaDevices.Add(id);
            }
            return Content("Hi there!");
        }
    }
}