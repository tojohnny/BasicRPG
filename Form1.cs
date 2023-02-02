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

        private static Form1 form1;
        public static Form1 GetInstance()
        {
            if (form1 == null)
            {
                form1 = new Form1();
            }

            return form1;
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

                dataGridView1.Columns[0].HeaderText = "Player ID";
                dataGridView1.Columns[1].HeaderText = "Username";
                dataGridView1.Columns[2].Visible = false; // Password
                dataGridView1.Columns[3].HeaderText = "Email";

                dataGridView1.Refresh();

            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show(
                    "Canceled login, please register if you are a new user.",
                    "Login Canceled");
            }
        }

        // Account Information
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
