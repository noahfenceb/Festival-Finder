using Festival_Finder.Data;
using Festival_Finder.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        //public IActionResult Index()
        //{
        //    // Get the current user's saved festivals
        //    var userId = User.Identity.GetUserId();
        //    var currentUser = context.Users.Find(userId);
        //    var savedFestivals = currentUser.SaveFestivals;

        //    // Map the saved festivals to the view model
        //    var savedFestivalViewModels = savedFestivals.Select(sf => new SavedFestivalViewModel
        //    {
        //        Id = sf.FestivalId,
        //        Name = sf.Festival.Name,
        //        Description = sf.Festival.Description
        //    }).ToList();

        //    // Pass the view model to the view
        //    return View(savedFestivalViewModels);

        //}
            public IActionResult Add(int id)
            {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();

                var existingFestival = context.SaveFestivals.FirstOrDefault(x => x.AppUserId == userId && x.FestivalId == id);
                var festival = context.Festivals.Find(id);


                if (existingFestival != null)
                {
                    return RedirectToAction("Index", "Dashboard");
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

    }
}
