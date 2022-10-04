
namespace inventory2
{
    partial class Edit_Spare_Hardware
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Back = new System.Windows.Forms.Button();
            this.data_grid = new System.Windows.Forms.DataGridView();
            this.Save = new System.Windows.Forms.Button();
            this.iT_InventoryDataSet = new inventory2.IT_InventoryDataSet();
            this.iTInventoryDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.laptopsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.laptopsTableAdapter = new inventory2.IT_InventoryDataSetTableAdapters.LaptopsTableAdapter();
            this.grid_2 = new System.Windows.Forms.DataGridView();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iT_InventoryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTInventoryDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laptopsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Back.ForeColor = System.Drawing.Color.Azure;
            this.Back.Location = new System.Drawing.Point(170, 597);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(94, 41);
            this.Back.TabIndex = 14;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // data_grid
            // 
            this.data_grid.BackgroundColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.data_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_grid.Location = new System.Drawing.Point(133, 118);
            this.data_grid.Margin = new System.Windows.Forms.Padding(2);
            this.data_grid.Name = "data_grid";
            this.data_grid.RowHeadersWidth = 62;
            this.data_grid.RowTemplate.Height = 28;
            this.data_grid.Size = new System.Drawing.Size(765, 228);
            this.data_grid.TabIndex = 13;
            this.data_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_grid_CellContentClick);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.ForeColor = System.Drawing.Color.Azure;
            this.Save.Location = new System.Drawing.Point(804, 597);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(94, 41);
            this.Save.TabIndex = 15;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // iT_InventoryDataSet
            // 
            this.iT_InventoryDataSet.DataSetName = "IT_InventoryDataSet";
            this.iT_InventoryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // iTInventoryDataSetBindingSource
            // 
            this.iTInventoryDataSetBindingSource.DataSource = this.iT_InventoryDataSet;
            this.iTInventoryDataSetBindingSource.Position = 0;
            this.iTInventoryDataSetBindingSource.CurrentChanged += new System.EventHandler(this.iTInventoryDataSetBindingSource_CurrentChanged);
            // 
            // laptopsBindingSource
            // 
            this.laptopsBindingSource.DataMember = "Laptops";
            this.laptopsBindingSource.DataSource = this.iT_InventoryDataSet;
            this.laptopsBindingSource.CurrentChanged += new System.EventHandler(this.laptopsBindingSource_CurrentChanged);
            // 
            // laptopsTableAdapter
            // 
            this.laptopsTableAdapter.ClearBeforeFill = true;
            // 
            // grid_2
            // 
            this.grid_2.BackgroundColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_2.Location = new System.Drawing.Point(133, 363);
            this.grid_2.Margin = new System.Windows.Forms.Padding(2);
            this.grid_2.Name = "grid_2";
            this.grid_2.RowHeadersWidth = 62;
            this.grid_2.RowTemplate.Height = 28;
            this.grid_2.Size = new System.Drawing.Size(765, 193);
            this.grid_2.TabIndex = 16;
            this.grid_2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_2_CellContentClick);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::inventory2.Properties.Resources.iti;
            this.pictureBox3.Location = new System.Drawing.Point(913, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(102, 85);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 103;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::inventory2.Properties.Resources.download__1___1_;
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 102;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Edit_Spare_Hardware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1072, 700);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grid_2);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.data_grid);
            this.Name = "Edit_Spare_Hardware";
            this.Text = "Edit_by_using_spare";
            this.Load += new System.EventHandler(this.Edit_by_using_spare_Load);
            this.Resize += new System.EventHandler(this.Edit_Spare_Hardware_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.data_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iT_InventoryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTInventoryDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laptopsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.BindingSource iTInventoryDataSetBindingSource;
        private IT_InventoryDataSet iT_InventoryDataSet;
        private System.Windows.Forms.BindingSource laptopsBindingSource;
        private IT_InventoryDataSetTableAdapters.LaptopsTableAdapter laptopsTableAdapter;
        public System.Windows.Forms.DataGridView data_grid;
        public System.Windows.Forms.DataGridView grid_2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}