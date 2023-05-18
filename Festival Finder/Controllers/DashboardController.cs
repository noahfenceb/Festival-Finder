using Festival_Finder.Data;
using Festival_Finder.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Festival_Finder.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext context;
        public DashboardController(ApplicationDbContext dbcontext)
        {
            context = dbcontext;
        }


        public IActionResult Add(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();

                var existingFestival = context.SaveFestivals.FirstOrDefault(x => x.AppUserId == userId && x.FestivalId == id);
                var festival = context.Festivals.Find(id);


                if (existingFestival != null)
                {
                    return RedirectToAction("Index", "Festival");
                }

                var savedFestival = new SaveFestival
                {
                    AppUserId = userId,
                    Festival = festival
                };

                context.SaveFestivals.Add(savedFestival);
                context.SaveChanges();
                //List<SaveFestival> allFestivals = context.SaveFestivals.ToList();
                //return View(allFestivals);
                return View(savedFestival);
            }
            return RedirectToAction("Index", "Festival");
        }

        //public IActionResult Detail()
        //{
        //    var userId = User.Identity.GetUserId();
        //    var favourites = context.SaveFestivals.Where(x => x.AppUserId == userId).ToList();
        //    return View(favourites);
        //}


        //public IActionResult Index()
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        var userId = User.Identity.GetUserId();
        //        var savedFestivals = context.SaveFestivals
        //            .Include(sf => sf.Festival)
        //            .Where(sf => sf.AppUserId == userId)
        //            .ToList();

        //        return View(savedFestivals);
        //    }

        //    return RedirectToAction("Index", "Festival");
        //}

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var savedFestivals = context.SaveFestivals
                    .Include(sf => sf.Festival)
                        .ThenInclude(f => f.Artists)
                    .Include(sf => sf.Festival)
                        .ThenInclude(f => f.Location)
                    .Where(sf => sf.AppUserId == userId)
                    .ToList();

                return View(savedFestivals);
            }

            return RedirectToAction("Index", "Festival");
        }

    }
}
