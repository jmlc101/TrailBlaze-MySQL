using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
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
        private string formattedPhoneNumber;

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

            ViewBag.DbSubmissionAlert = TempData["Alert"];

            return View();
        }

        public ActionResult Profile(string screenname)
        {
            if (HttpContext.Session.GetString("_Email") is null) // TODO - Is there a better way to filter this?
            {
                return Redirect("/User/LogOn");
            }
            User profilesUser = context.Users.Single(u => u.ScreenName == screenname);

            ViewBag.ProfileUserScreenName = profilesUser.ScreenName;
            return View();
        }

        public ActionResult DisplayFavorites()
        {
            var email = HttpContext.Session.GetString("_Email");
            User getUser = context.Users.Single(u => u.Email == email);
            if (getUser == null)
            {

            }
            else
            {
                IList<UserRoute> existingFavoriteRelationships = context.UserRoutes
                    .Where(ur => ur.UserID == getUser.ID).ToList();
                List<string> routeNames = new List<string>();
                List<Route> routes = new List<Route>();
                foreach (UserRoute userRoute in existingFavoriteRelationships)
                {
                    int routeID = userRoute.RouteID;
                    Route route = context.Routes.Single(r => r.ID == routeID);
                    routes.Add(route);
                    string routeName = route.RouteName;
                    routeNames.Add(routeName);

                }
                // ViewBag.Favorites = routeNames;
                ViewBag.FavoriteRoutes = routes;
                ViewBag.Favorites = existingFavoriteRelationships;
                ViewBag.SessionScreenName = HttpContext.Session.GetString("_ScreenName");

                TempData["Alert"] = TempData["Alert"];
                ViewBag.DbSubmissionAlert = TempData["Alert"];
                

                return View("Index");
            }

            return Redirect("/User");
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost] // TODO - Need Better validation on all entry Fields!!.
        public IActionResult Register(RegisterUserViewModel registerUserViewModel)
        {

            if (ModelState.IsValid)
            {
                int errorCount = 0;

                //Check if "password" and "confirm password" match:
                if (registerUserViewModel.Password != registerUserViewModel.ConfirmPassword)
                {
                    errorCount++;
                    ViewBag.PasswordMatchError = "Passwords do not match";
                }

                // Check if Email is already used in DB.
                IList<User> usersMatchingEmail = context.Users
                    .Where(u => u.Email == registerUserViewModel.Email)
                    .ToList();
                if (usersMatchingEmail.Count > 0)
                {
                    ViewBag.EmailInUse = "Email is already in use.";
                    errorCount++;
                }
                // Check if Screen Name is already used in DB.
                IList<User> usersMatchingScreenName = context.Users
                    .Where(u => u.ScreenName == registerUserViewModel.ScreenName)
                    .ToList();
                if (usersMatchingScreenName.Count > 0)
                {
                    ViewBag.ScreenNameInUse = "Screen Name is already in use.";
                    errorCount++;
                }


                //// stackoverflow.com/questions/5342375/regex-email-validation
                try
                {
                    MailAddress m = new MailAddress(registerUserViewModel.Email);
                }
                catch (FormatException)
                {
                    ViewBag.EmailError = "Invalid Email address.";
                    errorCount++;
                    //return View(registerUserViewModel);
                }
                ////

                if ( registerUserViewModel.PhoneNumber != null)
                {

                    ////www.safaribooksonline.com/library/view/regular-expressions-cookbook/9781449327453/ch04s02.html
                    Regex phoneRegex = new Regex(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");

                    if (phoneRegex.IsMatch(registerUserViewModel.PhoneNumber))
                    {
                        formattedPhoneNumber = phoneRegex.Replace(registerUserViewModel.PhoneNumber, "($1) $2-$3");
                    }
                    else
                    {
                        // TODO - Invalid phone number ViewBag.error
                        errorCount++;
                        ViewBag.PhoneNumberError = "Invalid Phone Number";
                        //return View(registerUserViewModel);
                    }
                    ////
                }

                if (errorCount > 0)
                {
                    return View(registerUserViewModel);
                }

                var newSalt = HashHelp.GeneratePassword(10);
                var passwordHash = HashHelp.EncodePassword(registerUserViewModel.Password, newSalt);
                User newUser = new User
                {
                    ScreenName = registerUserViewModel.ScreenName,
                    Email = registerUserViewModel.Email,
                    PasswordHash = passwordHash,
                    HashCode = newSalt,
                    CreationTime = DateTime.Now,
                    ModificationTime = DateTime.Now,
                    PhoneNumber = formattedPhoneNumber
                };// TODO - Why would I need to "Clear a ModelState"?
                context.Users.Add(newUser);
                context.SaveChanges();
                HttpContext.Session.Clear();
                HttpContext.Session.SetString("_Email", registerUserViewModel.Email); // TODO - added as per session guide.
                HttpContext.Session.SetString("_ScreenName", registerUserViewModel.ScreenName);
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
                string password = logOnViewModel.Password;
                // TODO - if (chkUser == null) {} ....
                //var getUser = (from s in context.ObjRegisterUser where s.UserName == userName || s.EmailId == userName select s).FirstOrDefault(); (((( Just an example for ideas that I copied))
                var getUser = (from s in context.Users where s.Email == email || s.PasswordHash == email select s).FirstOrDefault();
                if (getUser != null)
                {
                    var hashCode = getUser.HashCode;
                    //Password Hasing Process Call Helper Class Method    
                    var encodingPasswordString = HashHelp.EncodePassword(password, hashCode);
                    //Check Login Detail User Name Or Password    
                    var query = (from s in context.Users where (s.Email == email || s.PasswordHash == email) && s.PasswordHash.Equals(encodingPasswordString) select s).FirstOrDefault();
                    if (query != null)
                    {
                        string screenName = getUser.ScreenName;
                        HttpContext.Session.Clear();
                        HttpContext.Session.SetString("_Email", email); // TODO - added as per session guide.
                        HttpContext.Session.SetString("_ScreenName", screenName);
                        return Redirect("/Welcome");
                    }
                    ViewBag.ErrorMessage = "Invalid User Name and/or Password ";
                    return View();
                }
                ViewBag.ErrorMessage = "Invalid User Name and/or Password ";
                return View();
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

        /*
        public IActionResult SendMessage(string profileUserScreenName)
        {
            User recievingUser = context.Users.Single(u => u.ScreenName == profileUserScreenName);
            string sendingUsersEmail = HttpContext.Session.GetString("_Email");
            User sendingUser = context.Users.Single(u => u.Email == sendingUsersEmail);
            ViewBag.SendMessge = "Send Message";
            ViewBag.SendersID = sendingUser.ID;
            ViewBag.RecieversID = recievingUser.ID;
            return View();
        }
        */
        [HttpPost]
        public IActionResult SendMessage(SendMessageViewModel sendMessageViewModel)
        {
            if (sendMessageViewModel.ProfileUserScreenName != null)
            {
                User recievingUser = context.Users.Single(u => u.ScreenName == sendMessageViewModel.ProfileUserScreenName);
                string sendingUsersEmail = HttpContext.Session.GetString("_Email");
                User sendingUser = context.Users.Single(u => u.Email == sendingUsersEmail);
                ViewBag.SendMessge = "Send Message";
                ViewBag.SendersID = sendingUser.ID;
                ViewBag.RecieversID = recievingUser.ID;
                return View();
            }

            if (sendMessageViewModel.Body != null)
            { 
            Message newMessage = new Message
            {

                CreationTime = DateTime.Now,
                Body = sendMessageViewModel.Body,
                ReceiverID = sendMessageViewModel.RecieversID,
                SendersID = sendMessageViewModel.SendersID
            };

            context.Messages.Add(newMessage);
            context.SaveChanges();
            }
            
            return View("/User/Profile/sendMessageViewModel.RecieversID");
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