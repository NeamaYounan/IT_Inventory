using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

using System.Data.SqlClient;


namespace inventory2
{
    public partial class Hardware_Search : Form
    {
        
        private Size formOriginalSize;
        //pics
        private Rectangle pictureBox1OriginalRect;
        private Rectangle pictureBox2OriginalRect;
        //labels
        private Rectangle Label1OriginalRect;
        private Rectangle Label2OriginalRect;
        //textbox
        private Rectangle textBox1OriginalRect;
        private Rectangle textBox2OriginalRect;
        //buttons
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        private Rectangle button3OriginalRect;
        //datagride
        private Rectangle datagridviewOriginalRect;
        private Rectangle datagridview1OriginalRect;
        private Rectangle datagridview2OriginalRect;
        public Hardware_Search()
        {
            
            InitializeComponent();
            using (SqlConnection con = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;"))

            {
                Connection_Class.DB_cn();
                Connection_Class.open();

                SqlCommand cmd = new SqlCommand("SELECT  Desktop.Serial_Number_Desk ,  Laptops.Serial_Number_Lap ,  Monitor.Serial_Number_Monitor FROM Desktop, Laptops, Monitor", Connection_Class.cn);
               
                SqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    MyCollection.Add(reader.GetString(0));
                    MyCollection.Add(reader.GetString(1));
                    MyCollection.Add(reader.GetString(2));
                }
                Serial_Number.AutoCompleteCustomSource = MyCollection;
                con.Close();
            }
            //using (SqlConnection con = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;"))
            //{
            //    Connection_Class.DB_cn();
            //    Connection_Class.open();
            //    SqlCommand cmd = new SqlCommand("SELECT SUBSTRING(dbo.Desktop.Serial_Number_Desk,LEN(dbo.Desktop.Serial_Number_Desk)-3 , LEN(dbo.Desktop.Serial_Number_Desk)) , SUBSTRING(dbo.Laptops.Serial_Number_Lap,LEN(dbo.Laptops.Serial_Number_Lap)-3 , LEN(dbo.Laptops.Serial_Number_Lap)), SUBSTRING(dbo.Monitor.Serial_Number_Monitor,LEN(dbo.Monitor.Serial_Number_Monitor)-3 , LEN(dbo.Monitor.Serial_Number_Monitor)) FROM dbo.Desktop, dbo.Laptops, dbo.Monitor", Connection_Class.cn);
                
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
            //    while (reader.Read())
            //    {
            //        MyCollection.Add(reader.GetString(0));
            //        MyCollection.Add(reader.GetString(1));
            //        MyCollection.Add(reader.GetString(2));
            //    }
            //    Last_Letters.AutoCompleteCustomSource = MyCollection;
            //    Connection_Class.Close();
            //}
            using (SqlConnection con = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;"))
            {
                Connection_Class.DB_cn();
                Connection_Class.open();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT Model_Desktop, Model_Lap ,  Model_Monitor FROM dbo.Desktop, dbo.Laptops, dbo.Monitor", Connection_Class.cn);
                
                SqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    MyCollection.Add(reader.GetString(0));
                    MyCollection.Add(reader.GetString(1));
                    MyCollection.Add(reader.GetString(2));
                }
                Model_Search.AutoCompleteCustomSource = MyCollection;
                Connection_Class.Close();
            }

        }
       
        public string[] Details;

