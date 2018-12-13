﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class WelcomeController : Controller
    {
        /* TODO - Check out this warning when running app.
        warn: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager[35]
      No XML encryptor configured. Key {0e25f93a-564f-491c-98d7-6a2fe6ed032d} may be persisted to storage in unencrypted form.
        */
        // TODO - update asp.net core version in dependencies? (.csproj)

        // GET: Welcome
        public ActionResult Index()
        {
            // TODO - https://stackoverflow.com/questions/28664686/how-do-i-get-client-ip-address-in-asp-net-core
            // TODO - This doesn't actually appear to return an Ip Address yet. Will have to fiddle with when it's deployed?
            System.Net.IPAddress ipAddress = Request.HttpContext.Connection.RemoteIpAddress;

            if (HttpContext.Session.GetString("_Email") is null) // TODO - Is there a better way to filter this?
            {
                // TODO - if no cookie for user session, insert "Member" and "Become A Member" links.
                ViewBag.Member = "hiddentest?";
                return View();
            }
            // TODO - Have ViewModel insert "User Home" and "LogOut" links if cookie for user session is detected.

            ViewBag.UserScreenName = HttpContext.Session.GetString("_ScreenName");
            return View();
        }
        // TODO - ELIMINATE BAD PATHS BELOW!!!
        // TODO - try rewriting to use the functions given below.
        // GET: Welcome/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Welcome/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Welcome/Create
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

        // GET: Welcome/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Welcome/Edit/5
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

        // GET: Welcome/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Welcome/Delete/5
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