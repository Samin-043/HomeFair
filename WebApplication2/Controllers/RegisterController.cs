using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class RegisterController : Controller
    {
        private abcEntities3 db = new abcEntities3();
        public ActionResult Regsiter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Regsiter(Register t)
        {
            if (ModelState.IsValid == true)
            {
                Register u = new Register();
                u.Usesname = t.Usesname;
                u.Email = t.Email;
                u.Password = t.Password;
                u.Phone = t.Phone;
                db.Registers.Add(u);
                db.SaveChanges();

                TempData["msg"] = "Data has been Inserted";
            }
            else
            {
                TempData["msg"] = "Data hasn't been Inserted";
            }

            return View();
        }


    }
}