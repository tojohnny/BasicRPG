using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BasicRPG
{
    public partial class Form3 : Form
    {
        public BindingSource userBindingSource = new BindingSource();
        public BindingSource characterBindingSource = new BindingSource();

        // Login Initialization
        public Form3()
        {
            InitializeComponent();
        }

        // Login Button
        public void button1_Click(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            CharacterDAO characterDAO = new CharacterDAO();

            User existingUser = new User();

            List<User> existingUserList = new List<User>();
            List<Character> characterList = new List<Character>();

            existingUser = userDAO.getUser(textBox1.Text);
            

            if (existingUser.username == textBox1.Text)
            {
                string encryptedPassword = PasswordHash.ComputeSha256Hash((string)textBox2.Text);

                if (existingUser.password == encryptedPassword)
                {
                    MessageBox.Show("Welcome back, " + existingUser.username + ".");

                    userDAO.updateLastLogin(existingUser);
                    existingUserList.Add(existingUser);
                    userBindingSource.DataSource = existingUserList;

                    characterList = characterDAO.getCharacters(existingUser.playerID);
                    characterBindingSource.DataSource = characterList;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect Password.\n" + "Please re-enter password.",
                                    "Password Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                    textBox2.Text = null;
                }
            }
            else
            {
                MessageBox.Show("Invalid username.\n" + "Are you sure you registered?\n" + "If not, please register an account.",
                                "Invalid Username",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                textBox1.Text = null;
                textBox2.Text = null;
            }
        }
    }
}