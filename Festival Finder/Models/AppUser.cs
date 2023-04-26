using System;
namespace Festival_Finder.Models
{
	public class AppUser

	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public int Phone { get; set; }
		public string ImageURL { get; set; }
		public string Location { get; set; }

		public AppUser()
		{

		}

        public AppUser(string name, string email, int phone, string imageURL, string location)
        {
            Name = name;
            Email = email;
            Phone = phone;
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
            return ToString();
        }
    }



}

