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
    public partial class Add_New_Monitor_New_User : Form
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
        private Rectangle label1OriginalRect;
        private Rectangle label2OriginalRect;
        private Rectangle label3OriginalRect;
        private Rectangle label4OriginalRect;
        private Size formOriginalSize;
        public Add_New_Monitor_New_User()
        {
            InitializeComponent();
        }
        //neama DB=DESKTOP-OG2M2CI
        //Katren DB=DESKTOP-9QTGSEL
        //SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");

        private void button1_Click(object sender, EventArgs e)
        {
            Connection_Class.DB_cn();
            Connection_Class.open();
            List<string> SNS = new List<string>();
            SqlCommand monitor_sn = new SqlCommand("SELECT Serial_Number_Monitor from Monitor ; ", Connection_Class.cn);

            SqlDataReader sdr = monitor_sn.ExecuteReader();
            string[] numb = new string[sdr.FieldCount];

            while (sdr.Read())
            {
                for (int l = 0; l < sdr.FieldCount; l++)
                {

                    SNS.Add(sdr[l].ToString());
                }

            }

            if (SNS.Contains(sn_monitor.Text))
            {
                MessageBox.Show("Your Inventory has this Serial Number." + "\n" + "You can't duplicate Serial Number !!");
                sn_monitor.ForeColor = Color.Red;
            }

            else
            {

                SqlCommand cmd = new SqlCommand("Select max(dbo.Users.Id_User) FROM dbo.Users;", Connection_Class.cn);
                int i = Conditions_Class.Get_Id(cmd);
                SqlCommand cmd1 = new SqlCommand("INSERT INTO dbo.Monitor Values ('" + sn_monitor.Text + "','" + brand_monitor.Text + "','" + model_monitor.Text + "','" + note_monitor.Text + "','" + i + "')", Connection_Class.cn);
                cmd1.ExecuteNonQuery();
                //MessageBox.Show("Data Added Successfuly");
                Add_Software_Options_New_User software_options = new Add_Software_Options_New_User();
                software_options.Show();
                this.Hide();
            }
            Connection_Class.Close();

        }

        private void add_lap_btn_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Hardware_Options add_Hardware_Options = new Add_Hardware_Options();
            add_Hardware_Options.Show();
            this.Hide();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Add_Monitor_Options add_Options = new Add_Monitor_Options();
            add_Options.Show();
            this.Hide();
        }
        private void Add_New_Monitor_New_User_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
        private void resizeChildControls()
        {
            resizeControl(PictureBox1OriginalRect, pictureBox1);
            resizeControl(PictureBox2OriginalRect, pictureBox2);
            resizeControl(textBox1OriginalRect, sn_monitor);
            resizeControl(textBox2OriginalRect, brand_monitor);
            resizeControl(textBox3OriginalRect, model_monitor);
            resizeControl(textBox4OriginalRect, note_monitor);
            
            resizeControl(button1OriginalRect, back);
            //resizeControl(button2OriginalRect, add_lap_btn);
            resizeControl(button3OriginalRect, Next_bu);
            resizeControl(label1OriginalRect, label1);
            resizeControl(label2OriginalRect, label2);
            resizeControl(label3OriginalRect, label3);
            resizeControl(label4OriginalRect, label7);
            

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
        private void Add_New_Monitor_New_User_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            PictureBox1OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            PictureBox2OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            textBox1OriginalRect = new Rectangle(sn_monitor.Location.X, sn_monitor.Location.Y, sn_monitor.Width, sn_monitor.Height);
            textBox2OriginalRect = new Rectangle(brand_monitor.Location.X, brand_monitor.Location.Y, brand_monitor.Width, brand_monitor.Height);
            textBox3OriginalRect = new Rectangle(model_monitor.Location.X, model_monitor.Location.Y, model_monitor.Width, model_monitor.Height);
            textBox4OriginalRect = new Rectangle(note_monitor.Location.X, note_monitor.Location.Y, note_monitor.Width, note_monitor.Height);
            button1OriginalRect = new Rectangle(back.Location.X, back.Location.Y, back.Width, back.Height);
            //button2OriginalRect = new Rectangle(add_lap_btn.Location.X, add_lap_btn.Location.Y, add_lap_btn.Width, add_lap_btn.Height);
            button3OriginalRect = new Rectangle(Next_bu.Location.X, Next_bu.Location.Y, Next_bu.Width, Next_bu.Height);
            label1OriginalRect = new Rectangle(label1.Location.X, label1.Location.Y, label1.Width, label1.Height);
            label2OriginalRect = new Rectangle(label2.Location.X, label2.Location.Y, label2.Width, label2.Height);
            label3OriginalRect = new Rectangle(label3.Location.X, label3.Location.Y, label3.Width, label3.Height);
            label4OriginalRect = new Rectangle(label7.Location.X, label7.Location.Y, label7.Width, label7.Height);
            
        }
    }
}
