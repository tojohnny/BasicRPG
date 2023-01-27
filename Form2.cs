using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicRPG
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

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
                //TODO: ADD SHA-256 encryption to password before appending to database.
                User user = new User
                {
                    username = textBox1.Text,
                    password = textBox2.Text
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
