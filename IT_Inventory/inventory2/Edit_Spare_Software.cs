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
    public partial class Edit_Spare_Software : Form
    {
        private Rectangle pictureBox1OriginalRect;
        private Rectangle pictureBox2OriginalRect;
        private Rectangle grid10riginalRect;
        private Rectangle grid20riginalRect;
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
       
        private Size formOriginalSize;
        public Edit_Spare_Software()
        {
            InitializeComponent();
        }
        //SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
        
        string Name1;
        
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        public List<string> details = new List<string>();
        int i;
        int f = 0;





        private void Edit_Spare_Software_Load(object sender, EventArgs e)
        {



            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            pictureBox1OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            pictureBox2OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            grid10riginalRect = new Rectangle(data_grid.Location.X, data_grid.Location.Y, data_grid.Width, data_grid.Height);
            grid20riginalRect = new Rectangle(grid_2.Location.X, grid_2.Location.Y, grid_2.Width, grid_2.Height);
            button1OriginalRect = new Rectangle(Back.Location.X, Back.Location.Y, Back.Width, Back.Height);
            button2OriginalRect = new Rectangle(Save.Location.X, Save.Location.Y, Save.Width, Save.Height);
            int numbers = 0;
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

                data_grid.DataSource = dt1;
                data_grid.Width = 800;
                data_grid.Columns[0].Width = 30;
                foreach (DataGridViewColumn c in data_grid.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                for (int o = 1; o < 8; o++)
                {
                    data_grid.Columns[o].Width = 205;
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
            grid_2.Width = 800;
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

        private void Back_Click(object sender, EventArgs e)
        {

            Edit_Form edit = new Edit_Form();
            edit.Show();
            edit.Name.Text = Edit_Form.userName;
            edit.SearchName_Click(sender, e);
            this.Hide();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            int N = 0;
            Connection_Class.DB_cn();
            Connection_Class.open();
            SqlCommand User = new SqlCommand("Select  Id_User from dbo.Users WHERE dbo.Users.Name= '" + Edit_Form.userName + "'", Connection_Class.cn);

            Int32 Id_User = Conditions_Class.Get_Id(User);//Get_Id

            
            //////////////////////////////////////////////////////////////////////////////
            foreach (DataGridViewRow r in data_grid.Rows)
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
                foreach (DataGridViewRow row in data_grid.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[1].Value))
                    {
                        N++;
                        details.Clear();
                        for (i = 0; i < row.Cells.Count; i++)
                        {
                            details.Add(data_grid.Rows[row.Index].Cells[i].Value.ToString());


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
                        data_grid.Rows.RemoveAt(row.Index);
                        for (int o = 1; o < 7; o++)
                        {
                            grid_2.Columns[o].Width = 205;
                        }


                        //IF USER OWN LAPTOP
                        if (Edit_Form.b == false)
                        {
                            int Id_Soft=0;
                            Console.WriteLine("Laptop");
                            Connection_Class.open();
                            SqlCommand cmd111 = new SqlCommand("select Id_Laptop from Laptops where Laptops.Id_User='" + Id_User + "'", Connection_Class.cn);
                            
                            int Id_Lap = Conditions_Class.Get_Id(cmd111);
                            if (details[1].ToLower() == "foxit" && Edit_Form.User_Data_Before[23].ToLower() == "adobe")
                             {
                                SqlCommand ID_SOFT_OLD = new SqlCommand("select Id_Soft from Software where Software.type='" + Edit_Form.User_Data_Before[23] + "' AND Software.Email='" + Edit_Form.User_Data_Before[25] + "' AND Software.Password='" + Edit_Form.User_Data_Before[26] + "' AND Software.[Key]='" + Edit_Form.User_Data_Before[24] + "' AND Software.Version='" + Edit_Form.User_Data_Before[27] + "' ", Connection_Class.cn);
                                 Id_Soft = Conditions_Class.Get_Id(ID_SOFT_OLD);
                            //|| ||  || 
                            SqlCommand Update = new SqlCommand(" UPDATE dbo.Software  SET dbo.Software.[Key] = '" + details[4] + "',dbo.Software.Email='" + details[5] + "',dbo.Software.Password='" + details[6] + "',dbo.Software.Type ='" + details[2] + "',dbo.Software.Version='" + details[3] + "' WHERE Software.Id_Soft='" + Id_Soft + "'; ", Connection_Class.cn);
                                Update.ExecuteNonQuery();
                                SqlCommand delete_spare = new SqlCommand("Delete from dbo.Spare Where Spare.Type='" + details[2] + "' AND Spare.[Key]='" + details[4] + "' AND Spare.Email ='" + details[5] + "'  AND Spare.Version='" + details[6] + "'AND Spare.Note='" + details[7] + "'; ", Connection_Class.cn);
                                delete_spare.ExecuteNonQuery();
                                MessageBox.Show("Data Updated Successfully");
                                Edit_Form Edit= new Edit_Form();
                                Edit.Show();
                                this.Hide();
                                Edit.Name.Text = Edit_Form.userName;
                                Edit.SearchName_Click(sender, e);

                            }
                            else if ((details[2].ToLower() == "foxit" && Edit_Form.User_Data_Before[23].ToLower() == "foxit") || (details[2].ToLower() == "gstar" && Edit_Form.User_Data_Before[33].ToLower() == "autocad")|| (details[2].ToLower() == "autocad" && Edit_Form.User_Data_Before[33].ToLower() == "gstar")||(details[2].ToLower() == "office" && Edit_Form.User_Data_Before[18].ToLower() == "office"))
                            { 
                                if(details[2].ToLower() == "foxit" && Edit_Form.User_Data_Before[23].ToLower() == "foxit")
                                {
                                    SqlCommand ID_SOFT_OLD = new SqlCommand("select Id_Soft from Software where Software.type='" + Edit_Form.User_Data_Before[23] + "' AND Software.Email='" + Edit_Form.User_Data_Before[25] + "' AND Software.Password='" + Edit_Form.User_Data_Before[26] + "' AND Software.[Key]='" + Edit_Form.User_Data_Before[24] + "' AND Software.Version='" + Edit_Form.User_Data_Before[27] + "' ", Connection_Class.cn);
                                    Id_Soft = Conditions_Class.Get_Id(ID_SOFT_OLD);
                                    SqlCommand Insert_Soft_Spare = new SqlCommand("INSERT INTO dbo.Spare  (dbo.Spare.Type ,dbo.Spare.Email ,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note)  VALUES('" + Edit_Form.User_Data_Before[23] + "','" + Edit_Form.User_Data_Before[25] + "','" + Edit_Form.User_Data_Before[26] + "','" + Edit_Form.User_Data_Before[24] + "','" + Edit_Form.User_Data_Before[27] + "','Old'+' '+'" + Edit_Form.User_Data_Before[0] + "') ", Connection_Class.cn);
                                    Insert_Soft_Spare.ExecuteNonQuery();
                                }
                                else if((details[2].ToLower() == "gstar" && Edit_Form.User_Data_Before[33].ToLower() == "gstar") || (details[2].ToLower() == "autocad" && Edit_Form.User_Data_Before[23].ToLower() == "autocad"))
                                {
                                    SqlCommand ID_SOFT_OLD = new SqlCommand("select Id_Soft from Software where Software.type='" + Edit_Form.User_Data_Before[33] + "' AND Software.Email='" + Edit_Form.User_Data_Before[35] + "' AND Software.Password='" + Edit_Form.User_Data_Before[36] + "' AND Software.[Key]='" + Edit_Form.User_Data_Before[34] + "' AND Software.Version='" + Edit_Form.User_Data_Before[37] + "' ", Connection_Class.cn);
                                    Id_Soft = Conditions_Class.Get_Id(ID_SOFT_OLD);
                                    SqlCommand Insert_Soft_Spare = new SqlCommand("INSERT INTO dbo.Spare  (dbo.Spare.Type ,dbo.Spare.Email ,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note)  VALUES('" + Edit_Form.User_Data_Before[33] + "','" + Edit_Form.User_Data_Before[35] + "','" + Edit_Form.User_Data_Before[36] + "','" + Edit_Form.User_Data_Before[34] + "','" + Edit_Form.User_Data_Before[37] + "','Old'+' '+'" + Edit_Form.User_Data_Before[0] + "') ", Connection_Class.cn);
                                    Insert_Soft_Spare.ExecuteNonQuery();
                                }
                                else
                                {
                                    SqlCommand ID_SOFT_OLD = new SqlCommand("select Id_Soft from Software where Software.type='" + Edit_Form.User_Data_Before[18] + "' AND Software.Email='" + Edit_Form.User_Data_Before[20] + "' AND Software.Password='" + Edit_Form.User_Data_Before[21] + "' AND Software.[Key]='" + Edit_Form.User_Data_Before[19] + "' AND Software.Version='" + Edit_Form.User_Data_Before[22] + "' ", Connection_Class.cn);
                                    Id_Soft = Conditions_Class.Get_Id(ID_SOFT_OLD);
                                    SqlCommand Insert_Soft_Spare = new SqlCommand("INSERT INTO dbo.Spare  (dbo.Spare.Type ,dbo.Spare.Email ,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note)  VALUES('" + Edit_Form.User_Data_Before[18] + "','" + Edit_Form.User_Data_Before[20] + "','" + Edit_Form.User_Data_Before[21] + "','" + Edit_Form.User_Data_Before[19] + "','" + Edit_Form.User_Data_Before[22] + "','Old'+' '+'" + Edit_Form.User_Data_Before[0] + "') ", Connection_Class.cn);
                                    Insert_Soft_Spare.ExecuteNonQuery();
                                }
                                //Id_Soft=1;
                                SqlCommand Update = new SqlCommand(" UPDATE dbo.Software  SET dbo.Software.[Key] = '" + details[4] + "',dbo.Software.Email='" + details[5] + "',dbo.Software.Password='" + details[6] + "',dbo.Software.Type ='" + details[2] + "',dbo.Software.Version='" + details[3] + "' WHERE Software.Id_Soft='" + Id_Soft + "'; ", Connection_Class.cn);
                                Update.ExecuteNonQuery();
                                MessageBox.Show("Data Updated Successfully");
                                SqlCommand delete_spare = new SqlCommand("Delete from dbo.Spare Where Spare.Type = '" + details[2] + "' AND Spare.[Key] = '" + details[4] + "' AND Spare.Email = '" + details[5] + "'  AND Spare.Version = '" + details[3] + "'AND Spare.Note = '" + details[7] + "'; ", Connection_Class.cn);
                                delete_spare.ExecuteNonQuery();
                                Edit_Form Edit = new Edit_Form();
                                Edit.Show();
                                this.Hide();
                                Edit.Name.Text = Edit_Form.userName;
                                Edit.SearchName_Click(sender, e);
                            }
                            else
                            {
                                SqlCommand insert_into_soft = new SqlCommand("INSERT INTO dbo.Software Values( '" + details[5] + "' , '" + details[6] + "' , '" + details[4] + "','" + details[2] + "', '" + details[3] + "')", Connection_Class.cn);
                                insert_into_soft.ExecuteNonQuery();
                                SqlCommand insert_into_User_Soft = new SqlCommand("INSERT INTO dbo.User_Soft(dbo.User_Soft.Id_Soft, dbo.User_Soft.Id_User)SELECT dbo.Software.Id_Soft, '" + Id_User + "'From Software WHERE dbo.Software.Id_Soft = (select max(Id_Soft) from dbo.Software) ; ", Connection_Class.cn);
                                insert_into_User_Soft.ExecuteNonQuery();

                                //int id_desk = Conditions_Class.Get_Id(cmd111);
                                SqlCommand insert_into_Soft_Lap = new SqlCommand("INSERT INTO dbo.Soft_Laptop( Id_Laptop,Id_Soft) SELECT '" + Id_Lap + "',dbo.Software.Id_Soft From Software WHERE dbo.Software.Id_Soft = (select max(Id_Soft) from dbo.Software) ; ", Connection_Class.cn);
                                insert_into_Soft_Lap.ExecuteNonQuery();
                                SqlCommand delete_spare = new SqlCommand("Delete from dbo.Spare Where Spare.Type = '" + details[2] + "' AND Spare.[Key] = '" + details[4] + "' AND Spare.Email = '" + details[5] + "'  AND Spare.Version = '" + details[3] + "'AND Spare.Note = '" + details[7] + "'; ", Connection_Class.cn);
                                delete_spare.ExecuteNonQuery();

                                MessageBox.Show("Data Updated Successfully");
                                Edit_Form Edit = new Edit_Form();
                                Edit.Show();
                                this.Hide();
                                Edit.Name.Text = Edit_Form.userName;
                                Edit.SearchName_Click(sender, e);
                            }

                          

                        }
                        //the user own Desktop
                        else if (Edit_Form.b == true)
                        {

                            Console.WriteLine("Desktop");
                            Connection_Class.open();
                            int Id_Soft;
                            //SqlCommand ID_SOFT_OLD = new SqlCommand("select Id_Soft from Software where Software.type='" + Edit_Form.User_Data_Before[23] + "' AND Software.Email='" + Edit_Form.User_Data_Before[25] + "' AND Software.Password='" + Edit_Form.User_Data_Before[26] + "' AND Software.[Key]='" + Edit_Form.User_Data_Before[24] + "' AND Software.Version='" + Edit_Form.User_Data_Before[27] + "' ", Connection_Class.cn);
                            //int Id_Soft = Conditions_Class.Get_Id(ID_SOFT_OLD);
                            SqlCommand cmd111 = new SqlCommand("select Id_Desktop from Desktop where Desktop.Id_User='" + Id_User + "'", Connection_Class.cn);
                            int Id_Desk = Conditions_Class.Get_Id(cmd111);
                            if (details[1].ToLower() == "foxit" && Edit_Form.User_Data_Before[23].ToLower() == "adobe")
                            {
                                SqlCommand ID_SOFT_OLD = new SqlCommand("select Id_Soft from Software where Software.type='" + Edit_Form.User_Data_Before[23] + "' AND Software.Email='" + Edit_Form.User_Data_Before[25] + "' AND Software.Password='" + Edit_Form.User_Data_Before[26] + "' AND Software.[Key]='" + Edit_Form.User_Data_Before[24] + "' AND Software.Version='" + Edit_Form.User_Data_Before[27] + "' ", Connection_Class.cn);
                                 Id_Soft = Conditions_Class.Get_Id(ID_SOFT_OLD);
                                SqlCommand Update = new SqlCommand(" UPDATE dbo.Software  SET dbo.Software.[Key] = '" + details[4] + "',dbo.Software.Email='" + details[5] + "',dbo.Software.Password='" + details[6] + "',dbo.Software.Type ='" + details[2] + "',dbo.Software.Version='" + details[3] + "' WHERE Software.Id_Soft='" + Id_Soft + "'; ", Connection_Class.cn);
                                Update.ExecuteNonQuery();
                                MessageBox.Show("Data Updated Successfully");
                                SqlCommand delete_spare = new SqlCommand("Delete from dbo.Spare Where Spare.Type = '" + details[2] + "' AND Spare.[Key] = '" + details[4] + "' AND Spare.Email = '" + details[5] + "'  AND Spare.Version = '" + details[3] + "'AND Spare.Note = '" + details[7] + "'; ", Connection_Class.cn);
                                delete_spare.ExecuteNonQuery();
                                Edit_Form edit = new Edit_Form();
                                edit.Show();
                                this.Hide();
                                edit.Name.Text = Edit_Form.userName;
                                edit.SearchName_Click(sender, e);

                            }
                            else if (details[2].ToLower() == "foxit" && Edit_Form.User_Data_Before[23].ToLower() == "foxit" || (details[2].ToLower() == "gstar" && Edit_Form.User_Data_Before[33].ToLower() == "autocad") || (details[2].ToLower() == "autocad" && Edit_Form.User_Data_Before[33].ToLower() == "gstar") || (details[2].ToLower() == "office" && Edit_Form.User_Data_Before[18].ToLower() == "office"))
                            {
                                if (details[2].ToLower() == "foxit" && Edit_Form.User_Data_Before[23].ToLower() == "foxit")
                                {
                                    SqlCommand ID_SOFT_OLD = new SqlCommand("select Id_Soft from Software where Software.type='" + Edit_Form.User_Data_Before[23] + "' AND Software.Email='" + Edit_Form.User_Data_Before[25] + "' AND Software.Password='" + Edit_Form.User_Data_Before[26] + "' AND Software.[Key]='" + Edit_Form.User_Data_Before[24] + "' AND Software.Version='" + Edit_Form.User_Data_Before[27] + "' ", Connection_Class.cn);
                                    Id_Soft = Conditions_Class.Get_Id(ID_SOFT_OLD);
                                    SqlCommand Insert_Soft_Spare = new SqlCommand("INSERT INTO dbo.Spare  (dbo.Spare.Type ,dbo.Spare.Email ,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note)  VALUES('" + Edit_Form.User_Data_Before[23] + "','" + Edit_Form.User_Data_Before[25] + "','" + Edit_Form.User_Data_Before[26] + "','" + Edit_Form.User_Data_Before[24] + "','" + Edit_Form.User_Data_Before[27] + "','Old'+' '+'" + Edit_Form.User_Data_Before[0] + "') ", Connection_Class.cn);
                                    Insert_Soft_Spare.ExecuteNonQuery();
                                }
                                else if ((details[2].ToLower() == "gstar" && Edit_Form.User_Data_Before[23].ToLower() == "gstar") || (details[2].ToLower() == "autocad" && Edit_Form.User_Data_Before[33].ToLower() == "autocad"))
                                {
                                    SqlCommand ID_SOFT_OLD = new SqlCommand("select Id_Soft from Software where Software.type='" + Edit_Form.User_Data_Before[33] + "' AND Software.Email='" + Edit_Form.User_Data_Before[35] + "' AND Software.Password='" + Edit_Form.User_Data_Before[36] + "' AND Software.[Key]='" + Edit_Form.User_Data_Before[34] + "' AND Software.Version='" + Edit_Form.User_Data_Before[37] + "' ", Connection_Class.cn);
                                    Id_Soft = Conditions_Class.Get_Id(ID_SOFT_OLD);
                                    SqlCommand Insert_Soft_Spare = new SqlCommand("INSERT INTO dbo.Spare  (dbo.Spare.Type ,dbo.Spare.Email ,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note)  VALUES('" + Edit_Form.User_Data_Before[33] + "','" + Edit_Form.User_Data_Before[35] + "','" + Edit_Form.User_Data_Before[36] + "','" + Edit_Form.User_Data_Before[34] + "','" + Edit_Form.User_Data_Before[37] + "','Old'+' '+'" + Edit_Form.User_Data_Before[0] + "') ", Connection_Class.cn);
                                    Insert_Soft_Spare.ExecuteNonQuery();
                                }
                                else
                                {
                                    SqlCommand ID_SOFT_OLD = new SqlCommand("select Id_Soft from Software where Software.type='" + Edit_Form.User_Data_Before[18] + "' AND Software.Email='" + Edit_Form.User_Data_Before[20] + "' AND Software.Password='" + Edit_Form.User_Data_Before[21] + "' AND Software.[Key]='" + Edit_Form.User_Data_Before[19] + "' AND Software.Version='" + Edit_Form.User_Data_Before[22] + "' ", Connection_Class.cn);
                                    Id_Soft = Conditions_Class.Get_Id(ID_SOFT_OLD);
                                    SqlCommand Insert_Soft_Spare = new SqlCommand("INSERT INTO dbo.Spare  (dbo.Spare.Type ,dbo.Spare.Email ,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note)  VALUES('" + Edit_Form.User_Data_Before[18] + "','" + Edit_Form.User_Data_Before[20] + "','" + Edit_Form.User_Data_Before[21] + "','" + Edit_Form.User_Data_Before[19] + "','" + Edit_Form.User_Data_Before[22] + "','Old'+' '+'" + Edit_Form.User_Data_Before[0] + "') ", Connection_Class.cn);
                                    Insert_Soft_Spare.ExecuteNonQuery();
                                }
                                ///////////////////////////////////////////
                               
                                SqlCommand Update = new SqlCommand(" UPDATE dbo.Software  SET dbo.Software.[Key] = '" + details[4] + "',dbo.Software.Email='" + details[5] + "',dbo.Software.Password='" + details[6] + "',dbo.Software.Type ='" + details[2] + "',dbo.Software.Version='" + details[3] + "' WHERE Software.Id_Soft='" +Id_Soft  + "'; ", Connection_Class.cn);
                                Update.ExecuteNonQuery();
                                MessageBox.Show("Data Updated Successfully");
                                SqlCommand delete_spare = new SqlCommand("Delete from dbo.Spare Where Spare.Type = '" + details[2] + "' AND Spare.[Key] = '" + details[4] + "' AND Spare.Email = '" + details[5] + "'  AND Spare.Version = '" + details[3] + "'AND Spare.Note = '" + details[7] + "'; ", Connection_Class.cn);
                                delete_spare.ExecuteNonQuery();
                                Edit_Form edit = new Edit_Form();
                                edit.Show();
                                this.Hide();
                                edit.Name.Text = Edit_Form.userName;
                                edit.SearchName_Click(sender, e);
                            }
                            else
                            {
                                SqlCommand insert_into_soft = new SqlCommand("INSERT INTO dbo.Software Values( '" + details[5] + "' , '" + details[6] + "' , '" + details[4] + "','" + details[2] + "', '" + details[3] + "')", Connection_Class.cn);
                                insert_into_soft.ExecuteNonQuery();
                                SqlCommand insert_into_User_Soft = new SqlCommand("INSERT INTO dbo.User_Soft(dbo.User_Soft.Id_Soft, dbo.User_Soft.Id_User)SELECT dbo.Software.Id_Soft, '" + Id_User + "'From Software WHERE dbo.Software.Id_Soft = (select max(Id_Soft) from dbo.Software) ; ", Connection_Class.cn);
                                insert_into_User_Soft.ExecuteNonQuery();
                                
                                SqlCommand insert_into_Soft_desk = new SqlCommand("INSERT INTO dbo.Soft_Desk( Id_Desktop,Id_Soft) SELECT '" + Id_Desk + "',dbo.Software.Id_Soft From Software WHERE dbo.Software.Id_Soft = (select max(Id_Soft) from dbo.Software) ; ", Connection_Class.cn);
                                insert_into_Soft_desk.ExecuteNonQuery();
                                SqlCommand delete_spare = new SqlCommand("Delete from dbo.Spare Where Spare.Type = '" + details[2] + "' AND Spare.[Key] = '" + details[4] + "' AND Spare.Email = '" + details[5] + "'  AND Spare.Version = '" + details[3] + "'AND Spare.Note = '" + details[7] + "'; ", Connection_Class.cn);
                                delete_spare.ExecuteNonQuery();
                                MessageBox.Show("Data Updated Successfully");
                                Edit_Form edit = new Edit_Form();
                                edit.Show();
                                this.Hide();
                                edit.Name.Text = Edit_Form.userName;
                                edit.SearchName_Click(sender, e);


                            }
                            //SqlCommand cmd111 = new SqlCommand("select Id_Desktop from Desktop where Desktop.Id_User='" + Id_User + "'", Connection_Class.cn);
                            //object id_d = cmd111.ExecuteScalar();


                            //    SqlCommand insert_into_Software = new SqlCommand("INSERT INTO dbo.Software VALUES ( '" + details[1] + "' , '" + details[4] + "' , '" + details[5] + "','" + details[3] + "', '" + details[2] + "')", Connection_Class.cn);
                            //    insert_into_Software.ExecuteNonQuery();



                        }
                        else
                        {
                            MessageBox.Show("This user doesn't have  laptop or desktop");
                        }





                    }
                }
            }

            data_grid.ClearSelection();

           Connection_Class.Close();  
        }

        private void grid_2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void data_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Edit_Spare_Software_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
        private void resizeChildControls()
        {
            resizeControl(pictureBox1OriginalRect, pictureBox2);
            resizeControl(pictureBox2OriginalRect, pictureBox1);
            resizeControl(grid10riginalRect, data_grid);
            resizeControl(grid20riginalRect, grid_2);
            resizeControl(button1OriginalRect, Back);
            resizeControl(button2OriginalRect, Save);


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
        
           ///////////////////////////////////////////
    //       if(details[1] == "Foxit" )
    //                        {

    //                        }
    //                            Connection_Class.open();
    //                        if ((details[1]== "adobe" || details[1] == "Adobe") && (Edit_Form.User_Data_Before[23] == "adobe"|| Edit_Form.User_Data_Before[23] == "Adobe"))
    //                        {
    //                            SqlCommand Update = new SqlCommand(" UPDATE dbo.Software  SET dbo.Software.[Key] = '" + details[3] + "',dbo.Software.Email='" + details[4] + "',dbo.Software.Password='" + details[5] + "',dbo.Software.Type ='" + details[1] + "',dbo.Software.Version='" + details[2] + "' WHERE Software.Id_Soft='" + Edit_Form.idsoft_Old + "'; ", Connection_Class.cn);
    //    Update.ExecuteNonQuery();
                                
    //                        }
    //                        else
    //                        {
    //                            SqlCommand Insert_Soft_Spare = new SqlCommand("INSERT INTO dbo.Spare  (dbo.Spare.Type ,dbo.Spare.Email ,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note)  VALUES('" + Edit_Form.User_Data_Before[23] + "','" + Edit_Form.User_Data_Before[25] + "','" + Edit_Form.User_Data_Before[26] + "','" + Edit_Form.User_Data_Before[24] + "','" + Edit_Form.User_Data_Before[27] + "','Old'+' '+'" + Edit_Form.User_Data_Before[0] + "') ", Connection_Class.cn);
    //Insert_Soft_Spare.ExecuteNonQuery();
    //                            SqlCommand Update = new SqlCommand(" UPDATE dbo.Software  SET dbo.Software.[Key] = '" + details[3] + "',dbo.Software.Email='" + details[4] + "',dbo.Software.Password='" + details[5] + "',dbo.Software.Type ='" + details[1] + "',dbo.Software.Version='" + details[2] + "' WHERE Software.Id_Soft='" + Edit_Form.idsoft_Old + "'; ", Connection_Class.cn);
    //Update.ExecuteNonQuery();
    //                            MessageBox.Show("Data Updated Successfully");
    //                        }
     
     

