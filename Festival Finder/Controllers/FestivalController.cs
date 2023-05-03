using Festival_Finder.Data;
using Festival_Finder.Models;
using Festival_Finder.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            List<Festival> festivals = context.Festivals.Include(j => j.Location).Include(k => k.Artists).ToList();
            return View(festivals);
        }

        public IActionResult Detail(int? id)
        {
            Festival festival = context.Festivals.Include(j => j.Location).Single(j => j.Id == id);
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

        //[HttpPost]
        //public IActionResult Edit(EditFestivalViewModel editFestivalViewModel)
        //{
        //    //map viewmodel to model
        //    //var festival = new Festival
        //    //{
        //    //    Id = editFestivalViewModel.Id,
        //    //    Name = editFestivalViewModel.Name,
        //    //    Description = editFestivalViewModel.Description,
        //    //    ImageUrl = editFestivalViewModel.ImageUrl,
        //    //    Location = editFestivalViewModel.Location,
        //    //    Date = editFestivalViewModel.Date

        //    //};
        //    var festival = context.Festivals.Find(editFestivalViewModel.Id);
        //    var selectedArtists = new List<Artist>();
        //    foreach(var artist in editFestivalViewModel.SelectedArtists)
        //    {
        //        if(int.TryParse(artist, out var s))
        //        {
        //            var artistFound = context.Artists.Find(s);
        //            if(artistFound != null)
        //            {
        //                selectedArtists.Add(artistFound);
        //            }
        //        }
        //    }

        //    festival.Artists = selectedArtists;

        //    var existingFestival = context.Festivals.Include(x => x.Artists)
        //        .Include(y => y.Location).FirstOrDefault(x => x.Id == editFestivalViewModel.Id);

        //    if(existingFestival != null)
        //    {
        //        //existingFestival.Id = festival.Id;
        //        //existingFestival.Name = festival.Name;
        //        //existingFestival.Description = festival.Description;
        //        //existingFestival.ImageUrl = festival.ImageUrl;
        //        //existingFestival.Location = festival.Location;
        //        //existingFestival.Artists = festival.Artists;
        //        //Anthony
        //        //festival.Name = editFestivalViewModel?.Name;
        //        //festival.Description = editFestivalViewModel.Description

        //    }

        //    context.Update(festival);
        //    context.SaveChanges();
        //    //Notification
        //    return RedirectToAction("Index");
        //}

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
                return RedirectToAction("Index");
            }
            return View("Edit");
        }


        public IActionResult Search(string searchTerm)
        {
            var festivals = context.Festivals.Include(f => f.Artists).Where(f => f.Location.City.Contains(searchTerm) ||
            f.Description.Contains(searchTerm) || f.Artists.Any(a => a.Name.Contains(searchTerm))).ToList();

            return View(festivals);
        }

       

    }
}
