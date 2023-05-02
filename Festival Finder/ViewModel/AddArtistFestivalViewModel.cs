using Festival_Finder.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Festival_Finder.ViewModel
{
    public class AddArtistFestivalViewModel
    {
        public int FestivalId { get; set; }
        public Festival? Festival { get; set; }
        public int ArtistId { get; set; }
        public List<SelectListItem>? Artists { get; set; }

        public AddArtistFestivalViewModel(Festival theFestival, List<Artist> possibleArtist)
        {
            Artists = new List<SelectListItem>();

            foreach (var tag in possibleArtist)
            {
                Artists.Add(new SelectListItem
                {
                    Value = tag.Id.ToString(),
                    Text = tag.Name
                });
            }

            Festival = theFestival;
        }

        public AddArtistFestivalViewModel() { }
    }
}
