using Festival_Finder.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Festival_Finder.ViewModel
{
    public class AddFestivalViewModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public Location? Location { get; set; }
        public int ArtistId { get; set; }
        public DateTime Date { get; set; }
        public List<SelectListItem>? Artists { get; set; }

        public AddFestivalViewModel(List<Artist>? artists)
        {
            Artists = new List<SelectListItem>();
            foreach (var artist in artists)
            {
                Artists.Add(new SelectListItem
                {
                    Value = artist.Id.ToString(),
                    Text = artist.Name
                });
            }
        }

        public AddFestivalViewModel() { }


    }
}
