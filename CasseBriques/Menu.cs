﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CasseBriques
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1("normal");
            Hide();
            f.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1("hard");
            Hide();
            f.ShowDialog();
            Close();
        }
    }
}
