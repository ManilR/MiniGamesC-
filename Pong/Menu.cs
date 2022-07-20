using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lunchLocal(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lunchLocal(2);
        }

        private void lunchLocal(int nbPlayer)
        {
            Form1 f = new Form1(nbPlayer, "Local", null);
            Hide();
            f.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Online f = new Online();
            Hide();
            f.ShowDialog();
            Close();
        }
    }
}
