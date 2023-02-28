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

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT `slots.*` " +
                "FROM `inventory_slots` slots " +
                "JOIN `inventory_slot_has_item islot` ON `slots.inventory_slot_id` = `islot.inventory_slot_id` " +
                "JOIN `item it` ON `islot.item_id` = `it.item_id` WHERE it.item

            command.Connection = connection;
        }
    }
}
