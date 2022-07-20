using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Media.Playback;
using Windows.Media.Core;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace JoustGame
{
    public enum DIR{left, right };
    public partial class Game : Form
    {
        private bool stopRun = false;

        private int health = 5;
        private int score = 0;
        private int wave = 0;
        private int nbEnemies = 0;

        private int spawnTimer = 10000;
        private int spawnInt = 5000;

        private string exePath = System.IO.Directory.GetCurrentDirectory();
        private System.Media.SoundPlayer mediaPlayer = new System.Media.SoundPlayer();
        private List<Entity> entities = new List<Entity>();
        private List<Entity> eggs = new List<Entity>();
        private Entity player = new Entity();


        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {

            this.DoubleBuffered = true;
            //this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // réduit le lag

            player.speedX = 0;
            player.speedY = 0;
            player.pb = Player;
            player.direction = DIR.right;
            player.onTheGround = false;
            player.jumpTimer = 1000;

            entities.Add(player);

            timer1.Start();
            this.KeyPress += new KeyPressEventHandler(playerJump);
            this.KeyDown += new KeyEventHandler(Player1_Control_Down);
            this.KeyUp += new KeyEventHandler(Player1_Control_Up);

            startWave();

        }

        private void startWave()
        {
            if (wave > 0)
                score += 1000;
            spawnTimer = 10000;
            nbEnemies = 0;
            wave+=1;
            waveLabel.Text = "WAVE : " + wave.ToString();
            if (spawnInt > 2000)
                spawnInt -= 2000;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            labelScore.Text = "SCORE : " + score.ToString();
            
            spawnTimer += timer1.Interval;
            if (spawnTimer > spawnInt && nbEnemies < 3*wave)
            {
                spawnEnemy();
                spawnTimer = 0;
            }
            if (nbEnemies == 3 * wave && entities.Count == 1 + eggs.Count )
                startWave();
            foreach (Entity entity in entities)
            {
                int testEntities = entities.Count;
                int testEggs = eggs.Count;
                entity.jumpTimer += timer1.Interval;
                checkCollision(entity);
                if (testEntities != entities.Count || testEggs != eggs.Count)
                     break;
                entityFall(entity);

                if (entity.speedX < 0 && entity.direction == DIR.right && entity.pb.Image != null)
                {
                    entity.pb.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    entity.direction = DIR.left;
                }
                else if (entity.speedX > 0 && entity.direction == DIR.left && entity.pb.Image != null)
                {
                    entity.pb.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    entity.direction = DIR.right;
                }

                entityTP(entity);
                if(entity.pb.Name.Contains("Enemy"))
                    enemyMove(entity);

                entity.pb.Location = new Point(entity.pb.Location.X + (int)entity.speedX, entity.pb.Location.Y + (int)entity.speedY);
                
            }
        }

        private void spawnEnemy()
        {
            nbEnemies++;
            string exePath = System.IO.Directory.GetCurrentDirectory();
            string path = exePath + "\\enemy sprite edited.png";
            Entity enemy = new Entity();
            PictureBox pb = new PictureBox();
            pb.Size = new Size(45, 60);
            pb.BackColor = Color.Transparent;
            pb.Name = "Enemy";
            Random rand = new Random();

            int spawn = rand.Next(5) + 1;
            Panel spawnPoint = new Panel();
            foreach (Panel p in this.Controls.OfType<Panel>())
            {
                if (p.Name == "Spawn" + spawn.ToString())
                    spawnPoint = p;
            }
            pb.Location = new Point(spawnPoint.Location.X + spawnPoint.Width / 4, spawnPoint.Location.Y - pb.Height);
            
            pb.ImageLocation = path;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            if (spawnPoint.Name == "")
                pb.Location = new Point(0, 0);
            this.Controls.Add(pb);

            enemy.speedX = 0f;
            enemy.speedY = 0f;
            enemy.jumpTimer = 1000;
            enemy.pb = pb;
            if (enemy.pb.Location.X < Player.Location.X && enemy.pb.Image != null)
            {
                enemy.direction = DIR.right;
                pb.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            else
                enemy.direction = DIR.left;
            entities.Add(enemy);
        }

        private void enemyMove(Entity entity)
        {

                if (Player.Location.X > entity.pb.Location.X + 100)
                    entity.speedX = 1;
                else if (Player.Location.X < entity.pb.Location.X - 100)
                    entity.speedX = -1;
                if (Player.Location.Y < entity.pb.Location.Y)
                    enemyJump(entity);
        }

        private void checkCollision(Entity entity)
        {
            bool test = false;
            foreach (var panel in this.Controls.OfType<Panel>())
            {
                var intersection = Rectangle.Intersect(entity.pb.Bounds, panel.Bounds);
                if (!intersection.IsEmpty)
                {
                    bool hitSomethingAbove = entity.pb.Top == intersection.Top;
                    bool hitSomethingBelow = entity.pb.Bottom == intersection.Bottom;
                    bool hitSomethingOnTheRight = entity.pb.Right == intersection.Right;
                    bool hitSomethingOnTheLeft = entity.pb.Left == intersection.Left;
                    test = true;
                    if (panel.Name == "Fire")
                    {
                        if(entity.pb.Name == "Player")
                            playerDeath();
                        else
                        {
                            enemyDeath(entity, false);
                        }

                    }
                        

                    if (hitSomethingBelow)
                    {
                        
                        if (!entity.onTheGround)
                        {
                            if (entity.pb.Location.Y + entity.pb.Height > panel.Location.Y +1)
                                entity.pb.Location = new Point(entity.pb.Location.X, panel.Location.Y - entity.pb.Height - 1);
                            if(entity.pb.Name == "Player")
                            {
                                mediaPlayer.Stop();
                                mediaPlayer = new System.Media.SoundPlayer(exePath + "\\bounce.wav");
                                mediaPlayer.Play();
                            }
                            
                        }

                        if (entity.pb.Name.Contains("Egg"))
                        {
                            entity.speedY *= -0.9f;
                            if ((entity.speedY > -1 && entity.speedY < 0) || (entity.speedY < 1 && entity.speedY > 0))
                            {
                                entity.speedY = 0;
                                entity.onTheGround = true;
                            }
                                
                        }
                        else
                            entity.onTheGround = true;
                        
                    }
                    else
                    {
                        entity.onTheGround = false;
                    }

                    if(!panel.Name.Contains("Spawn") && hitSomethingAbove)
                    {
                        if (entity.pb.Location.Y  < panel.Location.Y + panel.Height - 1)
                            entity.pb.Location = new Point(entity.pb.Location.X, panel.Location.Y + panel.Height + 1);
                        if (entity.pb.Name == "Player")
                        {
                            mediaPlayer.Stop();
                            mediaPlayer = new System.Media.SoundPlayer(exePath + "\\bounce.wav");
                            mediaPlayer.Play();
                        }
                            
                        entity.speedY = entity.speedY * -1;
                    }
                    

                    if ((hitSomethingOnTheLeft || hitSomethingOnTheRight) &&  !hitSomethingBelow && !hitSomethingAbove)
                    {
                        if (entity.pb.Name == "Player")
                        {
                            mediaPlayer.Stop();
                            mediaPlayer = new System.Media.SoundPlayer(exePath + "\\bounce.wav");
                            mediaPlayer.Play();
                        }
                            
                        entity.speedX = entity.speedX * -1;
                    }




                }
            }

            if (!test)
                entity.onTheGround = false;

            if(entity.pb.Name == "Player")
            {
                foreach (var pb in this.Controls.OfType<PictureBox>())
                {
                    if (entity.pb.Bounds.IntersectsWith(pb.Bounds) && pb.Name != entity.pb.Name)
                    {
                        foreach (Entity enemy in entities)   
                        {
                            if (enemy.pb == pb)
                            {
                                if (pb.Location.Y > entity.pb.Location.Y && entities.Count > 0 || enemy.pb.Name.Contains("Egg"))
                                {
                                    enemyDeath(enemy, true);
                                    break;
                                }
                            else
                                playerDeath();
                            }
                        }
                    }
                }
            }
            
        }

        private void enemyDeath(Entity enemy, bool killed)
        {
            entities.Remove(enemy);
            this.Controls.Remove(enemy.pb);
            score += 500;
            mediaPlayer.Stop();
            mediaPlayer = new System.Media.SoundPlayer(exePath + "\\death.wav");
            mediaPlayer.Play();
            if (enemy.pb.Name.Contains("Enemy"))
                spawnEgg(enemy);
            else if (enemy.pb.Name.Contains("Egg"))
                eggs.Remove(enemy);
        }

        private void spawnEgg(Entity enemy)
        {
            string exePath = System.IO.Directory.GetCurrentDirectory();
            string path = exePath + "\\egg.png";
            Entity egg = new Entity();
            egg.speedX = enemy.speedX * -2;
            PictureBox pb = new PictureBox();
            pb.Size = new Size(18, 21);
            pb.BackColor = Color.Transparent;
            pb.Name = "Egg";
            pb.Location = new Point(enemy.pb.Location.X + (int)(egg.speedX*10), enemy.pb.Location.Y);
            pb.ImageLocation = path;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;

            
            this.Controls.Add(pb);
            egg.pb = pb;
            entities.Add(egg);
            eggs.Add(egg);
        }

        private void playerDeath()
        {
            mediaPlayer.Stop();
            mediaPlayer = new System.Media.SoundPlayer(exePath + "\\explosion.wav");
            mediaPlayer.Play();
            foreach (var pb in HUDpanel.Controls.OfType<PictureBox>())
            {
                if (pb.Name == "Health" + health.ToString())
                    pb.Visible = false;
            }
            health--;
            player.pb.Location = new Point(this.Width / 2, 0);
            player.speedX = 0;
            player.speedY = 0;
            if (health == 0)
            {
                timer1.Stop();              
                MessageBox.Show("Fin de partie. Votre score est de : " + score.ToString());
                this.Close();
            } 
        }

        private void entityTP(Entity entity)
        {
            if (entity.pb.Location.X + entity.pb.Width <= 0)
                entity.pb.Location = new Point(this.Width - entity.pb.Width, entity.pb.Location.Y);
            if (entity.pb.Location.X >= this.Width)
                entity.pb.Location = new Point(0 - entity.pb.Width, entity.pb.Location.Y);
        }

        private void entityFall(Entity entity)
        {

            if (!entity.onTheGround && entity.speedY <= 2.5)
                entity.speedY += 0.1f;
            if (!entity.onTheGround && (int)entity.speedY == 0)
                entity.speedY = 1;
            if (entity.onTheGround && entity.speedY > 0)
                entity.speedY = 0;

            if (entity.speedX > 0 && stopRun)
                entity.speedX -= 0.015f;
            if (entity.speedX < 0 && stopRun)
                entity.speedX += 0.015f;
        }

        private void playerJump(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32 && !e.Handled && player.jumpTimer >= 150)
            {
                
                e.Handled = true;
                jump(player);
                
            }
        }
        private void enemyJump(Entity enemy)
        {
            if (enemy.jumpTimer >= 300)
            {
                enemy.speedY = -3;
                enemy.jumpTimer = 0;
            }
        }

        private void jump(Entity entity)
        {
            entity.speedY = -3;
            entity.jumpTimer = 0;

            if(entity.pb.Name == "Player")
            {
                mediaPlayer.Stop();
                mediaPlayer = new System.Media.SoundPlayer(exePath + "\\jump.wav");
                mediaPlayer.Play();
            }
            
        }

        private void Player1_Control_Down(object sender, KeyEventArgs e)
        {
            int i = 0;
            if (e.KeyCode == Keys.P)
                i = 0;

            if (e.KeyCode == Keys.Q && !e.Handled && player.speedX > -5.5)
            {
                if (player.speedX > 0)
                    player.speedX -= 0.75f;
                else
                    player.speedX -= 0.15f;
                if (player.speedX > -1 && player.speedX < 0)
                    player.speedX = -1.5f;
                e.Handled = true;
                stopRun = false;
            }
            if (e.KeyCode == Keys.D && !e.Handled && player.speedX < 5.5)
            {
                if (player.speedX < 0)
                    player.speedX += 0.75f;
                else
                    player.speedX += 0.15f;
                if (player.speedX < 1 && player.speedX > 0)
                    player.speedX = 1.5f;
                e.Handled = true;
                stopRun = false;
            }
        }
        private void Player1_Control_Up(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Q && player.speedX < 0) || (e.KeyCode == Keys.D && player.speedX > 0))
            {
                stopRun = true;
            }
            //else
            //    stopRun = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void HUDpanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    public class Entity
    {
        public float speedX { get; set; }

        public float speedY { get; set; }

        public int jumpTimer { get; set; }

        public bool onTheGround { get; set; }

        public PictureBox pb { get; set; }

        public DIR direction { get; set; }
    }
}
