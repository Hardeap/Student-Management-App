using Student_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Student_Management.Controllers
{
    public class LoginController : Controller
    {
        StudentEntities db = new StudentEntities(); 
        // GET: Login
        public ActionResult Index( )
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User objchk)
        {
            if(ModelState.IsValid)
            {
                using(StudentEntities db = new StudentEntities())
                {
                    var obj = db.Users.Where(a => a.UserName.Equals(objchk.UserName) && a.Password.Equals(objchk.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserId"] = obj.Id.ToString();
                        Session["UserName"] = obj.Id.ToString();
                        return RedirectToAction("Index", "Home");
                    }

                    else
                    {
                        ModelState.AddModelError("", "The Username or password is incorrect");
                    }
                }
            }
           /* var obj = db.Users.Where(a => a.UserName.Equals(objchk.UserName) && a.Password.Equals(objchk.Password)).FirstOrDefault();
            if(obj != null)
            {
                Session["UserId"] = obj.Id.ToString();
                Session["UserName"] = obj.Id.ToString();
                return RedirectToAction("Index", "Home");
            }

            else
            {

            }*/
            return View(objchk);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}