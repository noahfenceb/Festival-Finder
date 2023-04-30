using Festival_Finder.Data;
using Festival_Finder.Models;
using Festival_Finder.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Festival_Finder.Controllers
{
    public class FestivalController : Controller
    {
        private readonly ApplicationDbContext context;

        public FestivalController(ApplicationDbContext dbcontext)
        {
            context = dbcontext;
        }
        public IActionResult Index()
        {
            List<Festival> festivals = context.Festivals.Include(j => j.Location).ToList();
            return View(festivals);
        }

        public IActionResult Detail(int? id)
        {
            Festival festival = context.Festivals.Include(j => j.Location).Single(j => j.Id == id);
            return View(festival);

        }

        public IActionResult Create()
        {
            List<Artist> artists = context.Artists.ToList();
            AddFestivalViewModel addFestivalView = new AddFestivalViewModel(artists);
            return View(addFestivalView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddFestivalViewModel addFestivalViewModel)
        {
            if (ModelState.IsValid)
            {
                List<Artist>? artist = context.Artists.Include(j => j.Location).ToList();

                Festival newFestival = new Festival
                {
                    Name = addFestivalViewModel.Name,
                    Description = addFestivalViewModel.Description,
                    ImageUrl = addFestivalViewModel.ImageUrl,
                    Artists = artist,
                    Location = addFestivalViewModel.Location,
                    Date = addFestivalViewModel.Date

                };
                context.Festivals.Add(newFestival);
                context.SaveChanges();

                return Redirect("Index");
            }
            return View(addFestivalViewModel);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Festival festival = context.Festivals.Find(id);

            return View(festival);
        }


    }
}
