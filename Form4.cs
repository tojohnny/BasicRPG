using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicRPG
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        // Create button
        private void button1_Click(object sender, EventArgs e)
        {
            bool isUniqueCharacter = false;

            CharacterDAO characterDAO = new CharacterDAO();
            CharacterHistory characterHistory = new CharacterHistory();
            List<Character> characterList = new List<Character>();

            Character existingCharacter = new Character();
            existingCharacter = characterDAO.getCharacter(textBox1.Text);

            if (existingCharacter.characterName != null)
            {
                MessageBox.Show("Character already exists, please choose another character name.",
                                "Existing Character Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                textBox1.Text = null;
            } 
            else
            {
                isUniqueCharacter = true;
            }

            if (isUniqueCharacter == true)
            {
                Form1 form1 = Application.OpenForms["Form1"] as Form1;

                Character newCharacter = new Character
                {
                    characterName = textBox1.Text,
                    characterGender = comboBox1.SelectedItem.ToString(),
                    characterRace = comboBox2.SelectedItem.ToString(),
                    className = comboBox3.SelectedItem.ToString(),
                    userID = (int)form1.dataGridView1.Rows[0].Cells[0].Value,
                };

                characterDAO.createNewCharacter(newCharacter);

                MessageBox.Show("New Character " + textBox1.Text + " has been created.",
                                "Character Creation Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                this.Close();
            }
        }
    }
}