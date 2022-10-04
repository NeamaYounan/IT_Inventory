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
    public partial class Search_Options : Form
    {


        private Size formOriginalSize;
        //pics
        private Rectangle pictureBox1OriginalRect;
        private Rectangle pictureBox2OriginalRect;
        private Rectangle pictureBox3OriginalRect;
        private Rectangle pictureBox4OriginalRect;
        private Rectangle pictureBox5OriginalRect;
        private Rectangle pictureBox6OriginalRect;
        
        //buttons
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        private Rectangle button3OriginalRect;
        private Rectangle button4OriginalRect;
       
        public Search_Options()
        {
            InitializeComponent();
        }

        private void Hardware_Click(object sender, EventArgs e)
        {
            Hardware_Search search = new Hardware_Search();
            search.Show();
            this.Hide();
        }

        private void User_Name_Click(object sender, EventArgs e)
        {
            Search_Name search = new Search_Name();
            search.Show();
            this.Hide();
        }

        private void Software_Click(object sender, EventArgs e)
        {
            Software_Search search = new Software_Search();
            search.Show();
            this.Hide();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Inventory_CURD search = new Inventory_CURD();
            search.Show();
            this.Hide();
        }

        private void Search_Options_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            pictureBox1OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            pictureBox2OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            pictureBox3OriginalRect = new Rectangle(pictureBox3.Location.X, pictureBox3.Location.Y, pictureBox3.Width, pictureBox3.Height);
            pictureBox4OriginalRect = new Rectangle(pictureBox4.Location.X, pictureBox4.Location.Y, pictureBox4.Width, pictureBox4.Height);
            pictureBox5OriginalRect = new Rectangle(pictureBox5.Location.X, pictureBox5.Location.Y, pictureBox5.Width, pictureBox5.Height);
            pictureBox6OriginalRect = new Rectangle(pictureBox6.Location.X, pictureBox6.Location.Y, pictureBox6.Width, pictureBox6.Height);
            button1OriginalRect = new Rectangle(Hardware.Location.X, Hardware.Location.Y, Hardware.Width, Hardware.Height);
            button2OriginalRect = new Rectangle(Software.Location.X, Software.Location.Y, Software.Width, Software.Height);
            button3OriginalRect = new Rectangle(User_Name.Location.X, User_Name.Location.Y, User_Name.Width, User_Name.Height);
            button4OriginalRect = new Rectangle(Back.Location.X, Back.Location.Y, Back.Width, Back.Height);

        }
        private void resizeChildControls()
        {
            //resize pics
            resizeControl(pictureBox1OriginalRect, pictureBox1);
            resizeControl(pictureBox2OriginalRect, pictureBox2);
            resizeControl(pictureBox3OriginalRect, pictureBox3);
            resizeControl(pictureBox4OriginalRect, pictureBox4);
            resizeControl(pictureBox5OriginalRect, pictureBox5);
            resizeControl(pictureBox6OriginalRect, pictureBox6);
            
            // resize buttons 
            resizeControl(button1OriginalRect, Hardware);
            resizeControl(button2OriginalRect, Software);
            resizeControl(button3OriginalRect, User_Name);
            resizeControl(button4OriginalRect, Back);
            

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

        private void Search_Options_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
    }
}
