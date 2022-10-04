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
    public partial class Add_From_Spare : Form
    {
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        private Rectangle button3OriginalRect;
        private Rectangle button4OriginalRect;
        private Rectangle button5OriginalRect;
        
        private Size formOriginalSize;
        public Add_From_Spare()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_New_User_Options add_options = new Add_New_User_Options();
            add_options.Show();
            this.Hide();
        }

        private void old_user_add_desktop_Click(object sender, EventArgs e)
        {
            Add_Desktop_New_User_From_Spare desktop_spare = new Add_Desktop_New_User_From_Spare();
            desktop_spare.Show();
            this.Hide();
        }

        private void old_user_add_laptop_Click(object sender, EventArgs e)
        {
            Add_Laptop_From_Spare_New_User laptop_spare = new Add_Laptop_From_Spare_New_User();

            laptop_spare.Show();
            this.Hide();
        }

        private void old_user_add_monitor_Click(object sender, EventArgs e)
        {
            Add_New_Monitor_From_Spare_New_User monitor_spare = new Add_New_Monitor_From_Spare_New_User();

            monitor_spare.Show();
            this.Hide();
        }

        private void old_user_add_software_Click(object sender, EventArgs e)
        {
            Add_Software_From_Spare_new_user software_spare = new Add_Software_From_Spare_new_user();
            software_spare.Show();
            this.Hide();
        }
        private void Add_From_Spare_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
        private void resizeChildControls()
        {

            resizeControl(button1OriginalRect, old_user_add_laptop);
            resizeControl(button2OriginalRect, old_user_add_desktop);
            resizeControl(button3OriginalRect, button1);
            resizeControl(button4OriginalRect, pictureBox2);
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

        private void Add_From_Spare_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            button1OriginalRect = new Rectangle(old_user_add_laptop.Location.X, old_user_add_laptop.Location.Y, old_user_add_laptop.Width, old_user_add_laptop.Height);
            button2OriginalRect = new Rectangle(old_user_add_desktop.Location.X, old_user_add_desktop.Location.Y, old_user_add_desktop.Width, old_user_add_desktop.Height);
            button3OriginalRect = new Rectangle(button1.Location.X, button1.Location.Y, button1.Width, button1.Height);
            button4OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            button5OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
        }
    }
}
