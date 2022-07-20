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

namespace TicTacToe
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
            string exePath = Application.ExecutablePath;
            string path = exePath.Substring(0, exePath.Length - 13) +  "GAMES\\GAME" + ID.ToString();
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (FileStream fs = File.Create(path))
            {
                fs.Close();

                string[] data = new string[16+8];
                for (int i = 0; i < 16 + 5; i++)
                {
                    data[i] = "0";
                }
                data[16] = "1";
                data[16 + 4] = "1";
                if (textName.Text != "")
                    data[16 + 4 + 1] = textName.Text;
                else
                    data[16 + 4 + 1] = "JOUEUR 1";
                File.WriteAllLines(path, data);
                Form1 f = new Form1(1, "Online", path); 
                Hide();
                f.ShowDialog();
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string exePath = Application.ExecutablePath;
            string path = exePath.Substring(0, exePath.Length - 13) + "GAMES\\GAME" + textID.Text.ToString();
            if (!File.Exists(path))
            {
                MessageBox.Show("Erreur : aucune partie ne possède cet ID");
            }
            else
            {
                string[] data = File.ReadAllLines(path);
                if(Int32.Parse(data[16 + 4]) >= 3)
                {
                    MessageBox.Show("Partie pleine");
                    return;
                }

                data[16 + 4] = (Int32.Parse(data[16 + 4])+1).ToString();
                if (textName.Text != "")
                    data[16 + 4 + Int32.Parse(data[16 + 4])] = textName.Text;
                else
                    data[16 + 4 + Int32.Parse(data[16 + 4])] = "JOUEUR " + data[16 + 4];
                File.WriteAllLines(path, data);
                Form1 f = new Form1(Int32.Parse(data[16 + 4]), "Online", path);
                Hide();
                f.ShowDialog();
                Close();
            }
        }

        private void Online_Load(object sender, EventArgs e)
        {

        }

        private void textName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
