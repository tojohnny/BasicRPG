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

        // Get all users
        public List<User> getUsers()
        {
            List<User> users = new List<User>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.CommandText = "SELECT player_id, username, password, email FROM USERS";
            mySqlCommand.Connection = connection;

            using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    User user = new User
                    {
                        playerID = reader.GetInt32(0),
                        username = reader.GetString(1),
                        password = reader.GetString(2),
                        email = reader.GetString(3),
                    };
                    users.Add(user);
                }
            }
            connection.Close();

            return users;
        }

        // Get specific user
        public User getUser(string username)
        {
            User user = new User();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "SELECT * FROM users WHERE username=@username";
            command.Parameters.AddWithValue("@username", username);
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
            command.CommandText = "INSERT INTO USERS (USERNAME, PASSWORD, EMAIL)  VALUES (@username, @password, @email)";
            command.Parameters.AddWithValue("@username", user.username);
            command.Parameters.AddWithValue("@password", user.password);
            command.Parameters.AddWithValue("@email", user.email);
            command.Connection = connection;

            int newUser = command.ExecuteNonQuery();
            connection.Close();

            return newUser;
        }

        internal User getEmail(string email)
        {
            User user = new User();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "SELECT * FROM users WHERE email=@email";
            command.Parameters.AddWithValue("@email", email);
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
    }
}
