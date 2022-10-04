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
    public partial class Add_Software_From_Spare_new_user : Form
    {
        private Rectangle pictureBox1OriginalRect;
        private Rectangle pictureBox2OriginalRect;
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        //private Rectangle button3OriginalRect;
        private Rectangle button4OriginalRect;
        private Rectangle button5OriginalRect;
        private Rectangle datagridviewOriginalRect;
        private Rectangle datagridview1OriginalRect;
        private Size formOriginalSize;
        public Add_Software_From_Spare_new_user()

        {
            InitializeComponent();



        }

        int f = 0;
        //SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
        public static string Name2;
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        public List<string> details = new List<string>();
        int i;


        private void Another_soft_old_Click(object sender, EventArgs e)
        {
            int n = 0;
            Connection_Class.DB_cn();
            Connection_Class.open();
            Console.WriteLine(Add_New_Laptop_New_User.id_l + "llll");
            foreach (DataGridViewRow r in Search_Grid.Rows)
            {

                if (Convert.ToBoolean(r.Cells[1].Value))
                {
                    f += 1;

                }

            }
            if (f == 0)
            {
                MessageBox.Show("First,You must check to choose the software you want ");
            }
            else
            {
                foreach (DataGridViewRow row in Search_Grid.Rows)
                {
                    Connection_Class.DB_cn();
                    Connection_Class.open();
                    details.Clear();
                    if (Convert.ToBoolean(row.Cells[1].Value))
                    {
                        n++;

                        for (i = 0; i < row.Cells.Count; i++)
                        {
                            details.Add(Search_Grid.Rows[row.Index].Cells[i].Value.ToString());


                            //Console.WriteLine(details[i].ToString());

                        }
                        DataRow dr1 = dt2.NewRow();
                        dr1["#"] = n;
                        dr1["Type"] = details[2];
                        dr1["Version"] = details[3];
                        dr1["Key"] = details[4];
                        //Fill device Type 
                        dr1["Email"] = details[5];
                        dr1["Password"] = details[6];
                        dr1["Note"] = details[7];
                        dt2.Rows.Add(dr1);
                        grid_2.DataSource = dt2;
                        //Search_Grid.Rows.RemoveAt(row.Index);
                        for (int o = 1; o < 7; o++)
                        {
                            grid_2.Columns[o].Width = 205;
                        }
                        SqlCommand get_id_user = new SqlCommand("select max(Id_User) from dbo.Users", Connection_Class.cn);
                        Int32 id = Conditions_Class.Get_Id(get_id_user);
                        SqlCommand key = new SqlCommand("select User_Soft.Id_User from Software, User_Soft where Software.[Key]='" + details[4] + "' AND Software.Type='Office' AND Software.Id_Soft=User_Soft.Id_Soft", Connection_Class.cn);
                        object Key = key.ExecuteScalar();
                        //select key
                        SqlCommand type = new SqlCommand("select User_Soft.Id_Soft from Software, User_Soft where Software.Type='" + details[2] + "' AND User_Soft.Id_User='" + id + "'  AND Software.Id_Soft=User_Soft.Id_Soft", Connection_Class.cn);
                        object Type = type.ExecuteScalar();
                        //check if this key of office is used before or not
                        if (Key != null)
                        {
                            MessageBox.Show("This Key is already assigned to another user ,you can't use it again");
                        }
                        else if (Type != null)
                        {
                            MessageBox.Show("This software has been added to that user  ,the user can't have the same software twice");
                        }
                        else
                        {

                            SqlCommand insert_into_soft = new SqlCommand("INSERT INTO dbo.Software Values( '" + details[5] + "' , '" + details[6] + "' , '" + details[4] + "','" + details[2] + "', '" + details[3] + "')", Connection_Class.cn);
                            insert_into_soft.ExecuteNonQuery();


                            SqlCommand cmd_id_user_soft = new SqlCommand("INSERT INTO dbo.User_Soft(dbo.User_Soft.Id_Soft, dbo.User_Soft.Id_User)SELECT dbo.Software.Id_Soft, '" + id + "'From Software WHERE dbo.Software.Id_Soft = (select max(Id_Soft) from dbo.Software) ; ", Connection_Class.cn);
                            cmd_id_user_soft.ExecuteNonQuery();
                            if (Add_New_Laptop_New_User.id_l == true || Add_Laptop_From_Spare_New_User.id_l_s == true)
                            {
                                SqlCommand cmd_soft_lap = new SqlCommand("INSERT INTO dbo.Soft_Laptop(dbo.Soft_Laptop.Id_Laptop, dbo.Soft_Laptop.Id_Soft)SELECT  dbo.Laptops.Id_Laptop, dbo.Software.Id_Soft FROM Laptops, Software WHERE dbo.Laptops.Id_Laptop = (select max(Id_Laptop) from dbo.Laptops) AND dbo.Software.Id_Soft = (select max(Id_Soft) from dbo.Software) ; ", Connection_Class.cn);
                                cmd_soft_lap.ExecuteNonQuery();

                                MessageBox.Show("Data Inserted Successfully.");
                                //if(f==1)
                                //{
                                //  Add_New_Laptop_New_User.id_l = false;
                                //    Add_Laptop_From_Spare_New_User.id_l_s = true;
                                //}
                               


                                SqlCommand delete_from_spare = new SqlCommand("Delete from dbo.Spare Where Spare.Type='" + details[2] + "' AND Spare.Password='" + details[6] + "' AND Spare.Email='" + details[5] + "' AND Spare.[Key]='" + details[4] + "'AND Spare.Version='" + details[3] + "'AND Spare.Note='" + details[7] + "'; ", Connection_Class.cn);
                                delete_from_spare.ExecuteNonQuery();
                                if(f==1)
                                {
                                    Add_Software_From_Spare_new_user sofware_spare_new_user = new Add_Software_From_Spare_new_user();
                                    sofware_spare_new_user.Show();
                                    this.Hide();
                                }
                                

                            }
                            else if (Add_New_Desktop_New_User.id_d == true || Add_Desktop_New_User_From_Spare.id_d_s == true)
                            {
                                SqlCommand cmd_soft_desk = new SqlCommand("INSERT INTO dbo.Soft_Desk(dbo.Soft_Desk.Id_Soft,dbo.Soft_Desk.Id_Desktop)SELECT  dbo.Software.Id_Soft, dbo.Desktop.Id_Desktop FROM Desktop, Software WHERE dbo.Software.Id_Soft = (select max(Id_Soft) from dbo.Software) AND dbo.Desktop.Id_Desktop = (select max(Id_Desktop) from dbo.Desktop)  ; ", Connection_Class.cn);
                                cmd_soft_desk.ExecuteNonQuery();
                                MessageBox.Show("Data Inserted Successfully.");
                                //if (f == 1)
                                //{
                                //    Add_New_Desktop_New_User.id_d = false;
                                //    Add_Desktop_New_User_From_Spare.id_d_s = false;
                                //}

                                SqlCommand delete_from_spare = new SqlCommand("Delete from dbo.Spare Where Spare.Type='" + details[2] + "' AND Spare.Password='" + details[6] + "' AND Spare.Email='" + details[5] + "' AND Spare.[Key]='" + details[4] + "'AND Spare.Version='" + details[3] + "'AND Spare.Note='" + details[7] + "'; ", Connection_Class.cn);
                                delete_from_spare.ExecuteNonQuery();
                                if(f==1)
                                {
                                    Add_Software_From_Spare_new_user sofware_spare_new_user = new Add_Software_From_Spare_new_user();
                                    sofware_spare_new_user.Show();
                                    this.Hide();
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("First You must add a device for this user");
                            }


                        }

                        f--;
                    }






                }
            }
            Search_Grid.ClearSelection();


            //Add_New_Laptop_New_User.id_l = false;
            //Add_New_Desktop_New_User.id_d = false;
            Connection_Class.Close();
        }
        private void Add_Software_From_Spare_new_user_Load(object sender, EventArgs e)
        {
            int numbers = 0;
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            pictureBox1OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            pictureBox2OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            button1OriginalRect = new Rectangle(back.Location.X, back.Location.Y, back.Width, back.Height);
            button2OriginalRect = new Rectangle(undo.Location.X, undo.Location.Y, undo.Width, undo.Height);
            //button3OriginalRect = new Rectangle(save.Location.X, save.Location.Y, save.Width, save.Height);
            button4OriginalRect = new Rectangle(Another_soft_old.Location.X, Another_soft_old.Location.Y, Another_soft_old.Width, Another_soft_old.Height);
            button5OriginalRect = new Rectangle(button1.Location.X, button1.Location.Y, button1.Width, button1.Height);
            datagridviewOriginalRect = new Rectangle(Search_Grid.Location.X, Search_Grid.Location.Y, Search_Grid.Width, Search_Grid.Height);
            datagridview1OriginalRect = new Rectangle(grid_2.Location.X, grid_2.Location.Y, grid_2.Width, grid_2.Height);
            Connection_Class.DB_cn();
            Connection_Class.open();
            Name2 = Add_User_Form.Name3;
            dt1.Columns.Add("#");
            dt1.Columns.Add("Check", typeof(bool));
            dt1.Columns.Add("Type");
            dt1.Columns.Add("Version");
            dt1.Columns.Add("Key");
            dt1.Columns.Add("Email");
            dt1.Columns.Add("Password");
            //add Device type column
            dt1.Columns.Add("Note");
            //Search_Grid.DataSource = dt1;
           
            List<Int32> Id_spare = new List<Int32>();
            SqlCommand Spare_Ids = new SqlCommand("Select  Id_Spare from dbo.Spare   where Type!='Monitor' AND Type!='Desktop' AND Type!='Laptop'", Connection_Class.cn);//Select id Users own this software
            SqlDataReader sdr1 = Spare_Ids.ExecuteReader();
            while (sdr1.Read())

            {

                Id_spare.Add(sdr1.GetInt32((sdr1.GetOrdinal("Id_Spare"))));


            }
            for (int s = 0; s < Id_spare.Count; s++)
            {
                numbers++;
                SqlCommand Spare_Type = new SqlCommand("Select ISNULL(Type,''),ISNULL(Version,''),ISNULL([Key],''),ISNULL(Email,''),ISNULL(Password,''),ISNULL(Note,'') from dbo.Spare where Id_Spare='" + Id_spare[s] + "'", Connection_Class.cn);//Command Query     
                SqlDataReader sdr2 = Spare_Type.ExecuteReader();
                string[] numb2 = new string[sdr2.FieldCount];
                while (sdr2.Read())
                {
                    for (int l = 0; l < sdr2.FieldCount; l++)
                    {
                        numb2[l] = sdr2[l].ToString();
                    }
                }
                DataRow dr = dt1.NewRow();
                Search_Grid.DataSource = dt1;
                Search_Grid.Width = 650;
                Search_Grid.Columns[0].Width = 30;
                foreach (DataGridViewColumn c in Search_Grid.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                for (int o = 1; o < 8; o++)
                {
                    Search_Grid.Columns[o].Width = 205;
                }
                //Fill User Details
                dr["#"] = numbers;
                dr["Check"] = false;
                dr["Type"] = numb2[0];
                dr["Version"] = numb2[1];
                dr["Key"] = numb2[2];
                //Fill device Type 
                dr["Email"] = numb2[3];
                dr["Password"] = numb2[4];
                dr["Note"] = numb2[5];
                dt1.Rows.Add(dr);

                
            }

            ////////////////////////////////////
            dt2.Columns.Add("#");
            dt2.Columns.Add("Type");
            dt2.Columns.Add("Version");
            dt2.Columns.Add("Key");
            dt2.Columns.Add("Email");
            dt2.Columns.Add("Password");
            //add Device type column
            dt2.Columns.Add("Note");
            grid_2.DataSource = dt2;
            grid_2.Width = 650;
            grid_2.Columns[0].Width = 30;
            foreach (DataGridViewColumn c in grid_2.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            for (int o = 1; o < 7; o++)
            {
                grid_2.Columns[o].Width = 205;
            }
            Connection_Class.Close();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Add_Software_Options_New_User add = new Add_Software_Options_New_User();
            add.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            int N = 0;
            Connection_Class.DB_cn();
            Connection_Class.open();

            Console.WriteLine(Add_New_Laptop_New_User.id_l + "llll");
            foreach (DataGridViewRow r in Search_Grid.Rows)
            {

                if (Convert.ToBoolean(r.Cells[1].Value))
                {
                    f += 1;


                }

            }
            if (f == 0)
            {
                MessageBox.Show("First,You must check to choose the software you want ");
                
            }
            else
            {

                foreach (DataGridViewRow row in Search_Grid.Rows)
                {
                    Connection_Class.DB_cn();
                    Connection_Class.open();
                    if (Convert.ToBoolean(row.Cells[1].Value))
                    {
                        N++;
                        details.Clear();
                        for (i = 0; i < row.Cells.Count; i++)
                        {
                            details.Add(Search_Grid.Rows[row.Index].Cells[i].Value.ToString());


                            //Console.WriteLine(details[i].ToString());

                        }
                        DataRow dr1 = dt2.NewRow();
                        dr1["#"] = N;
                        dr1["Type"] = details[2];
                        dr1["Version"] = details[3];
                        dr1["Key"] = details[4];
                        //Fill device Type 
                        dr1["Email"] = details[5];
                        dr1["Password"] = details[6];
                        dr1["Note"] = details[7];
                        dt2.Rows.Add(dr1);
                        grid_2.DataSource = dt2;
                        for (int o = 1; o < 7; o++)
                        {
                            grid_2.Columns[o].Width = 205;
                        }

                        SqlCommand get_id_user = new SqlCommand("select max(Id_User) from dbo.Users", Connection_Class.cn);
                        Int32 id = Conditions_Class.Get_Id(get_id_user);
                        SqlCommand key = new SqlCommand("select User_Soft.Id_User from Software, User_Soft where Software.[Key]='" + details[4] + "' AND Software.Type='Office' AND Software.Id_Soft=User_Soft.Id_Soft", Connection_Class.cn);
                        object Key = key.ExecuteScalar();
                        //select key
                        SqlCommand type = new SqlCommand("select User_Soft.Id_Soft from Software, User_Soft where Software.Type='" + details[2] + "' AND User_Soft.Id_User='" + id + "'  AND Software.Id_Soft=User_Soft.Id_Soft", Connection_Class.cn);
                        object Type = type.ExecuteScalar();
                        //check if this key of office is used before or not
                        if (Key != null)
                        {
                            MessageBox.Show("This Key is already assigned to another user ,you can't use it again");
                        }
                        else if (Type != null)
                        {
                            MessageBox.Show("This software has been added to that user  ,the user can't have the same software twice");
                        }
                        else
                        {

                            SqlCommand insert_into_soft = new SqlCommand("INSERT INTO dbo.Software Values( '" + details[5] + "' , '" + details[6] + "' , '" + details[4] + "','" + details[2] + "', '" + details[3] + "')", Connection_Class.cn);
                            insert_into_soft.ExecuteNonQuery();


                            SqlCommand cmd_id_user_soft = new SqlCommand("INSERT INTO dbo.User_Soft(dbo.User_Soft.Id_Soft, dbo.User_Soft.Id_User)SELECT dbo.Software.Id_Soft, '" + id + "'From Software WHERE dbo.Software.Id_Soft = (select max(Id_Soft) from dbo.Software) ; ", Connection_Class.cn);
                            cmd_id_user_soft.ExecuteNonQuery();
                            if (Add_New_Laptop_New_User.id_l == true || Add_Laptop_From_Spare_New_User.id_l_s == true)
                            {
                                SqlCommand cmd_soft_lap = new SqlCommand("INSERT INTO dbo.Soft_Laptop(dbo.Soft_Laptop.Id_Laptop, dbo.Soft_Laptop.Id_Soft)SELECT  dbo.Laptops.Id_Laptop, dbo.Software.Id_Soft FROM Laptops, Software WHERE dbo.Laptops.Id_Laptop = (select max(Id_Laptop) from dbo.Laptops) AND dbo.Software.Id_Soft = (select max(Id_Soft) from dbo.Software) ; ", Connection_Class.cn);
                                cmd_soft_lap.ExecuteNonQuery();

                                MessageBox.Show("Data Inserted Successfully.");
                                if(f==1)
                                {
                                    Add_New_Laptop_New_User.id_l = false;
                                    Add_Laptop_From_Spare_New_User.id_l_s = false;
                                }
                                
                                SqlCommand delete_from_spare = new SqlCommand("Delete from dbo.Spare Where Spare.Type='" + details[2] + "' AND Spare.Password='" + details[6] + "' AND Spare.Email='" + details[5] + "' AND Spare.[Key]='" + details[4] + "'AND Spare.Version='" + details[3] + "'AND Spare.Note='" + details[7] + "'; ", Connection_Class.cn);
                                delete_from_spare.ExecuteNonQuery();
                                //Add_Software_From_Spare_new_user sofware_spare_new_user = new Add_Software_From_Spare_new_user();
                                //sofware_spare_new_user.Show();
                                //this.Hide();


                            }
                            else if (Add_New_Desktop_New_User.id_d == true || Add_Desktop_New_User_From_Spare.id_d_s == true)
                            {
                                SqlCommand cmd_soft_desk = new SqlCommand("INSERT INTO dbo.Soft_Desk(dbo.Soft_Desk.Id_Soft,dbo.Soft_Desk.Id_Desktop)SELECT  dbo.Software.Id_Soft, dbo.Desktop.Id_Desktop FROM Desktop, Software WHERE dbo.Software.Id_Soft = (select max(Id_Soft) from dbo.Software) AND dbo.Desktop.Id_Desktop = (select max(Id_Desktop) from dbo.Desktop)  ; ", Connection_Class.cn);
                                cmd_soft_desk.ExecuteNonQuery();
                                MessageBox.Show("Data Inserted Successfully.");
                                if (f == 1)
                                {
                                    Add_New_Desktop_New_User.id_d = false;
                                    Add_Desktop_New_User_From_Spare.id_d_s = false;
                                }
                                SqlCommand delete_from_spare = new SqlCommand("Delete from dbo.Spare Where Spare.Type='" + details[2] + "' AND Spare.Password='" + details[6] + "' AND Spare.Email='" + details[5] + "' AND Spare.[Key]='" + details[4] + "'AND Spare.Version='" + details[3] + "'AND Spare.Note='" + details[7] + "'; ", Connection_Class.cn);
                                delete_from_spare.ExecuteNonQuery();
                                
                                  
                                //Add_Software_From_Spare_new_user sofware_spare_new_user = new Add_Software_From_Spare_new_user();
                                //sofware_spare_new_user.Show();
                                //this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("First You must add a device for this user");
                            }

                            
                        }
                        f--;
                    }





                   
                }
                Inventory_CURD invent = new Inventory_CURD();
                invent.Show();
                this.Hide();
                //Search_Grid.Rows.RemoveAt(row.Index);
            }
            Search_Grid.ClearSelection();


            //Add_New_Laptop_New_User.id_l = false;
            //Add_New_Desktop_New_User.id_d = false;

            
            Connection_Class.Close();
        }

        private void undo_Click(object sender, EventArgs e)
        {
            Undo undo = new Undo();
            undo.Show();
            this.Hide();
            //Connection_Class.open();
            //SqlCommand get_id = new SqlCommand("select Id_User from Users where Name ='" + Name2 + "'", Connection_Class.cn);
            //int id = Conditions_Class.Get_Id(get_id);

            //SqlCommand get_id_desk = new SqlCommand("select Id_User from Monitor where Monitor.Id_User='" + id + "' ", Connection_Class.cn);
            //object id_obj = get_id_desk.ExecuteScalar();
            //if (id_obj == null)
            //{
            //    MessageBox.Show("You can't use Undo ");

            //}
            //else
            //{
            //    SqlCommand get_id_user = new SqlCommand("Insert into Spare(Spare.Type,Spare.Serial_Number,Spare.Brand,Spare.Model,Spare.Note)select 'Monitor', Monitor.Serial_Number_Monitor,Monitor.Brand_Monitor,Monitor.Model_Monitor,ISNULL(Monitor.Note_Monitor,'')+' '+'Old'+' '+'" + Name2 + "' From Monitor WHERE Monitor.Id_User in(SELECT Id_User from dbo.Users where Name='" + Name2 + "')", Connection_Class.cn);
            //    //Int32 id = Conditions_Class.Get_Id(get_id_user);
            //    //SqlCommand get_id_user = new SqlCommand("select max(Id_User) from dbo.Users", Connection_Class.cn);
            //    get_id_user.ExecuteNonQuery();
            //    SqlCommand delete_from_spare = new SqlCommand("Delete from dbo.Monitor Where dbo.Monitor.Id_User = '" + id + "'; ", Connection_Class.cn);
            //    delete_from_spare.ExecuteNonQuery();
            //    MessageBox.Show(" Undo Done ");
            //}

            //Connection_Class.Close();
        }
        private void Add_Software_From_Spare_new_user_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
        private void resizeChildControls()
        {
            resizeControl(pictureBox1OriginalRect, pictureBox1);
            resizeControl(pictureBox2OriginalRect, pictureBox2);
            resizeControl(button1OriginalRect, back);
            resizeControl(button2OriginalRect, undo);
            //resizeControl(button3OriginalRect, save);
            resizeControl(button4OriginalRect, Another_soft_old);
            resizeControl(button5OriginalRect, button1);
            resizeControl(datagridviewOriginalRect, Search_Grid);
            resizeControl(datagridview1OriginalRect, grid_2);


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


