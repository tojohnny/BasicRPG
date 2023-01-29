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
                        password = reader.GetString(2),
                        email = reader.GetString(3),
                    };
                    users.Add(user);
                }
            }
            connection.Close();
            return users;
        }

        internal List<User> getUser(string username)
        {
            List<User> users = new List<User>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string searchWildPhrase = "%" + username + "%";

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "SELECT USERNAME, FROM USERS WHERE USERNAME LIKE @searchText";
            command.Parameters.AddWithValue("@searchText", searchWildPhrase);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    User user = new User
                    {
                        username = reader.GetString(0),
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
            command.CommandText = "INSERT INTO USERS (USERNAME, PASSWORD, EMAIL)  VALUES (@username, @password, @email)";
            command.Parameters.AddWithValue("@username", user.username);
            command.Parameters.AddWithValue("@password", user.password);
            command.Parameters.AddWithValue("@email", user.email);
            command.Connection = connection;

            int newUser = command.ExecuteNonQuery();
            connection.Close();

            return newUser;
        }

        internal List<User> searchUsers(string searchUser)
        {
            List<User> users = new List<User>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string searchWildPhrase = "%" + searchUser + "%";

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT USERNAME, PASSWORD, EMAIL FROM USERS WHERE USERNAME LIKE @searchText";
            command.Parameters.AddWithValue("@searchText", searchWildPhrase);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    User user = new User
                    {
                        username = reader.GetString(0),
                        password = reader.GetString(1),
                        email = reader.GetString(2)
                    };
                    users.Add(user);
                }
            }
            connection.Close();

            return users;
        }
    }
}
