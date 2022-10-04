using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace inventory2
{
    public partial class Software_Search : Form
    {
        private Size formOriginalSize;
        //pics
        private Rectangle pictureBox1OriginalRect;
        private Rectangle pictureBox2OriginalRect;
        private Rectangle pictureBox3OriginalRect;
        private Rectangle pictureBox4OriginalRect;
        private Rectangle pictureBox5OriginalRect;
        private Rectangle pictureBox6OriginalRect;
        private Rectangle pictureBox7OriginalRect;

        //labels
        private Rectangle Label1OriginalRect;
        private Rectangle Label2OriginalRect;
        private Rectangle Label3OriginalRect;
        private Rectangle Label4OriginalRect;
        //comboBox
        private Rectangle Combobox1OriginalRect;
        //textbox
        private Rectangle textBox1OriginalRect;
        private Rectangle textBox2OriginalRect;
        private Rectangle textBox3OriginalRect;
        
        //buttons
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        //datagride
        private Rectangle datagridviewOriginalRect;
        private Rectangle datagridview1OriginalRect;
        
        public Software_Search()
        {
          
        InitializeComponent();

            SqlConnection cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");            
            string Sql = "select DISTINCT type from dbo.Software";
            Connection_Class.DB_cn();
            Connection_Class.open();
            SqlCommand cmd = new SqlCommand(Sql, Connection_Class.cn);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                Type_Text.Items.Add(DR[0]);

            }
            //Type_Text.Items.Add("");
            Connection_Class.Close();
            using (SqlConnection con = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;"))
            {
                Connection_Class.DB_cn();
                Connection_Class.open();
                SqlCommand cmd1 = new SqlCommand("SELECT DISTINCT dbo.Software.[Key] FROM dbo.Software", Connection_Class.cn);
                
                SqlDataReader reader = cmd1.ExecuteReader();
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    MyCollection.Add(reader.GetString(0));
                    
                }
                Key_Text.AutoCompleteCustomSource = MyCollection;
                Connection_Class.Close();
            }
            using (SqlConnection con = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;"))
            {
                Connection_Class.DB_cn();
                Connection_Class.open();
                SqlCommand cmd1 = new SqlCommand("SELECT DISTINCT dbo.Software.Version FROM dbo.Software", Connection_Class.cn);
                
                SqlDataReader reader = cmd1.ExecuteReader();
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    MyCollection.Add(reader.GetString(0));

                }
                Version_Text.AutoCompleteCustomSource = MyCollection;
                Connection_Class.Close();
            }
            using (SqlConnection con = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;"))
            {
                Connection_Class.DB_cn();
                Connection_Class.open();
                SqlCommand cmd1 = new SqlCommand("SELECT DISTINCT dbo.Software.Email FROM dbo.Software", Connection_Class.cn);
               
                SqlDataReader reader = cmd1.ExecuteReader();
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    MyCollection.Add(reader.GetString(0));

                }
                Mail_Text.AutoCompleteCustomSource = MyCollection;
                Connection_Class.Close();
            }
        }
        //neama DB=DESKTOP-OG2M2CI
        //Katren DB=DESKTOP-9QTGSEL

        //SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");

        private void Search_Software_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            int Numbers = 0;
             String Key = Key_Text.Text;
            String Type = Type_Text.Text;
            String Version = Version_Text.Text;
            String Email = Mail_Text.Text;
            this.Search_Grid.ColumnHeadersHeight = 20;
            
            //Console.WriteLine(Key);
            if (Key != "" && Type == "" && Version == "" && Email == "")// if Write in Key Field
            {
                Connection_Class.DB_cn();
                Connection_Class.open();
                //select id from Software when input is Key
                SqlCommand Key_id_CMD = new SqlCommand("Select  type, Id_Soft from dbo.Software where dbo.Software.[Key] = '" + Key + "' ", Connection_Class.cn);//get id Software
                object Key_f = Key_id_CMD.ExecuteScalar();
                //if found this key in database
                if (Key_f != null)
                {

                    SqlDataReader sdr = Key_id_CMD.ExecuteReader();
                    List<String> Type_soft = new List<String>();//create types list
                    List<Int32> Id_soft = new List<Int32>();//create soft-ids list
                    List<Int32> Id_Users = new List<Int32>();//create Uder-ids list
                    //fill types-soft and soft-ids lists
                    while (sdr.Read())
                    {
                        Id_soft.Add(sdr.GetInt32((sdr.GetOrdinal("Id_Soft"))));
                        Type_soft.Add(sdr.GetString((sdr.GetOrdinal("type"))));
                    }
                    DataTable dt1 = new DataTable();
                    //add user columns
                    dt1.Columns.Add("#");
                    
                    dt1.Columns.Add("Name");
                    
                    //add Device Columns(Desktop or Laptop)
                    dt1.Columns.Add("Device");
                    dt1.Columns.Add("Serial Number");

                    //add software that belong this key
                    dt1.Columns.Add(Type_soft[0] + " Version");
                    dt1.Columns.Add(Type_soft[0] + " Key");
                    dt1.Columns.Add(Type_soft[0] + " Email");
                    dt1.Columns.Add(Type_soft[0] + " Password");
                    
                    for (int i = 0; i < Id_soft.Count; i++)
                    {
                        SqlCommand Users_Ids = new SqlCommand("Select  DISTINCT(Id_User) from dbo.User_Soft where dbo.User_Soft.Id_Soft= '" + Id_soft[i] + "' ", Connection_Class.cn);//Select id Users own this software
                        SqlDataReader sdr1 = Users_Ids.ExecuteReader();
                        while (sdr1.Read())
                        {
                            Id_Users.Add(sdr1.GetInt32((sdr1.GetOrdinal("Id_User"))));
                        }
                        for (int s = 0; s < Id_Users.Count; s++)
                        {
                            Numbers += 1;

                           DataRow dr = null;
                            dr = dt1.NewRow();
                            SqlCommand data_user = new SqlCommand("Select dbo.Users.Name from  dbo.Users  WHERE  dbo.Users.Id_User ='" + Id_Users[s] + "' ;", Connection_Class.cn);

                            SqlDataReader sdr2 = data_user.ExecuteReader();
                            string[] numb2 = new string[sdr2.FieldCount];
                            while (sdr2.Read())
                            {
                                for (int l = 0; l < sdr2.FieldCount; l++)
                                {
                                    numb2[l] = sdr2[l].ToString();
                                }

                            }
                            dr["#"] = Numbers;
                            dr["Name"] = numb2[0];
                            
                            SqlCommand data_Soft = new SqlCommand("SELECT dbo.Software.[Key], dbo.Software.Email, dbo.Software.Password, dbo.Software.Version from dbo.Software, User_Soft where dbo.Software.Id_Soft = '" + Id_soft[i] + "' AND dbo.User_Soft.Id_Soft = '" + Id_soft[i] + "' AND dbo.User_Soft.Id_User = '" + Id_Users[s] + "'  ; ", Connection_Class.cn);
                            SqlDataReader sdr3 = data_Soft.ExecuteReader();
                            string[] numb3 = new string[sdr3.FieldCount];
                            while (sdr3.Read())
                            {
                                for (int l = 0; l < sdr3.FieldCount; l++)
                                {
                                    numb3[l] = sdr3[l].ToString();
                                }
                            }
                            //add software that belong this key
                            dr[Type_soft[0] + " Key"] = numb3[0];
                            dr[Type_soft[0] + " Email"] = numb3[1];
                            dr[Type_soft[0] + " Password"] = numb3[2];
                            dr[Type_soft[0] + " Version"] = numb3[3];
                            if (Conditions_Class.Desktop_Found(Connection_Class.cn, Id_Users[s]) != null)
                            {
                                //select User and Device From Data base
                                SqlCommand data_by_Desktop = new SqlCommand("Select dbo.Desktop.Serial_Number_Desk from dbo.Desktop Where dbo.Desktop.Id_User= '" + Id_Users[s] + "';", Connection_Class.cn);
                                SqlDataReader sdr4 = data_by_Desktop.ExecuteReader();
                                string[] DeskAndUser = new string[sdr4.FieldCount];
                                while (sdr4.Read())
                                {
                                    for (int l = 0; l < sdr4.FieldCount; l++)
                                    {
                                        DeskAndUser[l] = sdr4[l].ToString();
                                    }
                                }
                                dr["Device"] = "Desktop";
                                dr["Serial Number"] = DeskAndUser[0];
                                
                            }
                            if (Conditions_Class.Laptop_Found(Connection_Class.cn, Id_Users[s]) != null)
                            {
                                //select User and Device From Data base
                                SqlCommand data_by_Laptop = new SqlCommand("Select Serial_Number_Lap from dbo.Laptops Where dbo.Laptops.Id_User= '" + Id_Users[s] + "';", Connection_Class.cn);
                                SqlDataReader sdr4 = data_by_Laptop.ExecuteReader();
                                string[] LapAndUser = new string[sdr4.FieldCount];
                                while (sdr4.Read())
                                {
                                    for (int l = 0; l < sdr4.FieldCount; l++)
                                    {
                                        LapAndUser[l] = sdr4[l].ToString();
                                    }
                                }
                                dr["Device"] = "Laptop";
                                dr["Serial Number"] = LapAndUser[0];
                                
                            }
                            

                            dt1.Rows.Add(dr);//add the row after fill in datatable
                            Id_Users.Clear();
                        }

                    }
                   
                    Search_Grid.DataSource = dt1;//fill datagridview with datatable
                    Search_Grid.Width = 800;
                    Search_Grid.Columns[0].Width = 30;
                    foreach (DataGridViewColumn c in Search_Grid.Columns)
                    {
                        c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                        c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    for (int o = 1; o < 8; o++)
                    {
                        Search_Grid.Columns[o].Width =205;
                    }

                }

                else
                {
                    dataGridView1.Visible = true;
                    MessageBox.Show("This Key Not Found");
                }
                
                Key_Text.Clear();
                Connection_Class.Close();
            }
            else if (Type != "" && Key == "" && Version == "" && Email == "")// if Write in Type Field
            {
                Connection_Class.DB_cn();
                Connection_Class.open();
                dataGridView1.Visible = false;
                SqlCommand Type_id_CMD = new SqlCommand("Select  Id_Soft from dbo.Software where dbo.Software.Type = '" + Type + "' ", Connection_Class.cn);//get id Software

                Object Type_F = Type_id_CMD.ExecuteScalar();

                if (Type_F != null)
                {
                    Numbers = 0;
                    DataTable dt = new DataTable();
                    SqlDataReader sdr = Type_id_CMD.ExecuteReader();
                    List<String> Type_soft = new List<String>();//create types list
                    List<Int32> Id_soft = new List<Int32>();//create soft-ids list
                    List<Int32> Id_Users = new List<Int32>();//create Uder-ids list
                    //fill types-soft and soft-ids lists
                    while (sdr.Read())
                    {
                        Id_soft.Add(sdr.GetInt32((sdr.GetOrdinal("Id_Soft")))); 
                    }
                    //add user columns
                    dt.Columns.Add("#");
                    dt.Columns.Add("Name");
                    
                    //add Device Columns(Desktop or Laptop)
                    dt.Columns.Add("Device");
                    dt.Columns.Add("Serial Number");

                    //add software that belong this key
                    dt.Columns.Add(Type + " Version");
                    dt.Columns.Add(Type + " Key");
                    dt.Columns.Add(Type + " Email");
                    dt.Columns.Add(Type + " Password");
                    
                    ////create header to datagrideview
                    //this.Search_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    //this.Search_Grid.ColumnHeadersHeight = this.Search_Grid.ColumnHeadersHeight * 2;
                    //this.Search_Grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                    //this.Search_Grid.CellPainting += new DataGridViewCellPaintingEventHandler(Search_Grid_CellPainting);
                    //this.Search_Grid.Paint += new PaintEventHandler(Search_Grid_Paint);
                    //this.Search_Grid.Scroll += new ScrollEventHandler(Search_Grid_Scroll);
                    //this.Search_Grid.ColumnWidthChanged += new DataGridViewColumnEventHandler(Search_Grid_ColumnWidthChanged);
                    for (int i = 0; i < Id_soft.Count; i++)
                    {
                        SqlCommand Users_Ids = new SqlCommand("Select  DISTINCT(Id_User) from dbo.User_Soft where dbo.User_Soft.Id_Soft= '" + Id_soft[i] + "' ", Connection_Class.cn);//Select id Users own this software
                        SqlDataReader sdr1 = Users_Ids.ExecuteReader();
                        while (sdr1.Read())
                        {
                            Id_Users.Add(sdr1.GetInt32((sdr1.GetOrdinal("Id_User"))));
                        }
                        for (int s = 0; s < Id_Users.Count; s++)
                        {
                            Numbers += 1;
                            DataRow dr = null;
                            dr = dt.NewRow();
                            SqlCommand data_user = new SqlCommand("Select dbo.Users.Name from  dbo.Users  WHERE  dbo.Users.Id_User ='" + Id_Users[s] + "' ;", Connection_Class.cn);

                            SqlDataReader sdr2 = data_user.ExecuteReader();
                            string[] numb2 = new string[sdr2.FieldCount];
                            while (sdr2.Read())
                            {
                                for (int l = 0; l < sdr2.FieldCount; l++)
                                {
                                    numb2[l] = sdr2[l].ToString();
                                }
                            }
                            dr["#"] = Numbers;
                            dr["Name"] = numb2[0];
                            
                            SqlCommand data_Soft = new SqlCommand("SELECT dbo.Software.[Key], dbo.Software.Email, dbo.Software.Password, dbo.Software.Version from dbo.Software, User_Soft where dbo.Software.Id_Soft = '" + Id_soft[i] + "' AND dbo.User_Soft.Id_Soft = '" + Id_soft[i] + "' AND dbo.User_Soft.Id_User = '" + Id_Users[s] + "'  ; ", Connection_Class.cn);
                            SqlDataReader sdr3 = data_Soft.ExecuteReader();
                            string[] numb3 = new string[sdr3.FieldCount];
                            while (sdr3.Read())
                            {
                                for (int l = 0; l < sdr3.FieldCount; l++)
                                {
                                    numb3[l] = sdr3[l].ToString();
                                }
                            }
                            //add software that belong this key
                            dr[Type + " Version"] = numb3[3];
                            dr[Type + " Key"] = numb3[0];
                            dr[Type + " Email"] = numb3[1];
                            dr[Type + " Password"] = numb3[2];
                            
                            if (Conditions_Class.Desktop_Found(Connection_Class.cn, Id_Users[s]) != null)
                            {
                                //select User and Device From Data base
                                SqlCommand data_by_Desktop = new SqlCommand("Select dbo.Desktop.Serial_Number_Desk  from dbo.Desktop Where dbo.Desktop.Id_User= '" + Id_Users[s] + "';", Connection_Class.cn);
                                SqlDataReader sdr4 = data_by_Desktop.ExecuteReader();
                                string[] DeskAndUser = new string[sdr4.FieldCount];
                                while (sdr4.Read())
                                {
                                    for (int l = 0; l < sdr4.FieldCount; l++)
                                    {
                                        DeskAndUser[l] = sdr4[l].ToString();
                                    }
                                }
                                dr["Device"] = "Desktop";
                                dr["Serial Number"] = DeskAndUser[0];
                               
                            }
                            if (Conditions_Class.Laptop_Found(Connection_Class.cn, Id_Users[s]) != null)
                            {
                                //select User and Device From Data base
                                SqlCommand data_by_Laptop = new SqlCommand("Select Serial_Number_Lap  from dbo.Laptops Where dbo.Laptops.Id_User= '" + Id_Users[s] + "';", Connection_Class.cn);
                                SqlDataReader sdr4 = data_by_Laptop.ExecuteReader();
                                string[] LapAndUser = new string[sdr4.FieldCount];
                                while (sdr4.Read())
                                {
                                    for (int l = 0; l < sdr4.FieldCount; l++)
                                    {
                                        LapAndUser[l] = sdr4[l].ToString();
                                    }
                                }
                                dr["Device"] = "Laptop";
                                dr["Serial Number"] = LapAndUser[0];
                               
                            }
                            

                            dt.Rows.Add(dr);//add the row after fill in datatable
                            Id_Users.Clear();
                            Type_Text.SelectedIndex = -1;
                        }

                    }
                    Search_Grid.DataSource = dt;//fill datagridview with datatable
                    Search_Grid.Width = 800;
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
                else
                {
                    dataGridView1.Visible = true;
                    MessageBox.Show("this Type not found");
                }
                Connection_Class.Close();
                Type_Text.SelectedItem = null;
            }
            else if (Version != "" && Type != "" && Key == "" && Email == "")// if Write in Version Field
            {
                Numbers = 0;
                Connection_Class.DB_cn();
                Connection_Class.open();
                dataGridView1.Visible = false;
                SqlCommand version_id_CMD = new SqlCommand("Select  Id_Soft from dbo.Software where dbo.Software.Version = '" + Version + "' AND dbo.Software.Type = '" + Type + "'", Connection_Class.cn);//get id Software
                
                Object version_F= version_id_CMD.ExecuteScalar();
                if(version_F != null)
                {
                    SqlDataReader sdr = version_id_CMD.ExecuteReader();
                    List<Int32> Id_soft = new List<Int32>();
                    List<Int32> Id_Users = new List<Int32>();
                    while (sdr.Read())
                    {
                        Id_soft.Add(sdr.GetInt32((sdr.GetOrdinal("Id_Soft"))));
                    }
                   
                    DataTable dt = new DataTable();
                    //add user columns
                    dt.Columns.Add("#");
                    dt.Columns.Add("Name");
                    
                    //add Device Columns(Desktop or Laptop)
                    dt.Columns.Add("Device");
                    dt.Columns.Add("Serial Number");


                    //add software that belong this key
                    dt.Columns.Add(Type + " Version");
                    dt.Columns.Add(Type + " Key");
                    dt.Columns.Add(Type + " Email");
                    dt.Columns.Add(Type + " Password");
                    
                   
                    for (int i = 0; i < Id_soft.Count; i++)
                    {
                        SqlCommand Users_Ids = new SqlCommand("Select  DISTINCT(Id_User) from dbo.User_Soft where dbo.User_Soft.Id_Soft= '" + Id_soft[i] + "' ", Connection_Class.cn);//Select id Users own this software
                        SqlDataReader sdr1 = Users_Ids.ExecuteReader();
                        while (sdr1.Read())
                        {
                            Id_Users.Add(sdr1.GetInt32((sdr1.GetOrdinal("Id_User"))));
                        }
                        for (int s = 0; s < Id_Users.Count; s++)
                        {
                            Numbers += 1;
                            DataRow dr = null;
                            dr = dt.NewRow();
                            SqlCommand data_user = new SqlCommand("Select dbo.Users.Name from  dbo.Users  WHERE  dbo.Users.Id_User ='" + Id_Users[s] + "' ;", Connection_Class.cn);

                            SqlDataReader sdr2 = data_user.ExecuteReader();
                            string[] numb2 = new string[sdr2.FieldCount];
                            while (sdr2.Read())
                            {
                                for (int l = 0; l < sdr2.FieldCount; l++)
                                {
                                    numb2[l] = sdr2[l].ToString();
                                }
                            }
                            dr["#"] = Numbers;
                            dr["Name"] = numb2[0];
                           
                            SqlCommand data_Soft = new SqlCommand("SELECT dbo.Software.[Key], dbo.Software.Email, dbo.Software.Password, dbo.Software.Version from dbo.Software, User_Soft where dbo.Software.Id_Soft = '" + Id_soft[i] + "' AND dbo.User_Soft.Id_Soft = '" + Id_soft[i] + "' AND dbo.User_Soft.Id_User = '" + Id_Users[s] + "'  ; ", Connection_Class.cn);
                            SqlDataReader sdr3 = data_Soft.ExecuteReader();
                            string[] numb3 = new string[sdr3.FieldCount];
                            while (sdr3.Read())
                            {
                                for (int l = 0; l < sdr3.FieldCount; l++)
                                {
                                    numb3[l] = sdr3[l].ToString();
                                }
                            }
                            //add software that belong this key
                            dr[Type + " Version"] = numb3[3];
                            dr[Type + " Key"] = numb3[0];
                            dr[Type + " Email"] = numb3[1];
                            dr[Type + " Password"] = numb3[2];
                            
                            if (Conditions_Class.Desktop_Found(Connection_Class.cn, Id_Users[s]) != null)
                            {
                                //select User and Device From Data base
                                SqlCommand data_by_Desktop = new SqlCommand("Select dbo.Desktop.Serial_Number_Desk  from dbo.Desktop Where dbo.Desktop.Id_User= '" + Id_Users[s] + "';", Connection_Class.cn);
                                SqlDataReader sdr4 = data_by_Desktop.ExecuteReader();
                                string[] DeskAndUser = new string[sdr4.FieldCount];
                                while (sdr4.Read())
                                {
                                    for (int l = 0; l < sdr4.FieldCount; l++)
                                    {
                                        DeskAndUser[l] = sdr4[l].ToString();
                                    }
                                }
                                dr["Device"] = "Desktop";
                                dr["Serial Number"] = DeskAndUser[0];
                               
                            }
                            if (Conditions_Class.Laptop_Found(Connection_Class.cn, Id_Users[s]) != null)
                            {
                                //select User and Device From Data base
                                SqlCommand data_by_Laptop = new SqlCommand("Select Serial_Number_Lap  from dbo.Laptops Where dbo.Laptops.Id_User= '" + Id_Users[s] + "';", Connection_Class.cn);
                                SqlDataReader sdr4 = data_by_Laptop.ExecuteReader();
                                string[] LapAndUser = new string[sdr4.FieldCount];
                                while (sdr4.Read())
                                {
                                    for (int l = 0; l < sdr4.FieldCount; l++)
                                    {
                                        LapAndUser[l] = sdr4[l].ToString();
                                    }
                                }
                                dr["Device"] = "Laptop";
                                dr["Serial Number"] = LapAndUser[0];
                                
                            }
                            

                            dt.Rows.Add(dr);//add the row after fill in datatable
                            Id_Users.Clear();
                            Type_Text.SelectedIndex = -1;
                            Version_Text.Clear();
                        }

                    }
                    Search_Grid.DataSource = dt;//fill datagridview with datatable 
                    Search_Grid.Width = 800;
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

                
           
                else
                {
                    dataGridView1.Visible = false;
                    MessageBox.Show("this version does not exist");
                }
                Version_Text.Clear();
                Type_Text.SelectedItem = null;
                Connection_Class.Close();
            }
            else if (Email != "" && Version == "" && Type != "" && Key == "")// if Write in Key Field
            {
                Numbers = 0;
                Connection_Class.DB_cn();
                Connection_Class.open();
                dataGridView1.Visible = false;
                SqlCommand Email_id_CMD = new SqlCommand("Select   Id_Soft from dbo.Software where dbo.Software.Email = '" + Email + "' AND dbo.Software.Type = '" + Type + "'", Connection_Class.cn);//get id Software
               
                object Key_f = Email_id_CMD.ExecuteScalar();
                if (Key_f != null)
                {
                    SqlDataReader sdr = Email_id_CMD.ExecuteReader();
                    List<Int32> Id_soft = new List<Int32>();
                    List<Int32> Id_Users = new List<Int32>();
                    while (sdr.Read())
                    {
                        Id_soft.Add(sdr.GetInt32((sdr.GetOrdinal("Id_Soft"))));   
                    }
                    DataTable dt = new DataTable();
                    //add user columns
                    dt.Columns.Add("#");
                    dt.Columns.Add("Name");
                    
                    //add Device Columns(Desktop or Laptop)
                    dt.Columns.Add("Device");
                    dt.Columns.Add("Serial Number");


                    //add software that belong this key
                    dt.Columns.Add(Type + " Version");
                    dt.Columns.Add(Type + " Key");
                    dt.Columns.Add(Type + " Email");
                    dt.Columns.Add(Type + " Password");
                    
                    ////create header to datagrideview
                    //this.Search_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    //this.Search_Grid.ColumnHeadersHeight = this.Search_Grid.ColumnHeadersHeight * 2;
                    //this.Search_Grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                    //this.Search_Grid.CellPainting += new DataGridViewCellPaintingEventHandler(Search_Grid_CellPainting);
                    //this.Search_Grid.Paint += new PaintEventHandler(Search_Grid_Paint);
                    //this.Search_Grid.Scroll += new ScrollEventHandler(Search_Grid_Scroll);
                    //this.Search_Grid.ColumnWidthChanged += new DataGridViewColumnEventHandler(Search_Grid_ColumnWidthChanged);
                    for (int i = 0; i < Id_soft.Count; i++)
                    {
                        SqlCommand Users_Ids = new SqlCommand("Select  DISTINCT(Id_User) from dbo.User_Soft where dbo.User_Soft.Id_Soft= '" + Id_soft[i] + "' ", Connection_Class.cn);//Select id Users own this software
                        SqlDataReader sdr1 = Users_Ids.ExecuteReader();
                        while (sdr1.Read())
                        {
                            Id_Users.Add(sdr1.GetInt32((sdr1.GetOrdinal("Id_User"))));
                        }
                        for (int s = 0; s < Id_Users.Count; s++)
                        {
                            Numbers += 1;
                            DataRow dr = null;
                            dr = dt.NewRow();
                            SqlCommand data_user = new SqlCommand("Select dbo.Users.Name from  dbo.Users  WHERE  dbo.Users.Id_User ='" + Id_Users[s] + "' ;", Connection_Class.cn);

                            SqlDataReader sdr2 = data_user.ExecuteReader();
                            string[] numb2 = new string[sdr2.FieldCount];
                            while (sdr2.Read())
                            {
                                for (int l = 0; l < sdr2.FieldCount; l++)
                                {
                                    numb2[l] = sdr2[l].ToString();
                                }
                            }
                            dr["#"] = Numbers;
                            dr["Name"] = numb2[0];
                            
                            SqlCommand data_Soft = new SqlCommand("SELECT dbo.Software.[Key], dbo.Software.Email, dbo.Software.Password, dbo.Software.Version from dbo.Software, User_Soft where dbo.Software.Id_Soft = '" + Id_soft[i] + "' AND dbo.User_Soft.Id_Soft = '" + Id_soft[i] + "' AND dbo.User_Soft.Id_User = '" + Id_Users[s] + "'  ; ", Connection_Class.cn);
                            SqlDataReader sdr3 = data_Soft.ExecuteReader();
                            string[] numb3 = new string[sdr3.FieldCount];
                            while (sdr3.Read())
                            {
                                for (int l = 0; l < sdr3.FieldCount; l++)
                                {
                                    numb3[l] = sdr3[l].ToString();
                                }
                            }
                            //add software that belong this key
                            dr[Type + " Key"] = numb3[0];
                            dr[Type + " Email"] = numb3[1];
                            dr[Type + " Password"] = numb3[2];
                            dr[Type + " Version"] = numb3[3];
                            if (Conditions_Class.Desktop_Found(Connection_Class.cn, Id_Users[s]) != null)
                            {
                                //select User and Device From Data base
                                SqlCommand data_by_Desktop = new SqlCommand("Select dbo.Desktop.Serial_Number_Desk  from dbo.Desktop Where dbo.Desktop.Id_User= '" + Id_Users[s] + "';", Connection_Class.cn);
                                SqlDataReader sdr4 = data_by_Desktop.ExecuteReader();
                                string[] DeskAndUser = new string[sdr4.FieldCount];
                                while (sdr4.Read())
                                {
                                    for (int l = 0; l < sdr4.FieldCount; l++)
                                    {
                                        DeskAndUser[l] = sdr4[l].ToString();
                                    }
                                }
                                dr["Device"] = "Desktop";
                                dr["Serial Number"] = DeskAndUser[0];
                                
                            }
                            if (Conditions_Class.Laptop_Found(Connection_Class.cn, Id_Users[s]) != null)
                            {
                                //select User and Device From Data base
                                SqlCommand data_by_Laptop = new SqlCommand("Select Serial_Number_Lap  from dbo.Laptops Where dbo.Laptops.Id_User= '" + Id_Users[s] + "';", Connection_Class.cn);
                                SqlDataReader sdr4 = data_by_Laptop.ExecuteReader();
                                string[] LapAndUser = new string[sdr4.FieldCount];
                                while (sdr4.Read())
                                {
                                    for (int l = 0; l < sdr4.FieldCount; l++)
                                    {
                                        LapAndUser[l] = sdr4[l].ToString();
                                    }
                                }
                                dr["Device"] = "Laptop";
                                dr["Serial Number"] = LapAndUser[0];
                               
                            }
                            

                            dt.Rows.Add(dr);//add the row after fill in datatable
                            Id_Users.Clear();
                            
                        }

                    }
                    Search_Grid.DataSource = dt;//fill datagridview with datatable 
                    Search_Grid.Width = 800;
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



                else
                {
                    dataGridView1.Visible = true;
                    MessageBox.Show("this email does not found");
                }
                Connection_Class.Close();
                Mail_Text.Clear();
                Type_Text.SelectedIndex = -1;

            }
            else
            {
                dataGridView1.Visible = true;
                string message = "Enter Enough information to Search";
                MessageBox.Show(message);
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Search_Options search = new Search_Options();
            search.Show();
            this.Hide();
        }
        private void Search_Grid_Scroll(object sender, ScrollEventArgs e)
        {
            Rectangle rtHeader = this.Search_Grid.DisplayRectangle;
            rtHeader.Height = this.Search_Grid.ColumnHeadersHeight;
            this.Search_Grid.Invalidate(rtHeader);
        }

        private void Search_Grid_Paint(object sender, PaintEventArgs e)
        {
            int[] Counter_Cells = { 3, 0, 0, 8, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 3, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0 };
            string[] Details = { "User", "", "", "Device", "", "", "", "", "", "", "", "Monitor", "", "", "", "Software", "", "", "" };

            for (int j = 0; j < 19;)
            {

                Rectangle r1 = this.Search_Grid.GetCellDisplayRectangle(j, -1, true);
                int w2 = 30;

                r1.X += 1;
                r1.Y += 1;
                r1.Width = r1.Width + w2 - 2;
                r1.Height = r1.Height / 2 - 2;
                e.Graphics.FillRectangle(new SolidBrush(this.Search_Grid.ColumnHeadersDefaultCellStyle.BackColor), r1);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(Details[j],
                this.Search_Grid.ColumnHeadersDefaultCellStyle.Font,
                new SolidBrush(this.Search_Grid.ColumnHeadersDefaultCellStyle.ForeColor),
                r1,
                format);
                j += 1;
            }
        }

        private void Search_Grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                Rectangle r2 = e.CellBounds;
                r2.Y += e.CellBounds.Height / 2;
                r2.Height = e.CellBounds.Height / 2;
                e.PaintBackground(r2, true);
                e.PaintContent(r2);
                e.Handled = true;
            }
        }

        private void Search_Grid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {

            Rectangle rtHeader = this.Search_Grid.DisplayRectangle;
            rtHeader.Height = this.Search_Grid.ColumnHeadersHeight / 2;
            this.Search_Grid.Invalidate(rtHeader);

        }

        private void Software_Search_Load(object sender, EventArgs e)
        {
            
            //pics
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            pictureBox1OriginalRect = new Rectangle(pictureBox5.Location.X, pictureBox5.Location.Y, pictureBox5.Width, pictureBox5.Height);
            pictureBox2OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            pictureBox3OriginalRect = new Rectangle(pictureBox4.Location.X, pictureBox4.Location.Y, pictureBox4.Width, pictureBox4.Height);
            pictureBox4OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            pictureBox5OriginalRect = new Rectangle(pictureBox3.Location.X, pictureBox3.Location.Y, pictureBox3.Width, pictureBox3.Height);
            pictureBox6OriginalRect = new Rectangle(pictureBox6.Location.X, pictureBox6.Location.Y, pictureBox6.Width, pictureBox6.Height);
            pictureBox7OriginalRect = new Rectangle(pictureBox7.Location.X, pictureBox7.Location.Y, pictureBox7.Width, pictureBox7.Height);

            //labels
            Label1OriginalRect = new Rectangle(label2.Location.X, label2.Location.Y, label2.Width, label2.Height);
            Label2OriginalRect = new Rectangle(label3.Location.X, label3.Location.Y, label3.Width, label3.Height);
            Label3OriginalRect = new Rectangle(label1.Location.X, label1.Location.Y, label1.Width, label1.Height);
            Label4OriginalRect = new Rectangle(label4.Location.X, label4.Location.Y, label4.Width, label4.Height);
            //combo
            Combobox1OriginalRect = new Rectangle(Type_Text.Location.X, Type_Text.Location.Y, Type_Text.Width, Type_Text.Height);

            //textbox
            textBox1OriginalRect = new Rectangle(Version_Text.Location.X, Version_Text.Location.Y, Version_Text.Width, Version_Text.Height);
            textBox2OriginalRect = new Rectangle(Key_Text.Location.X, Key_Text.Location.Y, Key_Text.Width, Key_Text.Height);
            textBox3OriginalRect = new Rectangle(Mail_Text.Location.X, Mail_Text.Location.Y, Mail_Text.Width, Mail_Text.Height);

            //buttons
            button1OriginalRect = new Rectangle(Search_Software.Location.X, Search_Software.Location.Y, Search_Software.Width, Search_Software.Height);
            button2OriginalRect = new Rectangle(Back.Location.X, Back.Location.Y, Back.Width, Back.Height);

            //datagrid
            datagridviewOriginalRect = new Rectangle(dataGridView1.Location.X, dataGridView1.Location.Y, dataGridView1.Width, dataGridView1.Height);
            datagridview1OriginalRect = new Rectangle(Search_Grid.Location.X, Search_Grid.Location.Y, Search_Grid.Width, Search_Grid.Height);

        }
        private void resizeChildControls()
        {
            //pics
            resizeControl(pictureBox1OriginalRect, pictureBox5);
            resizeControl(pictureBox2OriginalRect, pictureBox2);
            resizeControl(pictureBox3OriginalRect, pictureBox4);
            resizeControl(pictureBox4OriginalRect, pictureBox1);
            resizeControl(pictureBox5OriginalRect, pictureBox3);
            resizeControl(pictureBox6OriginalRect, pictureBox6);
            resizeControl(pictureBox7OriginalRect, pictureBox7);
            // resize labels 
            resizeControl(Label1OriginalRect, label2);
            resizeControl(Label2OriginalRect, label3);
            resizeControl(Label3OriginalRect, label1);
            resizeControl(Label4OriginalRect, label4);
            //resize combobox
            resizeControl(Combobox1OriginalRect, Type_Text);
            //textboxs
            resizeControl(textBox1OriginalRect, Version_Text);
            resizeControl(textBox2OriginalRect, Key_Text);
            resizeControl(textBox3OriginalRect, Mail_Text);
            //buttons
            resizeControl(button1OriginalRect, Search_Software);
            resizeControl(button2OriginalRect, Back);
            //datagrid
            resizeControl(datagridviewOriginalRect, dataGridView1);
            resizeControl(datagridview1OriginalRect, Search_Grid);
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

        private void Software_Search_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Version_Text_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
