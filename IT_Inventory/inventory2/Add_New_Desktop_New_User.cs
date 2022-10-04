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
    public partial class Add_New_Desktop_New_User : Form
    {
        private Rectangle PictureBox1OriginalRect;
        private Rectangle PictureBox2OriginalRect;
        private Rectangle button1OriginalRect;
        
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
        public Add_New_Desktop_New_User()
        {
            InitializeComponent();
        }
        public static bool id_d=false;
        public static object Id_d;
        //neama DB=DESKTOP-OG2M2CI
        //Katren DB=DESKTOP-9QTGSEL
        //SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
        private void button1_Click(object sender, EventArgs e)
        {
            Add_Hardware_Options hard_option = new Add_Hardware_Options();
            hard_option.Show();
            this.Hide();
        }

        private void add_lap_btn_Click(object sender, EventArgs e)
        {
            
        }

        private void Next_bu_Click(object sender, EventArgs e)
        {
            Connection_Class.DB_cn();
            Connection_Class.open();
            List<string> SNS = new List<string>();
            SqlCommand desk_sn = new SqlCommand("SELECT Serial_Number_Desk from Desktop ; ", Connection_Class.cn);

            SqlDataReader sdr = desk_sn.ExecuteReader();
            string[] numb = new string[sdr.FieldCount];

            while (sdr.Read())
            {
                for (int l = 0; l < sdr.FieldCount; l++)
                {

                    SNS.Add(sdr[l].ToString());
                }

            }

            if (SNS.Contains(sn_desk.Text))
            {
                MessageBox.Show("Your Inventory has this Serial Number." + "\n" + "You can't duplicate Serial Number !!");
                sn_desk.ForeColor = Color.Red;
            }

            else
            {
                id_d = true;
                //Get Id User
                SqlCommand cmd1 = new SqlCommand("SELECT max(Id_User) from dbo.Users ;", Connection_Class.cn);
                int id_desk = Conditions_Class.Get_Id(cmd1);

                //Add new Desk
                SqlCommand cmd2 = new SqlCommand("INSERT INTO  dbo.Desktop values( '" + sn_desk.Text + "', '" + brand_desk.Text + "','" + model_desk.Text + "','" + proc_desk.Text + "','" + ram_desk.Text + "','" + hard_desk.Text + "','" + note_desk.Text + "','" + id_desk + "')", Connection_Class.cn);
                cmd2.ExecuteNonQuery();
                //MessageBox.Show("Data Inserted Successfully.");
                SqlCommand cmd3 = new SqlCommand("SELECT Id_Desktop from dbo.Desktop  where Desktop.Serial_Number_Desk='" + sn_desk.Text + "';", Connection_Class.cn);
                Id_d = cmd3.ExecuteScalar();
                //if (Id_d != null)
                //{ id_d = true; }
                //else
                //{
                //    id_d = false;
                //}
               

                Add_Monitor_Options monitor_options = new Add_Monitor_Options();
                monitor_options.Show();
                this.Hide();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Connection_Class.Close();
            Add_Hardware_Options add_Hardware_Options = new Add_Hardware_Options();
            add_Hardware_Options.Show();
            this.Hide();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Add_New_User_Options add_Options = new Add_New_User_Options();
            add_Options.Show();
            this.Hide();
        }
        private void Add_New_Desktop_New_User_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
        private void resizeChildControls()
        {
            resizeControl(PictureBox1OriginalRect, pictureBox1);
            resizeControl(PictureBox2OriginalRect, pictureBox3);
            resizeControl(textBox1OriginalRect, sn_desk);
            resizeControl(textBox2OriginalRect, brand_desk);
            resizeControl(textBox3OriginalRect, model_desk);
            resizeControl(textBox4OriginalRect, proc_desk);
            resizeControl(textBox5OriginalRect, ram_desk);
            resizeControl(textBox6OriginalRect, hard_desk);
            resizeControl(textBox7OriginalRect, note_desk);
            resizeControl(button1OriginalRect, button1);
           
            resizeControl(button3OriginalRect, Next_bu);
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
        private void Add_New_Desktop_New_User_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            PictureBox1OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            PictureBox2OriginalRect = new Rectangle(pictureBox3.Location.X, pictureBox3.Location.Y, pictureBox3.Width, pictureBox3.Height);
            textBox1OriginalRect = new Rectangle(sn_desk.Location.X, sn_desk.Location.Y, sn_desk.Width, sn_desk.Height);
            textBox2OriginalRect = new Rectangle(brand_desk.Location.X, brand_desk.Location.Y, brand_desk.Width, brand_desk.Height);
            textBox3OriginalRect = new Rectangle(model_desk.Location.X, model_desk.Location.Y, model_desk.Width, model_desk.Height);
            textBox4OriginalRect = new Rectangle(proc_desk.Location.X, proc_desk.Location.Y, proc_desk.Width, proc_desk.Height);
            textBox5OriginalRect = new Rectangle(ram_desk.Location.X, ram_desk.Location.Y, ram_desk.Width, ram_desk.Height);
            textBox6OriginalRect = new Rectangle(hard_desk.Location.X, hard_desk.Location.Y, hard_desk.Width, hard_desk.Height);
            textBox7OriginalRect = new Rectangle(note_desk.Location.X, note_desk.Location.Y, note_desk.Width, note_desk.Height);
            button1OriginalRect = new Rectangle(button1.Location.X, button1.Location.Y, button1.Width, button1.Height);
            button3OriginalRect = new Rectangle(Next_bu.Location.X, Next_bu.Location.Y, Next_bu.Width, Next_bu.Height);
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
