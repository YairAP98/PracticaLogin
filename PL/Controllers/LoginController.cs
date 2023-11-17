using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.Negocio negocio)
        {
            Models.Negocio negocio1 = Models.Negocio.Login(negocio);


            if (negocio1.Username == negocio.Username)
            {
                if (negocio.Password == negocio1.Password)
                {
                    return RedirectToAction("Index", "Home");
                }
            }




            return View();
        }
    }
}