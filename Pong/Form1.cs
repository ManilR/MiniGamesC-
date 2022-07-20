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
    public enum Bonus_Type {Size, Block};
    public partial class Form1 : Form
    {
        private const float BASE_SPEED_BALL_X = 0.185f;
        private const float BASE_SPEED_BALL_Y = 0.15f;
        private int ballDirX = 0;
        private int ballDirY = 0;
        private int botDirY = 0;
        private int playerDirY = 0;
        private float speedX = BASE_SPEED_BALL_X;
        private float speedY = BASE_SPEED_BALL_Y;

        private int bonusDirY = 1;
        private Panel bonusMalus = null;
        private bool isBonusMalus = false;
        private Bonus_Type bonusType;

        private int timerBonusSpawn = 0;
        private int timerBonusEffect = 0;
        private const int BASE_SIZE_Y = 75;

        private int scoreP1 = 0;
        private int scoreP2 = 0;
        Panel blockBar = new Panel();

        private int nbPlayer = 0;
        private string mode;
        private string path;
        private int timerWrite = 0;

        public Form1(int nP, string mode, string path)
        {
            InitializeComponent();
            nbPlayer = nP;
            this.mode = mode;
            if(path != null)
            {
                this.path = path;
            }
            timer1.Start();
            if(nbPlayer == 2 && mode == "Online")
            {

            }
            else
            {
                this.KeyPreview = true;
                this.KeyDown += new KeyEventHandler(Player1_Control_Down);
                this.KeyUp += new KeyEventHandler(Player1_Control_Up);
                if (nbPlayer == 2 && mode == "Local")
                {
                    this.KeyDown += new KeyEventHandler(Player2_Control_Down);
                    this.KeyUp += new KeyEventHandler(Player2_Control_Up);
                }
                this.Controls.Add(Player1);
                ballStart();
                timer1.Tick += new EventHandler(botMove);
                timer1.Tick += new EventHandler(playerMove);
                blockBar.Size = new Size(5, 700);
                blockBar.Location = new Point(-10, -10);
                blockBar.BackColor = Color.Yellow;
                this.Controls.Add(blockBar);
            }  
        }

        private void addBonus()
        {
            timerBonusSpawn = 0;
            bool isBonus;
            Random rand = new Random();
            int value = rand.Next(2);
            Panel panel = new Panel();
            panel.Size = new Size(40, 40);
            panel.Location = new Point(225 + (225*value), 300);
            value = rand.Next(3);

            if (value == 0 || value == 2)
                isBonus = true;
            else
                isBonus = false;
            if (value == 0 || value == 1)
                bonusType = Bonus_Type.Size;
            else
                bonusType = Bonus_Type.Block;


            if (isBonus && bonusType == Bonus_Type.Size)
            {
                panel.BackColor = Color.Green;
                panel.Name = "Bonus"+bonusType.ToString();
            }
            if(bonusType == Bonus_Type.Block)
            {
                panel.BackColor = Color.Yellow;
                panel.Name = "Bonus" + bonusType.ToString();
            }
            if(!isBonus && bonusType == Bonus_Type.Size)
            {
                panel.BackColor = Color.Red;
                panel.Name = "Malus" + bonusType.ToString();
            }
            bonusMalus = panel;
            this.Controls.Add(panel);
        }

        private void bonusMalusMove()
        {
            
            if (bonusMalus.Location.Y <= this.Height * 0.2 && bonusDirY == -1)
                bonusDirY = 1;
            if (bonusMalus.Location.Y >= this.Height * 0.8 && bonusDirY == 1)
                bonusDirY = -1;


        }

        private void bonusMalusEffect()
        {
            timerBonusEffect = 0;
            isBonusMalus = true;
            
            
            if (ballDirX > 0)
            {
                if (bonusMalus.Name == "BonusSize")
                    sizePlus(Player1);
                if(bonusMalus.Name == "MalusSize")
                    sizeMinus(Player1);
                if (bonusType == Bonus_Type.Block)
                    block(Player1);
            }    
            else
            {
                if (bonusMalus.Name == "BonusSize")
                    sizePlus(Player2);
                if (bonusMalus.Name == "MalusSize")
                    sizeMinus(Player2);
                if (bonusType == Bonus_Type.Block)
                    block(Player2);
            }
            
            this.Controls.Remove(bonusMalus);
            bonusMalus = null;

        }

        private void block(Button player)
        {
            if (player == Player1)
                blockBar.Location = new Point(0, 100);
            else
                blockBar.Location = new Point(this.Width - 20, 100);
        }
        private void sizePlus(Button player)
        {
            player.Size = new Size(20, BASE_SIZE_Y * 2);
            if(player.Name == "Player1")
            {
                P1panel1.Size = new Size(4, P1panel1.Size.Height * 2);
                P1panel2.Size = new Size(4, P1panel2.Size.Height * 2);
            }
            else
            {
                P2panel1.Size = new Size(4, P2panel1.Size.Height * 2);
                P2panel2.Size = new Size(4, P2panel2.Size.Height * 2);
            }
        }
        private void sizeMinus(Button player)
        {
            player.Size = new Size(20, BASE_SIZE_Y / 2);
            if (player.Name == "Player1")
            {
                P1panel1.Size = new Size(4, P1panel1.Size.Height / 2);
                P1panel2.Size = new Size(4, P1panel2.Size.Height / 2);
            }
            else
            {
                P2panel1.Size = new Size(4, P2panel1.Size.Height / 2);
                P2panel2.Size = new Size(4, P2panel2.Size.Height / 2);
            }
        }


        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (nbPlayer == 2 && mode == "Online")
            {
                readInFile();
            }
            else
            {


                timerBonusSpawn += timer1.Interval;
                timerBonusEffect += timer1.Interval;
                timerWrite += timer1.Interval;
                checkCollision();
                int offsetX = (int)(timer1.Interval * speedX * ballDirX);
                int offsetY = (int)(timer1.Interval * speedY * ballDirY);
                Ball.Location = new Point(Ball.Location.X + offsetX, Ball.Location.Y + offsetY);

                if (mode == "Online" && timerWrite%20 == 0)
                {
                    writeInFile();
                }

                if (nbPlayer == 1 && mode == "Local")
                    botIA();

                P1panel1.Location = new Point(Player1.Location.X + Player1.Size.Width - P1panel1.Size.Width,
                                              Player1.Location.Y);
                P1panel2.Location = new Point(Player1.Location.X + Player1.Size.Width - P1panel1.Size.Width,
                                              Player1.Location.Y + Player1.Size.Height - P1panel1.Size.Height);

                P2panel1.Location = new Point(Player2.Location.X,
                                              Player2.Location.Y);
                P2panel2.Location = new Point(Player2.Location.X,
                                              Player2.Location.Y + Player2.Size.Height - P2panel1.Size.Height);
                if (bonusMalus != null)
                {
                    bonusMalusMove();
                    bonusMalus.Location = new Point(bonusMalus.Location.X, (int)(bonusMalus.Location.Y + timer1.Interval * bonusDirY * 0.1));
                }


                if (timerBonusEffect > 15000 && isBonusMalus == true)
                    isBonusMalus = false;
                if (Player1.Size.Height != BASE_SIZE_Y && !isBonusMalus)
                {
                    Player1.Size = new Size(20, BASE_SIZE_Y);
                    P1panel1.Size = new Size(4, BASE_SIZE_Y / 4);
                    P1panel2.Size = new Size(4, BASE_SIZE_Y / 4);
                }

                if (Player2.Size.Height != BASE_SIZE_Y && !isBonusMalus)
                {
                    Player2.Size = new Size(20, BASE_SIZE_Y);
                    P2panel1.Size = new Size(4, BASE_SIZE_Y / 4);
                    P2panel2.Size = new Size(4, BASE_SIZE_Y / 4);
                }

                if (!isBonusMalus && blockBar.Location != new Point(-10, -10))
                    blockBar.Location = new Point(-10, -10);

                if (timerBonusSpawn > 20000 && bonusMalus == null)
                    addBonus();
                P1Score.Text = "P1 : " + scoreP1.ToString();
                P2Score.Text = "P2 : " + scoreP2.ToString();
            }
                
        }
        private async void readInFile()
        {
            try
            {
                byte[] result;
                using (FileStream SourceStream = File.Open(path, FileMode.Open))
                {
                    result = new byte[SourceStream.Length];
                    await SourceStream.ReadAsync(result, 0, (int)SourceStream.Length);
                    string texte = System.Text.Encoding.ASCII.GetString(result);
                    string x = texte.Split('=', (char)3)[1].Split(',', (char)2)[0];
                    string y = texte.Split('=', (char)3)[2].Split('}', (char)2)[0];
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Erreur : Stream ouvert");
            } 
        }
        private void writeInFile()
        {
           
            try
            {
                using (FileStream fs = File.Create(path))
                {
                    string texte = "P1 : " + Player1.Location.ToString() + "\n" + "P2 : " + Player2.Location.ToString()
                                        + "\n" + "BALL : " + Ball.Location.ToString();
                    byte[] info = new UTF8Encoding(true).GetBytes(texte);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Erreur : Stream ouvert");
            }
        }
        private void botIA()
        {
            if (Ball.Location.X > this.Width / 2)
            {
                if (Ball.Location.Y <= Player2.Location.Y)
                    botDirY = -1;
                else if (Ball.Location.Y >= Player2.Location.Y + (Player2.Size.Height / 2))
                    botDirY = 1;
            }
            else
            {
                if (this.Height / 2 <= Player2.Location.Y)
                    botDirY = -1;
                else if (this.Height / 2 >= Player2.Location.Y + Player2.Size.Height)
                    botDirY = 1;
                else
                    botDirY = 0;
            }
            if (Player2.Location.Y <= 100 && botDirY == -1)
                botDirY = 0;
            if (Player2.Location.Y + Player2.Size.Height >= this.Height * 0.91 && botDirY == 1)
                botDirY = 0;
        }
        private void checkCollision()
        {

            
            if (Ball.Bounds.IntersectsWith(Player1.Bounds))
            {
                if (Ball.Location.Y + (Ball.Size.Height / 2) > Player1.Location.Y + (Player1.Size.Height / 2))
                    ballDirY = 1;
                else
                    ballDirY = -1;
                ballDirX *= -1;
                Ball.Location = new Point(Ball.Location.X + 1,Ball.Location.Y);
                if (speedX < BASE_SPEED_BALL_X * 3 && pStrike(Player1))
                {
                    speedX += BASE_SPEED_BALL_X / 2;
                    speedY = BASE_SPEED_BALL_Y;
                    speedY -= BASE_SPEED_BALL_Y / 3;
                }
                else if (speedX > BASE_SPEED_BALL_X)
                    speedX -= BASE_SPEED_BALL_X / 4;
                    
            }
            if (Ball.Bounds.IntersectsWith(Player2.Bounds))
            {
                if (Ball.Location.Y + (Ball.Size.Height / 2) > Player2.Location.Y + (Player2.Size.Height / 2))
                    ballDirY = 1;
                else
                    ballDirY = -1;
                ballDirX *= -1;
                Ball.Location = new Point(Ball.Location.X  - 1, Ball.Location.Y);
                if (speedX < BASE_SPEED_BALL_X * 3 && pStrike(Player2))
                {
                    speedX += BASE_SPEED_BALL_X / 2;                   
                    speedY = BASE_SPEED_BALL_Y;
                    speedY -= BASE_SPEED_BALL_Y / 3;
                }
                else if (speedX > BASE_SPEED_BALL_X)
                    speedX -= BASE_SPEED_BALL_X / 4;

            }
            if(Ball.Bounds.IntersectsWith(TopPanel.Bounds) || Ball.Location.Y + Ball.Size.Height >= this.Height* 0.91)
            {
                ballDirY *= -1;
                //if (speedX > BASE_SPEED_BALL_X)
                //    speedX -= BASE_SPEED_BALL_X / 3;
                if (speedY != BASE_SPEED_BALL_Y)
                    speedY = BASE_SPEED_BALL_Y;
            }

            if (Ball.Bounds.IntersectsWith(blockBar.Bounds))
                ballDirX *= -1;
            
            if (Ball.Location.X <= 0)
            {
                ballStart();
                scoreP2++;
            }
            if (Ball.Location.X + Ball.Size.Width >= this.Width)
            {
                ballStart();
                scoreP1++;
            }
            
            if (speedX > BASE_SPEED_BALL_X * 2)
                Ball.BackColor = Color.Orange;
            else if (speedX > BASE_SPEED_BALL_X)
                Ball.BackColor = Color.Yellow;
            else
                Ball.BackColor = Color.White;
            if (speedX > BASE_SPEED_BALL_X * 3)
                speedX = BASE_SPEED_BALL_X * 3;
            else if (speedX < BASE_SPEED_BALL_X)
                speedX = BASE_SPEED_BALL_X;

            if(bonusMalus != null)
                if (Ball.Bounds.IntersectsWith(bonusMalus.Bounds) && !isBonusMalus)
                    bonusMalusEffect();

        }
        private bool pStrike(Button player)
        {
            return (Ball.Location.Y + (Ball.Size.Height/2) <= player.Location.Y + player.Size.Height*0.25 ||
                    Ball.Location.Y + (Ball.Size.Height / 2) >= player.Location.Y + player.Size.Height * 0.75);
        }
        private void ballStart()
        {
            Ball.Location = new Point(this.Width/2, this.Height/2);
            Random rand = new Random();
            int dir = rand.Next(2);
            if (dir == 0)
                ballDirX = -1; //left
            else
                ballDirX = 1; // right
            dir = rand.Next(2);
            if (dir == 0)
                ballDirY = -1; //up
            else
                ballDirY = 1; // down
            speedX = BASE_SPEED_BALL_X;
        }
        private void botMove(object sender, EventArgs e)
        {
            Player2.Location = new Point(Player2.Location.X, Player2.Location.Y + (int)(2 * botDirY));
        }

        private void playerMove(object sender, EventArgs e)
        {
            Player1.Location = new Point(Player1.Location.X, Player1.Location.Y + (int)(2 * playerDirY));
        }

        
        private void Player1_Control_Down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z && Player1.Location.Y >= 100)
            {
                playerDirY = -1;
            }
            if(e.KeyCode == Keys.S && Player1.Location.Y + Player1.Size.Height <= this.Height*0.91)
            {
                playerDirY = 1;
            }
            if (Player1.Location.Y <= 100 && playerDirY == -1)
                playerDirY = 0;
            if (Player1.Location.Y + Player1.Size.Height >= this.Height * 0.91 && playerDirY == 1)
                playerDirY = 0;
        }
        private void Player1_Control_Up(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z || e.KeyCode == Keys.S)
            {
                playerDirY = 0;
            }
        }

        private void Player2_Control_Down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && Player2.Location.Y >= 100)
            {
                botDirY = -1;
            }
            if (e.KeyCode == Keys.Down && Player2.Location.Y + Player2.Size.Height <= this.Height * 0.91)
            {
                botDirY = 1;
            }
            if (Player2.Location.Y <= 100 && botDirY == -1)
                botDirY = 0;
            if (Player2.Location.Y + Player2.Size.Height >= this.Height * 0.91 && botDirY == 1)
                botDirY = 0;
        }
        private void Player2_Control_Up(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                botDirY = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Player1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
