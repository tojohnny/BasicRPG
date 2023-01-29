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
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            List<User> existingUser = new List<User>();
            existingUser = userDAO.searchUsers(textBox1.Text);
            string inputPassword = Form2.ComputeSha256Hash((string)textBox2.Text);
            try
            {
                if (existingUser[0].username == textBox1.Text)
                {
                    if (existingUser[0].password == inputPassword)
                    {
                        MessageBox.Show("Succesful login, welcome back " + existingUser[0].username + ".", "Login Success");
                        Form1 form1 = new Form1();
                        userDAO.getUser(existingUser[0].username);
                    }
                    else
                    {
                        string message = "Incorrect password, try again.";
                        string title = "Incorrect Password";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                        textBox2.Text = null;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                string message = "Username does not exist";
                string title = "Username Field Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                textBox1.Text = null;
            }
        }
    }
}