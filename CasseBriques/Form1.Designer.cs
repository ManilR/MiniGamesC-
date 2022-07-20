
namespace CasseBriques
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Player = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BallN1 = new System.Windows.Forms.Button();
            this.HUDbarre = new System.Windows.Forms.Panel();
            this.HUDpanel = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Label();
            this.playerScore = new System.Windows.Forms.Label();
            this.heart3 = new System.Windows.Forms.PictureBox();
            this.heart2 = new System.Windows.Forms.PictureBox();
            this.heart1 = new System.Windows.Forms.PictureBox();
            this.BallN2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.HUDpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heart1)).BeginInit();
            this.SuspendLayout();
            // 
            // Player
            // 
            this.Player.BackColor = System.Drawing.Color.Black;
            this.Player.Enabled = false;
            this.Player.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.Player.FlatAppearance.BorderSize = 5;
            this.Player.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Player.Location = new System.Drawing.Point(344, 596);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(100, 23);
            this.Player.TabIndex = 0;
            this.Player.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-4, 99);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(813, 538);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BallN1
            // 
            this.BallN1.BackColor = System.Drawing.Color.White;
            this.BallN1.Enabled = false;
            this.BallN1.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.BallN1.FlatAppearance.BorderSize = 5;
            this.BallN1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BallN1.Location = new System.Drawing.Point(334, 339);
            this.BallN1.Name = "BallN1";
            this.BallN1.Size = new System.Drawing.Size(25, 25);
            this.BallN1.TabIndex = 2;
            this.BallN1.UseVisualStyleBackColor = false;
            // 
            // HUDbarre
            // 
            this.HUDbarre.BackColor = System.Drawing.Color.White;
            this.HUDbarre.Location = new System.Drawing.Point(-4, 89);
            this.HUDbarre.Name = "HUDbarre";
            this.HUDbarre.Size = new System.Drawing.Size(806, 13);
            this.HUDbarre.TabIndex = 3;
            // 
            // HUDpanel
            // 
            this.HUDpanel.BackColor = System.Drawing.Color.Black;
            this.HUDpanel.Controls.Add(this.timer);
            this.HUDpanel.Controls.Add(this.playerScore);
            this.HUDpanel.Controls.Add(this.heart3);
            this.HUDpanel.Controls.Add(this.heart2);
            this.HUDpanel.Controls.Add(this.heart1);
            this.HUDpanel.Location = new System.Drawing.Point(-4, -2);
            this.HUDpanel.Name = "HUDpanel";
            this.HUDpanel.Size = new System.Drawing.Size(806, 95);
            this.HUDpanel.TabIndex = 4;
            this.HUDpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.HUDpanel_Paint);
            // 
            // timer
            // 
            this.timer.AutoSize = true;
            this.timer.Font = new System.Drawing.Font("Cooper Black", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timer.ForeColor = System.Drawing.Color.White;
            this.timer.Location = new System.Drawing.Point(675, 25);
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(117, 38);
            this.timer.TabIndex = 4;
            this.timer.Text = "label1";
            // 
            // playerScore
            // 
            this.playerScore.AutoSize = true;
            this.playerScore.Font = new System.Drawing.Font("Cooper Black", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerScore.ForeColor = System.Drawing.Color.White;
            this.playerScore.Location = new System.Drawing.Point(331, 25);
            this.playerScore.Name = "playerScore";
            this.playerScore.Size = new System.Drawing.Size(117, 38);
            this.playerScore.TabIndex = 3;
            this.playerScore.Text = "label1";
            // 
            // heart3
            // 
            this.heart3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.heart3.Image = ((System.Drawing.Image)(resources.GetObject("heart3.Image")));
            this.heart3.Location = new System.Drawing.Point(148, 14);
            this.heart3.Name = "heart3";
            this.heart3.Size = new System.Drawing.Size(50, 50);
            this.heart3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.heart3.TabIndex = 2;
            this.heart3.TabStop = false;
            // 
            // heart2
            // 
            this.heart2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.heart2.Image = ((System.Drawing.Image)(resources.GetObject("heart2.Image")));
            this.heart2.Location = new System.Drawing.Point(82, 14);
            this.heart2.Name = "heart2";
            this.heart2.Size = new System.Drawing.Size(50, 50);
            this.heart2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.heart2.TabIndex = 1;
            this.heart2.TabStop = false;
            // 
            // heart1
            // 
            this.heart1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.heart1.Image = ((System.Drawing.Image)(resources.GetObject("heart1.Image")));
            this.heart1.Location = new System.Drawing.Point(16, 14);
            this.heart1.Name = "heart1";
            this.heart1.Size = new System.Drawing.Size(50, 50);
            this.heart1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.heart1.TabIndex = 0;
            this.heart1.TabStop = false;
            // 
            // BallN2
            // 
            this.BallN2.BackColor = System.Drawing.Color.White;
            this.BallN2.Enabled = false;
            this.BallN2.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.BallN2.FlatAppearance.BorderSize = 5;
            this.BallN2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BallN2.Location = new System.Drawing.Point(409, 339);
            this.BallN2.Name = "BallN2";
            this.BallN2.Size = new System.Drawing.Size(25, 25);
            this.BallN2.TabIndex = 5;
            this.BallN2.UseVisualStyleBackColor = false;
            this.BallN2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 631);
            this.Controls.Add(this.BallN2);
            this.Controls.Add(this.HUDpanel);
            this.Controls.Add(this.HUDbarre);
            this.Controls.Add(this.BallN1);
            this.Controls.Add(this.Player);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.HUDpanel.ResumeLayout(false);
            this.HUDpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Player;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button BallN1;
        private System.Windows.Forms.Panel HUDbarre;
        private System.Windows.Forms.Panel HUDpanel;
        private System.Windows.Forms.PictureBox heart1;
        private System.Windows.Forms.PictureBox heart3;
        private System.Windows.Forms.PictureBox heart2;
        private System.Windows.Forms.Label timer;
        private System.Windows.Forms.Label playerScore;
        private System.Windows.Forms.Button BallN2;
    }
}

