namespace inventory2
{
    partial class Edit_by_spare_options
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
            this.back = new System.Windows.Forms.Button();
            this.new_Software = new System.Windows.Forms.Button();
            this.spare_software = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.Azure;
            this.back.Location = new System.Drawing.Point(9, 402);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(87, 45);
            this.back.TabIndex = 90;
            this.back.Text = "Back";
            this.back.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // new_Software
            // 
            this.new_Software.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.new_Software.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_Software.ForeColor = System.Drawing.Color.Azure;
            this.new_Software.Location = new System.Drawing.Point(443, 169);
            this.new_Software.Name = "new_Software";
            this.new_Software.Size = new System.Drawing.Size(290, 62);
            this.new_Software.TabIndex = 89;
            this.new_Software.Text = "Edit Software";
            this.new_Software.UseMnemonic = false;
            this.new_Software.UseVisualStyleBackColor = false;
            this.new_Software.Click += new System.EventHandler(this.new_Software_Click);
            // 
            // spare_software
            // 
            this.spare_software.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.spare_software.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spare_software.ForeColor = System.Drawing.Color.Azure;
            this.spare_software.Location = new System.Drawing.Point(443, 297);
            this.spare_software.Name = "spare_software";
            this.spare_software.Size = new System.Drawing.Size(290, 62);
            this.spare_software.TabIndex = 88;
            this.spare_software.Text = " Edit Device & Software ";
            this.spare_software.UseMnemonic = false;
            this.spare_software.UseVisualStyleBackColor = false;
            this.spare_software.Click += new System.EventHandler(this.spare_software_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::inventory2.Properties.Resources.YYYY;
            this.pictureBox1.Location = new System.Drawing.Point(-3, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(319, 386);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 101;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::inventory2.Properties.Resources.iti;
            this.pictureBox2.Location = new System.Drawing.Point(686, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(112, 93);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 102;
            this.pictureBox2.TabStop = false;
            // 
            // Edit_by_spare_options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.back);
            this.Controls.Add(this.new_Software);
            this.Controls.Add(this.spare_software);
            this.Name = "Edit_by_spare_options";
            this.Text = "Edit_by_spare_options";
            this.Load += new System.EventHandler(this.Edit_by_spare_options_Load);
            this.Resize += new System.EventHandler(this.Edit_by_spare_options_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button new_Software;
        private System.Windows.Forms.Button spare_software;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}