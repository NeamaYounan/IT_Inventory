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
//using System.Web.ui.WebControls;

namespace inventory2
{
    public partial class Search_Name : Form
    {
        private Size formOriginalSize;
        //pics
        private Rectangle pictureBox1OriginalRect;
        private Rectangle pictureBox2OriginalRect;
        //labels
        private Rectangle Label1OriginalRect;
        //textbox
        private Rectangle textBox1OriginalRect;
        //buttons
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        //datagride
        private Rectangle datagridviewOriginalRect;
        private Rectangle datagridview1OriginalRect;
        private Rectangle datagridview2OriginalRect;
        public Search_Name()
        {
            InitializeComponent();
            using (SqlConnection con = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;"))
            {
                Connection_Class.DB_cn();
                Connection_Class.open();
                SqlCommand cmd = new SqlCommand("SELECT Name FROM dbo.Users", Connection_Class.cn);
                
                SqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    MyCollection.Add(reader.GetString(0));
                }
                User_Name.AutoCompleteCustomSource = MyCollection;
                Connection_Class.Close();

            }

        }
        public static int Cad_Counter = 0;
        //neama DB=DESKTOP-OG2M2CI
        //Katren DB=DESKTOP-9QTGSEL
        //SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");

        private void Search_Name_Load(object sender, EventArgs e)
        {
                //dataGridView2.Rows.RemoveAt(0);
           
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            //pictureBox1OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);

            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            pictureBox1OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            pictureBox2OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            Label1OriginalRect = new Rectangle(label1.Location.X, label1.Location.Y, label1.Width, label1.Height);
            textBox1OriginalRect = new Rectangle(User_Name.Location.X, User_Name.Location.Y, User_Name.Width, User_Name.Height);
            button1OriginalRect = new Rectangle(SearchName.Location.X, SearchName.Location.Y, SearchName.Width, SearchName.Height);
            button2OriginalRect = new Rectangle(Back.Location.X, Back.Location.Y, Back.Width, Back.Height);
            datagridviewOriginalRect = new Rectangle(dataGridView1.Location.X, dataGridView1.Location.Y, dataGridView1.Width, dataGridView1.Height);
            datagridview1OriginalRect = new Rectangle(Search_Grid.Location.X, Search_Grid.Location.Y, Search_Grid.Width, Search_Grid.Height);
            datagridview2OriginalRect = new Rectangle(dataGridView2.Location.X, dataGridView2.Location.Y, dataGridView2.Width, dataGridView2.Height);
        }

