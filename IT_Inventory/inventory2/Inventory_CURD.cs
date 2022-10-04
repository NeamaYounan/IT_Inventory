using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;

namespace inventory2
{
    public partial class Inventory_CURD : Form
    {
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        private Rectangle button3OriginalRect;
        private Rectangle button4OriginalRect;
        private Rectangle button5OriginalRect;
        private Rectangle button6OriginalRect;
        private Rectangle PictureBoxOriginalRect;
        
        private Size formOriginalSize;

        public Inventory_CURD()
        {
            InitializeComponent();
        }
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void search_op_Click(object sender, EventArgs e)
        {

        }

        private void edit_op_Click(object sender, EventArgs e)
        {
            Edit_Form edit = new Edit_Form();
            edit.Show();
            this.Hide();
        }

        private void search_op_Click_1(object sender, EventArgs e)
        {
            Search_Options search = new Search_Options();
            search.Show();
            this.Hide();
        }

        private void Add_op_Click(object sender, EventArgs e)
        {
            Add_User_Form add = new Add_User_Form();
            add.Show();
            this.Hide();
        }

        private void Export_Click(object sender, EventArgs e)
        {
            Export ex = new Export();
            ex.Show();
            this.Hide();
        }

        private void multi_Click(object sender, EventArgs e)
        {
            import_form import = new import_form();
            import.Show();
            this.Hide();
            
        }

        private void delete_Click(object sender, EventArgs e)
        {
            Delete_User delete_User = new Delete_User();
            delete_User.Show();
            this.Hide();

        }

        private void transfer_Click(object sender, EventArgs e)
        {
            Transform transform= new Transform();
            transform.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Spare spare = new Spare();
            spare.Show();
            this.Close();
        }
        //private void Inventory_CURD_Resize(object sender, EventArgs e)
        //{
        //    resizeChildControls();
        //}
        private void resizeChildControls()
        {
            
            
            resizeControl(button1OriginalRect, Add_op);
            resizeControl(button2OriginalRect, search_op);
            resizeControl(button3OriginalRect, edit_op);

            resizeControl(button4OriginalRect, multi);
            resizeControl(button5OriginalRect, button1);
            resizeControl(button6OriginalRect, Export);
            resizeControl(PictureBoxOriginalRect, pictureBox2);

        }
        private void resizeControl(Rectangle originalControlRect, Control control)
        {
            float xRatio = (float)(this.Size.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Size.Width) / (float)(formOriginalSize.Width);
            int newx = (int)(originalControlRect.X * xRatio);
            int newy = (int)(originalControlRect.Y * yRatio);
            int newwidth = (int)(originalControlRect.Width * xRatio);
            int newheight = (int)(originalControlRect.Height * xRatio);
            control.Location = new Point(newx, newy);
            control.Size = new Size(newwidth, newheight);



        }

        private void Inventory_CURD_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            button1OriginalRect = new Rectangle(Add_op.Location.X, Add_op.Location.Y, Add_op.Width, Add_op.Height);
            button2OriginalRect = new Rectangle(search_op.Location.X, search_op.Location.Y, search_op.Width, search_op.Height);
            button3OriginalRect = new Rectangle(edit_op.Location.X, edit_op.Location.Y, edit_op.Width, edit_op.Height);
            button4OriginalRect = new Rectangle(multi.Location.X, multi.Location.Y, multi.Width, multi.Height);
            button5OriginalRect = new Rectangle(button1.Location.X, button1.Location.Y, button1.Width, button1.Height);
            button6OriginalRect = new Rectangle(Export.Location.X, Export.Location.Y, Export.Width, Export.Height);
            PictureBoxOriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);


        }

        private void Inventory_Curd_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }

        
    }
    
}
           
        
