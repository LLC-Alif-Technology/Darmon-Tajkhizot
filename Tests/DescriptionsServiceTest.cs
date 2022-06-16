using Entities.DataContexts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class DescriptionsServiceTest
    {
        private static DbContextOptions<DataContext> dbContextOptions = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "Darmon").Options;
        DataContext context;
        DescriptionService descriptionService;

        [OneTimeSetUp]
        public void Setup()
        {
            context = new DataContext(dbContextOptions);
            context.Database.EnsureCreated();
            SeedDatabase();
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

        private void SeedDatabase()
        {
            var descriptions = new List<Description>
            {
               new Description()
               {
                   Id = Guid.NewGuid(),
                   Name = "Name1",
                   Text = "Text1"
               },
               new Description()
               {
                   Id = Guid.NewGuid(),
                   Name = "Name2",
                   Text = "Text2"
               }
            };
            context.Descriptions.AddRange(descriptions);
            
            //var categories = new List<Category>
            //{
            //    new Category()
            //    {
            //        Id = Guid.NewGuid(),
            //        ImagePath = @"C:\Users\Faramush\Downloads\photo_2022-05-28_11-29-58.jpg",

            //    }

            //};
            
        }


    }
}
