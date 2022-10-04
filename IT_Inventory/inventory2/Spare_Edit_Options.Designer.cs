
namespace inventory2
{
    partial class Spare_Edit_Options
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
            this.new_Software = new System.Windows.Forms.Button();
            this.spare_software = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // new_Software
            // 
            this.new_Software.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.new_Software.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_Software.ForeColor = System.Drawing.Color.Azure;
            this.new_Software.Location = new System.Drawing.Point(446, 160);
            this.new_Software.Name = "new_Software";
            this.new_Software.Size = new System.Drawing.Size(290, 62);
            this.new_Software.TabIndex = 17;
            this.new_Software.Text = "Hardware";
            this.new_Software.UseMnemonic = false;
            this.new_Software.UseVisualStyleBackColor = false;
            this.new_Software.Click += new System.EventHandler(this.new_Software_Click);
            // 
            // spare_software
            // 
            this.spare_software.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.spare_software.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spare_software.ForeColor = System.Drawing.Color.Azure;
            this.spare_software.Location = new System.Drawing.Point(446, 288);
            this.spare_software.Name = "spare_software";
            this.spare_software.Size = new System.Drawing.Size(290, 62);
            this.spare_software.TabIndex = 16;
            this.spare_software.Text = " Software ";
            this.spare_software.UseMnemonic = false;
            this.spare_software.UseVisualStyleBackColor = false;
            this.spare_software.Click += new System.EventHandler(this.spare_software_Click);
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.Azure;
            this.back.Location = new System.Drawing.Point(12, 393);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(87, 45);
            this.back.TabIndex = 87;
            this.back.Text = "Back";
            this.back.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            this.back.Resize += new System.EventHandler(this.Spare_Edit_Options_Resize);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::inventory2.Properties.Resources.YYYY;
            this.pictureBox1.Location = new System.Drawing.Point(-4, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(319, 386);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 100;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::inventory2.Properties.Resources.iti;
            this.pictureBox3.Location = new System.Drawing.Point(688, -4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 91);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 102;
            this.pictureBox3.TabStop = false;
            // 
            // Spare_Edit_Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(799, 458);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.back);
            this.Controls.Add(this.new_Software);
            this.Controls.Add(this.spare_software);
            this.Name = "Spare_Edit_Options";
            this.Text = "Spare_Edit_Options";
            this.Load += new System.EventHandler(this.Spare_Edit_Options_Load);
            this.Resize += new System.EventHandler(this.Spare_Edit_Options_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button new_Software;
        private System.Windows.Forms.Button spare_software;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}