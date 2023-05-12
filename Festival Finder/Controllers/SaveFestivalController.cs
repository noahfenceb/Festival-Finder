using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.Identity;
using Festival_Finder.Data;
using Festival_Finder.Models;
using Microsoft.EntityFrameworkCore;
using Festival_Finder.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace Festival_Finder.Controllers
{
    [Authorize]
    public class SaveFestivalController : Controller
    {
        private readonly ApplicationDbContext context;

        public SaveFestivalController(ApplicationDbContext dbcontext)
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

        

        //public IActionResult Add(int id)
        //{
        //    Festival festival = context.Festivals.Find(id);
        //    if (festival == null)
        //    {
        //        return NotFound();
        //    }

        //    AppUser user = context.Users.Find(User.Identity.Name);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    user.Festivals.Add(festival);
        //    context.SaveChanges();
        //    return RedirectToAction("Index", "SaveFestival");
        //}

        //public IActionResult Index()
        //{
        //    AppUser user = context.Users.Include(x => x.Festivals).FirstOrDefault(y => y.UserName == User.Identity.Name);
        //    if(user == null)
        //    {
        //        return Challenge();
        //    }

        //    return View(user.Festivals);
        //}

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


    }
}
