using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoustGame
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            string exePath = System.IO.Directory.GetCurrentDirectory();
            System.Media.SoundPlayer mediaPlayer = new System.Media.SoundPlayer();
            mediaPlayer = new System.Media.SoundPlayer(exePath + "\\music.wav");
            mediaPlayer.PlayLooping();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game g = new Game();
            Hide();
            g.ShowDialog();
            Close();
        }
    }
}
