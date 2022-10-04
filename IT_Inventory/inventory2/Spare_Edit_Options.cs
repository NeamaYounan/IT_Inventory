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
    public partial class Spare_Edit_Options : Form
    {
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        private Rectangle button3OriginalRect;
        private Rectangle PictureBox1OriginalRect;
        private Rectangle PictureBox2OriginalRect;
        private Size formOriginalSize;
        public Spare_Edit_Options()
        {
            InitializeComponent();
        }

        private void new_Software_Click(object sender, EventArgs e)
        {
            Edit_Spare_Hardware edit = new Edit_Spare_Hardware();
            edit.Show();
            this.Hide();
        }

        private void spare_software_Click(object sender, EventArgs e)
        {
            Add_Software_From_Spare_Old_User edit = new Add_Software_From_Spare_Old_User();
            edit.Show();
            this.Hide();
        }

        private void back_Click(object sender, EventArgs e)
        {
            
            Edit_Form edit = new Edit_Form();
            edit.Show();
            edit.Name.Text = Edit_Form.userName;
            edit.SearchName_Click(sender, e);
            this.Hide();
        }

        private void Spare_Edit_Options_Load(object sender, EventArgs e)
        {

            formOriginalSize = this.Size;
            PictureBox1OriginalRect = new Rectangle(pictureBox3.Location.X, pictureBox3.Location.Y, pictureBox3.Width, pictureBox3.Height);
            PictureBox2OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            button1OriginalRect = new Rectangle(new_Software.Location.X, new_Software.Location.Y, new_Software.Width, new_Software.Height);
            button2OriginalRect = new Rectangle(spare_software.Location.X, spare_software.Location.Y, spare_software.Width, spare_software.Height);
            button3OriginalRect = new Rectangle(back.Location.X, back.Location.Y, back.Width, back.Height);
        }
        
        private void resizeChildControls()
        {
            resizeControl(PictureBox1OriginalRect, pictureBox3);
            resizeControl(PictureBox2OriginalRect, pictureBox1);
            resizeControl(button1OriginalRect, new_Software);
            resizeControl(button2OriginalRect, spare_software);
            resizeControl(button3OriginalRect, back);


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

        private void Spare_Edit_Options_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
    }
}
