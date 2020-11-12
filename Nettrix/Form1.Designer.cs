namespace Nettrix
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.onButton_Start = new System.Windows.Forms.Button();
            this.gamefieldBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gamefieldBox)).BeginInit();
            this.SuspendLayout();
            // 
            // onButton_Start
            // 
            this.onButton_Start.Location = new System.Drawing.Point(343, 188);
            this.onButton_Start.Name = "onButton_Start";
            this.onButton_Start.Size = new System.Drawing.Size(75, 23);
            this.onButton_Start.TabIndex = 0;
            this.onButton_Start.Text = "Start Game";
            this.onButton_Start.UseVisualStyleBackColor = true;
            this.onButton_Start.Click += new System.EventHandler(this.onButton_Start_Click);
            // 
            // gamefieldBox
            // 
            this.gamefieldBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gamefieldBox.Location = new System.Drawing.Point(12, 12);
            this.gamefieldBox.Name = "gamefieldBox";
            this.gamefieldBox.Size = new System.Drawing.Size(265, 415);
            this.gamefieldBox.TabIndex = 1;
            this.gamefieldBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gamefieldBox);
            this.Controls.Add(this.onButton_Start);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gamefieldBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button onButton_Start;
        private System.Windows.Forms.PictureBox gamefieldBox;
    }
}

