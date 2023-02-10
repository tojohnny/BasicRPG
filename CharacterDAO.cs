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
        public List<Character> getCharacters(int userID)
        {
            List<Character> allCharacters = new List<Character>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "SELECT * FROM `character` WHERE user_id = @userid";
            command.Parameters.AddWithValue("@userid", userID);
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
                        className = reader.GetString(4),
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

            command.CommandText = "SELECT * FROM `character` WHERE character_name=@searchterm";
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
                    character.className = reader.GetString(4);
                    character.userID = reader.GetInt32(5);
                }
            }
            connection.Close();

            return character;
        }

        // Create new character
        internal int createNewCharacter(Character character)
        {
            List<Character> users = new List<Character>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "INSERT INTO `character`(`character_name`, `character_gender`, `character_race`, `class_name`, `user_id`)" +
                " VALUES (@charactername, @charactergender, @characterrace, @classname, @userid)";
            command.Parameters.AddWithValue("@charactername", character.characterName);
            command.Parameters.AddWithValue("@charactergender", character.characterGender);
            command.Parameters.AddWithValue("@characterrace", character.characterRace);
            command.Parameters.AddWithValue("@classname", character.className);
            command.Parameters.AddWithValue("@userid", character.userID);
            command.Connection = connection;

            var newCharacter = command.ExecuteNonQuery();
            connection.Close();

            return newCharacter;
        }

        // Update Character Last Login
        internal void updateLastLogin(Character character)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "UPDATE character_history SET character_last_login=@timestamp WHERE character_id=@characterid";
            command.Parameters.AddWithValue("@timestamp", DateTime.Now);
            command.Parameters.AddWithValue("@characterid", character.characterID);
            command.Connection = connection;

            int userUpdate = command.ExecuteNonQuery();
            connection.Close();
        }

        public CharacterStat getCharacterStat(Character character)
        {
            CharacterStat characterStat = new CharacterStat();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "SELECT `character_stat_id`, `health_point`, `mana_point`, `strength`, `dexterity`, `intelligence`, `agility`, `character_id`" +
                " FROM `character_stat` WHERE character_id=@searchterm";
            command.Parameters.AddWithValue("@searchterm", character.characterID);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    characterStat.characterStatID = reader.GetInt32(0);
                    characterStat.healthPoint = reader.GetInt32(1);
                    characterStat.manaPoint = reader.GetInt32(2);
                    characterStat.strength = reader.GetInt32(3);
                    characterStat.dexterity = reader.GetInt32(4);
                    characterStat.intelligence = reader.GetInt32(5);
                    characterStat.agility = reader.GetInt32(6);
                    characterStat.characterID = reader.GetInt32(7);
                }
                connection.Close();

                return characterStat;
            }
        }

        public CharacterLevel getCharacterLevel(Character character)
        {
            CharacterLevel characterLevel = new CharacterLevel();
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand();

            command.CommandText = "SELECT `character_level_id`, `character_level`, `character_experience_point`, `character_id`" +
                " FROM `character_level` WHERE character_id=@searchterm";
            command.Parameters.AddWithValue("@searchterm", character.characterID);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    characterLevel.levelID = reader.GetInt32(0);
                    characterLevel.level = reader.GetInt32(1);
                    characterLevel.experiencePoint = reader.GetInt32(2);
                    characterLevel.characterID = reader.GetInt32(3);
                }
                connection.Close();

                return characterLevel;
            }
        }
    }
}
