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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        // Change name button
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = Application.OpenForms["Form1"] as Form1;
            var rowClicked = form1.dataGridView2.CurrentCell.RowIndex;

            CharacterDAO characterDAO = new CharacterDAO();

            if (characterDAO.getCharacter(textBox1.Text).characterName == null)
            {
                characterDAO.changeCharacterName(textBox1.Text, (int)form1.dataGridView2.Rows[rowClicked].Cells[0].Value);
                MessageBox.Show("Character name successfully changed from " + form1.dataGridView2.Rows[rowClicked].Cells[1].Value + " to " + textBox1.Text,
                                "Name Change Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Character already exists, please choose another character name.",
                "Existing Character Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

                textBox1.Text = null;
            }
        }
    }
}
