using System;
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
    public partial class Form1 : Form
    {
        private string mode;
        private Button[] balls = new Button[2];

        private int nbLigne = 6;
        private int nbBlocMin = 4;
        private int nbBlocMax = 10;

        private int playerDirX = 0;
        private int health = 3;
        private int score = 0;
        private int chrono = 60000;
        private int nbBrick = 0;

        private const float BASE_SPEED_BALL_X = 0.185f;
        private const float BASE_SPEED_BALL_Y = 0.3f;
        private int nbBall = 0;
        private int[] ballDirX = new int[2];
        private int[] ballDirY = new int[2];
        private float[] speedX = new float[2];
        private float[] speedY = new float[2];

        public Form1(string mode)
        {
            this.mode = mode;
            InitializeComponent();
            balls[0] = BallN1;
            if (mode == "normal")
                nbBall = 1;
            else
            {
                nbBall = 2;
                balls[1] = BallN2;
                BallN2.Visible = true;
            }
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Player1_Control_Down);
            this.KeyUp += new KeyEventHandler(Player1_Control_Up);

            for(int i = 0; i < nbBall; i++)
            {
                ballDirX[i] = 0;
                ballDirY[i] = 0;
                speedX[i] = BASE_SPEED_BALL_X;
                speedY[i] = BASE_SPEED_BALL_Y;
                ballStart(balls[i]);
            }


            timer1.Start();
            startLevel();
            
            foreach (var pb in HUDpanel.Controls.OfType<PictureBox>())
            {
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Show();
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Show();
        }
        private void ballStart(Button ball)
        {
            int index = Int32.Parse( ball.Name.Split('N')[1]) -1;
            ball.Location = new Point(this.Width / 2 + (100*index), (this.Height / 2) + 100);
            Random rand = new Random();
            int dir = rand.Next(2);
            if (dir == 0)
                ballDirX[index] = -1; //left
            else
                ballDirX[index] = 1; // right
            
            ballDirY[index] = -1; //up
            speedX[index] = BASE_SPEED_BALL_X;
        }
        private void startLevel()
        {
            pictureBox1.Hide();
            Random rand1 = new Random();
            Random rand2 = new Random();
            for (int i = 0; i < nbLigne; i++)
            {
                int nbBlock = rand1.Next(nbBlocMax - nbBlocMin) + nbBlocMin;
                Color color = defineColor(rand2.Next(5));
                for(int j = 0; j < nbBlock; j ++)
                {
                    nbBrick++;
                    Panel panel = new Panel();
                    panel.BringToFront();
                    panel.BackColor = color;
                    panel.Size = new Size((int)(this.Width * 0.85 / nbBlock), (int)(this.Height * 0.04));
                    panel.Location = new Point((int)(this.Width * 0.05 + j*(panel.Size.Width *1.05)) ,(int)(this.Height * 0.05 * (i + 1) + 100));
                    this.Controls.Add(panel);
                }
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Show();
            pictureBox1.SendToBack();
        }

        private Color defineColor(int value)
        {
            switch (value)
            {
                case 0:
                    return Color.Red;
                    break;
                case 1:
                    return Color.Blue;
                    break;
                case 2:
                    return Color.Green;
                    break;
                case 3:
                    return Color.Yellow;
                    break;
                case 4:
                    return Color.Purple;
                    break;
                default:
                    return Color.Black;
                    break;
            }
                
        }

        private void Player1_Control_Down(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Q && Player.Location.X >= 0)
            {
                Console.WriteLine("test1");
                playerDirX = -1;
            }
            if (e.KeyCode == Keys.D && Player.Location.X + Player.Size.Width <= this.Width * 0.97)
            {
                Console.WriteLine("test2");
                playerDirX = 1;
            }
            if (Player.Location.X <= 0 && playerDirX == -1)
                playerDirX = 0;
            if (Player.Location.X + Player.Size.Width >= this.Width * 0.97 && playerDirX == 1)
                playerDirX = 0;
        }
        private void Player1_Control_Up(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q || e.KeyCode == Keys.D)
            {
                playerDirX = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            playerScore.Text = "SCORE : " + score.ToString();
            chrono -= timer1.Interval;
            timer.Text = (chrono / 1000.0f).ToString();
            if (chrono <= 0)
            {
                score += 500 * health;
                endGame();
            }
                
            

            Player.Location = new Point(Player.Location.X + (int)(4 * playerDirX), Player.Location.Y );
            for(int i = 0; i < nbBall; i++)
            {
                checkCollision(balls[i]);
                int offsetX = (int)(timer1.Interval * speedX[i] * ballDirX[i]);
                int offsetY = (int)(timer1.Interval * speedY[i] * ballDirY[i]);
                balls[i].Location = new Point(balls[i].Location.X + offsetX, balls[i].Location.Y + offsetY);
            }
            
        }


        private void checkCollision(Button ball)
        {
            int index = Int32.Parse(ball.Name.Split('N')[1]) - 1;
            foreach (var panel in this.Controls.OfType<Panel>())
            {
                if (ball.Bounds.IntersectsWith(panel.Bounds))
                {
                    if (!panel.Name.Contains("HUD"))
                    {
                        this.Controls.Remove(panel);
                        score += 100;
                        nbBrick--;
                    }    
                    ballDirY[index] *= -1;
                }
            }
            foreach (var button in this.Controls.OfType<Button>())
            {
                if(button.Name.Contains("Ball") && button.Name != ball.Name && ball.Bounds.IntersectsWith(button.Bounds))
                {
                    ballDirX[index] *= -1;
                    ballDirY[index] *= -1;
                }
                   
                    
            }
            if (nbBrick == 0)
            {
                score += 1000;
                startLevel();
                ballStart(ball);
            }

            if (ball.Bounds.IntersectsWith(Player.Bounds))
            {  
                ballDirY[index] *= -1;
                if (ball.Location.X + ball.Width/2 <= Player.Location.X + Player.Size.Width / 2)
                    ballDirX[index] = -1;
                else
                    ballDirX[index] = 1;

                if (ball.Location.X + ball.Width / 2 <= Player.Location.X + Player.Size.Width / 3 ||
                    ball.Location.X + ball.Width / 2 >= Player.Location.X + Player.Size.Width * (2 / 3))
                    speedX[index] = BASE_SPEED_BALL_X * 1.5f;
                else
                    speedX[index] = BASE_SPEED_BALL_X;
            }

            if (ball.Location.Y <= 0)
                ballDirY[index] *= -1;

            if (ball.Location.X <= 0 || ball.Location.X + ball.Width >= this.Width * 0.97)
            {
                ballDirX[index] *= -1;
            }

            if (ball.Location.Y + ball.Height >= this.Height)
            {
                foreach (var pb in HUDpanel.Controls.OfType<PictureBox>())
                {
                    if (pb.Name.Contains("heart" + health.ToString()))
                        pb.Hide();
                }
                health--;
                ballStart(ball);
                if (health == 0)
                    defeat();
            }

        }
        private void defeat()
        {
            score -= 1000;
            if (score < 0)
                score = 0;
            endGame();
        }

        private void endGame()
        {
            timer1.Stop();
            MessageBox.Show("Final Score : " + score.ToString());
            this.Close();
        }

        private void HUDpanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
