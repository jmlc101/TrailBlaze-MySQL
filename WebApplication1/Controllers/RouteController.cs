using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class RouteController : Controller
    {
        // TODO - keep track of hosting environment and its importance!
        private Secrets _secrets { get; }

        private JMCapstoneDbContext context;
        public RouteController(JMCapstoneDbContext dbContext, IOptions<Secrets> secrets)
        {
            context = dbContext;
            this._secrets = secrets.Value;
        }

        // GET: Route
        public ActionResult Index()
        {
            List<Route> routes = new List<Route>();
            ViewBag.Routes = context.Routes.ToList<Route>();
            ViewBag.UserScreenName = HttpContext.Session.GetString("_ScreenName");
            return View();
        }

        public ActionResult SubmitSearchFilters()// TODO - user can submit search parameters for User/Index.cshtml
        {
            return View();
        }

        public ActionResult SaveRoute()
        {
            ViewBag.SaveRoute = 1;
            ViewBag.UserScreenName = HttpContext.Session.GetString("_ScreenName");
            return View();
        }
        // TODO - Make sure User is Logged in in order to save a route! Must check session! 
        // TODO - Make sure User gets to confirm route map before submitting it to database!
        [HttpPost]
        public ActionResult SaveRoute(SaveRouteViewModel saveRouteViewModel)
        {
            if (ModelState.IsValid)
            {
                string waypoints = ""; // TODO - need to change Waypoints from saveRouteViewModel to Google API query format.
                if (saveRouteViewModel.Waypoint1 == null) { }
                else
                { 
                    foreach (char character in saveRouteViewModel.Waypoint1)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint2 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint2)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint3 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint3)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint4 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint4)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint5 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint5)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint6 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint6)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint7 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint7)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint8 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint8)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint9 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint9)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint10 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint10)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint11 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint11)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint12 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint12)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint13 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint13)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint14 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint14)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint15 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint15)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint16 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint16)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint17 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint17)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint18 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint18)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint19 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint19)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }
                if (saveRouteViewModel.Waypoint20 == null) { }
                else
                {
                    waypoints = waypoints + '|';
                    foreach (char character in saveRouteViewModel.Waypoint20)
                    {
                        char item = character;
                        if (item == ' ')
                        {
                            waypoints = waypoints + '+';
                        }
                        else
                        {
                            waypoints = waypoints + character;
                        }
                    }
                }

                string destination = "";// TODO - need to change Destination from saveRouteViewModel to Google API query format.
                foreach (char character in saveRouteViewModel.Destination)
                {
                    char item = character;
                    if (item == ' ')
                    {
                        destination = destination + '+';
                    }
                    else
                    {
                        destination = destination + character;
                    }
                }

                string origin = "";// TODO - need to change Origin from saveRouteViewModel to Google API query format.
                foreach (char character in saveRouteViewModel.Origin)
                    {
                    char item = character;
                    if (item == ' ')
                    {
                        origin = origin + '+';
                    }
                    else
                    {
                        origin = origin + character;
                    }
                }

                Route newRoute = new Route
                {
                    RouteName = saveRouteViewModel.RouteName,
                    Origin = origin,
                    Waypoints = waypoints,
                    Destination = destination,
                    Review = saveRouteViewModel.Review, // TODO - change this to a list of User's reviews somehow.
                };// TODO - Why would I need to "Clear a ModelState"?
                //////////////// Serialize the newRoute
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("MyFile.bin",
                                         FileMode.Create,
                                         FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, newRoute);
                stream.Close();
               
                ////////////////////


                //context.Routes.Add(newRoute);
                //context.SaveChanges();

                ViewBag.Origin = origin; // TODO - I'm not sure I need these 3 lines anymore...
                ViewBag.Waypoints = waypoints;
                ViewBag.Destination = destination;

                string userEmail = HttpContext.Session.GetString("_Email");
                User user = context.Users.Single(u => u.Email == userEmail);
                ViewBag.UserId = user.ID;

                //return RedirectToAction("DisplaySelectRoute", new { id = newRoute.ID }); // TODO - NEED to REDIRECT TO A CONFIRMATION PAGE TO VERIFY THE MAPPED ROUTE FOR THE USER!!!!!
                return Redirect("/Route/SubmitRoute");
            }
            return View(saveRouteViewModel);
        }

        
        public ActionResult SubmitRoute()
        {
            /////////Deserialize the newRoute
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin",
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
            Route route = (Route)formatter.Deserialize(stream);
            stream.Close();

            /////////

            string apiKey = string.IsNullOrEmpty(this._secrets.MySecret) // ViewData "object" not a string, doesn't work in pass to View, must use ViewBag?
                ? "Are you in production?"
                : this._secrets.MySecret;
            Route theRoute = route;
            ViewBag.MapUrl = string.Format("https://www.google.com/maps/embed/v1/directions?origin={0} &waypoints={1} &destination={2} &key={3}", theRoute.Origin, theRoute.Waypoints, theRoute.Destination, apiKey);
            ViewBag.Review = theRoute.Review;



            // Serialize again for next method
            //IFormatter formatter = new BinaryFormatter();
            Stream stream2 = new FileStream("MyFile.bin",
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);
            formatter.Serialize(stream2, theRoute);
            stream2.Close();
            //////
            return View();
        }
        [HttpPost]
        public ActionResult SubmitRoute(SubmitRouteViewModel submitRouteViewModel)
        {
            //De serialize again
            IFormatter formatter = new BinaryFormatter();
            Stream stream2 = new FileStream("MyFile.bin",
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
            Route route = (Route)formatter.Deserialize(stream2);
            stream2.Close();
            //
            context.Routes.Add(route);
            context.SaveChanges();
            return Redirect("/User");
        }

        public ActionResult DisplaySelectRoute(int id)
        {
            string apiKey = string.IsNullOrEmpty(this._secrets.MySecret) // ViewData "object" not a string, doesn't work in pass to View, must use ViewBag?
                ? "Are you in production?"
                : this._secrets.MySecret;
            Route theRoute = context.Routes.Single(c => c.ID == id);
            ViewBag.MapUrl = string.Format("https://www.google.com/maps/embed/v1/directions?origin={0} &waypoints={1} &destination={2} &key={3}", theRoute.Origin, theRoute.Waypoints, theRoute.Destination, apiKey);
            ViewBag.Review = theRoute.Review;
            ViewBag.RouteID = theRoute.ID; // TODO - Can I just pass "theRoute" threw thew View to the and form submission to next controller?

            var email = HttpContext.Session.GetString("_Email");
            var sessionTest = HttpContext.Session.GetString("_Email"); // TODO - Check out this 2 line session test, any better ways?
            if (sessionTest != null)
            { 
                User getUser = context.Users.Single(u => u.Email == email);
                if (getUser == null)
                {

                }
                else
                {
                    ViewBag.UserID = getUser.ID;
                }
            }

            return View();
        }

        

        public ActionResult SaveFavoriteRoute(SaveFavoriteRouteViewModel saveFavoriteRouteViewModel)
        {
            if (saveFavoriteRouteViewModel == null) // TODO - Is this nescessary? I don't think so.
            {
                throw new ArgumentNullException(nameof(saveFavoriteRouteViewModel));
            }

            if (HttpContext.Session.GetString("_Email") is null) // TODO - Is there a better way to filter this?
            {
                return Redirect("/User/LogOn");
            }
            else
            {
                //TODO - Form DB relationship between User and Route.
                int userId = saveFavoriteRouteViewModel.UserID;
                int routeId = saveFavoriteRouteViewModel.RouteID;
                IList<UserRoute> existingItems = context.UserRoutes
                    .Where(ur => ur.UserID == userId)
                    .Where(ur => ur.RouteID == routeId).ToList();
                if (existingItems.Count == 0)
                {
                    //var userID = saveFavoriteRouteViewModel.UserID;
                    //var routeID = saveFavoriteRouteViewModel.RouteID;
                    UserRoute favRoute = new UserRoute
                    {
                        User = context.Users.Single(u => u.ID == userId),
                        Route = context.Routes.Single(r => r.ID == routeId)
                    };
                    context.UserRoutes.Add(favRoute);
                    context.SaveChanges();
                    return Redirect("/User/DisplayFavorites");
                }
            }
            return Redirect("/User/DisplayFavorites");
        }

        public ActionResult RemoveFavoriteRoute(int id)
        {
            string email = HttpContext.Session.GetString("_Email");
            User user = context.Users.Single(u => u.Email == email);
            IList<UserRoute> existingItems = context.UserRoutes
                    .Where(ur => ur.UserID == user.ID)
                    .Where(ur => ur.RouteID == id).ToList();
            if ( existingItems.Count != 0)
            {
                foreach (UserRoute item in existingItems)
                {
                    context.UserRoutes.Remove(item);
                }
                context.SaveChanges();
            }
            return Redirect("/User/DisplayFavorites");
        }

        // TODO - ELIMINATE BAD PATHWAYS BELOW!!!
        // TODO - try rewriting to use the functions given below.
        // GET: Route/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Route/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Route/Create
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

        // GET: Route/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Route/Edit/5
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

        // GET: Route/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Route/Delete/5
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