using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace inventory2
{
    public partial class Add_New_Software_New_User : Form
    {
        private Rectangle pictureBox1OriginalRect;
        private Rectangle pictureBox2OriginalRect;
        private Rectangle pictureBox3OriginalRect;
        private Rectangle pictureBox4OriginalRect;
        private Rectangle pictureBox5OriginalRect;
        private Rectangle pictureBox6OriginalRect;
        private Rectangle pictureBox7OriginalRect;
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        private Rectangle button3OriginalRect;
        //private Rectangle button4OriginalRect;
        private Rectangle textBox1OriginalRect;
        private Rectangle textBox2OriginalRect;
        private Rectangle textBox3OriginalRect;
        private Rectangle textBox4OriginalRect;
        private Rectangle textBox5OriginalRect;
        private Rectangle label1OriginalRect;
        private Rectangle label2OriginalRect;
        private Rectangle label3OriginalRect;
        private Rectangle label4OriginalRect;
        private Rectangle label5OriginalRect;
        private Size formOriginalSize;
        public Add_New_Software_New_User()
        {
            InitializeComponent();
            using (SqlConnection cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;"))
            {
                Connection_Class.DB_cn();
                Connection_Class.open();
                SqlCommand cmd = new SqlCommand("SELECT ISNULL(Type,''),ISNULL(Version,''),ISNULL(Email,''),ISNULL(Password,''),ISNULL([Key],'') FROM dbo.Software", Connection_Class.cn);

                
                SqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                AutoCompleteStringCollection MyCollection1 = new AutoCompleteStringCollection();
                AutoCompleteStringCollection MyCollection2 = new AutoCompleteStringCollection();
                AutoCompleteStringCollection MyCollection3 = new AutoCompleteStringCollection();
                AutoCompleteStringCollection MyCollection4 = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    MyCollection.Add(reader.GetString(0));
                    MyCollection1.Add(reader.GetString(1));
                    MyCollection2.Add(reader.GetString(2));
                    MyCollection3.Add(reader.GetString(3));
                    MyCollection4.Add(reader.GetString(4));
                }
                Soft_Name.AutoCompleteCustomSource = MyCollection;
                Soft_Version.AutoCompleteCustomSource = MyCollection1;
                Soft_Email.AutoCompleteCustomSource = MyCollection2;
                Soft_Pass.AutoCompleteCustomSource = MyCollection3;
                Soft_Key.AutoCompleteCustomSource = MyCollection4;
                Connection_Class.Close();
            }
        }
        public static int Id_user;
        //neama DB=DESKTOP-OG2M2CI
        //Katren DB=DESKTOP-9QTGSEL
        //SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            Connection_Class.DB_cn();
            Connection_Class.open();
            string type = Soft_Name.Text;
            SqlCommand id_user = new SqlCommand("select MAX(Id_User )from Users ", Connection_Class.cn);
             Id_user = Conditions_Class.Get_Id(id_user);
            

            SqlCommand check_Type = new SqlCommand("select User_Soft.Id_Soft from Software, User_Soft where Software.Type='" + type + "'  AND User_Soft.Id_User='" + Id_user + "' AND Software.Id_Soft=User_Soft.Id_Soft ", Connection_Class.cn);
            object Check_Type = check_Type.ExecuteScalar();
            //Check if key office is assigned before to another user so you cannot use it 
            SqlCommand cmd = new SqlCommand("select User_Soft.Id_User from Software, User_Soft where Software.[Key]='" + Soft_Key.Text + "' AND (Software.Type='Office' OR Software.Type='Windows') AND Software.Id_Soft=User_Soft.Id_Soft ", Connection_Class.cn);
            object user = cmd.ExecuteScalar();
            if (user != null)
            {
                MessageBox.Show("This Key is already assigned to another user ,you can't use it again");
            }
            else if(Check_Type != null)
            {
                MessageBox.Show("This user is already has "+type+" ,you can't add it again");
                Add_New_Software_New_User add = new Add_New_Software_New_User();
                add.Show();
                this.Close();
            }

            else 
            {


                if (Add_New_Laptop_New_User.id_l == true || Add_Laptop_From_Spare_New_User.id_l_s == true)
                {
                    if (((Soft_Name.Text.ToLower() == "foxit") || (Soft_Name.Text.ToLower() == "office" && Soft_Version.Text == "2016")) && Soft_Key.Text == "")
                    {
                        MessageBox.Show("You must add  Key");
                        Add_New_Software_New_User add = new Add_New_Software_New_User();
                        add.Show();
                        if (Soft_Name.Text.ToLower() == "foxit")
                        { add.Soft_Name.Text = "Foxit"; }
                        else
                        {
                            add.Soft_Name.Text = "Office";
                            add.Soft_Version.Text = "2016";
                        }
                        this.Hide();
                    }
                    else if ((Soft_Name.Text.ToLower() == "office") && (Soft_Version.Text == "2019") && (Soft_Key.Text == "" || Soft_Email.Text == "" || Soft_Pass.Text == ""))
                    {
                        MessageBox.Show("You must add  Key , Email and password of Office 2019");
                        Add_New_Software_New_User add = new Add_New_Software_New_User();
                        add.Show();
                        add.Soft_Name.Text = "Office";
                        add.Soft_Version.Text = "2019";
                        this.Hide();
                    }
                    else
                    {
                        SqlCommand cmd2 = new SqlCommand("insert into dbo.Software values( '" + Soft_Email.Text + "' ,'" + Soft_Pass.Text + "','" + Soft_Key.Text + "', '" + Soft_Name.Text + "','" + Soft_Version.Text + "')", Connection_Class.cn);
                        cmd2.ExecuteNonQuery();

                        ////////////////////isert into User_Soft table///////////////////////////////// 
                        // Add Software
                        SqlCommand cmd_id_user_soft = new SqlCommand("INSERT INTO dbo.User_Soft(dbo.User_Soft.Id_Soft, dbo.User_Soft.Id_User)SELECT dbo.Software.Id_Soft, dbo.Users.Id_User FROM Users, Software WHERE dbo.Users.Id_User = (select Id_User from dbo.Users Where Users.Name='" + Add_User_Form.Name3 + "') AND dbo.Software.Id_Soft = (select max(Id_Soft) from dbo.Software) ; ", Connection_Class.cn);
                        cmd_id_user_soft.ExecuteNonQuery();
                        SqlCommand cmd_soft_lap = new SqlCommand("INSERT INTO dbo.Soft_Laptop(dbo.Soft_Laptop.Id_Laptop, dbo.Soft_Laptop.Id_Soft)SELECT  dbo.Laptops.Id_Laptop, dbo.Software.Id_Soft FROM Laptops, Software WHERE dbo.Laptops.Id_Laptop = (select max(Id_Laptop) from dbo.Laptops) AND dbo.Software.Id_Soft = (select max(Id_Soft) from dbo.Software) ; ", Connection_Class.cn);
                        cmd_soft_lap.ExecuteNonQuery();
                        MessageBox.Show("Data Inserted Successfully.");
                        Inventory_CURD inv = new Inventory_CURD();
                        inv.Show();
                        this.Hide();
                    }

                }
                else if (Add_New_Desktop_New_User.id_d == true || Add_Desktop_New_User_From_Spare.id_d_s == true)
                {
                    if (((Soft_Name.Text.ToLower() == "foxit") || (Soft_Name.Text.ToLower() == "office" && Soft_Version.Text == "2016")) && Soft_Key.Text == "")
                    {
                        MessageBox.Show("You must add  Key");
                        Add_New_Software_New_User add = new Add_New_Software_New_User();
                        add.Show();
                        if (Soft_Name.Text.ToLower() == "foxit")
                        { add.Soft_Name.Text = "Foxit"; }
                        else
                        {
                            add.Soft_Name.Text = "Office";
                            add.Soft_Version.Text = "2016";
                        }
                        this.Hide();
                    }
                    else if ((Soft_Name.Text.ToLower() == "office") && (Soft_Version.Text == "2019") && (Soft_Key.Text == "" || Soft_Email.Text == "" || Soft_Pass.Text == ""))
                    {
                        MessageBox.Show("You must add  Key , Email and password of Office 2019");
                        Add_New_Software_New_User add = new Add_New_Software_New_User();
                        add.Show();
                        add.Soft_Name.Text = "Office";
                        add.Soft_Version.Text = "2019";
                        this.Hide();
                    }
                    else
                    {

                        SqlCommand cmd3 = new SqlCommand("insert into dbo.Software values( '" + Soft_Email.Text + "' ,'" + Soft_Pass.Text + "','" + Soft_Key.Text + "', '" + Soft_Name.Text + "','" + Soft_Version.Text + "')", Connection_Class.cn);
                        cmd3.ExecuteNonQuery();

                        ////////////////////isert into User_Soft table///////////////////////////////// 
                        // Add Software
                        SqlCommand cmd_id_user_soft = new SqlCommand("INSERT INTO dbo.User_Soft(dbo.User_Soft.Id_Soft, dbo.User_Soft.Id_User)SELECT dbo.Software.Id_Soft, dbo.Users.Id_User FROM Users, Software WHERE dbo.Users.Id_User = (select Id_User from dbo.Users Where Users.Name='" + Add_User_Form.Name3 + "') AND dbo.Software.Id_Soft = (select max(Id_Soft) from dbo.Software) ; ", Connection_Class.cn);
                        cmd_id_user_soft.ExecuteNonQuery();
                        SqlCommand cmd_soft_desk = new SqlCommand("INSERT INTO dbo.Soft_Desk(dbo.Soft_Desk.Id_Soft,dbo.Soft_Desk.Id_Desktop)SELECT  dbo.Software.Id_Soft, dbo.Desktop.Id_Desktop FROM Desktop, Software WHERE dbo.Software.Id_Soft = (select max(Id_Soft) from dbo.Software) AND dbo.Desktop.Id_Desktop = (select max(Id_Desktop) from dbo.Desktop)  ; ", Connection_Class.cn);
                        cmd_soft_desk.ExecuteNonQuery();
                        MessageBox.Show("Data Inserted Successfully.");
                        Inventory_CURD inv = new Inventory_CURD();
                        inv.Show();
                        this.Hide();

                    }
                }
                else
                {
                    MessageBox.Show("First You must add a device for this user");
                }
            }
            Connection_Class.Close();
            //Add_New_Laptop_New_User.id_l = false;
            //Add_New_Desktop_New_User.id_d = false;
            
        }

        private void Add_Another_Click(object sender, EventArgs e)
        {
            Connection_Class.DB_cn();
            Connection_Class.open();
            string type_software = Soft_Name.Text;
            SqlCommand id_user = new SqlCommand("select MAX(Id_User )from Users ", Connection_Class.cn);
            Id_user = Conditions_Class.Get_Id(id_user);
            //get max id_desktop to use it when add new software ont it 


            //Check if key office is assigned before to another user so you cannot use it 
            SqlCommand cmd = new SqlCommand("select User_Soft.Id_User from Software, User_Soft where Software.[Key]='" + Soft_Key.Text + "' AND (Software.Type='Office' OR Software.Type='Windows') AND Software.Id_Soft=User_Soft.Id_Soft", Connection_Class.cn);
            object user = cmd.ExecuteScalar();
            SqlCommand Check_Type= new SqlCommand("select User_Soft.Id_Soft from Software, User_Soft where  Software.Type='"+ type_software + "'  AND User_Soft.Id_User='" + Id_user +"' AND Software.Id_Soft=User_Soft.Id_Soft ", Connection_Class.cn);
            object types = Check_Type.ExecuteScalar();
            if (user != null)
            {
                MessageBox.Show("This Key is already assigned to another user ,you can't use it again");

            }
            else if (types != null)
            {
                MessageBox.Show("This user is already has "+type_software+" ,you can't add it again");
                Add_New_Software_New_User add = new Add_New_Software_New_User();
                add.Show();
                this.Close();
            }
            else
            {
                if (Add_New_Laptop_New_User.id_l == true || Add_Laptop_From_Spare_New_User.id_l_s == true)
                {
                    if (((Soft_Name.Text.ToLower() == "foxit") || (Soft_Name.Text.ToLower() == "office" && Soft_Version.Text == "2016")) && Soft_Key.Text == "")
                    {
                        MessageBox.Show("You must add  Key");
                        Add_New_Software_New_User add = new Add_New_Software_New_User();
                        add.Show();
                        if(Soft_Name.Text.ToLower() == "foxit")
                        {add.Soft_Name.Text = "Foxit"; }
                        else
                        {
                            add.Soft_Name.Text = "Office";
                            add.Soft_Version.Text = "2016";
                        }
                        
                        this.Hide();
                    }
                    else if ((Soft_Name.Text.ToLower() == "office") && (Soft_Version.Text == "2019") && (Soft_Key.Text == "" || Soft_Email.Text == "" || Soft_Pass.Text == ""))
                    {
                        MessageBox.Show("You must add  Key , Email and password of Office 2019");
                        Add_New_Software_New_User add = new Add_New_Software_New_User();
                        add.Show();
                        add.Soft_Name.Text = "Office";
                        add.Soft_Version.Text = "2019";
                        this.Hide();
                    }
                    else
                    {
                        SqlCommand cmd3 = new SqlCommand("insert into dbo.Software values( '" + Soft_Email.Text + "' ,'" + Soft_Pass.Text + "','" + Soft_Key.Text + "', '" + Soft_Name.Text + "','" + Soft_Version.Text + "')", Connection_Class.cn);
                        cmd3.ExecuteNonQuery();

                        ////////////////////isert into User_Soft table///////////////////////////////// 
                        // Add Software
                        SqlCommand cmd_id_user_soft = new SqlCommand("INSERT INTO dbo.User_Soft(dbo.User_Soft.Id_Soft, dbo.User_Soft.Id_User)SELECT dbo.Software.Id_Soft, dbo.Users.Id_User FROM Users, Software WHERE dbo.Users.Id_User = (select Id_User from dbo.Users Where Users.Name='" + Add_User_Form.Name3 + "') AND dbo.Software.Id_Soft = (select max(Id_Soft) from dbo.Software) ; ", Connection_Class.cn);
                        cmd_id_user_soft.ExecuteNonQuery();
                        SqlCommand cmd_soft_lap = new SqlCommand("INSERT INTO dbo.Soft_Laptop(dbo.Soft_Laptop.Id_Laptop, dbo.Soft_Laptop.Id_Soft)SELECT  dbo.Laptops.Id_Laptop, dbo.Software.Id_Soft FROM Laptops, Software WHERE dbo.Laptops.Id_Laptop = (select max(Id_Laptop) from dbo.Laptops) AND dbo.Software.Id_Soft = (select max(Id_Soft) from dbo.Software) ; ", Connection_Class.cn);
                        cmd_soft_lap.ExecuteNonQuery();
                        MessageBox.Show("Data Inserted Successfully.");
                        //Add_New_Laptop_New_User.id_l = false;
                        Add_Software_Options_New_User add_Software = new Add_Software_Options_New_User();
                        add_Software.Show();
                        this.Hide();
                    }
                }
                else if (Add_New_Desktop_New_User.id_d == true || Add_Desktop_New_User_From_Spare.id_d_s == true)
                {
                    if (((Soft_Name.Text.ToLower() == "foxit") || (Soft_Name.Text.ToLower() == "office" && Soft_Version.Text == "2016")) && Soft_Key.Text == "")
                    {
                        MessageBox.Show("You must add  Key");
                        Add_New_Software_New_User add = new Add_New_Software_New_User();
                        add.Show();
                        if (Soft_Name.Text.ToLower() == "foxit")
                        { add.Soft_Name.Text = "Foxit"; }
                        else
                        {
                            add.Soft_Name.Text = "Office";
                            add.Soft_Version.Text = "2016";
                        }
                        this.Hide();
                    }
                    else if ((Soft_Name.Text.ToLower() == "office") && (Soft_Version.Text == "2019") && (Soft_Key.Text == "" || Soft_Email.Text == "" || Soft_Pass.Text == ""))
                    {
                        MessageBox.Show("You must add  Key , Email and password of Office 2019");
                        Add_New_Software_New_User add = new Add_New_Software_New_User();
                        add.Show();
                        add.Soft_Name.Text = "Office";
                        add.Soft_Version.Text = "2019";
                        this.Hide();
                    }
                    else
                    {
                        SqlCommand cmd2 = new SqlCommand("insert into dbo.Software values( '" + Soft_Email.Text + "' ,'" + Soft_Pass.Text + "','" + Soft_Key.Text + "', '" + Soft_Name.Text + "','" + Soft_Version.Text + "')", Connection_Class.cn);
                        cmd2.ExecuteNonQuery();

                        ////////////////////isert into User_Soft table///////////////////////////////// 
                        // Add Software
                        SqlCommand cmd_id_user_soft = new SqlCommand("INSERT INTO dbo.User_Soft(dbo.User_Soft.Id_Soft, dbo.User_Soft.Id_User)SELECT dbo.Software.Id_Soft, dbo.Users.Id_User FROM Users, Software WHERE dbo.Users.Id_User = (select Id_User from dbo.Users Where Users.Name='" + Add_User_Form.Name3 + "') AND dbo.Software.Id_Soft = (select max(Id_Soft) from dbo.Software) ; ", Connection_Class.cn);
                        cmd_id_user_soft.ExecuteNonQuery();
                        Console.WriteLine("DDDD");
                        SqlCommand cmd_soft_desk = new SqlCommand("INSERT INTO dbo.Soft_Desk(dbo.Soft_Desk.Id_Soft,dbo.Soft_Desk.Id_Desktop)SELECT  dbo.Software.Id_Soft, dbo.Desktop.Id_Desktop FROM Desktop, Software WHERE dbo.Software.Id_Soft = (select max(Id_Soft) from dbo.Software) AND dbo.Desktop.Id_Desktop = (select max(Id_Desktop) from dbo.Desktop)  ; ", Connection_Class.cn);
                        cmd_soft_desk.ExecuteNonQuery();
                        MessageBox.Show("Data Inserted Successfully.");
                        //Add_New_Desktop_New_User.id_d = false;
                        Add_Software_Options_New_User add_Software = new Add_Software_Options_New_User();
                        add_Software.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("First You must add a device for this user");
                }
            }
            Connection_Class.Close();
            
            
        }

        private void back_Click(object sender, EventArgs e)
        {
            Add_Software_Options_New_User soft_options = new Add_Software_Options_New_User();
            soft_options.Show();
            this.Hide();
        }
        private void Add_New_Software_New_User_Resize(object sender, EventArgs e)
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
            resizeControl(pictureBox7OriginalRect, pictureBox7);
            resizeControl(textBox4OriginalRect, Soft_Email);
            resizeControl(textBox5OriginalRect, Soft_Pass);
            resizeControl(textBox3OriginalRect, Soft_Key);
            resizeControl(textBox2OriginalRect, Soft_Name);
            resizeControl(textBox1OriginalRect, Soft_Version);
            resizeControl(label1OriginalRect, label3);
            resizeControl(label2OriginalRect, label5);
            resizeControl(label3OriginalRect, label1);
            resizeControl(label4OriginalRect, label4);
            resizeControl(label5OriginalRect, label2);
            resizeControl(button1OriginalRect, back);
            resizeControl(button3OriginalRect, Add_Another);
            resizeControl(button2OriginalRect, Finish_Bu);
            
            //resizeControl(button4OriginalRect, add_soft_btn);
            
            

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
        private void Add_New_Software_New_User_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            pictureBox1OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            pictureBox2OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            pictureBox3OriginalRect = new Rectangle(pictureBox3.Location.X, pictureBox3.Location.Y, pictureBox3.Width, pictureBox3.Height);
            pictureBox4OriginalRect = new Rectangle(pictureBox4.Location.X, pictureBox4.Location.Y, pictureBox4.Width, pictureBox4.Height);
            pictureBox5OriginalRect = new Rectangle(pictureBox5.Location.X, pictureBox5.Location.Y, pictureBox5.Width, pictureBox5.Height);
            pictureBox6OriginalRect = new Rectangle(pictureBox6.Location.X, pictureBox6.Location.Y, pictureBox6.Width, pictureBox6.Height);
            pictureBox7OriginalRect = new Rectangle(pictureBox7.Location.X, pictureBox7.Location.Y, pictureBox7.Width, pictureBox7.Height);
            textBox4OriginalRect = new Rectangle(Soft_Email.Location.X, Soft_Email.Location.Y, Soft_Email.Width, Soft_Email.Height);
            textBox5OriginalRect = new Rectangle(Soft_Pass.Location.X, Soft_Pass.Location.Y, Soft_Pass.Width, Soft_Pass.Height);
            textBox3OriginalRect = new Rectangle(Soft_Key.Location.X, Soft_Key.Location.Y, Soft_Key.Width, Soft_Key.Height);
            textBox1OriginalRect = new Rectangle(Soft_Name.Location.X, Soft_Name.Location.Y, Soft_Name.Width, Soft_Name.Height);
            textBox2OriginalRect = new Rectangle(Soft_Version.Location.X, Soft_Version.Location.Y, Soft_Version.Width, Soft_Version.Height);
            button1OriginalRect = new Rectangle(back.Location.X, back.Location.Y, back.Width, back.Height);
            button2OriginalRect = new Rectangle(Finish_Bu.Location.X, Finish_Bu.Location.Y, Finish_Bu.Width, Finish_Bu.Height);
            button3OriginalRect = new Rectangle(Add_Another.Location.X, Add_Another.Location.Y, Add_Another.Width, Add_Another.Height);
            //button4OriginalRect = new Rectangle(add_soft_btn.Location.X, add_soft_btn.Location.Y, add_soft_btn.Width, add_soft_btn.Height);
            label1OriginalRect = new Rectangle(label3.Location.X, label3.Location.Y, label3.Width, label3.Height);
            label2OriginalRect = new Rectangle(label5.Location.X, label5.Location.Y, label5.Width, label5.Height);
            label3OriginalRect = new Rectangle(label1.Location.X, label1.Location.Y, label1.Width, label1.Height);
            label4OriginalRect = new Rectangle(label4.Location.X, label4.Location.Y, label4.Width, label4.Height);
            label5OriginalRect = new Rectangle(label2.Location.X, label2.Location.Y, label2.Width, label2.Height);
            
        }

        private void Soft_Version_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}