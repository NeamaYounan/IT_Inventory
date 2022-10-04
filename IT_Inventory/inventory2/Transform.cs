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
    public partial class Transform : Form
    {
        public Transform()
        {
            InitializeComponent();
            Type_Text.Items.Add("Desktop");
            Type_Text.Items.Add("Laptop");
            Type_Text.Items.Add("Monitor");
            //Second_Name.AutoCompleteCustomSource = MyCollection;
            using (SqlConnection con = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;"))
            {


                SqlCommand cmd = new SqlCommand("SELECT Name FROM dbo.Users", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection MyCollections = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    MyCollections.Add(reader.GetString(0));
                }
                First_Name.AutoCompleteCustomSource = MyCollections;
                Second_Name.AutoCompleteCustomSource = MyCollections;
                con.Close();
            }

        }
        //neama DB=DESKTOP-OG2M2CI
        //Katren DB=DESKTOP-9QTGSEL
        SqlConnection cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
        int Id_First_User;
        int Id_Second_User; 
        private void save_Click(object sender, EventArgs e)
        {
            String type = Type_Text.Text;
            if(type == "Desktop")
            {
                if (Search_Grid.Rows.Count > 0)
                {
                    cn.Open();
                    String Name1 = Search_Grid.Rows[0].Cells[0].Value.ToString();
                    String SN1 = Search_Grid.Rows[0].Cells[1].Value.ToString();
                    String Brand1 = Search_Grid.Rows[0].Cells[2].Value.ToString();
                    String Model1 = Search_Grid.Rows[0].Cells[3].Value.ToString();
                    String Processor1 = Search_Grid.Rows[0].Cells[4].Value.ToString();
                    String Ram1 = Search_Grid.Rows[0].Cells[5].Value.ToString();
                    String Hard1 = Search_Grid.Rows[0].Cells[6].Value.ToString();
                    String Note1 = Search_Grid.Rows[0].Cells[7].Value.ToString();
                    //get row2
                    String Name2 = Search_Grid.Rows[1].Cells[0].Value.ToString();
                    String SN2 = Search_Grid.Rows[1].Cells[1].Value.ToString();
                    String Brand2 = Search_Grid.Rows[1].Cells[2].Value.ToString();
                    String Model2 = Search_Grid.Rows[1].Cells[3].Value.ToString();
                    String Processor2 = Search_Grid.Rows[1].Cells[4].Value.ToString();
                    String Ram2 = Search_Grid.Rows[1].Cells[5].Value.ToString();
                    String Hard2 = Search_Grid.Rows[1].Cells[6].Value.ToString();
                    String Note2 = Search_Grid.Rows[1].Cells[7].Value.ToString();
                    SqlCommand Update_sn2 = new SqlCommand("UPDATE dbo.Desktop SET dbo.Desktop.Serial_Number_Desk='" + "kkk" + "' WHERE dbo.Desktop.Id_User='" + Id_Second_User + "' ", cn);
                    Update_sn2.ExecuteNonQuery();
                    SqlCommand Update_User1 = new SqlCommand("UPDATE dbo.Desktop SET dbo.Desktop.Serial_Number_Desk='" + SN2 + "', dbo.Desktop.Brand_Desktop='" + Brand2 + "',dbo.Desktop.Model_Desktop='" + Model2 + "', dbo.Desktop.Processor_Desktop='" + Processor2 + "', dbo.Desktop.Ram_Desktop='" + Ram2 + "', dbo.Desktop.Hard_Desktop='" + Hard2 + "',dbo.Desktop.Note_Desktop= ISNULL('" + Note2 + "',' ')+' '+'old'+ ' '+'" + Name2 + "' WHERE dbo.Desktop.Id_User='" + Id_First_User + "' ", cn);
                    Update_User1.ExecuteNonQuery();
                    SqlCommand Update_User2 = new SqlCommand("UPDATE dbo.Desktop SET dbo.Desktop.Serial_Number_Desk='" + SN1 + "', dbo.Desktop.Brand_Desktop='" + Brand1 + "',dbo.Desktop.Model_Desktop='" + Model1 + "', dbo.Desktop.Processor_Desktop='" + Processor1 + "', dbo.Desktop.Ram_Desktop='" + Ram1 + "', dbo.Desktop.Hard_Desktop='" + Hard1 + "',dbo.Desktop.Note_Desktop=ISNULL('" + Note1 + "',' ')+' '+'old'+' '+ '" + Name1 + "' WHERE dbo.Desktop.Id_User='" + Id_Second_User + "' ", cn);
                    Update_User2.ExecuteNonQuery();
                    MessageBox.Show("Data Edited Successfully");

                }
                else
                {
                    MessageBox.Show("Please Press Show Button");
                }


            }
            else if(type == "Laptop")
            {
                if (Search_Grid.Rows.Count > 0)
                {
                    cn.Open();
                    String Name1 = Search_Grid.Rows[0].Cells[0].Value.ToString();
                    String SN1 = Search_Grid.Rows[0].Cells[1].Value.ToString();
                    String Brand1 = Search_Grid.Rows[0].Cells[2].Value.ToString();
                    String Model1 = Search_Grid.Rows[0].Cells[3].Value.ToString();
                    String Processor1 = Search_Grid.Rows[0].Cells[4].Value.ToString();
                    String Ram1 = Search_Grid.Rows[0].Cells[5].Value.ToString();
                    String Hard1 = Search_Grid.Rows[0].Cells[6].Value.ToString();
                    String Note1 = Search_Grid.Rows[0].Cells[7].Value.ToString();
                    //get row2
                    String Name2 = Search_Grid.Rows[1].Cells[0].Value.ToString();
                    String SN2 = Search_Grid.Rows[1].Cells[1].Value.ToString();
                    String Brand2 = Search_Grid.Rows[1].Cells[2].Value.ToString();
                    String Model2 = Search_Grid.Rows[1].Cells[3].Value.ToString();
                    String Processor2 = Search_Grid.Rows[1].Cells[4].Value.ToString();
                    String Ram2 = Search_Grid.Rows[1].Cells[5].Value.ToString();
                    String Hard2 = Search_Grid.Rows[1].Cells[6].Value.ToString();
                    String Note2 = Search_Grid.Rows[1].Cells[7].Value.ToString();
                    SqlCommand Update_sn2 = new SqlCommand("UPDATE dbo.Laptops SET dbo.Laptops.Serial_Number_Lap='" + "kkk" + "' WHERE dbo.Laptops.Id_User='" + Id_Second_User + "' ", cn);
                    Update_sn2.ExecuteNonQuery();
                    SqlCommand Update_User1 = new SqlCommand("UPDATE dbo.Laptops SET dbo.Laptops.Serial_Number_Lap='" + SN2 + "', dbo.Laptops.Brand_Lap='" + Brand2 + "',dbo.Laptops.Model_Lap='" + Model2 + "', dbo.Laptops.Processor_Lap='" + Processor2 + "', dbo.Laptops.Ram_Lap='" + Ram2 + "', dbo.Laptops.Hard_Lap='" + Hard2 + "',dbo.Laptops.Note_Lap= ISNULL('" + Note2 + "',' ')+' '+'old'+ ' '+'" + Name2 + "' WHERE dbo.Laptops.Id_User='" + Id_First_User + "' ", cn);
                    Update_User1.ExecuteNonQuery();
                    SqlCommand Update_User2 = new SqlCommand("UPDATE dbo.Laptops SET dbo.Laptops.Serial_Number_Lap='" + SN1 + "', dbo.Laptops.Brand_Lap='" + Brand1 + "',dbo.Laptops.Model_Lap='" + Model1 + "', dbo.Laptops.Processor_Lap='" + Processor1 + "', dbo.Laptops.Ram_Lap='" + Ram1 + "', dbo.Laptops.Hard_Lap='" + Hard1 + "',dbo.Laptops.Note_Lap=ISNULL('" + Note1 + "',' ')+' '+'old'+' '+ '" + Name1 + "' WHERE dbo.Laptops.Id_User='" + Id_Second_User + "' ", cn);
                    Update_User2.ExecuteNonQuery();
                    MessageBox.Show("Data Edited Successfully");
                }
                else
                {
                    MessageBox.Show("Please Press Show Button");
                }
               
            }
            else if(type == "Monitor")
            {
                if (Search_Grid.Rows.Count > 0)
                {
                    cn.Open();
                    String Name1 = Search_Grid.Rows[0].Cells[0].Value.ToString();
                    String SN1 = Search_Grid.Rows[0].Cells[1].Value.ToString();
                    String Brand1 = Search_Grid.Rows[0].Cells[2].Value.ToString();
                    String Model1 = Search_Grid.Rows[0].Cells[3].Value.ToString();
                    String Note1 = Search_Grid.Rows[0].Cells[4].Value.ToString();
                    //get row2
                    String Name2 = Search_Grid.Rows[1].Cells[0].Value.ToString();
                    String SN2 = Search_Grid.Rows[1].Cells[1].Value.ToString();
                    String Brand2 = Search_Grid.Rows[1].Cells[2].Value.ToString();
                    String Model2 = Search_Grid.Rows[1].Cells[3].Value.ToString();
                    String Note2 = Search_Grid.Rows[1].Cells[4].Value.ToString();
                    SqlCommand Update_sn2 = new SqlCommand("UPDATE dbo.Monitor SET dbo.Monitor.Serial_Number_Monitor='" + "kkk" + "' WHERE dbo.Monitor.Id_User='" + Id_Second_User + "' ", cn);
                    Update_sn2.ExecuteNonQuery();
                    SqlCommand Update_User1 = new SqlCommand("UPDATE dbo.Monitor SET dbo.Monitor.Serial_Number_Monitor='" + SN2 + "', dbo.Monitor.Brand_Monitor='" + Brand2 + "',dbo.Monitor.Model_Monitor='" + Model2 + "', dbo.Monitor.Note_Monitor= ISNULL('" + Note2 + "',' ')+' '+'old'+ ' '+'" + Name2 + "' WHERE dbo.Monitor.Id_User='" + Id_First_User + "' ", cn);
                    Update_User1.ExecuteNonQuery();
                    SqlCommand Update_User2 = new SqlCommand("UPDATE dbo.Monitor SET dbo.Monitor.Serial_Number_Monitor='" + SN1 + "', dbo.Monitor.Brand_Monitor='" + Brand1 + "',dbo.Monitor.Model_Monitor='" + Model1 + "',dbo.Monitor.Note_Monitor=ISNULL('" + Note1 + "',' ')+' '+'old'+ ' '+'" + Name1 + "' WHERE dbo.Monitor.Id_User='" + Id_Second_User + "' ", cn);
                    Update_User2.ExecuteNonQuery();
                    MessageBox.Show("Data Edited Successfully");
                }
                else
                {
                    MessageBox.Show("Please Press Show Button");
                }

            }
            else
            {
                MessageBox.Show("Please Enter Type You Want Transfered");
            }
            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow dr = null;
            DataRow dr1 = null;
            String first_name = First_Name.Text;
            String second_Name = Second_Name.Text;
            String type = Type_Text.Text;
            cn.Close();
            cn.Open();
            //get Id_User first user
            SqlCommand Id_First = new SqlCommand("Select Id_User from dbo.Users where dbo.Users.Name = '" + first_name + "'", cn);//Command Query     
            SqlCommand Id_second = new SqlCommand("Select Id_User from dbo.Users where dbo.Users.Name = '" + second_Name + "'", cn);//Command Query     
            Object First = Id_First.ExecuteScalar();
            Object Second = Id_second.ExecuteScalar();
            if (First == null || Second == null)
            {
                MessageBox.Show("one of this users not found in Inventory");
            }
            else
            {

                Id_First_User = Conditions_Class.Get_Id(Id_First);
                Id_Second_User = Conditions_Class.Get_Id(Id_second);
                if (type == "Desktop")
                {
                    DataTable dt1 = new DataTable();

                    dt1.Columns.Add("Name");
                    dt1.Columns.Add("Desktop Serial Number");
                    dt1.Columns.Add("Desktop Brand");
                    dt1.Columns.Add("Desktop Model");
                    dt1.Columns.Add("Desktop Processor");
                    dt1.Columns.Add("Desktop Ram");
                    dt1.Columns.Add("Desktop Hard");
                    dt1.Columns.Add("Desktop Note");
                    dr = dt1.NewRow();//add new row in data table

                    //get first Desktop Details
                    SqlCommand First_Desk = new SqlCommand("Select Serial_Number_Desk, Brand_Desktop, Model_Desktop, Processor_Desktop, Ram_Desktop, Hard_Desktop, Note_Desktop from dbo.Desktop where dbo.Desktop.Id_User = '" + Id_First_User + "'", cn);//Command Query     
                    SqlDataReader sdr4 = First_Desk.ExecuteReader();
                    string[] numb4 = new string[sdr4.FieldCount];
                    //get first desktop data in numb4
                    while (sdr4.Read())
                    {
                        for (int l = 0; l < sdr4.FieldCount; l++)
                        {
                            numb4[l] = sdr4[l].ToString();
                        }
                    }

                    //put first desktop data in row dr
                    dr["Name"] = first_name;
                    dr["Desktop Serial Number"] = numb4[0];
                    dr["Desktop Brand"] = numb4[1];
                    dr["Desktop Model"] = numb4[2];
                    dr["Desktop Processor"] = numb4[3];
                    dr["Desktop Ram"] = numb4[4];
                    dr["Desktop Hard"] = numb4[5];
                    dr["Desktop Note"] = numb4[6];
                    sdr4.Close();
                    dt1.Rows.Add(dr);
                    //get Second Desktop Details
                    SqlCommand Second_Desk = new SqlCommand("Select Serial_Number_Desk, Brand_Desktop, Model_Desktop, Processor_Desktop, Ram_Desktop, Hard_Desktop, Note_Desktop from dbo.Desktop where dbo.Desktop.Id_User = '" + Id_Second_User + "'", cn);//Command Query     
                    dr1 = dt1.NewRow();
                    SqlDataReader sdr5 = Second_Desk.ExecuteReader();
                    string[] numb5 = new string[sdr5.FieldCount];
                    //get first desktop data in numb4
                    while (sdr5.Read())
                    {
                        for (int l = 0; l < sdr5.FieldCount; l++)
                        {
                            numb5[l] = sdr5[l].ToString();
                        }
                    }

                    //put first desktop data in row dr
                    dr1["Name"] = second_Name;
                    dr1["Desktop Serial Number"] = numb5[0];
                    dr1["Desktop Brand"] = numb5[1];
                    dr1["Desktop Model"] = numb5[2];
                    dr1["Desktop Processor"] = numb5[3];
                    dr1["Desktop Ram"] = numb5[4];
                    dr1["Desktop Hard"] = numb5[5];
                    dr1["Desktop Note"] = numb5[6];
                    dt1.Rows.Add(dr1);
                    sdr5.Close();
                    Search_Grid.DataSource = dt1;

                }
                else if (type == "Laptop")
                {
                    DataTable dt1 = new DataTable();

                    dt1.Columns.Add("Name");
                    dt1.Columns.Add("Laptop Serial Number");
                    dt1.Columns.Add("Laptop Brand");
                    dt1.Columns.Add("Laptop Model");
                    dt1.Columns.Add("Laptop Processor");
                    dt1.Columns.Add("Laptop Ram");
                    dt1.Columns.Add("Laptop Hard");
                    dt1.Columns.Add("Laptop Note");
                    dr = dt1.NewRow();//add new row in data table

                    //get first Desktop Details
                    SqlCommand First_Desk = new SqlCommand("Select Serial_Number_Lap, Brand_Lap, Model_Lap, Processor_Lap, Ram_Lap, Hard_Lap, Note_Lap from dbo.Laptops where dbo.Laptops.Id_User = '" + Id_First_User + "'", cn);//Command Query     
                    SqlDataReader sdr4 = First_Desk.ExecuteReader();
                    string[] numb4 = new string[sdr4.FieldCount];
                    //get first desktop data in numb4
                    while (sdr4.Read())
                    {
                        for (int l = 0; l < sdr4.FieldCount; l++)
                        {
                            numb4[l] = sdr4[l].ToString();
                        }
                    }

                    //put first desktop data in row dr
                    dr["Name"] = first_name;
                    dr["Laptop Serial Number"] = numb4[0];
                    dr["Laptop Brand"] = numb4[1];
                    dr["Laptop Model"] = numb4[2];
                    dr["Laptop Processor"] = numb4[3];
                    dr["Laptop Ram"] = numb4[4];
                    dr["Laptop Hard"] = numb4[5];
                    dr["Laptop Note"] = numb4[6];
                    sdr4.Close();
                    dt1.Rows.Add(dr);
                    //get Second Desktop Details
                    SqlCommand Second_Desk = new SqlCommand("Select Serial_Number_Lap, Brand_Lap, Model_Lap, Processor_Lap, Ram_Lap, Hard_Lap, Note_Lap from dbo.Laptops where dbo.Laptops.Id_User = '" + Id_Second_User + "'", cn);//Command Query     
                    dr1 = dt1.NewRow();
                    SqlDataReader sdr5 = Second_Desk.ExecuteReader();
                    string[] numb5 = new string[sdr5.FieldCount];
                    //get first desktop data in numb4
                    while (sdr5.Read())
                    {
                        for (int l = 0; l < sdr5.FieldCount; l++)
                        {
                            numb5[l] = sdr5[l].ToString();
                        }
                    }

                    //put first desktop data in row dr
                    //put first desktop data in row dr
                    dr1["Name"] = second_Name;
                    dr1["Laptop Serial Number"] = numb5[0];
                    dr1["Laptop Brand"] = numb5[1];
                    dr1["Laptop Model"] = numb5[2];
                    dr1["Laptop Processor"] = numb5[3];
                    dr1["Laptop Ram"] = numb5[4];
                    dr1["Laptop Hard"] = numb5[5];
                    dr1["Laptop Note"] = numb5[6];
                    dt1.Rows.Add(dr1);
                    sdr5.Close();
                    Search_Grid.DataSource = dt1;

                }
                else if (type == "Monitor")
                {

                    DataTable dt1 = new DataTable();

                    dt1.Columns.Add("Name");
                    dt1.Columns.Add("Monitor Serial Number");
                    dt1.Columns.Add("Monitor Brand");
                    dt1.Columns.Add("Monitor Model");
                    dt1.Columns.Add("Monitor Note");
                    dr = dt1.NewRow();//add new row in data table

                    //get first Desktop Details
                    SqlCommand First_Desk = new SqlCommand("Select Serial_Number_Monitor, Brand_Monitor, Model_Monitor, Note_Monitor from dbo.Monitor where dbo.Monitor.Id_User = '" + Id_First_User + "'", cn);//Command Query     
                    SqlDataReader sdr4 = First_Desk.ExecuteReader();
                    string[] numb4 = new string[sdr4.FieldCount];
                    //get first desktop data in numb4
                    while (sdr4.Read())
                    {
                        for (int l = 0; l < sdr4.FieldCount; l++)
                        {
                            numb4[l] = sdr4[l].ToString();
                        }
                    }

                    //put first desktop data in row dr
                    dr["Name"] = first_name;
                    dr["Monitor Serial Number"] = numb4[0];
                    dr["Monitor Brand"] = numb4[1];
                    dr["Monitor Model"] = numb4[2];
                    dr["Monitor Note"] = numb4[3];
                    sdr4.Close();
                    dt1.Rows.Add(dr);
                    //get Second Desktop Details
                    SqlCommand Second_Desk = new SqlCommand("Select Serial_Number_Monitor, Brand_Monitor, Model_Monitor, Note_Monitor from dbo.Monitor where dbo.Monitor.Id_User = '" + Id_Second_User + "'", cn);//Command Query     
                    dr1 = dt1.NewRow();
                    SqlDataReader sdr5 = Second_Desk.ExecuteReader();
                    string[] numb5 = new string[sdr5.FieldCount];
                    //get first desktop data in numb4
                    while (sdr5.Read())
                    {
                        for (int l = 0; l < sdr5.FieldCount; l++)
                        {
                            numb5[l] = sdr5[l].ToString();
                        }
                    }

                    //put first desktop data in row dr
                    //put first desktop data in row dr
                    dr1["Name"] = second_Name;
                    dr1["Monitor Serial Number"] = numb5[0];
                    dr1["Monitor Brand"] = numb5[1];
                    dr1["Monitor Model"] = numb5[2];
                    dr1["Monitor Note"] = numb5[3];
                    dt1.Rows.Add(dr1);
                    sdr5.Close();
                    Search_Grid.DataSource = dt1;

                }
                else
                {
                    MessageBox.Show("Please Enter Type You Want Transfered");
                }
                    cn.Close();
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            Inventory_CURD invent = new Inventory_CURD();
            invent.Show();
            this.Hide();
        }
    }
}
