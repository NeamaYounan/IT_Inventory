using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory2
{
    public partial class Edit_by_spare_options : Form
    {
        private Rectangle pictureBox1OriginalRect;
        private Rectangle pictureBox2OriginalRect;
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        private Rectangle button3OriginalRect;
        private Size formOriginalSize;

        public Edit_by_spare_options()
        {
            InitializeComponent();
        }

        private void spare_software_Click(object sender, EventArgs e)
        {
            Spare_Edit_Options edit = new Spare_Edit_Options();
            edit.Show();
            this.Hide();

        }

        private void new_Software_Click(object sender, EventArgs e)
        {
            Edit_Spare_Software edit_Software=new Edit_Spare_Software();
            edit_Software.Show();
            this.Hide();

        }

        private void back_Click(object sender, EventArgs e)
        {
            Edit_Form edit = new Edit_Form();
            edit.Show();
            this.Hide();
            edit.Name.Text = Edit_Form.userName;
            edit.SearchName_Click(sender, e);
        }

        private void Edit_by_spare_options_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            pictureBox1OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            pictureBox2OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            button1OriginalRect = new Rectangle(back.Location.X, back.Location.Y, back.Width, back.Height);
            button2OriginalRect = new Rectangle(new_Software.Location.X, new_Software.Location.Y, new_Software.Width, new_Software.Height);
            button3OriginalRect = new Rectangle(spare_software.Location.X, spare_software.Location.Y, spare_software.Width, spare_software.Height);
            
        }
        
            
        
        private void resizeChildControls()
        {
            resizeControl(pictureBox1OriginalRect, pictureBox1);
            resizeControl(pictureBox2OriginalRect, pictureBox2);
            resizeControl(button1OriginalRect, back);
            resizeControl(button2OriginalRect, new_Software);
            resizeControl(button3OriginalRect, spare_software);
            //resizeControl(formOriginalSize, spare_software);


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

        private void Edit_by_spare_options_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
    }
}
