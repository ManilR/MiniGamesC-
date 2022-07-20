using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pendu
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1("Facile");
            Hide();
            f.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1("Moyen");
            Hide();
            f.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1("Difficile");
            Hide();
            f.ShowDialog();
            Close();
        }
    }
}
