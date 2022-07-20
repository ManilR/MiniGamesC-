using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Pendu
{
    public partial class Form1 : Form
    {
        string mot;
        int nbErreur = 0;
        int nbBon = 0;
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string usedLetters = "";
        List<Label> labels = new List<Label>();
        public Form1(string difficulty)
        {
            InitializeComponent();

            //LECTURE D'UN FICHIER JSON EN LIGNE
            StreamReader reader;
            using (WebClient client = new WebClient())
            {

                client.Proxy = WebRequest.DefaultWebProxy;
                client.UseDefaultCredentials = true;
                client.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

                Stream stream = client.OpenRead("https://raw.githubusercontent.com/words/an-array-of-french-words/master/index.json");
                reader = new StreamReader(stream);
            }
            using (reader)
            {
                string content = reader.ReadToEnd();
                List<string> data = JsonConvert.DeserializeObject<List<string>>(content);
                List<string> words = new List<string>();
                foreach (string s in data)
                {
                    if (difficulty == "Facile"  && s.Length < 5)
                        words.Add(s);
                    if (difficulty == "Moyen" && s.Length > 4 && s.Length <9)
                        words.Add(s);
                    if (difficulty == "Difficile" && s.Length > 8)
                        words.Add(s);
                }
                if(words.Count <= 0)
                {
                    MessageBox.Show("Erreur création dictionnaire");
                    this.Close();
                }

                string exePath = Application.ExecutablePath;
                string path = exePath.Substring(0, exePath.Length - 9) + "\\Dictionnaire.txt";
                File.WriteAllLines(path, data);


                Random rand = new Random();
                mot = words[rand.Next(words.Count)];
            }


            //LECTURE D'UN FICHIER TXT EN LOCAL
            //string exePath = Application.ExecutablePath;
            ////string path = exePath.Substring(0, exePath.Length - 9) + "\\Dictionnaire" + difficulty + ".txt";
            //string path = exePath.Substring(0, exePath.Length - 9) + "\\test" + ".txt";
            //if (!File.Exists(path))
            //{
            //    MessageBox.Show("Erreur fichier");
            //    this.Close();
            //}
            //else
            //{
            //    string[] data = File.ReadAllLines(path);
            //    Random rand = new Random();
            //    mot = data[rand.Next(data.Length)];
            //}

            startHUD();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        
        private void startHUD()
        {
            foreach (var panel in this.Controls.OfType<Panel>())
            {
                if (panel.Name.Contains("pendu"))
                    panel.Visible = false;
            }
            for (int i = 0; i < mot.Length; i++)
            {
                Panel panel = new Panel();
                panel.Location = new Point(200 + 60*i, 300);
                panel.Size = new Size(50, 10);
                panel.BackColor = Color.Black;
                panel.Visible = true;
                this.Controls.Add(panel);

                Label label = new Label();
                label.Location = new Point(200 + 60 * i, 260);
                label.Size = new Size(50, 50);
                label.BackColor = Color.Transparent;
                label.Visible = true;
                label.Font = new Font("Arial", textBox1.Font.Size + 5);
                label.Text = "";
                if (mot.ToCharArray()[i] == '-')
                {
                    label.Text = "-";
                    nbBon++;
                }
                    
                label.Name = "Letter" + i.ToString();
                labels.Add(label);
                this.Controls.Add(label);
            }
            int j = 0;
            foreach(char c in alphabet)
            {
                Button label = new Button();
                label.Location = new Point(10 + 40 * j, 30);
                label.Size = new Size(35, 35);
                label.ForeColor = Color.Black;
                label.BackColor = Color.LightGray;
                label.Text = c.ToString();
                label.Font = new Font("Arial", textBox1.Font.Size -1);
                label.Name = c.ToString();
                label.Visible = true;
                label.Click += new EventHandler(letterButton_click);
                this.Controls.Add(label);

                j++;
            }

            

        }

        private void letterButton_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox1.Text = button.Name;
        }
        static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder
                .ToString()
                .Normalize(NormalizationForm.FormC);
        }
        private void chkButton_Click(object sender, EventArgs e)
        {
            char letter = textBox1.Text.ToCharArray()[0];
            bool appear = false;
            for (int i = 0; i < mot.Length; i++)
            {
                char c = RemoveDiacritics(mot).ToCharArray()[i];
                if((c == letter || c == Char.ToLower(letter)))
                {
                    appear = true;
                    if (!usedLetters.Contains(letter))
                    {
                        labels.ToArray()[i].Text = Char.ToUpper(c).ToString();

                        nbBon++;
                        
                        foreach (var label in this.Controls.OfType<Button>())
                        {
                            if (label.Text.Contains(letter) && label.Name.Length == 1)
                            {
                                label.ForeColor = Color.Green;
                                label.BackColor = Color.Black;
                            }
                        }
                    }
                }
 
            }
            
            if (!appear && !usedLetters.Contains(letter))
            {
                foreach (var label in this.Controls.OfType<Button>())
                {
                    if (label.Text.Contains(letter) && label.Text.Length == 1)
                    {
                        label.ForeColor = Color.Red;
                        label.BackColor = Color.Black;
                    }

                }

                nbErreur++;

                foreach (var panel in this.Controls.OfType<Panel>())
                {
                    if (panel.Name == "pendu" + nbErreur.ToString())
                        panel.Visible = true;
                }
            }
            usedLetters = usedLetters + letter.ToString();

            if (nbBon == mot.Length)
                endGame("Bravo vous avez gagné !");

            if (nbErreur == 10)
                endGame("Vous avez perdu ! Le mot était : " + mot);
                
        }

        private void endGame(string msg)
        {
            MessageBox.Show(msg);
            Menu m = new Menu();
            Hide();
            m.ShowDialog();
            Close();
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            TextBox currentContainer = ((TextBox)sender);
            int caretPosition = currentContainer.SelectionStart;

            currentContainer.Text = currentContainer.Text.ToUpper();
            currentContainer.SelectionStart = caretPosition++;

            string s = textBox1.Text;
            if (s.Length > 1)
                s = s.Substring(1, s.Length - 1);

            textBox1.Text = s;

            if (!alphabet.Contains(textBox1.Text))
                textBox1.Text = "";
        }
    }
}
