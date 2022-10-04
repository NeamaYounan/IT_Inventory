namespace inventory2
{
    partial class Delete_User
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
            this.Name_txt = new System.Windows.Forms.TextBox();
            this.name_Deleted = new System.Windows.Forms.Label();
            this.view_User = new System.Windows.Forms.Button();
            this.ViewGride = new System.Windows.Forms.DataGridView();
            this.Confirm_Deleted = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.back = new System.Windows.Forms.Button();
            this.Project_Label = new System.Windows.Forms.Label();
            this.Project_Name = new System.Windows.Forms.TextBox();
            this.User_Not_Found = new System.Windows.Forms.DataGridView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ViewGride)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.User_Not_Found)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Name_txt
            // 
            this.Name_txt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Name_txt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Name_txt.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name_txt.Location = new System.Drawing.Point(401, 186);
            this.Name_txt.Name = "Name_txt";
            this.Name_txt.Size = new System.Drawing.Size(185, 29);
            this.Name_txt.TabIndex = 8;
            // 
            // name_Deleted
            // 
            this.name_Deleted.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.name_Deleted.Cursor = System.Windows.Forms.Cursors.Default;
            this.name_Deleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_Deleted.ForeColor = System.Drawing.Color.Azure;
            this.name_Deleted.Location = new System.Drawing.Point(57, 176);
            this.name_Deleted.Name = "name_Deleted";
            this.name_Deleted.Size = new System.Drawing.Size(236, 39);
            this.name_Deleted.TabIndex = 9;
            this.name_Deleted.Text = "Name Deleted";
            this.name_Deleted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // view_User
            // 
            this.view_User.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.view_User.Cursor = System.Windows.Forms.Cursors.Default;
            this.view_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.view_User.ForeColor = System.Drawing.Color.Azure;
            this.view_User.Location = new System.Drawing.Point(664, 249);
            this.view_User.Name = "view_User";
            this.view_User.Size = new System.Drawing.Size(133, 50);
            this.view_User.TabIndex = 10;
            this.view_User.Text = "View User";
            this.view_User.UseVisualStyleBackColor = false;
            this.view_User.Click += new System.EventHandler(this.Delete_Click);
            // 
            // ViewGride
            // 
            this.ViewGride.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ViewGride.Cursor = System.Windows.Forms.Cursors.Default;
            this.ViewGride.Location = new System.Drawing.Point(32, 332);
            this.ViewGride.Name = "ViewGride";
            this.ViewGride.Size = new System.Drawing.Size(784, 135);
            this.ViewGride.TabIndex = 11;
            // 
            // Confirm_Deleted
            // 
            this.Confirm_Deleted.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.Confirm_Deleted.Cursor = System.Windows.Forms.Cursors.Default;
            this.Confirm_Deleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Confirm_Deleted.ForeColor = System.Drawing.Color.Azure;
            this.Confirm_Deleted.Location = new System.Drawing.Point(663, 553);
            this.Confirm_Deleted.Name = "Confirm_Deleted";
            this.Confirm_Deleted.Size = new System.Drawing.Size(133, 50);
            this.Confirm_Deleted.TabIndex = 12;
            this.Confirm_Deleted.Text = "Confirm ";
            this.Confirm_Deleted.UseVisualStyleBackColor = false;
            this.Confirm_Deleted.Click += new System.EventHandler(this.Confirm_Deleted_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.BackColor = System.Drawing.Color.LightCyan;
            this.checkBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkBox1.ForeColor = System.Drawing.Color.Blue;
            this.checkBox1.Location = new System.Drawing.Point(651, 176);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(98, 35);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "Transferred";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            this.checkBox1.CheckStateChanged += new System.EventHandler(this.ch);
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.back.Cursor = System.Windows.Forms.Cursors.Default;
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.Azure;
            this.back.Location = new System.Drawing.Point(33, 553);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(133, 50);
            this.back.TabIndex = 14;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // Project_Label
            // 
            this.Project_Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.Project_Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.Project_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Project_Label.ForeColor = System.Drawing.Color.Azure;
            this.Project_Label.Location = new System.Drawing.Point(53, 239);
            this.Project_Label.Name = "Project_Label";
            this.Project_Label.Size = new System.Drawing.Size(240, 39);
            this.Project_Label.TabIndex = 16;
            this.Project_Label.Text = "Project want Transfer";
            this.Project_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Project_Label.Visible = false;
            // 
            // Project_Name
            // 
            this.Project_Name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Project_Name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Project_Name.Cursor = System.Windows.Forms.Cursors.Default;
            this.Project_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Project_Name.Location = new System.Drawing.Point(401, 249);
            this.Project_Name.Name = "Project_Name";
            this.Project_Name.Size = new System.Drawing.Size(185, 29);
            this.Project_Name.TabIndex = 15;
            this.Project_Name.Visible = false;
            this.Project_Name.VisibleChanged += new System.EventHandler(this.Project_Name_VisibleChanged);
            // 
            // User_Not_Found
            // 
            this.User_Not_Found.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.User_Not_Found.Cursor = System.Windows.Forms.Cursors.Default;
            this.User_Not_Found.Location = new System.Drawing.Point(33, 332);
            this.User_Not_Found.Name = "User_Not_Found";
            this.User_Not_Found.Size = new System.Drawing.Size(784, 135);
            this.User_Not_Found.TabIndex = 17;
            this.User_Not_Found.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox2.Image = global::inventory2.Properties.Resources.iti;
            this.pictureBox2.Location = new System.Drawing.Point(743, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(103, 90);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 97;
            this.pictureBox2.TabStop = false;
            // 
            // Delete_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(847, 615);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.User_Not_Found);
            this.Controls.Add(this.Project_Label);
            this.Controls.Add(this.Project_Name);
            this.Controls.Add(this.back);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Confirm_Deleted);
            this.Controls.Add(this.ViewGride);
            this.Controls.Add(this.view_User);
            this.Controls.Add(this.name_Deleted);
            this.Controls.Add(this.Name_txt);
            this.Name = "Delete_User";
            this.Text = "Delete User";
            this.Load += new System.EventHandler(this.Delete_User_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ViewGride)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.User_Not_Found)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Name_txt;
        private System.Windows.Forms.Label name_Deleted;
        private System.Windows.Forms.Button view_User;
        private System.Windows.Forms.DataGridView ViewGride;
        private System.Windows.Forms.Button Confirm_Deleted;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Label Project_Label;
        private System.Windows.Forms.TextBox Project_Name;
        private System.Windows.Forms.DataGridView User_Not_Found;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}