using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.IO;
using Newtonsoft.Json.Linq;

namespace CrudOperations
{
    class ProductRepository
    {
        public ProductRepository(string connectionString)
        {
            connStr = connectionString;
        }

        private string connStr;
    }
}
