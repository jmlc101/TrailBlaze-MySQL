using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class WelcomeController : Controller
    {
        // GET: Welcome
        public ActionResult Index()
        {
            string c00kie = "true";
            if (c00kie == "true")
                {
                // TODO - Have ViewModel insert "User Home" and "LogOut" links if cookie for user session is detected.
                return View();
            }
            else
            {
                // TODO - if no cookie for user session, insert "Member" and "Become A Member" links.
                return View();
            }
        }
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