
namespace inventory2
{
    partial class Add_New_User_Options
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
            this.new_device = new System.Windows.Forms.Button();
            this.from_spare = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // new_device
            // 
            this.new_device.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.new_device.Cursor = System.Windows.Forms.Cursors.Default;
            this.new_device.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_device.ForeColor = System.Drawing.Color.Azure;
            this.new_device.Location = new System.Drawing.Point(404, 187);
            this.new_device.Name = "new_device";
            this.new_device.Size = new System.Drawing.Size(360, 71);
            this.new_device.TabIndex = 14;
            this.new_device.Text = "New Device & Software";
            this.new_device.UseMnemonic = false;
            this.new_device.UseVisualStyleBackColor = false;
            this.new_device.Click += new System.EventHandler(this.new_device_Click);
            // 
            // from_spare
            // 
            this.from_spare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.from_spare.Cursor = System.Windows.Forms.Cursors.Default;
            this.from_spare.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.from_spare.ForeColor = System.Drawing.Color.Azure;
            this.from_spare.Location = new System.Drawing.Point(404, 332);
            this.from_spare.Name = "from_spare";
            this.from_spare.Size = new System.Drawing.Size(360, 65);
            this.from_spare.TabIndex = 13;
            this.from_spare.Text = "Add From Spare";
            this.from_spare.UseMnemonic = false;
            this.from_spare.UseVisualStyleBackColor = false;
            this.from_spare.Click += new System.EventHandler(this.from_spare_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = global::inventory2.Properties.Resources.cccvsf;
            this.pictureBox1.Location = new System.Drawing.Point(-6, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(339, 545);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::inventory2.Properties.Resources.iti;
            this.pictureBox2.Location = new System.Drawing.Point(727, -1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(108, 90);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 100;
            this.pictureBox2.TabStop = false;
            // 
            // Add_New_User_Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(838, 541);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.new_device);
            this.Controls.Add(this.from_spare);
            this.Name = "Add_New_User_Options";
            this.Text = "Add_New_User_Options";
            this.Load += new System.EventHandler(this.Add_New_User_Options_Load);
            this.Resize += new System.EventHandler(this.Add_New_User_Options_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button new_device;
        private System.Windows.Forms.Button from_spare;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}