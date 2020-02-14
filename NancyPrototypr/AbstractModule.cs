using System;
using System.Collections.Generic;
using System.Text;
using Nancy;
using System.Data.SqlClient;

namespace EcoConception
{
    public abstract class AbstractModule : NancyModule
    {
        public Database Database { get; private set; }
        public abstract IEnumerable<Product> Products { get; }
        public abstract IEnumerable<Category> Categories { get; }

        public AbstractModule()
        {

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //builder.InitialCatalog = "BDD";
            // builder.DataSource = "InstanceAddress";
            // builder.UserID = "UserOfTheDatabase";
<<<<<<< HEAD
            builder.ConnectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=Hackathon1;Integrated Security=True";
=======
            builder.ConnectionString = @"Data Source=AG\SQLEXPRESS;Initial Catalog=Hackathon1;Integrated Security=True";
>>>>>>> 8d5f6c50e80eed9495bd164571727d112ca58a2c
            Database = new Database(builder);
            Database.OpenConnection();
        }
    }
}