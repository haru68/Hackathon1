using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Nancy;
using Nancy.ModelBinding;
using System.Linq;

namespace EcoConception
{
    public class HomeModule : AbstractModule
    {
        public override IEnumerable<Product> Products
        {
            get
            {
                // You must get products from a database
                // in the real version. This code is only
                // here to show you how to pass a model
                // to your view
                // Database.GetMostRecentProducts();
                List<Product> products = new List<Product>();
                IEnumerable<Category> categories = Categories;
                Category badassCategory = Categories.Single(category => category.Name == "Bada$$");
                products.Add(new Product { Name = "Corentin", Price = 40000, Category = badassCategory, Description = "SuperDev" });
                return products;
            }
        }

        public override IEnumerable<Category> Categories 
        { 
            get
            {
                List<Category> categories = new List<Category>
                {
                    new Category{ Name = "Bada$$", Description = "Really good stuff" }
                };
                return categories;
            }
        }

        public HomeModule()
        {
            Get("/", ServeHome);
        }

        private dynamic ServeHome(object manyParameters)
        {
            return View["home.sshtml", Products];
        }
    }
}