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
    public partial class Add_Software_Options_Old_User : Form
    {
        private Rectangle pictureBox1OriginalRect;
        private Rectangle pictureBox2OriginalRect;
        private Rectangle pictureBox3OriginalRect;
        private Rectangle pictureBox4OriginalRect;
        private Rectangle pictureBox5OriginalRect;
        private Rectangle pictureBox6OriginalRect;
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        private Size formOriginalSize;
        public Add_Software_Options_Old_User()
        {
            InitializeComponent();
        }

        private void spare_software_Click(object sender, EventArgs e)
        {
            Add_Software_From_Spare_Old_User spare_Old_User = new Add_Software_From_Spare_Old_User();
            spare_Old_User.Show();
            this.Hide();
        }

        private void new_Software_Click(object sender, EventArgs e)
        {
            Add_New_Software_For_Old_User soft_Old_User = new Add_New_Software_For_Old_User();
            soft_Old_User.Show();
            this.Hide();
        }

        private void Add_Software_Options_Old_User_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size;
            pictureBox1OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            pictureBox2OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            pictureBox3OriginalRect = new Rectangle(pictureBox3.Location.X, pictureBox3.Location.Y, pictureBox3.Width, pictureBox3.Height);
            pictureBox4OriginalRect = new Rectangle(pictureBox4.Location.X, pictureBox4.Location.Y, pictureBox4.Width, pictureBox4.Height);
            pictureBox5OriginalRect = new Rectangle(pictureBox5.Location.X, pictureBox5.Location.Y, pictureBox5.Width, pictureBox5.Height);
            pictureBox6OriginalRect = new Rectangle(pictureBox6.Location.X, pictureBox6.Location.Y, pictureBox6.Width, pictureBox6.Height);
            button1OriginalRect = new Rectangle(new_Software.Location.X, new_Software.Location.Y, new_Software.Width, new_Software.Height);
            button2OriginalRect = new Rectangle(spare_software.Location.X, spare_software.Location.Y, spare_software.Width, spare_software.Height);

        }

        private void Add_Software_Options_Old_User_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
        private void resizeChildControls()
        {
            resizeControl(pictureBox1OriginalRect, pictureBox1);
            resizeControl(pictureBox2OriginalRect, pictureBox2);
            resizeControl(pictureBox3OriginalRect, pictureBox3);
            resizeControl(pictureBox4OriginalRect, pictureBox4);
            resizeControl(pictureBox5OriginalRect, pictureBox5);
            resizeControl(pictureBox6OriginalRect, pictureBox6);
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
