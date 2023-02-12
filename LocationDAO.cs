using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRPG
{
    internal class LocationDAO
    {
        // Connect to local MySQL Database.
        string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=basicrpg";

        // Get location
        public Location getCurrentLocation(int locationID)
        {
            Location currentLocation = new Location();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "SELECT * FROM `location` WHERE location_id = @locationid";
            command.Parameters.AddWithValue("@locationid", locationID);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    currentLocation.locationID = reader.GetInt32(0);
                    currentLocation.locationName = reader.GetString(1);
                    currentLocation.isSafeZone = reader.GetBoolean(2);
                }
                connection.Close();

                return currentLocation;
            }
        }
    }
}
