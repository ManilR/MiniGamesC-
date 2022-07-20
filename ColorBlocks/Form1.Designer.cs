
namespace ColorBlocks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.endGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.SkyBlue;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // endGame
            // 
            this.endGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.endGame.BackColor = System.Drawing.Color.Black;
            this.endGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.endGame.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.endGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.endGame.ForeColor = System.Drawing.Color.White;
            this.endGame.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.endGame.Location = new System.Drawing.Point(275, 480);
            this.endGame.MaximumSize = new System.Drawing.Size(460, 120);
            this.endGame.Name = "endGame";
            this.endGame.Size = new System.Drawing.Size(230, 60);
            this.endGame.TabIndex = 1;
            this.endGame.Text = "TERMINER PARTIE";
            this.endGame.UseVisualStyleBackColor = false;
            this.endGame.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.endGame);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button endGame;
    }
}

