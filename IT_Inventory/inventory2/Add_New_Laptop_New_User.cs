using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace inventory2
{
    public partial class Add_New_Laptop_New_User : Form
    {
        private Rectangle PictureBox1OriginalRect;
        private Rectangle PictureBox2OriginalRect;
        private Rectangle button1OriginalRect;
        //private Rectangle button2OriginalRect;
        private Rectangle button3OriginalRect;
        private Rectangle textBox1OriginalRect;
        private Rectangle textBox2OriginalRect;
        private Rectangle textBox3OriginalRect;
        private Rectangle textBox4OriginalRect;
        private Rectangle textBox5OriginalRect;
        private Rectangle textBox6OriginalRect;
        private Rectangle textBox7OriginalRect;
        private Rectangle label1OriginalRect;
        private Rectangle label2OriginalRect;
        private Rectangle label3OriginalRect;
        private Rectangle label4OriginalRect;
        private Rectangle label5OriginalRect;
        private Rectangle label6OriginalRect;
        private Rectangle label7OriginalRect;
        private Size formOriginalSize;
        //public static bool id_l = true;
        public Add_New_Laptop_New_User()
        {
            InitializeComponent();
        }
        public static bool id_l=false;
        public static object Id_l;
        //SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
        
        private void button1_Click(object sender, EventArgs e)
        {
           Add_Hardware_Options back = new Add_Hardware_Options();
            back.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void next_Click(object sender, EventArgs e)
        {
            Connection_Class.DB_cn();
            Connection_Class.open();
            List<string> SNS = new List<string>();
            SqlCommand Lap_sn = new SqlCommand("SELECT Serial_Number_Lap from Laptops;", Connection_Class.cn);

            SqlDataReader sdr = Lap_sn.ExecuteReader();
            string[] numb = new string[sdr.FieldCount];

            while (sdr.Read())
            {
                for (int l = 0; l < sdr.FieldCount; l++)
                {

                    SNS.Add(sdr[l].ToString());
                }
            }
            if (SNS.Contains(sn_lap.Text))
            {
                MessageBox.Show("Your Inventory has this Serial Number." + "\n" + "You can't duplicate Serial Number !!");
                sn_lap.ForeColor = Color.Red;
                Add_New_Laptop_New_User add = new Add_New_Laptop_New_User();    
                add.Show();
                this.Hide();
            }

            else
            {
                //Get Id User
                SqlCommand cmd1 = new SqlCommand("SELECT max(Id_User) from dbo.Users ;", Connection_Class.cn);
                int id_lap = Conditions_Class.Get_Id(cmd1);
                //Add new Laptop
                SqlCommand cmd3 = new SqlCommand("INSERT INTO  dbo.Laptops values( '" + sn_lap.Text + "', '" + brand_lab.Text + "','" + lap_model.Text + "','" + proc_lab.Text + "','" + lap_ram.Text + "','" + hard_lab.Text + "','" + note_lab.Text + "','" + id_lap + "')", Connection_Class.cn);
                cmd3.ExecuteNonQuery();
                //MessageBox.Show("Data Inserted Successfully.");
                //get max id_desktop to use it when add new software ont it 
                SqlCommand cmd2 = new SqlCommand("SELECT Id_Laptop from dbo.Laptops where Laptops.Serial_Number_Lap= '" + sn_lap.Text + "' ;", Connection_Class.cn);
                Id_l = cmd2.ExecuteScalar();
                //if (Id_l != null)
                //{ id_l = true; }
                //else
                //{
                //    id_l = false;
                //}
                id_l = true;
                Add_Software_Options_New_User soft_add = new Add_Software_Options_New_User();
                soft_add.Show();
                this.Hide();

            }
            Connection_Class.Close();
            

        }
        private void Add_New_Laptop_New_User_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
        private void resizeChildControls()
        {
            resizeControl(PictureBox1OriginalRect, pictureBox1);
            resizeControl(PictureBox2OriginalRect, pictureBox3);
            resizeControl(textBox1OriginalRect, sn_lap);
            resizeControl(textBox2OriginalRect, brand_lab);
            resizeControl(textBox3OriginalRect, lap_model);
            resizeControl(textBox4OriginalRect, proc_lab);
            resizeControl(textBox5OriginalRect, lap_ram);
            resizeControl(textBox6OriginalRect, hard_lab);
            resizeControl(textBox7OriginalRect, note_lab);
            resizeControl(button1OriginalRect, button1);
            //resizeControl(button2OriginalRect, add_lap_btn);
            resizeControl(button3OriginalRect, next);
            resizeControl(label1OriginalRect, label1);
            resizeControl(label2OriginalRect, label2);
            resizeControl(label3OriginalRect, label3);
            resizeControl(label4OriginalRect, label4);
            resizeControl(label5OriginalRect, label5);
            resizeControl(label6OriginalRect, label6);
            resizeControl(label7OriginalRect, label7);

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
        private void Add_New_Laptop_New_User_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            PictureBox1OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            PictureBox2OriginalRect = new Rectangle(pictureBox3.Location.X, pictureBox3.Location.Y, pictureBox3.Width, pictureBox3.Height);
            textBox1OriginalRect = new Rectangle(sn_lap.Location.X, sn_lap.Location.Y, sn_lap.Width, sn_lap.Height);
            textBox2OriginalRect = new Rectangle(brand_lab.Location.X, brand_lab.Location.Y, brand_lab.Width, brand_lab.Height);
            textBox3OriginalRect = new Rectangle(lap_model.Location.X, lap_model.Location.Y, lap_model.Width, lap_model.Height);
            textBox4OriginalRect = new Rectangle(proc_lab.Location.X, proc_lab.Location.Y, proc_lab.Width, proc_lab.Height);
            textBox5OriginalRect = new Rectangle(lap_ram.Location.X, lap_ram.Location.Y, lap_ram.Width, lap_ram.Height);
            textBox6OriginalRect = new Rectangle(hard_lab.Location.X, hard_lab.Location.Y, hard_lab.Width, hard_lab.Height);
            textBox7OriginalRect = new Rectangle(note_lab.Location.X, note_lab.Location.Y, note_lab.Width, note_lab.Height);
            button1OriginalRect = new Rectangle(button1.Location.X, button1.Location.Y, button1.Width, button1.Height);
            //button2OriginalRect = new Rectangle(add_lap_btn.Location.X, add_lap_btn.Location.Y, add_lap_btn.Width, add_lap_btn.Height);
            button3OriginalRect = new Rectangle(next.Location.X, next.Location.Y, next.Width, next.Height);
            label1OriginalRect = new Rectangle(label1.Location.X, label1.Location.Y, label1.Width, label1.Height);
            label2OriginalRect = new Rectangle(label2.Location.X, label2.Location.Y, label2.Width, label2.Height);
            label3OriginalRect = new Rectangle(label3.Location.X, label3.Location.Y, label3.Width, label3.Height);
            label4OriginalRect = new Rectangle(label4.Location.X, label4.Location.Y, label4.Width, label4.Height);
            label5OriginalRect = new Rectangle(label5.Location.X, label5.Location.Y, label5.Width, label5.Height);
            label6OriginalRect = new Rectangle(label6.Location.X, label6.Location.Y, label6.Width, label6.Height);
            label7OriginalRect = new Rectangle(label7.Location.X, label7.Location.Y, label7.Width, label7.Height);
        }

    }
}
