namespace inventory2
{
    partial class Transform
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
            this.First_Name = new System.Windows.Forms.TextBox();
            this.Second_Name = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Type_Text = new System.Windows.Forms.ComboBox();
            this.Search_Grid = new System.Windows.Forms.DataGridView();
            this.confirm = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Search_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // First_Name
            // 
            this.First_Name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.First_Name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.First_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.First_Name.Location = new System.Drawing.Point(345, 10);
            this.First_Name.Name = "First_Name";
            this.First_Name.Size = new System.Drawing.Size(251, 29);
            this.First_Name.TabIndex = 81;
            this.First_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Second_Name
            // 
            this.Second_Name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Second_Name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Second_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Second_Name.Location = new System.Drawing.Point(345, 71);
            this.Second_Name.Name = "Second_Name";
            this.Second_Name.Size = new System.Drawing.Size(251, 29);
            this.Second_Name.TabIndex = 82;
            this.Second_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Indigo;
            this.label8.Image = global::inventory2.Properties.Resources._55;
            this.label8.Location = new System.Drawing.Point(133, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(168, 35);
            this.label8.TabIndex = 83;
            this.label8.Text = "First User";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Image = global::inventory2.Properties.Resources._55;
            this.label1.Location = new System.Drawing.Point(133, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 35);
            this.label1.TabIndex = 84;
            this.label1.Text = "Second  User";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Indigo;
            this.label2.Image = global::inventory2.Properties.Resources._55;
            this.label2.Location = new System.Drawing.Point(133, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 57);
            this.label2.TabIndex = 85;
            this.label2.Text = "Types Want Transfer";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Type_Text
            // 
            this.Type_Text.AllowDrop = true;
            this.Type_Text.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Type_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.Type_Text.FormattingEnabled = true;
            this.Type_Text.Location = new System.Drawing.Point(345, 125);
            this.Type_Text.Name = "Type_Text";
            this.Type_Text.Size = new System.Drawing.Size(251, 32);
            this.Type_Text.TabIndex = 86;
            // 
            // Search_Grid
            // 
            this.Search_Grid.AllowUserToOrderColumns = true;
            this.Search_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Search_Grid.Location = new System.Drawing.Point(32, 197);
            this.Search_Grid.Name = "Search_Grid";
            this.Search_Grid.Size = new System.Drawing.Size(743, 174);
            this.Search_Grid.TabIndex = 90;
            // 
            // confirm
            // 
            this.confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirm.Location = new System.Drawing.Point(560, 404);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(195, 45);
            this.confirm.TabIndex = 91;
            this.confirm.Text = "Confirm Transfer";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.save_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(656, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 33);
            this.button1.TabIndex = 92;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // back
            // 
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.Location = new System.Drawing.Point(32, 393);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(95, 45);
            this.back.TabIndex = 93;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // Transform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::inventory2.Properties.Resources._55;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.back);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.Search_Grid);
            this.Controls.Add(this.Type_Text);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Second_Name);
            this.Controls.Add(this.First_Name);
            this.Name = "Transform";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.Search_Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox First_Name;
        private System.Windows.Forms.TextBox Second_Name;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Type_Text;
        private System.Windows.Forms.DataGridView Search_Grid;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button back;
    }
}