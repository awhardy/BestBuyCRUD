using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.IO;
using Newtonsoft.Json.Linq;

namespace CrudOperations
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            string jsonText = File.ReadAllText("appsettings.development.json");
#else
            string josonText = File.ReadAllText("appsettings.release.json")
#endif
            string connStr = JObject.Parse(jsonText)["ConnectionStrings"]["DefaultConnection"].ToString();

            ProductRepository prod = new ProductRepository(connStr);

            ProductRepository repo = new ProductRepository(connStr);
        }
    }
}
