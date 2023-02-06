﻿using MySqlConnector;
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
                    character.classID = reader.GetInt32(4);
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
            command.CommandText = "INSERT INTO `character`(`character_name`, `character_gender`, `character_race`, `class_id`, `user_id`)" +
                " VALUES (@charactername, @charactergender, @characterrace, @classid, @userid)";
            command.Parameters.AddWithValue("@charactername", character.characterName);
            command.Parameters.AddWithValue("@charactergender", character.characterGender);
            command.Parameters.AddWithValue("@characterrace", character.characterRace);
            command.Parameters.AddWithValue("@classid", character.classID);
            command.Parameters.AddWithValue("@userid", character.userID);
            command.Connection = connection;

            var newCharacter = command.ExecuteNonQuery();
            connection.Close();

            return newCharacter;
        }
    }
}