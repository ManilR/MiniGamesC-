using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    public partial class Online : Form
    {
        public Online()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int ID = rand.Next(10000);
            string path = @"M:\developpement-Manil\pong\GAME"+ ID.ToString() +".txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (FileStream fs = File.Create(path))
            {
                fs.Close();
                //Program.AddText(fs, "ID : " + ID.ToString() + "\n");
                //Program.AddText(fs, "Message secret");
                Form1 f = new Form1(1, "Online", path);
                Hide();
                f.ShowDialog();
                Close();
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = @"M:\developpement-Manil\pong\GAME" + textID.Text + ".txt";
            if (!File.Exists(path))
            {
                MessageBox.Show("Erreur : aucune partie ne possède cet ID");
            }
            else
            {
                Form1 f = new Form1(2, "Online", path);
                Hide();
                f.ShowDialog();
                Close();
                //FileStream fs = File.OpenRead(path);
                //string fileContent;
                //using (StreamReader reader = new StreamReader(fs))
                //{
                //    fileContent = reader.ReadToEnd();
                //    MessageBox.Show(fileContent);
                //    fs.Close();
                //}
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
