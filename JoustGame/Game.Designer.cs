
namespace JoustGame
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Fire = new System.Windows.Forms.Panel();
            this.HUDpanel = new System.Windows.Forms.Panel();
            this.waveLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Health5 = new System.Windows.Forms.PictureBox();
            this.Health4 = new System.Windows.Forms.PictureBox();
            this.Health3 = new System.Windows.Forms.PictureBox();
            this.Health2 = new System.Windows.Forms.PictureBox();
            this.Health1 = new System.Windows.Forms.PictureBox();
            this.labelScore = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Spawn5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Spawn2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Spawn1 = new System.Windows.Forms.Panel();
            this.Player = new System.Windows.Forms.PictureBox();
            this.Spawn3 = new System.Windows.Forms.Panel();
            this.Spawn4 = new System.Windows.Forms.Panel();
            this.Fire.SuspendLayout();
            this.HUDpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Health5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Health4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Health3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Health2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Health1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // Fire
            // 
            this.Fire.BackColor = System.Drawing.Color.Red;
            this.Fire.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Fire.BackgroundImage")));
            this.Fire.Controls.Add(this.HUDpanel);
            this.Fire.Location = new System.Drawing.Point(-5, 527);
            this.Fire.Name = "Fire";
            this.Fire.Size = new System.Drawing.Size(1184, 100);
            this.Fire.TabIndex = 0;
            // 
            // HUDpanel
            // 
            this.HUDpanel.BackColor = System.Drawing.Color.Transparent;
            this.HUDpanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("HUDpanel.BackgroundImage")));
            this.HUDpanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HUDpanel.Controls.Add(this.waveLabel);
            this.HUDpanel.Controls.Add(this.label1);
            this.HUDpanel.Controls.Add(this.Health5);
            this.HUDpanel.Controls.Add(this.Health4);
            this.HUDpanel.Controls.Add(this.Health3);
            this.HUDpanel.Controls.Add(this.Health2);
            this.HUDpanel.Controls.Add(this.Health1);
            this.HUDpanel.Controls.Add(this.labelScore);
            this.HUDpanel.Location = new System.Drawing.Point(168, 3);
            this.HUDpanel.Name = "HUDpanel";
            this.HUDpanel.Size = new System.Drawing.Size(872, 94);
            this.HUDpanel.TabIndex = 0;
            this.HUDpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.HUDpanel_Paint);
            // 
            // waveLabel
            // 
            this.waveLabel.AutoSize = true;
            this.waveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waveLabel.ForeColor = System.Drawing.Color.White;
            this.waveLabel.Location = new System.Drawing.Point(294, 30);
            this.waveLabel.Name = "waveLabel";
            this.waveLabel.Size = new System.Drawing.Size(115, 39);
            this.waveLabel.TabIndex = 16;
            this.waveLabel.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(260, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 38);
            this.label1.TabIndex = 15;
            // 
            // Health5
            // 
            this.Health5.BackColor = System.Drawing.Color.Transparent;
            this.Health5.Image = ((System.Drawing.Image)(resources.GetObject("Health5.Image")));
            this.Health5.Location = new System.Drawing.Point(237, 22);
            this.Health5.Name = "Health5";
            this.Health5.Size = new System.Drawing.Size(41, 55);
            this.Health5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Health5.TabIndex = 14;
            this.Health5.TabStop = false;
            // 
            // Health4
            // 
            this.Health4.BackColor = System.Drawing.Color.Transparent;
            this.Health4.Image = ((System.Drawing.Image)(resources.GetObject("Health4.Image")));
            this.Health4.Location = new System.Drawing.Point(190, 22);
            this.Health4.Name = "Health4";
            this.Health4.Size = new System.Drawing.Size(41, 55);
            this.Health4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Health4.TabIndex = 13;
            this.Health4.TabStop = false;
            // 
            // Health3
            // 
            this.Health3.BackColor = System.Drawing.Color.Transparent;
            this.Health3.Image = ((System.Drawing.Image)(resources.GetObject("Health3.Image")));
            this.Health3.Location = new System.Drawing.Point(143, 22);
            this.Health3.Name = "Health3";
            this.Health3.Size = new System.Drawing.Size(41, 55);
            this.Health3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Health3.TabIndex = 12;
            this.Health3.TabStop = false;
            // 
            // Health2
            // 
            this.Health2.BackColor = System.Drawing.Color.Transparent;
            this.Health2.Image = ((System.Drawing.Image)(resources.GetObject("Health2.Image")));
            this.Health2.Location = new System.Drawing.Point(96, 22);
            this.Health2.Name = "Health2";
            this.Health2.Size = new System.Drawing.Size(41, 55);
            this.Health2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Health2.TabIndex = 11;
            this.Health2.TabStop = false;
            // 
            // Health1
            // 
            this.Health1.BackColor = System.Drawing.Color.Transparent;
            this.Health1.Image = ((System.Drawing.Image)(resources.GetObject("Health1.Image")));
            this.Health1.Location = new System.Drawing.Point(49, 22);
            this.Health1.Name = "Health1";
            this.Health1.Size = new System.Drawing.Size(41, 55);
            this.Health1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Health1.TabIndex = 10;
            this.Health1.TabStop = false;
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.ForeColor = System.Drawing.Color.White;
            this.labelScore.Location = new System.Drawing.Point(484, 30);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(115, 39);
            this.labelScore.TabIndex = 0;
            this.labelScore.Text = "label1";
            this.labelScore.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Maroon;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(221, 463);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(735, 44);
            this.panel2.TabIndex = 1;
            // 
            // Spawn5
            // 
            this.Spawn5.BackColor = System.Drawing.Color.Gray;
            this.Spawn5.Location = new System.Drawing.Point(853, 463);
            this.Spawn5.Name = "Spawn5";
            this.Spawn5.Size = new System.Drawing.Size(66, 10);
            this.Spawn5.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Maroon;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(-22, 249);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(330, 37);
            this.panel3.TabIndex = 2;
            // 
            // Spawn2
            // 
            this.Spawn2.BackColor = System.Drawing.Color.Gray;
            this.Spawn2.Location = new System.Drawing.Point(146, 249);
            this.Spawn2.Name = "Spawn2";
            this.Spawn2.Size = new System.Drawing.Size(66, 10);
            this.Spawn2.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Maroon;
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(853, 249);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(326, 37);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Maroon;
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel5.Location = new System.Drawing.Point(431, 85);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(296, 39);
            this.panel5.TabIndex = 4;
            // 
            // Spawn1
            // 
            this.Spawn1.BackColor = System.Drawing.Color.Gray;
            this.Spawn1.Location = new System.Drawing.Point(545, 85);
            this.Spawn1.Name = "Spawn1";
            this.Spawn1.Size = new System.Drawing.Size(66, 10);
            this.Spawn1.TabIndex = 3;
            // 
            // Player
            // 
            this.Player.BackColor = System.Drawing.Color.Transparent;
            this.Player.Image = ((System.Drawing.Image)(resources.GetObject("Player.Image")));
            this.Player.Location = new System.Drawing.Point(545, 294);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(60, 80);
            this.Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Player.TabIndex = 5;
            this.Player.TabStop = false;
            // 
            // Spawn3
            // 
            this.Spawn3.BackColor = System.Drawing.Color.Gray;
            this.Spawn3.Location = new System.Drawing.Point(938, 249);
            this.Spawn3.Name = "Spawn3";
            this.Spawn3.Size = new System.Drawing.Size(66, 10);
            this.Spawn3.TabIndex = 6;
            // 
            // Spawn4
            // 
            this.Spawn4.BackColor = System.Drawing.Color.Gray;
            this.Spawn4.Location = new System.Drawing.Point(270, 463);
            this.Spawn4.Name = "Spawn4";
            this.Spawn4.Size = new System.Drawing.Size(66, 10);
            this.Spawn4.TabIndex = 9;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1161, 619);
            this.Controls.Add(this.Spawn1);
            this.Controls.Add(this.Spawn2);
            this.Controls.Add(this.Spawn5);
            this.Controls.Add(this.Spawn4);
            this.Controls.Add(this.Spawn3);
            this.Controls.Add(this.Player);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Fire);
            this.Name = "Game";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.Fire.ResumeLayout(false);
            this.HUDpanel.ResumeLayout(false);
            this.HUDpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Health5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Health4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Health3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Health2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Health1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel Fire;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel Spawn5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel Spawn2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel Spawn1;
        private System.Windows.Forms.PictureBox Player;
        private System.Windows.Forms.Panel Spawn3;
        private System.Windows.Forms.Panel Spawn4;
        private System.Windows.Forms.Panel HUDpanel;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.PictureBox Health5;
        private System.Windows.Forms.PictureBox Health4;
        private System.Windows.Forms.PictureBox Health3;
        private System.Windows.Forms.PictureBox Health2;
        private System.Windows.Forms.PictureBox Health1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label waveLabel;
    }
}