using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorBlocks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        
        
        private void buttonColor_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int buttonX = Int32.Parse(button.Name.Substring(0,1));
            int buttonY = Int32.Parse(button.Name.Substring(1, 1));
            int[,] shadowTab = new int[nbBoutons, nbBoutons];
            shadowTab = checkBlocks(buttonX, buttonY, shadowTab);
            int nbBlocks = tabSum(shadowTab);
            if (nbBlocks > 1)
            {
                score += (int)Math.Pow(2, nbBlocks);
                label1.Text = "SCORE : " + score.ToString();
                clearBlocks(shadowTab);
            }
                
        }

        private int tabSum(int[,] tab)
        {
            int somme = 0;
            for(int i = 0; i<nbBoutons; i++)
            {
                for(int j=0; j < nbBoutons; j++)
                {
                    somme += tab[i, j];
                }
            }

            return somme;
        }

        private int[,] checkBlocks(int x, int y, int[,] shadowTab)
        {
            shadowTab[x, y] = 1;

            if(x<nbBoutons - 1)
                if (buttonsTab[x, y].BackColor == buttonsTab[x + 1, y].BackColor && shadowTab[x+1,y] == 0)
                    shadowTab = checkBlocks(x+1, y, shadowTab);

            if (x > 0)
                if (buttonsTab[x, y].BackColor == buttonsTab[x - 1, y].BackColor && shadowTab[x - 1, y] == 0)
                    shadowTab = checkBlocks(x-1, y, shadowTab);

            if (y < nbBoutons - 1)
                if (buttonsTab[x, y].BackColor == buttonsTab[x, y+1].BackColor && shadowTab[x, y+1] == 0)
                    shadowTab = checkBlocks(x, y+1, shadowTab);

            if (y > 0)
                if (buttonsTab[x, y].BackColor == buttonsTab[x, y-1].BackColor && shadowTab[x, y-1] == 0)
                    shadowTab = checkBlocks(x, y-1, shadowTab);


            return shadowTab;
        }

        private void clearBlocks(int[,] shadowTab)
        {
            List<Button> buttonList = new List<Button>();
            for (int i = 0; i < nbBoutons; i++)
            {
                for (int j = 0; j < nbBoutons; j++)
                {
                    if (shadowTab[i, j] == 1)
                        buttonList.Add(buttonsTab[i, j]);
                }
            }
            fillBlocks(buttonList);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MessageBox.Show("SCORE FINAL : " + score.ToString());
            this.Close();
        }

        //private List<List<Button>> buttonMatrix = new List<List<Button>>();
        private static int nbBoutons = 6;
        private int score = 0;
        private Button[,] buttonsTab = new Button[nbBoutons, nbBoutons];
        
        private void Form1_Load(object sender, EventArgs e)
        {
            List<Button> buttonList = new List<Button>();
            label1.Text = "SCORE : " + score.ToString();
            int left = (int)(this.Width * 0.25);
            int top = (int)(this.Height * 0.05);
            int width = (int)(this.Width * 0.08);
            int height = width;
            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.Location = new Point(left, top);
            flow.Size = new Size(((int)(this.Width * 0.085)*nbBoutons) + (int)(this.Width * 0.02), 
                ((int)(this.Width * 0.085) * nbBoutons) + (int)(this.Width * 0.02));

            for (int i = 0; i < nbBoutons; i++)
            {
                for (int j = 0; j < nbBoutons; j++)
                {
                    
                    Button button = new Button();
                    button.Location = new System.Drawing.Point(left, top);
                    button.Size = new System.Drawing.Size(width, height);
                    button.Name = i.ToString() + j.ToString();
                    button.Enabled = true;
                    button.Visible = true;
                    button.Cursor = Cursors.Hand;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = Color.Black;
                    button.FlatAppearance.BorderSize = 2;
                    
                    buttonList.Add(button);
                    buttonsTab[i, j] = button;
                    button.Click += new System.EventHandler(buttonColor_Click);
                    flow.Controls.Add(button);
                    
                    left += (int)(this.Width * 0.1);
                    
                }
                fillBlocks(buttonList);
                //buttonMatrix.Add(buttonLine);
                top += (int)(this.Height * 0.1);
            }
            flow.BackColor = Color.Transparent;
            flow.Anchor = AnchorStyles.Top;
            this.Controls.Add(flow);
           
        }

        private void fillBlocks(List<Button> buttons)
        {

            Random rand1 = new Random();
            foreach (Button button in buttons)
            {
                
                int value = rand1.Next(1, 5 + 1);
                switch (value)
                {
                    case 1:
                        button.BackColor = Color.Red;
                        break;
                    case 2:
                        button.BackColor = Color.Blue;
                        break;
                    case 3:
                        button.BackColor = Color.Green;
                        break;
                    case 4:
                        button.BackColor = Color.Yellow;
                        break;
                    case 5:
                        button.BackColor = Color.Cyan;
                        break;
                    default:
                        Console.WriteLine("Error");
                        button.BackColor = Color.Black;
                        break;
                }
                button.FlatAppearance.MouseOverBackColor = Color.FromArgb(button.BackColor.A / 2, button.BackColor.R, button.BackColor.G, button.BackColor.B);
                button.FlatAppearance.MouseDownBackColor = Color.White;
                
            }
        }
    }
}
