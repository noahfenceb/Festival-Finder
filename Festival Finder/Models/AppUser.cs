using Microsoft.AspNetCore.Identity;
using System;
namespace Festival_Finder.Models
{
	public class AppUser: IdentityUser

	{
		
		public string? Name { get; set; }
		public string? ImageURL { get; set; }
        public int? LocationId { get; set; }
		public Location? Location { get; set; }
        public ICollection<Artist>? Artists { get; set; }
        public ICollection<Festival>? Festivals { get; set; }
        

		public AppUser()
		{

		}

        public AppUser(string? name, string? imageURL, Location? location)
        {
            Name = name;
            ImageURL = imageURL;
            Location = location;
        }

        public override bool Equals(object? obj)
        {
            return obj is AppUser user &&
                   Id == user.Id;
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

