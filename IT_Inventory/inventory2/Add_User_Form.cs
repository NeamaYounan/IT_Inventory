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
    public partial class Add_User_Form : Form
    {
        private Rectangle pictureBox1OriginalRect;
        private Rectangle pictureBox2OriginalRect;
        private Rectangle button1OriginalRect;
       // private Rectangle button2OriginalRect;
        private Rectangle button3OriginalRect;
        private Rectangle textBox1OriginalRect;
        private Rectangle textBox2OriginalRect;
        private Rectangle textBox3OriginalRect;
        private Rectangle label1OriginalRect;
        private Rectangle label4OriginalRect;
        private Rectangle label2OriginalRect;
        private Rectangle label3OriginalRect;
        private Size formOriginalSize;
        public Add_User_Form()
        {

            InitializeComponent();
            { 
                SqlConnection cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
                Connection_Class.DB_cn();
                Connection_Class.open();
               
                SqlCommand cmd = new SqlCommand("SELECT Name FROM dbo.Users", Connection_Class.cn);
                
                SqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    MyCollection.Add(reader.GetString(0));
                }
                name_user.AutoCompleteCustomSource = MyCollection;
                Connection_Class.Close();
            }

        }
        //neama DB=DESKTOP-OG2M2CI
        //Katren DB=DESKTOP-9QTGSEL
        //SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
        
        public static String Name3 ;
       
       

        private void button1_Click(object sender, EventArgs e)
        {
            Connection_Class.DB_cn();
            Connection_Class.open();
            Name3 = name_user.Text;
            List<string> names = new List<string>();
            SqlCommand cmd = new SqlCommand("SELECT Name FROM dbo.Users", Connection_Class.cn);
            SqlDataReader sdr5 = cmd.ExecuteReader();
            //string[] numb5 = new string[sdr5.FieldCount];
            while (sdr5.Read())
            {
                for (int l = 0; l < sdr5.FieldCount; l++)
                {

                    names.Add(sdr5[l].ToString());
                }

            }

            if (names.Contains(name_user.Text))
            {
                MessageBox.Show("Your Inventory has this name." + "\n" + "You can't duplicate name !!");
                name_user.ForeColor = Color.Red; ;
            }

            else
            {
                //Add new new user
                SqlCommand cmd1 = new SqlCommand("insert into dbo.Users values( '" + Name3 + "', '" + title_user.Text + "','" + location_user.Text + "')", Connection_Class.cn);
                cmd1.ExecuteNonQuery();
                Add_New_User_Options Next = new Add_New_User_Options();
                Next.Show();
                this.Hide();
                //MessageBox.Show("Data Inserted Successfully.");
            }



            Connection_Class.Close();
            
        }

        private void back_Click(object sender, EventArgs e)
        {
            Inventory_CURD back = new Inventory_CURD();
            back.Show();
            this.Hide();
        }

        private void Add_User_Form_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
        private void resizeChildControls()
        {
            resizeControl(pictureBox1OriginalRect, pictureBox1);
            resizeControl(pictureBox2OriginalRect, pictureBox2);
            resizeControl(textBox1OriginalRect, name_user);
            resizeControl(textBox2OriginalRect, title_user);
            resizeControl(textBox3OriginalRect, location_user);
            resizeControl(button1OriginalRect, back);
            //resizeControl(button2OriginalRect, add_btn);
            resizeControl(button3OriginalRect, next_bu);
            resizeControl(label1OriginalRect, label5);
            resizeControl(label2OriginalRect, label2);
            resizeControl(label3OriginalRect, label3);
            resizeControl(label4OriginalRect, label4);

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
        private void Add_User_Form_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            pictureBox1OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            pictureBox2OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            textBox1OriginalRect = new Rectangle(name_user.Location.X, name_user.Location.Y, name_user.Width, name_user.Height);
            textBox2OriginalRect = new Rectangle(title_user.Location.X, title_user.Location.Y, title_user.Width, title_user.Height);
            textBox3OriginalRect = new Rectangle(location_user.Location.X, location_user.Location.Y, location_user.Width, location_user.Height);
            button1OriginalRect = new Rectangle(back.Location.X, back.Location.Y, back.Width, back.Height);
            //button2OriginalRect = new Rectangle(add_btn.Location.X, add_btn.Location.Y, add_btn.Width, add_btn.Height);
            button3OriginalRect = new Rectangle(next_bu.Location.X, next_bu.Location.Y, next_bu.Width, next_bu.Height);
            label1OriginalRect = new Rectangle(label5.Location.X, label5.Location.Y, label5.Width, label5.Height);
            label2OriginalRect = new Rectangle(label2.Location.X, label2.Location.Y, label2.Width, label2.Height);
            label3OriginalRect = new Rectangle(label3.Location.X, label3.Location.Y, label3.Width, label3.Height);
            label4OriginalRect = new Rectangle(label4.Location.X, label4.Location.Y, label4.Width, label4.Height);
        }
    }
}
