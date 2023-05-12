using System;
namespace Festival_Finder.Models
{
	public class Festival
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
        public string? ImageUrl { get; set; }
		public int ArtistId { get; set; }
		public ICollection<Artist> Artists { get; set; }
        public DateTime Date { get; set; }
        public int LocationId { get; set; }
		public Location? Location { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        

        public Festival()
		{
		}

        public Festival(string name, string description, int artistId, ICollection<Artist> artists, int locationId, Location location, DateTime date)
        {
            Name = name;
            Description = description;
            ArtistId = artistId;
            Artists = artists;
            LocationId = locationId;
            Location = location;
            Date = date;

        }

        public override bool Equals(object? obj)
        {
            return obj is Festival festival &&
                   Id == festival.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string? ToString()
        {
            return this.ToString();
        }
    }
}