        //neama DB=DESKTOP-OG2M2CI
        //Katren DB=DESKTOP-9QTGSEL
        //SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
        DataTable dt1 = new DataTable();
        DataRow dr = null;
        private void Hardware_Search_Load(object sender, EventArgs e)
        {
            dataGridView2.RowHeadersVisible = false;
            Search_Grid.RowHeadersVisible = false;
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            pictureBox1OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            pictureBox2OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            Label1OriginalRect = new Rectangle(Serial_Lable.Location.X, Serial_Lable.Location.Y, Serial_Lable.Width, Serial_Lable.Height);
            Label2OriginalRect = new Rectangle(Model.Location.X, Model.Location.Y, Model.Width, Model.Height);
            textBox1OriginalRect = new Rectangle(Serial_Number.Location.X, Serial_Number.Location.Y, Serial_Number.Width, Serial_Number.Height);
            textBox2OriginalRect = new Rectangle(Model_Search.Location.X, Model_Search.Location.Y, Model_Search.Width, Model_Search.Height);
            button1OriginalRect = new Rectangle(Search.Location.X, Search.Location.Y, Search.Width, Search.Height);
            button2OriginalRect = new Rectangle(Search_Model.Location.X, Search_Model.Location.Y, Search_Model.Width, Search_Model.Height);
            button3OriginalRect = new Rectangle(Back.Location.X, Back.Location.Y, Back.Width, Back.Height);
            datagridviewOriginalRect = new Rectangle(dataGridView2.Location.X, dataGridView2.Location.Y, dataGridView2.Width, dataGridView2.Height);
            datagridview1OriginalRect = new Rectangle(Search_Grid.Location.X, Search_Grid.Location.Y, Search_Grid.Width, Search_Grid.Height);
            datagridview2OriginalRect = new Rectangle(model_Grid.Location.X, model_Grid.Location.Y, model_Grid.Width, model_Grid.Height);
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Search_Options search = new Search_Options();
            search.Show();
            this.Hide();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
            int Numbers;
            this.Search_Grid.ColumnHeadersHeight = 20;
            model_Grid.Visible = false;
            dt1.Columns.Clear();
            dt1.Rows.Clear();
            string txt = Serial_Number.Text;//Get input Serial
            DataTable dt2 = new DataTable();
            Connection_Class.DB_cn();
            Connection_Class.open();

            SqlCommand cmd;//initialize Command
            int Id_User; //initialize Id_User

            //select id from desktop if found

            SqlCommand Desktop_CMD = new SqlCommand("Select  Id_User from dbo.Desktop where dbo.Desktop.Serial_Number_Desk  = '" + txt + "'", Connection_Class.cn);
            Object Check = Desktop_CMD.ExecuteScalar();
            //select id from desktop if found
            SqlCommand LapS_CMD = new SqlCommand("Select Id_User from dbo.Laptops where Serial_Number_Lap = '" + txt + "' ", Connection_Class.cn);
            Object Laps = LapS_CMD.ExecuteScalar();
            //select id from desktop if found
            SqlCommand MonitorS_CMD = new SqlCommand("Select Id_User from dbo.Monitor where Serial_Number_Monitor = '" + txt + "' ", Connection_Class.cn);
            Object Monitor1 = MonitorS_CMD.ExecuteScalar();
            if (Check == null && Monitor1 == null && Laps != null)//check if serial belong to Laptop 
            {
                Numbers = 0;
                Id_User = Conditions_Class.Get_Id(LapS_CMD);
                //get id User that belong this Serial Laptop
                int Others_Software = 0;//to Count the Other Softwares
                //add user and Device Column
                dt2.Columns.Add("#");
                dt2.Columns.Add("Name");
                dt2.Columns.Add("Title");
                dt2.Columns.Add("Location");
                dt2.Columns.Add("Device");
                dt2.Columns.Add("Serial Number");
                dt2.Columns.Add("Brand");
                dt2.Columns.Add("Model");
                dt2.Columns.Add("Processor");
                dt2.Columns.Add("Ram");
                dt2.Columns.Add("Hard");
                dt2.Columns.Add("Note");

                //add Monitor Columns
                dt2.Columns.Add("Monitor Serial Number");
                dt2.Columns.Add("Monitor Brand");
                dt2.Columns.Add("Monitor Model");
                dt2.Columns.Add("Monitor Note");

                //add Windows software columns
                dt2.Columns.Add("Windows Type");
                dt2.Columns.Add("Windows Key");
                dt2.Columns.Add("Windows Version");

                //add office software columns
                dt2.Columns.Add("Office Type");
                dt2.Columns.Add("Office Key");
                dt2.Columns.Add("Office Email");
                dt2.Columns.Add("Office Password");
                dt2.Columns.Add("Office Version");

                //add PDF software Columns
                dt2.Columns.Add("PDF Type");
                dt2.Columns.Add("PDF Key");
                dt2.Columns.Add("PDF Email");
                dt2.Columns.Add("PDF Password");
                dt2.Columns.Add("PDF Version");

                //add AntiVirus software columns
                dt2.Columns.Add("AntiVirus Type");
                dt2.Columns.Add("AntiVirus Key");
                dt2.Columns.Add("AntiVirus Email");
                dt2.Columns.Add("AntiVirus Password");
                dt2.Columns.Add("AntiVirus Version");

                //add Cad software columns
                dt2.Columns.Add("Cad Type");
                dt2.Columns.Add("Cad Key");
                dt2.Columns.Add("Cad Email");
                dt2.Columns.Add("Cad Password");
                dt2.Columns.Add("Cad Version");

                //add Other1 software columns
                dt2.Columns.Add("Other1 Type");
                dt2.Columns.Add("Other1 Key");
                dt2.Columns.Add("Other1 Email");
                dt2.Columns.Add("Other1 Password");
                dt2.Columns.Add("Other1 Version");

                //add Other2 software columns
                dt2.Columns.Add("Other2 Type");
                dt2.Columns.Add("Other2 Key");
                dt2.Columns.Add("Other2 Email");
                dt2.Columns.Add("Other2 Password");
                dt2.Columns.Add("Other2 Version");

                //add other3 software columns
                dt2.Columns.Add("Other3 Type");
                dt2.Columns.Add("Other3 Key");
                dt2.Columns.Add("Other3 Email");
                dt2.Columns.Add("Other3 Password");
                dt2.Columns.Add("Other3 Version");

                //initialize Details array

                //create header to datagrideview
                //this.Search_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                //this.Search_Grid.ColumnHeadersHeight = this.Search_Grid.ColumnHeadersHeight * 2;
                //this.Search_Grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                //this.Search_Grid.CellPainting += new DataGridViewCellPaintingEventHandler(Search_Grid_CellPainting);
                //this.Search_Grid.Paint += new PaintEventHandler(Search_Grid_Paint);
                //this.Search_Grid.Scroll += new ScrollEventHandler(Search_Grid_Scroll);
                //this.Search_Grid.ColumnWidthChanged += new DataGridViewColumnEventHandler(Search_Grid_ColumnWidthChanged);

                //create data new row in DataTable 
                DataRow dr = dt2.NewRow();

                //select User and Device From Data base
                SqlCommand data_by_lap = new SqlCommand("Select  dbo.Users.Name,dbo.Users.Title,dbo.Users.Location,dbo.Laptops.Serial_Number_Lap,dbo.Laptops.Brand_Lap,dbo.Laptops.Model_Lap,dbo.Laptops.Processor_Lap,dbo.Laptops.Hard_Lap,dbo.Laptops.Ram_Lap,Laptops.Note_Lap  from dbo.Laptops,dbo.Users Where dbo.Users.Id_User= '" + Id_User + "' AND  dbo.Laptops.Id_User ='" + Id_User + "'   ;", Connection_Class.cn);
                SqlDataReader sdr2 = data_by_lap.ExecuteReader();
                string[] LapAndUser = new string[sdr2.FieldCount];
                Numbers += 1;
                while (sdr2.Read())
                {
                    for (int l = 0; l < sdr2.FieldCount; l++)
                    {
                        LapAndUser[l] = sdr2[l].ToString();
                    }
                }
                //fill data of user and device in data table
                dr["#"] = Numbers;
                dr["Name"] = LapAndUser[0];
                dr["Title"] = LapAndUser[1];
                dr["Location"] = LapAndUser[2];
                dr["Device"] = "Laptop";
                dr["Serial Number"] = LapAndUser[3];
                dr["Brand"] = LapAndUser[4];
                dr["Model"] = LapAndUser[5];
                dr["Processor"] = LapAndUser[6];
                dr["Ram"] = LapAndUser[7];
                dr["Hard"] = LapAndUser[8];
                dr["Note"] = LapAndUser[9];
                //select Monitor Details from DataBase
                SqlCommand Monitor_Data = new SqlCommand("Select dbo.Monitor.Serial_Number_Monitor,dbo.Monitor.Brand_Monitor,dbo.Monitor.Model_Monitor,dbo.Monitor.Note_Monitor from dbo.Monitor Where dbo.Monitor.Id_User= '" + Id_User + "' ;", Connection_Class.cn);

                if (Conditions_Class.Monitor_Found(Connection_Class.cn, Id_User) != null)//Check if user Own the Monitor
                {

                    SqlDataReader sdr3 = Monitor_Data.ExecuteReader();
                    string[] Monitor_C = new string[sdr3.FieldCount];
                    while (sdr3.Read())
                    {
                        for (int l = 0; l < sdr3.FieldCount; l++)
                        {
                            Monitor_C[l] = sdr3[l].ToString();
                        }
                    }
                    //fill Monitor data that selected
                    dr["Monitor Serial Number"] = Monitor_C[0];
                    dr["Monitor Brand"] = Monitor_C[1];
                    dr["Monitor Model"] = Monitor_C[2];
                    dr["Monitor Note"] = Monitor_C[3];
                }
                //select Ids and Types of the Software that own to this Laptop
                SqlCommand Soft_Lap = new SqlCommand("SELECT dbo.Soft_Laptop.Id_Soft, dbo.Software.type from dbo.Soft_Laptop, dbo.Laptops, dbo.Software where dbo.Laptops.Id_User ='" + Id_User + "' AND dbo.Laptops.Id_Laptop = dbo.Soft_Laptop.Id_Laptop AND dbo.Soft_Laptop.Id_Soft = dbo.Software.Id_Soft ;", Connection_Class.cn);
                Object S_Lap = Soft_Lap.ExecuteScalar();
                List<Int32> Id_soft_Lap = new List<Int32>();
                List<String> Soft_Lap_Type = new List<String>();
                SqlDataReader sdr = Soft_Lap.ExecuteReader();
                while (sdr.Read())
                {
                    Id_soft_Lap.Add(sdr.GetInt32((sdr.GetOrdinal("Id_Soft"))));
                    Soft_Lap_Type.Add(sdr.GetString((sdr.GetOrdinal("type"))));
                }
                //for loop on all types of this Software 
                for (int i = 0; i < Soft_Lap_Type.Count; i++)
                {
                    //select software Details
                    SqlCommand Software_Details = new SqlCommand("SELECT type,[Key],Email,Password,Version from  dbo.Software where dbo.Software.Id_Soft ='" + Id_soft_Lap[i] + "' ;", Connection_Class.cn);
                    SqlDataReader SW_D = Software_Details.ExecuteReader();
                    string[] numb = new string[SW_D.FieldCount];
                    while (SW_D.Read())
                    {
                        for (int l = 0; l < SW_D.FieldCount; l++)
                        {
                            numb[l] = SW_D[l].ToString();
                        }
                    }
                    if (Soft_Lap_Type[i].Contains("Office") || Soft_Lap_Type[i].Contains("office")) //if this software type is Office 
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
                    else if (Soft_Lap_Type[i].Contains("trendmicro") || Soft_Lap_Type[i].Contains("Trendmicro"))//check if this software is antivirus
                    {

                        dr["AntiVirus Type"] = numb[0];
                        dr["AntiVirus Key"] = numb[1];
                        dr["AntiVirus Email"] = numb[2];
                        dr["AntiVirus Password"] = numb[3];
                        dr["AntiVirus Version"] = numb[4];

                    }
                    else if (Soft_Lap_Type[i].Contains("dwg") || Soft_Lap_Type[i].Contains("DWG") || Soft_Lap_Type[i].Contains("autocad") || Soft_Lap_Type[i].Contains("Autocad") || Soft_Lap_Type[i].Contains("Gstar") || Soft_Lap_Type[i].Contains("gstar"))//check if this software is Autocad or Gstar
                    {

                        dr["Cad Type"] = numb[0];
                        dr["Cad Key"] = numb[1];
                        dr["Cad Email"] = numb[2];
                        dr["Cad Password"] = numb[3];
                        dr["Cad Version"] = numb[4];

                    }
                    else if (Soft_Lap_Type[i].Contains("Windows") || Soft_Lap_Type[i].Contains("windows")) //if this software type is Office 
                    {
                        dr["Windows Type"] = numb[0];
                        dr["Windows Key"] = numb[1];
                        dr["Windows Version"] = numb[4];
                    }
                    else //this mean this software is other 
                    {
                        if (Others_Software < 3)//if other software is less than or equal 3 Software
                        {
                            Others_Software++;
                            dr["Other" + Others_Software + " Type"] = numb[0];
                            dr["Other" + Others_Software + " Key"] = numb[1];
                            dr["Other" + Others_Software + " Email"] = numb[2];
                            dr["Other" + Others_Software + " Password"] = numb[3];
                            dr["Other" + Others_Software + " Version"] = numb[4];
                        }
                        else //if the number of other software is more than 3 show this message
                        {
                            MessageBox.Show("the others Softwares Greater than 3");
                        }

                    }
                }

                dt2.Rows.Add(dr);//add the row to datatable
                Search_Grid.DataSource = dt2;//show this datatable in data grid view
                Search_Grid.Scroll += new System.Windows.Forms.ScrollEventHandler(Search_Grid_Scroll);
                Search_Grid.Width = 800;
                dataGridView2.Width = 800;
                Search_Grid.Columns[0].Width = 30;
                dataGridView2.Columns[0].Width = 30;
                foreach (DataGridViewColumn c in Search_Grid.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                
            }
            else if (Check == null && Monitor1 != null && Laps == null)//if serial Monitor
            {
                Numbers = 0;
                int Others_Software = 0;//to Count the Other Softwares
                //add user and Device Column
                dt2.Columns.Add("#");
                dt2.Columns.Add("Name");
                dt2.Columns.Add("Title");
                dt2.Columns.Add("Location");
                dt2.Columns.Add("Device");
                dt2.Columns.Add("Serial Number");
                dt2.Columns.Add("Brand");
                dt2.Columns.Add("Model");
                dt2.Columns.Add("Processor");
                dt2.Columns.Add("Ram");
                dt2.Columns.Add("Hard");
                dt2.Columns.Add("Note");
                //add Monitor Columns
                dt2.Columns.Add("Monitor Serial Number");
                dt2.Columns.Add("Monitor Brand");
                dt2.Columns.Add("Monitor Model");
                dt2.Columns.Add("Monitor Note");

                //add Windows software columns
                dt2.Columns.Add("Windows Type");
                dt2.Columns.Add("Windows Key");
                dt2.Columns.Add("Windows Version");

                //add office software columns
                dt2.Columns.Add("Office Type");
                dt2.Columns.Add("Office Key");
                dt2.Columns.Add("Office Email");
                dt2.Columns.Add("Office Password");
                dt2.Columns.Add("Office Version");

                //add PDF software Columns
                dt2.Columns.Add("PDF Type");
                dt2.Columns.Add("PDF Key");
                dt2.Columns.Add("PDF Email");
                dt2.Columns.Add("PDF Password");
                dt2.Columns.Add("PDF Version");

                //add AntiVirus software columns
                dt2.Columns.Add("AntiVirus Type");
                dt2.Columns.Add("AntiVirus Key");
                dt2.Columns.Add("AntiVirus Email");
                dt2.Columns.Add("AntiVirus Password");
                dt2.Columns.Add("AntiVirus Version");

                //add Cad software columns
                dt2.Columns.Add("Cad Type");
                dt2.Columns.Add("Cad Key");
                dt2.Columns.Add("Cad Email");
                dt2.Columns.Add("Cad Password");
                dt2.Columns.Add("Cad Version");

                //add Other1 software columns
                dt2.Columns.Add("Other1 Type");
                dt2.Columns.Add("Other1 Key");
                dt2.Columns.Add("Other1 Email");
                dt2.Columns.Add("Other1 Password");
                dt2.Columns.Add("Other1 Version");

                //add Other2 software columns
                dt2.Columns.Add("Other2 Type");
                dt2.Columns.Add("Other2 Key");
                dt2.Columns.Add("Other2 Email");
                dt2.Columns.Add("Other2 Password");
                dt2.Columns.Add("Other2 Version");

                //add other3 software columns
                dt2.Columns.Add("Other3 Type");
                dt2.Columns.Add("Other3 Key");
                dt2.Columns.Add("Other3 Email");
                dt2.Columns.Add("Other3 Password");
                dt2.Columns.Add("Other3 Version");

                ////create header to datagrideview
                //this.Search_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                //this.Search_Grid.ColumnHeadersHeight = this.Search_Grid.ColumnHeadersHeight * 2;
                //this.Search_Grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                //this.Search_Grid.CellPainting += new DataGridViewCellPaintingEventHandler(Search_Grid_CellPainting);
                //this.Search_Grid.Paint += new PaintEventHandler(Search_Grid_Paint);
                //this.Search_Grid.Scroll += new ScrollEventHandler(Search_Grid_Scroll);
                //this.Search_Grid.ColumnWidthChanged += new DataGridViewColumnEventHandler(Search_Grid_ColumnWidthChanged);

                Id_User = Conditions_Class.Get_Id(MonitorS_CMD);//get id User that belong this Serial Desktop
                DataRow dr = dt2.NewRow();
                if (Conditions_Class.Desktop_Found(Connection_Class.cn, Id_User) != null)//check if user own desktop
                {
                    Numbers += 1;
                    //select User and Device From Data base
                    SqlCommand data_by_Desktop = new SqlCommand("Select  dbo.Users.Name,dbo.Users.Title,dbo.Users.Location,dbo.Desktop.Serial_Number_Desk,dbo.Desktop.Brand_Desktop,dbo.Desktop.Model_Desktop,dbo.Desktop.Processor_Desktop,dbo.Desktop.Hard_Desktop,dbo.Desktop.Ram_Desktop,dbo.Desktop.Note_Desktop  from dbo.Desktop,dbo.Users Where dbo.Users.Id_User= '" + Id_User + "' AND  dbo.Desktop.Id_User ='" + Id_User + "'   ;", Connection_Class.cn);
                    SqlDataReader sdr2 = data_by_Desktop.ExecuteReader();
                    string[] DeskAndUser = new string[sdr2.FieldCount];
                    while (sdr2.Read())
                    {
                        for (int l = 0; l < sdr2.FieldCount; l++)
                        {
                            DeskAndUser[l] = sdr2[l].ToString();
                        }
                    }
                    //create data new row in DataTable 

                    //fill data of user and device in data table

                    dr["#"] = Numbers;
                    dr["Name"] = DeskAndUser[0];
                    dr["Title"] = DeskAndUser[1];
                    dr["Location"] = DeskAndUser[2];
                    dr["Device"] = "Desktop";
                    dr["Serial Number"] = DeskAndUser[3];
                    dr["Brand"] = DeskAndUser[4];
                    dr["Model"] = DeskAndUser[5];
                    dr["Processor"] = DeskAndUser[6];
                    dr["Ram"] = DeskAndUser[7];
                    dr["Hard"] = DeskAndUser[8];
                    dr["Note"] = DeskAndUser[9];
                    //select Ids and Types of the Software that own to this Desktop
                    SqlCommand Soft_Desk = new SqlCommand("SELECT dbo.Soft_Desk.Id_Soft, dbo.Software.type from dbo.Soft_Desk, dbo.Desktop, dbo.Software where dbo.Desktop.Id_User ='" + Id_User + "' AND dbo.Desktop.Id_Desktop = dbo.Soft_Desk.Id_Desktop AND dbo.Soft_Desk.Id_Soft = dbo.Software.Id_Soft ;", Connection_Class.cn);
                    List<Int32> Id_soft_Desk = new List<Int32>();
                    List<String> Soft_Desk_Type = new List<String>();
                    SqlDataReader sdr = Soft_Desk.ExecuteReader();
                    while (sdr.Read())
                    {
                        Id_soft_Desk.Add(sdr.GetInt32((sdr.GetOrdinal("Id_Soft"))));
                        Soft_Desk_Type.Add(sdr.GetString((sdr.GetOrdinal("type"))));
                    }
                    //for loop on all types of this Software 
                    for (int i = 0; i < Soft_Desk_Type.Count; i++)
                    {
                        //select software Details
                        SqlCommand Software_Details = new SqlCommand("SELECT type,[Key],Email,Password,Version from  dbo.Software where dbo.Software.Id_Soft ='" + Id_soft_Desk[i] + "' ;", Connection_Class.cn);
                        SqlDataReader SW_D = Software_Details.ExecuteReader();
                        string[] numb = new string[SW_D.FieldCount];
                        while (SW_D.Read())
                        {
                            for (int l = 0; l < SW_D.FieldCount; l++)
                            {
                                numb[l] = SW_D[l].ToString();
                            }
                        }
                        if (Soft_Desk_Type[i].Contains("Office")) //if this software type is Office 
                        {
                            //fill Office Columns
                            dr["Office Type"] = numb[0];
                            dr["Office Key"] = numb[1];
                            dr["Office Email"] = numb[2];
                            dr["Office Password"] = numb[3];
                            dr["Office Version"] = numb[4];
                        }
                        else if (Soft_Desk_Type[i].Contains("foxit") || Soft_Desk_Type[i].Contains("adobe")) //check if this Software type is PDF
                        {
                            //fill pdf Columns
                            dr["PDF Type"] = numb[0];
                            dr["PDF Key"] = numb[1];
                            dr["PDF Email"] = numb[2];
                            dr["PDF Password"] = numb[3];
                            dr["PDF Version"] = numb[4];

                        }
                        else if (Soft_Desk_Type[i].Contains("trendmicro"))//check if this software is antivirus
                        {

                            dr["AntiVirus Type"] = numb[0];
                            dr["AntiVirus Key"] = numb[1];
                            dr["AntiVirus Email"] = numb[2];
                            dr["AntiVirus Password"] = numb[3];
                            dr["AntiVirus Version"] = numb[4];

                        }
                        else if (Soft_Desk_Type[i].Contains("dwg") || Soft_Desk_Type[i].Contains("DWG") || Soft_Desk_Type[i].Contains("autocad") || Soft_Desk_Type[i].Contains("gstar"))//check if this software is Autocad or Gstar
                        {

                            dr["Cad Type"] = numb[0];
                            dr["Cad Key"] = numb[1];
                            dr["Cad Email"] = numb[2];
                            dr["Cad Password"] = numb[3];
                            dr["Cad Version"] = numb[4];

                        }
                        else if (Soft_Desk_Type[i].Contains("Windows")) //if this software type is Office 
                        {
                            dr["Windows Type"] = numb[0];
                            dr["Windows Key"] = numb[1];
                            dr["Windows Version"] = numb[4];
                        }
                        else //this mean this software is other 
                        {
                            if (Others_Software < 3)//if other software is less than or equal 3 Software
                            {
                                Others_Software++;
                                dr["Other" + Others_Software + " Type"] = numb[0];
                                dr["Other" + Others_Software + " Key"] = numb[1];
                                dr["Other" + Others_Software + " Email"] = numb[2];
                                dr["Other" + Others_Software + " Password"] = numb[3];
                                dr["Other" + Others_Software + " Version"] = numb[4];
                            }
                            else //if the number of other software is more than 3 show this message
                            {
                                MessageBox.Show("the others Softwares Greater than 3");
                            }

                        }

                    }
                    //dt2.Rows.Add(dr);//add the row to datatable
                    //Search_Grid.DataSource = dt2;//show this datatable in data grid view
                    //Search_Grid.Scroll += new System.Windows.Forms.ScrollEventHandler(ExportView_Scroll);
                    //Search_Grid.Width = 800;
                    //dataGridView2.Width = 800;
                    //Search_Grid.Columns[0].Width = 30;
                    //foreach (DataGridViewColumn c in Search_Grid.Columns)
                    //{
                    //    c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                    //    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //}
                }
                else if (Conditions_Class.Laptop_Found(Connection_Class.cn, Id_User) != null)//check if user own Laptop
                {
                    Numbers += 1;
                    //select User and Device From Data base
                    SqlCommand data_by_lap = new SqlCommand("Select  dbo.Users.Name,dbo.Users.Title,dbo.Users.Location,dbo.Laptops.Serial_Number_Lap,dbo.Laptops.Brand_Lap,dbo.Laptops.Model_Lap,dbo.Laptops.Processor_Lap,dbo.Laptops.Hard_Lap,dbo.Laptops.Ram_Lap,Laptops.Note_Lap  from dbo.Laptops,dbo.Users Where dbo.Users.Id_User= '" + Id_User + "' AND  dbo.Laptops.Id_User ='" + Id_User + "'   ;", Connection_Class.cn);
                    SqlDataReader sdr2 = data_by_lap.ExecuteReader();
                    string[] LapAndUser = new string[sdr2.FieldCount];
                    while (sdr2.Read())
                    {
                        for (int l = 0; l < sdr2.FieldCount; l++)
                        {
                            LapAndUser[l] = sdr2[l].ToString();
                        }
                    }

                    //create data new row in DataTable 

                    //fill data of user and device in data table
                    dr["#"] = Numbers;
                    dr["Name"] = LapAndUser[0];
                    dr["Title"] = LapAndUser[1];
                    dr["Location"] = LapAndUser[2];
                    dr["Device"] = "Laptop";
                    dr["Serial Number"] = LapAndUser[3];
                    dr["Brand"] = LapAndUser[4];
                    dr["Model"] = LapAndUser[5];
                    dr["Processor"] = LapAndUser[6];
                    dr["Ram"] = LapAndUser[7];
                    dr["Hard"] = LapAndUser[8];
                    dr["Note"] = LapAndUser[9];


                    SqlCommand Soft_Lap = new SqlCommand("SELECT dbo.Soft_Laptop.Id_Soft, dbo.Software.type from dbo.Soft_Laptop, dbo.Laptops, dbo.Software where dbo.Laptops.Id_User ='" + Id_User + "' AND dbo.Laptops.Id_Laptop = dbo.Soft_Laptop.Id_Laptop AND dbo.Soft_Laptop.Id_Soft = dbo.Software.Id_Soft ;", Connection_Class.cn);
                    Object S_Lap = Soft_Lap.ExecuteScalar();
                    List<Int32> Id_soft_Lap = new List<Int32>();
                    List<String> Soft_Lap_Type = new List<String>();
                    SqlDataReader sdr = Soft_Lap.ExecuteReader();
                    while (sdr.Read())
                    {
                        Id_soft_Lap.Add(sdr.GetInt32((sdr.GetOrdinal("Id_Soft"))));
                        Soft_Lap_Type.Add(sdr.GetString((sdr.GetOrdinal("type"))));
                    }
                    //for loop on all types of this Software 
                    for (int i = 0; i < Soft_Lap_Type.Count; i++)
                    {
                        //select software Details
                        SqlCommand Software_Details = new SqlCommand("SELECT type,[Key],Email,Password,Version from  dbo.Software where dbo.Software.Id_Soft ='" + Id_soft_Lap[i] + "' ;", Connection_Class.cn);
                        SqlDataReader SW_D = Software_Details.ExecuteReader();
                        string[] numb = new string[SW_D.FieldCount];
                        while (SW_D.Read())
                        {
                            for (int l = 0; l < SW_D.FieldCount; l++)
                            {
                                numb[l] = SW_D[l].ToString();
                            }
                        }
                        if (Soft_Lap_Type[i].Contains("Office") || Soft_Lap_Type[i].Contains("office")) //if this software type is Office 
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
                        else if (Soft_Lap_Type[i].Contains("trendmicro") || Soft_Lap_Type[i].Contains("Trendmicro"))//check if this software is antivirus
                        {

                            dr["AntiVirus Type"] = numb[0];
                            dr["AntiVirus Key"] = numb[1];
                            dr["AntiVirus Email"] = numb[2];
                            dr["AntiVirus Password"] = numb[3];
                            dr["AntiVirus Version"] = numb[4];

                        }
                        else if (Soft_Lap_Type[i].Contains("dwg") || Soft_Lap_Type[i].Contains("DWG") || Soft_Lap_Type[i].Contains("autocad") || Soft_Lap_Type[i].Contains("Autocad") || Soft_Lap_Type[i].Contains("Gstar") || Soft_Lap_Type[i].Contains("gstar"))//check if this software is Autocad or Gstar
                        {

                            dr["Cad Type"] = numb[0];
                            dr["Cad Key"] = numb[1];
                            dr["Cad Email"] = numb[2];
                            dr["Cad Password"] = numb[3];
                            dr["Cad Version"] = numb[4];

                        }
                        else if (Soft_Lap_Type[i].Contains("Windows") || Soft_Lap_Type[i].Contains("windows")) //if this software type is Office 
                        {
                            dr["Windows Type"] = numb[0];
                            dr["Windows Key"] = numb[1];
                            dr["Windows Version"] = numb[4];
                        }
                        else //this mean this software is other 
                        {
                            if (Others_Software < 3)//if other software is less than or equal 3 Software
                            {
                                Others_Software++;
                                dr["Other" + Others_Software + " Type"] = numb[0];
                                dr["Other" + Others_Software + " Key"] = numb[1];
                                dr["Other" + Others_Software + " Email"] = numb[2];
                                dr["Other" + Others_Software + " Password"] = numb[3];
                                dr["Other" + Others_Software + " Version"] = numb[4];
                            }
                            else //if the number of other software is more than 3 show this message
                            {
                                MessageBox.Show("the others Softwares Greater than 3");
                            }

                        }
                    }

                }

                //select Monitor Details from DataBase
                SqlCommand Monitor_Data = new SqlCommand("Select dbo.Monitor.Serial_Number_Monitor,dbo.Monitor.Brand_Monitor,dbo.Monitor.Model_Monitor,dbo.Monitor.Note_Monitor from dbo.Monitor Where dbo.Monitor.Id_User= '" + Id_User + "' ;", Connection_Class.cn);
                SqlDataReader sdr3 = Monitor_Data.ExecuteReader();
                string[] Monitor_C = new string[sdr3.FieldCount];
                while (sdr3.Read())
                {
                    for (int l = 0; l < sdr3.FieldCount; l++)
                    {
                        Monitor_C[l] = sdr3[l].ToString();
                    }
                }
                //fill Monitor data that selected
                dr["Monitor Serial Number"] = Monitor_C[0];
                dr["Monitor Brand"] = Monitor_C[1];
                dr["Monitor Model"] = Monitor_C[2];
                dr["Monitor Note"] = Monitor_C[3];



                dt2.Rows.Add(dr);//add the row to datatable
                Search_Grid.DataSource = dt2;//show this datatable in data grid view
                Search_Grid.Scroll += new System.Windows.Forms.ScrollEventHandler(Search_Grid_Scroll);
                Search_Grid.Width = 800;
                dataGridView2.Width = 800;
                Search_Grid.Columns[0].Width = 30;
                dataGridView2.Columns[0].Width = 30;
                foreach (DataGridViewColumn c in Search_Grid.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            else if (Check != null && Monitor1 == null && Laps == null)//if serial belong to Desktop
            {
                Numbers = 0;
                Id_User = Conditions_Class.Get_Id(Desktop_CMD);//get id User that belong this Serial Desktop
                int Others_Software = 0;//to Count the Other Softwares

                //add user and Device Column
                dt2.Columns.Add("#");
                dt2.Columns.Add("Name");
                dt2.Columns.Add("Title");
                dt2.Columns.Add("Location");
                dt2.Columns.Add("Device");
                dt2.Columns.Add("Serial Number");
                dt2.Columns.Add("Brand");
                dt2.Columns.Add("Model");
                dt2.Columns.Add("Processor");
                dt2.Columns.Add("Ram");
                dt2.Columns.Add("Hard");
                dt2.Columns.Add("Note");

                //add Monitor Columns
                dt2.Columns.Add("Monitor Serial Number");
                dt2.Columns.Add("Monitor Brand");
                dt2.Columns.Add("Monitor Model");
                dt2.Columns.Add("Monitor Note");

                //add Windows software columns
                dt2.Columns.Add("Windows Type");
                dt2.Columns.Add("Windows Key");
                dt2.Columns.Add("Windows Version");

                //add office software columns
                dt2.Columns.Add("Office Type");
                dt2.Columns.Add("Office Key");
                dt2.Columns.Add("Office Email");
                dt2.Columns.Add("Office Password");
                dt2.Columns.Add("Office Version");

                //add PDF software Columns
                dt2.Columns.Add("PDF Type");
                dt2.Columns.Add("PDF Key");
                dt2.Columns.Add("PDF Email");
                dt2.Columns.Add("PDF Password");
                dt2.Columns.Add("PDF Version");

                //add AntiVirus software columns
                dt2.Columns.Add("AntiVirus Type");
                dt2.Columns.Add("AntiVirus Key");
                dt2.Columns.Add("AntiVirus Email");
                dt2.Columns.Add("AntiVirus Password");
                dt2.Columns.Add("AntiVirus Version");

                //add Cad software columns
                dt2.Columns.Add("Cad Type");
                dt2.Columns.Add("Cad Key");
                dt2.Columns.Add("Cad Email");
                dt2.Columns.Add("Cad Password");
                dt2.Columns.Add("Cad Version");

                //add Other1 software columns
                dt2.Columns.Add("Other1 Type");
                dt2.Columns.Add("Other1 Key");
                dt2.Columns.Add("Other1 Email");
                dt2.Columns.Add("Other1 Password");
                dt2.Columns.Add("Other1 Version");

                //add Other2 software columns
                dt2.Columns.Add("Other2 Type");
                dt2.Columns.Add("Other2 Key");
                dt2.Columns.Add("Other2 Email");
                dt2.Columns.Add("Other2 Password");
                dt2.Columns.Add("Other2 Version");

                //add other3 software columns
                dt2.Columns.Add("Other3 Type");
                dt2.Columns.Add("Other3 Key");
                dt2.Columns.Add("Other3 Email");
                dt2.Columns.Add("Other3 Password");
                dt2.Columns.Add("Other3 Version");

                //////create header to datagrideview
                ////this.Search_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                ////this.Search_Grid.ColumnHeadersHeight = this.Search_Grid.ColumnHeadersHeight * 2;
                ////this.Search_Grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                ////this.Search_Grid.CellPainting += new DataGridViewCellPaintingEventHandler(Search_Grid_CellPainting);
                ////this.Search_Grid.Paint += new PaintEventHandler(Search_Grid_Paint);
                ////this.Search_Grid.Scroll += new ScrollEventHandler(Search_Grid_Scroll);
                ////this.Search_Grid.ColumnWidthChanged += new DataGridViewColumnEventHandler(Search_Grid_ColumnWidthChanged);

                //select User and Device From Data base
                Numbers += 1;
                SqlCommand data_by_Desktop = new SqlCommand("Select  dbo.Users.Name,dbo.Users.Title,dbo.Users.Location,dbo.Desktop.Serial_Number_Desk,dbo.Desktop.Brand_Desktop,dbo.Desktop.Model_Desktop,dbo.Desktop.Processor_Desktop,dbo.Desktop.Hard_Desktop,dbo.Desktop.Ram_Desktop,dbo.Desktop.Note_Desktop  from dbo.Desktop,dbo.Users Where dbo.Users.Id_User= '" + Id_User + "' AND  dbo.Desktop.Id_User ='" + Id_User + "'   ;", Connection_Class.cn);
                SqlDataReader sdr2 = data_by_Desktop.ExecuteReader();
                string[] DeskAndUser = new string[sdr2.FieldCount];
                while (sdr2.Read())
                {
                    for (int l = 0; l < sdr2.FieldCount; l++)
                    {
                        DeskAndUser[l] = sdr2[l].ToString();
                    }
                }
                //select Monitor Details from DataBase
                SqlCommand Monitor_Data = new SqlCommand("Select dbo.Monitor.Serial_Number_Monitor,dbo.Monitor.Brand_Monitor,dbo.Monitor.Model_Monitor,dbo.Monitor.Note_Monitor from dbo.Monitor Where dbo.Monitor.Id_User= '" + Id_User + "' ;", Connection_Class.cn);
                //create data new row in DataTable 
                DataRow dr = dt2.NewRow();
                if (Conditions_Class.Monitor_Found(Connection_Class.cn, Id_User) != null)//Check if user Own the Monitor
                {

                    SqlDataReader sdr3 = Monitor_Data.ExecuteReader();
                    string[] Monitor_C = new string[sdr3.FieldCount];
                    while (sdr3.Read())
                    {
                        for (int l = 0; l < sdr3.FieldCount; l++)
                        {
                            Monitor_C[l] = sdr3[l].ToString();
                        }
                    }
                    //fill Monitor data that selected
                    dr["Monitor Serial Number"] = Monitor_C[0];
                    dr["Monitor Brand"] = Monitor_C[1];
                    dr["Monitor Model"] = Monitor_C[2];
                    dr["Monitor Note"] = Monitor_C[3];
                }
                //select Ids and Types of the Software that own to this Desktop
                SqlCommand Soft_Lap = new SqlCommand("SELECT dbo.Soft_Desk.Id_Soft, dbo.Software.type from dbo.Soft_Desk, dbo.Desktop, dbo.Software where dbo.Desktop.Id_User ='" + Id_User + "' AND dbo.Desktop.Id_Desktop = dbo.Soft_Desk.Id_Desktop AND dbo.Soft_Desk.Id_Soft = dbo.Software.Id_Soft ;", Connection_Class.cn);
                List<Int32> Id_soft_Desk = new List<Int32>();
                List<String> Soft_Desk_Type = new List<String>();
                SqlDataReader sdr = Soft_Lap.ExecuteReader();
                while (sdr.Read())
                {
                    Id_soft_Desk.Add(sdr.GetInt32((sdr.GetOrdinal("Id_Soft"))));
                    Soft_Desk_Type.Add(sdr.GetString((sdr.GetOrdinal("type"))));
                }
                //for loop on all types of this Software 
                for (int i = 0; i < Soft_Desk_Type.Count; i++)
                {
                    //select software Details
                    SqlCommand Software_Details = new SqlCommand("SELECT type,[Key],Email,Password,Version from  dbo.Software where dbo.Software.Id_Soft ='" + Id_soft_Desk[i] + "' ;", Connection_Class.cn);
                    SqlDataReader SW_D = Software_Details.ExecuteReader();
                    string[] numb = new string[SW_D.FieldCount];
                    while (SW_D.Read())
                    {
                        for (int l = 0; l < SW_D.FieldCount; l++)
                        {
                            numb[l] = SW_D[l].ToString();
                        }
                    }
                    if (Soft_Desk_Type[i].Contains("Office") || Soft_Desk_Type[i].Contains("office")) //if this software type is Office 
                    {
                        //fill Office Columns
                        dr["Office Type"] = numb[0];
                        dr["Office Key"] = numb[1];
                        dr["Office Email"] = numb[2];
                        dr["Office Password"] = numb[3];
                        dr["Office Version"] = numb[4];
                    }
                    else if (Soft_Desk_Type[i].Contains("foxit") || Soft_Desk_Type[i].Contains("Foxit") || Soft_Desk_Type[i].Contains("Adobe") || Soft_Desk_Type[i].Contains("adobe")) //check if this Software type is PDF
                    {
                        //fill pdf Columns
                        dr["PDF Type"] = numb[0];
                        dr["PDF Key"] = numb[1];
                        dr["PDF Email"] = numb[2];
                        dr["PDF Password"] = numb[3];
                        dr["PDF Version"] = numb[4];

                    }
                    else if (Soft_Desk_Type[i].Contains("trendmicro") || Soft_Desk_Type[i].Contains("Trendmicro"))//check if this software is antivirus
                    {

                        dr["AntiVirus Type"] = numb[0];
                        dr["AntiVirus Key"] = numb[1];
                        dr["AntiVirus Email"] = numb[2];
                        dr["AntiVirus Password"] = numb[3];
                        dr["AntiVirus Version"] = numb[4];

                    }
                    else if (Soft_Desk_Type[i].Contains("dwg") || Soft_Desk_Type[i].Contains("DWG") || Soft_Desk_Type[i].Contains("autocad") || Soft_Desk_Type[i].Contains("Autocad") || Soft_Desk_Type[i].Contains("Gstar") || Soft_Desk_Type[i].Contains("gstar"))//check if this software is Autocad or Gstar
                    {

                        dr["Cad Type"] = numb[0];
                        dr["Cad Key"] = numb[1];
                        dr["Cad Email"] = numb[2];
                        dr["Cad Password"] = numb[3];
                        dr["Cad Version"] = numb[4];

                    }
                    else if (Soft_Desk_Type[i].Contains("Windows") || Soft_Desk_Type[i].Contains("windows")) //if this software type is Office 
                    {
                        dr["Windows Type"] = numb[0];
                        dr["Windows Key"] = numb[1];
                        dr["Windows Version"] = numb[4];
                    }
                    else //this mean this software is other 
                    {
                        if (Others_Software < 3)//if other software is less than or equal 3 Software
                        {
                            Others_Software++;
                            dr["Other" + Others_Software + " Type"] = numb[0];
                            dr["Other" + Others_Software + " Key"] = numb[1];
                            dr["Other" + Others_Software + " Email"] = numb[2];
                            dr["Other" + Others_Software + " Password"] = numb[3];
                            dr["Other" + Others_Software + " Version"] = numb[4];
                        }
                        else //if the number of other software is more than 3 show this message
                        {
                            MessageBox.Show("the others Softwares Greater than 3");
                        }

                    }
                }
                //fill data of user and device in data table
                dr["#"] = Numbers;
                dr["Name"] = DeskAndUser[0];
                dr["Title"] = DeskAndUser[1];
                dr["Location"] = DeskAndUser[2];
                dr["Device"] = "Desktop";
                dr["Serial Number"] = DeskAndUser[3];
                dr["Brand"] = DeskAndUser[4];
                dr["Model"] = DeskAndUser[5];
                dr["Processor"] = DeskAndUser[6];
                dr["Ram"] = DeskAndUser[7];
                dr["Hard"] = DeskAndUser[8];
                dr["Note"] = DeskAndUser[9];
                dt2.Rows.Add(dr);//add the row to datatable
                Search_Grid.DataSource = dt2;//show this datatable in data grid view
                Search_Grid.Scroll += new System.Windows.Forms.ScrollEventHandler(Search_Grid_Scroll);
                Search_Grid.Width = 800;
                dataGridView2.Width = 800;
                Search_Grid.Columns[0].Width = 30;
                dataGridView2.Columns[0].Width = 30;
                foreach (DataGridViewColumn c in Search_Grid.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

            }
            else
            {
                model_Grid.Visible = true;
                string message = "This Serial Number not Found";
                MessageBox.Show(message);
            }
           Connection_Class.Close();
            Serial_Number.Clear();
        }


        private void Search_Model_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            model_Grid.Visible = true;
            dt1.Columns.Clear();
            dt1.Rows.Clear();
            DataTable dt3 = new DataTable(); //create datatable
                                             //add user Details Columns

            string Model = Model_Search.Text;//Get input Serial
           // SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
            Connection_Class.DB_cn();
            Connection_Class.open();
            int Id_User; //initialize Id_User
            //select id from desktop if found
            SqlCommand Desktop_CMD = new SqlCommand("Select  Id_User from dbo.Desktop where dbo.Desktop.Model_Desktop = '" + Model + "'", Connection_Class.cn);
            Object Desktop = Desktop_CMD.ExecuteScalar();
            //select id from desktop if found
            SqlCommand LapS_CMD = new SqlCommand("Select Id_User from dbo.Laptops where Model_Lap = '" + Model + "' ", Connection_Class.cn);
            Object Laps = LapS_CMD.ExecuteScalar();
            //select id from desktop if found
            SqlCommand MonitorS_CMD = new SqlCommand("Select Id_User from dbo.Monitor where Model_Monitor = '" + Model + "' ", Connection_Class.cn);
            Object Monitor = MonitorS_CMD.ExecuteScalar();
            int Numbers;
            if (Laps != null && Desktop == null && Monitor == null)//model belong laptop
            {   Numbers=0; 
                //add user and Device Columns
                dt3.Columns.Add("#");
                dt3.Columns.Add("Name");
                dt3.Columns.Add("Title");
                dt3.Columns.Add("Location");
                dt3.Columns.Add("Device");
                dt3.Columns.Add("Serial Number");
                dt3.Columns.Add("Brand");
                dt3.Columns.Add("Model");
                dt3.Columns.Add("Processor");
                dt3.Columns.Add("Hard");
                dt3.Columns.Add("Note");
                //Count the Laptops with this model
                SqlCommand l = new SqlCommand("Select COUNT(*) from dbo.Laptops where Model_Lap = '" + Model + "' ", Connection_Class.cn);
                SqlDataReader sdr = LapS_CMD.ExecuteReader();
                while (sdr.Read())
                {
                    for (int i = 0; i < sdr.FieldCount; i++)//for loop on the all Laptop belong this model
                    {
                        Numbers += 1;
                        DataRow dr = dt3.NewRow(); //add new row to this data table
                        //select Users and Laptops Data From data base
                        SqlCommand Data = new SqlCommand("Select Name,Title,Location , Serial_Number_Lap,Brand_Lap,Model_Lap,Processor_Lap,Ram_Lap,Hard_Lap,Note_Lap from  dbo.Laptops  , dbo.Users   where  dbo.Laptops.Id_User = '" + sdr[i] + "' AND dbo.Users.Id_User='" + sdr[i] + "'", Connection_Class.cn);
                        SqlDataReader S = Data.ExecuteReader();
                        string[] numb = new string[S.FieldCount];
                        while (S.Read())
                        {
                            for (int m = 0; m < S.FieldCount; m++)
                            {
                                numb[m] = S[m].ToString();
                            }
                        }
                        //fill the datatable with user and device data
                        dr["#"] = Numbers;
                        dr["Name"] = numb[0];
                        dr["Title"] = numb[1];
                        dr["Location"] = numb[2];
                        dr["Device"] = "Laptop";
                        dr["Serial Number"] = numb[3];
                        dr["Brand"] = numb[4];
                        dr["Model"] = numb[5];
                        dr["Processor"] = numb[6];
                        dr["Hard"] = numb[7];
                        dr["Note"] = numb[8];
                        dt3.Rows.Add(dr);//add the row after fill in datatable
                    }
                }

                model_Grid.DataSource = dt3;//fill datagridview with datatable
                model_Grid.Width = 800;
                Search_Grid.Width = 800;
                model_Grid.Columns[0].Width = 30;
                foreach (DataGridViewColumn c in model_Grid.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                for (int o = 1; o < 11; o++)
                {
                    model_Grid.Columns[o].Width = 205;
                }

            }


            else if (Desktop != null && Laps == null && Monitor == null)//model belong to Desktop
            {
                Numbers = 0;
               // Console.WriteLine("DDDDDDDDD");
                //add user and Device Columns
                dt3.Columns.Add("#");
                dt3.Columns.Add("Name");
                dt3.Columns.Add("Title");
                dt3.Columns.Add("Location");
                dt3.Columns.Add("Device");
                dt3.Columns.Add("Serial Number");
                dt3.Columns.Add("Brand");
                dt3.Columns.Add("Model");
                dt3.Columns.Add("Processor");
                dt3.Columns.Add("Hard");
                dt3.Columns.Add("Note");
                //Count the Desktops with this model
                SqlCommand l = new SqlCommand("Select COUNT(*) from dbo.Desktop where Model_Desktop = '" + Model + "' ", Connection_Class.cn);
                SqlDataReader sdr = Desktop_CMD.ExecuteReader();
                while (sdr.Read())
                {
                    for (int i = 0; i < sdr.FieldCount; i++)//for loop on the all Laptop belong this model
                    {
                        Numbers += 1;
                        DataRow dr = dt3.NewRow();//add new row to this data table
                        //select Users and Desktops Data From data base
                        SqlCommand Data = new SqlCommand("Select  Name,Title,Location,Serial_Number_Desk, Brand_Desktop, Model_Desktop, Processor_Desktop, Ram_Desktop, Hard_Desktop, Note_Desktop from  dbo.Desktop  , dbo.Users   where  dbo.Desktop.Id_User = '" + sdr[i] + "' AND dbo.Users.Id_User='" + sdr[i] + "'", Connection_Class.cn);
                        SqlDataReader S = Data.ExecuteReader();
                        string[] numb = new string[S.FieldCount];
                        while (S.Read())
                        {
                            for (int m = 0; m < S.FieldCount; m++)
                            {
                                numb[m] = S[m].ToString();
                            }
                        }
                        //fill the datatable with user and device data
                        dr["#"] =Numbers;
                        dr["Name"] = numb[0];
                        dr["Title"] = numb[1];
                        dr["Location"] = numb[2];
                        dr["Device"] = "Desktop";
                        dr["Serial Number"] = numb[3];
                        dr["Brand"] = numb[4];
                        dr["Model"] = numb[5];
                        dr["Processor"] = numb[6];
                        dr["Hard"] = numb[7];
                        dr["Note"] = numb[8];
                        dt3.Rows.Add(dr);//add the row after fill in datatable
                    }
                }
                model_Grid.DataSource = dt3;//fill datagridview with datatable
                model_Grid.Width = 800;
                Search_Grid.Width = 800;
                model_Grid.Columns[0].Width = 30;
                foreach (DataGridViewColumn c in model_Grid.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                for (int o = 1; o < 11; o++)
                {
                    model_Grid.Columns[o].Width = 205;
                }

            }
            else if (Monitor != null && Laps == null && Desktop == null)//model belong laptop
            {
                Numbers = 0;
                //add user and Device Columns
                dt3.Columns.Add("#");
                dt3.Columns.Add("Name");
                dt3.Columns.Add("Title");
                dt3.Columns.Add("Location");
                dt3.Columns.Add("Serial Number");
                dt3.Columns.Add("Brand");
                dt3.Columns.Add("Model");
                dt3.Columns.Add("Note");
                //Count the Desktops with this model
                SqlCommand l = new SqlCommand("Select COUNT(*) from dbo.Monitor where Model_Monitor = '" + Model + "' ", Connection_Class.cn);
                SqlDataReader sdr = MonitorS_CMD.ExecuteReader();

                while (sdr.Read())
                {
                    for (int i = 0; i < sdr.FieldCount; i++)//for loop on the all Laptop belong this model
                    {
                        Numbers+= 1;
                        DataRow dr = dt3.NewRow();//add new row to this data table
                        //select Users and Monitors Data From data base
                        SqlCommand Data = new SqlCommand("Select  Name,Title,Location ,Serial_Number_Monitor,Brand_Monitor,Model_Monitor,Note_Monitor  from  dbo.Monitor  , dbo.Users   where  dbo.Monitor.Id_User = '" + sdr[i] + "' AND dbo.Users.Id_User='" + sdr[i] + "'", Connection_Class.cn);
                        SqlDataReader S = Data.ExecuteReader();
                        string[] numb = new string[S.FieldCount];
                        while (S.Read())
                        {
                            for (int m = 0; m < S.FieldCount; m++)
                            {
                                numb[m] = S[m].ToString();
                            }
                        }

                        //fill the datatable with user and device data
                        dr["#"] = Numbers;
                        dr["Name"] = numb[0];
                        dr["Title"] = numb[1];
                        dr["Location"] = numb[2];
                        dr["Serial Number"] = numb[3];
                        dr["Brand"] = numb[4];
                        dr["Model"] = numb[5];
                        dr["Note"] = numb[6];
                        dt3.Rows.Add(dr);//add the row after fill in datatable

                    }
                }


                model_Grid.DataSource = dt3;//fill datagridview with datatable
                model_Grid.Width = 800;
                Search_Grid.Width = 800;
                model_Grid.Columns[0].Width = 30;
                
                foreach (DataGridViewColumn c in model_Grid.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                for (int o = 1; o < 8; o++)
                {
                    model_Grid.Columns[o].Width = 250;
                    
                }
            }
            else
            {
                string message = "This Model not Found";
                MessageBox.Show(message);
            }
            Model_Search.Clear();
           Connection_Class.Close();
        }

        private void resizeChildControls()
        {
            //resize Buttons
            resizeControl(pictureBox1OriginalRect, pictureBox1);
            resizeControl(pictureBox2OriginalRect, pictureBox2);
            resizeControl(Label1OriginalRect, Serial_Lable);
            // resize gridviews 
            resizeControl(Label2OriginalRect, Model);
            resizeControl(textBox1OriginalRect, Serial_Number);
            resizeControl(textBox2OriginalRect, Model_Search);
            //logos
            resizeControl(button1OriginalRect, Search);
            resizeControl(button2OriginalRect, Search_Model);
            resizeControl(button3OriginalRect, Back);
            resizeControl(datagridviewOriginalRect, dataGridView2);
            resizeControl(datagridview1OriginalRect, Search_Grid);
            resizeControl(datagridview2OriginalRect, model_Grid);
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
        private void Hardware_Search_Resize(object sender, EventArgs e)
        {
            Search_Grid.Width = 1000;
            dataGridView2.Width = 1000;
            resizeChildControls();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        //    this.Search_Grid.ColumnHeadersHeight = 20;
        //    model_Grid.Visible = false;
        //    DataTable dt2 = new DataTable();
        //    dt1.Columns.Clear();
        //    dt1.Rows.Clear();
        //    string txt = Last_Letters.Text;//Get input Serial
        //    Connection_Class.DB_cn();                            //SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
        //    Connection_Class.open();
        //    SqlCommand cmd;//initialize Command
        //    int Id_User; //initialize Id_User

        //    //select id from desktop if found
        //    SqlCommand Desktop_CMD = new SqlCommand("Select  Id_User from dbo.Desktop where SUBSTRING(dbo.Desktop.Serial_Number_Desk,LEN(dbo.Desktop.Serial_Number_Desk)-3 , LEN(dbo.Desktop.Serial_Number_Desk))  = '" + txt + "'", Connection_Class.cn);
        //    Object Check = Desktop_CMD.ExecuteScalar();
        //    //select id from desktop if found
        //    SqlCommand LapS_CMD = new SqlCommand("Select Id_User from dbo.Laptops where SUBSTRING(Serial_Number_Lap,LEN(Serial_Number_Lap)-3 , LEN(Serial_Number_Lap)) = '" + txt + "' ", Connection_Class.cn);
        //    Object Laps = LapS_CMD.ExecuteScalar();

        //    //select id from desktop if found
        //    SqlCommand MonitorS_CMD = new SqlCommand("Select Id_User from dbo.Monitor where SUBSTRING(Serial_Number_Monitor,LEN(Serial_Number_Monitor)-3 , LEN(Serial_Number_Monitor)) = '" + txt + "' ", Connection_Class.cn);
        //    Object Monitor = MonitorS_CMD.ExecuteScalar();
        //    //////////////////////////////////////////////////////
        //    if (Check == null && Monitor == null && Laps != null)//check if serial belong to Laptop 
        //    {
        //        Id_User = Conditions_Class.Get_Id(LapS_CMD);//get id User that belong this Serial Laptop
        //        int Others_Software = 0;//to Count the Other Softwares
        //        //add user and Device Column
        //        dt2.Columns.Add("Name");
        //        dt2.Columns.Add("Title");
        //        dt2.Columns.Add("Location");
        //        dt2.Columns.Add("Device");
        //        dt2.Columns.Add("Serial Number");
        //        dt2.Columns.Add("Brand");
        //        dt2.Columns.Add("Model");
        //        dt2.Columns.Add("Processor");
        //        dt2.Columns.Add("Ram");
        //        dt2.Columns.Add("Hard");
        //        dt2.Columns.Add("Note");

        //        //add Monitor Columns
        //        dt2.Columns.Add("Monitor Serial Number");
        //        dt2.Columns.Add("Monitor Brand");
        //        dt2.Columns.Add("Monitor Model");
        //        dt2.Columns.Add("Monitor Note");


        //        //add Windows software columns
        //        dt2.Columns.Add("Windows Type");
        //        dt2.Columns.Add("Windows Key");
        //        dt2.Columns.Add("Windows Version");

        //        //add office software columns
        //        dt2.Columns.Add("Office Type");
        //        dt2.Columns.Add("Office Key");
        //        dt2.Columns.Add("Office Email");
        //        dt2.Columns.Add("Office Password");
        //        dt2.Columns.Add("Office Version");

        //        //add PDF software Columns
        //        dt2.Columns.Add("PDF Type");
        //        dt2.Columns.Add("PDF Key");
        //        dt2.Columns.Add("PDF Email");
        //        dt2.Columns.Add("PDF Password");
        //        dt2.Columns.Add("PDF Version");

        //        //add AntiVirus software columns
        //        dt2.Columns.Add("AntiVirus Type");
        //        dt2.Columns.Add("AntiVirus Key");
        //        dt2.Columns.Add("AntiVirus Email");
        //        dt2.Columns.Add("AntiVirus Password");
        //        dt2.Columns.Add("AntiVirus Version");

        //        //add Cad software columns
        //        dt2.Columns.Add("Cad Type");
        //        dt2.Columns.Add("Cad Key");
        //        dt2.Columns.Add("Cad Email");
        //        dt2.Columns.Add("Cad Password");
        //        dt2.Columns.Add("Cad Version");

        //        //add Other1 software columns
        //        dt2.Columns.Add("Other1 Type");
        //        dt2.Columns.Add("Other1 Key");
        //        dt2.Columns.Add("Other1 Email");
        //        dt2.Columns.Add("Other1 Password");
        //        dt2.Columns.Add("Other1 Version");

        //        //add Other2 software columns
        //        dt2.Columns.Add("Other2 Type");
        //        dt2.Columns.Add("Other2 Key");
        //        dt2.Columns.Add("Other2 Email");
        //        dt2.Columns.Add("Other2 Password");
        //        dt2.Columns.Add("Other2 Version");

        //        //add other3 software columns
        //        dt2.Columns.Add("Other3 Type");
        //        dt2.Columns.Add("Other3 Key");
        //        dt2.Columns.Add("Other3 Email");
        //        dt2.Columns.Add("Other3 Password");
        //        dt2.Columns.Add("Other3 Version");

        //        //create header to datagrideview
        //        this.Search_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        //        this.Search_Grid.ColumnHeadersHeight = this.Search_Grid.ColumnHeadersHeight * 2;
        //        this.Search_Grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
        //        this.Search_Grid.CellPainting += new DataGridViewCellPaintingEventHandler(Search_Grid_CellPainting);
        //        this.Search_Grid.Paint += new PaintEventHandler(Search_Grid_Paint);
        //        this.Search_Grid.Scroll += new ScrollEventHandler(Search_Grid_Scroll);
        //        this.Search_Grid.ColumnWidthChanged += new DataGridViewColumnEventHandler(Search_Grid_ColumnWidthChanged);

        //        //select User and Device From Data base
        //        SqlCommand data_by_lap = new SqlCommand("Select  dbo.Users.Name,dbo.Users.Title,dbo.Users.Location,dbo.Laptops.Serial_Number_Lap,dbo.Laptops.Brand_Lap,dbo.Laptops.Model_Lap,dbo.Laptops.Processor_Lap,dbo.Laptops.Hard_Lap,dbo.Laptops.Ram_Lap,Laptops.Note_Lap  from dbo.Laptops,dbo.Users Where dbo.Users.Id_User= '" + Id_User + "' AND  dbo.Laptops.Id_User ='" + Id_User + "'   ;", Connection_Class.cn);
        //        SqlDataReader sdr2 = data_by_lap.ExecuteReader();
        //        string[] LapAndUser = new string[sdr2.FieldCount];
        //        while (sdr2.Read())
        //        {
        //            for (int l = 0; l < sdr2.FieldCount; l++)
        //            {
        //                LapAndUser[l] = sdr2[l].ToString();
        //            }
        //        }
        //        //select Monitor Details from DataBase
        //        SqlCommand Monitor_Data = new SqlCommand("Select dbo.Monitor.Serial_Number_Monitor,dbo.Monitor.Brand_Monitor,dbo.Monitor.Model_Monitor,dbo.Monitor.Note_Monitor from dbo.Monitor Where dbo.Monitor.Id_User= '" + Id_User + "' ;", Connection_Class.cn);
        //        //create data new row in DataTable 
        //        DataRow dr = dt2.NewRow();
        //        if (Conditions_Class.Monitor_Found(Connection_Class.cn, Id_User) != null)//Check if user Own the Monitor
        //        {
                    
        //            SqlDataReader sdr3 = Monitor_Data.ExecuteReader();
        //            string[] Monitor_C = new string[sdr3.FieldCount];
        //            while (sdr3.Read())
        //            {
        //                for (int l = 0; l < sdr3.FieldCount; l++)
        //                {
        //                    Monitor_C[l] = sdr3[l].ToString();
        //                }
        //            }
        //            //fill Monitor data that selected
        //            dr["Monitor Serial Number"] = Monitor_C[0];
        //            dr["Monitor Brand"] = Monitor_C[1];
        //            dr["Monitor Model"] = Monitor_C[2];
        //            dr["Monitor Note"] = Monitor_C[3];
        //        }
        //        //select Ids and Types of the Software that own to this Laptop
        //        SqlCommand Soft_Lap = new SqlCommand("SELECT dbo.Soft_Laptop.Id_Soft, dbo.Software.type from dbo.Soft_Laptop, dbo.Laptops, dbo.Software where dbo.Laptops.Id_User ='" + Id_User + "' AND dbo.Laptops.Id_Laptop = dbo.Soft_Laptop.Id_Laptop AND dbo.Soft_Laptop.Id_Soft = dbo.Software.Id_Soft ;", Connection_Class.cn);
        //        Object S_Lap = Soft_Lap.ExecuteScalar();
        //        List<Int32> Id_soft_Lap = new List<Int32>();
        //        List<String> Soft_Lap_Type = new List<String>();
        //        SqlDataReader sdr = Soft_Lap.ExecuteReader();
        //        while (sdr.Read())
        //        {
        //            Id_soft_Lap.Add(sdr.GetInt32((sdr.GetOrdinal("Id_Soft"))));
        //            Soft_Lap_Type.Add(sdr.GetString((sdr.GetOrdinal("type"))));
        //        }
        //        //for loop on all types of this Software 
        //        for (int i = 0; i < Soft_Lap_Type.Count; i++)
        //        {
        //            //select software Details
        //            SqlCommand Software_Details = new SqlCommand("SELECT type,[Key],Email,Password,Version from  dbo.Software where dbo.Software.Id_Soft ='" + Id_soft_Lap[i] + "' ;", Connection_Class.cn);
        //            SqlDataReader SW_D = Software_Details.ExecuteReader();
        //            string[] numb = new string[SW_D.FieldCount];
        //            while (SW_D.Read())
        //            {
        //                for (int l = 0; l < SW_D.FieldCount; l++)
        //                {
        //                    numb[l] = SW_D[l].ToString();
        //                }
        //            }
        //            if (Soft_Lap_Type[i].Contains("Office")|| Soft_Lap_Type[i].Contains("office")) //if this software type is Office 
        //            {
        //                //fill Office Columns
        //                dr["Office Type"] = numb[0];
        //                dr["Office Key"] = numb[1];
        //                dr["Office Email"] = numb[2];
        //                dr["Office Password"] = numb[3];
        //                dr["Office Version"] = numb[4];
        //            }
        //            else if (Soft_Lap_Type[i].Contains("foxit")|| Soft_Lap_Type[i].Contains("Foxit") || Soft_Lap_Type[i].Contains("Adobe") || Soft_Lap_Type[i].Contains("adobe")) //check if this Software type is PDF
        //            {
        //                //fill pdf Columns
        //                dr["PDF Type"] = numb[0];
        //                dr["PDF Key"] = numb[1];
        //                dr["PDF Email"] = numb[2];
        //                dr["PDF Password"] = numb[3];
        //                dr["PDF Version"] = numb[4];

        //            }
        //            else if (Soft_Lap_Type[i].Contains("trendmicro")|| Soft_Lap_Type[i].Contains("Trendmicro"))//check if this software is antivirus
        //            {

        //                dr["AntiVirus Type"] = numb[0];
        //                dr["AntiVirus Key"] = numb[1];
        //                dr["AntiVirus Email"] = numb[2];
        //                dr["AntiVirus Password"] = numb[3];
        //                dr["AntiVirus Version"] = numb[4];

        //            }
        //            else if (Soft_Lap_Type[i].Contains("autocad")|| Soft_Lap_Type[i].Contains("Autocad") || Soft_Lap_Type[i].Contains("Gstar") || Soft_Lap_Type[i].Contains("gstar"))//check if this software is Autocad or Gstar
        //            {

        //                dr["Cad Type"] = numb[0];
        //                dr["Cad Key"] = numb[1];
        //                dr["Cad Email"] = numb[2];
        //                dr["Cad Password"] = numb[3];
        //                dr["Cad Version"] = numb[4];

        //            }
        //            else if (Soft_Lap_Type[i].Contains("Windows")|| Soft_Lap_Type[i].Contains("windows")) //if this software type is Office 
        //            {
        //                dr["Windows Type"] = numb[0];
        //                dr["Windows Key"] = numb[1];
        //                dr["Windows Version"] = numb[4];
        //            }
        //            else //this mean this software is other 
        //            {
        //                if (Others_Software < 3)//if other software is less than or equal 3 Software
        //                {
        //                    Others_Software++;
        //                    dr["Other" + Others_Software + " Type"] = numb[0];
        //                    dr["Other" + Others_Software + " Key"] = numb[1];
        //                    dr["Other" + Others_Software + " Email"] = numb[2];
        //                    dr["Other" + Others_Software + " Password"] = numb[3];
        //                    dr["Other" + Others_Software + " Version"] = numb[4];
        //                }
        //                else //if the number of other software is more than 3 show this message
        //                {
        //                    MessageBox.Show("the others Softwares Greater than 3");
        //                }

        //            }
        //        }
        //        //fill data of user and device in data table
        //        dr["Name"] = LapAndUser[0];
        //        dr["Title"] = LapAndUser[1];
        //        dr["Location"] = LapAndUser[2];
        //        dr["Device"] = "Laptop";
        //        dr["Serial Number"] = LapAndUser[3];
        //        dr["Brand"] = LapAndUser[4];
        //        dr["Model"] = LapAndUser[5];
        //        dr["Processor"] = LapAndUser[6];
        //        dr["Ram"] = LapAndUser[7];
        //        dr["Hard"] = LapAndUser[8];
        //        dr["Note"] = LapAndUser[9];
        //        dt2.Rows.Add(dr);//add the row to datatable
        //        Search_Grid.DataSource = dt2;//show this datatable in data grid view 
        //    }
        //    else if (Check != null && Monitor == null && Laps == null)//check if serial belong to Desktop 
        //    {
        //        Id_User = Conditions_Class.Get_Id(Desktop_CMD);//get id User that belong this Serial Desktop
        //        int Others_Software = 0;//to Count the Other Softwares
        //        //add user and Device Column
        //        dt2.Columns.Add("Name");
        //        dt2.Columns.Add("Title");
        //        dt2.Columns.Add("Location");
        //        dt2.Columns.Add("Device");
        //        dt2.Columns.Add("Serial Number");
        //        dt2.Columns.Add("Brand");
        //        dt2.Columns.Add("Model");
        //        dt2.Columns.Add("Processor");
        //        dt2.Columns.Add("Ram");
        //        dt2.Columns.Add("Hard");
        //        dt2.Columns.Add("Note");

        //        //add Monitor Columns
        //        dt2.Columns.Add("Monitor Serial Number");
        //        dt2.Columns.Add("Monitor Brand");
        //        dt2.Columns.Add("Monitor Model");
        //        dt2.Columns.Add("Monitor Note");


        //        //add Windows software columns
        //        dt2.Columns.Add("Windows Type");
        //        dt2.Columns.Add("Windows Key");
        //        dt2.Columns.Add("Windows Version");

        //        //add office software columns
        //        dt2.Columns.Add("Office Type");
        //        dt2.Columns.Add("Office Key");
        //        dt2.Columns.Add("Office Email");
        //        dt2.Columns.Add("Office Password");
        //        dt2.Columns.Add("Office Version");

        //        //add PDF software Columns
        //        dt2.Columns.Add("PDF Type");
        //        dt2.Columns.Add("PDF Key");
        //        dt2.Columns.Add("PDF Email");
        //        dt2.Columns.Add("PDF Password");
        //        dt2.Columns.Add("PDF Version");

        //        //add AntiVirus software columns
        //        dt2.Columns.Add("AntiVirus Type");
        //        dt2.Columns.Add("AntiVirus Key");
        //        dt2.Columns.Add("AntiVirus Email");
        //        dt2.Columns.Add("AntiVirus Password");
        //        dt2.Columns.Add("AntiVirus Version");

        //        //add Cad software columns
        //        dt2.Columns.Add("Cad Type");
        //        dt2.Columns.Add("Cad Key");
        //        dt2.Columns.Add("Cad Email");
        //        dt2.Columns.Add("Cad Password");
        //        dt2.Columns.Add("Cad Version");

        //        //add Other1 software columns
        //        dt2.Columns.Add("Other1 Type");
        //        dt2.Columns.Add("Other1 Key");
        //        dt2.Columns.Add("Other1 Email");
        //        dt2.Columns.Add("Other1 Password");
        //        dt2.Columns.Add("Other1 Version");

        //        //add Other2 software columns
        //        dt2.Columns.Add("Other2 Type");
        //        dt2.Columns.Add("Other2 Key");
        //        dt2.Columns.Add("Other2 Email");
        //        dt2.Columns.Add("Other2 Password");
        //        dt2.Columns.Add("Other2 Version");

        //        //add other3 software columns
        //        dt2.Columns.Add("Other3 Type");
        //        dt2.Columns.Add("Other3 Key");
        //        dt2.Columns.Add("Other3 Email");
        //        dt2.Columns.Add("Other3 Password");
        //        dt2.Columns.Add("Other3 Version");

        //        //create header to datagrideview
        //        this.Search_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        //        this.Search_Grid.ColumnHeadersHeight = this.Search_Grid.ColumnHeadersHeight * 2;
        //        this.Search_Grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
        //        this.Search_Grid.CellPainting += new DataGridViewCellPaintingEventHandler(Search_Grid_CellPainting);
        //        this.Search_Grid.Paint += new PaintEventHandler(Search_Grid_Paint);
        //        this.Search_Grid.Scroll += new ScrollEventHandler(Search_Grid_Scroll);
        //        this.Search_Grid.ColumnWidthChanged += new DataGridViewColumnEventHandler(Search_Grid_ColumnWidthChanged);

        //        //select User and Device From Data base
        //        SqlCommand data_by_Desktop = new SqlCommand("Select  dbo.Users.Name,dbo.Users.Title,dbo.Users.Location,dbo.Desktop.Serial_Number_Desk,dbo.Desktop.Brand_Desktop,dbo.Desktop.Model_Desktop,dbo.Desktop.Processor_Desktop,dbo.Desktop.Hard_Desktop,dbo.Desktop.Ram_Desktop,dbo.Desktop.Note_Desktop  from dbo.Desktop,dbo.Users Where dbo.Users.Id_User= '" + Id_User + "' AND  dbo.Desktop.Id_User ='" + Id_User + "'   ;", Connection_Class.cn);
        //        SqlDataReader sdr2 = data_by_Desktop.ExecuteReader();
        //        string[] DeskAndUser = new string[sdr2.FieldCount];
        //        while (sdr2.Read())
        //        {
        //            for (int l = 0; l < sdr2.FieldCount; l++)
        //            {
        //                DeskAndUser[l] = sdr2[l].ToString();
        //            }
        //        }
        //        //select Monitor Details from DataBase
        //        SqlCommand Monitor_Data = new SqlCommand("Select dbo.Monitor.Serial_Number_Monitor,dbo.Monitor.Brand_Monitor,dbo.Monitor.Model_Monitor,dbo.Monitor.Note_Monitor from dbo.Monitor Where dbo.Monitor.Id_User= '" + Id_User + "' ;", Connection_Class.cn);
        //        //create data new row in DataTable 
        //        DataRow dr = dt2.NewRow();
        //        if (Conditions_Class.Monitor_Found(Connection_Class.cn, Id_User) != null)//Check if user Own the Monitor
        //        {
                   
        //            SqlDataReader sdr3 = Monitor_Data.ExecuteReader();
        //            string[] Monitor_C = new string[sdr3.FieldCount];
        //            while (sdr3.Read())
        //            {
        //                for (int l = 0; l < sdr3.FieldCount; l++)
        //                {
        //                    Monitor_C[l] = sdr3[l].ToString();
        //                }
        //            }
        //            //fill Monitor data that selected
        //            dr["Monitor Serial Number"] = Monitor_C[0];
        //            dr["Monitor Brand"] = Monitor_C[1];
        //            dr["Monitor Model"] = Monitor_C[2];
        //            dr["Monitor Note"] = Monitor_C[3];
        //        }
        //        //select Ids and Types of the Software that own to this Desktop
        //        SqlCommand Soft_Lap = new SqlCommand("SELECT dbo.Soft_Desk.Id_Soft, dbo.Software.type from dbo.Soft_Desk, dbo.Desktop, dbo.Software where dbo.Desktop.Id_User ='" + Id_User + "' AND dbo.Desktop.Id_Desktop = dbo.Soft_Desk.Id_Desktop AND dbo.Soft_Desk.Id_Soft = dbo.Software.Id_Soft ;", Connection_Class.cn);
        //        List<Int32> Id_soft_Desk = new List<Int32>();
        //        List<String> Soft_Desk_Type = new List<String>();
        //        SqlDataReader sdr = Soft_Lap.ExecuteReader();
        //        while (sdr.Read())
        //        {
        //            Id_soft_Desk.Add(sdr.GetInt32((sdr.GetOrdinal("Id_Soft"))));
        //            Soft_Desk_Type.Add(sdr.GetString((sdr.GetOrdinal("type"))));
        //        }
        //        //for loop on all types of this Software 
        //        for (int i = 0; i < Soft_Desk_Type.Count; i++)
        //        {
        //            //select software Details
        //            SqlCommand Software_Details = new SqlCommand("SELECT type,[Key],Email,Password,Version from  dbo.Software where dbo.Software.Id_Soft ='" + Id_soft_Desk[i] + "' ;", Connection_Class.cn);
        //            SqlDataReader SW_D = Software_Details.ExecuteReader();
        //            string[] numb = new string[SW_D.FieldCount];
        //            while (SW_D.Read())
        //            {
        //                for (int l = 0; l < SW_D.FieldCount; l++)
        //                {
        //                    numb[l] = SW_D[l].ToString();
        //                }
        //            }
        //            if (Soft_Desk_Type[i].Contains("Office")|| Soft_Desk_Type[i].Contains("office")) //if this software type is Office 
        //            {
        //                //fill Office Columns
        //                dr["Office Type"] = numb[0];
        //                dr["Office Key"] = numb[1];
        //                dr["Office Email"] = numb[2];
        //                dr["Office Password"] = numb[3];
        //                dr["Office Version"] = numb[4];
        //            }
        //            else if (Soft_Desk_Type[i].Contains("foxit")|| Soft_Desk_Type[i].Contains("Foxit") || Soft_Desk_Type[i].Contains("Adobe") || Soft_Desk_Type[i].Contains("adobe")) //check if this Software type is PDF
        //            {
        //                //fill pdf Columns
        //                dr["PDF Type"] = numb[0];
        //                dr["PDF Key"] = numb[1];
        //                dr["PDF Email"] = numb[2];
        //                dr["PDF Password"] = numb[3];
        //                dr["PDF Version"] = numb[4];

        //            }
        //            else if (Soft_Desk_Type[i].Contains("trendmicro")|| Soft_Desk_Type[i].Contains("Trendmicro"))//check if this software is antivirus
        //            {

        //                dr["AntiVirus Type"] = numb[0];
        //                dr["AntiVirus Key"] = numb[1];
        //                dr["AntiVirus Email"] = numb[2];
        //                dr["AntiVirus Password"] = numb[3];
        //                dr["AntiVirus Version"] = numb[4];

        //            }
        //            else if (Soft_Desk_Type[i].Contains("autocad") || Soft_Desk_Type[i].Contains("Autocad") || Soft_Desk_Type[i].Contains("Gstar") || Soft_Desk_Type[i].Contains("gstar"))//check if this software is Autocad or Gstar
        //            {

        //                dr["Cad Type"] = numb[0];
        //                dr["Cad Key"] = numb[1];
        //                dr["Cad Email"] = numb[2];
        //                dr["Cad Password"] = numb[3];
        //                dr["Cad Version"] = numb[4];

        //            }
        //            else if (Soft_Desk_Type[i].Contains("Windows")|| Soft_Desk_Type[i].Contains("windows")) //if this software type is Office 
        //            {
        //                dr["Windows Type"] = numb[0];
        //                dr["Windows Key"] = numb[1];
        //                dr["Windows Version"] = numb[4];
        //            }
        //            else //this mean this software is other 
        //            {
        //                if (Others_Software < 3)//if other software is less than or equal 3 Software
        //                {
        //                    Others_Software++;
        //                    dr["Other" + Others_Software + " Type"] = numb[0];
        //                    dr["Other" + Others_Software + " Key"] = numb[1];
        //                    dr["Other" + Others_Software + " Email"] = numb[2];
        //                    dr["Other" + Others_Software + " Password"] = numb[3];
        //                    dr["Other" + Others_Software + " Version"] = numb[4];
        //                }
        //                else //if the number of other software is more than 3 show this message
        //                {
        //                    MessageBox.Show("the others Softwares Greater than 3");
        //                }

        //            }
        //        }
        //        //fill data of user and device in data table
        //        dr["Name"] = DeskAndUser[0];
        //        dr["Title"] = DeskAndUser[1];
        //        dr["Location"] = DeskAndUser[2];
        //        dr["Device"] = "Desktop";
        //        dr["Serial Number"] = DeskAndUser[3];
        //        dr["Brand"] = DeskAndUser[4];
        //        dr["Model"] = DeskAndUser[5];
        //        dr["Processor"] = DeskAndUser[6];
        //        dr["Ram"] = DeskAndUser[7];
        //        dr["Hard"] = DeskAndUser[8];
        //        dr["Note"] = DeskAndUser[9];
        //        dt2.Rows.Add(dr);//add the row to datatable
        //        Search_Grid.DataSource = dt2;//show this datatable in data grid view

        //    }
        //    else if (Check == null && Monitor != null && Laps == null)//check if serial belong to Monitor 
        //    {
        //        int Others_Software = 0;//to Count the Other Softwares
        //        //add user and Device Column
        //        dt2.Columns.Add("Name");
        //        dt2.Columns.Add("Title");
        //        dt2.Columns.Add("Location");
        //        dt2.Columns.Add("Device");
        //        dt2.Columns.Add("Serial Number");
        //        dt2.Columns.Add("Brand");
        //        dt2.Columns.Add("Model");
        //        dt2.Columns.Add("Processor");
        //        dt2.Columns.Add("Ram");
        //        dt2.Columns.Add("Hard");
        //        dt2.Columns.Add("Note");
        //        //add Monitor Columns
        //        dt2.Columns.Add("Monitor Serial Number");
        //        dt2.Columns.Add("Monitor Brand");
        //        dt2.Columns.Add("Monitor Model");
        //        dt2.Columns.Add("Monitor Note");

        //        //add Windows software columns
        //        dt2.Columns.Add("Windows Type");
        //        dt2.Columns.Add("Windows Key");
        //        dt2.Columns.Add("Windows Version");

        //        //add office software columns
        //        dt2.Columns.Add("Office Type");
        //        dt2.Columns.Add("Office Key");
        //        dt2.Columns.Add("Office Email");
        //        dt2.Columns.Add("Office Password");
        //        dt2.Columns.Add("Office Version");

        //        //add PDF software Columns
        //        dt2.Columns.Add("PDF Type");
        //        dt2.Columns.Add("PDF Key");
        //        dt2.Columns.Add("PDF Email");
        //        dt2.Columns.Add("PDF Password");
        //        dt2.Columns.Add("PDF Version");

        //        //add AntiVirus software columns
        //        dt2.Columns.Add("AntiVirus Type");
        //        dt2.Columns.Add("AntiVirus Key");
        //        dt2.Columns.Add("AntiVirus Email");
        //        dt2.Columns.Add("AntiVirus Password");
        //        dt2.Columns.Add("AntiVirus Version");

        //        //add Cad software columns
        //        dt2.Columns.Add("Cad Type");
        //        dt2.Columns.Add("Cad Key");
        //        dt2.Columns.Add("Cad Email");
        //        dt2.Columns.Add("Cad Password");
        //        dt2.Columns.Add("Cad Version");

        //        //add Other1 software columns
        //        dt2.Columns.Add("Other1 Type");
        //        dt2.Columns.Add("Other1 Key");
        //        dt2.Columns.Add("Other1 Email");
        //        dt2.Columns.Add("Other1 Password");
        //        dt2.Columns.Add("Other1 Version");

        //        //add Other2 software columns
        //        dt2.Columns.Add("Other2 Type");
        //        dt2.Columns.Add("Other2 Key");
        //        dt2.Columns.Add("Other2 Email");
        //        dt2.Columns.Add("Other2 Password");
        //        dt2.Columns.Add("Other2 Version");

        //        //add other3 software columns
        //        dt2.Columns.Add("Other3 Type");
        //        dt2.Columns.Add("Other3 Key");
        //        dt2.Columns.Add("Other3 Email");
        //        dt2.Columns.Add("Other3 Password");
        //        dt2.Columns.Add("Other3 Version");

        //        //create header to datagrideview
        //        this.Search_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        //        this.Search_Grid.ColumnHeadersHeight = this.Search_Grid.ColumnHeadersHeight * 2;
        //        this.Search_Grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
        //        this.Search_Grid.CellPainting += new DataGridViewCellPaintingEventHandler(Search_Grid_CellPainting);
        //        this.Search_Grid.Paint += new PaintEventHandler(Search_Grid_Paint);
        //        this.Search_Grid.Scroll += new ScrollEventHandler(Search_Grid_Scroll);
        //        this.Search_Grid.ColumnWidthChanged += new DataGridViewColumnEventHandler(Search_Grid_ColumnWidthChanged);

        //        Id_User = Conditions_Class.Get_Id(MonitorS_CMD);//get id User that belong this Serial Desktop
        //        DataRow dr = dt2.NewRow();
        //        if (Conditions_Class.Desktop_Found(Connection_Class.cn, Id_User) != null)//check if user own desktop
        //        {
        //            //select User and Device From Data base
        //            SqlCommand data_by_Desktop = new SqlCommand("Select  dbo.Users.Name,dbo.Users.Title,dbo.Users.Location,dbo.Desktop.Serial_Number_Desk,dbo.Desktop.Brand_Desktop,dbo.Desktop.Model_Desktop,dbo.Desktop.Processor_Desktop,dbo.Desktop.Hard_Desktop,dbo.Desktop.Ram_Desktop,dbo.Desktop.Note_Desktop  from dbo.Desktop,dbo.Users Where dbo.Users.Id_User= '" + Id_User + "' AND  dbo.Desktop.Id_User ='" + Id_User + "'   ;", Connection_Class.cn);
        //            SqlDataReader sdr2 = data_by_Desktop.ExecuteReader();
        //            string[] DeskAndUser = new string[sdr2.FieldCount];
        //            while (sdr2.Read())
        //            {
        //                for (int l = 0; l < sdr2.FieldCount; l++)
        //                {
        //                    DeskAndUser[l] = sdr2[l].ToString();
        //                }
        //            }
        //            //create data new row in DataTable 
                    
        //            //fill data of user and device in data table
        //            dr["Name"] = DeskAndUser[0];
        //            dr["Title"] = DeskAndUser[1];
        //            dr["Location"] = DeskAndUser[2];
        //            dr["Device"] = "Desktop";
        //            dr["Serial Number"] = DeskAndUser[3];
        //            dr["Brand"] = DeskAndUser[4];
        //            dr["Model"] = DeskAndUser[5];
        //            dr["Processor"] = DeskAndUser[6];
        //            dr["Ram"] = DeskAndUser[7];
        //            dr["Hard"] = DeskAndUser[8];
        //            dr["Note"] = DeskAndUser[9];
        //            //select Ids and Types of the Software that own to this Desktop
        //            SqlCommand Soft_Desk = new SqlCommand("SELECT dbo.Soft_Desk.Id_Soft, dbo.Software.type from dbo.Soft_Desk, dbo.Desktop, dbo.Software where dbo.Desktop.Id_User ='" + Id_User + "' AND dbo.Desktop.Id_Desktop = dbo.Soft_Desk.Id_Desktop AND dbo.Soft_Desk.Id_Soft = dbo.Software.Id_Soft ;", Connection_Class.cn);
        //            List<Int32> Id_soft_Desk = new List<Int32>();
        //            List<String> Soft_Desk_Type = new List<String>();
        //            SqlDataReader sdr = Soft_Desk.ExecuteReader();
        //            while (sdr.Read())
        //            {
        //                Id_soft_Desk.Add(sdr.GetInt32((sdr.GetOrdinal("Id_Soft"))));
        //                Soft_Desk_Type.Add(sdr.GetString((sdr.GetOrdinal("type"))));
        //            }
        //            //for loop on all types of this Software 
        //            for (int i = 0; i < Soft_Desk_Type.Count; i++)
        //            {
        //                //select software Details
        //                SqlCommand Software_Details = new SqlCommand("SELECT type,[Key],Email,Password,Version from  dbo.Software where dbo.Software.Id_Soft ='" + Id_soft_Desk[i] + "' ;", Connection_Class.cn);
        //                SqlDataReader SW_D = Software_Details.ExecuteReader();
        //                string[] numb = new string[SW_D.FieldCount];
        //                while (SW_D.Read())
        //                {
        //                    for (int l = 0; l < SW_D.FieldCount; l++)
        //                    {
        //                        numb[l] = SW_D[l].ToString();
        //                    }
        //                }
        //                if (Soft_Desk_Type[i].Contains("Office")) //if this software type is Office 
        //                {
        //                    //fill Office Columns
        //                    dr["Office Type"] = numb[0];
        //                    dr["Office Key"] = numb[1];
        //                    dr["Office Email"] = numb[2];
        //                    dr["Office Password"] = numb[3];
        //                    dr["Office Version"] = numb[4];
        //                }
        //                else if (Soft_Desk_Type[i].Contains("foxit")|| Soft_Desk_Type[i].Contains("Foxit") || Soft_Desk_Type[i].Contains("Adobe") || Soft_Desk_Type[i].Contains("adobe")) //check if this Software type is PDF
        //                {
        //                    //fill pdf Columns
        //                    dr["PDF Type"] = numb[0];
        //                    dr["PDF Key"] = numb[1];
        //                    dr["PDF Email"] = numb[2];
        //                    dr["PDF Password"] = numb[3];
        //                    dr["PDF Version"] = numb[4];

        //                }
        //                else if (Soft_Desk_Type[i].Contains("trendmicro")|| Soft_Desk_Type[i].Contains("Trendmicro"))//check if this software is antivirus
        //                {

        //                    dr["AntiVirus Type"] = numb[0];
        //                    dr["AntiVirus Key"] = numb[1];
        //                    dr["AntiVirus Email"] = numb[2];
        //                    dr["AntiVirus Password"] = numb[3];
        //                    dr["AntiVirus Version"] = numb[4];

        //                }
        //                else if (Soft_Desk_Type[i].Contains("autocad")|| Soft_Desk_Type[i].Contains("Autocad") || Soft_Desk_Type[i].Contains("Gstar") || Soft_Desk_Type[i].Contains("gstar"))//check if this software is Autocad or Gstar
        //                {

        //                    dr["Cad Type"] = numb[0];
        //                    dr["Cad Key"] = numb[1];
        //                    dr["Cad Email"] = numb[2];
        //                    dr["Cad Password"] = numb[3];
        //                    dr["Cad Version"] = numb[4];

        //                }
        //                else if (Soft_Desk_Type[i].Contains("Windows")|| Soft_Desk_Type[i].Contains("windows")) //if this software type is Office 
        //                {
        //                    dr["Windows Type"] = numb[0];
        //                    dr["Windows Key"] = numb[1];
        //                    dr["Windows Version"] = numb[4];
        //                }
        //                else //this mean this software is other 
        //                {
        //                    if (Others_Software < 3)//if other software is less than or equal 3 Software
        //                    {
        //                        Others_Software++;
        //                        dr["Other" + Others_Software + " Type"] = numb[0];
        //                        dr["Other" + Others_Software + " Key"] = numb[1];
        //                        dr["Other" + Others_Software + " Email"] = numb[2];
        //                        dr["Other" + Others_Software + " Password"] = numb[3];
        //                        dr["Other" + Others_Software + " Version"] = numb[4];
        //                    }
        //                    else //if the number of other software is more than 3 show this message
        //                    {
        //                        MessageBox.Show("the others Softwares Greater than 3");
        //                    }

        //                }
        //            }
        //        }
        //        else if (Conditions_Class.Laptop_Found(Connection_Class.cn, Id_User) != null)//check if user own Laptop
        //        {
        //            //select User and Device From Data base
        //            SqlCommand data_by_lap = new SqlCommand("Select  dbo.Users.Name,dbo.Users.Title,dbo.Users.Location,dbo.Laptops.Serial_Number_Lap,dbo.Laptops.Brand_Lap,dbo.Laptops.Model_Lap,dbo.Laptops.Processor_Lap,dbo.Laptops.Hard_Lap,dbo.Laptops.Ram_Lap,Laptops.Note_Lap  from dbo.Laptops,dbo.Users Where dbo.Users.Id_User= '" + Id_User + "' AND  dbo.Laptops.Id_User ='" + Id_User + "'   ;", Connection_Class.cn);
        //            SqlDataReader sdr2 = data_by_lap.ExecuteReader();
        //            string[] LapAndUser = new string[sdr2.FieldCount];
        //            while (sdr2.Read())
        //            {
        //                for (int l = 0; l < sdr2.FieldCount; l++)
        //                {
        //                    LapAndUser[l] = sdr2[l].ToString();
        //                }
        //            }

        //            //create data new row in DataTable 
                    
        //            //fill data of user and device in data table
        //            dr["Name"] = LapAndUser[0];
        //            dr["Title"] = LapAndUser[1];
        //            dr["Location"] = LapAndUser[2];
        //            dr["Device"] = "Laptop";
        //            dr["Serial Number"] = LapAndUser[3];
        //            dr["Brand"] = LapAndUser[4];
        //            dr["Model"] = LapAndUser[5];
        //            dr["Processor"] = LapAndUser[6];
        //            dr["Ram"] = LapAndUser[7];
        //            dr["Hard"] = LapAndUser[8];
        //            dr["Note"] = LapAndUser[9];


        //            SqlCommand Soft_Lap = new SqlCommand("SELECT dbo.Soft_Laptop.Id_Soft, dbo.Software.type from dbo.Soft_Laptop, dbo.Laptops, dbo.Software where dbo.Laptops.Id_User ='" + Id_User + "' AND dbo.Laptops.Id_Laptop = dbo.Soft_Laptop.Id_Laptop AND dbo.Soft_Laptop.Id_Soft = dbo.Software.Id_Soft ;", Connection_Class.cn);
        //            Object S_Lap = Soft_Lap.ExecuteScalar();
        //            List<Int32> Id_soft_Lap = new List<Int32>();
        //            List<String> Soft_Lap_Type = new List<String>();
        //            SqlDataReader sdr = Soft_Lap.ExecuteReader();
        //            while (sdr.Read())
        //            {
        //                Id_soft_Lap.Add(sdr.GetInt32((sdr.GetOrdinal("Id_Soft"))));
        //                Soft_Lap_Type.Add(sdr.GetString((sdr.GetOrdinal("type"))));
        //            }
        //            //for loop on all types of this Software 
        //            for (int i = 0; i < Soft_Lap_Type.Count; i++)
        //            {
        //                //select software Details
        //                SqlCommand Software_Details = new SqlCommand("SELECT type,[Key],Email,Password,Version from  dbo.Software where dbo.Software.Id_Soft ='" + Id_soft_Lap[i] + "' ;", Connection_Class.cn);
        //                SqlDataReader SW_D = Software_Details.ExecuteReader();
        //                string[] numb = new string[SW_D.FieldCount];
        //                while (SW_D.Read())
        //                {
        //                    for (int l = 0; l < SW_D.FieldCount; l++)
        //                    {
        //                        numb[l] = SW_D[l].ToString();
        //                    }
        //                }
        //                if (Soft_Lap_Type[i].Contains("Office")) //if this software type is Office 
        //                {
        //                    //fill Office Columns
        //                    dr["Office Type"] = numb[0];
        //                    dr["Office Key"] = numb[1];
        //                    dr["Office Email"] = numb[2];
        //                    dr["Office Password"] = numb[3];
        //                    dr["Office Version"] = numb[4];
        //                }
        //                else if (Soft_Lap_Type[i].Contains("foxit") || Soft_Lap_Type[i].Contains("adobe")) //check if this Software type is PDF
        //                {
        //                    //fill pdf Columns
        //                    dr["PDF Type"] = numb[0];
        //                    dr["PDF Key"] = numb[1];
        //                    dr["PDF Email"] = numb[2];
        //                    dr["PDF Password"] = numb[3];
        //                    dr["PDF Version"] = numb[4];

        //                }
        //                else if (Soft_Lap_Type[i].Contains("trendmicro"))//check if this software is antivirus
        //                {

        //                    dr["AntiVirus Type"] = numb[0];
        //                    dr["AntiVirus Key"] = numb[1];
        //                    dr["AntiVirus Email"] = numb[2];
        //                    dr["AntiVirus Password"] = numb[3];
        //                    dr["AntiVirus Version"] = numb[4];

        //                }
        //                else if (Soft_Lap_Type[i].Contains("autocad") || Soft_Lap_Type[i].Contains("gstar"))//check if this software is Autocad or Gstar
        //                {

        //                    dr["Cad Type"] = numb[0];
        //                    dr["Cad Key"] = numb[1];
        //                    dr["Cad Email"] = numb[2];
        //                    dr["Cad Password"] = numb[3];
        //                    dr["Cad Version"] = numb[4];

        //                }
        //                else if (Soft_Lap_Type[i].Contains("Windows")) //if this software type is Office 
        //                {
        //                    dr["Windows Type"] = numb[0];
        //                    dr["Windows Key"] = numb[1];
        //                    dr["Windows Version"] = numb[4];
        //                }
        //                else //this mean this software is other 
        //                {
        //                    if (Others_Software < 3)//if other software is less than or equal 3 Software
        //                    {
        //                        Others_Software++;
        //                        dr["Other" + Others_Software + " Type"] = numb[0];
        //                        dr["Other" + Others_Software + " Key"] = numb[1];
        //                        dr["Other" + Others_Software + " Email"] = numb[2];
        //                        dr["Other" + Others_Software + " Password"] = numb[3];
        //                        dr["Other" + Others_Software + " Version"] = numb[4];
        //                    }
        //                    else //if the number of other software is more than 3 show this message
        //                    {
        //                        MessageBox.Show("the others Softwares Greater than 3");
        //                    }

        //                }
        //            }
                    
        //        }




        //        //select Monitor Details from DataBase
        //        SqlCommand Monitor_Data = new SqlCommand("Select dbo.Monitor.Serial_Number_Monitor,dbo.Monitor.Brand_Monitor,dbo.Monitor.Model_Monitor,dbo.Monitor.Note_Monitor from dbo.Monitor Where dbo.Monitor.Id_User= '" + Id_User + "' ;", Connection_Class.cn);
        //        SqlDataReader sdr3 = Monitor_Data.ExecuteReader();
        //        string[] Monitor_C = new string[sdr3.FieldCount];
        //        while (sdr3.Read())
        //        {
        //            for (int l = 0; l < sdr3.FieldCount; l++)
        //            {
        //                Monitor_C[l] = sdr3[l].ToString();
        //            }
        //        }
        //        //fill Monitor data that selected
        //        dr["Monitor Serial Number"] = Monitor_C[0];
        //        dr["Monitor Brand"] = Monitor_C[1];
        //        dr["Monitor Model"] = Monitor_C[2];
        //        dr["Monitor Note"] = Monitor_C[3];
        //        dt2.Rows.Add(dr);//add the row to datatable
        //        Search_Grid.DataSource = dt2;//show this datatable in data grid view

        //    }
        //    else
        //    {
        //        MessageBox.Show("this serial Don't found in DataBase");
        //        model_Grid.Visible = true;
        //    }
        //   Connection_Class.Close();
        //    Last_Letters.Clear();
        //
        }
        private void Search_Grid_Scroll(object sender, ScrollEventArgs e)
        {
            dataGridView2.FirstDisplayedScrollingColumnIndex = Search_Grid.FirstDisplayedScrollingColumnIndex;

        }

        //private void Search_Grid_Paint(object sender, PaintEventArgs e)
        //{
        //    int[] Counter_Cells = { 3, 0, 0, 8, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 3, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0 };
        //    string[] Details = { "User", "", "", "Device", "", "", "", "", "", "", "", "Monitor", "", "", "", "Windows", "", "", "Office", "", "", "", "", "PDF", "", "", "", "", "AntiVirus", "", "", "", "", "Cad & Gstar", "", "", "", "", "Others", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };

        //    for (int j = 0; j < 53;)
        //    {

        //        Rectangle r1 = this.Search_Grid.GetCellDisplayRectangle(j, -1, true);
        //        int w2 = 30;

        //        r1.X += 1;
        //        r1.Y += 1;
        //        r1.Width = r1.Width + w2 - 2;
        //        r1.Height = r1.Height / 2 - 2;
        //        e.Graphics.FillRectangle(new SolidBrush(this.Search_Grid.ColumnHeadersDefaultCellStyle.BackColor), r1);
        //        StringFormat format = new StringFormat();
        //        format.Alignment = StringAlignment.Center;
        //        format.LineAlignment = StringAlignment.Center;
        //        e.Graphics.DrawString(Details[j],
        //        this.Search_Grid.ColumnHeadersDefaultCellStyle.Font,
        //        new SolidBrush(this.Search_Grid.ColumnHeadersDefaultCellStyle.ForeColor),
        //        r1,
        //        format);
        //        j += 1;
        //    }
        //}

        //private void Search_Grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        //{
        //    if (e.RowIndex == -1 && e.ColumnIndex > -1)
        //    {
        //        Rectangle r2 = e.CellBounds;
        //        r2.Y += e.CellBounds.Height / 2;
        //        r2.Height = e.CellBounds.Height / 2;
        //        e.PaintBackground(r2, true);
        //        e.PaintContent(r2);
        //        e.Handled = true;
        //    }
        //}

        //private void Search_Grid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        //{

        //    Rectangle rtHeader = this.Search_Grid.DisplayRectangle;
        //    rtHeader.Height = this.Search_Grid.ColumnHeadersHeight / 2;
        //    this.Search_Grid.Invalidate(rtHeader);

        //}

        private void Last_Letters_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void model_Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}

