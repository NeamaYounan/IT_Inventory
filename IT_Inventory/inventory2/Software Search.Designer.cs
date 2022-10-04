namespace inventory2
{
    partial class Software_Search
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Search_Software = new System.Windows.Forms.Button();
            this.Key_Text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Version_Text = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Mail_Text = new System.Windows.Forms.TextBox();
            this.Search_Grid = new System.Windows.Forms.DataGridView();
            this.Back = new System.Windows.Forms.Button();
            this.softwareBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iTInventoryDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iT_InventoryDataSet = new inventory2.IT_InventoryDataSet();
            this.softwareBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.softwareTableAdapter = new inventory2.IT_InventoryDataSetTableAdapters.SoftwareTableAdapter();
            this.softwareBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.Type_Text = new System.Windows.Forms.ComboBox();
            this.softwareBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Search_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTInventoryDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iT_InventoryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // Search_Software
            // 
            this.Search_Software.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.Search_Software.Cursor = System.Windows.Forms.Cursors.Default;
            this.Search_Software.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.Search_Software.ForeColor = System.Drawing.Color.Azure;
            this.Search_Software.Location = new System.Drawing.Point(817, 283);
            this.Search_Software.Name = "Search_Software";
            this.Search_Software.Size = new System.Drawing.Size(109, 50);
            this.Search_Software.TabIndex = 0;
            this.Search_Software.Text = "Search";
            this.Search_Software.UseVisualStyleBackColor = false;
            this.Search_Software.Click += new System.EventHandler(this.Search_Software_Click);
            // 
            // Key_Text
            // 
            this.Key_Text.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Key_Text.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Key_Text.Cursor = System.Windows.Forms.Cursors.Default;
            this.Key_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Key_Text.Location = new System.Drawing.Point(608, 177);
            this.Key_Text.Name = "Key_Text";
            this.Key_Text.Size = new System.Drawing.Size(212, 29);
            this.Key_Text.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Azure;
            this.label1.Location = new System.Drawing.Point(393, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Key";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Azure;
            this.label2.Location = new System.Drawing.Point(393, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 39);
            this.label2.TabIndex = 4;
            this.label2.Text = "Type";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Azure;
            this.label3.Location = new System.Drawing.Point(393, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 39);
            this.label3.TabIndex = 6;
            this.label3.Text = "Version";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Version_Text
            // 
            this.Version_Text.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Version_Text.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Version_Text.Cursor = System.Windows.Forms.Cursors.Default;
            this.Version_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Version_Text.Location = new System.Drawing.Point(608, 120);
            this.Version_Text.Name = "Version_Text";
            this.Version_Text.Size = new System.Drawing.Size(212, 31);
            this.Version_Text.TabIndex = 5;
            this.Version_Text.TextChanged += new System.EventHandler(this.Version_Text_TextChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Azure;
            this.label4.Location = new System.Drawing.Point(391, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 39);
            this.label4.TabIndex = 8;
            this.label4.Text = "E-Mail";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mail_Text
            // 
            this.Mail_Text.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Mail_Text.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Mail_Text.Cursor = System.Windows.Forms.Cursors.Default;
            this.Mail_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mail_Text.Location = new System.Drawing.Point(608, 229);
            this.Mail_Text.Name = "Mail_Text";
            this.Mail_Text.Size = new System.Drawing.Size(212, 31);
            this.Mail_Text.TabIndex = 7;
            // 
            // Search_Grid
            // 
            this.Search_Grid.BackgroundColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Search_Grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Search_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Search_Grid.Location = new System.Drawing.Point(101, 358);
            this.Search_Grid.Margin = new System.Windows.Forms.Padding(2);
            this.Search_Grid.Name = "Search_Grid";
            this.Search_Grid.RowHeadersVisible = false;
            this.Search_Grid.RowHeadersWidth = 62;
            this.Search_Grid.RowTemplate.Height = 28;
            this.Search_Grid.Size = new System.Drawing.Size(779, 170);
            this.Search_Grid.TabIndex = 11;
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(74)))), ((int)(((byte)(131)))));
            this.Back.Cursor = System.Windows.Forms.Cursors.Default;
            this.Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.Back.ForeColor = System.Drawing.Color.Azure;
            this.Back.Location = new System.Drawing.Point(30, 544);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(94, 41);
            this.Back.TabIndex = 12;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // softwareBindingSource
            // 
            this.softwareBindingSource.DataMember = "Software";
            this.softwareBindingSource.DataSource = this.iTInventoryDataSetBindingSource;
            // 
            // iTInventoryDataSetBindingSource
            // 
            this.iTInventoryDataSetBindingSource.DataSource = this.iT_InventoryDataSet;
            this.iTInventoryDataSetBindingSource.Position = 0;
            // 
            // iT_InventoryDataSet
            // 
            this.iT_InventoryDataSet.DataSetName = "IT_InventoryDataSet";
            this.iT_InventoryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // softwareBindingSource1
            // 
            this.softwareBindingSource1.DataMember = "Software";
            this.softwareBindingSource1.DataSource = this.iTInventoryDataSetBindingSource;
            // 
            // softwareTableAdapter
            // 
            this.softwareTableAdapter.ClearBeforeFill = true;
            // 
            // softwareBindingSource2
            // 
            this.softwareBindingSource2.DataMember = "Software";
            this.softwareBindingSource2.DataSource = this.iTInventoryDataSetBindingSource;
            // 
            // Type_Text
            // 
            this.Type_Text.Cursor = System.Windows.Forms.Cursors.Default;
            this.Type_Text.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Type_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.Type_Text.FormattingEnabled = true;
            this.Type_Text.Location = new System.Drawing.Point(608, 66);
            this.Type_Text.Name = "Type_Text";
            this.Type_Text.Size = new System.Drawing.Size(212, 32);
            this.Type_Text.TabIndex = 13;
            // 
            // softwareBindingSource3
            // 
            this.softwareBindingSource3.DataMember = "Software";
            this.softwareBindingSource3.DataSource = this.iTInventoryDataSetBindingSource;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView1.Location = new System.Drawing.Point(101, 358);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(779, 170);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox6.Image = global::inventory2.Properties.Resources.F;
            this.pictureBox6.Location = new System.Drawing.Point(162, 274);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(56, 47);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 26;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox5.Image = global::inventory2.Properties.Resources.images__6_;
            this.pictureBox5.Location = new System.Drawing.Point(113, 53);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(59, 58);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 25;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.LightCyan;
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox4.Image = global::inventory2.Properties.Resources.images__5___1_;
            this.pictureBox4.Location = new System.Drawing.Point(209, 140);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(99, 71);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 24;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = global::inventory2.Properties.Resources.A;
            this.pictureBox1.Location = new System.Drawing.Point(139, 148);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox3.Image = global::inventory2.Properties.Resources.images__7_;
            this.pictureBox3.Location = new System.Drawing.Point(87, 189);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(187, 106);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox2.Image = global::inventory2.Properties.Resources.AUTO1;
            this.pictureBox2.Location = new System.Drawing.Point(87, 62);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(187, 121);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::inventory2.Properties.Resources.iti;
            this.pictureBox7.Location = new System.Drawing.Point(868, 0);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(112, 91);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 102;
            this.pictureBox7.TabStop = false;
            // 
            // Software_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(983, 661);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Type_Text);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Search_Grid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Mail_Text);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Version_Text);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Key_Text);
            this.Controls.Add(this.Search_Software);
            this.Name = "Software_Search";
            this.Text = "Software Search";
            this.Load += new System.EventHandler(this.Software_Search_Load);
            this.Resize += new System.EventHandler(this.Software_Search_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.Search_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTInventoryDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iT_InventoryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.softwareBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Search_Software;
        private System.Windows.Forms.TextBox Key_Text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Version_Text;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Mail_Text;
        private System.Windows.Forms.DataGridView Search_Grid;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.BindingSource iTInventoryDataSetBindingSource;
        private IT_InventoryDataSet iT_InventoryDataSet;
        private System.Windows.Forms.BindingSource softwareBindingSource;
        private IT_InventoryDataSetTableAdapters.SoftwareTableAdapter softwareTableAdapter;
        private System.Windows.Forms.BindingSource softwareBindingSource1;
        private System.Windows.Forms.BindingSource softwareBindingSource2;
        private System.Windows.Forms.ComboBox Type_Text;
        private System.Windows.Forms.BindingSource softwareBindingSource3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
    }
}