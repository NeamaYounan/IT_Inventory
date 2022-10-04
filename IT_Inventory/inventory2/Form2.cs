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
    public partial class Form2 : Form
    {
        private Rectangle Label1OriginalRect;
        private Size formOriginalSize;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            Label1OriginalRect = new Rectangle(Deleted.Location.X, Deleted.Location.Y, Deleted.Width, Deleted.Height);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void resizeChildControls()
        {
            resizeControl(Label1OriginalRect, Deleted);
           


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

        private void Form2_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
    }
}
