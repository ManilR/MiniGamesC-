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
    public partial class Form1 : Form
    {
        private int playing = 0;
        private int[,] board = new int[4,4];
        private int scoreJ1 = 0;
        private int scoreJ2 = 0;
        private int scoreJ3 = 0;

        private string mode;
        private int joueur;
        private string path;
        public Form1(int joueur,string mode, string path)
        {
            this.mode = mode;
            this.joueur = joueur;
            this.path = path;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(Form1_Close);
            timer1.Start();
            playing = 1;
            label1.Text = "JOUEUR " + playing.ToString();
            if (playing == 1)
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Blue;

            foreach (var button in this.Controls.OfType<Button>())
            {
                if (button.Name.Contains("button"))
                {
                    button.Click += new EventHandler(buttonClick);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.MouseOverBackColor = Color.LightGray;
                }
                
            }
            Replay.Enabled = false;
            Replay.Visible = false;
            score1.Text = "SCORE : " + scoreJ1.ToString();
            score2.Text = "SCORE : " + scoreJ2.ToString();
            score3.Text = "SCORE : " + scoreJ3.ToString();
            if(mode == "Online")
            {
                labelJoueur.Text = "JOUEUR " + joueur.ToString();
                if (joueur == 1)
                    labelJoueur.ForeColor = Color.Red;
                if (joueur == 2)
                    labelJoueur.ForeColor = Color.Blue;
                if (joueur == 3)
                    labelJoueur.ForeColor = Color.Yellow;
            }
            else
            {
                labelJoueur.Visible = false;
                J1name.Visible = false;
                J2name.Visible = false;
                J3name.Visible = false;
                vs1.Visible = false;
                vs2.Visible = false;
            }
            if (path != null)
                labelID.Text = path.Split('\\')[path.Split('\\').Length - 1];
            else
                labelID.Text = "";
        }

        private void buttonClick(object sender, EventArgs e)
        { 
            Button button = (Button)sender;
            string texte = button.Name.Split('n')[1];
            board[Int32.Parse(texte) / 10, Int32.Parse(texte) %10] = playing;
            button.Enabled = false;

            if (playing == 1)
            {
                button.BackColor = Color.Red;
                playing = 2;
                label1.ForeColor = Color.Blue;
                
            }
            else if(playing == 2)
            {
                button.BackColor = Color.Blue;
                playing = 3;
                label1.ForeColor = Color.Yellow;
            }
            else
            {
                button.BackColor = Color.Yellow;
                playing = 1;
                label1.ForeColor = Color.Red;
            }
            label1.Text = "JOUEUR " + playing.ToString();
            if(mode == "Local")
            {
                detectWin();
                score1.Text = "SCORE : " + scoreJ1.ToString();
                score2.Text = "SCORE : " + scoreJ2.ToString();
                score3.Text = "SCORE : " + scoreJ3.ToString();
            }
                
            
            if (mode == "Online")
                writeInFile();

            

        }


        private void detectWin()
        {
            int winner = 0;

            for(int i = 0; i < 4; i++)
            {
                if (winner != 0)
                    break;
                for (int j = 0; j < 4; j++)
                {
                    if (winner != 0)
                        break;
                    winner = chkAround(new int[] { i, j },0, 0);
                }              
            }
            if (winner != 0)
            {
                label1.Text = "JOUEUR " + winner.ToString() + " gagne !";
                foreach (var b in this.Controls.OfType<Button>())
                    b.Enabled = false;
                Replay.Enabled = true;
                Replay.Visible = true;
                Replay.BackColor = Color.Black;
                Replay.ForeColor = Color.White;
            }
            else if(isFull())
            {
                label1.Text = "Egalité !";
                label1.ForeColor = Color.Black;
                Replay.Enabled = true;
                Replay.Visible = true;
                Replay.BackColor = Color.Black;
                Replay.ForeColor = Color.White;
            }
            else
            {
                Replay.Enabled = false;
                Replay.Visible = false;
            }
            if (winner == 1)
            {
                label1.ForeColor = Color.Red;
                scoreJ1++;
            }

            else if (winner == 2)
            {
                label1.ForeColor = Color.Blue;
                scoreJ2++;
            }
            else if (winner == 3)
            {
                label1.ForeColor = Color.Yellow;
                scoreJ3++;
            }
            return;
        }

        private bool isFull()
        {
            bool full = true;
            foreach(int i in board)
            {
                if(i == 0)
                {
                    full = false;
                    break;
                }
            }
            return full;
        }

        private int chkAround(int[] pos, int dir, int suite)
        {
            int x = pos[0];
            int y = pos[1];
            if (suite == 2)
                return board[x, y];
            if (x > 0)
            {
                if (board[x, y] != 0 && board[x, y] == board[x - 1, y] && (dir == 0 || dir == 1))
                    return chkAround(new int[] {x-1, y}, 1, suite +1);
                if(y > 0)
                {
                    if (board[x, y] != 0 && board[x, y] == board[x - 1, y - 1] && (dir == 0 || dir == 2))
                        return chkAround(new int[] { x - 1, y - 1 }, 2, suite + 1);
                }
                if (y < 3)
                {
                    if (board[x, y] != 0 && board[x, y] == board[x - 1, y + 1] && (dir == 0 || dir == 3))
                        return chkAround(new int[] { x - 1, y + 1 }, 3, suite + 1);
                }
            }
            if (x < 3)
            {
                if (board[x, y] != 0 && board[x, y] == board[x + 1, y] && (dir == 0 || dir == 4))
                    return chkAround(new int[] { x + 1, y }, 4, suite + 1);
                if (y > 0)
                {
                    if (board[x, y] != 0 && board[x, y] == board[x + 1, y - 1] && (dir == 0 || dir == 5))
                        return chkAround(new int[] { x + 1, y - 1 }, 5, suite + 1);
                }
                if (y < 3)
                {
                    if (board[x, y] != 0 && board[x, y] == board[x + 1, y + 1] && (dir == 0 || dir == 6))
                        return chkAround(new int[] { x + 1, y + 1 }, 6, suite + 1);
                }
            }
            if (y > 0)
            {
                if (board[x, y] != 0 && board[x, y] == board[x, y-1] && (dir == 0 || dir == 7))
                    return chkAround(new int[] { x, y-1 }, 7, suite + 1);
            }
            if (y < 3)
            {
                if (board[x, y] != 0 && board[x, y] == board[x, y + 1] && (dir == 0 || dir == 8))
                    return chkAround(new int[] { x, y + 1 }, 8, suite + 1);
            }
            return 0;
        }

        private void Replay_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    board[i, j] = 0;
            }
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.BackColor = Color.White;
                button.Enabled = true;
            }
            if(mode == "Online")
                writeInFile();
            Replay.Enabled = false;
            Replay.Visible = false;
            label1.Text = "JOUEUR " + playing.ToString();
            if (playing == 1)
                label1.ForeColor = Color.Red;
            if (playing == 2)
                label1.ForeColor = Color.Blue;
            if (playing == 3)
                label1.ForeColor = Color.Yellow;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (mode == "Online")
                readInFile();
        }
        private void readInFile()
        {
            if (!File.Exists(path))
            {
                timer1.Stop();
                MessageBox.Show("Partie terminée");
                this.Close();
            }
            try
            {
                string[] data=File.ReadAllLines(path);
                for(int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                        board[i, j] = Int32.Parse(data[i * 4 + j]);     
                }
                playing = Int32.Parse(data[16]);
                scoreJ1 = Int32.Parse(data[16+1]);
                scoreJ2 = Int32.Parse(data[16+2]);
                scoreJ3 = Int32.Parse(data[16 + 3]);
                J1name.Text = data[16 + 4 + 1];
                J2name.Text = data[16 + 4 + 2];
                J3name.Text = data[16 + 4 + 3];
                refreshGame();    
            }
            catch (IOException e)
            {
                Console.WriteLine("Erreur : Stream ouvert");
            }
        }

        private void refreshGame()
        {
            score1.Text = "SCORE : " + scoreJ1.ToString();
            score2.Text = "SCORE : " + scoreJ2.ToString();
            score3.Text = "SCORE : " + scoreJ3.ToString();

            label1.Text = "JOUEUR " + playing.ToString();
            if (playing == 1)
                label1.ForeColor = Color.Red;
            if (playing == 2)
                label1.ForeColor = Color.Blue;
            if (playing == 3)
                label1.ForeColor = Color.Yellow;
            foreach (var b in this.Controls.OfType<Button>())
            {
                if (b.Name.Contains("button"))
                {
                    string texte = b.Name.Split('n')[1];
                    int value = board[Int32.Parse(texte) / 10, Int32.Parse(texte) % 10];
                    if (value == 0)
                        b.BackColor = Color.White;
                    if (value == 1)
                        b.BackColor = Color.Red;
                    if (value == 2)
                        b.BackColor = Color.Blue;
                    if (value == 3)
                        b.BackColor = Color.Yellow;
                    if (playing != joueur)
                        b.Enabled = false;
                    else if(b.BackColor == Color.White)
                        b.Enabled = true;
                }    
            }
            detectWin();
        }

        private void writeInFile()
        {
            try
            {
                string[] data = File.ReadAllLines(path);
                for(int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                        data[i * 4 + j] = board[i, j].ToString();
                }
                data[16] = playing.ToString();
                data[16+1] = scoreJ1.ToString();
                data[16+2] = scoreJ2.ToString();
                data[16 + 3] = scoreJ3.ToString();
                File.WriteAllLines(path, data);
            }
            catch (IOException e)
            {
                Console.WriteLine("Erreur : Stream ouvert");
            }
        }

        private void Form1_Close(object sender, FormClosedEventArgs e)
        {
            if(path != null && joueur == 1)
                File.Delete(path);
        }
    }
}
