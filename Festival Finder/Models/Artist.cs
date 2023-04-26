using System;
namespace Festival_Finder.Models
{
	public class Artist
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Location Location { get; set; }
		public int FestivalId { get; set; }
		public ICollection<Festival>? Festival { get; set; }

		public Artist()
		{
		}

        public Artist(string name, Location location, int festivalId, ICollection<Festival>? festival)
        {
            Name = name;
            Location = location;
            FestivalId = festivalId;
            Festival = festival;
        }

        public override bool Equals(object? obj)
        {
            return obj is Artist artist &&
                   Id == artist.Id;
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

