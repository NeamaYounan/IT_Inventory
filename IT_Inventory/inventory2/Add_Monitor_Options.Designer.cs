
namespace inventory2
{
    partial class Add_Monitor_Options
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
            this.new_monitor = new System.Windows.Forms.Button();
            this.spare_Monitor = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // new_monitor
            // 
            this.new_monitor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.new_monitor.Cursor = System.Windows.Forms.Cursors.Default;
            this.new_monitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_monitor.ForeColor = System.Drawing.Color.Azure;
            this.new_monitor.Location = new System.Drawing.Point(427, 122);
            this.new_monitor.Name = "new_monitor";
            this.new_monitor.Size = new System.Drawing.Size(290, 62);
            this.new_monitor.TabIndex = 18;
            this.new_monitor.Text = "New Monitor";
            this.new_monitor.UseMnemonic = false;
            this.new_monitor.UseVisualStyleBackColor = false;
            this.new_monitor.Click += new System.EventHandler(this.new_monitor_Click);
            // 
            // spare_Monitor
            // 
            this.spare_Monitor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.spare_Monitor.Cursor = System.Windows.Forms.Cursors.Default;
            this.spare_Monitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spare_Monitor.ForeColor = System.Drawing.Color.Azure;
            this.spare_Monitor.Location = new System.Drawing.Point(427, 250);
            this.spare_Monitor.Name = "spare_Monitor";
            this.spare_Monitor.Size = new System.Drawing.Size(290, 62);
            this.spare_Monitor.TabIndex = 17;
            this.spare_Monitor.Text = "Spare Monitor";
            this.spare_Monitor.UseMnemonic = false;
            this.spare_Monitor.UseVisualStyleBackColor = false;
            this.spare_Monitor.Click += new System.EventHandler(this.spare_Monitor_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = global::inventory2.Properties.Resources.front_shot_dual_blank_white_260nw_1730358172;
            this.pictureBox1.Location = new System.Drawing.Point(12, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(364, 322);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::inventory2.Properties.Resources.iti;
            this.pictureBox2.Location = new System.Drawing.Point(690, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(108, 90);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 100;
            this.pictureBox2.TabStop = false;
            // 
            // Add_Monitor_Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.new_monitor);
            this.Controls.Add(this.spare_Monitor);
            this.Name = "Add_Monitor_Options";
            this.Text = "Add_Monitor_Options";
            this.Load += new System.EventHandler(this.Add_Monitor_Options_Load);
            this.Resize += new System.EventHandler(this.Add_Monitor_Options_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button new_monitor;
        private System.Windows.Forms.Button spare_Monitor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}