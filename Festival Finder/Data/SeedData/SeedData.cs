using Festival_Finder.Models;

namespace Festival_Finder.Data.SeedData
{
    public class SeedData
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Artists.Any())
                {
                    //artist
                    context.Artists.AddRange(new List<Artist>()
                    {
                        new Artist()
                        {
                            Name = "Jay Z",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSOYcBjGEMaX_jhru5A8fH0OgzaJpraSE6DJQZur95PVCGDC5JFmq8ocQ&s",
                            Festival = new Festival()
                            {
                                Name = "STL Vibes",
                                Description = "A day under the sun"
                            },
                            Location = new Location()
                            {
                                Street = "Natural Bridge",
                                City = "St. Louis",
                                State = "Missouri"
                            }
                         },
                        new Artist()
                        {
                            Name = "Boosie",
                            ImageUrl = "https://t0.gstatic.com/licensed-image?q=tbn:ANd9GcT9j7OfNAqnxDvG89H75XUTSbdeBIBDUGk1oPeUYgAuBy7KmTwnI9oMcjHgV5Und4eq8DXLdWBSCBxLwts",
                            Festival = new Festival()
                            {
                                Name = "Turn Up",
                                Description = "All white Party"
                            },
                            Location = new Location()
                            {
                                Street = "Brooklyn",
                                City = "East St. Louis",
                                State = "Illinios"
                            }
                         },
                        new Artist()
                        {
                            Name = "Gloriilla",
                            ImageUrl = "https://media.allure.com/photos/6418b4da135da48037bc50be/4:3/w_1955,h_1466,c_limit/Glorilla%20red%20waves%20.jpg",
                            Festival = new Festival()
                            {
                                Name = "Turn Up",
                                Description = "All white Party"
                            },
                            Location = new Location()
                            {
                                Street = "Brooklyn",
                                City = "East St. Louis",
                                State = "Illinios"
                            }
                         },
                        
                    });
                    context.SaveChanges();
                }
                //Festival
                if (!context.Festivals.Any())
                {
                    context.Festivals.AddRange(new List<Festival>()
                    {
                        new Festival()
                        {
                            Name = "Colors",
                            ImageUrl = "https://images.unsplash.com/photo-1506157786151-b8491531f063?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8bXVzaWMlMjBmZXN0aXZhbHxlbnwwfHwwfHw%3D&w=1000&q=80",
                            Description = "Night of Colors",
                           
                            Location = new Location()
                            {
                                Street = "123 Main St",
                                City = "Charlotte",
                                State = "NC"
                            }
                        },
                        new Festival()
                        {
                            Name = "Happy Hour",
                            ImageUrl = "https://i.guim.co.uk/img/media/dc60c2216c6230eeb2eaf2ffecc6c7452b771820/0_54_4096_2457/master/4096.jpg?width=1200&height=1200&quality=85&auto=format&fit=crop&s=68532136fa2c6a2a3579e9694bc73d2b",
                            Description = "Drink Tuesday",

                            Location = new Location()
                            {
                                Street = "56 Nights Ave",
                                City = "Miami",
                                State = "Florida"
                            }
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
