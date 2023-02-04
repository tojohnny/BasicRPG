using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BasicRPG
{
    internal class UserDAO
    {
        // Connect to local MySQL Database.
        string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=basicrpg";

        // Get specific user
        public User getUser(string searchTerm)
        {
            User user = new User();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "SELECT * FROM user WHERE username=@searchterm OR email=@searchterm";
            command.Parameters.AddWithValue("@searchterm", searchTerm);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    user.playerID = reader.GetInt32(0);
                    user.username = reader.GetString(1);
                    user.password = reader.GetString(2);
                    user.email = reader.GetString(3);
                }
            }
            connection.Close();

            return user;
        }

        // Add new user
        internal int registerNewUser(User user)
        {
            List<User> users = new List<User>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "INSERT INTO user (username, password, email) VALUES (@username, @password, @email)";
            command.Parameters.AddWithValue("@username", user.username);
            command.Parameters.AddWithValue("@password", user.password);
            command.Parameters.AddWithValue("@email", user.email);
            command.Connection = connection;

            int newUser = command.ExecuteNonQuery();
            connection.Close();

            return newUser;
        }
    }
}
