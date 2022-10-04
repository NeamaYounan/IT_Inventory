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
    public partial class Add_Software_From_Spare_Old_User : Form
    {
        private Rectangle pictureBox1OriginalRect;
        private Rectangle pictureBox2OriginalRect;
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        private Rectangle button3OriginalRect;
        private Rectangle datagridviewOriginalRect;
        private Rectangle datagridview1OriginalRect;
        private Size formOriginalSize;
        public Add_Software_From_Spare_Old_User()
        {
            InitializeComponent();
            
        }
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        public List<string> details = new List<string>();
        int i;
        
        //SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");


        private void save_Click(object sender, EventArgs e)
        {
            int f = 0;
            int n = 0;
            Connection_Class.Close();
            Connection_Class.DB_cn();
            Connection_Class.open();
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
                    if (Convert.ToBoolean(row.Cells[1].Value))
                    {
                        n++;
                        details.Clear();
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
                        for (int o = 1; o < 7; o++)
                        {
                            grid_2.Columns[o].Width = 205;
                        }
                        // Search_Grid.Rows.RemoveAt(row.Index);

                        SqlCommand get_id_user = new SqlCommand("select Id_User from dbo.Users where dbo.Users.Name='" + Edit_Form.userName + "' ", Connection_Class.cn);
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

                            /////////////////////////////////////////////////////////////
                            SqlCommand insert_into_soft = new SqlCommand("INSERT INTO dbo.Software Values( '" + details[5] + "' , '" + details[6] + "' , '" + details[4] + "','" + details[2] + "', '" + details[3] + "')", Connection_Class.cn);
                            insert_into_soft.ExecuteNonQuery();


                            SqlCommand cmd_id_user_soft = new SqlCommand("INSERT INTO dbo.User_Soft(dbo.User_Soft.Id_Soft, dbo.User_Soft.Id_User)SELECT dbo.Software.Id_Soft, '" + id + "'From Software WHERE dbo.Software.Id_Soft = (select max(Id_Soft) from dbo.Software) ; ", Connection_Class.cn);
                            cmd_id_user_soft.ExecuteNonQuery();

                            SqlCommand cmd_id_soft = new SqlCommand("select max(Id_Soft) from dbo.Software ; ", Connection_Class.cn);
                            Int32 idSoft = (Int32)cmd_id_soft.ExecuteScalar();
                            //insert software
                            //SqlCommand software = new SqlCommand("INSERT INTO dbo.SoftwareValues( '" + details[4] + "' , '" + details[5] + "' , '" + details[3] + "','" + details[1] + "', '" + details[2] + "')", Connection_Class.cn);
                            //software.ExecuteNonQuery();
                            //SqlCommand cmd_id_user_soft = new SqlCommand("INSERT INTO dbo.User_Soft(dbo.User_Soft.Id_Soft, dbo.User_Soft.Id_User)SELECT dbo.Software.Id_Soft, '" + id + "'From Software WHERE dbo.Software.Id_Soft = '" + Edit_Form.idsoft_Old + "';", Connection_Class.cn);
                            //cmd_id_user_soft.ExecuteNonQuery();

                            //SqlCommand cmd_id_soft = new SqlCommand("select max(Id_Soft) from dbo.Software ; ", Connection_Class.cn);
                            //Int32 idSoft = (Int32)cmd_id_soft.ExecuteScalar();


                            if (Edit_Form.b == false)
                            {

                                SqlCommand get_Idlap = new SqlCommand("Select dbo.Laptops.Id_Laptop from dbo.Laptops WHERE  dbo.Laptops.Id_Laptop= (select Id_Laptop from dbo.Laptops where dbo.Laptops.Id_User='" + id + "')", Connection_Class.cn);
                                Int32 idlap = (Int32)get_Idlap.ExecuteScalar();
                                SqlCommand cmd_id_desk_soft = new SqlCommand("INSERT INTO dbo.Soft_Laptop Values('" + idSoft + "','" + idlap + "' ); ", Connection_Class.cn);
                                cmd_id_desk_soft.ExecuteNonQuery();
                                
                                
                                SqlCommand delete_from_spare = new SqlCommand("Delete from dbo.Spare Where Spare.type='" + details[2] + "'AND Spare.Password='" + details[6] + "'AND Spare.Email='" + details[5] + "'AND Spare.[Key]='" + details[4] + "'AND Spare.Version='" + details[3] + "'AND Spare.Note='" + details[7] + "'; ", Connection_Class.cn);
                                delete_from_spare.ExecuteNonQuery();
                                MessageBox.Show("Data Updated Successfully");
                                if (f==1)
                                {
                                  
                                    Edit_Form edit = new Edit_Form();
                                    edit.Name.Text = Edit_Form.userName;
                                    edit.SearchName_Click(sender, e);
                                    edit.Show();
                                    this.Hide();
                                    
                                }
                                
                            }
                            else
                            {
                                SqlCommand get_Iddesk = new SqlCommand("Select dbo.Desktop.Id_Desktop from dbo.Desktop WHERE  dbo.Desktop.Id_Desktop = (select Id_Desktop from dbo.Desktop where dbo.Desktop.Id_User='" + id + "' )", Connection_Class.cn);
                                Int32 iddesk = (Int32)get_Iddesk.ExecuteScalar();
                                SqlCommand cmd_id_desk_soft = new SqlCommand("INSERT INTO dbo.Soft_Desk Values('" + idSoft + "','" + iddesk + "' ); ", Connection_Class.cn);
                                cmd_id_desk_soft.ExecuteNonQuery();
                                
                                SqlCommand delete_from_spare = new SqlCommand("Delete from dbo.Spare Where Spare.type='" + details[1] + "'AND Spare.Password='" + details[5] + "'AND Spare.Email='" + details[4] + "'AND Spare.[Key]='" + details[3] + "'AND Spare.Version='" + details[2] + "'AND Spare.Note='" + details[6] + "'; ", Connection_Class.cn);
                                delete_from_spare.ExecuteNonQuery();
                                MessageBox.Show("Data Updated Successfully");
                                if (f==1)
                                {
                                    
                                    Edit_Form edit = new Edit_Form();
                                    edit.Name.Text = Edit_Form.userName;
                                    edit.SearchName_Click(sender, e);
                                    edit.Show();
                                    this.Hide();
                                    
                                }
                                
                            }

                        }
                        f--;
                        Console.WriteLine(f);
                    }
                    
                }
                
            }
            Search_Grid.ClearSelection();
            Connection_Class.Close();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Edit_Form edit = new Edit_Form();
            edit.Show();
            edit.Name.Text = Edit_Form.userName;
            edit.SearchName_Click(sender, e);
            this.Hide();
        }

        private void Another_soft_old_Click(object sender, EventArgs e)
        {
            int f = 0;
            int N = 0;
            Connection_Class.DB_cn();
            Connection_Class.open();
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
                    if (Convert.ToBoolean(row.Cells[1].Value))
                    {
                        N++;
                        details.Clear();
                        for (i = 0; i < row.Cells.Count; i++)
                        {
                            details.Add(Search_Grid.Rows[row.Index].Cells[i].Value.ToString());
                            Console.WriteLine(details[i].ToString());
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
                            Search_Grid.Columns[o].Width = 205;
                        }


                        //Search_Grid.Rows.RemoveAt(row.Index);

                        SqlCommand get_id_user = new SqlCommand("select Id_User from dbo.Users where dbo.Users.Name='" + Edit_Form.userName + "' ", Connection_Class.cn);
                        Int32 id = Conditions_Class.Get_Id(get_id_user);
                        SqlCommand key = new SqlCommand("select User_Soft.Id_User from Software, User_Soft where Software.[Key]='" + details[4] + "' AND Software.Type='" + details[2] + "' AND Software.Type='Office' AND Software.Id_Soft=User_Soft.Id_Soft", Connection_Class.cn);
                        object Key = key.ExecuteScalar();
                        //select key
                        SqlCommand type = new SqlCommand("select User_Soft.Id_Soft from Software, User_Soft where Software.Type='" + details[2] + "' AND Software.[Key]='" + details[4] + "' AND  User_Soft.Id_User='" + id + "'  AND Software.Id_Soft=User_Soft.Id_Soft", Connection_Class.cn);
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

                            SqlCommand cmd_id_soft = new SqlCommand("select max(Id_Soft) from dbo.Software ; ", Connection_Class.cn);
                            Int32 idSoft = (Int32)cmd_id_soft.ExecuteScalar();

                            if (Edit_Form.b == false)
                            {
                                Console.WriteLine(2222222222);
                                SqlCommand get_Idlap = new SqlCommand("Select dbo.Laptops.Id_Laptop from dbo.Laptops WHERE  dbo.Laptops.Id_Laptop= (select Id_Laptop from dbo.Laptops where dbo.Laptops.Id_User='" + id + "')", Connection_Class.cn);
                                Int32 idlap = (Int32)get_Idlap.ExecuteScalar();
                                SqlCommand cmd_id_desk_soft = new SqlCommand("INSERT INTO dbo.Soft_Laptop Values('" + idSoft + "','" + idlap + "' ); ", Connection_Class.cn);
                                cmd_id_desk_soft.ExecuteNonQuery();
                                
                                SqlCommand delete_from_spare = new SqlCommand("Delete from dbo.Spare Where Spare.type='" + details[2] + "'AND Spare.Password='" + details[6] + "'AND Spare.Email='" + details[5] + "'AND Spare.[Key]='" + details[4] + "'AND Spare.Version='" + details[3] + "'AND Spare.Note='" + details[7] + "'; ", Connection_Class.cn);
                                delete_from_spare.ExecuteNonQuery();
                                MessageBox.Show("Data Updated Successfully");
                                if (f==1)
                                {
                                    
                                    Search_Grid.ClearSelection();
                                    Add_Software_From_Spare_Old_User add_another = new Add_Software_From_Spare_Old_User();
                                    add_another.Show();
                                    this.Hide();
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine(11111);
                                SqlCommand get_Iddesk = new SqlCommand("Select dbo.Desktop.Id_Desktop from dbo.Desktop WHERE  dbo.Desktop.Id_Desktop = (select Id_Desktop from dbo.Desktop where dbo.Desktop.Id_User='" + id + "' )", Connection_Class.cn);
                                Int32 iddesk = Conditions_Class.Get_Id(get_Iddesk);
                                SqlCommand cmd_id_desk_soft = new SqlCommand("INSERT INTO dbo.Soft_Desk Values('" + idSoft + "','" + iddesk + "' ); ", Connection_Class.cn);
                                cmd_id_desk_soft.ExecuteNonQuery();
                                
                                SqlCommand delete_from_spare = new SqlCommand("Delete from dbo.Spare Where Spare.type='" + details[2] + "'AND Spare.Password='" + details[6] + "'AND Spare.Email='" + details[5] + "'AND Spare.[Key]='" + details[4] + "'AND Spare.Version='" + details[3] + "'AND Spare.Note='" + details[7] + "'; ", Connection_Class.cn);
                                delete_from_spare.ExecuteNonQuery();
                                MessageBox.Show("Data Updated Successfully");
                                if (f==1)
                                {
                                    Add_Software_From_Spare_Old_User add_another = new Add_Software_From_Spare_Old_User();
                                    add_another.Show();
                                    this.Hide();
                                }
                                
                                
                            }

                        }
                        f--;
                        Console.WriteLine(f);
                    }
                    
                    
                }

            }
            Search_Grid.ClearSelection();
            Connection_Class.Close();
            
        }

        private void Add_Software_From_Spare_Old_User_Load(object sender, EventArgs e)
        {
            
            int numbers = 0;
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            pictureBox1OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            pictureBox2OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            button1OriginalRect = new Rectangle(back.Location.X, back.Location.Y, back.Width, back.Height);
            button2OriginalRect = new Rectangle(Another_soft_old.Location.X, Another_soft_old.Location.Y, Another_soft_old.Width, Another_soft_old.Height);
            button3OriginalRect = new Rectangle(save.Location.X, save.Location.Y, save.Width, save.Height);
            datagridviewOriginalRect = new Rectangle(Search_Grid.Location.X, Search_Grid.Location.Y, Search_Grid.Width, Search_Grid.Height);
            datagridview1OriginalRect = new Rectangle(grid_2.Location.X, grid_2.Location.Y, grid_2.Width, grid_2.Height);
            Connection_Class.DB_cn();
            Connection_Class.open();
            //Get spare type from Spare table
            dt1.Columns.Add("#");
            dt1.Columns.Add("Check", typeof(bool));
            dt1.Columns.Add("Type");
            dt1.Columns.Add("Version");
            dt1.Columns.Add("Key");
            dt1.Columns.Add("Email");
            dt1.Columns.Add("Password");
            //add Device type column
            dt1.Columns.Add("Note");
            List<Int32> Id_spare = new List<Int32>();
            SqlCommand Spare_Ids = new SqlCommand("Select  Id_Spare from dbo.Spare where   Type!='Monitor'  AND Type!='Desktop' AND Type!='Laptop'", Connection_Class.cn);//Select id Users own this software
            SqlDataReader sdr1 = Spare_Ids.ExecuteReader();
            while (sdr1.Read())

            {

                Id_spare.Add(sdr1.GetInt32((sdr1.GetOrdinal("Id_Spare"))));


            }
            for (int s = 0; s < Id_spare.Count; s++)
            {
                numbers++;
                SqlCommand Spare_Type = new SqlCommand("Select Type,Version,[Key],Email,Password,Note from dbo.Spare where Id_Spare='" + Id_spare[s] + "'", Connection_Class.cn);//Command Query     
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
        private void Add_Software_From_Spare_Old_User_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
        private void resizeChildControls()
        {
            resizeControl(pictureBox1OriginalRect, pictureBox1);
            resizeControl(pictureBox2OriginalRect, pictureBox2);
            resizeControl(button1OriginalRect, back);
            resizeControl(button2OriginalRect, Another_soft_old);
            resizeControl(button3OriginalRect, save);
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
