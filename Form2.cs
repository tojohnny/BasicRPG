using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicRPG
{
    public partial class Form2 : Form
    {
        // New User Registration Initialization
        public Form2()
        {
            InitializeComponent();
        }

        // SHA256 Encryption
        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // E-mail format validation
        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        // Register Button
        private void button1_Click(object sender, EventArgs e)
        {
            bool isValidUsername = false;
            bool isValidPassword = false;
            bool isValidEmail = false;

            UserDAO userDAO = new UserDAO();
            List<User> existingUser = new List<User>();
            existingUser = userDAO.searchUsers(textBox1.Text);
            
            // Username validation.
            if (textBox1.Text == "")
            {
                MessageBox.Show(
                    "Username field empty." + "\n" + "Please enter a username.",
                    "Username Field Empty",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else if (Regex.IsMatch(textBox1.Text, "^[a-zA-Z0-9]*$") == false)
            {
                MessageBox.Show(
                    "Username contains non-alphanumeric characters." + "\n" + "Please choose a different username.",
                    "Invalid Username",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBox1.Text = null;
            }
            else if (existingUser.Any() == false)
            {
                isValidUsername = true;
            }
            else
            {
                MessageBox.Show(
                    "Username already exists." + "\n" + "Please choose a different username.",
                    "Username Unavailable",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBox1.Text = null;
            }

            // Password validation.
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show(
                    "Passwords do not match, please re-enter password.",
                    "Password Field Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBox2.Text = null;
                textBox3.Text = null;
            } 
            else if (textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show(
                    "One or more password fields are empty, please enter a re-enter a valid password.",
                    "Password Field Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBox2.Text = null;
                textBox3.Text = null;
            } 
            else if (textBox2.Text != "" && textBox3.Text != "" && textBox2.Text == textBox3.Text)
            {
                isValidPassword = true;
            }

            // Email validation.
            if (textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show(
                    "One or more e-mail fields are empty, please enter a re-enter a valid password.",
                    "E-mail Field Error",
                    MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);

                textBox4.Text = null;
                textBox5.Text = null;
            }
            else if (textBox4.Text != textBox5.Text)
            {
                MessageBox.Show(
                    "E-mails do not match, please re-enter e-mail address.",
                    "E-mail Field Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBox4.Text = null;
                textBox5.Text = null;
            }
            else if (IsValidEmail(textBox5.Text) == false)
            {
                MessageBox.Show(
                    "Invalid e-mail, please enter a valid e-mail address.",
                    "Invalid e-mail address",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                textBox4.Text = null;
                textBox5.Text = null;
            }
            else if (textBox4.Text != "" && textBox5.Text != "" && textBox4.Text == textBox5.Text
                && IsValidEmail(textBox5.Text) == true)
            {
                isValidEmail = true;
            }

            // If everything is valid, then submit.
            if (isValidUsername == true && isValidPassword == true && isValidEmail == true)
            {
                string encryptedPassword = ComputeSha256Hash((string)textBox2.Text);

                User user = new User
                {
                    username = textBox1.Text,
                    password = encryptedPassword,
                    email = textBox5.Text,
                };

                try
                {
                    int result = userDAO.registerNewUser(user);

                    MessageBox.Show(
                        "Registration completed.",
                        "Successful Registration",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (MySqlException)
                {
                    MessageBox.Show(
                        "E-mail already exists." + "\n" + "Please use a different E-mail address.",
                        "E-mail Unavailable", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);

                    textBox4.Text = null;
                    textBox5.Text = null;
                }
            }
        }
    }
}
