using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicCrud.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

    

    namespace BasicCrud.Data
    {
        public class AspnetRunContextSeed
        {
            public static async Task SeedAsync(AspnetRunContext aspnetrunContext, ILoggerFactory loggerFactory, int? retry = 0)
            {
                int retryForAvailability = retry.Value;

                try
                {
                    // TODO: Only run this if using a real database
                     aspnetrunContext.Database.Migrate();
                     aspnetrunContext.Database.EnsureCreated();

                    if (!aspnetrunContext.Categories.Any())
                    {
                        aspnetrunContext.Categories.AddRange(GetPreconfiguredCategories());
                        await aspnetrunContext.SaveChangesAsync();
                    }

                    if (!aspnetrunContext.Products.Any())
                    {
                        aspnetrunContext.Products.AddRange(GetPreconfiguredProducts());
                        await aspnetrunContext.SaveChangesAsync();
                    }
                }
                catch (Exception exception)
                {
                    if (retryForAvailability < 10)
                    {
                        retryForAvailability++;
                        var log = loggerFactory.CreateLogger<AspnetRunContextSeed>();
                        log.LogError(exception.Message);
                        await SeedAsync(aspnetrunContext, loggerFactory, retryForAvailability);
                    }
                    throw;
                }
            }

            private static IEnumerable<Category> GetPreconfiguredCategories()
            {
                return new List<Category>()
            {
                new Category()
                {
                    Name = "Really cheap coffee",
                    Description = "SALE SALE SALE",
                    ImageName = "one"
                },
                new Category()
                {
                    Name = "Insanely cheap coffee",
                    Description = "Dare you buy from the bargain bin.",
                    ImageName = "two"
                },
                new Category()
                {
                    Name = "Cheap Coffee",
                    Description = "A step up from the rest, be bold with our best of the best selection",
                    ImageName = "three"
                }
            };
            }

            private static IEnumerable<Product> GetPreconfiguredProducts()
            {
                return new List<Product>()
            {
                new Product()
                {
                    Name = "Vietnamese blend",
                    Summary = "Vietnam is bold enough to claim they have the best coffee in the WORLD. THere is only one way for you to find out!",
                    Description = "Trying this Robusta is a must! If you need an energy boost to start your day then look no furhter than our Vietnamese Robusta blend. ",
                    ImageFile = "product-1.png",
                    Price = 22.00M,
                    CategoryId = 1
                },
                new Product()
                {
                    Name = "Napal Blend",
                    Summary = "Napal is home to some of the worlds largest mountains. It has been said man would scale any of them just to taste this coffee. ",
                    Description = "Sweet, spicy, and an aroma that will fill your house with warmth.  Order today to try one of the worlds most original tasting coffees. ",
                    ImageFile = "product-2.png",
                    Price = 23.00M,
                    CategoryId = 1
                },
                new Product()
                {
                    Name = "Mystery Bean",
                    Summary = "Keep things fresh with our monthly mystery bean",
                    Description = "Every Month we will send you our Mystery bean of the month.  We can't give any clues here or what would be the fun??",
                    ImageFile = "product-3.png",
                    Price = 12.00M,
                    CategoryId = 2
                },
                new Product()
                {
                    Name = "Peru Blend",
                    Summary = "Peru offers the perfect growing envrionment for year round prduction of the worlds best coffee beans",
                    Description = "THis coffee comes from the deep jungles of Peru. The unique jungle blend offers something truly special that you will not find elsewhere. ",
                    ImageFile = "product-4.png",
                    Price = 25.00M,
                    CategoryId = 1
                },
                new Product()
                {
                    Name = "Starbucks",
                    Summary = "A premier brand that is known in just about every country around the world. Everyone loves a fresh cup of starbucks. ",
                    Description = "Right now we only carry one kind of starbucks coffee and this is the premium dark roast. ",
                    ImageFile = "product-5.png",
                    Price = 20.00M,
                    CategoryId = 1
                },
                new Product()
                {
                    Name = "USA Blend",
                    Summary = "Here we have a blend coming stright out of the USA.  It is not typically known for its ability to grow beans, but they have found a way!",
                    Description = "This light roast comes with a variety of flavors packed into one bean.  With hints of freedom and capitalism, coffee has never tasted sooo good. ",
                    ImageFile = "product-6.png",
                    Price = 5.00M,
                    CategoryId = 3
                }
            };
            }
        }
    }
