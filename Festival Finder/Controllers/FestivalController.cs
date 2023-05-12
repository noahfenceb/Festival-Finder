using Festival_Finder.Data;
using Festival_Finder.Models;
using Festival_Finder.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Festival_Finder.Controllers
{
    [Authorize]
    public class FestivalController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<AppUser> _userManager;

        public FestivalController(ApplicationDbContext dbcontext, UserManager<AppUser> userManager)
        {
            context = dbcontext;
            _userManager = userManager;
        }
        //[AllowAnonymous]
        public IActionResult Index()
        {
            List<Festival> festivals = context.Festivals.Include(j => j.Location).Include(k => k.Artists).ToList();
            return View(festivals);

        }

        public IActionResult Detail(int? id)
        {
            Festival festival = context.Festivals.Include(j => j.Location).Include(a => a.Artists).Single(j => j.Id == id);
            return View(festival);

        }

        public IActionResult Create()
        {
            var artists = context.Artists.ToList();
            var festivalViewModel = new AddFestivalViewModel
            {
                Artists = artists.Select(j => new SelectListItem
                {
                    Value = j.Id.ToString(),
                    Text = j.Name
                })
            };

            return View(festivalViewModel);
        }

        [HttpPost]
        public IActionResult Create(AddFestivalViewModel addFestivalViewModel)
        {
            //AddFestivalViewModel to Festival Model
            var festival = new Festival
            {
                Name = addFestivalViewModel.Name,
                Description = addFestivalViewModel.Description,
                ImageUrl = addFestivalViewModel.ImageUrl,
                Location = addFestivalViewModel.Location,
                Date = addFestivalViewModel.Date
            };

            //Mapp Artist
            var selectedArtist = new List<Artist>();
            foreach( var selectArtistId in addFestivalViewModel.SelectedArtists)
            {
                var selectArtistIdAsInt = int.Parse(selectArtistId.ToString());
                var existingArtists = context.Artists.Find(selectArtistIdAsInt);
                if(existingArtists != null)
                {
                    selectedArtist.Add(existingArtists);
                }

            }

            festival.Artists = selectedArtist;
            context.Add(festival);
            context.SaveChanges();
            TempData["success"] = "Festival create successful";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            //get festival by id from database
            var festival = context.Festivals.Include(x => x.Artists).Include(y => y.Location)
                .FirstOrDefault(x => x.Id == id);

            //var festival = context.Festivals.FirstOrDefault(x => x.Id == id);

            var artist = context.Artists.ToList();

            if (festival != null)
            {

                //Map model to viewModel
                var editViewModel = new EditFestivalViewModel
                {
                    Id = festival.Id,
                    Name = festival.Name,
                    Description = festival.Description,
                    ImageUrl = festival.ImageUrl,
                    Location = festival.Location,
                    Date = festival.Date,
                    Artists = artist.Select(a => new SelectListItem
                    {
                        Text = a.Name,
                        Value = a.Id.ToString()
                    }).ToList(),
                    SelectedArtists = festival.Artists.Select(a => a.Id.ToString()).ToArray()
                };
                return View(editViewModel);
            }
            return View();
        }


        [HttpPost]
        public IActionResult Edit(EditFestivalViewModel editFestivalViewModel)
        {
            var existingFestival = context.Festivals.Include(x => x.Artists)
                .Include(y => y.Location).FirstOrDefault(x => x.Id == editFestivalViewModel.Id);
            if (existingFestival != null)
            {
                existingFestival.Name = editFestivalViewModel.Name;
                existingFestival.Description = editFestivalViewModel.Description;
                existingFestival.ImageUrl = editFestivalViewModel.ImageUrl;
                existingFestival.Location = editFestivalViewModel.Location;
                existingFestival.Date = editFestivalViewModel.Date;
                var selectedArtists = new List<Artist>();
                foreach (var artistId in editFestivalViewModel.SelectedArtists)
                {
                    if (int.TryParse(artistId, out var id))
                    {
                        var artist = context.Artists.Find(id);
                        if (artist != null)
                        {
                            selectedArtists.Add(artist);
                        }
                    }
                }
                existingFestival.Artists = selectedArtists;
                context.Update(existingFestival);
                context.SaveChanges();
                //Notification
                TempData["success"] = "Festival update successful";
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public IActionResult Delete(int id)
        {
            var existingFestival = context.Festivals.Find(id);
            if(existingFestival != null)
            {
                context.Festivals.Remove(existingFestival);
                context.SaveChanges();
                TempData["success"] = "Festival Delete successful";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Delete unsuccessful";
            return View("Edit");
        }


        //public IActionResult Search(string searchTerm)
        //{
        //    var festivals = context.Festivals.Include(f => f.Artists).Where(f => f.Description.Contains(searchTerm)).ToList();

        //    return View(festivals);
        //}
        public IActionResult Search(string searchString)
        {
            var festivals = from f in context.Festivals
                            select f;

            if (!String.IsNullOrEmpty(searchString))
            {
                festivals = festivals.Where(f =>
                    f.Name.Contains(searchString) ||
                    f.Description.Contains(searchString));
                    //|| f.Artists.Any(a => a.Name.Contains(searchString)));
                
            }

            return View(festivals.ToList());
        }



    }
}
