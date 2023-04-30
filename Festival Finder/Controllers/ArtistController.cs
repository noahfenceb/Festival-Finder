using Festival_Finder.Data;
using Festival_Finder.Models;
using Festival_Finder.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Festival_Finder.Controllers
{
    public class ArtistController : Controller
    {

        private readonly ApplicationDbContext context;

        public ArtistController(ApplicationDbContext dbcontext)
        {
            context = dbcontext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            AddArtistViewModel artistViewModel = new AddArtistViewModel();
            return View(artistViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddArtistViewModel artistViewModel)
        {
            if (ModelState.IsValid)
            {
                Artist artist = new Artist
                {
                    Name = artistViewModel.Name,
                    
                };

                context.Artists.Add(artist);
                context.SaveChanges();

                return RedirectToAction("Create","Festival");
            }

            return View(artistViewModel);
        }
    }
    
}
