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
    public partial class Add_Monitor_Options : Form
    {
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        private Rectangle PictureBox1OriginalRect;
        private Rectangle PictureBox2OriginalRect;
        private Size formOriginalSize;
        public Add_Monitor_Options()
        {
            InitializeComponent();
        }

        private void new_monitor_Click(object sender, EventArgs e)
        {
            Add_New_Monitor_New_User add_monitor = new Add_New_Monitor_New_User();
            add_monitor.Show();
            this.Hide();
        }

        private void spare_Monitor_Click(object sender, EventArgs e)
        {
            Add_New_Monitor_From_Spare_New_User spare_monitor = new Add_New_Monitor_From_Spare_New_User();
            spare_monitor.Show();
            this.Hide();
        }

        private void back_Click(object sender, EventArgs e)
        {

        }
        private void Add_Monitor_Options_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size;
            PictureBox1OriginalRect= new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            PictureBox2OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            button1OriginalRect = new Rectangle(new_monitor.Location.X, new_monitor.Location.Y, new_monitor.Width, new_monitor.Height);
            button2OriginalRect = new Rectangle(spare_Monitor.Location.X, spare_Monitor.Location.Y, spare_Monitor.Width, spare_Monitor.Height);
            
        }

        private void Add_Monitor_Options_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
        private void resizeChildControls()
        {
            resizeControl(PictureBox1OriginalRect, pictureBox2);
            resizeControl(PictureBox2OriginalRect, pictureBox1);
            resizeControl(button1OriginalRect, new_monitor);
            resizeControl(button2OriginalRect, spare_Monitor);
           


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
