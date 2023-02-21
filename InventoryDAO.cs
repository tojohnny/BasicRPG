using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRPG
{
    internal class InventoryDAO
    {
        // Connect to local MySQL Database.
        string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=basicrpg";

        internal void giveStarterPackage()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();


        }
    }
}
