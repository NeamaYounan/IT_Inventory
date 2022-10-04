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
    public partial class Edit_Form : Form
    {
        private Rectangle pictureBox1OriginalRect;
        private Rectangle pictureBox2OriginalRect;
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        private Rectangle button3OriginalRect;
        private Rectangle button4OriginalRect;
        private Rectangle button5OriginalRect;
        private Rectangle TextBox1OriginalRect;
        private Rectangle Label1OriginalRect;
        private Rectangle GridView1OriginalRect;
        private Rectangle GridView2OriginalRect;
        private Rectangle GridView3OriginalRect;
        private Size formOriginalSize;
        public Edit_Form()
        {
            InitializeComponent();
            
                Connection_Class.DB_cn();
                Connection_Class.open();
                SqlCommand cmd = new SqlCommand("SELECT Name FROM dbo.Users", Connection_Class.cn);
                
                SqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    MyCollection.Add(reader.GetString(0));
                }
                Name.AutoCompleteCustomSource = MyCollection;
                Connection_Class.Close();
           
        }
        //SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");

        public static List<Int32> Id_soft = new List<Int32>();
        List<String> User_Data = new List<string>();//define list to collect in it user Cells from data gride view
        public static List<string> types = new List<string>();
        public static List<string> keys = new List<string>();
        public static List<string> emails = new List<string>();
        public static List<string> passwords = new List<string>();
        public static List<string> versions = new List<string>();
        public static string lap_sn;
        public static string lap_b;
        public static string lap_m;
        public static string lap_p;
        public static string lap_h;
        public static string lap_r;
        public static string lap_n;
        public static string desk_sn;
        public static string desk_b;
        public static string desk_m;
        public static string desk_p;
        public static string desk_h;
        public static string desk_r;
        public static string desk_n;
        public static string monitor_sn;
        public static string monitor_b;
        public static string monitor_m;
        public static string monitor_n;
        public static string type;
        public static string emil;
        public static string key;
        public static string password;
        public static string version;
        public string[] numb6;
        public static List<String> Soft_Lap_Type = new List<String>();
        public static List<String> Soft_Desk_Type = new List<String>();
        public static List<Int32> Id_soft_Lap = new List<Int32>();
        public static List<Int32> Id_soft_Desk = new List<Int32>();
        public static string userName;
        public string Name5;
        public int software;
        public static bool v;
        public static bool b;
        public static int Id_User;
        int f = 0;
        public static int idsoft_Old;
        public  static List<String> User_Data_Before = new List<string>();
        



        private void Edit_Form_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            pictureBox1OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            pictureBox2OriginalRect = new Rectangle(pictureBox3.Location.X, pictureBox3.Location.Y, pictureBox3.Width, pictureBox3.Height);
            button1OriginalRect = new Rectangle(SearchName.Location.X, SearchName.Location.Y, SearchName.Width, SearchName.Height);
            button2OriginalRect = new Rectangle(button2.Location.X, button2.Location.Y, button2.Width, button2.Height);
            button3OriginalRect = new Rectangle(button1.Location.X, button1.Location.Y, button1.Width, button1.Height);
            button4OriginalRect = new Rectangle(save.Location.X, save.Location.Y, save.Width, save.Height);
            button5OriginalRect = new Rectangle(button3.Location.X, button3.Location.Y, button3.Width, button3.Height);
            TextBox1OriginalRect = new Rectangle(Name.Location.X, Name.Location.Y, Name.Width, Name.Height);
            Label1OriginalRect = new Rectangle(label1.Location.X, label1.Location.Y, label1.Width, label1.Height);
            GridView1OriginalRect = new Rectangle(dataGridView3.Location.X, dataGridView3.Location.Y, dataGridView3.Width, dataGridView3.Height);
            GridView2OriginalRect = new Rectangle(dataGridView1.Location.X, dataGridView1.Location.Y, dataGridView1.Width, dataGridView1.Height);
            GridView3OriginalRect = new Rectangle(data_grid.Location.X, data_grid.Location.Y, data_grid.Width, data_grid.Height);
            // Name5 = Edit_Form.userName;
        }

        public void SearchName_Click(object sender, EventArgs e)
        {
            User_Data_Before.Clear();
            Connection_Class.DB_cn();
            Connection_Class.open();
            this.data_grid.ColumnHeadersHeight = 20;

            string name = Name.Text;
            userName = Name.Text;
            DataTable dt1 = new DataTable(); //create datatable
            SqlCommand User = new SqlCommand("Select Id_User from dbo.Users where Lower(dbo.Users.Name) = '" + name.ToLower() + "'", Connection_Class.cn);//Command Query                   

            object user_name = User.ExecuteScalar();
            if (user_name == null) //this user not found in database
            {
                dataGridView1.Visible = true;
                MessageBox.Show("This name doesn't exist"); //show massage to not found user
            }
            else //this user found in database
            {
                dataGridView1.Visible = false;
                int Id_User = Conditions_Class.Get_Id(User);//Get_Id_user 
                
                //add user Details Columns
                dt1.Columns.Add("Name");
                dt1.Columns.Add("Title");
                dt1.Columns.Add("Location");
                //add Device type column
                dt1.Columns.Add("Device");
                if (Conditions_Class.Laptop_Found(Connection_Class.cn, Id_User) != null || Conditions_Class.Desktop_Found(Connection_Class.cn, Id_User) != null)// if user own Laptop or Desktop 
                {
                    dt1.Columns.Add("Serial Number");
                    dt1.Columns.Add("Brand");
                    dt1.Columns.Add("Model");
                    dt1.Columns.Add("Processor");
                    dt1.Columns.Add(" Ram");
                    dt1.Columns.Add("Hard");
                    dt1.Columns.Add(" Note");

                    

                    dt1.Columns.Add("Monitor Serial Number");
                    dt1.Columns.Add("Monitor Brand");
                    dt1.Columns.Add("Monitor Model");
                    dt1.Columns.Add("Monitor Note");

                    //add Windows software columns
                    dt1.Columns.Add("Windows Type");
                    dt1.Columns.Add("Windows Key");
                    dt1.Columns.Add("Windows Version");
                    //add office software columns
                    dt1.Columns.Add("Office Type");
                    dt1.Columns.Add("Office Key");
                    dt1.Columns.Add("Office Email");
                    dt1.Columns.Add("Office Password");
                    dt1.Columns.Add("Office Version");

                    //add PDF software Columns
                    dt1.Columns.Add("PDF Type");
                    dt1.Columns.Add("PDF Key");
                    dt1.Columns.Add("PDF Email");
                    dt1.Columns.Add("PDF Password");
                    dt1.Columns.Add("PDF Version");

                    //add AntiVirus software columns
                    dt1.Columns.Add("AntiVirus Type");
                    dt1.Columns.Add("AntiVirus Key");
                    dt1.Columns.Add("AntiVirus Email");
                    dt1.Columns.Add("AntiVirus Password");
                    dt1.Columns.Add("AntiVirus Version");

                    //add Cad software columns
                    dt1.Columns.Add("Cad Type");
                    dt1.Columns.Add("Cad Key");
                    dt1.Columns.Add("Cad Email");
                    dt1.Columns.Add("Cad Password");
                    dt1.Columns.Add("Cad Version");

                    //add Other1 software columns
                    dt1.Columns.Add("Other1 Type");
                    dt1.Columns.Add("Other1 Key");
                    dt1.Columns.Add("Other1 Email");
                    dt1.Columns.Add("Other1 Password");
                    dt1.Columns.Add("Other1 Version");

                    //add Other2 software columns
                    dt1.Columns.Add("Other2 Type");
                    dt1.Columns.Add("Other2 Key");
                    dt1.Columns.Add("Other2 Email");
                    dt1.Columns.Add("Other2 Password");
                    dt1.Columns.Add("Other2 Version");

                    //add other3 software columns
                    dt1.Columns.Add("Other3 Type");
                    dt1.Columns.Add("Other3 Key");
                    dt1.Columns.Add("Other3 Email");
                    dt1.Columns.Add("Other3 Password");
                    dt1.Columns.Add("Other3 Version");
                    for (int j = 0; j < this.data_grid.ColumnCount; j++)
                    {
                        this.data_grid.Columns[j].Width = 50;
                    }

                    //this.data_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    //this.data_grid.ColumnHeadersHeight = this.data_grid.ColumnHeadersHeight * 2;
                    //this.data_grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                    //this.data_grid.CellPainting += new DataGridViewCellPaintingEventHandler(Search_Grid_CellPainting);
                    //this.data_grid.Paint += new PaintEventHandler(Search_Grid_Paint);
                    //this.data_grid.Scroll += new ScrollEventHandler(Search_Grid_Scroll);
                    //this.data_grid.ColumnWidthChanged += new DataGridViewColumnEventHandler(Search_Grid_ColumnWidthChanged);




                    if (Conditions_Class.Laptop_Found(Connection_Class.cn, Id_User) != null) //check if user have laptop tp add Laptop Details and its Software in it in new Row
                    {
                        b = false;
                        User_Data_Before.Clear();
                        int Others_Software = 0;
                        DataRow dr = dt1.NewRow();
                        //select User Details From database
                        SqlCommand User_Details = new SqlCommand("SELECT Name, Title, Location  from dbo.Users where dbo.Users.Id_User ='" + Id_User + "' ;", Connection_Class.cn);
                        SqlDataReader sdr2 = User_Details.ExecuteReader();
                        string[] numb2 = new string[sdr2.FieldCount];
                        while (sdr2.Read())
                        {
                            for (int l = 0; l < sdr2.FieldCount; l++)
                            {
                                numb2[l] = sdr2[l].ToString();
                            }
                        }
                        //Fill User Details
                        dr["Name"] = numb2[0];
                        dr["Title"] = numb2[1];
                        dr["Location"] = numb2[2];
                        //Fill device Type 
                        dr["Device"] = "Laptop";
                        //select Laptop Details From Database
                        SqlCommand Laptop_Details = new SqlCommand("Select  ISNULL(dbo.Laptops.Serial_Number_Lap,' ') AS Serial_Number_Lap,ISNULL(dbo.Laptops.Brand_Lap , ' ' ) AS Brand_Lap,ISNULL(dbo.Laptops.Model_Lap,' ') AS Model_Lap,ISNULL(dbo.Laptops.Processor_Lap,' ') AS Processor_Lap,ISNULL(dbo.Laptops.Ram_Lap,' ') AS Ram_Lap,ISNULL(dbo.Laptops.Hard_Lap,' ') AS Hard_Lap,ISNULL(Laptops.Note_Lap,' ') AS Note_Lap  from dbo.Laptops, dbo.Users WHERE dbo.Laptops.Id_User = '" + Id_User + "';", Connection_Class.cn);
                        SqlDataReader sdr1 = Laptop_Details.ExecuteReader();
                        string[] numb1 = new string[sdr1.FieldCount];
                        while (sdr1.Read())
                        {
                            for (int l = 0; l < sdr1.FieldCount; l++)
                            {
                                numb1[l] = sdr1[l].ToString();
                            }
                        }
                        //Fill Laptop Details In columns Belong to Device SN,Brand,model,Processor,Ram,Hard,note
                        dr["Serial Number"] = numb1[0];
                        dr["Brand"] = numb1[1];
                        dr["Model"] = numb1[2];
                        dr["Processor"] = numb1[3];
                        dr[" Ram"] = numb1[4];
                        dr["Hard"] = numb1[5];
                        dr[" Note"] = numb1[6];
                        if (Conditions_Class.Monitor_Found(Connection_Class.cn, Id_User) != null) //check if User own monitor or not 
                        {
                            //Select Monitor Details from DataBase
                            SqlCommand Monitor_Details = new SqlCommand("SELECT Serial_Number_Monitor, Brand_Monitor , Model_Monitor, Note_Monitor  from dbo.monitor where dbo.Monitor.Id_User ='" + Id_User + "' ;", Connection_Class.cn);
                            SqlDataReader sdr = Monitor_Details.ExecuteReader();
                            string[] numb = new string[sdr.FieldCount];
                            while (sdr.Read())
                            {
                                for (int l = 0; l < sdr.FieldCount; l++)
                                {
                                    numb[l] = sdr[l].ToString();
                                }
                            }
                            //Fill Monitor Details on Coulmns Belong to Monitor
                            dr["Monitor Serial Number"] = numb[0];
                            dr["Monitor Brand"] = numb[1];
                            dr["Monitor Model"] = numb[2];
                            dr["Monitor Note"] = numb[3];
                        }
                        //get all types and Ids Soft of all software 
                        SqlCommand Ids_Types = new SqlCommand("SELECT dbo.Soft_Laptop.Id_Soft, dbo.Software.type from dbo.Soft_Laptop, dbo.Laptops, dbo.Software where dbo.Laptops.Id_User ='" + Id_User + "' AND dbo.Laptops.Id_Laptop = dbo.Soft_Laptop.Id_Laptop AND dbo.Soft_Laptop.Id_Soft = dbo.Software.Id_Soft ;", Connection_Class.cn);


                        List<Int32> Id_soft_Lap = new List<Int32>(); //list contain Ids Software
                        List<String> Soft_Lap_Type = new List<String>(); //list Contain Types Software

                        SqlDataReader sdr3 = Ids_Types.ExecuteReader();
                        //fill lists of ids and types 
                        while (sdr3.Read())
                        {
                            Id_soft_Lap.Add(sdr3.GetInt32((sdr3.GetOrdinal("Id_Soft"))));
                            Soft_Lap_Type.Add(sdr3.GetString((sdr3.GetOrdinal("type"))));
                        }
                        for (int i = 0; i < Soft_Lap_Type.Count; i++)
                        {
                            //select software Details
                            SqlCommand Office_Details = new SqlCommand("SELECT type,[Key],Email,Password,Version from  dbo.Software where dbo.Software.Id_Soft ='" + Id_soft_Lap[i] + "' ;", Connection_Class.cn);
                            SqlDataReader sdr = Office_Details.ExecuteReader();
                            string[] numb = new string[sdr.FieldCount];
                            while (sdr.Read())
                            {
                                for (int l = 0; l < sdr.FieldCount; l++)
                                {
                                    numb[l] = sdr[l].ToString();
                                }
                            }
                            if (Soft_Lap_Type[i].Contains("Office")|| Soft_Lap_Type[i].Contains("office")) //if this software type is Office 
                            {
                                //fill Office Columns
                                dr["Office Type"] = numb[0];
                                dr["Office Key"] = numb[1];
                                dr["Office Email"] = numb[2];
                                dr["Office Password"] = numb[3];
                                dr["Office Version"] = numb[4];
                            }
                            else if (Soft_Lap_Type[i].Contains("foxit") || Soft_Lap_Type[i].Contains("Foxit") || Soft_Lap_Type[i].Contains("Adobe") || Soft_Lap_Type[i].Contains("adobe")) //check if this Software type is PDF
                            {
                                //fill pdf Columns
                                dr["PDF Type"] = numb[0];
                                dr["PDF Key"] = numb[1];
                                dr["PDF Email"] = numb[2];
                                dr["PDF Password"] = numb[3];
                                dr["PDF Version"] = numb[4];

                            }
                            else if (Soft_Lap_Type[i].Contains("trendmicro")|| Soft_Lap_Type[i].Contains("Trendmicro"))
                            {

                                dr["AntiVirus Type"] = numb[0];
                                dr["AntiVirus Key"] = numb[1];
                                dr["AntiVirus Email"] = numb[2];
                                dr["AntiVirus Password"] = numb[3];
                                dr["AntiVirus Version"] = numb[4];

                            }
                            else if (Soft_Lap_Type[i].Contains("dwg") || Soft_Lap_Type[i].Contains("DWG") || Soft_Lap_Type[i].Contains("autocad")|| Soft_Lap_Type[i].Contains("Autocad") || Soft_Lap_Type[i].Contains("gstar")|| Soft_Lap_Type[i].Contains("Gstar"))
                            {

                                dr["Cad Type"] = numb[0];
                                dr["Cad Key"] = numb[1];
                                dr["Cad Email"] = numb[2];
                                dr["Cad Password"] = numb[3];
                                dr["Cad Version"] = numb[4];

                            }
                            else if (Soft_Lap_Type[i].Contains("Windows")|| Soft_Lap_Type[i].Contains("windows")) //if this software type is Office 
                            {
                                dr["Windows Type"] = numb[0];
                                dr["Windows Key"] = numb[1];
                                dr["Windows Version"] = numb[4];
                            }
                            else
                            {
                                if (Others_Software < 3)
                                {
                                    Others_Software++;
                                    dr["Other" + Others_Software + " Type"] = numb[0];
                                    dr["Other" + Others_Software + " Key"] = numb[1];
                                    dr["Other" + Others_Software + " Email"] = numb[2];
                                    dr["Other" + Others_Software + " Password"] = numb[3];
                                    dr["Other" + Others_Software + " Version"] = numb[4];
                                }
                                else
                                {
                                    MessageBox.Show("the others Softwares Greater than 3");
                                }

                            }
                        }
                        dt1.Rows.Add(dr);
                        data_grid.DataSource = dt1;
                        data_grid.Scroll += new System.Windows.Forms.ScrollEventHandler(Search_Grid_Scroll);
                        dataGridView3.Width = 900;
                        data_grid.Width = 900;
                        
                        foreach (DataGridViewColumn c in data_grid.Columns)
                        {
                            c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                            c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            c.Width = 100;
                        }
                        dt1 = null;
                        for(int i=0; i<53; i++)
                        {
                           User_Data_Before.Add( data_grid.Rows[0].Cells[i].Value.ToString());
                        }

                    }
                    if (Conditions_Class.Desktop_Found(Connection_Class.cn, Id_User) != null)//check if user own Desktop
                    {
                        b = true;
                        User_Data_Before.Clear();
                        int Others_Software = 0;
                        DataRow dr = dt1.NewRow();
                        //select User Details From database
                        SqlCommand User_Details = new SqlCommand("SELECT Name, Title, Location  from dbo.Users where dbo.Users.Id_User ='" + Id_User + "' ;", Connection_Class.cn);
                        SqlDataReader sdr2 = User_Details.ExecuteReader();
                        string[] numb2 = new string[sdr2.FieldCount];
                        while (sdr2.Read())
                        {
                            for (int l = 0; l < sdr2.FieldCount; l++)
                            {
                                numb2[l] = sdr2[l].ToString();
                            }
                        }
                        //Fill User Details
                        dr["Name"] = numb2[0];
                        dr["Title"] = numb2[1];
                        dr["Location"] = numb2[2];
                        //Fill device Type 
                        dr["Device"] = "Desktop";
                        //select Desktop Details From Database
                        SqlCommand Laptop_Details = new SqlCommand("Select  dbo.Desktop.Serial_Number_Desk,dbo.Desktop.Brand_Desktop,dbo.Desktop.Model_Desktop,dbo.Desktop.Processor_Desktop,dbo.Desktop.Hard_Desktop,dbo.Desktop.Ram_Desktop,Desktop.Note_Desktop  from dbo.Desktop WHERE dbo.Desktop.Id_User = '" + Id_User + "';", Connection_Class.cn);
                        SqlDataReader sdr1 = Laptop_Details.ExecuteReader();
                        string[] numb1 = new string[sdr1.FieldCount];
                        while (sdr1.Read())
                        {
                            for (int l = 0; l < sdr1.FieldCount; l++)
                            {
                                numb1[l] = sdr1[l].ToString();
                            }
                        }
                        //Fill Desktop Details In columns Belong to Device SN,Brand,model,Processor,Ram,Hard,note
                        dr["Serial Number"] = numb1[0];
                        dr["Brand"] = numb1[1];
                        dr["Model"] = numb1[2];
                        dr["Processor"] = numb1[3];
                        dr[" Ram"] = numb1[5];
                        dr["Hard"] = numb1[4];
                        dr[" Note"] = numb1[6];
                        if (Conditions_Class.Monitor_Found(Connection_Class.cn,Id_User)!=null) //check if User own monitor or not 
                        {
                            //Select Monitor Details from DataBase
                            SqlCommand Monitor_Details = new SqlCommand("SELECT Serial_Number_Monitor, Brand_Monitor , Model_Monitor, Note_Monitor  from dbo.monitor where dbo.Monitor.Id_User ='" + Id_User + "' ;", Connection_Class.cn);
                            SqlDataReader sdr = Monitor_Details.ExecuteReader();
                            string[] numb = new string[sdr.FieldCount];
                            while (sdr.Read())
                            {
                                for (int l = 0; l < sdr.FieldCount; l++)
                                {
                                    numb[l] = sdr[l].ToString();
                                }
                            }
                            //Fill Monitor Details on Coulmns Belong to Monitor
                            dr["Monitor Serial Number"] = numb[0];
                            dr["Monitor Brand"] = numb[1];
                            dr["Monitor Model"] = numb[2];
                            dr["Monitor Note"] = numb[3];
                        }
                        //get all types and Ids Soft of all software 
                        SqlCommand Ids_Types = new SqlCommand("SELECT dbo.Soft_Desk.Id_Soft, dbo.Software.type from dbo.Soft_Desk, dbo.Desktop, dbo.Software where dbo.Desktop.Id_User ='" + Id_User + "' AND dbo.Desktop.Id_Desktop = dbo.Soft_Desk.Id_Desktop AND dbo.Soft_Desk.Id_Soft = dbo.Software.Id_Soft ;", Connection_Class.cn);


                        List<Int32> Id_soft_Lap = new List<Int32>(); //list contain Ids Software
                        List<String> Soft_Lap_Type = new List<String>(); //list Contain Types Software

                        SqlDataReader sdr3 = Ids_Types.ExecuteReader();
                        //fill lists of ids and types 
                        while (sdr3.Read())
                        {
                            Id_soft_Lap.Add(sdr3.GetInt32((sdr3.GetOrdinal("Id_Soft"))));
                            Soft_Lap_Type.Add(sdr3.GetString((sdr3.GetOrdinal("type"))));
                        }
                        for (int i = 0; i < Soft_Lap_Type.Count; i++)
                        {
                            //select software Details
                            SqlCommand Office_Details = new SqlCommand("SELECT type,[Key],Email,Password,Version from  dbo.Software where dbo.Software.Id_Soft ='" + Id_soft_Lap[i] + "' ;", Connection_Class.cn);
                            SqlDataReader sdr = Office_Details.ExecuteReader();
                            string[] numb = new string[sdr.FieldCount];
                            while (sdr.Read())
                            {
                                for (int l = 0; l < sdr.FieldCount; l++)
                                {
                                    numb[l] = sdr[l].ToString();
                                }
                            }
                            if (Soft_Lap_Type[i].Contains("Office")|| Soft_Lap_Type[i].Contains("office")) //if this software type is Office 
                            {
                                //fill Office Columns
                                dr["Office Type"] = numb[0];
                                dr["Office Key"] = numb[1];
                                dr["Office Email"] = numb[2];
                                dr["Office Password"] = numb[3];
                                dr["Office Version"] = numb[4];
                            }
                            else if (Soft_Lap_Type[i].Contains("foxit")|| Soft_Lap_Type[i].Contains("Foxit") || Soft_Lap_Type[i].Contains("adobe")|| Soft_Lap_Type[i].Contains("Adobe")) //check if this Software type is PDF
                            {
                                //fill pdf Columns
                                dr["PDF Type"] = numb[0];
                                dr["PDF Key"] = numb[1];
                                dr["PDF Email"] = numb[2];
                                dr["PDF Password"] = numb[3];
                                dr["PDF Version"] = numb[4];

                            }
                            else if (Soft_Lap_Type[i].Contains("trendmicro")|| Soft_Lap_Type[i].Contains("Trendmicro"))
                            {

                                dr["AntiVirus Type"] = numb[0];
                                dr["AntiVirus Key"] = numb[1];
                                dr["AntiVirus Email"] = numb[2];
                                dr["AntiVirus Password"] = numb[3];
                                dr["AntiVirus Version"] = numb[4];

                            }
                            else if (Soft_Lap_Type[i].Contains("dwg") || Soft_Lap_Type[i].Contains("DWG")||Soft_Lap_Type[i].Contains("autocad")|| Soft_Lap_Type[i].Contains("Autocad") || Soft_Lap_Type[i].Contains("gstar")|| Soft_Lap_Type[i].Contains("Gstar"))
                            {

                                dr["Cad Type"] = numb[0];
                                dr["Cad Key"] = numb[1];
                                dr["Cad Email"] = numb[2];
                                dr["Cad Password"] = numb[3];
                                dr["Cad Version"] = numb[4];

                            }
                            else if (Soft_Lap_Type[i].Contains("Windows")|| Soft_Lap_Type[i].Contains("windows")) //if this software type is Office 
                            {
                                dr["Windows Type"] = numb[0];
                                dr["Windows Key"]=numb[1];
                                dr["Windows Version"]=numb[4];
                            }
                            else
                            {
                                if (Others_Software < 3)
                                {
                                    Others_Software++;
                                    dr["Other" + Others_Software + " Type"] = numb[0];
                                    dr["Other" + Others_Software + " Key"] = numb[1];
                                    dr["Other" + Others_Software + " Email"] = numb[2];
                                    dr["Other" + Others_Software + " Password"] = numb[3];
                                    dr["Other" + Others_Software + " Version"] = numb[4];
                                }
                                else
                                {
                                    MessageBox.Show("the others Softwares Greater than 3");
                                }

                            }

                        }
                        dt1.Rows.Add(dr);
                        data_grid.DataSource = dt1;
                        data_grid.Scroll += new System.Windows.Forms.ScrollEventHandler(Search_Grid_Scroll);
                        dataGridView3.Width = 900;
                        data_grid.Width = 900;
                        //data_grid.Columns[0].Width = 30;
                        //dataGridView3.Columns[0].Width = 30;
                        //data_grid.Columns[0].Width = 30;
                        foreach (DataGridViewColumn c in data_grid.Columns)
                        {
                            c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                            c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            c.Width = 100;
                        }
                        dt1 = null;
                        for (int i = 0; i < 53; i++)
                        {
                            User_Data_Before.Add(data_grid.Rows[0].Cells[i].Value.ToString());
                        }
                        dt1 = null;
                        for (int i = 0; i < 53; i++)
                        {
                            User_Data_Before.Add(data_grid.Rows[0].Cells[i].Value.ToString());
                        }
                        
                    }

                }
                else
                {
                    dataGridView1.Visible = true;
                    MessageBox.Show("This user don't own any device");
                }
            
            }
            dt1 = null;
            Connection_Class.Close();
        }


        private void Search_Grid_Scroll(object sender, ScrollEventArgs e)
        {
            dataGridView3.FirstDisplayedScrollingColumnIndex = data_grid.FirstDisplayedScrollingColumnIndex;
        }
        private void resizeChildControls()
        {
            resizeControl(pictureBox1OriginalRect, pictureBox1);
            resizeControl(pictureBox2OriginalRect, pictureBox3);
            resizeControl(button1OriginalRect, SearchName);
            resizeControl(button2OriginalRect, button2);
            resizeControl(button3OriginalRect, button1);
            resizeControl(button4OriginalRect, save);
            resizeControl(button5OriginalRect, button3);
            resizeControl(TextBox1OriginalRect, Name);
            resizeControl(Label1OriginalRect, label1);
            resizeControl(GridView1OriginalRect, dataGridView3);
            resizeControl(GridView2OriginalRect, dataGridView1);
            resizeControl(GridView3OriginalRect, data_grid);
            //resizeControl(formOriginalSize, spare_software);


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
        private void Search_Grid_Paint(object sender, PaintEventArgs e)
        {
            //int[] Counter_Cells = { 3,0,0, 8,0,0,0,0,0,0, 4,0,0,0, 3,0,0, 5,0,0,0,0, 5,0,0,0,0, 5,0,0,0,0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5 ,0, 0, 0, 0};
            string[] monthes = { "User", "", "", "Device", "", "", "", "", "", "", "", "Monitor", "", "", "", "Windows", "", "", "Office", "", "", "", "", "PDF", "", "", "", "", "AntiVirus", "", "", "", "", "Cad & Gstar", "", "", "", "", "Others", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            for (int j = 0; j < 53;)
            {

                Rectangle r1 = this.data_grid.GetCellDisplayRectangle(j, -1, true);
                int w2 = 30;

                r1.X += 1;
                r1.Y += 1;
                r1.Width = r1.Width + w2 - 2;
                r1.Height = r1.Height / 2 - 2;
                e.Graphics.FillRectangle(new SolidBrush(this.data_grid.ColumnHeadersDefaultCellStyle.BackColor), r1);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(monthes[j],
                this.data_grid.ColumnHeadersDefaultCellStyle.Font= new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel),
                new SolidBrush(this.data_grid.ColumnHeadersDefaultCellStyle.ForeColor),
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

            Rectangle rtHeader = this.data_grid.DisplayRectangle;
            rtHeader.Height = this.data_grid.ColumnHeadersHeight / 2;
            this.data_grid.Invalidate(rtHeader);

        }

        private void save_Click(object sender, EventArgs e)
        {

            //string name = data_grid.SelectedRows[0].Cells[0].Value.ToString();

            userName = Name.Text;
            Connection_Class.DB_cn();
            Connection_Class.open();
            
            SqlCommand User = new SqlCommand("Select Id_User from dbo.Users where Lower(dbo.Users.Name) = '" + userName.ToLower() + "'", Connection_Class.cn);//Command Query                    

            Object Id = User.ExecuteScalar();//convert result of id command to object to sure find Users own this Software
                                             //this mean Not found this key in database
            if (Id == null)
            {

                MessageBox.Show("This Name not found");

            }

            else if (data_grid.Rows.Count > 0)
            {
                int Id_User = Conditions_Class.Get_Id(User);//Get_Id
                

                for (int i = 0; i < 53; i++)
                {
                    User_Data.Add(data_grid.Rows[0].Cells[i].Value.ToString());
                }
                //Update Users Table in dataBase with cells in data gride view
                SqlCommand Update_User = new SqlCommand("UPDATE dbo.Users SET dbo.Users.Name='" + User_Data[0] + "',dbo.Users.Title='" + User_Data[1] + "',dbo.Users.Location='" + User_Data[2] + "' WHERE dbo.Users.Id_User='" + Id_User + "';", Connection_Class.cn);
                Update_User.ExecuteNonQuery();
                ///////////////////////////////1-change laptop with laptop////////////////////////////////////
                if (User_Data[3] == "Laptop"&& User_Data[3] == User_Data_Before[3])//if User Own Laptop Device
                {
                    ////1-Add new laptop to the old user
                    //if (User_Data_Before[4] == null && User_Data[4] != null && User_Data_Before[5] == null && User_Data[5] != null && User_Data_Before[6] == null && User_Data[6] != null && User_Data_Before[7] == null && User_Data[7] != null && User_Data_Before[8] == null && User_Data[8] != null && User_Data_Before[9] == null && User_Data[9] != null && User_Data_Before[10] == null && User_Data[10] != null)
                    //{
                    //    b = true;
                    //    Console.WriteLine("new lap");
                    //    SqlCommand Add_Lap = new SqlCommand("INSERT INTO  dbo.Laptops VALUES('" + User_Data[4] + "','" + User_Data[5] + "' ,'" + User_Data[6] + "','" + User_Data[7] + "','" + User_Data[8] + "','" + User_Data[9] + "','" + User_Data[10] + "' ,'" + Id_User + "');", Connection_Class.cn);
                    //    Add_Lap.ExecuteNonQuery();
                    //    MessageBox.Show("Data Updated Successfully");
                    //    Add_Software_Options_Old_User add = new Add_Software_Options_Old_User();
                    //    add.Show();
                    //    this.Hide();
                    //}
                    //2-User has a laptop and i will give him new laptop writting it by my hand
                    if (User_Data_Before[4].ToString() != "" && User_Data[4].ToString() != "" && User_Data_Before[4] != User_Data[4])
                    {
                        b = false;
                        Console.WriteLine("replace laptop");
                        SqlCommand ID_Lap = new SqlCommand("select Id_Laptop from Laptops where Laptops.Id_User='" + Id_User + "'", Connection_Class.cn);
                        int id_lap = Conditions_Class.Get_Id(ID_Lap);
                        SqlCommand ID_Soft_Lap = new SqlCommand("select Id_Soft from Soft_Laptop where Soft_Laptop.Id_Laptop='" + id_lap + "'", Connection_Class.cn);
                        SqlDataReader sdr3 = ID_Soft_Lap.ExecuteReader();
                        List<int> Ids_Soft = new List<int>();
                        //fill lists of ids and types 
                        while (sdr3.Read())
                        {
                            Ids_Soft.Add(sdr3.GetInt32((sdr3.GetOrdinal("Id_Soft"))));

                        }
                        for (int i = 0; i < Ids_Soft.Count; i++)
                        {
                            SqlCommand spare_Soft = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Email,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note) Select dbo.Software.type,dbo.Software.Email,dbo.Software.Password,dbo.Software.[Key],dbo.Software.Version,'old '+'" + User_Data_Before[0] + "' from dbo.Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                            spare_Soft.ExecuteNonQuery();
                            SqlCommand Delete_Lap_Soft = new SqlCommand("DELETE FROM Soft_Laptop WHERE dbo.Soft_Laptop.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                            Delete_Lap_Soft.ExecuteNonQuery();

                            SqlCommand Delete_User_Soft = new SqlCommand("DELETE FROM User_Soft WHERE dbo.User_Soft.Id_Soft = '" + Ids_Soft[i] + "' AND dbo.User_Soft.Id_User='" + Id_User + "'", Connection_Class.cn);
                            Delete_User_Soft.ExecuteNonQuery();
                            SqlCommand Ids_Own_Soft = new SqlCommand("select Id_Soft from User_Soft", Connection_Class.cn);
                            SqlDataReader sdr4 = Ids_Own_Soft.ExecuteReader();
                            List<int> Ids_Soft_also = new List<int>();
                            //fill lists of ids and types 
                            while (sdr4.Read())
                            {
                                Ids_Soft_also.Add(sdr4.GetInt32((sdr4.GetOrdinal("Id_Soft"))));

                            }
                            if (!Ids_Soft_also.Contains(Ids_Soft[i]))
                            {
                                SqlCommand Delete_Soft = new SqlCommand("DELETE FROM Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                                Delete_Soft.ExecuteNonQuery();
                            }



                        }
                        SqlCommand Add_Lap_Spare = new SqlCommand("INSERT INTO  dbo.Spare(dbo.Spare.Type,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Serial_Number,dbo.Spare.Processor,dbo.Spare.Hard,dbo.Spare.Ram,dbo.Spare.Note ) VALUES('Laptop','" + User_Data_Before[5] + "' ,'" + User_Data_Before[6] + "','" + User_Data_Before[4] + "','" + User_Data_Before[7] + "','" + User_Data_Before[9] + "','" + User_Data_Before[8] + "','" + User_Data_Before[10] + "'+' '+' Old '+ '  ' + '" + User_Data_Before[0] + "');", Connection_Class.cn);
                        Add_Lap_Spare.ExecuteNonQuery();
                        SqlCommand Update_Lap = new SqlCommand("UPDATE dbo.Laptops set Laptops.Serial_Number_Lap='" + User_Data[4] + "', Laptops.Brand_Lap='" + User_Data[5] + "' , Laptops.Model_Lap='" + User_Data[6] + "',Laptops.Processor_Lap='" + User_Data[7] + "',Laptops.Hard_Lap='" + User_Data[9] + "',Laptops.Ram_Lap='" + User_Data[8] + "',Laptops.Note_Lap='" + User_Data[10] + "' WHERE Laptops.Id_User='" + Id_User + "';", Connection_Class.cn);
                        Update_Lap.ExecuteNonQuery();
                        Add_Software_Options_Old_User soft_old = new Add_Software_Options_Old_User();
                        soft_old.Show();
                        this.Hide();
                        MessageBox.Show("Data Updated Successfully");
                        //SearchName_Click(sender, e);
                        Connection_Class.open();
                    }
                    //3-edit laptop in hard or ram
                    if ((User_Data_Before[4] == User_Data[4] && User_Data_Before[5] == User_Data[5] && User_Data_Before[6] == User_Data[6] && User_Data_Before[7] == User_Data[7]) && ((User_Data_Before[9] == User_Data[9] && User_Data_Before[8] != User_Data[8]) || (User_Data_Before[9] != User_Data[9] && User_Data_Before[8] == User_Data[8]) || (User_Data_Before[10] != User_Data[10]) || (User_Data_Before[9] != User_Data[9] && User_Data_Before[8] != User_Data[8])))
                    {
                        Console.WriteLine("upgrade ram and hard");
                        SqlCommand cmd3 = new SqlCommand("UPDATE dbo.Laptops SET dbo.Laptops.Serial_Number_Lap='" + User_Data[4] + "',dbo.Laptops.Brand_Lap='" + User_Data[5] + "' , dbo.Laptops.Model_Lap='" + User_Data[6] + "',dbo.Laptops.Processor_Lap='" + User_Data[7] + "',dbo.Laptops.Hard_Lap='" + User_Data[9] + "',dbo.Laptops.Ram_Lap='" + User_Data[8] + "',Laptops.Note_Lap='" + User_Data[10] + "' WHERE dbo.Laptops.Id_User='" + Id_User + "';", Connection_Class.cn);
                        cmd3.ExecuteNonQuery();
                        MessageBox.Show("Data Updated Successfully");
                        SearchName_Click(sender, e);

                    }



                }
                ///////////////////////2-change desktop with new desktop///////////////////////////////////////
                else if (User_Data[3] == "Desktop" && User_Data[3] == User_Data_Before[3])//if this user own Desktop
                {
                    //1-User has a desktop and i will give it new laptop  writting it by my hand
                    if (User_Data_Before[4].ToString() != "" && User_Data[4].ToString() != "" && User_Data_Before[4] != User_Data[4])
                    {
                        b = true;
                        Console.WriteLine("replace desktop");
                        SqlCommand Add_Desk_Spare = new SqlCommand("INSERT INTO  dbo.Spare(dbo.Spare.Type,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Serial_Number,dbo.Spare.Processor,dbo.Spare.Hard,dbo.Spare.Ram,dbo.Spare.Note ) VALUES('Desktop','" + User_Data_Before[5] + "' ,'" + User_Data_Before[6] + "','" + User_Data_Before[4] + "','" + User_Data_Before[7] + "','" + User_Data_Before[9] + "','" + User_Data_Before[8] + "','" + User_Data_Before[10] + "'+' '+' Old '+ '  ' + '" + User_Data_Before[0] + "');", Connection_Class.cn);
                        Add_Desk_Spare.ExecuteNonQuery();
                        SqlCommand Desktop = new SqlCommand("Select Id_Desktop from dbo.Desktop where dbo.Desktop.Id_User = '" + Id_User + "'", Connection_Class.cn);//Command Query                   
                        int Id_Desk = Conditions_Class.Get_Id(Desktop);//Get_Id_Desktop
                                                                       //Insert Desktop to spare
                        
                        SqlCommand ID_Soft_Lap = new SqlCommand("select Id_Soft from Soft_Desk where Soft_Desk.Id_Desktop='" + Id_Desk + "'", Connection_Class.cn);
                        SqlDataReader sdr3 = ID_Soft_Lap.ExecuteReader();
                        List<int> Ids_Soft = new List<int>();
                        //fill lists of ids and types 
                        while (sdr3.Read())
                        {
                            Ids_Soft.Add(sdr3.GetInt32((sdr3.GetOrdinal("Id_Soft"))));

                        }
                        for (int i = 0; i < Ids_Soft.Count; i++)
                        {
                            SqlCommand spare_Soft = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Email,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note) Select dbo.Software.type,dbo.Software.Email,dbo.Software.Password,dbo.Software.[Key],dbo.Software.Version,'old '+'" + User_Data_Before[0] + "' from dbo.Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                            spare_Soft.ExecuteNonQuery();
                            SqlCommand Delete_Desk_Soft = new SqlCommand("DELETE FROM Soft_Desk WHERE dbo.Soft_Desk.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                            Delete_Desk_Soft.ExecuteNonQuery();

                            SqlCommand Delete_User_Soft = new SqlCommand("DELETE FROM User_Soft WHERE dbo.User_Soft.Id_Soft = '" + Ids_Soft[i] + "'AND dbo.User_Soft.Id_User='" + Id_User + "'", Connection_Class.cn);
                            Delete_User_Soft.ExecuteNonQuery();
                            SqlCommand Ids_Own_Soft = new SqlCommand("select Id_Soft from User_Soft", Connection_Class.cn);
                            SqlDataReader sdr4 = Ids_Own_Soft.ExecuteReader();
                            List<int> Ids_Soft_also = new List<int>();
                            //fill lists of ids and types 
                            while (sdr4.Read())
                            {
                                Ids_Soft_also.Add(sdr4.GetInt32((sdr4.GetOrdinal("Id_Soft"))));

                            }
                            if (!Ids_Soft_also.Contains(Ids_Soft[i]))
                            {
                                SqlCommand Delete_Soft = new SqlCommand("DELETE FROM Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                                Delete_Soft.ExecuteNonQuery();
                            }



                        }
                        SqlCommand Update_Desk = new SqlCommand("UPDATE dbo.Desktop set Desktop.Serial_Number_Desk='" + User_Data[4] + "', Desktop.Brand_Desktop='" + User_Data[5] + "' , Desktop.Model_Desktop='" + User_Data[6] + "',Desktop.Processor_Desktop='" + User_Data[7] + "',Desktop.Hard_Desktop='" + User_Data[9] + "',Desktop.Ram_Desktop='" + User_Data[8] + "',Desktop.Note_Desktop='" + User_Data[10] + "' WHERE Desktop.Id_User='" + Id_User + "';", Connection_Class.cn);
                        Update_Desk.ExecuteNonQuery();
                        Add_Software_Options_Old_User soft_old=new Add_Software_Options_Old_User();
                        soft_old.Show();
                        this.Hide();
                        MessageBox.Show("Data Updated Successfully");
                        //SearchName_Click(sender, e);
                        Connection_Class.open();
                    }
                    ////2-Add new desktop to the old user
                    

                    //3-edit in hard or ram
                    if ((User_Data_Before[4] == User_Data[4] && User_Data_Before[5] == User_Data[5] && User_Data_Before[6] == User_Data[6] && User_Data_Before[7] == User_Data[7]) && ((User_Data_Before[9] == User_Data[9] && User_Data_Before[8] != User_Data[8]) || (User_Data_Before[9] != User_Data[9] && User_Data_Before[8] == User_Data[8]) || (User_Data_Before[10] != User_Data[10]) || (User_Data_Before[9] != User_Data[9] && User_Data_Before[8] != User_Data[8])))
                    {
                        Console.WriteLine("upgrade ram and hard desktop");
                        SqlCommand Update_Desk = new SqlCommand("UPDATE dbo.Desktop SET dbo.Desktop.Hard_Desktop='" + User_Data[9] + "',dbo.Desktop.Ram_Desktop='" + User_Data[8] + "',dbo.Desktop.Note_Desktop='" + User_Data[10] + "' WHERE dbo.Desktop.Id_User='" + Id_User + "';", Connection_Class.cn);
                        Update_Desk.ExecuteNonQuery();
                        MessageBox.Show("Data Updated Successfully");
                        SearchName_Click(sender, e);


                    }
                }
                
                if(User_Data[3] != User_Data_Before[3])
                {///////////////////////////////////////3-change laptop with desktop/////////////////////////////////////
                    if (User_Data_Before[3] == "Laptop")
                    {
                        b = true;
                        SqlCommand ID_Lap = new SqlCommand("select Id_Laptop from Laptops where Laptops.Id_User='" + Id_User + "'", Connection_Class.cn);
                        int id_lap = Conditions_Class.Get_Id(ID_Lap);
                        SqlCommand Add_Lap_Spare = new SqlCommand("INSERT INTO  dbo.Spare(dbo.Spare.Type,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Serial_Number,dbo.Spare.Processor,dbo.Spare.Hard,dbo.Spare.Ram,dbo.Spare.Note ) VALUES('Laptop','" + User_Data_Before[5] + "' ,'" + User_Data_Before[6] + "','" + User_Data_Before[4] + "','" + User_Data_Before[7] + "','" + User_Data_Before[9] + "','" + User_Data_Before[8] + "','" + User_Data_Before[10] + "'+' '+' Old '+ '  ' + '" + User_Data_Before[0] + "');", Connection_Class.cn);
                        Add_Lap_Spare.ExecuteNonQuery();
                        SqlCommand ID_Soft_Lap = new SqlCommand("select Id_Soft from Soft_Laptop where Soft_Laptop.Id_Laptop='" + id_lap + "'", Connection_Class.cn);
                        SqlDataReader sdr3 = ID_Soft_Lap.ExecuteReader();
                        List<int> Ids_Soft = new List<int>();
                        //fill lists of ids and types 
                        while (sdr3.Read())
                        {
                            Ids_Soft.Add(sdr3.GetInt32((sdr3.GetOrdinal("Id_Soft"))));

                        }
                        for(int i=0; i < Ids_Soft.Count; i++)
                        {
                            SqlCommand spare_Soft = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Email,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note) Select dbo.Software.type,dbo.Software.Email,dbo.Software.Password,dbo.Software.[Key],dbo.Software.Version,'old '+'" + User_Data_Before[0] + "' from dbo.Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                            spare_Soft.ExecuteNonQuery();
                            SqlCommand Delete_Lap_Soft = new SqlCommand("DELETE FROM Soft_Laptop WHERE dbo.Soft_Laptop.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                            Delete_Lap_Soft.ExecuteNonQuery();

                            SqlCommand Delete_User_Soft = new SqlCommand("DELETE FROM User_Soft WHERE dbo.User_Soft.Id_Soft = '" + Ids_Soft[i] + "' AND dbo.User_Soft.Id_User='" + Id_User + "' ", Connection_Class.cn);
                            Delete_User_Soft.ExecuteNonQuery();
                            SqlCommand Ids_Own_Soft = new SqlCommand("select Id_Soft from User_Soft", Connection_Class.cn);
                            SqlDataReader sdr4 = Ids_Own_Soft.ExecuteReader();
                            List<int> Ids_Soft_also = new List<int>();
                            //fill lists of ids and types 
                            while (sdr4.Read())
                            {
                                Ids_Soft_also.Add(sdr4.GetInt32((sdr4.GetOrdinal("Id_Soft"))));
                                Console.WriteLine(sdr4.GetInt32((sdr4.GetOrdinal("Id_Soft"))));
                            }
                            
                            if (Ids_Soft_also.Contains(Ids_Soft[i])!=true)
                            {
                                SqlCommand Delete_Soft = new SqlCommand("DELETE FROM Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                                Delete_Soft.ExecuteNonQuery();
                            }
                            


                        }
                        SqlCommand Delete_Laptop = new SqlCommand("DELETE FROM Laptops WHERE dbo.Laptops.Id_Laptop = '" + id_lap + "'", Connection_Class.cn);
                        Delete_Laptop.ExecuteNonQuery();
                        SqlCommand Add_Desktop = new SqlCommand("INSERT INTO  dbo.Desktop VALUES('" + User_Data[4] + "','" + User_Data[5] + "' ,'" + User_Data[6] + "','" + User_Data[7] + "','" + User_Data[8] + "','" + User_Data[9] + "','" + User_Data[10] + "','" + Id_User + "');", Connection_Class.cn);
                        Add_Desktop.ExecuteNonQuery();
                        Add_Software_Options_Old_User soft_old = new Add_Software_Options_Old_User();
                        soft_old.Show();
                        this.Hide();
                        MessageBox.Show("Data Updated Successfully");
                        //SearchName_Click(sender, e);
                    }
                    /////////////////////////4-change desktop with laptop///////////////////////////
                    if (User_Data_Before[3] == "Desktop")
                    {

                        b = false;
                        SqlCommand Desktop = new SqlCommand("Select Id_Desktop from dbo.Desktop where dbo.Desktop.Id_User = '" + Id_User + "'", Connection_Class.cn);//Command Query                   
                        int Id_Desk = Conditions_Class.Get_Id(Desktop);//Get_Id_Desktop
                                                                       //Insert Desktop to spare
                        SqlCommand spare_Desktop = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Serial_Number,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Processor,dbo.Spare.Ram,dbo.Spare.Hard,dbo.Spare.Note) Select 'Desktop', dbo.Desktop.Serial_Number_Desk,dbo.Desktop.Brand_Desktop,dbo.Desktop.Model_Desktop,dbo.Desktop.Processor_Desktop,dbo.Desktop.Ram_Desktop,dbo.Desktop.Hard_Desktop,dbo.Desktop.Note_Desktop+' old '+'" +User_Data_Before[0] + "' from dbo.Desktop WHERE dbo.Desktop.Id_Desktop = '" + Id_Desk + "'", Connection_Class.cn);
                        spare_Desktop.ExecuteNonQuery();
                        SqlCommand ID_Soft_Lap = new SqlCommand("select Id_Soft from Soft_Desk where Soft_Desk.Id_Desktop='" + Id_Desk + "'", Connection_Class.cn);
                        SqlDataReader sdr3 = ID_Soft_Lap.ExecuteReader();
                        List<int> Ids_Soft = new List<int>();
                        //fill lists of ids and types 
                        while (sdr3.Read())
                        {
                            Ids_Soft.Add(sdr3.GetInt32((sdr3.GetOrdinal("Id_Soft"))));

                        }
                        for (int i = 0; i < Ids_Soft.Count; i++)
                        {
                            SqlCommand spare_Soft = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Email,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note) Select dbo.Software.type,dbo.Software.Email,dbo.Software.Password,dbo.Software.[Key],dbo.Software.Version,'old '+'" + User_Data_Before[0] + "' from dbo.Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                            spare_Soft.ExecuteNonQuery();
                            SqlCommand Delete_Desk_Soft = new SqlCommand("DELETE FROM Soft_Desk WHERE dbo.Soft_Desk.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                            Delete_Desk_Soft.ExecuteNonQuery();

                            SqlCommand Delete_User_Soft = new SqlCommand("DELETE FROM User_Soft WHERE dbo.User_Soft.Id_Soft = '" + Ids_Soft[i] + "'AND dbo.User_Soft.Id_User='" + Id_User + "'", Connection_Class.cn);
                            Delete_User_Soft.ExecuteNonQuery();
                            SqlCommand Ids_Own_Soft = new SqlCommand("select Id_Soft from User_Soft", Connection_Class.cn);
                            SqlDataReader sdr4 = Ids_Own_Soft.ExecuteReader();
                            List<int> Ids_Soft_also = new List<int>();
                            //fill lists of ids and types 
                            while (sdr4.Read())
                            {
                                Ids_Soft_also.Add(sdr4.GetInt32((sdr4.GetOrdinal("Id_Soft"))));

                            }
                            if (!Ids_Soft_also.Contains(Ids_Soft[i]))
                            {
                                SqlCommand Delete_Soft = new SqlCommand("DELETE FROM Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                                Delete_Soft.ExecuteNonQuery();
                            }



                        }
                        SqlCommand Delete_Desk = new SqlCommand("DELETE FROM Desktop WHERE dbo.Desktop.Id_Desktop = '" + Id_Desk + "'", Connection_Class.cn);
                        Delete_Desk.ExecuteNonQuery();
                        SqlCommand spare_Monitor = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Serial_Number,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Note) Select 'Monitor', dbo.Monitor.Serial_Number_Monitor,dbo.Monitor.Brand_Monitor,dbo.Monitor.Model_Monitor,dbo.Monitor.Note_Monitor+' old '+'" + User_Data_Before[0] + "' from dbo.Monitor WHERE dbo.Monitor.Id_User = '" + Id_User + "'", Connection_Class.cn);
                        spare_Monitor.ExecuteNonQuery();
                        SqlCommand Delete_Monitor = new SqlCommand("DELETE FROM Monitor WHERE dbo.Monitor.Id_User = '" + Id_User + "'", Connection_Class.cn);
                        Delete_Monitor.ExecuteNonQuery();
                        SqlCommand Add_Laptop = new SqlCommand("INSERT INTO dbo.Laptops VALUES('" + User_Data[4] + "','" + User_Data[5] + "' ,'" + User_Data[6] + "','" + User_Data[7] + "','" + User_Data[8] + "','" + User_Data[9] + "','" + User_Data[10] + "','" + Id_User + "');", Connection_Class.cn);
                        Add_Laptop.ExecuteNonQuery();
                        Add_Software_Options_Old_User soft_old = new Add_Software_Options_Old_User();
                        soft_old.Show();
                        this.Hide();
                        MessageBox.Show("Data Updated Successfully");
                        //SearchName_Click(sender, e);

                    }

                }
                //Edit in Monitor 
                if (User_Data_Before[11].ToString() != "" && User_Data_Before[11] != User_Data[11] && User_Data[11].ToString() != "" )
                {
                    Console.WriteLine("replace Monitor");
                    SqlCommand Add_Monitor_Spare = new SqlCommand("INSERT INTO  dbo.Spare (dbo.Spare.Type,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Serial_Number,dbo.Spare.Note )VALUES('Monitor','" + User_Data_Before[12] + "','" + User_Data_Before[13] + "' ,'" + User_Data_Before[11] + "','" + User_Data_Before[14] + "' +' '+' Old '+ '  ' + '" + User_Data_Before[0] + "');", Connection_Class.cn);
                    Add_Monitor_Spare.ExecuteNonQuery();
                    SqlCommand Update_moitor = new SqlCommand("UPDATE dbo.Monitor SET dbo.Monitor.Serial_Number_Monitor='" + User_Data[11] + "',dbo.Monitor.Brand_Monitor='" + User_Data[12] + "' , dbo.Monitor.Model_Monitor='" + User_Data[13] + "',Monitor.Note_Monitor='" + User_Data[14] + "' WHERE dbo.Monitor.Id_User='" + Id_User + "';", Connection_Class.cn);
                    Update_moitor.ExecuteNonQuery();
                    MessageBox.Show("Data Updated Successfully");
                    SearchName_Click(sender, e);

                }
                //2-Add new monitor to the old user NULL
                if (User_Data_Before[11].ToString() == ""&& User_Data[11].ToString() != "" && User_Data_Before[12].ToString() == "" && User_Data[12] .ToString() != "" && User_Data_Before[13].ToString() == "" && User_Data[13].ToString() != "")
                {
                    Console.WriteLine("new Monitor");
                    SqlCommand Add_Monitor = new SqlCommand("INSERT INTO  dbo.Monitor VALUES('" + User_Data[11] + "','" + User_Data[12] + "' ,'" + User_Data[13] + "','" + User_Data[14] + "','" + Id_User + "');", Connection_Class.cn);
                    Add_Monitor.ExecuteNonQuery();
                    MessageBox.Show("Data Updated Successfully");
                    SearchName_Click(sender, e);

                }
                //change version pdf
                if ((User_Data_Before[23] == "Foxit"|| User_Data_Before[23] == "foxit") && (User_Data[23] == "foxit"|| User_Data[23] == "Foxit") && User_Data_Before[24] == User_Data_Before[24] && User_Data_Before[27] != User_Data[27])
                {
                    Console.WriteLine("upgrade version foxit");
                    //get software id 
                    SqlCommand Old_Soft = new SqlCommand("select Id_Soft from dbo.Software where Email = '" + User_Data_Before[25] + "' AND  Password = '" + User_Data_Before[26] + "' AND  [Key] = '" + User_Data_Before[24] + "' AND  type = '" + User_Data_Before[23] + "' AND  Version = '" + User_Data_Before[27] + "'", Connection_Class.cn);
                    int idsoft_Old = Conditions_Class.Get_Id(Old_Soft);
                    SqlCommand ID_Soft = new SqlCommand("select Id_Soft from User_Soft where User_Soft.Id_Soft='" + idsoft_Old + "' AND User_Soft.Id_User != '" + Id_User + "'", Connection_Class.cn);
                    Object Soft_f = ID_Soft.ExecuteScalar();
                    if(Soft_f != null)
                    {
                        //inseert new row in software 
                        SqlCommand Insert_Pdf = new SqlCommand("INSERT INTO dbo.Software VALUES('" + User_Data[25] + "','" + User_Data[26] + "','" + User_Data[24] + "','" + User_Data[23] + "','" + User_Data[27] + "') ", Connection_Class.cn);
                        Insert_Pdf.ExecuteNonQuery();
                        SqlCommand Max_Soft = new SqlCommand("select max(Id_Soft) from dbo.Software", Connection_Class.cn);
                        int idsoft_new = Conditions_Class.Get_Id(Max_Soft);

                        SqlCommand Update_User_Soft = new SqlCommand(" UPDATE dbo.User_Soft SET dbo.User_Soft.Id_Soft='" + idsoft_new + "' WHERE  dbo.User_Soft.Id_User = '" + Id_User + "' AND  dbo.User_Soft.Id_Soft = '" + idsoft_Old + "' ", Connection_Class.cn);
                        Update_User_Soft.ExecuteNonQuery();
                        //check if software on laptop or desktop
                        if (User_Data_Before[3] == "Desktop")
                        {
                            SqlCommand ID_Desk = new SqlCommand("select Id_Desktop from Desktop where Desktop.Id_User='" + Id_User + "'", Connection_Class.cn);
                            int id_desk = Conditions_Class.Get_Id(ID_Desk);

                            SqlCommand Update_Soft_Desk = new SqlCommand(" UPDATE dbo.Soft_Desk SET dbo.Soft_Desk.Id_Soft='" + idsoft_new + "' WHERE  dbo.Soft_Desk.Id_Desktop = '" + id_desk + "' AND  dbo.Soft_Desk.Id_Soft = '" + idsoft_Old + "' ", Connection_Class.cn);
                            Update_Soft_Desk.ExecuteNonQuery();
                        }
                        else
                        {
                            SqlCommand ID_Lap = new SqlCommand("select Id_Laptop from Laptops where Laptops.Id_User='" + Id_User + "'", Connection_Class.cn);
                            int id_lap = Conditions_Class.Get_Id(ID_Lap);
                            SqlCommand Update_SoftLap = new SqlCommand(" UPDATE dbo.Soft_Laptop SET dbo.Soft_Laptop.Id_Soft='" + idsoft_new + "' WHERE  dbo.Soft_Laptop.Id_Laptop = '" + id_lap + "' AND  dbo.Soft_Laptop.Id_Soft = '" + idsoft_Old + "' ", Connection_Class.cn);
                            Update_SoftLap.ExecuteNonQuery();
                        }
                        MessageBox.Show("Data Updated Successfully");
                        
                    }

                    else
                    {
                        SqlCommand Update_User_Soft = new SqlCommand(" UPDATE dbo.Software SET dbo.Software.Version='" + User_Data[27] + "' WHERE dbo.Software.Id_Soft = '" + idsoft_Old + "' ", Connection_Class.cn);
                        Update_User_Soft.ExecuteNonQuery();
                        MessageBox.Show("Data Updated Successfully");
                    }
                    SearchName_Click(sender, e);
                }
                //change version gstar
                if ((User_Data_Before[33] == "gstar"|| User_Data_Before[33] == "Gstar") && (User_Data[33] == "gstar" || User_Data[33] == "Gstar") && User_Data_Before[34] == User_Data_Before[34] && User_Data_Before[37] != User_Data[37])
                {
                    Console.WriteLine("upgrade version gstar");

                    //get software id 
                    SqlCommand Old_Soft = new SqlCommand("select Id_Soft from dbo.Software where Email = '" + User_Data_Before[35] + "' AND  Password = '" + User_Data_Before[36] + "' AND  [Key] = '" + User_Data_Before[34] + "' AND  type = '" + User_Data_Before[33] + "' AND  Version = '" + User_Data_Before[37] + "'", Connection_Class.cn);
                    int idsoft_Old = Conditions_Class.Get_Id(Old_Soft);
                    SqlCommand ID_Soft = new SqlCommand("select Id_Soft from User_Soft where User_Soft.Id_Soft='" + idsoft_Old + "' AND User_Soft.Id_User != '" + Id_User + "'", Connection_Class.cn);
                    Object Soft_f = ID_Soft.ExecuteScalar();
                    if (Soft_f != null)

                    {
                        //insert new row in software 
                        SqlCommand Insert_Cad = new SqlCommand("INSERT INTO dbo.Software VALUES('" + User_Data[35] + "','" + User_Data[36] + "','" + User_Data[34] + "','" + User_Data[33] + "','" + User_Data[37] + "') ", Connection_Class.cn);
                        Insert_Cad.ExecuteNonQuery();
                        SqlCommand Max_Soft = new SqlCommand("select max(Id_Soft) from dbo.Software", Connection_Class.cn);
                        int idsoft_new = Conditions_Class.Get_Id(Max_Soft);
                        SqlCommand Update_User_Soft = new SqlCommand(" UPDATE dbo.User_Soft SET dbo.User_Soft.Id_Soft='" + idsoft_new + "' WHERE  dbo.User_Soft.Id_User = '" + Id_User + "' AND  dbo.User_Soft.Id_Soft = '" + idsoft_Old + "' ", Connection_Class.cn);
                        Update_User_Soft.ExecuteNonQuery();
                        //check if software on laptop or desktop
                        if (User_Data_Before[3] == "Desktop")
                        {
                            SqlCommand ID_Desk = new SqlCommand("select Id_Desktop from Desktop where Desktop.Id_User='" + Id_User + "'", Connection_Class.cn);
                            int id_desk = Conditions_Class.Get_Id(ID_Desk);

                            SqlCommand Update_Soft_Desk = new SqlCommand(" UPDATE dbo.Soft_Desk SET dbo.Soft_Desk.Id_Soft='" + idsoft_new + "' WHERE  dbo.Soft_Desk.Id_Desktop = '" + id_desk + "' AND  dbo.Soft_Desk.Id_Soft = '" + idsoft_Old + "' ", Connection_Class.cn);
                            Update_Soft_Desk.ExecuteNonQuery();
                        }
                        else
                        {
                            SqlCommand ID_Lap = new SqlCommand("select Id_Laptop from Laptops where Laptops.Id_User='" + Id_User + "'", Connection_Class.cn);
                            int id_lap = Conditions_Class.Get_Id(ID_Lap);
                            SqlCommand Update_SoftLap = new SqlCommand(" UPDATE dbo.Soft_Laptop SET dbo.Soft_Laptop.Id_Soft='" + idsoft_new + "' WHERE  dbo.Soft_Laptop.Id_Laptop = '" + id_lap + "' AND  dbo.Soft_Laptop.Id_Soft = '" + idsoft_Old + "' ", Connection_Class.cn);
                            Update_SoftLap.ExecuteNonQuery();
                        }
                        MessageBox.Show("Data Updated Successfully");
                       
                    }
                    else
                    {
                        SqlCommand Update_User_Soft = new SqlCommand(" UPDATE dbo.Software SET dbo.Software.Version='" + User_Data[37] + "' WHERE dbo.Software.Id_Soft = '" + idsoft_Old + "' ", Connection_Class.cn);
                        Update_User_Soft.ExecuteNonQuery();
                        MessageBox.Show("Data Updated Successfully");
                    }
                    SearchName_Click(sender, e);
                }
                //autocad to gstar or gstar to autocad
                if (((User_Data_Before[33].ToLower() == "gstar" && User_Data[33].ToLower() == "autocad") ||( User_Data_Before[33].ToLower() == "autocad" && User_Data[33].ToLower() == "gstar")) )
                {
                    Console.WriteLine("transfer from autocad to gstar");

                    //get software id 
                    SqlCommand Old_Soft = new SqlCommand("select Id_Soft from dbo.Software where Email = '" + User_Data_Before[35] + "' AND  Password = '" + User_Data_Before[36] + "' AND  [Key] = '" + User_Data_Before[34] + "' AND  type = '" + User_Data_Before[33] + "' AND  Version = '" + User_Data_Before[37] + "'", Connection_Class.cn);
                    int idsoft_Old = Conditions_Class.Get_Id(Old_Soft);
                    SqlCommand ID_Soft = new SqlCommand("select Id_Soft from User_Soft where User_Soft.Id_Soft='" + idsoft_Old + "' AND User_Soft.Id_User != '" + Id_User + "'", Connection_Class.cn);
                    Object Soft_f = ID_Soft.ExecuteScalar();
                    SqlCommand cmd14 = new SqlCommand("INSERT INTO dbo.Spare  (dbo.Spare.Type ,dbo.Spare.Email ,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note)  VALUES('" + User_Data_Before[33] + "','" + User_Data_Before[35] + "','" + User_Data_Before[36] + "','" + User_Data_Before[34] + "','" + User_Data_Before[37] + "','Old'+' '+'" + User_Data_Before[0] + "') ", Connection_Class.cn);
                    cmd14.ExecuteNonQuery();
                    SqlCommand Update = new SqlCommand(" UPDATE dbo.Software  SET dbo.Software.[Key] = '" + User_Data[34] + "',dbo.Software.Email='" + User_Data[35] + "',dbo.Software.Password='" + User_Data[36] + "',dbo.Software.Type ='" + User_Data[33] + "',dbo.Software.Version='" + User_Data[37] + "' WHERE Software.Id_Soft='" + idsoft_Old + "'; ", Connection_Class.cn);
                    Update.ExecuteNonQuery();
                    MessageBox.Show("Data Updated Successfully");
                    SearchName_Click(sender, e);
                }

                //2 - change only in autocad version
                if ((User_Data[33] == "autocad" || User_Data[33] == "Autocad") && (User_Data_Before[35] == User_Data[35] && User_Data_Before[36] == User_Data[36] && User_Data_Before[37] != User_Data[37]))
                {
                    Console.WriteLine("upgrade autocad version");
                    SqlCommand Old_Soft = new SqlCommand("select Id_Soft from dbo.Software where Email = '" + User_Data_Before[35] + "' AND  Password = '" + User_Data_Before[36] + "' AND  [Key] = '" + User_Data_Before[34] + "' AND  type = '" + User_Data_Before[33] + "' AND  Version = '" + User_Data_Before[37] + "'", Connection_Class.cn);
                    int idsoft_Old = Conditions_Class.Get_Id(Old_Soft);
                    SqlCommand cmd15 = new SqlCommand("UPDATE dbo.Software SET dbo.Software.Version='" + User_Data[37] + "' WHERE Software.Id_Soft ='" + idsoft_Old + "'; ", Connection_Class.cn);
                    cmd15.ExecuteNonQuery();
                    MessageBox.Show("Data Updated Successfully");
                    SearchName_Click(sender, e);
                }
                if(User_Data_Before[23].ToString() == ""&& User_Data[23]!= User_Data_Before[23])
                {
                    if(User_Data[24].ToString()=="")
                    {
                        MessageBox.Show("Please Enter the Foxit Key");
                    }
                    else
                    {
                        Console.WriteLine("add pdf type");
                        SqlCommand Id_u = new SqlCommand("select Id_User from Users where Lower(dbo.Users.Name) = '" + userName.ToLower() + "'", Connection_Class.cn);
                        int id = Conditions_Class.Get_Id(Id_u);

                        Console.WriteLine(id);
                        SqlCommand Old_Soft = new SqlCommand("INSERT INTO dbo.Software (dbo.Software.Email ,dbo.Software.Password ,dbo.Software.[Key],dbo.Software.type,dbo.Software.Version) VALUES('" + User_Data[23] + "','" + User_Data[26] + "','" + User_Data[24] + "','" + User_Data[23] + "', '" + User_Data[27] + "') ", Connection_Class.cn);
                        Old_Soft.ExecuteNonQuery();
                        SqlCommand new_Soft = new SqlCommand("select Id_Soft from dbo.Software where Email = '" + User_Data[23] + "' AND  Password = '" + User_Data[26] + "' AND  [Key] = '" + User_Data[24] + "' AND  type = '" + User_Data[23] + "' AND  Version = '" + User_Data[27] + "'", Connection_Class.cn);
                        idsoft_Old = Conditions_Class.Get_Id(new_Soft);
                        SqlCommand ins_User_Soft = new SqlCommand("INSERT INTO dbo.User_Soft(dbo.User_Soft.Id_User,dbo.User_Soft.Id_Soft) VALUES('" + Id_User + "','" + idsoft_Old + "') ", Connection_Class.cn);
                        ins_User_Soft.ExecuteNonQuery();
                        if (b == false)
                        {
                            SqlCommand find_Lap = new SqlCommand("select Id_Laptop from dbo.Laptops where Id_User='" + id + "'", Connection_Class.cn);
                            int Id_Lap = Conditions_Class.Get_Id(find_Lap);
                            SqlCommand ins_Lap_Soft = new SqlCommand("INSERT INTO dbo.Soft_Laptop (dbo.Soft_Laptop.Id_Soft,dbo.Soft_Laptop.Id_Laptop) VALUES('" + idsoft_Old + "','" + Id_Lap + "') ", Connection_Class.cn);
                            ins_Lap_Soft.ExecuteNonQuery();
                        }
                        else
                        {
                            SqlCommand find_Desk = new SqlCommand("select Id_Desktop from dbo.Desktop where Id_User='" + Id_User + "'", Connection_Class.cn);
                            int Id_Desk = Conditions_Class.Get_Id(find_Desk);
                            SqlCommand ins_Desk_Soft = new SqlCommand("INSERT INTO dbo.Soft_Desk(dbo.Soft_Desk.Id_Soft,dbo.Soft_Desk.Id_Desktop) VALUES('" + idsoft_Old + "','" + Id_Desk + "') ", Connection_Class.cn);
                            ins_Desk_Soft.ExecuteNonQuery();
                        }
                        MessageBox.Show("Data Updated Successfully");
                    }
                    

                }

                    ////3-Chang software (foxit to adobe or adobe to foxit,gstar to autocad)
                    if ((User_Data_Before[23] != User_Data[23])&& User_Data_Before[23].ToString() != "")
                {
                    
                    Console.WriteLine("change pdf type");
                    SqlCommand Old_Soft = new SqlCommand("select Id_Soft from dbo.Software where Email = '" + User_Data_Before[25] + "' AND  Password = '" + User_Data_Before[26] + "' AND  [Key] = '" + User_Data_Before[24] + "' AND  type = '" + User_Data_Before[23] + "' AND  Version = '" + User_Data_Before[27] + "'", Connection_Class.cn);
                     idsoft_Old = Conditions_Class.Get_Id(Old_Soft);
                    if (User_Data_Before[23] == "adobe")
                    {
                        if (User_Data[24].ToString() == "")
                        {
                            MessageBox.Show("Please Enter the Foxit Key");
                        }
                        else
                        {
                        SqlCommand Update = new SqlCommand(" UPDATE dbo.Software  SET dbo.Software.[Key] = '" + User_Data[24] + "',dbo.Software.Email='" + User_Data[25] + "',dbo.Software.Password='" + User_Data[26] + "',dbo.Software.Type ='" + User_Data[23] + "',dbo.Software.Version='" + User_Data[27] + "' WHERE Software.Id_Soft='" + idsoft_Old + "'; ", Connection_Class.cn);
                        Update.ExecuteNonQuery();
                        MessageBox.Show("Data Updated Successfully");
                        }
                        
                    }
                    else
                    {
                        SqlCommand Insert_Soft_Spare = new SqlCommand("INSERT INTO dbo.Spare  (dbo.Spare.Type ,dbo.Spare.Email ,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note)  VALUES('" + User_Data_Before[23] + "','" + User_Data_Before[25] + "','" + User_Data_Before[26] + "','" + User_Data_Before[24] + "','" + User_Data_Before[27] + "','Old'+' '+'" + User_Data_Before[0] + "') ", Connection_Class.cn);
                        Insert_Soft_Spare.ExecuteNonQuery();
                        SqlCommand Update = new SqlCommand(" UPDATE dbo.Software  SET dbo.Software.[Key] = '" + User_Data[24] + "',dbo.Software.Email='" + User_Data[25] + "',dbo.Software.Password='" + User_Data[26] + "',dbo.Software.Type ='" + User_Data[23] + "',dbo.Software.Version='" + User_Data[27] + "' WHERE Software.Id_Soft='" + idsoft_Old + "'; ", Connection_Class.cn);
                        Update.ExecuteNonQuery();
                        MessageBox.Show("Data Updated Successfully");
                    }
                    SearchName_Click(sender, e);
                }
                // 4-chang office
                if (User_Data_Before[18] != User_Data[18] && User_Data_Before[19] != User_Data[19])
                {
                    Console.WriteLine("change office");
                    SqlCommand Old_Soft = new SqlCommand("select Id_Soft from dbo.Software where Email = '" + User_Data_Before[20] + "' AND  Password = '" + User_Data_Before[21] + "' AND  [Key] = '" + User_Data_Before[19] + "' AND  type = '" + User_Data_Before[18] + "' AND  Version = '" + User_Data_Before[22] + "'", Connection_Class.cn);
                    int idsoft_Old = Conditions_Class.Get_Id(Old_Soft);
                    SqlCommand cmd14 = new SqlCommand("INSERT INTO dbo.Spare  (dbo.Spare.Type ,dbo.Spare.Email ,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note)  VALUES('" + User_Data_Before[18] + "','" + User_Data_Before[20] + "','" + User_Data_Before[21] + "','" + User_Data_Before[19] + "','" + User_Data_Before[22] + "','Old'+' '+'" + User_Data_Before[0] + "') ", Connection_Class.cn);
                    cmd14.ExecuteNonQuery();
                    SqlCommand cmd13 = new SqlCommand(" UPDATE dbo.Software  SET dbo.Software.Type = '" + User_Data[18] + "', dbo.Software.[Key] = '" + User_Data[19] + "',dbo.Software.Email='" + User_Data[20] + "',dbo.Software.Password='" + User_Data[21] + "',dbo.Software.Version='" + User_Data[22] + "' WHERE Software.Id_Soft='" + idsoft_Old + "'; ", Connection_Class.cn);
                    cmd13.ExecuteNonQuery();
                    MessageBox.Show("Data Updated Successfully");
                    SearchName_Click(sender, e);
                }
                //5-change activation license of autocad,revit,civil3d (change email and password)
                if (((User_Data_Before[33] == User_Data[33] &&( User_Data_Before[33] == "autocad" || User_Data_Before[33] == "Autocad") && User_Data_Before[35]!= User_Data[35]) ))
                {
                    SqlCommand Old_Soft = new SqlCommand("select Id_Soft from dbo.Software where Email = '" + User_Data_Before[35] + "' AND  Password = '" + User_Data_Before[36] + "' AND  [Key] = '" + User_Data_Before[34] + "' AND  type = '" + User_Data_Before[33] + "' AND  Version = '" + User_Data_Before[37] + "'", Connection_Class.cn);
                    int idsoft_Old = Conditions_Class.Get_Id(Old_Soft);
                    SqlCommand insert_spare = new SqlCommand("insert into Spare (Spare.Type,Spare.Email,Spare.Password,Spare.[Key],Spare.Version,Spare.Note) VALUES('" + User_Data_Before[33] + "','" + User_Data_Before[35] + "','" + User_Data_Before[36] + "','" + User_Data_Before[34] + "','" + User_Data_Before[37] + "','Old'+' '+'" + User_Data_Before[0] + "')", Connection_Class.cn);
                    insert_spare.ExecuteNonQuery();
                    SqlCommand cmd13 = new SqlCommand(" UPDATE dbo.Software  SET dbo.Software.Email='" + User_Data[35] + "',dbo.Software.Password='" + User_Data[36] + "',dbo.Software.Version='" + User_Data[37] + "' WHERE Software.Id_Soft='" + idsoft_Old + "'; ", Connection_Class.cn);
                    cmd13.ExecuteNonQuery();
                    MessageBox.Show("Data Updated Successfully");
                    SearchName_Click(sender, e);
                }
                /////////////////////oTHER1 Revit and Civil3D////////////////////////////////
                if (((User_Data_Before[38] == User_Data[38] && User_Data_Before[40] != User_Data[40] && (User_Data_Before[38] == "revit" || User_Data_Before[38] == "civil3d"))))
                {
                    SqlCommand Old_Soft = new SqlCommand("select Id_Soft from dbo.Software where Email = '" + User_Data_Before[40] + "' AND  Password = '" + User_Data_Before[41] + "' AND  [Key] = '" + User_Data_Before[39] + "' AND  type = '" + User_Data_Before[38] + "' AND  Version = '" + User_Data_Before[42] + "'", Connection_Class.cn);
                    int idsoft_Old = Conditions_Class.Get_Id(Old_Soft);
                    SqlCommand insert_spare = new SqlCommand("insert into Spare(Spare.Type,Spare.Email,Spare.Password,Spare.[Key],Spare.Version,Spare.Note) VALUES('" + User_Data_Before[38] + "','" + User_Data_Before[40] + "','" + User_Data_Before[41] + "','" + User_Data_Before[39] + "','" + User_Data_Before[42] + "','Old'+' '+'" + User_Data_Before[0] + "')", Connection_Class.cn);
                    insert_spare.ExecuteNonQuery();
                    SqlCommand cmd13 = new SqlCommand(" UPDATE dbo.Software  SET dbo.Software.Email='" + User_Data[40] + "',dbo.Software.Password='" + User_Data[41] + "',dbo.Software.Version='" + User_Data[42] + "' WHERE Software.Id_Soft='" + idsoft_Old + "'; ", Connection_Class.cn);
                    cmd13.ExecuteNonQuery();
                    MessageBox.Show("Data Updated Successfully");
                    SearchName_Click(sender, e);

                }
                /////////////////////////////////////////OTHER2 Revit and Civil3D//////////////////////////////////////////////////////
                if (( (User_Data_Before[43] == User_Data[43] && User_Data_Before[45] != User_Data[45] && (User_Data_Before[43] == "revit"|| User_Data_Before[43] == "Revit" || User_Data_Before[43] == "Civil3d" || User_Data_Before[43] == "civil3d")) ))
                {
                    SqlCommand Old_Soft = new SqlCommand("select Id_Soft from dbo.Software where Email = '" + User_Data_Before[45] + "' AND  Password = '" + User_Data_Before[46] + "' AND  [Key] = '" + User_Data_Before[44] + "' AND  type = '" + User_Data_Before[43] + "' AND  Version = '" + User_Data_Before[47] + "'", Connection_Class.cn);
                    int idsoft_Old = Conditions_Class.Get_Id(Old_Soft);
                    SqlCommand insert_spare = new SqlCommand("insert into Spare (Spare.Type,Spare.Email,Spare.Password,Spare.[Key],Spare.Version,Spare.Note) VALUES('" + User_Data_Before[43] + "','" + User_Data_Before[45] + "','" + User_Data_Before[46] + "','" + User_Data_Before[44] + "','" + User_Data_Before[47] + "','Old'+' '+'" + User_Data_Before[0] + "')", Connection_Class.cn);
                    insert_spare.ExecuteNonQuery();
                    SqlCommand cmd13 = new SqlCommand(" UPDATE dbo.Software  SET dbo.Software.Email='" + User_Data[45] + "',dbo.Software.Password='" + User_Data[46] + "',dbo.Software.Version='" + User_Data[47] + "' WHERE Software.Id_Soft='" + idsoft_Old + "'; ", Connection_Class.cn);
                    cmd13.ExecuteNonQuery();
                    MessageBox.Show("Data Updated Successfully");
                    SearchName_Click(sender, e);

                }
                ///////////////////////////////////////////////OTHER3 Revit and Civil3D///////////////////////////////////////////////
                if ((User_Data_Before[48] == User_Data[48] && User_Data_Before[50] != User_Data[50] && ( User_Data_Before[48] == "revit" || User_Data_Before[48] == "Revit" || User_Data_Before[48] == "Civil3d" || User_Data_Before[48] == "civil3d")))
                {
                    SqlCommand Old_Soft = new SqlCommand("select Id_Soft from dbo.Software where Email = '" + User_Data_Before[50] + "' AND  Password = '" + User_Data_Before[51] + "' AND  [Key] = '" + User_Data_Before[49] + "' AND  type = '" + User_Data_Before[48] + "' AND  Version = '" + User_Data_Before[52] + "'", Connection_Class.cn);
                    int idsoft_Old = Conditions_Class.Get_Id(Old_Soft);
                    SqlCommand insert_spare = new SqlCommand("insert into Spare (Spare.Type,Spare.Email,Spare.Password,Spare.[Key],Spare.Version,Spare.Note) VALUES('" + User_Data_Before[48] + "','" + User_Data_Before[50] + "','" + User_Data_Before[51] + "','" + User_Data_Before[49] + "','" + User_Data_Before[52] + "','Old'+' '+'" + User_Data_Before[0] + "')", Connection_Class.cn);
                    insert_spare.ExecuteNonQuery();
                    SqlCommand cmd13 
                        = new SqlCommand(" UPDATE dbo.Software  SET dbo.Software.Email='" + User_Data[50] + "',dbo.Software.Password='" + User_Data[51] + "',dbo.Software.Version='" + User_Data[52] + "' WHERE Software.Id_Soft='" + idsoft_Old + "'; ", Connection_Class.cn);
                    cmd13.ExecuteNonQuery();
                    MessageBox.Show("Data Updated Successfully");
                    SearchName_Click(sender, e);
                }

                /////////////////////oTHER New Software////////////////////////////////
                if (((User_Data_Before[48].ToString() == "" || User_Data_Before[43].ToString() == "" || User_Data_Before[38].ToString() == "") && (User_Data[48].ToString() != "" || User_Data[43].ToString() != "" || User_Data[38].ToString() != "")))
                {
                    if (User_Data[48].ToString() != "" && User_Data_Before[48].ToString() == "")
                    {
                        SqlCommand Add_Other = new SqlCommand("INSERT INTO dbo.Software (dbo.Software.Email ,dbo.Software.Password ,dbo.Software.[Key],dbo.Software.type,dbo.Software.Version) VALUES('" + User_Data[51] + "','" + User_Data[52] + "','" + User_Data[50] + "','" + User_Data[48] + "', '" + User_Data[49] + "') ", Connection_Class.cn);
                        Add_Other.ExecuteNonQuery();
                        SqlCommand Max_Soft = new SqlCommand("select max(Id_Soft) from dbo.Software", Connection_Class.cn);
                        int idsoft_new = Conditions_Class.Get_Id(Max_Soft);
                        SqlCommand Add_User_Soft = new SqlCommand("INSERT INTO dbo.User_Soft (dbo.User_Soft.Id_User ,dbo.User_Soft.Id_Soft) VALUES('" + Id_User + "','" + idsoft_new + "') ", Connection_Class.cn);
                        Add_User_Soft.ExecuteNonQuery();
                        if (User_Data[3] == "Laptop")
                        {
                            SqlCommand ID_Lap = new SqlCommand("select Id_Laptop from Laptops where Laptops.Id_User='" + Id_User + "'", Connection_Class.cn);
                            int id_lap = Conditions_Class.Get_Id(ID_Lap);
                            SqlCommand Add_Soft_Lap = new SqlCommand("INSERT INTO dbo.Soft_Laptop (dbo.Soft_Laptop.Id_Laptop ,dbo.User_Soft.Id_Soft) VALUES('" + id_lap + "','" + idsoft_new + "') ", Connection_Class.cn);
                            Add_Soft_Lap.ExecuteNonQuery();
                        }
                        else
                        {
                            SqlCommand ID_Desk = new SqlCommand("select Id_Desktop from Desktop where Desktop.Id_User='" + Id_User + "'", Connection_Class.cn);
                            int id_desk = Conditions_Class.Get_Id(ID_Desk);
                            SqlCommand Add_Soft_Desk = new SqlCommand("INSERT INTO dbo.Soft_Desk (dbo.Soft_Desk.Id_Desktop ,dbo.User_Soft.Id_Soft) VALUES('" + id_desk + "','" + idsoft_new + "') ", Connection_Class.cn);
                            Add_Soft_Desk.ExecuteNonQuery();
                        }

                    }
                    if (User_Data[43].ToString() != "" && User_Data_Before[43].ToString() == "")
                    {
                        SqlCommand Add_Other = new SqlCommand("INSERT INTO dbo.Software (dbo.Software.Email ,dbo.Software.Password ,dbo.Software.[Key],dbo.Software.type,dbo.Software.Version) VALUES('" + User_Data[46] + "','" + User_Data[47] + "','" + User_Data[45] + "','" + User_Data[43] + "', '" + User_Data[44] + "') ", Connection_Class.cn);
                        Add_Other.ExecuteNonQuery();
                        SqlCommand Max_Soft = new SqlCommand("select max(Id_Soft) from dbo.Software", Connection_Class.cn);
                        int idsoft_new = Conditions_Class.Get_Id(Max_Soft);
                        SqlCommand Add_User_Soft = new SqlCommand("INSERT INTO dbo.User_Soft (dbo.User_Soft.Id_User ,dbo.User_Soft.Id_Soft) VALUES('" + Id_User + "','" + idsoft_new + "') ", Connection_Class.cn);
                        Add_User_Soft.ExecuteNonQuery();
                        if (User_Data[3] == "Laptop")
                        {
                            SqlCommand ID_Lap = new SqlCommand("select Id_Laptop from Laptops where Laptops.Id_User='" + Id_User + "'", Connection_Class.cn);
                            int id_lap = Conditions_Class.Get_Id(ID_Lap);
                            SqlCommand Add_Soft_Lap = new SqlCommand("INSERT INTO dbo.Soft_Laptop (dbo.Soft_Laptop.Id_Laptop ,dbo.User_Soft.Id_Soft) VALUES('" + id_lap + "','" + idsoft_new + "') ", Connection_Class.cn);
                            Add_Soft_Lap.ExecuteNonQuery();
                        }
                        else
                        {
                            SqlCommand ID_Desk = new SqlCommand("select Id_Desktop from Desktop where Desktop.Id_User='" + Id_User + "'", Connection_Class.cn);
                            int id_desk = Conditions_Class.Get_Id(ID_Desk);
                            SqlCommand Add_Soft_Desk = new SqlCommand("INSERT INTO dbo.Soft_Desk (dbo.Soft_Desk.Id_Desktop ,dbo.User_Soft.Id_Soft) VALUES('" + id_desk + "','" + idsoft_new + "') ", Connection_Class.cn);
                            Add_Soft_Desk.ExecuteNonQuery();
                        }
                    }
                    if (User_Data[38].ToString() != "" && User_Data_Before[38].ToString() == "")
                    {
                        SqlCommand Add_Other = new SqlCommand("INSERT INTO dbo.Software (dbo.Software.Email ,dbo.Software.Password ,dbo.Software.[Key],dbo.Software.type,dbo.Software.Version) VALUES('" + User_Data[41] + "','" + User_Data[42] + "','" + User_Data[40] + "','" + User_Data[38] + "', '" + User_Data[39] + "') ", Connection_Class.cn);
                        Add_Other.ExecuteNonQuery();
                        SqlCommand Max_Soft = new SqlCommand("select max(Id_Soft) from dbo.Software", Connection_Class.cn);
                        int idsoft_new = Conditions_Class.Get_Id(Max_Soft);
                        SqlCommand Add_User_Soft = new SqlCommand("INSERT INTO dbo.User_Soft (dbo.User_Soft.Id_User ,dbo.User_Soft.Id_Soft) VALUES('" + Id_User + "','" + idsoft_new + "') ", Connection_Class.cn);
                        Add_User_Soft.ExecuteNonQuery();
                        if (User_Data[3] == "Laptop")
                        {
                            SqlCommand ID_Lap = new SqlCommand("select Id_Laptop from Laptops where Laptops.Id_User='" + Id_User + "'", Connection_Class.cn);
                            int id_lap = Conditions_Class.Get_Id(ID_Lap);
                            SqlCommand Add_Soft_Lap = new SqlCommand("INSERT INTO dbo.Soft_Laptop (dbo.Soft_Laptop.Id_Laptop ,dbo.User_Soft.Id_Soft) VALUES('" + id_lap + "','" + idsoft_new + "') ", Connection_Class.cn);
                            Add_Soft_Lap.ExecuteNonQuery();
                        }
                        else
                        {
                            SqlCommand ID_Desk = new SqlCommand("select Id_Desktop from Desktop where Desktop.Id_User='" + Id_User + "'", Connection_Class.cn);
                            int id_desk = Conditions_Class.Get_Id(ID_Desk);
                            SqlCommand Add_Soft_Desk = new SqlCommand("INSERT INTO dbo.Soft_Desk (dbo.Soft_Desk.Id_Desktop ,dbo.User_Soft.Id_Soft) VALUES('" + id_desk + "','" + idsoft_new + "') ", Connection_Class.cn);
                            Add_Soft_Desk.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Data Updated Successfully");
                    SearchName_Click(sender, e);

                }
                data_grid.ClearSelection();
                
                User_Data.Clear();


            }
            Connection_Class.Close();
        }








        
        //}
    
            //SearchName_Click(sender, e);
        

        private void button1_Click(object sender, EventArgs e)
        {
            Edit_by_spare_options edit= new Edit_by_spare_options();
            edit.Show();
            this.Hide();

            //...
            }

        private void button2_Click(object sender, EventArgs e)
        {
            Inventory_CURD curd = new Inventory_CURD();
            curd.Show();
            this.Hide();
        }
        //////////////////////////////////////////////back///////////////////////////////////////////////////////////////////////////
        private void Data_Gride_Edit(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            Connection_Class.DB_cn();
            Connection_Class.open();
            //AutoComplete Brand_Device
            if (data_grid.CurrentCell.ColumnIndex == 5)
            {
               
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Brand_Lap,Brand_Desktop FROM dbo.Laptops,dbo.Desktop", Connection_Class.cn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader.GetString(0));
                        MyCollection.Add(reader.GetString(1));
                    }


                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    prodCode.AutoCompleteCustomSource = MyCollection;

                }

            }
            //Autocomplete Model_Device
            else if (data_grid.CurrentCell.ColumnIndex == 6)
            {
               
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Model_Lap,Model_Desktop FROM dbo.Laptops,dbo.Desktop", Connection_Class.cn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader.GetString(0));
                        MyCollection.Add(reader.GetString(1));
                    }


                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    prodCode.AutoCompleteCustomSource = MyCollection;

                }

            }
            //Autocomplete Processor_Device
            else if (data_grid.CurrentCell.ColumnIndex == 7)
            {
                
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Processor_Lap,Processor_Desktop FROM dbo.Laptops,dbo.Desktop", Connection_Class.cn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader.GetString(0));
                        MyCollection.Add(reader.GetString(1));
                    }


                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    prodCode.AutoCompleteCustomSource = MyCollection;

                }

            }
            //Autocomplete Ram_Device
            else if (data_grid.CurrentCell.ColumnIndex == 8)
            {
                
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Ram_Lap,Ram_Desktop FROM dbo.Laptops,dbo.Desktop", Connection_Class.cn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader.GetString(0));
                        MyCollection.Add(reader.GetString(1));
                    }


                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    prodCode.AutoCompleteCustomSource = MyCollection;

                }

            }
            //Autocomplete Hard_Device
            else if (data_grid.CurrentCell.ColumnIndex == 9)
            {
                
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Hard_Lap,Hard_Desktop FROM dbo.Laptops,dbo.Desktop",Connection_Class.cn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader.GetString(0));
                        MyCollection.Add(reader.GetString(1));
                    }


                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    prodCode.AutoCompleteCustomSource = MyCollection;

                }

            }
            //Autocomplete Model_Monitor
            else if (data_grid.CurrentCell.ColumnIndex == 13)
            {
                
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Model_Monitor FROM dbo.Monitor", Connection_Class.cn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader.GetString(0));

                    }


                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    prodCode.AutoCompleteCustomSource = MyCollection;

                }

            }
            //AutoComplete Brand_Monitor
            else if (data_grid.CurrentCell.ColumnIndex == 12)
            {
                
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Brand_Monitor FROM dbo.Monitor", Connection_Class.cn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader.GetString(0));

                    }


                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    prodCode.AutoCompleteCustomSource = MyCollection;

                }

            }
            //AutoComplete Win-Type
            else if (data_grid.CurrentCell.ColumnIndex == 15)
            {
                
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT type FROM dbo.Software WHERE type LIKE 'Windows%'; ", Connection_Class.cn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader.GetString(0));

                    }


                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    prodCode.AutoCompleteCustomSource = MyCollection;

                }

            }
            //AutoComplete Win-Version
            else if (data_grid.CurrentCell.ColumnIndex == 17)
            {
               
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Version FROM dbo.Software WHERE type LIKE 'Windows%'; ",Connection_Class.cn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader.GetString(0));

                    }


                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    prodCode.AutoCompleteCustomSource = MyCollection;

                }

            }
            //AutoComplete Office-Type
            else if (data_grid.CurrentCell.ColumnIndex == 18)
            {
                
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Type FROM dbo.Software WHERE type LIKE 'Office%'; ",Connection_Class.cn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader.GetString(0));

                    }


                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    prodCode.AutoCompleteCustomSource = MyCollection;

                }

            }
            //AutoComplete Office-Version
            else if (data_grid.CurrentCell.ColumnIndex == 22)
            {
                
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Version FROM dbo.Software WHERE type LIKE 'Office%'; ",Connection_Class.cn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader.GetString(0));

                    }


                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    prodCode.AutoCompleteCustomSource = MyCollection;

                }

            }
            //AutoComplete Office-Pass
            else if (data_grid.CurrentCell.ColumnIndex == 21)
            {
              
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Password FROM dbo.Software WHERE type LIKE 'Office%'; ",Connection_Class.cn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader.GetString(0));

                    }


                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    prodCode.AutoCompleteCustomSource = MyCollection;

                }
            }
            //AutoComplete Office-Version
            else if (data_grid.CurrentCell.ColumnIndex == 21)
            {
               
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Password FROM dbo.Software WHERE type LIKE 'Office%'; ", Connection_Class.cn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader.GetString(0));

                    }


                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    prodCode.AutoCompleteCustomSource = MyCollection;

                }

            }
            //AutoComplete PDF-Type
            else if (data_grid.CurrentCell.ColumnIndex == 23)
            {
               
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Type FROM dbo.Software WHERE type LIKE 'Foxit%' OR type LIKE 'Adobe%' ; ", Connection_Class.cn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader.GetString(0));

                    }


                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    prodCode.AutoCompleteCustomSource = MyCollection;

                }

            }
            //AutoComplete PDF-Version
            else if (data_grid.CurrentCell.ColumnIndex == 27)
            {
               
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Version FROM dbo.Software WHERE type LIKE 'Foxit%' OR type LIKE 'Adobe%' ; ", Connection_Class.cn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader.GetString(0));

                    }


                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    prodCode.AutoCompleteCustomSource = MyCollection;

                }

            }
            //AutoComplete Foxit-Key
            else if (data_grid.CurrentCell.ColumnIndex == 24)
            {
               
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT [Key] FROM dbo.Software WHERE type LIKE 'Foxit%'; ", Connection_Class.cn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader.GetString(0));

                    }
                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    prodCode.AutoCompleteCustomSource = MyCollection;
                }
            }
            //AutoComplete ANTIVIRUS-TYPE
            else if (data_grid.CurrentCell.ColumnIndex == 28)
            {
               
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT type FROM dbo.Software WHERE type LIKE 'Trendmicro%' OR type LIKE 'trendmicro%'OR type LIKE 'TrendMicro%'; ", Connection_Class.cn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader.GetString(0));

                    }
                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    prodCode.AutoCompleteCustomSource = MyCollection;
                }
            }
            //AutoComplete ANTIVIRUS-Version
            else if (data_grid.CurrentCell.ColumnIndex == 32)
            {
              
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Version FROM dbo.Software WHERE type LIKE 'Trendmicro%' OR type LIKE 'trendmicro%'OR type LIKE 'TrendMicro%'; ", Connection_Class.cn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader.GetString(0));

                    }
                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    prodCode.AutoCompleteCustomSource = MyCollection;
                }
            }
            //AutoComplete Cad-Type
            else if (data_grid.CurrentCell.ColumnIndex == 33)
            {
                
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT type FROM dbo.Software WHERE type LIKE '%Cad%' OR type LIKE '%cad%'OR type LIKE '%Gstar%' OR type LIKE '%gstar%'; ", Connection_Class.cn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader.GetString(0));

                    }
                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    prodCode.AutoCompleteCustomSource = MyCollection;
                }
            }
            //AutoComplete Cad-Email
            else if (data_grid.CurrentCell.ColumnIndex == 35)
            {
               
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Email FROM dbo.Software WHERE type LIKE '%Cad%' OR type LIKE '%cad%'; ", Connection_Class.cn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader.GetString(0));

                    }
                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    prodCode.AutoCompleteCustomSource = MyCollection;
                }
            }
            //AutoComplete Cad-Pass
            else if (data_grid.CurrentCell.ColumnIndex == 36)
            {
               
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT Password FROM dbo.Software WHERE type LIKE '%Cad%' OR type LIKE '%cad%'; ", Connection_Class.cn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader.GetString(0));

                    }
                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    prodCode.AutoCompleteCustomSource = MyCollection;
                }
            }
            //AutoComplete Cad-Key
            else if (data_grid.CurrentCell.ColumnIndex == 34)
            {
                
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    SqlCommand cmd = new SqlCommand("SELECT [Key] FROM dbo.Software WHERE type LIKE '%Gstar%' OR type LIKE '%gstar%'; ", Connection_Class.cn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                    while (reader.Read())
                    {
                        MyCollection.Add(reader.GetString(0));

                    }
                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    prodCode.AutoCompleteCustomSource = MyCollection;
                }
            }
            else
            {
                TextBox prodCode = e.Control as TextBox;
                if (prodCode != null)
                {
                    prodCode.AutoCompleteMode = AutoCompleteMode.None;
                }
            }
            Connection_Class.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete Del =new Delete();
            Del.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Edit_Form_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
    }
    }

