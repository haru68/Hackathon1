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


        public List<Product> GetRandomProducts()
        {
            Random randomGenerator = new Random();
            int id = randomGenerator.Next(1, 21);
            int id2 = randomGenerator.Next(1, 21);
            int id3 = randomGenerator.Next(1, 21);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection;
            cmd.CommandText = $"SELECT photo_path, \"name\", price, \"description\" FROM Products WHERE id = {id} OR id = {id2} OR id = {id3}";
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

        public List<Product> GetAllProducts()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection;
            cmd.CommandText = "SELECT * FROM Products";
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
            cmd.CommandText = $"SELECT * FROM Categories";
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

        

        public int GetCategoryId(string category)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection;
            cmd.CommandText = $"SELECT id FROM Categories WHERE \"name\" = '{category}'";
            int id = 1;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id"));
                    }
                }
            }
            return id;
        }



        public List<Product> GetProductByCategory(int category_id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection;
            cmd.CommandText = $"SELECT \"name\", id, price, \"description\" FROM Products WHERE category = {category_id}";
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
                        product.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        products.Add(product);
                    }
                }
            }
            return products;
        }

        public List<Product> GetProductFromCharacteristicHasTeeth(int boolean)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection;
            cmd.CommandText = $"SELECT \"name\", id, price, \"description\", photo_path FROM Products WHERE hasTeeth = {boolean}";
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
                        product.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        products.Add(product);
                    }
                }
            }
            return products;
        }

        public List<Product> GetProductFromCharacteristicHasOxygen(int boolean)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection;
            cmd.CommandText = $"SELECT \"name\", id, price, \"description\", photo_path FROM Products WHERE hasOxygenBottle = {boolean}";
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
                        product.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        products.Add(product);
                    }
                }
            }
            return products;
        }

        public List<Product> GetProductFromCharacteristicIsIncontinent(int boolean)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection;
            cmd.CommandText = $"SELECT \"name\", id, price, \"description\", photo_path FROM Products WHERE isIncontinent = {boolean}";
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
                        product.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        products.Add(product);
                    }
                }
            }
            return products;
        }

        public List<Product> GetProductFromCharacteristicIsHandicaped(int boolean)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection;
            cmd.CommandText = $"SELECT \"name\", id, price, \"description\", photo_path FROM Products WHERE isHandicaped = {boolean}";
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
                        product.Id = reader.GetInt32(reader.GetOrdinal("id"));
                        products.Add(product);
                    }
                }
            }
            return products;
        }
    }
}