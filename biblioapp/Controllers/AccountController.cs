using biblioapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Security;
namespace biblioapp.Controllers
{
    public class AccountController : Controller
    {




        // GET: Account

        public ActionResult Index()
        {
            Session.Clear();
            return View();
        }
        public ActionResult Login(string returnUrl)
        {
            Session.Clear();
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Login model, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "livres");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "The username or password is incorrect");
                }

            }

            return View(model);
        }
        public ActionResult LogOff()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("login", "Account");
        }
        public ActionResult Register()
        {
            Session.Clear();
            return View();

        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MembershipUser NewUser = Membership.CreateUser(model.UserName, model.Password);
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("login", "Account");


                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("Registration Error", "Registration error: " + e.StatusCode.ToString());

                }

            }
            return View(model);

        }


    }
}