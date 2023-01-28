using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            if (textBox2.Text != textBox3.Text)
            {
                string message = "Passwords do not match, please re-enter password.";
                string title = "Password Field Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                textBox2.Text = null;
                textBox3.Text = null;
            }
            else
            {
                string encryptedPassword = ComputeSha256Hash((string)textBox2.Text);

                User user = new User
                {
                    username = textBox1.Text,
                    password = encryptedPassword,
                };

                UserDAO userDAO = new UserDAO();
                int result = userDAO.registerNewUser(user);

                string message = "Registration completed.";
                string title = "Successful Registration";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            }
        }
    }
}
