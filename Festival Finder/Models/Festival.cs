using System;
namespace Festival_Finder.Models
{
	public class Festival
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int ArtisteId { get; set; }
		public ICollection<Artist> Artist { get; set; }
		public int LocationId { get; set; }
		public Location Location { get; set; }

		public Festival()
		{
		}

        public Festival(string name, string description, int artisteId, ICollection<Artist> artist, int locationId, Location location)
        {
            Name = name;
            Description = description;
            ArtisteId = artisteId;
            Artist = artist;
            LocationId = locationId;
            Location = location;
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
            return base.ToString();
        }
    }
}

