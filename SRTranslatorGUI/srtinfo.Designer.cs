namespace SRTranslatorGUI
{
    partial class srtinfo
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.strname = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.strstatus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Indexsrt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // strname
            // 
            this.strname.Location = new System.Drawing.Point(35, 8);
            this.strname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.strname.Name = "strname";
            this.strname.Size = new System.Drawing.Size(275, 21);
            this.strname.TabIndex = 0;
            this.strname.Text = "srtname";
            this.strname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(164, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Retry";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(390, 5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(172, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // strstatus
            // 
            this.strstatus.AutoSize = true;
            this.strstatus.Location = new System.Drawing.Point(317, 12);
            this.strstatus.Name = "strstatus";
            this.strstatus.Size = new System.Drawing.Size(37, 13);
            this.strstatus.TabIndex = 3;
            this.strstatus.Text = "Status";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Green;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 31);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Indexsrt
            // 
            this.Indexsrt.AutoSize = true;
            this.Indexsrt.BackColor = System.Drawing.Color.Green;
            this.Indexsrt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Indexsrt.Location = new System.Drawing.Point(3, 8);
            this.Indexsrt.Name = "Indexsrt";
            this.Indexsrt.Size = new System.Drawing.Size(25, 13);
            this.Indexsrt.TabIndex = 5;
            this.Indexsrt.Text = "999";
            // 
            // srtinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.Indexsrt);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.strstatus);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.strname);
            this.Name = "srtinfo";
            this.Size = new System.Drawing.Size(605, 31);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label strname;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label strstatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Indexsrt;
    }
}
