
using System;

namespace Pong
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Player1 = new System.Windows.Forms.Button();
            this.Player2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Ball = new System.Windows.Forms.Button();
            this.P1panel1 = new System.Windows.Forms.Panel();
            this.P1panel2 = new System.Windows.Forms.Panel();
            this.P2panel2 = new System.Windows.Forms.Panel();
            this.P2panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.P1Score = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.P2Score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Location = new System.Drawing.Point(445, 351);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 75);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Location = new System.Drawing.Point(445, 457);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 75);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Location = new System.Drawing.Point(445, 556);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 75);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Location = new System.Drawing.Point(445, 666);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 75);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.Location = new System.Drawing.Point(445, 245);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(10, 75);
            this.panel5.TabIndex = 1;
            // 
            // Player1
            // 
            this.Player1.BackColor = System.Drawing.Color.White;
            this.Player1.Enabled = false;
            this.Player1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.Player1.FlatAppearance.BorderSize = 4;
            this.Player1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Player1.ForeColor = System.Drawing.Color.White;
            this.Player1.Location = new System.Drawing.Point(15, 326);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(20, 100);
            this.Player1.TabIndex = 3;
            this.Player1.TabStop = false;
            this.Player1.UseVisualStyleBackColor = false;
            this.Player1.Click += new System.EventHandler(this.Player1_Click_1);
            // 
            // Player2
            // 
            this.Player2.BackColor = System.Drawing.Color.White;
            this.Player2.Enabled = false;
            this.Player2.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.Player2.FlatAppearance.BorderSize = 4;
            this.Player2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Player2.ForeColor = System.Drawing.Color.White;
            this.Player2.Location = new System.Drawing.Point(850, 326);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(20, 100);
            this.Player2.TabIndex = 4;
            this.Player2.TabStop = false;
            this.Player2.UseVisualStyleBackColor = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Ball
            // 
            this.Ball.BackColor = System.Drawing.Color.White;
            this.Ball.Enabled = false;
            this.Ball.FlatAppearance.BorderColor = System.Drawing.Color.Purple;
            this.Ball.FlatAppearance.BorderSize = 4;
            this.Ball.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ball.ForeColor = System.Drawing.Color.White;
            this.Ball.Location = new System.Drawing.Point(435, 419);
            this.Ball.Name = "Ball";
            this.Ball.Size = new System.Drawing.Size(20, 20);
            this.Ball.TabIndex = 5;
            this.Ball.TabStop = false;
            this.Ball.UseVisualStyleBackColor = false;
            // 
            // P1panel1
            // 
            this.P1panel1.BackColor = System.Drawing.Color.Gold;
            this.P1panel1.ForeColor = System.Drawing.Color.Transparent;
            this.P1panel1.Location = new System.Drawing.Point(30, 326);
            this.P1panel1.Name = "P1panel1";
            this.P1panel1.Size = new System.Drawing.Size(5, 25);
            this.P1panel1.TabIndex = 6;
            // 
            // P1panel2
            // 
            this.P1panel2.BackColor = System.Drawing.Color.Gold;
            this.P1panel2.ForeColor = System.Drawing.Color.Transparent;
            this.P1panel2.Location = new System.Drawing.Point(30, 401);
            this.P1panel2.Name = "P1panel2";
            this.P1panel2.Size = new System.Drawing.Size(5, 25);
            this.P1panel2.TabIndex = 7;
            // 
            // P2panel2
            // 
            this.P2panel2.BackColor = System.Drawing.Color.Gold;
            this.P2panel2.ForeColor = System.Drawing.Color.Transparent;
            this.P2panel2.Location = new System.Drawing.Point(853, 401);
            this.P2panel2.Name = "P2panel2";
            this.P2panel2.Size = new System.Drawing.Size(5, 25);
            this.P2panel2.TabIndex = 7;
            // 
            // P2panel1
            // 
            this.P2panel1.BackColor = System.Drawing.Color.Gold;
            this.P2panel1.ForeColor = System.Drawing.Color.Transparent;
            this.P2panel1.Location = new System.Drawing.Point(853, 326);
            this.P2panel1.Name = "P2panel1";
            this.P2panel1.Size = new System.Drawing.Size(5, 25);
            this.P2panel1.TabIndex = 8;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel6.Location = new System.Drawing.Point(445, 142);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(10, 75);
            this.panel6.TabIndex = 2;
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.White;
            this.TopPanel.Location = new System.Drawing.Point(0, 110);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(900, 10);
            this.TopPanel.TabIndex = 9;
            // 
            // P1Score
            // 
            this.P1Score.AutoSize = true;
            this.P1Score.Font = new System.Drawing.Font("OCR A Extended", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1Score.Location = new System.Drawing.Point(166, 45);
            this.P1Score.Name = "P1Score";
            this.P1Score.Size = new System.Drawing.Size(121, 30);
            this.P1Score.TabIndex = 10;
            this.P1Score.Text = "label1";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel7.Location = new System.Drawing.Point(445, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(10, 112);
            this.panel7.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(676, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "label2";
            // 
            // P2Score
            // 
            this.P2Score.AutoSize = true;
            this.P2Score.Font = new System.Drawing.Font("OCR A Extended", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2Score.Location = new System.Drawing.Point(639, 45);
            this.P2Score.Name = "P2Score";
            this.P2Score.Size = new System.Drawing.Size(121, 30);
            this.P2Score.TabIndex = 11;
            this.P2Score.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(889, 653);
            this.Controls.Add(this.P2Score);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.P1Score);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.P2panel1);
            this.Controls.Add(this.P2panel2);
            this.Controls.Add(this.P1panel2);
            this.Controls.Add(this.P1panel1);
            this.Controls.Add(this.Ball);
            this.Controls.Add(this.Player2);
            this.Controls.Add(this.Player1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Player1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button Player1;
        private System.Windows.Forms.Button Player2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Ball;
        private System.Windows.Forms.Panel P1panel1;
        private System.Windows.Forms.Panel P1panel2;
        private System.Windows.Forms.Panel P2panel2;
        private System.Windows.Forms.Panel P2panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label P1Score;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label P2Score;
    }
}