        public static int Monitor_Found=0;
        private void SearchName_Click(object sender, EventArgs e)
        {
            
            Connection_Class.DB_cn();
            Connection_Class.open();
            int Numbers;
            
            this.Search_Grid.ColumnHeadersHeight = 40;

            string name = User_Name.Text;
            SqlCommand User = new SqlCommand("Select Id_User from dbo.Users where Lower(dbo.Users.Name) = '" + name.ToLower() + "'", Connection_Class.cn);//Command Query                   

            object user_name = User.ExecuteScalar();
            if (user_name == null) //this user not found in database
            {
                dataGridView1.Visible = true;
                MessageBox.Show("This name doesn't exist"); //show massage to not found user
            }
            else //this user found in database
            {
                Numbers = 0;
                dataGridView1.Visible = false;
                int Id_User = Conditions_Class.Get_Id(User);//Get_Id_user 
                DataTable dt1 = new DataTable(); //create datatable
                //add user Details Columns
                dt1.Columns.Add("#");
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
                   
                        //Change Monitor Flag From 0 to 1 
                        Monitor_Found = 1;
                        //add Monitor Columns
                        
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
                    Numbers += 1;
                       

                    //this.Search_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    //    this.Search_Grid.ColumnHeadersHeight = this.Search_Grid.ColumnHeadersHeight * 2;
                    //    this.Search_Grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                    //    this.Search_Grid.CellPainting += new DataGridViewCellPaintingEventHandler(Search_Grid_CellPainting);
                    //    this.Search_Grid.Paint += new PaintEventHandler(Search_Grid_Paint);
                    //    this.Search_Grid.Scroll += new ScrollEventHandler(Search_Grid_Scroll);
                    //    this.Search_Grid.ColumnWidthChanged += new DataGridViewColumnEventHandler(Search_Grid_ColumnWidthChanged);
                    
                   
                   

                    if (Conditions_Class.Laptop_Found(Connection_Class.cn, Id_User) != null) //check if user have laptop tp add Laptop Details and its Software in it in new Row
                    {
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
                        dr["#"] = Numbers;
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
                        dr[" Note"] = numb1[5];
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
                            else if (Soft_Lap_Type[i].Contains("foxit") || Soft_Lap_Type[i].Contains("Foxit") || Soft_Lap_Type[i].Contains("adobe") || Soft_Lap_Type[i].Contains("Adobe") ) //check if this Software type is PDF
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
                            else if (Soft_Lap_Type[i].Contains("dwg") || Soft_Lap_Type[i].Contains("DWG") || Soft_Lap_Type[i].Contains("autocad") || Soft_Lap_Type[i].Contains("Autocad") || Soft_Lap_Type[i].Contains("gstar") || Soft_Lap_Type[i].Contains("Gstar"))
                            {

                                dr["Cad Type"] = numb[0];
                                dr["Cad Key"] = numb[1];
                                dr["Cad Email"] = numb[2];
                                dr["Cad Password"] = numb[3];
                                dr["Cad Version"] = numb[4];

                            }
                            else if (Soft_Lap_Type[i].Contains("Windows")|| Soft_Lap_Type[i].Contains("Windows")) //if this software type is Office 
                            {
                                dr["Windows Type"]= numb[0];
                               dr["Windows Key"]=numb[1];
                                dr["Windows Version"]= numb[4];
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
                        Search_Grid.DataSource = dt1;
                        Search_Grid.Scroll += new System.Windows.Forms.ScrollEventHandler(Search_Grid_Scroll);
                        
                        Search_Grid.Width = 700;
                        dataGridView2.Width = 700;
                        Search_Grid.Columns[0].Width = 30;
                        dataGridView2.Columns[0].Width = 30;
                        foreach (DataGridViewColumn c in Search_Grid.Columns)
                        {
                            c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                            c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                        
                        dt1 = null;
                        
                    }
                    if(Conditions_Class.Desktop_Found(Connection_Class.cn, Id_User) != null)//check if user own Desktop
                    {
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
                        dr["#"] = Numbers;
                        dr["Name"] = numb2[0];
                        dr["Title"] = numb2[1];
                        dr["Location"] = numb2[2];
                        //Fill device Type 
                        dr["Device"] = "Laptop";
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
                        dr[" Ram"] = numb1[4];
                        dr["Hard"] = numb1[5];
                        dr[" Note"] = numb1[5];
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
                            else if (Soft_Lap_Type[i].Contains("foxit") || Soft_Lap_Type[i].Contains("Foxit") || Soft_Lap_Type[i].Contains("adobe")|| Soft_Lap_Type[i].Contains("Adobe")) //check if this Software type is PDF
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
                            else if (Soft_Lap_Type[i].Contains("dwg") || Soft_Lap_Type[i].Contains("DWG") || Soft_Lap_Type[i].Contains("autocad")|| Soft_Lap_Type[i].Contains("Autocad") || Soft_Lap_Type[i].Contains("Gstar") || Soft_Lap_Type[i].Contains("gstar"))
                            {

                                dr["Cad Type"] = numb[0];
                                dr["Cad Key"] = numb[1];
                                dr["Cad Email"] = numb[2];
                                dr["Cad Password"] = numb[3];
                                dr["Cad Version"] = numb[4];

                            }
                            else if (Soft_Lap_Type[i].Contains("Windows")|| Soft_Lap_Type[i].Contains("windows")) //if this software type is Office 
                            {
                               dr["Windows Type"]= numb[0];
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
                        Search_Grid.DataSource = dt1;
                        Search_Grid.Scroll += new System.Windows.Forms.ScrollEventHandler(Search_Grid_Scroll);

                        Search_Grid.Width = 700;
                        dataGridView2.Width = 700;
                        //Search_Grid.Columns[0].Width = 30;
                        dataGridView2.Columns[0].Width = 30;
                        Search_Grid.Columns[0].Width = 30;
                        foreach (DataGridViewColumn c in Search_Grid.Columns)
                        {
                            c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                            c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }

                    }

                }
                else
                {
                    dataGridView1.Visible = true;
                    MessageBox.Show("This user don't own any device");
                }
            }
           Connection_Class.Close();
        }
        
    


      
    


        private void Back_Click(object sender, EventArgs e)
        {
            Search_Options search = new Search_Options();
            search.Show();
            this.Hide();
        }
        private void Search_Grid_Scroll(object sender, ScrollEventArgs e)
        {
            dataGridView2.FirstDisplayedScrollingColumnIndex = Search_Grid.FirstDisplayedScrollingColumnIndex;
        }

        private void Search_Grid_Paint(object sender, PaintEventArgs e)
        {
            //int[] Counter_Cells = { 3,0,0, 8,0,0,0,0,0,0, 4,0,0,0, 3,0,0, 5,0,0,0,0, 5,0,0,0,0, 5,0,0,0,0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5 ,0, 0, 0, 0};
            string[] monthes = { "","User", "", "", "Device", "", "", "", "", "", "", "", "Monitor", "", "", "", "Windows", "", "", "Office", "", "", "", "", "PDF", "", "", "", "", "AntiVirus", "", "", "", "", "Cad & Gstar", "", "", "", "", "Others", "", "", "", "", "", "", "", "", "", "","","","","" };
            for (int j = 0; j < 54;)
            {
                
                Rectangle r1 = this.Search_Grid.GetCellDisplayRectangle(j, -1, true);
                int w2 =30;

                r1.X += 1;
                r1.Y += 1;
                r1.Width = r1.Width + w2 - 2;
                r1.Height = r1.Height / 2 - 2;
                e.Graphics.FillRectangle(new SolidBrush(this.Search_Grid.ColumnHeadersDefaultCellStyle.BackColor), r1);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(monthes[j],
                this.Search_Grid.ColumnHeadersDefaultCellStyle.Font= new Font("Arial", 14F, FontStyle.Bold,GraphicsUnit.Pixel),
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Back_Click_1(object sender, EventArgs e)
        {

            Search_Options search = new Search_Options();
            search.Show();
            this.Hide();
        }

        private void resizeChildControls()
        {
            //resize Buttons
            resizeControl(pictureBox1OriginalRect, pictureBox2);
            resizeControl(pictureBox2OriginalRect, pictureBox1);
            resizeControl(Label1OriginalRect, label1);
            // resize gridviews 
            resizeControl(textBox1OriginalRect, User_Name);
            resizeControl(button1OriginalRect, SearchName);
            resizeControl(button2OriginalRect, Back);
            resizeControl(datagridviewOriginalRect, dataGridView1);
            resizeControl(datagridview1OriginalRect, Search_Grid);
            resizeControl(datagridview2OriginalRect, dataGridView2);

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

        private void Search_Name_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
    }
}

