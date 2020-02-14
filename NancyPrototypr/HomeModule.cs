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

                return Database.GetRandomProducts();
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

        public IEnumerable<Product> ProductFromCategory(string categoryName)
        {
            return Database.GetProductByCategory(Database.GetCategoryId(categoryName));
        }

        public HomeModule()
        {
            Get("/", ServeHome);
            Get("/Categories", ServeCategories);
            Get("/tri_{category}", parameters =>  ServeProductFromCategory(parameters.category));
            Get("/choice_{boolean}", parameters => ServeProductFromHasTeeth(parameters.boolean));
            Get("/choice_{boolean}", parameters => ServeProductFromHasOxygen(parameters.boolean));
            Get("/choice_{boolean}", parameters => ServeProductFromIsIncontinent(parameters.boolean));
            Get("/choice_{boolean}", parameters => ServeProductFromIsHandicaped(parameters.boolean));
        }

        private dynamic ServeHome(object manyParameters)
        {
            return View["home.sshtml", Products];
        }

        private dynamic ServeCategories(object manyParameters)
        {
            return View["categories.sshtml", Categories];
        }

        private dynamic ServeProductFromCategory(string manyParameters)
        {
            return View["home.sshtml", ProductFromCategory(manyParameters)];
        }

        private dynamic ServeProductFromHasTeeth(int manyParameters)
        {
            return View["choice.sshtml", Database.GetProductFromCharacteristicHasTeeth(manyParameters)];
        }

        private dynamic ServeProductFromHasOxygen(int manyParameters)
        {
            return View["choice.sshtml", Database.GetProductFromCharacteristicHasOxygen(manyParameters)];
        }

        private dynamic ServeProductFromIsIncontinent(int manyParameters)
        {
            return View["choice.sshtml", Database.GetProductFromCharacteristicIsIncontinent(manyParameters)];
        }

        private dynamic ServeProductFromIsHandicaped(int manyParameters)
        {
            return View["choice.sshtml", Database.GetProductFromCharacteristicIsHandicaped(manyParameters)];
        }

    }
}