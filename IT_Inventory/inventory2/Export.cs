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
using System.Data;
using System.IO;


namespace inventory2
{
    public partial class Export : Form
    {
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        private Rectangle button3OriginalRect;

        private Rectangle datagridviewOriginalRect;
        private Rectangle datagridview1OriginalRect;
        private Rectangle datagridview2OriginalRect;

        private Rectangle datagridview3OriginalRect;
        private Rectangle datagridview4OriginalRect;
        // 
        private Size formOriginalSize;
        public List<Int32> Ids_User = new List<Int32>();
        DataTable dt1 = new DataTable();
        public Export()
        {
            InitializeComponent();



        }
        //SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
        public static int Monitor_Found = 0;
        
        private void ExportView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void exportExcel_Click(object sender, EventArgs e)
        {
            int cols;
            //open file 
            StreamWriter wr = new StreamWriter(@"C:\Users\Public\Export.xls", false, Encoding.UTF8);

            //determine the number of columns and write columns to file 
            cols = ExportView.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                wr.Write(ExportView.Columns[i].Name.ToString().ToUpper() + ",");
            }
            wr.WriteLine();

            //write rows to excel file
            for (int i = 0; i < (ExportView.Rows.Count); i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (ExportView.Rows[i].Cells[j].Value != null)
                    {
                        wr.Write(ExportView.Rows[i].Cells[j].Value + ",");
                    }
                    else
                    {
                        wr.Write(",");
                    }
                }

