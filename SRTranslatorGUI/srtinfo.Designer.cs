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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.strstatus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Indexsrt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // strname
            // 
            this.strname.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.strname.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.strname.Location = new System.Drawing.Point(35, 0);
            this.strname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.strname.Name = "strname";
            this.strname.Size = new System.Drawing.Size(275, 31);
            this.strname.TabIndex = 0;
            this.strname.Text = "srtname";
            this.strname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.strstatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.strstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strstatus.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.strstatus.Location = new System.Drawing.Point(317, 0);
            this.strstatus.Name = "strstatus";
            this.strstatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.strstatus.Size = new System.Drawing.Size(67, 31);
            this.strstatus.TabIndex = 3;
            this.strstatus.Text = "Status";
            this.strstatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.Indexsrt.BackColor = System.Drawing.Color.Green;
            this.Indexsrt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Indexsrt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Indexsrt.Location = new System.Drawing.Point(0, 0);
            this.Indexsrt.Name = "Indexsrt";
            this.Indexsrt.Size = new System.Drawing.Size(33, 31);
            this.Indexsrt.TabIndex = 5;
            this.Indexsrt.Text = "999";
            this.Indexsrt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.Controls.Add(this.strname);
            this.Name = "srtinfo";
            this.Size = new System.Drawing.Size(574, 31);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label strname;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label strstatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Indexsrt;
    }
}
