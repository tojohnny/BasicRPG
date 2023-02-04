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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        // Create button
        private void button1_Click(object sender, EventArgs e)
        {
            UserDAO userDAO = new UserDAO();
            Character newCharacter = new Character();
            CharacterHistory history = new CharacterHistory();


        }
    }
}
