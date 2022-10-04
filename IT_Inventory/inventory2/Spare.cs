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
    public partial class Spare : Form
    {
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        private Rectangle button3OriginalRect;
        private Rectangle PictureBox1OriginalRect;
        private Rectangle PictureBox2OriginalRect;
        private Size formOriginalSize;
        public Spare()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Inventory_CURD back = new Inventory_CURD();
            back.Show();
            this.Close();

        }

        private void spare_software_Click(object sender, EventArgs e)
        {
            Spare_Software back = new Spare_Software();
            back.Show();
            this.Close();
        }

        private void new_Software_Click(object sender, EventArgs e)
        {
            Spare_Hardware soft = new Spare_Hardware();
            soft.Show();
            this.Close();

        }

        private void Spare_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size;
            PictureBox1OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            PictureBox2OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            button1OriginalRect = new Rectangle(new_Software.Location.X, new_Software.Location.Y, new_Software.Width, new_Software.Height);
            button2OriginalRect = new Rectangle(spare_software.Location.X, spare_software.Location.Y, spare_software.Width, spare_software.Height);
            button3OriginalRect = new Rectangle(back.Location.X, back.Location.Y, back.Width, back.Height);
        }
        private void Spare_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
        private void resizeChildControls()
        {
            resizeControl(PictureBox1OriginalRect, pictureBox2);
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
    }
}
