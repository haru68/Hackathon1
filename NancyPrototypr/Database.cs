using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Specialized;


namespace EcoConception
{
    public sealed class Database
    {
        public SqlConnection Connection { get; set; }

        public Database(SqlConnectionStringBuilder connectionBuilder)
        {
            Connection = new SqlConnection(connectionBuilder.ConnectionString);
        }


        public void OpenConnection()
        {
            try
            {
                Connection.Open();
            }
            catch (Exception exception)
            {
                if (exception is InvalidOperationException || exception is SqlException)
                {
                    Console.WriteLine("There has been an error while connecting to the database:\n", exception);
                }
            }
        }

        public void CloseConnection()
        {
            try
            {
                Connection.Close();
            }
            catch (SqlException exception)
            {
                Console.WriteLine("There has been an error while closing the connection to the database:\n", exception);
            }
        }

        public static string GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Hackathon1"].ConnectionString;
            return connectionString;
        }


        public List<Product> GetAllProducts()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection;
            cmd.CommandText = "SELECT [id], [price], [name], [description], [isFemale], [hasTeeth], [age], [hasOxygenBottle], [isIncontinent], [isHandicaped], [category], [photo] FROM Products";
            List<Product> products = new List<Product>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.Price = reader.GetDecimal(reader.GetOrdinal("price"));
                        product.Name = reader.GetString(reader.GetOrdinal("name"));
                        product.Description = reader.GetString(reader.GetOrdinal("description"));
                        product.isFemale = reader.GetBoolean(reader.GetOrdinal("isFemale"));
                        product.hasOxygenBottle = reader.GetBoolean(reader.GetOrdinal("hasTeeth"));
                        product.isIncontinent = reader.GetBoolean(reader.GetOrdinal("isIncontinent"));
                        product.isHandicaped = reader.GetBoolean(reader.GetOrdinal("isHandicaped"));
                        product.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        product.age = reader.GetInt32(reader.GetOrdinal("age"));
                        
                        products.Add(product);
                    }
                }
            }
            return products;

        }

        public List<Category> GetAllCategories()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection;
            cmd.CommandText = $"SELECT [id], [name], [description] FROM Categories";
            List<Category> categories = new List<Category>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Category category = new Category();
                        category.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        category.Name = reader.GetString(reader.GetOrdinal("name"));
                        category.Description = reader.GetString(reader.GetOrdinal("description"));
                        categories.Add(category);
                    }
                }
            }
            return categories;
        }

        public List<Product> GetProductsOfCat1()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection;
            cmd.CommandText = "SELECT [price], [name], [description], [photo] FROM Products WHERE [category]=1";
            List<Product> products = new List<Product>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.Price = reader.GetDecimal(reader.GetOrdinal("price"));
                        product.Name = reader.GetString(reader.GetOrdinal("name"));
                        product.Description = reader.GetString(reader.GetOrdinal("description"));

                        products.Add(product);
                    }
                }
            }
            return products;

        }

        public List<Product> GetProductsOfCat2()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection;
            cmd.CommandText = "SELECT [price], [name], [description], [photo] FROM Products WHERE [category]=2";
            List<Product> products = new List<Product>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.Price = reader.GetDecimal(reader.GetOrdinal("price"));
                        product.Name = reader.GetString(reader.GetOrdinal("name"));
                        product.Description = reader.GetString(reader.GetOrdinal("description"));

                        products.Add(product);
                    }
                }
            }
            return products;

        }
    }
}