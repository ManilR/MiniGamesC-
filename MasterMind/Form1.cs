using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterMind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void KeyDown(object sender, KeyEventArgs e)
        {


            

        }

        private List<Button> buttonList = new List<Button>();
        private int nbBoutons = 4;
        private int chrono;
        private void Form1_Load(object sender, EventArgs e)
        {
            chrono = 60000; //60 secondes
            timer1.Start();

            Color color = Color.Red;

            int left = (int)(this.Width * 0.25);
            int top = (int)(this.Height * 0.8);
            int width = (int)(this.Width * 0.09);
            int height = (int)(this.Height * 0.08);

            for (int i = 0; i < nbBoutons; i++)
            {
                
                Button button = new Button();
                button.Location = new Point(left, top);
                button.Size = new Size(width, height);
                button.Name = "colorButton" + (i + 1).ToString();
                button.Enabled = true;
                button.Visible = true;                
                button.BackColor = color;
                button.Click += new System.EventHandler(buttonColor_Click);

                buttonList.Add(button);
                this.Controls.Add(button);
                this.ResumeLayout(false);
                this.PerformLayout();
                left += (int)(this.Width * 0.1); ;
            }

            buttonPlay.BackColor = Color.White;
            buttonPlay.Location = new Point((int)(this.Width * 0.05), top);
            Program.defineGoal(nbBoutons);
            

        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Program.changeColor(button.BackColor);
        }
       

        private void button5_Click(object sender, EventArgs e)
        {
            Color[] tryColors = new Color[nbBoutons];
            for(int i = 0; i < nbBoutons; i++)
            {
                tryColors[i] = buttonList.ToArray()[i].BackColor;
            }
            int nbGoob = Program.checkTry(tryColors, nbBoutons)[0];
            int nbBadPlace = Program.checkTry(tryColors, nbBoutons)[1];

            addPanels(tryColors, nbGoob, nbBadPlace);


            if (nbGoob == nbBoutons)
            {
                timer1.Stop();
                MessageBox.Show("VICTOIRE");
                this.Close();
            }
            Program.nbTours++;
            if (Program.checkDefeat())
            {
                timer1.Stop();
                showCode();
                MessageBox.Show("DEFAITE : PLUS DE TOURS");
                this.Close();
            }
            
        }

        private void addPanels(Color[] colorTab, int nbGood, int nbBadPlace)
        {
            int left = (int)(this.Width * 0.25);
            int top = (int)(this.Height * 0.05) +((int)(this.Height * 0.09) * Program.nbTours);
            int width = (int)(this.Width * 0.09);
            int height = (int)(this.Height * 0.08);


            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.Location = new Point(left, top);
            flow.Size = new Size(width * 7, height);
            

            for (int i = 0; i < nbBoutons; i++)
            {

                Panel panel = new Panel();
                panel.Location = new System.Drawing.Point(left, top);
                panel.Size = new System.Drawing.Size(width, height);
                panel.Name = "panel" + Program.nbTours.ToString() + (i + 1).ToString();
                panel.Enabled = true;
                panel.Visible = true;
                panel.BackColor = colorTab[i];
                //this.Controls.Add(panel);
                flow.Controls.Add(panel);
                left += 80;
            }
            TextBox text = new TextBox();
            text.Multiline = true;
            text.Location = new Point(left, top);
            text.Size = new Size(70, 20);
            text.Name = "text1" + (Program.nbTours + 1).ToString();
            text.Text = nbGood.ToString() + " bien placé(s) ";
            text.ReadOnly = true;
            
            //this.Controls.Add(text);
            TextBox text2 = new TextBox();
            text.Multiline = true;
            text2.Location = new Point(left + 100, top);
            text2.Size = new Size(70, 20);
            text2.Name = "text2" + (Program.nbTours + 1).ToString();
            text2.Text =  nbBadPlace.ToString() + " mal placé(s)";
            text2.ReadOnly = true;
            //this.Controls.Add(text);

            flow.Controls.Add(text);
            flow.Controls.Add(text2);
            this.Controls.Add(flow);

        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            chrono -= timer1.Interval;
            label1.Text = (chrono / 1000.0f).ToString();
            if(chrono <= 0)
            {
                timer1.Stop();
                showCode();
                MessageBox.Show("DEFAITE : PLUS DE TEMPS");
                this.Close();
            }
        }

        private void showCode()
        {
            for(int i = 0; i < nbBoutons; i++)
            {
                buttonList.ToArray()[i].BackColor = Program.goalColors[i];
            }
        }
    }
}
