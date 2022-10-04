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
    public partial class Add_New_User_Options : Form
    {
        
        private Rectangle pictureBox1OriginalRect;
        private Rectangle pictureBox2OriginalRect;
        private Rectangle button2OriginalRect;
        private Rectangle button3OriginalRect;
        private Size formOriginalSize;
        public Add_New_User_Options()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add_Options add_options = new Add_Options();
            //add_options.Show();
            //this.Hide();
        }

        private void new_device_Click(object sender, EventArgs e)
        {
            Add_Hardware_Options new_user_device = new Add_Hardware_Options();
            new_user_device.Show();
            this.Hide();
        }

        private void from_spare_Click(object sender, EventArgs e)
        {
            Add_From_Spare add_from_spare = new Add_From_Spare();
            add_from_spare.Show();
            this.Hide();
        }
        
       
        /// ////////////////Autosize
        
        private void Add_New_User_Options_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
        private void resizeChildControls()
        {
            resizeControl(pictureBox1OriginalRect, pictureBox1);
            resizeControl(pictureBox2OriginalRect, pictureBox2);
            resizeControl(button2OriginalRect, from_spare);
            resizeControl(button3OriginalRect, new_device);

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
        private void Add_New_User_Options_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            pictureBox1OriginalRect= new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            pictureBox2OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            button3OriginalRect = new Rectangle(new_device.Location.X, new_device.Location.Y, new_device.Width, new_device.Height);
            button2OriginalRect = new Rectangle(from_spare.Location.X, from_spare.Location.Y, from_spare.Width, from_spare.Height);
           
            
        }

    }
}
