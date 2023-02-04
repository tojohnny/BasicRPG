using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRPG
{
    internal class CharacterDAO
    {
        // Connect to local MySQL Database.
        string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=basicrpg";

        // Get all characters
        public List<Character> getCharacters()
        {
            List<Character> allCharacters = new List<Character>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "SELECT * FROM character";
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Character character = new Character
                    {
                        characterID = reader.GetInt32(0),
                        characterName = reader.GetString(1),
                        characterGender = reader.GetString(2),
                        characterRace = reader.GetString(3),
                        classID = reader.GetInt32(4),
                        userID = reader.GetInt32(5),
                    };
                    allCharacters.Add(character);
                }
                connection.Close();

                return allCharacters;
            }
        }
        // Get specific character
        public Character getCharacter(string searchTerm)
        {
            Character character = new Character();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "SELECT * FROM character WHERE character_name=@searchterm";
            command.Parameters.AddWithValue("@searchterm", searchTerm);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    character.characterID = reader.GetInt32(0);
                    character.characterName = reader.GetString(1);
                    character.characterGender = reader.GetString(2);
                    character.characterRace = reader.GetString(3);
                    character.classID = reader.GetInt32(4);
                    character.userID = reader.GetInt32(5);
                }
            }
            connection.Close();

            return character;
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
