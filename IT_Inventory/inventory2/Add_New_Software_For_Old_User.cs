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
    public partial class Add_New_Software_For_Old_User : Form
    {
        private Rectangle PictureBox1OriginalRect;
        private Rectangle PictureBox2OriginalRect;
        private Rectangle PictureBox3OriginalRect;
        private Rectangle PictureBox4OriginalRect;
        private Rectangle PictureBox5OriginalRect;
        private Rectangle PictureBox6OriginalRect;
        private Rectangle PictureBox7OriginalRect;
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
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        private Size formOriginalSize;

        public Add_New_Software_For_Old_User()
        {
            InitializeComponent();
            {
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
                    Soft_Name_old.AutoCompleteCustomSource = MyCollection;
                    Soft_Version_old.AutoCompleteCustomSource = MyCollection1;
                    Soft_Email_old.AutoCompleteCustomSource = MyCollection2;
                    Soft_Pass_old.AutoCompleteCustomSource = MyCollection3;
                    Soft_Key_old.AutoCompleteCustomSource = MyCollection4;
                    Connection_Class.Close();
                }
            }

        }
        //SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
        private void Another_soft_old_Click(object sender, EventArgs e)
        {
            Connection_Class.DB_cn();
            Connection_Class.open();
            SqlCommand get_iduser = new SqlCommand("SELECT Id_User from dbo.Users where dbo.Users.Name='" + Edit_Form.userName + "' ;", Connection_Class.cn);
            int IdUser = Conditions_Class.Get_Id(get_iduser);
            SqlCommand cmd = new SqlCommand("select User_Soft.Id_User from Software, User_Soft where Software.[Key]='" + Soft_Key_old.Text + "' AND (Software.Type='Office' OR Software.Type='Windows')   AND Software.Id_Soft=User_Soft.Id_Soft", Connection_Class.cn);
            object user = cmd.ExecuteScalar();
            SqlCommand Check_Type = new SqlCommand("select User_Soft.Id_User from Software, User_Soft where  Software.Type='" + Soft_Name_old.Text + "'  AND User_Soft.Id_User='" +IdUser  + "'", Connection_Class.cn);
            object types = Check_Type.ExecuteScalar();
            Console.WriteLine(Edit_Form.b.ToString() + "bbbbbbb", Edit_Form.v.ToString() + "vvvvvvvvvvv");
            if (Edit_Form.b == false)
            {
                if (user != null)
                {
                    MessageBox.Show("This Key is already assigned to another user ,you can't use it again");
                }
                else if (types != null)
                {
                    MessageBox.Show("This user is already has " + Soft_Name_old.Text + " ,you can't add it again");
                    //Add_New_Software_For_Old_User add = new Add_New_Software_For_Old_User();
                    //add.Show();
                    //this.Close();
                }
               else if (((Soft_Name_old.Text.ToLower() == "foxit") || (Soft_Name_old.Text.ToLower() == "office" && Soft_Version_old.Text == "2016")) && Soft_Key_old.Text == "")
                {
                    MessageBox.Show("You must add  Key");
                    Add_New_Software_For_Old_User add = new Add_New_Software_For_Old_User();
                    add.Show();
                    if (Soft_Name_old.Text.ToLower() == "foxit")
                    { add.Soft_Name_old.Text = "Foxit"; }
                    else
                    {
                        add.Soft_Name_old.Text = "Office";
                        add.Soft_Version_old.Text = "2016";
                    }
                    this.Hide();
                }
                else if ((Soft_Name_old.Text.ToLower() == "office") && (Soft_Version_old.Text == "2019") && (Soft_Key_old.Text == "" || Soft_Email_old.Text == "" || Soft_Pass_old.Text == ""))
                {
                    MessageBox.Show("You must add  Key , Email and password of Office 2019");
                    Add_New_Software_For_Old_User add = new Add_New_Software_For_Old_User();
                    add.Show();
                    add.Soft_Name_old.Text = "Office";
                    add.Soft_Version_old.Text = "2019";
                    this.Hide();
                }
                //Get Id User

                else
                {
                    SqlCommand get_IdUser = new SqlCommand("SELECT Id_User from dbo.Users where dbo.Users.Name='" + Edit_Form.userName + "' ;", Connection_Class.cn);
                    int idUser = Conditions_Class.Get_Id(get_IdUser);
                    Console.WriteLine(idUser);
                    SqlCommand cmd2 = new SqlCommand("insert into dbo.Software values( '" + Soft_Email_old.Text + "' ,'" + Soft_Pass_old.Text + "','" + Soft_Key_old.Text + "', '" + Soft_Name_old.Text + "','" + Soft_Version_old.Text + "')", Connection_Class.cn);
                    cmd2.ExecuteNonQuery();

                    ////////////////////isert into User_Soft table///////////////////////////////// 
                    //Get Id Soft
                    SqlCommand get_Idsoft = new SqlCommand("Select dbo.Software.Id_Soft from dbo.Software WHERE  dbo.Software.Id_Soft = (select max(Id_Soft) from dbo.Software)", Connection_Class.cn);
                    Int32 idSoft = (Int32)get_Idsoft.ExecuteScalar();
                    Console.WriteLine(idSoft);
                    // Add id_soft and user_soft in User_Soft Table
                    SqlCommand cmd_id_user_soft = new SqlCommand("INSERT INTO dbo.User_Soft Values('" + idSoft + "','" + idUser + "'); ", Connection_Class.cn);
                    cmd_id_user_soft.ExecuteNonQuery();
                    SqlCommand get_Idlap = new SqlCommand("Select dbo.Laptops.Id_Laptop from dbo.Laptops WHERE  dbo.Laptops.Id_User ='" + idUser + "';", Connection_Class.cn);
                    Int32 idlap = (Int32)get_Idlap.ExecuteScalar();
                    SqlCommand cmd_id_lap_soft = new SqlCommand("INSERT INTO dbo.Soft_Laptop Values('" + idSoft + "','" + idlap + "'); ", Connection_Class.cn);
                    cmd_id_lap_soft.ExecuteNonQuery();
                    MessageBox.Show("Data Inserted Successfully.");
                    Add_Software_Options_Old_User another_soft = new Add_Software_Options_Old_User();
                    another_soft.Show();
                    this.Hide();
                }
            }
            else
            {
                
                if (user != null)
                {
                    MessageBox.Show("This Key is already assigned to another user ,you can't use it again");
                }
                else if (types != null)
                {
                    MessageBox.Show("This user is already has " + Soft_Name_old.Text + " ,you can't add it again");
                    //Add_New_Software_For_Old_User add = new Add_New_Software_For_Old_User();
                    //add.Show();
                    //this.Close();
                }
               else if (((Soft_Name_old.Text.ToLower() == "foxit") || (Soft_Name_old.Text.ToLower() == "office" && Soft_Version_old.Text == "2016")) && Soft_Key_old.Text == "")
                {
                    MessageBox.Show("You must add  Key");
                    Add_New_Software_For_Old_User add = new Add_New_Software_For_Old_User();
                    add.Show();
                    if (Soft_Name_old.Text.ToLower() == "foxit")
                    { add.Soft_Name_old.Text = "Foxit"; }
                    else
                    {
                        add.Soft_Name_old.Text = "Office";
                        add.Soft_Version_old.Text = "2016";
                    }
                    this.Hide();
                }
                else if ((Soft_Name_old.Text.ToLower() == "office") && (Soft_Version_old.Text == "2019") && (Soft_Key_old.Text == "" || Soft_Email_old.Text == "" || Soft_Pass_old.Text == ""))
                {
                    MessageBox.Show("You must add  Key , Email and password of Office 2019");
                    Add_New_Software_For_Old_User add = new Add_New_Software_For_Old_User();
                    add.Show();
                    add.Soft_Name_old.Text = "Office";
                    add.Soft_Version_old.Text = "2019";
                    this.Hide();
                }
                //Get Id User

                else
                {
                    SqlCommand get_IdUser = new SqlCommand("SELECT Id_User from dbo.Users where dbo.Users.Name='" + Edit_Form.userName + "' ;", Connection_Class.cn);
                    int idUser = Conditions_Class.Get_Id(get_IdUser);
                    Console.WriteLine(idUser);

                    SqlCommand cmd2 = new SqlCommand("insert into dbo.Software values( '" + Soft_Email_old.Text + "' ,'" + Soft_Pass_old.Text + "','" + Soft_Key_old.Text + "', '" + Soft_Name_old.Text + "','" + Soft_Version_old.Text + "')", Connection_Class.cn);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Data Inserted Successfully.");
                    ////////////////////isert into User_Soft table///////////////////////////////// 
                    //Get Id Soft
                    SqlCommand get_Idsoft = new SqlCommand("Select dbo.Software.Id_Soft from dbo.Software WHERE  dbo.Software.Id_Soft = (select max(Id_Soft) from dbo.Software)", Connection_Class.cn);
                    Int32 idSoft = (Int32)get_Idsoft.ExecuteScalar();
                    Console.WriteLine(idSoft);
                    // Add id_soft and user_soft in User_Soft Table
                    SqlCommand cmd_id_user_soft = new SqlCommand("INSERT INTO dbo.User_Soft Values('" + idSoft + "','" + idUser + "'); ", Connection_Class.cn);
                    cmd_id_user_soft.ExecuteNonQuery();
                    SqlCommand get_Iddesk = new SqlCommand("Select dbo.Desktop.Id_Desktop from dbo.Desktop WHERE  dbo.Desktop.Id_User ='" + idUser + "';", Connection_Class.cn);
                    Int32 iddesk = (Int32)get_Iddesk.ExecuteScalar();
                    Console.WriteLine(iddesk + "mmmm");
                    SqlCommand cmd_id_desk_soft = new SqlCommand("INSERT INTO dbo.Soft_Desk Values('" + idSoft + "','" + iddesk + "' ); ", Connection_Class.cn);
                    cmd_id_desk_soft.ExecuteNonQuery();
                    Add_Software_Options_Old_User another_soft = new Add_Software_Options_Old_User();
                    another_soft.Show();
                    this.Hide();
                }
            }
            Connection_Class.Close();
           
        }

       
        private void Finish_Bu_Click(object sender, EventArgs e)
        {
            Connection_Class.DB_cn();
            Connection_Class.open();
            SqlCommand cmd = new SqlCommand("select User_Soft.Id_User from Software, User_Soft where Software.[Key]='" + Soft_Key_old.Text + "' AND Software.Type='Office' AND Software.Id_Soft=User_Soft.Id_Soft", Connection_Class.cn);
            object user = cmd.ExecuteScalar();
            SqlCommand get_iduser = new SqlCommand("SELECT Id_User from dbo.Users where dbo.Users.Name='" + Edit_Form.userName + "' ;", Connection_Class.cn);
            int IdUser = Conditions_Class.Get_Id(get_iduser);
            SqlCommand Check_Type = new SqlCommand("select User_Soft.Id_User from Software, User_Soft where  Software.Type='" + Soft_Name_old.Text + "'  AND User_Soft.Id_User='" + IdUser + "'", Connection_Class.cn);
            object types = Check_Type.ExecuteScalar();
            Console.WriteLine(Edit_Form.b.ToString() + "bbbbbbb"+'\n'+ Edit_Form.v.ToString() + "vvvvvvvvvvv");
            if (Edit_Form.b == false)
            {

                //Get Id User
                SqlCommand get_IdUser = new SqlCommand("SELECT Id_User from dbo.Users where dbo.Users.Name='" + Edit_Form.userName + "' ;", Connection_Class.cn);
                int idUser = Conditions_Class.Get_Id(get_IdUser);
                Console.WriteLine(idUser);
                if (user != null)
                {
                    MessageBox.Show("This Key is already assigned to another user ,you can't use it again");
                }
                else if (types != null)
                {
                    MessageBox.Show("This user is already has " + Soft_Name_old.Text + " ,you can't add it again");
                    //Add_New_Software_For_Old_User add = new Add_New_Software_For_Old_User();
                    //add.Show();
                    //this.Close();
                }
                else if (((Soft_Name_old.Text.ToLower() == "foxit") || (Soft_Name_old.Text.ToLower() == "office" && Soft_Version_old.Text == "2016")) && Soft_Key_old.Text == "")
                {
                    MessageBox.Show("You must add  Key");
                    Add_New_Software_For_Old_User add = new Add_New_Software_For_Old_User();
                    add.Show();
                    if (Soft_Name_old.Text.ToLower() == "foxit")
                    { add.Soft_Name_old.Text = "Foxit"; }
                    else
                    {
                        add.Soft_Name_old.Text = "Office";
                        add.Soft_Version_old.Text = "2016";
                    }
                    this.Hide();
                }
                else if ((Soft_Name_old.Text.ToLower() == "office") && (Soft_Version_old.Text == "2019") && (Soft_Key_old.Text == "" || Soft_Email_old.Text == "" || Soft_Pass_old.Text == ""))
                {
                    MessageBox.Show("You must add  Key , Email and password of Office 2019");
                    Add_New_Software_For_Old_User add = new Add_New_Software_For_Old_User();
                    add.Show();
                    add.Soft_Name_old.Text = "Office";
                    add.Soft_Version_old.Text = "2019";
                    this.Hide();
                }
                //Get Id User

                else
                {

                    SqlCommand cmd2 = new SqlCommand("insert into dbo.Software values( '" + Soft_Email_old.Text + "' ,'" + Soft_Pass_old.Text + "','" + Soft_Key_old.Text + "', '" + Soft_Name_old.Text + "','" + Soft_Version_old.Text + "')", Connection_Class.cn);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Data Inserted Successfully.");
                    ////////////////////isert into User_Soft table///////////////////////////////// 
                    //Get Id Soft
                    SqlCommand get_Idsoft = new SqlCommand("Select dbo.Software.Id_Soft from dbo.Software WHERE  dbo.Software.Id_Soft = (select max(Id_Soft) from dbo.Software)", Connection_Class.cn);
                    Int32 idSoft = (Int32)get_Idsoft.ExecuteScalar();
                    Console.WriteLine(idSoft);
                    // Add id_soft and user_soft in User_Soft Table
                    SqlCommand cmd_id_user_soft = new SqlCommand("INSERT INTO dbo.User_Soft Values('" + idSoft + "','" + idUser + "'); ", Connection_Class.cn);
                    cmd_id_user_soft.ExecuteNonQuery();
                    SqlCommand get_Idlap = new SqlCommand("Select dbo.Laptops.Id_Laptop from dbo.Laptops WHERE  dbo.Laptops.Id_User='" + idUser + "';", Connection_Class.cn);
                    Int32 idlap = (Int32)get_Idlap.ExecuteScalar();
                    SqlCommand cmd_id_lap_soft = new SqlCommand("INSERT INTO dbo.Soft_Laptop Values('" + idSoft + "','" + idlap + "' ); ", Connection_Class.cn);
                    cmd_id_lap_soft.ExecuteNonQuery();
                    Edit_Form edit = new Edit_Form();
                    edit.Show();
                    edit.Name.Text = Edit_Form.userName;
                    edit.SearchName_Click(sender, e);
                    this.Hide();

                }

            }
            else
            {
                SqlCommand get_IdUser = new SqlCommand("SELECT Id_User from dbo.Users where dbo.Users.Name='" + Edit_Form.userName + "' ;", Connection_Class.cn);
                int idUser = Conditions_Class.Get_Id(get_IdUser);
                Console.WriteLine(idUser);
                if (user != null)
                {
                    MessageBox.Show("This Key is already assigned to another user ,you can't use it again");
                }
                if (((Soft_Name_old.Text.ToLower() == "foxit") || (Soft_Name_old.Text.ToLower() == "office" && Soft_Version_old.Text == "2016")) && Soft_Key_old.Text == "")
                {
                    MessageBox.Show("You must add  Key");
                    Add_New_Software_For_Old_User add = new Add_New_Software_For_Old_User();
                    add.Show();
                    if (Soft_Name_old.Text.ToLower() == "foxit")
                    { add.Soft_Name_old.Text = "Foxit"; }
                    else
                    {
                        add.Soft_Name_old.Text = "Office";
                        add.Soft_Version_old.Text = "2016";
                    }
                    this.Hide();
                }
                else if ((Soft_Name_old.Text.ToLower() == "office") && (Soft_Version_old.Text == "2019") && (Soft_Key_old.Text == "" || Soft_Email_old.Text == "" || Soft_Pass_old.Text == ""))
                {
                    MessageBox.Show("You must add  Key , Email and password of Office 2019");
                    Add_New_Software_For_Old_User add = new Add_New_Software_For_Old_User();
                    add.Show();
                    add.Soft_Name_old.Text = "Office";
                    add.Soft_Version_old.Text = "2019";
                    this.Hide();
                }
                //Get Id User

                else
                {
                    SqlCommand cmd2 = new SqlCommand("insert into dbo.Software values( '" + Soft_Email_old.Text + "' ,'" + Soft_Pass_old.Text + "','" + Soft_Key_old.Text + "', '" + Soft_Name_old.Text + "','" + Soft_Version_old.Text + "')", Connection_Class.cn);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Data Inserted Successfully.");
                    ////////////////////isert into User_Soft table///////////////////////////////// 
                    //Get Id Soft
                    SqlCommand get_Idsoft = new SqlCommand("Select dbo.Software.Id_Soft from dbo.Software WHERE  dbo.Software.Id_Soft = (select max(Id_Soft) from dbo.Software)", Connection_Class.cn);
                    Int32 idSoft = (Int32)get_Idsoft.ExecuteScalar();
                    Console.WriteLine(idSoft);
                    // Add id_soft and user_soft in User_Soft Table
                    SqlCommand cmd_id_user_soft = new SqlCommand("INSERT INTO dbo.User_Soft Values('" + idSoft + "','" + idUser + "'); ", Connection_Class.cn);
                    cmd_id_user_soft.ExecuteNonQuery();
                    SqlCommand get_Iddesk = new SqlCommand("Select dbo.Desktop.Id_Desktop from dbo.Desktop WHERE  dbo. Desktop.Id_User='" + idUser + "';", Connection_Class.cn);
                    Int32 iddesk = (Int32)get_Iddesk.ExecuteScalar();
                    SqlCommand cmd_id_desk_soft = new SqlCommand("INSERT INTO dbo.Soft_Desk Values('" + idSoft + "','" + iddesk + "'); ", Connection_Class.cn);
                    cmd_id_desk_soft.ExecuteNonQuery();
                    Edit_Form edit = new Edit_Form();
                    edit.Show();
                    edit.Name.Text = Edit_Form.userName;
                    edit.SearchName_Click(sender, e);
                    this.Hide();
                }
            }
            Connection_Class.Close();
            
        }
        private void Add_New_Desktop_New_User_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
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
        private void Add_New_Software_For_Old_User_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            PictureBox1OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            PictureBox2OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            PictureBox3OriginalRect = new Rectangle(pictureBox3.Location.X, pictureBox3.Location.Y, pictureBox3.Width, pictureBox3.Height);
            PictureBox4OriginalRect = new Rectangle(pictureBox4.Location.X, pictureBox4.Location.Y, pictureBox4.Width, pictureBox4.Height);
            PictureBox5OriginalRect = new Rectangle(pictureBox5.Location.X, pictureBox5.Location.Y, pictureBox5.Width, pictureBox5.Height);
            PictureBox6OriginalRect = new Rectangle(pictureBox6.Location.X, pictureBox6.Location.Y, pictureBox6.Width, pictureBox6.Height);
            PictureBox7OriginalRect = new Rectangle(pictureBox7.Location.X, pictureBox7.Location.Y, pictureBox7.Width, pictureBox7.Height);
            
            textBox1OriginalRect = new Rectangle(Soft_Name_old.Location.X, Soft_Name_old.Location.Y, Soft_Name_old.Width, Soft_Name_old.Height);
            textBox2OriginalRect = new Rectangle(Soft_Version_old.Location.X, Soft_Version_old.Location.Y, Soft_Version_old.Width, Soft_Version_old.Height);
            textBox3OriginalRect = new Rectangle(Soft_Key_old.Location.X, Soft_Key_old.Location.Y, Soft_Key_old.Width, Soft_Key_old.Height);
            textBox4OriginalRect = new Rectangle(Soft_Email_old.Location.X, Soft_Email_old.Location.Y, Soft_Email_old.Width, Soft_Email_old.Height);
            textBox5OriginalRect = new Rectangle(Soft_Pass_old.Location.X, Soft_Pass_old.Location.Y, Soft_Pass_old.Width, Soft_Pass_old.Height);
            button1OriginalRect = new Rectangle(Another_soft_old.Location.X, Another_soft_old.Location.Y, Another_soft_old.Width, Another_soft_old.Height);
            button2OriginalRect = new Rectangle(Finish_Bu.Location.X, Finish_Bu.Location.Y, Finish_Bu.Width, Finish_Bu.Height);
            label1OriginalRect = new Rectangle(label1.Location.X, label1.Location.Y, label1.Width, label1.Height);
            label2OriginalRect = new Rectangle(label2.Location.X, label2.Location.Y, label2.Width, label2.Height);
            label3OriginalRect = new Rectangle(label3.Location.X, label3.Location.Y, label3.Width, label3.Height);
            label4OriginalRect = new Rectangle(label4.Location.X, label4.Location.Y, label4.Width, label4.Height);
            label5OriginalRect = new Rectangle(label5.Location.X, label5.Location.Y, label5.Width, label5.Height);
           
        }
        private void resizeChildControls()
        {
            resizeControl(PictureBox1OriginalRect, pictureBox1);
            resizeControl(PictureBox2OriginalRect, pictureBox2);
            resizeControl(PictureBox3OriginalRect, pictureBox3);
            resizeControl(PictureBox4OriginalRect, pictureBox4);
            resizeControl(PictureBox5OriginalRect, pictureBox5);
            resizeControl(PictureBox6OriginalRect, pictureBox6);
            resizeControl(PictureBox7OriginalRect, pictureBox7);
            resizeControl(textBox1OriginalRect, Soft_Name_old);
            resizeControl(textBox2OriginalRect, Soft_Version_old);
            resizeControl(textBox3OriginalRect, Soft_Key_old);
            resizeControl(textBox4OriginalRect, Soft_Email_old);
            resizeControl(textBox5OriginalRect, Soft_Pass_old);
            resizeControl(label1OriginalRect, label3);
            resizeControl(label2OriginalRect, label5);
            resizeControl(label3OriginalRect, label1);
            resizeControl(label4OriginalRect, label4);
            resizeControl(label5OriginalRect, label2);
            resizeControl(button1OriginalRect, Another_soft_old);
            resizeControl(button2OriginalRect, Finish_Bu);

        }
    }
}
