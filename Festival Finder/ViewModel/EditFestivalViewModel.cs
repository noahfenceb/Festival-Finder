using Festival_Finder.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Festival_Finder.ViewModel
{
    public class EditFestivalViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public Location? Location { get; set; }

        public DateTime Date { get; set; }
        //Display Artist
        public IEnumerable<SelectListItem> Artists { get; set; }
        //Capture artist
        public string[] SelectedArtists { get; set; } = Array.Empty<string>();
    }
}
