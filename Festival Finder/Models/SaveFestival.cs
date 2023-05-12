namespace Festival_Finder.Models
{
    public class SaveFestival
    {
        public int Id { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public int? FestivalId { get; set; }
        public Festival? Festival { get; set; }
    }
}
