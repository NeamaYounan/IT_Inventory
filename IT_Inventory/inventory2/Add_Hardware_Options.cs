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
    public partial class Add_Hardware_Options : Form
    {
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        private Rectangle button3OriginalRect;
        private Rectangle button4OriginalRect;
        private Rectangle button5OriginalRect;
        private Size formOriginalSize;
        public Add_Hardware_Options()
        {
            InitializeComponent();
        }

        private void add_laptop_Click(object sender, EventArgs e)
        {
            Add_New_Laptop_New_User add_lap = new Add_New_Laptop_New_User();
            add_lap.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_New_User_Options add_opt = new Add_New_User_Options();
            add_opt.Show();
            this.Hide();
        }

        

        private void add_desktop_Click(object sender, EventArgs e)
        {
            Add_New_Desktop_New_User add_desk = new Add_New_Desktop_New_User();
            add_desk.Show();
            this.Hide();
        }

        private void Add_Hardware_Options_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size;
            button1OriginalRect = new Rectangle(add_laptop.Location.X, add_laptop.Location.Y, add_laptop.Width, add_laptop.Height);
            button2OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            button3OriginalRect = new Rectangle(add_desktop.Location.X, add_desktop.Location.Y, add_desktop.Width, add_desktop.Height);
            button4OriginalRect = new Rectangle(button1.Location.X, button1.Location.Y, button1.Width, button1.Height);
            button5OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            
        }

        private void Add_Hardware_Options_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
        private void resizeChildControls()
        {
            
            resizeControl(button1OriginalRect, add_laptop);
            resizeControl(button2OriginalRect, pictureBox2);
            resizeControl(button3OriginalRect, add_desktop);
            resizeControl(button4OriginalRect, button1);
            resizeControl(button5OriginalRect, pictureBox1);

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