                wr.WriteLine();
            }
            //close file
            wr.Close();
            MessageBox.Show(String.Join(Environment.NewLine, "Your Excel File is Saved in That Location", "C:\\Users\\Public\\Export.xlsx"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inventory_CURD inventory = new Inventory_CURD();
            inventory.Show();
            this.Hide();
        }

        private void stock_Click(object sender, EventArgs e)
        {
            ExportView.Visible = false;
            dataGridView1.Visible = true;
            int numbers = 0;
            //SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
            Connection_Class.DB_cn();
            Connection_Class.open();
            DataTable dt = new DataTable();

            //List<string> details = new List<string>();
            dt.Columns.Add("#");
            dt.Columns.Add("Type");
            dt.Columns.Add("Brand");
            dt.Columns.Add("Model");
            dt.Columns.Add("Serial_Number");
            dt.Columns.Add("Processor");
            dt.Columns.Add("Hard");
            dt.Columns.Add("Ram");
            dt.Columns.Add("Version");
            dt.Columns.Add("Key");
            dt.Columns.Add("Email");
            dt.Columns.Add("Password");
            dt.Columns.Add("Note");

            List<Int32> Id_spare = new List<Int32>();
            SqlCommand spare_Ids = new SqlCommand("Select  Id_Spare from dbo.Spare ", Connection_Class.cn);//Select id Users own this software
            SqlDataReader sdr1 = spare_Ids.ExecuteReader();
            while (sdr1.Read())

            {

                Id_spare.Add(sdr1.GetInt32((sdr1.GetOrdinal("Id_Spare"))));


            }
            if (Id_spare.Count == 0)
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                for (int s = 0; s < Id_spare.Count; s++)
                {
                    numbers += 1;
            //Where Spare.Id_Spare = '" + Id_spare[s] + "'
                    SqlCommand Spare_Type = new SqlCommand("Select Type,Brand,Model,Serial_Number,Processor,Hard,Ram,Version,[Key],Email,Password,Note from dbo.Spare Where Spare.Id_Spare = '" + Id_spare[s] + "' ", Connection_Class.cn);//Command Query     
            SqlDataReader sdr2 = Spare_Type.ExecuteReader();
            string[] numb2 = new string[sdr2.FieldCount];
            while (sdr2.Read())
            {
                for (int l = 0; l < sdr2.FieldCount; l++)
                {
                    numb2[l] = sdr2[l].ToString();
                }
            }
            DataRow dr = dt.NewRow();
            //Fill User Details
            dr["#"] = numbers;
            dr["Type"] = numb2[0];
            dr["Brand"] = numb2[1];
            dr["Model"] = numb2[2];
            //Fill device Type 
            dr["Serial_Number"] = numb2[3];
            dr["Processor"] = numb2[4];
            dr["Hard"] = numb2[5];
            dr["Ram"] = numb2[6];
            dr["Version"] = numb2[7];
            dr["Key"] = numb2[8];
            dr["Email"] = numb2[9];
            dr["Password"] = numb2[10];
            dr["Note"] = numb2[11];
            dt.Rows.Add(dr);
                    //SqlDataAdapter da = new SqlDataAdapter();
                    //da.SelectCommand = Spare_Type;

                    //da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Width = 1100;
                    dataGridView1.Columns[0].Width = 30;
                    foreach (DataGridViewColumn c in dataGridView1.Columns)
                    {
                        c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                        c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                }
    }
    Connection_Class.Close();
        }
            

        private void Export_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            int numbers = 0;
            Connection_Class.DB_cn();
            Connection_Class.open();
            SqlCommand Users = new SqlCommand("Select Id_User from dbo.Users ", Connection_Class.cn);//Command Query
            SqlDataReader sdr3 = Users.ExecuteReader();                                                                      //fill lists of ids and types 
            while (sdr3.Read())
            {
                Ids_User.Add(sdr3.GetInt32((sdr3.GetOrdinal("Id_User"))));
                Console.WriteLine(Ids_User[0]);
            }
             //create datatable
            dt1.Columns.Add("#");                               //add user Details Columns
            dt1.Columns.Add("Name");
            dt1.Columns.Add("Title");
            dt1.Columns.Add("Location");
            //add Device type column
            dt1.Columns.Add("Device");
            dt1.Columns.Add("Serial Number");
            dt1.Columns.Add("Brand");
            dt1.Columns.Add("Model");
            dt1.Columns.Add("Processor");
            dt1.Columns.Add(" Ram");
            dt1.Columns.Add("Hard");
            dt1.Columns.Add(" Note");
            dt1.Columns.Add("Monitor Brand");
            dt1.Columns.Add("Monitor Model");
            dt1.Columns.Add("Monitor Serial Number");
            dt1.Columns.Add("Monitor Note");

            //add Windows software columns
            dt1.Columns.Add("Windows Type");
            dt1.Columns.Add("Windows Key");
            dt1.Columns.Add("Windows Version");
            //add AntiVirus software columns
            dt1.Columns.Add("AntiVirus Type");
            dt1.Columns.Add("AntiVirus Version");
            //add office software columns
            dt1.Columns.Add("Office Type");
            dt1.Columns.Add("Office Key");
            dt1.Columns.Add("Office Email");
            dt1.Columns.Add("Office Password");
            dt1.Columns.Add("Office Version");

            //add PDF software Columns
            dt1.Columns.Add("PDF Type");
            dt1.Columns.Add("PDF Key");
            
            dt1.Columns.Add("PDF Version");


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
            //this.ExportView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            //this.ExportView.ColumnHeadersHeight = this.ExportView.ColumnHeadersHeight * 2;
            //this.ExportView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            //this.ExportView.CellPainting += new DataGridViewCellPaintingEventHandler(ExportView_CellPainting);
            //this.ExportView.Paint += new PaintEventHandler(ExportView_Paint);
            //this.ExportView.Scroll += new ScrollEventHandler(ExportView_Scroll);
            //this.ExportView.ColumnWidthChanged += new DataGridViewColumnEventHandler(ExportView_ColumnWidthChanged);
            if (Ids_User.Count == 0)
            {
                ExportView.DataSource = dt1;
                
            }
            else
            {
                for (int i = 0; i < Ids_User.Count; i++)
                {////////////////////////////////////////////////////////////////////////////////////////
                    /// get all Laptops
                        numbers += 1;
                    if (Conditions_Class.Laptop_Found(Connection_Class.cn, Ids_User[i]) != null) //check if user have laptop tp add Laptop Details and its Software in it in new Row
                    {
                        //numbers += 1;
                        int Others_Software = 0;
                        DataRow dr = dt1.NewRow();
                        //select User Details From database
                        SqlCommand User_Details = new SqlCommand("SELECT Name, Title, Location  from dbo.Users where dbo.Users.Id_User ='" + Ids_User[i] + "' ;", Connection_Class.cn);
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
                        dr["#"] = numbers;
                        dr["Name"] = numb2[0];
                        dr["Title"] = numb2[1];
                        dr["Location"] = numb2[2];
                        //Fill device Type 
                        dr["Device"] = "Laptop";
                        //select Laptop Details From Database
                        SqlCommand Laptop_Details = new SqlCommand("Select  ISNULL(dbo.Laptops.Serial_Number_Lap,' ') AS Serial_Number_Lap,ISNULL(dbo.Laptops.Brand_Lap , ' ' ) AS Brand_Lap,ISNULL(dbo.Laptops.Model_Lap,' ') AS Model_Lap,ISNULL(dbo.Laptops.Processor_Lap,' ') AS Processor_Lap,ISNULL(dbo.Laptops.Ram_Lap,' ') AS Ram_Lap,ISNULL(dbo.Laptops.Hard_Lap,' ') AS Hard_Lap,ISNULL(Laptops.Note_Lap,' ') AS Note_Lap  from dbo.Laptops, dbo.Users WHERE dbo.Laptops.Id_User = '" + Ids_User[i] + "';", Connection_Class.cn);
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

                        //Select Monitor Details from DataBase
                        SqlCommand Monitor_Details = new SqlCommand("SELECT Serial_Number_Monitor, Brand_Monitor , Model_Monitor, Note_Monitor  from dbo.monitor where dbo.Monitor.Id_User ='" + Ids_User[i] + "' ;", Connection_Class.cn);
                        SqlDataReader sdr = Monitor_Details.ExecuteReader();
                        string[] numb = new string[sdr.FieldCount];
                        while (sdr.Read())
                        {
                            for (int l = 0; l < sdr.FieldCount; l++)
                            {
                                numb[l] = sdr[l].ToString();
                            }
                        }
                        if (Conditions_Class.Monitor_Found(Connection_Class.cn, Ids_User[i]) != null)//check if User own monitor or not 
                            {
                            //Fill Monitor Details on Coulmns Belong to Monitor
                            
                            dr["Monitor Brand"] = numb[1];
                            dr["Monitor Model"] = numb[2];
                            dr["Monitor Serial Number"] = numb[0];
                            dr["Monitor Note"] = numb[3];
                        }

                        //get all types and Ids Soft of all software 
                        SqlCommand Ids_Types = new SqlCommand("SELECT dbo.Soft_Laptop.Id_Soft, dbo.Software.type from dbo.Soft_Laptop, dbo.Laptops, dbo.Software where dbo.Laptops.Id_User ='" + Ids_User[i] + "' AND dbo.Laptops.Id_Laptop = dbo.Soft_Laptop.Id_Laptop AND dbo.Soft_Laptop.Id_Soft = dbo.Software.Id_Soft ;", Connection_Class.cn);


                        List<Int32> Id_soft_Lap = new List<Int32>(); //list contain Ids Software
                        List<String> Soft_Lap_Type = new List<String>(); //list Contain Types Software

                        SqlDataReader sdr33 = Ids_Types.ExecuteReader();
                        //fill lists of ids and types 
                        while (sdr33.Read())
                        {
                            Id_soft_Lap.Add(sdr33.GetInt32((sdr33.GetOrdinal("Id_Soft"))));
                            Soft_Lap_Type.Add(sdr33.GetString((sdr33.GetOrdinal("type"))));
                            Console.WriteLine(Soft_Lap_Type[0]);
                        }
                        for (int x = 0; x < Soft_Lap_Type.Count; x++)
                        {
                            Console.WriteLine(Soft_Lap_Type[x]);
                            //select software Details
                            SqlCommand Office_Details = new SqlCommand("SELECT type,[Key],Email,Password,Version from  dbo.Software where dbo.Software.Id_Soft ='" + Id_soft_Lap[x] + "' ;", Connection_Class.cn);
                            SqlDataReader sdr45 = Office_Details.ExecuteReader();
                            string[] numb67 = new string[sdr45.FieldCount];
                            while (sdr45.Read())
                            {
                                for (int l = 0; l < sdr45.FieldCount; l++)
                                {
                                    numb67[l] = sdr45[l].ToString();
                                }
                            }
                            if (Soft_Lap_Type[x].Contains("Office")|| Soft_Lap_Type[x].Contains("office")) //if this software type is Office 
                            {
                                //fill Office Columns
                                dr["Office Type"] = numb67[0];
                                dr["Office Key"] = numb67[1];
                                dr["Office Email"] = numb67[2];
                                dr["Office Password"] = numb67[3];
                                dr["Office Version"] = numb67[4];
                            }
                            else if (Soft_Lap_Type[x].Contains("foxit")|| Soft_Lap_Type[x].Contains("Foxit") || Soft_Lap_Type[x].Contains("Adobe") || Soft_Lap_Type[x].Contains("adobe")) //check if this Software type is PDF
                            {
                                //fill pdf Columns
                                dr["PDF Type"] = numb67[0];
                                dr["PDF Key"] = numb67[1];
                               
                                dr["PDF Version"] = numb67[4];

                            }
                            else if (Soft_Lap_Type[x].Contains("trendmicro")|| Soft_Lap_Type[x].Contains("Trendmicro"))
                            {

                                dr["AntiVirus Type"] = numb67[0];

                                dr["AntiVirus Version"] = numb67[4];

                            }
                            else if (Soft_Lap_Type[x].Contains("autocad") || Soft_Lap_Type[x].Contains("Autocad") || Soft_Lap_Type[x].Contains("gstar")|| Soft_Lap_Type[x].Contains("Gstar"))
                            {

                                dr["Cad Type"] = numb67[0];
                                dr["Cad Key"] = numb67[1];
                                dr["Cad Email"] = numb67[2];
                                dr["Cad Password"] = numb67[3];
                                dr["Cad Version"] = numb67[4];

                            }
                            else if (Soft_Lap_Type[x].Contains("Windows")|| Soft_Lap_Type[x].Contains("windows")) //if this software type is Office 
                            {
                                dr["Windows Type"] = numb67[0];
                                dr["Windows Key"] = numb67[1];
                                dr["Windows Version"] = numb67[4];
                            }
                            else
                            {
                                if (Others_Software < 3)
                                {
                                    Others_Software++;
                                    dr["Other" + Others_Software + " Type"] = numb67[0];
                                    dr["Other" + Others_Software + " Key"] = numb67[1];
                                    dr["Other" + Others_Software + " Email"] = numb67[2];
                                    dr["Other" + Others_Software + " Password"] = numb67[3];
                                    dr["Other" + Others_Software + " Version"] = numb67[4];
                                }
                                else
                                {
                                    MessageBox.Show("the others Softwares Greater than 3");
                                }

                            }
                        }
                        dt1.Rows.Add(dr);
                        ExportView.DataSource = dt1;
                        ExportView.Scroll += new System.Windows.Forms.ScrollEventHandler(ExportView_Scroll);
                        ExportView.Width = 1100;
                        dataGridView2.Width = 1100;
                        ExportView.Columns[0].Width = 30;
                        dataGridView2.Columns[0].Width = 30;
                        foreach (DataGridViewColumn c in ExportView.Columns)
                        {
                            c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                            c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                    }
                    ////////////////////////////////////////////////////////////////////////
                    // get all Desktops
                    if (Conditions_Class.Desktop_Found(Connection_Class.cn, Ids_User[i]) != null)//check if user own Desktop
                    {
                        //numbers += 1;
                        int Others_Software_d = 0;
                        DataRow dr = dt1.NewRow();
                        //select User Details From database
                        SqlCommand User_Details = new SqlCommand("SELECT Name, Title, Location  from dbo.Users where dbo.Users.Id_User ='" + Ids_User[i] + "' ;", Connection_Class.cn);
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
                        dr["#"] = numbers;
                        dr["Name"] = numb2[0];
                        dr["Title"] = numb2[1];
                        dr["Location"] = numb2[2];
                        //Fill device Type 
                        dr["Device"] = "Desktop";
                        //select Desktop Details From Database
                        SqlCommand Laptop_Details = new SqlCommand("Select  dbo.Desktop.Serial_Number_Desk,dbo.Desktop.Brand_Desktop,dbo.Desktop.Model_Desktop,dbo.Desktop.Processor_Desktop,dbo.Desktop.Hard_Desktop,dbo.Desktop.Ram_Desktop,Desktop.Note_Desktop  from dbo.Desktop WHERE dbo.Desktop.Id_User = '" + Ids_User[i] + "';", Connection_Class.cn);
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
                        dr[" Note"] = numb1[6];

                        //Select Monitor Details from DataBase
                        SqlCommand Monitor_Details = new SqlCommand("SELECT Serial_Number_Monitor, Brand_Monitor , Model_Monitor, Note_Monitor  from dbo.monitor where dbo.Monitor.Id_User ='" + Ids_User[i] + "' ;", Connection_Class.cn);
                        SqlDataReader sdr33 = Monitor_Details.ExecuteReader();
                        string[] numb33 = new string[sdr33.FieldCount];
                        while (sdr33.Read())
                        {
                            for (int l = 0; l < sdr33.FieldCount; l++)
                            {
                                numb33[l] = sdr33[l].ToString();
                            }
                        }
                        if (Conditions_Class.Monitor_Found(Connection_Class.cn, Ids_User[i]) != null) //check if User own monitor or not 
                            {
                            //Fill Monitor Details on Coulmns Belong to Monitor
                            dr["Monitor Serial Number"] = numb33[0];
                            dr["Monitor Brand"] = numb33[1];
                            dr["Monitor Model"] = numb33[2];
                            dr["Monitor Note"] = numb33[3];
                        }
                        else
                        {
                            dr["Monitor Serial Number"] = "";
                            dr["Monitor Brand"] = "";
                            dr["Monitor Model"] = "";
                            dr["Monitor Note"] = "";
                        }
                        //get all types and Ids Soft of all software 
                        SqlCommand Ids_Types = new SqlCommand("SELECT dbo.Soft_Desk.Id_Soft, dbo.Software.type from dbo.Soft_Desk, dbo.Desktop, dbo.Software where dbo.Desktop.Id_User ='" + Ids_User[i] + "' AND dbo.Desktop.Id_Desktop = dbo.Soft_Desk.Id_Desktop AND dbo.Soft_Desk.Id_Soft = dbo.Software.Id_Soft ;", Connection_Class.cn);


                        List<Int32> Id_soft_Lap = new List<Int32>(); //list contain Ids Software
                        List<String> Soft_Lap_Type = new List<String>(); //list Contain Types Software

                        SqlDataReader sdr43 = Ids_Types.ExecuteReader();
                        //fill lists of ids and types 
                        while (sdr43.Read())
                        {
                            Id_soft_Lap.Add(sdr43.GetInt32((sdr43.GetOrdinal("Id_Soft"))));
                            Soft_Lap_Type.Add(sdr43.GetString((sdr43.GetOrdinal("type"))));
                        }
                        for (int z = 0; z < Soft_Lap_Type.Count; z++)
                        {
                            //select software Details
                            SqlCommand Office_Details = new SqlCommand("SELECT type,[Key],Email,Password,Version from  dbo.Software where dbo.Software.Id_Soft ='" + Id_soft_Lap[z] + "' ;", Connection_Class.cn);
                            SqlDataReader sdr = Office_Details.ExecuteReader();
                            string[] numb = new string[sdr.FieldCount];
                            while (sdr.Read())
                            {
                                for (int l = 0; l < sdr.FieldCount; l++)
                                {
                                    numb[l] = sdr[l].ToString();
                                }
                            }
                            if (Soft_Lap_Type[z].Contains("Office")) //if this software type is Office 
                            {
                                //fill Office Columns
                                dr["Office Type"] = numb[0];
                                dr["Office Key"] = numb[1];
                                dr["Office Email"] = numb[2];
                                dr["Office Password"] = numb[3];
                                dr["Office Version"] = numb[4];
                            }
                            else if (Soft_Lap_Type[z].Contains("foxit") || Soft_Lap_Type[z].Contains("Foxit") || Soft_Lap_Type[z].Contains("adobe")|| Soft_Lap_Type[z].Contains("Adobe")) //check if this Software type is PDF
                            {
                                //fill pdf Columns
                                dr["PDF Type"] = numb[0];
                                dr["PDF Key"] = numb[1];
                                
                                dr["PDF Version"] = numb[4];

                            }
                            else if (Soft_Lap_Type[z].Contains("trendmicro")|| Soft_Lap_Type[z].Contains("Trendmicro"))
                            {

                                dr["AntiVirus Type"] = numb[0];
                                dr["AntiVirus Version"] = numb[4];

                            }
                            else if (Soft_Lap_Type[z].Contains("autocad") || Soft_Lap_Type[z].Contains("Autocad") || Soft_Lap_Type[z].Contains("gstar") || Soft_Lap_Type[z].Contains("Gstar"))
                            {

                                dr["Cad Type"] = numb[0];
                                dr["Cad Key"] = numb[1];
                                dr["Cad Email"] = numb[2];
                                dr["Cad Password"] = numb[3];
                                dr["Cad Version"] = numb[4];

                            }
                            else if (Soft_Lap_Type[z].Contains("Windows")|| Soft_Lap_Type[z].Contains("Windows")) //if this software type is Office 
                            {
                                dr["Windows Type"] = numb[0];
                                dr["Windows Key"] = numb[1];
                                dr["Windows Version"] = numb[4];
                            }
                            else
                            {
                                if (Others_Software_d < 3)
                                {
                                    Others_Software_d++;
                                    dr["Other" + Others_Software_d + " Type"] = numb[0];
                                    dr["Other" + Others_Software_d + " Key"] = numb[1];
                                    dr["Other" + Others_Software_d + " Email"] = numb[2];
                                    dr["Other" + Others_Software_d + " Password"] = numb[3];
                                    dr["Other" + Others_Software_d + " Version"] = numb[4];
                                }
                                else
                                {
                                    MessageBox.Show("the others Softwares Greater than 3");
                                }

                            }

                        }
                        dt1.Rows.Add(dr);
                        ExportView.DataSource = dt1;
                        ExportView.Scroll += new System.Windows.Forms.ScrollEventHandler(ExportView_Scroll);
                        ExportView.Width = 1100;
                        dataGridView2.Width = 1100;
                        ExportView.Columns[0].Width = 30;
                        dataGridView2.Columns[0].Width = 30;
                        foreach (DataGridViewColumn c in ExportView.Columns)
                        {
                            c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                            c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                        
                    }


                }
               Connection_Class.Close();
            }
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            button1OriginalRect = new Rectangle(button1.Location.X, button1.Location.Y, button1.Width, button1.Height);
            button2OriginalRect = new Rectangle(stock.Location.X, stock.Location.Y, stock.Width, stock.Height);
            button3OriginalRect = new Rectangle(exportExcel.Location.X, exportExcel.Location.Y, exportExcel.Width, exportExcel.Height);
            datagridviewOriginalRect = new Rectangle(ExportView.Location.X, ExportView.Location.Y, ExportView.Width, ExportView.Height);
            datagridview1OriginalRect = new Rectangle(dataGridView1.Location.X, dataGridView1.Location.Y, dataGridView1.Width, dataGridView1.Height);
            datagridview2OriginalRect = new Rectangle(dataGridView2.Location.X, dataGridView2.Location.Y, dataGridView2.Width, dataGridView2.Height);
            datagridview3OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            datagridview4OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
        }
        ////////////////////////////////////////////////////////////////////////////////////////
        //Merge
        private void ExportView_Scroll(object sender, ScrollEventArgs e)
        {
            dataGridView2.FirstDisplayedScrollingColumnIndex = ExportView.FirstDisplayedScrollingColumnIndex;
        }

        private void ExportView_Paint(object sender, PaintEventArgs e)
        {
            int[] Counter_Cells = { 3, 0, 0, 8, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 3, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0 };
            string[] monthes = {"","","","","User", "", "", "", "", "Device", "", "", "", "", "Monitor", "", "", "", "Windows", "", "", "AntiVirus", "", "", "Office", "", "", "", "", "PDF", "", "", "Cad & Gstar", "", "", "", "", "", "", "", "", "", "", "", "", "", "Others", "", "", "", "", "","","" };
            for (int j = 0; j < 48;)
            {

                Rectangle r1 = this.ExportView.GetCellDisplayRectangle(j, -1, true);
                int w2 = 30;
                r1.X += 1;
                r1.Y += 1;
                r1.Width = r1.Width + w2 - 2;
                r1.Height = r1.Height / 2 - 2;
                e.Graphics.FillRectangle(new SolidBrush(this.ExportView.ColumnHeadersDefaultCellStyle.BackColor), r1);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(monthes[j],
                this.ExportView.ColumnHeadersDefaultCellStyle.Font,
                new SolidBrush(this.ExportView.ColumnHeadersDefaultCellStyle.ForeColor),
                r1,
                format);
                j += 1;
            }
        }

        private void ExportView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void ExportView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {


            Rectangle rtHeader = this.ExportView.DisplayRectangle;
            rtHeader.Height = this.ExportView.ColumnHeadersHeight / 2;
            this.ExportView.Invalidate(rtHeader);

        }
        //////////////////////////////////////////////////////////////////////////////////////

        //Autosize
        private void Export_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
        private void resizeChildControls()
        {
             //resize Buttons
            resizeControl(button1OriginalRect, button1);
            resizeControl(button2OriginalRect, stock);
            resizeControl(button3OriginalRect, exportExcel);
            // resize gridviews 
            resizeControl(datagridviewOriginalRect, ExportView);
            resizeControl(datagridview1OriginalRect, dataGridView1);
            resizeControl(datagridview2OriginalRect, dataGridView2);
            //logos
            resizeControl(datagridview3OriginalRect, pictureBox1);
            resizeControl(datagridview4OriginalRect, pictureBox2);

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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}













//SqlCommand User = new SqlCommand("Select Name,Title,Location,Email,Password,[Key],type,Version  from dbo.Users,dbo.Software,dbo.User_soft where   dbo.User_Soft.Id_User =dbo.Users.Id_User AND dbo.Software.Id_User =dbo.Users.Id_Soft AND dbo.Monitor.Id_User =dbo.Users.Id_User");


