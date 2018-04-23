﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private JMCapstoneDbContext context;
        public UserController(JMCapstoneDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: User
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("_Email") is null) // TODO - Is there a better way to filter this?
            {
                return Redirect("/Welcome");
            }
            ViewBag.SessionEmail = HttpContext.Session.GetString("_Email");
            ViewBag.SessionScreenName = HttpContext.Session.GetString("_ScreenName");
            ViewBag.answer = "yes";
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost] // TODO - password validation.
        public IActionResult Register(RegisterUserViewModel registerUserViewModel)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    ScreenName = registerUserViewModel.ScreenName,
                    Email = registerUserViewModel.Email,
                    Password = registerUserViewModel.Password,
                    PhoneNumber = registerUserViewModel.PhoneNumber
                };
                context.Users.Add(newUser);
                context.SaveChanges();
                return Redirect("/User");
            }
            return View(registerUserViewModel);
        }

        public IActionResult Remove()
        {
            if (HttpContext.Session.GetString("_Email") is null) // TODO - Is there a better way to filter this?
            {
                return Redirect("/Welcome");
            }
            return View();
        }

        public IActionResult LogOn()
        {
            return View();
        }
        [HttpPost] // TODO - is this password validation location?
        public IActionResult LogOn(LogOnViewModel logOnViewModel)
        {
            if (ModelState.IsValid)
            {
                string email = logOnViewModel.Email;
                try
                {
                    User user = context.Users.First(u => u.Email == email);
                    string screenName = user.ScreenName;
                    HttpContext.Session.SetString("_Email", email); // TODO - added as per session guide.
                    HttpContext.Session.SetString("_ScreenName", screenName);
                    return Redirect("/Welcome");
                }
                catch (InvalidOperationException)
                {
                    ViewBag.Error = "Not a Valid User. Please try another, or ";
                    ViewBag.RegisterLink = "Register Here.";
                    return View(); // TODO - pass threw message that user was invalid?
                }  
            }
            return View(logOnViewModel);
        }

        public IActionResult LogOff()
        {
            if (HttpContext.Session.GetString("_Email") is null) // TODO - Is there a better way to filter this?
            {
                return Redirect("/Welcome");
            }
            HttpContext.Session.Clear();
            // TODO - Need a before action handler that checks if user's logged on.
            return Redirect("/User");
        }
        // TODO - ELIMINATE BAD PATHWAYS BELOW!!!
        // TODO - try rewriting to use the functions given below.
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}