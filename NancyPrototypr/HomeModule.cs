using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Nancy;
using Nancy.ModelBinding;
using System.Linq;
using System.Data.SqlClient;


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
                /*List<Product> products = new List<Product>();
                IEnumerable<Category> categories = Categories;
                Category womanCategory = Categories.Single(category => category.Name == "Women");
                Category manCategory = Categories.Single(category => category.Name == "Men");
                products.Add(new Product { Name = "Henriette", Price = 40000, Category = womanCategory, Description = "Old woman" });
                products.Add(new Product { Name = "Gérard", Price = 30000, Category = manCategory, Description = "Old handsome boy" });
                */

                return Database.GetAllProducts();
            }
        }



        /*public override IEnumerable<Category> Categories
        {
            get
            {
                List<Category> categories = new List<Category>
                {
                    new Category{ Name = "Women", Description = "Old mature and pretty women" },
                    new Category{ Name = "Men", Description = "Good guys like your daddy" }
                };
                return categories;
            }
        }*/

        public override IEnumerable<Category> Categories
        {
            get
            {
                return Database.GetAllCategories();
            }
        }

        public HomeModule()
        {
            Get("/", ServeHome);
            Get("/Categories", ServeCategories);
            Get("/tri", ServeCategory1);
        }

        private dynamic ServeHome(object manyParameters)
        {
            return View["home.sshtml", Products];
        }

        private dynamic ServeCategories(object manyParameters)
        {
            return View["home.sshtml", Categories];
        }

        private dynamic ServeCategory1(object manyParameters)
        {
            return View["home.sshtml", Database.GetProductsOfCat1()];
        }
    }
}