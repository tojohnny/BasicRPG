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
    public partial class Form1 : Form
    {
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
        // Refresh data
        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
            dataGridView2.Refresh();
            dataGridView3.Refresh();
        }
    }
}
