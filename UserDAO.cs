using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRPG
{
    internal class UserDAO
    {
        // Connect to local MySQL Database.
        string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=basicrpg";

        public List<User> getUsers()
        {
            List<User> users = new List<User>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.CommandText = "SELECT PLAYER_ID, USERNAME, PASSWORD FROM USERS";
            mySqlCommand.Connection = connection;

            using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    User user = new User
                    {
                        playerID = reader.GetInt32(0),
                        username = reader.GetString(1),
                        password = reader.GetString(2)
                    };
                    users.Add(user);
                }
            }
            connection.Close();
            return users;
        }

        internal int registerNewUser(User user)
        {
            List<User> users = new List<User>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "INSERT INTO USERS (USERNAME, PASSWORD)  VALUES (@username, @password)";
            command.Parameters.AddWithValue("@username", user.username);
            command.Parameters.AddWithValue("@password", user.password);
            command.Connection = connection;

            int newUser = command.ExecuteNonQuery();
            connection.Close();

            return newUser;
        }
    }
}
