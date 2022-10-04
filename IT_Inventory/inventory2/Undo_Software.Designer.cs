
namespace inventory2
{
    partial class Undo
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
            this.back = new System.Windows.Forms.Button();
            this.next_bu = new System.Windows.Forms.Button();
            this.Search_Grid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Search_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.Location = new System.Drawing.Point(46, 382);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(87, 45);
            this.back.TabIndex = 60;
            this.back.Text = "Back";
            this.back.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // next_bu
            // 
            this.next_bu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.next_bu.Location = new System.Drawing.Point(662, 393);
            this.next_bu.Name = "next_bu";
            this.next_bu.Size = new System.Drawing.Size(87, 45);
            this.next_bu.TabIndex = 59;
            this.next_bu.Text = "Save";
            this.next_bu.UseVisualStyleBackColor = true;
            this.next_bu.Click += new System.EventHandler(this.next_bu_Click);
            // 
            // Search_Grid
            // 
            this.Search_Grid.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.Search_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Search_Grid.Location = new System.Drawing.Point(36, 59);
            this.Search_Grid.Margin = new System.Windows.Forms.Padding(2);
            this.Search_Grid.Name = "Search_Grid";
            this.Search_Grid.RowHeadersWidth = 62;
            this.Search_Grid.RowTemplate.Height = 28;
            this.Search_Grid.Size = new System.Drawing.Size(737, 158);
            this.Search_Grid.TabIndex = 58;
            // 
            // Undo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::inventory2.Properties.Resources._55;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.back);
            this.Controls.Add(this.next_bu);
            this.Controls.Add(this.Search_Grid);
            this.Name = "Undo";
            this.Text = "Undo_Software";
            this.Load += new System.EventHandler(this.Undo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Search_Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button next_bu;
        private System.Windows.Forms.DataGridView Search_Grid;
    }
}