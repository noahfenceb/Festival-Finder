using System;
namespace Festival_Finder.Models
{
	public class Location
	{
		public int Id { get; set; }
		public string? Street { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }

		public Location()
		{
		}

        public override bool Equals(object? obj)
        {
            return obj is Location location &&
                   Street == location.Street &&
                   City == location.City &&
                   State == location.State;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Street, City, State);
        }

        public override string? ToString()
        {
            return this.ToString();
        }
    }
}

