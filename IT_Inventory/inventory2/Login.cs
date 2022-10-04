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
    public partial class Login : Form
    {
        private Rectangle pictureBox1OriginalRect;
        private Rectangle pictureBox2OriginalRect;
        private Rectangle pictureBox3OriginalRect;
        private Rectangle label1OriginalRect;
        private Rectangle label2OriginalRect;
        private Rectangle textBox1OriginalRect;
        private Rectangle textBox2OriginalRect;
        private Rectangle button1OriginalRect;
       
        private Size formOriginalSize;
        public Login()
        {
            InitializeComponent();
        }

        private void UserName_TextChanged(object sender, EventArgs e)
        {
            
        }

            private void Password_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (UserName.Text == "A" && Password.Text == "A")
                    {


                        Inventory_CURD inventory_CURD = new Inventory_CURD();
                        inventory_CURD.Show();
                        this.Hide();
                    }
                    else
                    {
                        string message = "Wrong UserName or Password";
                        MessageBox.Show(message);
                    }
                }
            }
        
        private void Login_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
        private void resizeChildControls()
        {
            resizeControl(pictureBox1OriginalRect, pictureBox3);
            resizeControl(pictureBox2OriginalRect, pictureBox2);
            resizeControl(pictureBox3OriginalRect, pictureBox1);
            resizeControl(label1OriginalRect, label3);
            resizeControl(label2OriginalRect, label2);
            resizeControl(textBox1OriginalRect, UserName);
            resizeControl(textBox2OriginalRect, Password);
            resizeControl(button1OriginalRect, button1);

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
        private void Login_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            pictureBox1OriginalRect = new Rectangle(pictureBox3.Location.X, pictureBox3.Location.Y, pictureBox3.Width, pictureBox3.Height);
            pictureBox2OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            pictureBox3OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            label1OriginalRect = new Rectangle(label3.Location.X, label3.Location.Y, label3.Width, label3.Height);
            label2OriginalRect = new Rectangle(label2.Location.X, label2.Location.Y, label2.Width, label2.Height);
            textBox1OriginalRect  = new Rectangle(UserName.Location.X, UserName.Location.Y, UserName.Width, UserName.Height);
            textBox2OriginalRect = new Rectangle(Password.Location.X, Password.Location.Y, Password.Width, Password.Height);
            button1OriginalRect = new Rectangle(button1.Location.X, button1.Location.Y, button1.Width, button1.Height);            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (UserName.Text == "A" && Password.Text == "A")
            {


                Inventory_CURD inventory_CURD = new Inventory_CURD();
                inventory_CURD.Show();
                this.Hide();
            }
            else
            {
                string message = "Wrong UserName or Password";
                MessageBox.Show(message);
            }
        }
    }
}
