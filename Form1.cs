using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicRPG
{
    public partial class Form1 : Form
    {
        private static List<Character> loadedCharacter = new List<Character>();

        // BasicRPG Initialization
        public Form1()
        {
            InitializeComponent();
        }

        // New User Registration Button
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you a new user? Click Yes to start registration." + "\n" + "Returning users please login.",
                "New User Registration",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                var form2 = new Form2();
                form2.Owner = this;
                form2.ShowDialog();
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show(
                    "Canceled registration, please login if you are a returning user.",
                    "Registration Canceled");
            }
        }

        // Login Button
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you a returning user? Click yes to login." + "\n" + "New users please register.",
                "Returning User Login",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                var form3 = new Form3();
                form3.Owner = this;
                form3.ShowDialog();

                dataGridView1.DataSource = form3.userBindingSource;
                dataGridView2.DataSource = form3.characterBindingSource;

                dataGridView1.Columns[0].HeaderText = "Player ID";
                dataGridView1.Columns[1].HeaderText = "Username";
                dataGridView1.Columns[2].Visible = false; // Password
                dataGridView1.Columns[3].HeaderText = "Email";

                dataGridView2.Columns[0].HeaderText = "ID";
                dataGridView2.Columns[1].HeaderText = "Name";
                dataGridView2.Columns[2].HeaderText = "Gender";
                dataGridView2.Columns[3].HeaderText = "Race";
                dataGridView2.Columns[4].HeaderText = "Class";
                dataGridView2.Columns[5].Visible = false; // User ID


                dataGridView1.Refresh();
                dataGridView2.Refresh();
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show(
                    "Canceled login, please register if you are a new user.",
                    "Login Canceled");
            }
        }

        // New Character Button
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to create a new character?",
                                                  "Character Creator",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Information,
                                                  MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                var form4 = new Form4();
                form4.Owner = this;
                form4.ShowDialog();
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Canceled login, please register if you are a new user.",
                                "Login Canceled");
            }
        }

        // Load Character
        private void button6_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            string timestamp = time.ToString();

            CharacterDAO characterDAO = new CharacterDAO();
            CharacterStat loadedCharacterStats = new CharacterStat();
            CharacterLevel loadedCharacterLevel = new CharacterLevel();
            LocationDAO locationDAO = new LocationDAO();
            Location currentLocation = new Location();
            Wealth currentWealth = new Wealth();

            if (loadedCharacter.Any() == true)
            {
                loadedCharacter.Clear();
            }

            var rowClicked = dataGridView2.CurrentCell.RowIndex;
            Character loadCharacter = new Character
            {
                characterID = (int)dataGridView2.Rows[rowClicked].Cells[0].Value,
                characterName = (string)dataGridView2.Rows[rowClicked].Cells[1].Value,
                characterGender = (string)dataGridView2.Rows[rowClicked].Cells[2].Value,
                characterRace = (string)dataGridView2.Rows[rowClicked].Cells[3].Value,
                className = (string)dataGridView2.Rows[rowClicked].Cells[4].Value,
            };
            loadedCharacter.Add(loadCharacter);
            characterDAO.updateLastLogin(loadCharacter);
            groupBox1.Text = loadCharacter.characterName;

            loadedCharacterStats = characterDAO.getCharacterStat(loadCharacter);
            loadedCharacterLevel = characterDAO.getCharacterLevel(loadCharacter);
            currentLocation = locationDAO.getCurrentLocation(loadCharacter.characterID);
            currentWealth = characterDAO.getCharacterWealth(loadCharacter.characterID);

            label9.Text = loadedCharacterStats.healthPoint.ToString();
            label10.Text = loadedCharacterStats.manaPoint.ToString();
            label11.Text = loadedCharacterStats.strength.ToString();
            label12.Text = loadedCharacterStats.dexterity.ToString();
            label13.Text = loadedCharacterStats.intelligence.ToString();
            label14.Text = loadedCharacterStats.agility.ToString();

            label17.Text = loadedCharacterLevel.level.ToString();
            label18.Text = loadedCharacterLevel.experiencePoint.ToString();

            label21.Text = currentLocation.locationName.ToString();
            label22.Text = currentLocation.isSafeZone.ToString();

            label40.Text = currentWealth.goldCoinAmount.ToString();

            MessageBox.Show("Welcome back, " + loadCharacter.characterName + ".",
                            "Character Loaded",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            textBox1.AppendText("[" + (string)timestamp + "] (SYSTEM): " + "Welcome back, " + loadedCharacter[0].characterName + ". ");
            textBox1.AppendText(Environment.NewLine);
        }

        // COMMAND BOX TO CONSOLE
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            DateTime time = DateTime.Now;
            string timestamp = time.ToString();

            if (e.KeyCode == Keys.Enter)
            {
                string modifiedMessage = "[" + (string)timestamp + "] (PLAYER) " + loadedCharacter[0].characterName + ": " + textBox2.Text;
                textBox1.AppendText(modifiedMessage);
                textBox1.AppendText(Environment.NewLine);
                textBox2.Text = null;
            }
        }

        // Edit character name
        private void button4_Click(object sender, EventArgs e)
        {
            var rowClicked = dataGridView2.CurrentCell.RowIndex;

            DialogResult result = MessageBox.Show("Do you want to edit " + dataGridView2.Rows[rowClicked].Cells[1].Value.ToString() + "?",
                            "Edit Character Name",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var form5 = new Form5();
                form5.Owner = this;
                form5.ShowDialog();
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Name Change Canceled.",
                                "Action Canceled",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CharacterDAO characterDAO = new CharacterDAO();
            var rowClicked = dataGridView2.CurrentCell.RowIndex;

            DialogResult result = MessageBox.Show("Do you want to delete " + dataGridView2.Rows[rowClicked].Cells[1].Value.ToString() + "?",
                            "Edit Character Name",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                characterDAO.deleteCharacter((int)dataGridView2.Rows[rowClicked].Cells[0].Value);

                MessageBox.Show("Character " + dataGridView2.Rows[rowClicked].Cells[1].Value + " is deleted.",
                "Character Deletion Success.",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Name Change Canceled.",
                                "Action Canceled",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }
    }
}
