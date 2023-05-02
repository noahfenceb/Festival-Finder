using System;
namespace Festival_Finder.Models
{
	public class Artist
	{
		public int Id { get; set; }
		public string? Name { get; set; }
        public string? ImageUrl { get; set; }
		public Location? Location { get; set; }
        public ICollection<Festival>? Festivals { get; set; }

        public Artist()
		{
		}

        public Artist(string name, Location location, ICollection<Festival>? festivals)
        {
            Name = name;
            Location = location;
            Festivals = festivals;
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
            return this.ToString();
        }
    }
}

