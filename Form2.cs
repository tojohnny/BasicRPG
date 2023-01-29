using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicRPG
{
    public partial class Form2 : Form
    {
        // New User Registration Form Initialization
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
        // Register Button
        private void button1_Click(object sender, EventArgs e)
        {
            bool isValidUsername = false;
            bool isValidPassword = false;
            bool isValidEmail = false;
            
            // Check for valid unique username.
            UserDAO userDAO = new UserDAO();
            List<User> existingUser = new List<User>();
            existingUser = userDAO.searchUsers(textBox1.Text);

            if (existingUser.Any() == false)
            {
                isValidUsername = true;
            }
            else if (textBox1.Text == "")
            {
                string message = "Username field empty." + "\n" + "Please enter a username.";
                string title = "Username Field Empty";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }
            else
            {
                string message = "Username unavailable." + "\n" + "Please choose a different username.";
                string title = "Username Unavailable";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                textBox1.Text = null;
            }
            // Check for valid password, no restrictions besides null field.
            if (textBox2.Text != textBox3.Text)
            {
                string message = "Passwords do not match, please re-enter password.";
                string title = "Password Field Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                textBox2.Text = null;
                textBox3.Text = null;
            } 
            else if (textBox2.Text == "" || textBox3.Text == "")
            {
                string message = "One or more password fields are empty, please enter a re-enter a valid password.";
                string title = "Password Field Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                textBox2.Text = null;
                textBox3.Text = null;
            } 
            else if (textBox2.Text != "" && textBox3.Text != "" && textBox2.Text == textBox3.Text)
            {
                isValidPassword = true;
            }

            // Check for valid email.
            bool IsValidEmail(string email)
            {
                var trimmedEmail = email.Trim();

                if (trimmedEmail.EndsWith("."))
                {
                    return false; // suggested by @TK-421
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
            //TODO: Add a check for unique e-mail address.
            if (textBox4.Text == "" || textBox5.Text == "")
            {
                string message = "One or more e-mail fields are empty, please enter a re-enter a valid password.";
                string title = "E-mail Field Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                textBox2.Text = null;
                textBox3.Text = null;
            }
            else if (textBox4.Text != textBox5.Text)
            {
                string message = "E-mails do not match, please re-enter e-mail address.";
                string title = "E-mail Field Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                textBox4.Text = null;
                textBox5.Text = null;
            }
            else if (IsValidEmail(textBox5.Text) == false)
            {
                string message = "Invalid e-mail, please enter a valid e-mail address.";
                string title = "Invalid e-mail address";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                textBox4.Text = null;
                textBox5.Text = null;
            }
            else if (textBox4.Text != "" && textBox5.Text != "" && textBox4.Text == textBox5.Text && IsValidEmail(textBox5.Text) == true)
            {
                isValidEmail = true;
            }
            
            // If everything is valid, then submit register new user to the database.
            if (isValidUsername == true && isValidPassword == true && isValidEmail == true)
            {
                string encryptedPassword = ComputeSha256Hash((string)textBox2.Text);

                User user = new User
                {
                    username = textBox1.Text,
                    password = encryptedPassword,
                    email = textBox5.Text,
                };

                int result = userDAO.registerNewUser(user);

                string message = "Registration completed.";
                string title = "Successful Registration";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            }
        }
    }
}
