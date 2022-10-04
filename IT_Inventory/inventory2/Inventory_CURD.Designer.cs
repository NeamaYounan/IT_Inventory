namespace inventory2
{
    partial class Inventory_CURD
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
            this.components = new System.ComponentModel.Container();
            this.Add_op = new System.Windows.Forms.Button();
            this.edit_op = new System.Windows.Forms.Button();
            this.iT_InventoryDataSet = new inventory2.IT_InventoryDataSet();
            this.desktopBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.desktopTableAdapter = new inventory2.IT_InventoryDataSetTableAdapters.DesktopTableAdapter();
            this.search_op = new System.Windows.Forms.Button();
            this.Export = new System.Windows.Forms.Button();
            this.multi = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.iT_InventoryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.desktopBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Add_op
            // 
            this.Add_op.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.Add_op.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Add_op.FlatAppearance.BorderSize = 3;
            this.Add_op.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add_op.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add_op.ForeColor = System.Drawing.Color.AliceBlue;
            this.Add_op.Location = new System.Drawing.Point(419, 33);
            this.Add_op.Name = "Add_op";
            this.Add_op.Size = new System.Drawing.Size(328, 51);
            this.Add_op.TabIndex = 1;
            this.Add_op.Text = "New User";
            this.Add_op.UseVisualStyleBackColor = false;
            this.Add_op.Click += new System.EventHandler(this.Add_op_Click);
            // 
            // edit_op
            // 
            this.edit_op.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.edit_op.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.edit_op.FlatAppearance.BorderSize = 3;
            this.edit_op.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edit_op.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edit_op.ForeColor = System.Drawing.Color.Azure;
            this.edit_op.Location = new System.Drawing.Point(419, 189);
            this.edit_op.Name = "edit_op";
            this.edit_op.Size = new System.Drawing.Size(328, 51);
            this.edit_op.TabIndex = 5;
            this.edit_op.Text = "Edit";
            this.edit_op.UseVisualStyleBackColor = false;
            this.edit_op.Click += new System.EventHandler(this.edit_op_Click);
            // 
            // iT_InventoryDataSet
            // 
            this.iT_InventoryDataSet.DataSetName = "IT_InventoryDataSet";
            this.iT_InventoryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // desktopBindingSource
            // 
            this.desktopBindingSource.DataMember = "Desktop";
            this.desktopBindingSource.DataSource = this.iT_InventoryDataSet;
            // 
            // desktopTableAdapter
            // 
            this.desktopTableAdapter.ClearBeforeFill = true;
            // 
            // search_op
            // 
            this.search_op.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.search_op.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.search_op.FlatAppearance.BorderSize = 3;
            this.search_op.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_op.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_op.ForeColor = System.Drawing.Color.Azure;
            this.search_op.Location = new System.Drawing.Point(419, 111);
            this.search_op.Name = "search_op";
            this.search_op.Size = new System.Drawing.Size(328, 51);
            this.search_op.TabIndex = 7;
            this.search_op.Text = "Search";
            this.search_op.UseVisualStyleBackColor = false;
            this.search_op.Click += new System.EventHandler(this.search_op_Click_1);
            // 
            // Export
            // 
            this.Export.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.Export.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Export.FlatAppearance.BorderSize = 3;
            this.Export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Export.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Export.ForeColor = System.Drawing.Color.Azure;
            this.Export.Location = new System.Drawing.Point(419, 423);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(328, 51);
            this.Export.TabIndex = 8;
            this.Export.Text = "Total Inventory";
            this.Export.UseVisualStyleBackColor = false;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // multi
            // 
            this.multi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.multi.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.multi.FlatAppearance.BorderSize = 3;
            this.multi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.multi.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multi.ForeColor = System.Drawing.Color.Azure;
            this.multi.Location = new System.Drawing.Point(419, 267);
            this.multi.Name = "multi";
            this.multi.Size = new System.Drawing.Size(328, 51);
            this.multi.TabIndex = 9;
            this.multi.Text = "Import";
            this.multi.UseVisualStyleBackColor = false;
            this.multi.Click += new System.EventHandler(this.multi_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Azure;
            this.button1.Location = new System.Drawing.Point(419, 345);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(328, 51);
            this.button1.TabIndex = 12;
            this.button1.Text = "Stock";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(106)))), ((int)(((byte)(187)))));
            this.pictureBox2.Image = global::inventory2.Properties.Resources.bg7;
            this.pictureBox2.Location = new System.Drawing.Point(-8, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(392, 576);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // Inventory_CURD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(782, 575);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.multi);
            this.Controls.Add(this.Export);
            this.Controls.Add(this.search_op);
            this.Controls.Add(this.edit_op);
            this.Controls.Add(this.Add_op);
            this.Name = "Inventory_CURD";
            this.Text = "Inventory_CURD";
            this.Load += new System.EventHandler(this.Inventory_CURD_Load);
            this.Resize += new System.EventHandler(this.Inventory_Curd_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.iT_InventoryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.desktopBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Add_op;
        private System.Windows.Forms.Button edit_op;
        private IT_InventoryDataSet iT_InventoryDataSet;
        private System.Windows.Forms.BindingSource desktopBindingSource;
        private IT_InventoryDataSetTableAdapters.DesktopTableAdapter desktopTableAdapter;
        private System.Windows.Forms.Button search_op;
        private System.Windows.Forms.Button Export;
        private System.Windows.Forms.Button multi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}