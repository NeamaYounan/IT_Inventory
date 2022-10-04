
namespace inventory2
{
    partial class add_desktop_from_spare_old_user
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
            this.next = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.Search_Grid = new System.Windows.Forms.DataGridView();
            this.back = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Search_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // next
            // 
            this.next.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.next.Location = new System.Drawing.Point(681, 385);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(87, 45);
            this.next.TabIndex = 69;
            this.next.Text = "Next";
            this.next.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // save
            // 
            this.save.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save.Location = new System.Drawing.Point(356, 385);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(87, 45);
            this.save.TabIndex = 68;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // Search_Grid
            // 
            this.Search_Grid.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.Search_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Search_Grid.Location = new System.Drawing.Point(31, 104);
            this.Search_Grid.Margin = new System.Windows.Forms.Padding(2);
            this.Search_Grid.Name = "Search_Grid";
            this.Search_Grid.RowHeadersWidth = 62;
            this.Search_Grid.RowTemplate.Height = 28;
            this.Search_Grid.Size = new System.Drawing.Size(737, 236);
            this.Search_Grid.TabIndex = 66;
            // 
            // back
            // 
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.Location = new System.Drawing.Point(59, 385);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(87, 45);
            this.back.TabIndex = 70;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Indigo;
            this.label6.Image = global::inventory2.Properties.Resources._55;
            this.label6.Location = new System.Drawing.Point(171, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 36);
            this.label6.TabIndex = 81;
            this.label6.Text = "Name";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // name
            // 
            this.name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(387, 34);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(251, 29);
            this.name.TabIndex = 80;
            this.name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // add_desktop_from_spare_old_user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::inventory2.Properties.Resources._55;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.name);
            this.Controls.Add(this.back);
            this.Controls.Add(this.next);
            this.Controls.Add(this.save);
            this.Controls.Add(this.Search_Grid);
            this.Name = "add_desktop_from_spare_old_user";
            this.Text = "add_desktop_from_spare_old_user";
            this.Load += new System.EventHandler(this.add_desktop_from_spare_old_user_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Search_Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.DataGridView Search_Grid;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox name;
    }
}