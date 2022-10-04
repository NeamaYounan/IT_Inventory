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
    public partial class Add_Software_Options_New_User : Form
    {
        //buttons
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        //pics
        private Rectangle PictureBox1OriginalRect;
        private Rectangle PictureBox2OriginalRect;
        private Rectangle PictureBox3OriginalRect;
        private Rectangle PictureBox4OriginalRect;
        private Rectangle PictureBox5OriginalRect;
        private Rectangle PictureBox6OriginalRect;
        //form
        private Size formOriginalSize;
        public Add_Software_Options_New_User()
        {
            InitializeComponent();
        }

        private void new_Software_Click(object sender, EventArgs e)
        {
            Add_New_Software_New_User add_soft = new Add_New_Software_New_User();
            add_soft.Show();
            this.Hide();
        }

        private void spare_software_Click(object sender, EventArgs e)
        {
            Add_Software_From_Spare_new_user add_soft_spare = new Add_Software_From_Spare_new_user();
            add_soft_spare.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inventory_CURD invent = new Inventory_CURD();
            invent.Show();
            this.Hide();
        }
        private void Add_Software_Options_New_User_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size;
            //buttons
            button1OriginalRect = new Rectangle(new_Software.Location.X, new_Software.Location.Y, new_Software.Width, new_Software.Height);
            button2OriginalRect = new Rectangle(spare_software.Location.X, spare_software.Location.Y, spare_software.Width, spare_software.Height);
            //pics
            PictureBox1OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            PictureBox2OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            PictureBox3OriginalRect = new Rectangle(pictureBox3.Location.X, pictureBox3.Location.Y, pictureBox3.Width, pictureBox3.Height);
            PictureBox4OriginalRect = new Rectangle(pictureBox4.Location.X, pictureBox4.Location.Y, pictureBox4.Width, pictureBox4.Height);
            PictureBox5OriginalRect = new Rectangle(pictureBox5.Location.X, pictureBox5.Location.Y, pictureBox5.Width, pictureBox5.Height);
            PictureBox6OriginalRect = new Rectangle(pictureBox6.Location.X, pictureBox6.Location.Y, pictureBox6.Width, pictureBox6.Height);

        }

        private void Add_Software_Options_New_User_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
        private void resizeChildControls()
        {
            //pics
            resizeControl(PictureBox1OriginalRect, pictureBox1);
            resizeControl(PictureBox2OriginalRect, pictureBox2);
            resizeControl(PictureBox3OriginalRect, pictureBox3);
            resizeControl(PictureBox4OriginalRect, pictureBox4);
            resizeControl(PictureBox5OriginalRect, pictureBox5);
            resizeControl(PictureBox6OriginalRect, pictureBox6);

            //buttons
            resizeControl(button1OriginalRect, new_Software);
            resizeControl(button2OriginalRect, spare_software);



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
    }
}
