
namespace inventory2
{
    partial class Add_From_Spare
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
            this.button1 = new System.Windows.Forms.Button();
            this.old_user_add_laptop = new System.Windows.Forms.Button();
            this.old_user_add_desktop = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Azure;
            this.button1.Location = new System.Drawing.Point(12, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 45);
            this.button1.TabIndex = 19;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // old_user_add_laptop
            // 
            this.old_user_add_laptop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.old_user_add_laptop.Cursor = System.Windows.Forms.Cursors.Default;
            this.old_user_add_laptop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.old_user_add_laptop.ForeColor = System.Drawing.Color.Azure;
            this.old_user_add_laptop.Location = new System.Drawing.Point(407, 144);
            this.old_user_add_laptop.Name = "old_user_add_laptop";
            this.old_user_add_laptop.Size = new System.Drawing.Size(290, 62);
            this.old_user_add_laptop.TabIndex = 18;
            this.old_user_add_laptop.Text = "Add Laptop";
            this.old_user_add_laptop.UseMnemonic = false;
            this.old_user_add_laptop.UseVisualStyleBackColor = false;
            this.old_user_add_laptop.Click += new System.EventHandler(this.old_user_add_laptop_Click);
            // 
            // old_user_add_desktop
            // 
            this.old_user_add_desktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.old_user_add_desktop.Cursor = System.Windows.Forms.Cursors.Default;
            this.old_user_add_desktop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.old_user_add_desktop.ForeColor = System.Drawing.Color.Azure;
            this.old_user_add_desktop.Location = new System.Drawing.Point(407, 240);
            this.old_user_add_desktop.Name = "old_user_add_desktop";
            this.old_user_add_desktop.Size = new System.Drawing.Size(290, 62);
            this.old_user_add_desktop.TabIndex = 16;
            this.old_user_add_desktop.Text = "Add Desktop";
            this.old_user_add_desktop.UseMnemonic = false;
            this.old_user_add_desktop.UseVisualStyleBackColor = false;
            this.old_user_add_desktop.Click += new System.EventHandler(this.old_user_add_desktop_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox2.Image = global::inventory2.Properties.Resources.iti1;
            this.pictureBox2.Location = new System.Drawing.Point(681, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(116, 95);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 97;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = global::inventory2.Properties.Resources.YYYY;
            this.pictureBox1.Location = new System.Drawing.Point(3, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(319, 386);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 96;
            this.pictureBox1.TabStop = false;
            // 
            // Add_From_Spare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.old_user_add_laptop);
            this.Controls.Add(this.old_user_add_desktop);
            this.Name = "Add_From_Spare";
            this.Text = "Add_From_Spare";
            this.Load += new System.EventHandler(this.Add_From_Spare_Load);
            this.Resize += new System.EventHandler(this.Add_From_Spare_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button old_user_add_laptop;
        private System.Windows.Forms.Button old_user_add_desktop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}