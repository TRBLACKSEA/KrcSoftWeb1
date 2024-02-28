using KrcSoftWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KrcSoftWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        AdminContext context = new AdminContext();
        [HttpGet]
        public ActionResult Index()
		{
            return View();
		}
        [HttpPost]
        public ActionResult Index(User user)
        {
            User loginUser = context.Users.Where(q => q.UserName == user.UserName && q.Password == user.Password).FirstOrDefault();
			if (loginUser != null)
			{
                if(loginUser.Kullanimdami)
				{
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    Session["UserName"] = loginUser.UserName;
                    AdminController.dm.user = loginUser;
                    ViewBag.LoginMessage = "";
                    return RedirectToAction("Index", "Admin");
				}
				else
				{
                    ViewBag.LoginMessage = "Kullanıcı Pasif Durumda Sisteme Giriş Yapamaz.";
                }
			}
			else{
                ViewBag.LoginMessage = "Kullanıcı Bulunamadı";
            }
            
            return View(loginUser);
        }
        public ActionResult LogOut()
		{
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
		}
    }
}