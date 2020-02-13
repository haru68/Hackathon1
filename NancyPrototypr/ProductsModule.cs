using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EcoConception
{
    public class ProductsModule : AbstractModule
    {
        public Product product { get; set; }
        public Category category { get; set; }


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
                Category womanCategory = Categories.Single(category => category.Name == "Women");
                Category manCategory = Categories.Single(category => category.Name == "Men");
                products.Add(new Product { Name = "Gérard", Price = 30000, Category = manCategory, Description = "Old handsome boy" });
                products.Add(new Product { Name = "Gérard", Price = 30000, Category = manCategory, Description = "Old handsome boy" });

                // Requête SQL des produits ici pour avoir la liste de tous les produits
                return products;
            }
        }


        public override IEnumerable<Category> Categories 
        {
            get
            {
                List<Category> categories = new List<Category>
                {
                    // Requete SQL pour avoir la liste des catégories
                    new Category{ Name = "Women", Description = "Old mature and pretty women" },
                    new Category{ Name = "Men", Description = "Good guys like your daddy" }
                };
                return categories;
            }
        }

        public ProductsModule()
        {

        }

        

    }
}