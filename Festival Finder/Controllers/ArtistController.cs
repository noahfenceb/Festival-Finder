using Festival_Finder.Data;
using Festival_Finder.Models;
using Festival_Finder.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Festival_Finder.Controllers
{
    [Authorize]
    public class ArtistController : Controller
    {

        private readonly ApplicationDbContext context;

        public ArtistController(ApplicationDbContext dbcontext)
        {
            context = dbcontext;
        }

        public IActionResult Index()
        {
            List<Artist> artists = context.Artists.ToList();
            return View(artists);
        }

        public IActionResult Add()
        {
            //Artist artist = new Artist();
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddArtistViewModel addArtistViewModel)
        {
            if (ModelState.IsValid)
            {
                //Mapping artist viewmodel to model
                var artist = new Artist
                {
                    Name = addArtistViewModel.Name
                };
                context.Artists.Add(artist);
                context.SaveChanges();
                TempData["success"] = "Artist Added";
                return RedirectToAction("Create", "Festival");
            }

            return View("Add");
        }

        public IActionResult Edit(int id)
        {
            var artist = context.Artists.FirstOrDefault(x => x.Id == id);

            if(artist != null)
            {
                var editArtistViewModel = new EditArtistViewModel
                {
                    Id = artist.Id,
                    Name = artist.Name
                };
                return View(editArtistViewModel);
            }

            return View("List");
        }

        [HttpPost]
        public IActionResult Edit(EditArtistViewModel editArtistViewModel)
        {
            //convert back to a artist
            var artist = new Artist
            {
                Id = editArtistViewModel.Id,
                Name = editArtistViewModel.Name
            };
            var existingArtist = context.Artists.Find(artist.Id);
            if(existingArtist != null)
            {
                existingArtist.Name = artist.Name;

                //Save Changes
                context.SaveChanges();
                //Success notification
                TempData["success"] = "Artist Updated";
                return RedirectToAction("Index");
            }
            //Error Notification
            return RedirectToAction("Edit", new { id = editArtistViewModel.Id});
        }

        public IActionResult Delete(EditArtistViewModel editArtistViewModel)
        {
            var existingArtist = context.Artists.Find(editArtistViewModel.Id);

            if(existingArtist != null)
            {
                context.Artists.Remove(existingArtist);
                context.SaveChanges();

                //Success Notification
                TempData["success"] = "Artist Removed";
                return RedirectToAction("Index");
            }

            //Fail Notification
            return RedirectToAction("Edit", new { id = editArtistViewModel.Id });
        }


        //// localhost:[port]/Artist/AddFestival/{AnimalId?}
        //public IActionResult AddFestival(int id)
        //{
        //    Festival theFestival = context.Festivals.Find(id);
        //    List<Artist> possibleArtists = context.Artists.ToList();

        //    AddArtistFestivalViewModel viewModel = new AddArtistFestivalViewModel(theFestival, possibleArtists);

        //    return View(viewModel);
        //}

        //[HttpPost]
        //public IActionResult AddFestival(AddArtistFestivalViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        int festivalId = viewModel.FestivalId;
        //        int artistId = viewModel.ArtistId;

        //        Festival theFestival = context.Festivals
        //            .Include(a => a.Artists)
        //            .Where(a => a.Id == festivalId)
        //            .First();

        //        Artist theArtist = context.Artists
        //            .Where(t => t.Id == artistId)
        //            .First();

        //        theFestival.Artists.Add(theArtist);
        //        context.SaveChanges();
        //        return Redirect("/Festivals/Detail/" + festivalId);
        //    }

        //    return View(viewModel);
        //}

        //public IActionResult Detail(int id)
        //{
        //    Artist theArtist = context.Artists
        //        .Include(a => a.Festivals)
        //        .Where(t => t.Id == id)
        //        .First();

        //    return View(theArtist);
        //}
        //    public IActionResult Index()
        //    {
        //        return View();
        //    }

        //    public IActionResult Add()
        //    {
        //        AddArtistViewModel artistViewModel = new AddArtistViewModel();
        //        return View(artistViewModel);
        //    }

        //    [HttpPost]
        //    public IActionResult Add(AddArtistViewModel artistViewModel)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            Artist artist = new Artist
        //            {
        //                Name = artistViewModel.Name,

        //            };

        //            context.Artists.Add(artist);
        //            context.SaveChanges();

        //            return RedirectToAction("Create","Festival");
        //        }

        //        return View(artistViewModel);
        //    }
    }
    
}
