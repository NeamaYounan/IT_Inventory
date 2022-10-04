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
    public partial class Delete_User : Form
    {
        private Rectangle pictureBox1OriginalRect;
        private Rectangle checkBoxOriginalRect;
        private Rectangle button1OriginalRect;
         private Rectangle button2OriginalRect;
        private Rectangle button3OriginalRect;
        private Rectangle textBox1OriginalRect;
        private Rectangle textBox2OriginalRect;
        private Rectangle label1OriginalRect;
        private Rectangle label2OriginalRect;
        private Rectangle datagridview1OriginalRect;
        private Rectangle datagridview2OriginalRect;
        private Size formOriginalSize;
        
        public Delete_User()
        {
            InitializeComponent();
            //Console.WriteLine(0);
            using (SqlConnection con = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;"))
            {
                
                
                SqlCommand cmd = new SqlCommand("SELECT Name FROM dbo.Users", Connection_Class.cn);
                Connection_Class.DB_cn();
                Connection_Class.open();
                SqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    MyCollection.Add(reader.GetString(0));
                }
                Name_txt.AutoCompleteCustomSource = MyCollection;
                Connection_Class.Close();
            }
        }
        //neama DB=DESKTOP-OG2M2CI
        //Katren DB=DESKTOP-9QTGSEL
        //SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
        public int Monitor_Found;
        private void Delete_Click(object sender, EventArgs e)
        {
            User_Not_Found.Visible = false;
            Connection_Class.DB_cn();
            Connection_Class.open();
            this.ViewGride.ColumnHeadersHeight = 20;

            string name = Name_txt.Text;
            SqlCommand User = new SqlCommand("Select Id_User from dbo.Users where Lower(dbo.Users.Name) = '" + name.ToLower() + "'", Connection_Class.cn);//Command Query                   

            object user_name = User.ExecuteScalar();
            if (user_name == null) //this user not found in database
            {
                User_Not_Found.Visible = true;
                MessageBox.Show("This name doesn't exist"); //show massage to not found user
            }

            else //this user found in database
            {
                int Id_User = Conditions_Class.Get_Id(User);//Get_Id_user 
                DataTable dt1 = new DataTable(); //create datatable
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


                
                    

                        for (int j = 0; j < this.ViewGride.ColumnCount; j++)
                        {
                            this.ViewGride.Columns[j].Width = 50;
                        }

                   

                    this.ViewGride.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    this.ViewGride.ColumnHeadersHeight = this.ViewGride.ColumnHeadersHeight * 2;
                    this.ViewGride.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                    this.ViewGride.CellPainting += new DataGridViewCellPaintingEventHandler(Search_Grid_CellPainting);
                    this.ViewGride.Paint += new PaintEventHandler(Search_Grid_Paint);
                    this.ViewGride.Scroll += new ScrollEventHandler(Search_Grid_Scroll);
                    this.ViewGride.ColumnWidthChanged += new DataGridViewColumnEventHandler(Search_Grid_ColumnWidthChanged);
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
                        if (Monitor_Found == 1) //check if User own monitor or not 
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
                            else if (Soft_Lap_Type[i].Contains("autocad")|| Soft_Lap_Type[i].Contains("Autocad") || Soft_Lap_Type[i].Contains("Gstar") || Soft_Lap_Type[i].Contains("gstar"))
                            {

                                dr["Cad Type"] = numb[0];
                                dr["Cad Key"] = numb[1];
                                dr["Cad Email"] = numb[2];
                                dr["Cad Password"] = numb[3];
                                dr["Cad Version"] = numb[4];

                            }
                            else if (Soft_Lap_Type[i].Contains("Windows")|| Soft_Lap_Type[i].Contains("windows")) //if this software type is Office 
                            {
                                dt1.Columns.Add("Windows Type");
                                dt1.Columns.Add("Windows Key");
                                dt1.Columns.Add("Windows Version");
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
                        ViewGride.DataSource = dt1;
                        dt1 = null;

                    }
                    if (Conditions_Class.Desktop_Found(Connection_Class.cn, Id_User) != null)//check if user own Desktop
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
                            else if (Soft_Lap_Type[i].Contains("autocad")|| Soft_Lap_Type[i].Contains("Autocad") || Soft_Lap_Type[i].Contains("Gstar") || Soft_Lap_Type[i].Contains("gstar"))
                            {

                                dr["Cad Type"] = numb[0];
                                dr["Cad Key"] = numb[1];
                                dr["Cad Email"] = numb[2];
                                dr["Cad Password"] = numb[3];
                                dr["Cad Version"] = numb[4];

                            }
                            else if (Soft_Lap_Type[i].Contains("Windows")|| Soft_Lap_Type[i].Contains("windows")) //if this software type is Office 
                            {
                                dt1.Columns.Add("Windows Type");
                                dt1.Columns.Add("Windows Key");
                                dt1.Columns.Add("Windows Version");
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
                        ViewGride.DataSource = dt1;

                    }

                }
                else
                {
                    User_Not_Found.Visible = true;
                    MessageBox.Show("This user don't own any device");
                }

            }

        Connection_Class.cn.Close();
            
        }

        
        
    
    
        private void Confirm_Deleted_Click(object sender, EventArgs e)
        {
            Connection_Class.DB_cn();
            Connection_Class.open();
            string name = Name_txt.Text;
            
            SqlCommand User = new SqlCommand("Select Id_User from dbo.Users where Lower(dbo.Users.Name) = '" + name.ToLower() + "'", Connection_Class.cn);//Command Query                   
            object user_name = User.ExecuteScalar();
            if (user_name == null) //this user not found in database
            { 
                MessageBox.Show("This name doesn't exist"); //show massage to not found user
                
            }
            else
            {
                int Id_User = Conditions_Class.Get_Id(User);//Get_Id_user
                if (checkBox1.Checked == true)
                {

                    string project_name = Project_Name.Text;

                    if (Conditions_Class.Laptop_Found(Connection_Class.cn, Id_User)!=null)//if user own laptop
                    {
                        //get Id_Laptop
                        SqlCommand Laptop = new SqlCommand("Select Id_Laptop from dbo.Laptops where dbo.Laptops.Id_User = '" +Id_User+ "'", Connection_Class.cn);//Command Query                   
                        int Id_Lap = Conditions_Class.Get_Id(Laptop);//Get_Id_Laptop
                        List<int> Ids_Soft = new List<int>();//define list to get ids software
                        //select ids to software that user own this LAptop
                        SqlCommand Soft = new SqlCommand("Select Id_Soft from dbo.Soft_Laptop where dbo.Soft_Laptop.Id_Laptop = '" + Id_Lap + "'", Connection_Class.cn);//Command Query                   
                        SqlDataReader sdr3 = Soft.ExecuteReader();
                        //fill lists of ids and types 
                        while (sdr3.Read())
                        {
                            Ids_Soft.Add(sdr3.GetInt32((sdr3.GetOrdinal("Id_Soft"))));
                            
                        }
                        //insert softwares that user own it in spare 
                        //delete this softwares from tables (User_Soft,Laptop_soft,Software)
                        for(int i = 0; i < Ids_Soft.Count; i++)
                        {
                            SqlCommand spare_Soft = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Email,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note) Select dbo.Software.type,dbo.Software.Email,dbo.Software.Password,dbo.Software.[Key],dbo.Software.Version,'old '+'"+name+"'+' Transfered to ' + '"+project_name+"' from dbo.Software WHERE dbo.Software.Id_Soft = '" +Ids_Soft[i]+ "'", Connection_Class.cn);
                            spare_Soft.ExecuteNonQuery();
                            SqlCommand Delete_Lap_Soft = new SqlCommand("DELETE FROM Soft_Laptop WHERE dbo.Soft_Laptop.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                            Delete_Lap_Soft.ExecuteNonQuery();
                            SqlCommand Delete_User_Soft = new SqlCommand("DELETE FROM User_Soft WHERE dbo.User_Soft.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                            Delete_User_Soft.ExecuteNonQuery();
                            SqlCommand Delete_Soft = new SqlCommand("DELETE FROM Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                            Delete_Soft.ExecuteNonQuery();
                        }
                        //Insert Laptop to spare
                        SqlCommand spare_Laptop = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Serial_Number,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Processor,dbo.Spare.Ram,dbo.Spare.Hard,dbo.Spare.Note) Select 'Laptop', dbo.Laptops.Serial_Number_Lap,dbo.Laptops.Brand_Lap,dbo.Laptops.Model_Lap,dbo.Laptops.Processor_Lap,dbo.Laptops.Ram_Lap,dbo.Laptops.Hard_Lap,dbo.Laptops.Note_Lap+' old '+'" + name + "'+' Transfered to ' + '" + project_name + "' from dbo.Laptops WHERE dbo.Laptops.Id_Laptop = '" + Id_Lap + "'", Connection_Class.cn);
                        spare_Laptop.ExecuteNonQuery();
                        //Delete Laptop From Laptops Table
                        SqlCommand Delete_Laptop = new SqlCommand("DELETE FROM Laptops WHERE dbo.Laptops.Id_Laptop = '" + Id_Lap + "'", Connection_Class.cn);
                        Delete_Laptop.ExecuteNonQuery();
                        if(Conditions_Class.Monitor_Found(Connection_Class.cn,Id_User)!=null)
                        {
                            //Insert Monitor to spare
                            SqlCommand spare_Monitor = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Serial_Number,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Note) Select 'Monitor', dbo.Monitor.Serial_Number_Monitor,dbo.Monitor.Brand_Monitor,dbo.Monitor.Model_Monitor,dbo.Monitor.Note_Monitor +' old '+'" + name + "'+' Transfered to ' + '" + project_name + "' from dbo.Monitor WHERE dbo.Monitor.Id_User = '" + Id_User + "'", Connection_Class.cn);
                            spare_Monitor.ExecuteNonQuery();
                            //Delete Monitor From Laptops Table
                            SqlCommand Delete_Monitor = new SqlCommand("DELETE FROM Monitor WHERE dbo.Monitor.Id_User = '" + Id_User + "'", Connection_Class.cn);
                            Delete_Monitor.ExecuteNonQuery();
                        }
                        //Delete Monitor From Laptops Table
                        SqlCommand Delete_User = new SqlCommand("DELETE FROM Users WHERE dbo.Users.Id_User = '" + Id_User + "'", Connection_Class.cn);
                        Delete_User.ExecuteNonQuery();
                    }
                    else if(Conditions_Class.Desktop_Found(Connection_Class.cn,Id_User)!=null)//check if User own Desktop
                    {
                        //get Id_Desktop
                        SqlCommand Desktop = new SqlCommand("Select Id_Desktop from dbo.Desktop where dbo.Desktop.Id_User = '" + Id_User + "'", Connection_Class.cn);//Command Query                   
                        int Id_Desk = Conditions_Class.Get_Id(Desktop);//Get_Id_Desktop
                        List<int> Ids_Soft = new List<int>();//define list to get ids software
                        //select ids to software that user own this Desktop
                        SqlCommand Soft = new SqlCommand("Select Id_Soft from dbo.Soft_Desk where dbo.Soft_Desk.Id_Desktop = '" + Id_Desk + "'", Connection_Class.cn);//Command Query                   
                        SqlDataReader sdr3 = Soft.ExecuteReader();
                        //fill lists of ids and types 
                        while (sdr3.Read())
                        {
                            Ids_Soft.Add(sdr3.GetInt32((sdr3.GetOrdinal("Id_Soft"))));

                        }

                        //insert softwares that user own it in spare 
                        //delete this softwares from tables (User_Soft,Desk_soft,Software)
                        for (int i = 0; i < Ids_Soft.Count; i++)
                        {
                            SqlCommand spare_Soft = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Email,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note) Select dbo.Software.type,dbo.Software.Email,dbo.Software.Password,dbo.Software.[Key],dbo.Software.Version,'old '+'" + name + "'+' Transfered to ' + '" + project_name + "' from dbo.Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                            spare_Soft.ExecuteNonQuery();
                            SqlCommand Delete_Desk_Soft = new SqlCommand("DELETE FROM Soft_Desk WHERE dbo.Soft_Desk.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                            Delete_Desk_Soft.ExecuteNonQuery();
                            SqlCommand Delete_User_Soft = new SqlCommand("DELETE FROM User_Soft WHERE dbo.User_Soft.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                            Delete_User_Soft.ExecuteNonQuery();
                            SqlCommand Delete_Soft = new SqlCommand("DELETE FROM Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                            Delete_Soft.ExecuteNonQuery();
                        }
                        //Insert Laptop to spare
                        SqlCommand spare_Desktop = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Serial_Number,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Processor,dbo.Spare.Ram,dbo.Spare.Hard,dbo.Spare.Note) Select 'Desktop', dbo.Desktop.Serial_Number_Desk,dbo.Desktop.Brand_Desktop,dbo.Desktop.Model_Desktop,dbo.Desktop.Processor_Desktop,dbo.Desktop.Ram_Desktop,dbo.Desktop.Hard_Desktop,dbo.Desktop.Note_Desktop+' old '+'" + name + "'+' Transfered to ' + '" + project_name + "' from dbo.Desktop WHERE dbo.Desktop.Id_Desktop = '" + Id_Desk + "'", Connection_Class.cn);
                        spare_Desktop.ExecuteNonQuery();
                        //Delete Laptop From Laptops Table
                        SqlCommand Delete_Desktop = new SqlCommand("DELETE FROM Desktop WHERE dbo.Desktop.Id_Desktop = '" + Id_Desk + "'", Connection_Class.cn);
                        Delete_Desktop.ExecuteNonQuery();
                        if (Conditions_Class.Monitor_Found(Connection_Class.cn, Id_User) != null)
                        {
                            //Insert Monitor to spare
                            SqlCommand spare_Monitor = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Serial_Number,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Note) Select 'Monitor', dbo.Monitor.Serial_Number_Monitor,dbo.Monitor.Brand_Monitor,dbo.Monitor.Model_Monitor,dbo.Monitor.Note_Monitor +' old '+'" + name + "'+' Transfered to ' + '" + project_name + "' from dbo.Monitor WHERE dbo.Monitor.Id_User = '" + Id_User + "'", Connection_Class.cn);
                            spare_Monitor.ExecuteNonQuery();
                            //Delete Monitor From Laptops Table
                            SqlCommand Delete_Monitor = new SqlCommand("DELETE FROM Monitor WHERE dbo.Monitor.Id_User = '" + Id_User + "'", Connection_Class.cn);
                            Delete_Monitor.ExecuteNonQuery();
                        }
                        //Delete Monitor From Laptops Table
                        SqlCommand Delete_User = new SqlCommand("DELETE FROM Users WHERE dbo.Users.Id_User = '" + Id_User + "'", Connection_Class.cn);
                        Delete_User.ExecuteNonQuery();
                    }
                }
                else
                {
                    if (Conditions_Class.Laptop_Found(Connection_Class.cn, Id_User) != null)//if user own laptop
                    {
                        //get Id_Laptop
                        SqlCommand Laptop = new SqlCommand("Select Id_Laptop from dbo.Laptops where dbo.Laptops.Id_User = '" + Id_User + "'", Connection_Class.cn);//Command Query                   
                        int Id_Lap = Conditions_Class.Get_Id(Laptop);//Get_Id_Laptop
                        List<int> Ids_Soft = new List<int>();//define list to get ids software
                        //select ids to software that user own this LAptop
                        SqlCommand Soft = new SqlCommand("Select Id_Soft from dbo.Soft_Laptop where dbo.Soft_Laptop.Id_Laptop = '" + Id_Lap + "'", Connection_Class.cn);//Command Query                   
                        SqlDataReader sdr3 = Soft.ExecuteReader();
                        //fill lists of ids and types 
                        while (sdr3.Read())
                        {
                            Ids_Soft.Add(sdr3.GetInt32((sdr3.GetOrdinal("Id_Soft"))));

                        }
                        //insert softwares that user own it in spare 
                        //delete this softwares from tables (User_Soft,Laptop_soft,Software)
                        for (int i = 0; i < Ids_Soft.Count; i++)
                        {
                            SqlCommand spare_Soft = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Email,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note) Select dbo.Software.type,dbo.Software.Email,dbo.Software.Password,dbo.Software.[Key],dbo.Software.Version,'old '+'" + name + "' from dbo.Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                            spare_Soft.ExecuteNonQuery();
                            SqlCommand Delete_Lap_Soft = new SqlCommand("DELETE FROM Soft_Laptop WHERE dbo.Soft_Laptop.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                            Delete_Lap_Soft.ExecuteNonQuery();
                            SqlCommand Delete_User_Soft = new SqlCommand("DELETE FROM User_Soft WHERE dbo.User_Soft.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                            Delete_User_Soft.ExecuteNonQuery();
                            SqlCommand Delete_Soft = new SqlCommand("DELETE FROM Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                            Delete_Soft.ExecuteNonQuery();
                        }
                        //Insert Laptop to spare
                        SqlCommand spare_Laptop = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Serial_Number,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Processor,dbo.Spare.Ram,dbo.Spare.Hard,dbo.Spare.Note) Select 'Laptop', dbo.Laptops.Serial_Number_Lap,dbo.Laptops.Brand_Lap,dbo.Laptops.Model_Lap,dbo.Laptops.Processor_Lap,dbo.Laptops.Ram_Lap,dbo.Laptops.Hard_Lap,dbo.Laptops.Note_Lap+' old '+'" + name + "' from dbo.Laptops WHERE dbo.Laptops.Id_Laptop = '" + Id_Lap + "'", Connection_Class.cn);
                        spare_Laptop.ExecuteNonQuery();
                        //Delete Laptop From Laptops Table
                        SqlCommand Delete_Laptop = new SqlCommand("DELETE FROM Laptops WHERE dbo.Laptops.Id_Laptop = '" + Id_Lap + "'", Connection_Class.cn);
                        Delete_Laptop.ExecuteNonQuery();
                        if (Conditions_Class.Monitor_Found(Connection_Class.cn, Id_User) != null)
                        {
                            //Insert Monitor to spare
                            SqlCommand spare_Monitor = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Serial_Number,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Note) Select 'Monitor', dbo.Monitor.Serial_Number_Monitor,dbo.Monitor.Brand_Monitor,dbo.Monitor.Model_Monitor,dbo.Monitor.Note_Monitor +' old '+'" + name + "' from dbo.Monitor WHERE dbo.Monitor.Id_User = '" + Id_User + "'", Connection_Class.cn);
                            spare_Monitor.ExecuteNonQuery();
                            //Delete Monitor From Laptops Table
                            SqlCommand Delete_Monitor = new SqlCommand("DELETE FROM Monitor WHERE dbo.Monitor.Id_User = '" + Id_User + "'", Connection_Class.cn);
                            Delete_Monitor.ExecuteNonQuery();
                        }
                        //Delete Monitor From Laptops Table
                        SqlCommand Delete_User = new SqlCommand("DELETE FROM Users WHERE dbo.Users.Id_User = '" + Id_User + "'", Connection_Class.cn);
                        Delete_User.ExecuteNonQuery();
                    }

                    else if (Conditions_Class.Desktop_Found(Connection_Class.cn, Id_User) != null)//check if User own Desktop
                    {
                        //get Id_Desktop
                        SqlCommand Desktop = new SqlCommand("Select Id_Desktop from dbo.Desktop where dbo.Desktop.Id_User = '" + Id_User + "'", Connection_Class.cn);//Command Query                   
                        int Id_Desk = Conditions_Class.Get_Id(Desktop);//Get_Id_Desktop
                        List<int> Ids_Soft = new List<int>();//define list to get ids software
                        //select ids to software that user own this Desktop
                        SqlCommand Soft = new SqlCommand("Select Id_Soft from dbo.Soft_Desk where dbo.Soft_Desk.Id_Desktop = '" + Id_Desk + "'", Connection_Class.cn);//Command Query                   
                        SqlDataReader sdr3 = Soft.ExecuteReader();
                        //fill lists of ids and types 
                        while (sdr3.Read())
                        {
                            Ids_Soft.Add(sdr3.GetInt32((sdr3.GetOrdinal("Id_Soft"))));

                        }

                        //insert softwares that user own it in spare 
                        //delete this softwares from tables (User_Soft,Desk_soft,Software)
                        for (int i = 0; i < Ids_Soft.Count; i++)
                        {
                            SqlCommand spare_Soft = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Email,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note) Select dbo.Software.type,dbo.Software.Email,dbo.Software.Password,dbo.Software.[Key],dbo.Software.Version,'old '+'" + name + "' from dbo.Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                            spare_Soft.ExecuteNonQuery();
                            SqlCommand Delete_Desk_Soft = new SqlCommand("DELETE FROM Soft_Desk WHERE dbo.Soft_Desk.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                            Delete_Desk_Soft.ExecuteNonQuery();
                            SqlCommand Delete_User_Soft = new SqlCommand("DELETE FROM User_Soft WHERE dbo.User_Soft.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                            Delete_User_Soft.ExecuteNonQuery();
                            SqlCommand Delete_Soft = new SqlCommand("DELETE FROM Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                            Delete_Soft.ExecuteNonQuery();
                        }
                        //Insert Laptop to spare
                        SqlCommand spare_Desktop = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Serial_Number,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Processor,dbo.Spare.Ram,dbo.Spare.Hard,dbo.Spare.Note) Select 'Desktop', dbo.Desktop.Serial_Number_Desk,dbo.Desktop.Brand_Desktop,dbo.Desktop.Model_Desktop,dbo.Desktop.Processor_Desktop,dbo.Desktop.Ram_Desktop,dbo.Desktop.Hard_Desktop,dbo.Desktop.Note_Desktop+' old '+'" + name + "' from dbo.Desktop WHERE dbo.Desktop.Id_Desktop = '" + Id_Desk + "'", Connection_Class.cn);
                        spare_Desktop.ExecuteNonQuery();
                        //Delete Laptop From Laptops Table
                        SqlCommand Delete_Desktop = new SqlCommand("DELETE FROM Desktop WHERE dbo.Desktop.Id_Desktop = '" + Id_Desk + "'", Connection_Class.cn);
                        Delete_Desktop.ExecuteNonQuery();
                        if (Conditions_Class.Monitor_Found(Connection_Class.cn, Id_User) != null)
                        {
                            //Insert Monitor to spare
                            SqlCommand spare_Monitor = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Serial_Number,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Note) Select 'Monitor', dbo.Monitor.Serial_Number_Monitor,dbo.Monitor.Brand_Monitor,dbo.Monitor.Model_Monitor,dbo.Monitor.Note_Monitor +' old '+'" + name + "'  from dbo.Monitor WHERE dbo.Monitor.Id_User = '" + Id_User + "'", Connection_Class.cn);
                            spare_Monitor.ExecuteNonQuery();
                            //Delete Monitor From Laptops Table
                            SqlCommand Delete_Monitor = new SqlCommand("DELETE FROM Monitor WHERE dbo.Monitor.Id_User = '" + Id_User + "'", Connection_Class.cn);
                            Delete_Monitor.ExecuteNonQuery();
                        }
                        //Delete Monitor From Laptops Table
                        SqlCommand Delete_User = new SqlCommand("DELETE FROM Users WHERE dbo.Users.Id_User = '" + Id_User + "'", Connection_Class.cn);
                        Delete_User.ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show("Data Updated Successfully");
            Connection_Class.Close();   
        }
        private void Add_User_Form_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
        private void resizeChildControls()
        {
            resizeControl(pictureBox1OriginalRect, pictureBox2);
            resizeControl(checkBoxOriginalRect, checkBox1);
            resizeControl(textBox1OriginalRect, Name_txt);
            resizeControl(textBox2OriginalRect, Project_Name);
            
            resizeControl(button1OriginalRect, back);
            resizeControl(button2OriginalRect, Confirm_Deleted);
            resizeControl(button3OriginalRect, view_User);
            resizeControl(label1OriginalRect, name_Deleted);
            resizeControl(label2OriginalRect, Project_Label);
            resizeControl(datagridview1OriginalRect, User_Not_Found);
            resizeControl(datagridview2OriginalRect, ViewGride);



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
        private void Delete_User_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            pictureBox1OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            checkBoxOriginalRect = new Rectangle(checkBox1.Location.X, checkBox1.Location.Y, checkBox1.Width, checkBox1.Height);
            textBox1OriginalRect = new Rectangle(Name_txt.Location.X, Name_txt.Location.Y, Name_txt.Width, Name_txt.Height);
            textBox2OriginalRect = new Rectangle(Project_Name.Location.X, Project_Name.Location.Y, Project_Name.Width, Project_Name.Height);
            
            button1OriginalRect = new Rectangle(back.Location.X, back.Location.Y, back.Width, back.Height);
            button2OriginalRect = new Rectangle(Confirm_Deleted.Location.X, Confirm_Deleted.Location.Y, Confirm_Deleted.Width, Confirm_Deleted.Height);
            button3OriginalRect = new Rectangle(view_User.Location.X, view_User.Location.Y, view_User.Width, view_User.Height);
            label1OriginalRect = new Rectangle(name_Deleted.Location.X, name_Deleted.Location.Y, name_Deleted.Width, name_Deleted.Height);
            label2OriginalRect = new Rectangle(Project_Label.Location.X, Project_Label.Location.Y, Project_Label.Width, Project_Label.Height);
            datagridview1OriginalRect = new Rectangle(User_Not_Found.Location.X, User_Not_Found.Location.Y, User_Not_Found.Width, User_Not_Found.Height);
            datagridview2OriginalRect = new Rectangle(ViewGride.Location.X, ViewGride.Location.Y, ViewGride.Width, ViewGride.Height);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Project_Label.Visible = true;
                Project_Name.Visible = true;
            }
            else
            {
                Project_Label.Visible = false;
                Project_Name.Visible = false;
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            Inventory_CURD invent = new Inventory_CURD();
            invent.Show();
            this.Hide();
        }

        private void ch(object sender, EventArgs e)
        {

        }

        private void Project_Name_VisibleChanged(object sender, EventArgs e)
        {
            
        }
        private void Search_Grid_Scroll(object sender, ScrollEventArgs e)
        {
            Rectangle rtHeader = this.ViewGride.DisplayRectangle;
            rtHeader.Height = this.ViewGride.ColumnHeadersHeight;
            this.ViewGride.Invalidate(rtHeader);
        }

        private void Search_Grid_Paint(object sender, PaintEventArgs e)
        {
            int[] Counter_Cells = { 3, 0, 0, 8, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 3, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0, 5, 0, 0, 0, 0 };
            string[] monthes = { "User", "", "", "Device", "", "", "", "", "", "", "", "Monitor", "", "", "", "Windows", "", "", "Office", "", "", "", "", "PDF", "", "", "", "", "AntiVirus", "", "", "", "", "Cad & Gstar", "", "", "", "", "Others", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            for (int j = 0; j < 53;)
            {

                Rectangle r1 = this.ViewGride.GetCellDisplayRectangle(j, -1, true);
                int w2 = 30;

                r1.X += 1;
                r1.Y += 1;
                r1.Width = r1.Width + w2 - 2;
                r1.Height = r1.Height / 2 - 2;
                e.Graphics.FillRectangle(new SolidBrush(this.ViewGride.ColumnHeadersDefaultCellStyle.BackColor), r1);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(monthes[j],
                this.ViewGride.ColumnHeadersDefaultCellStyle.Font,
                new SolidBrush(this.ViewGride.ColumnHeadersDefaultCellStyle.ForeColor),
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

            Rectangle rtHeader = this.ViewGride.DisplayRectangle;
            rtHeader.Height = this.ViewGride.ColumnHeadersHeight / 2;
            this.ViewGride.Invalidate(rtHeader);

        }

    }

} 

