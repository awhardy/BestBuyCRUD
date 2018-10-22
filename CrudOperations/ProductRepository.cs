using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.IO;
using Newtonsoft.Json.Linq;

namespace CrudOperations
{
    public class ProductRepository
    {
        public ProductRepository(string connectionString)
        {
            connStr = connectionString;
        }
        private string connStr;


        public void CreateProduct(string Name, decimal Price, int catID)
        {
            MySqlConnection conn = new MySqlConnection(connStr);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO products (Name, Price, CategoryID) " +
                                  "VALUES(@n, @p, @cID);";
                cmd.Parameters.AddWithValue("n", Name);
                cmd.Parameters.AddWithValue("p", Price);
                cmd.Parameters.AddWithValue("cID", catID);

                cmd.ExecuteNonQuery();

            }
        }


        public Product ReadProduct(int id)
        {
            MySqlConnection conn = new MySqlConnection(connStr);

            using (conn)
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ProductID, Name, Price " +
                                    "FROM products " +
                                    "WHERE ProductID=" + id;

                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    Product product = new Product()
                    {
                        Name = dataReader["Name"].ToString(),
                        ProductId = (int)dataReader["ProductID"],
                        Price = (decimal)dataReader["Price"]
                    };

                    return product;
                }
                else
                {
                    return null;

                }
            }
        }


        public void UpdateProduct(Product prod)
        {
            var conn = new MySqlConnection(connStr);

            using (conn)
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE products " +
                                  "SET Name = @n, Price = @p, CategoryId = @cID " +
                                  "WHERE ProductId = @pID;";
                cmd.Parameters.AddWithValue("n", prod.Name);
                cmd.Parameters.AddWithValue("p", prod.Price);
                cmd.Parameters.AddWithValue("cID", prod.CategoryId);
                cmd.Parameters.AddWithValue("pID", prod.ProductId);
                cmd.ExecuteNonQuery();
            }
        }


        public void DeleteProduct(int id)
        {
            var conn = new MySqlConnection(connStr);

            using (conn)
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM products WHERE ProductID = @id;";
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
