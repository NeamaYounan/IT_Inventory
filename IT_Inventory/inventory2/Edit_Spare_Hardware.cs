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
    public partial class Edit_Spare_Hardware : Form
    {
        private Rectangle pictureBox1OriginalRect;
        private Rectangle pictureBox2OriginalRect;
        private Rectangle Grid1OriginalRect;
        private Rectangle Grid2OriginalRect;
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        
        private Size formOriginalSize;
        public Edit_Spare_Hardware()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Edit_Form edit = new Edit_Form();
            edit.Show();
            edit.Name.Text= Name1;
           edit.SearchName_Click(sender, e) ;
            this.Hide();

        }
       // SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
        string[] numb8;
        string[] numb7;
        string[] numb6;
        string value1;
        string value2;
        string value3;
        string value4;
        string value5;
        string value6;
        string value7;
        string value8;
        string value9;
        string value10;
        string value11;
        string value12;
        string Name1;
        string Lap_sn;
        string Lap_b;
        string Lap_m;
        string Lap_p;
        string Lap_h;
        string Lap_r;
        string Lap_n;
        string Desk_sn;
        string Desk_b;
        string Desk_m;
        string Desk_p;
        string Desk_h;
        string Desk_r;
        string Desk_n;
        string Monitor_sn;
        string Monitor_b;
        string Monitor_m;
        string Monitor_n;
        List<String> Types;
        List<String> Emails;
        List<String> Versions;
        List<String> Passwords;
        List<String> Keys;
        public string name;
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        public List<string> details = new List<string>();
        int i;
        int f = 0;


        private void Save_Click(object sender, EventArgs e)
        {
            int numbers = 0;
            Connection_Class.DB_cn();
            Connection_Class.open();
            SqlCommand User = new SqlCommand("Select  Id_User from dbo.Users WHERE dbo.Users.Name= '" + Edit_Form.userName+ "'", Connection_Class.cn);
            SqlCommand nameUser = new SqlCommand("Select  Name from dbo.Users WHERE dbo.Users.Name= '" + Edit_Form.userName + "'", Connection_Class.cn);
            name = Conditions_Class.Get_Name(nameUser);
            Int32 Id_User = Conditions_Class.Get_Id(User);//Get_Id
            SqlCommand Id_lapt = new SqlCommand("Select  Id_Laptop from dbo.Laptops WHERE dbo.Laptops.Id_User= '" +Id_User + "';", Connection_Class.cn);
            object Laptop = Id_lapt.ExecuteScalar();
            
            SqlCommand Id_Desk = new SqlCommand("Select  Id_Desktop from dbo.Desktop WHERE dbo.Desktop.Id_User= '" + Id_User + "';", Connection_Class.cn);
            object Desktop = Id_Desk.ExecuteScalar();
            SqlCommand Id_monitor = new SqlCommand("Select  Id_Monitor from dbo.Monitor WHERE dbo.Monitor.Id_User= '" + Id_User + "';", Connection_Class.cn);
            object Monitor = Id_monitor.ExecuteScalar();

            foreach (DataGridViewRow r in data_grid.Rows)
            {

                if (Convert.ToBoolean(r.Cells[1].Value))
                {
                    f += 1;

                }

            }
            if (f == 0)
            {
                MessageBox.Show("First,You must check to choose Laptop you want ");
            }
            else
            {
                foreach (DataGridViewRow row in data_grid.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[1].Value))
                    {
                        numbers++;
                        details.Clear();
                        for (i = 0; i < row.Cells.Count; i++)
                        {
                            details.Add(data_grid.Rows[row.Index].Cells[i].Value.ToString());


                            //Console.WriteLine(details[i].ToString());

                        }
                        DataRow dr1 = dt2.NewRow();
                        dr1["#"] = numbers;
                        dr1["Type"] = details[2];
                        dr1["Brand"] = details[3];
                        //Fill device Type 
                        dr1["Model"] = details[4];
                        dr1["Serial_Number"] = details[5];
                        dr1["Processor"] = details[6];
                        dr1["Hard"] = details[7];
                        dr1["Ram"] = details[8];
                        dr1["Note"] = details[9];
                        dt2.Rows.Add(dr1);
                        grid_2.DataSource = dt2;
                        data_grid.Rows.RemoveAt(row.Index);
                        for (int o = 1; o < 9; o++)
                        {
                            grid_2.Columns[o].Width = 205;
                        }
                        List<string> SNS = new List<string>();
                        SqlCommand desk_sn = new SqlCommand("SELECT Serial_Number_Desk ,Serial_Number_Monitor,Serial_Number_Lap   from Desktop,Laptops,Monitor ; ", Connection_Class.cn);

                        SqlDataReader sdr = desk_sn.ExecuteReader();
                        string[] numb = new string[sdr.FieldCount];

                        while (sdr.Read())
                        {
                            for (int l = 0; l < sdr.FieldCount; l++)
                            {

                                SNS.Add(sdr[l].ToString());
                            }

                        }
                        if (SNS.Contains(details[5]))
                        {
                            MessageBox.Show("Your Inventory has this Serial Number." + "\n" + "You can't duplicate Serial Number !!");
                        }
                        else
                        {
                                if (details[2] == "Laptop")
                                {/////////////////////user was have desktop and i will give it laptop from spare////////////////////////////////
                                    if (Laptop == null && Desktop != null)
                                    {
                                        Edit_Form.b = false;
                                        //cn.Open();
                                        //SqlCommand User = new SqlCommand("Select  Id_User from dbo.Users WHERE dbo.Users.Name= '" + Name1 + "'", cn);//Command Query  


                                        Console.WriteLine(Id_User);
                                        SqlCommand insert_into_Laptop = new SqlCommand("INSERT INTO dbo.Laptops Values( '" + details[5] + "' , '" + details[3] + "' , '" + details[4] + "', '" + details[6] + "' , '" + details[8] + "','" + details[7] + "', '" + details[9] + "','" + Id_User + "')", Connection_Class.cn);
                                        insert_into_Laptop.ExecuteNonQuery();

                                        SqlCommand delete_from_spare = new SqlCommand("Delete from dbo.Spare Where Spare.Type='" + details[2] + "'AND Spare.Brand='" + details[3] + "'AND Spare.Model='" + details[4] + "'AND Spare.Serial_Number='" + details[5] + "' AND Spare.Processor='" + details[6] + "'AND Spare.Hard='" + details[7] + "'AND Spare.Ram='" + details[8] + "'AND Spare.Note='" + details[9] + "'; ", Connection_Class.cn);
                                        delete_from_spare.ExecuteNonQuery();
                                        SqlCommand insert_into_spare_old_Desktop = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Serial_Number,dbo.Spare.Processor,dbo.Spare.Hard,dbo.Spare.Ram,dbo.Spare.Note ) VALUES('Desktop','" + Edit_Form.User_Data_Before[5] + "' ,'" + Edit_Form.User_Data_Before[6] + "','" + Edit_Form.User_Data_Before[4] + "','" + Edit_Form.User_Data_Before[7] + "','" + Edit_Form.User_Data_Before[9] + "','" + Edit_Form.User_Data_Before[8] + "','" + Edit_Form.User_Data_Before[10] + "'+' '+' Old '+ '  ' + '" + Edit_Form.User_Data_Before[0] + "');", Connection_Class.cn);
                                        insert_into_spare_old_Desktop.ExecuteNonQuery();

                                        int iddesk = Conditions_Class.Get_Id(Id_Desk);
                                        SqlCommand ID_Soft_Lap = new SqlCommand("select Id_Soft from Soft_Desk where Soft_Desk.Id_Desktop='" + iddesk + "'", Connection_Class.cn);
                                        SqlDataReader sdr3 = ID_Soft_Lap.ExecuteReader();
                                        List<int> Ids_Soft = new List<int>();
                                        //fill lists of ids and types 
                                        while (sdr3.Read())
                                        {
                                            Ids_Soft.Add(sdr3.GetInt32((sdr3.GetOrdinal("Id_Soft"))));
                                        Console.WriteLine(sdr3.GetInt32((sdr3.GetOrdinal("Id_Soft"))));
                                    }

                                        for (int i = 0; i < Ids_Soft.Count; i++)
                                        {
                                            SqlCommand spare_Soft = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Email,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note) Select dbo.Software.type,dbo.Software.Email,dbo.Software.Password,dbo.Software.[Key],dbo.Software.Version,'old '+'" + Edit_Form.User_Data_Before[0] + "' from dbo.Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
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
                                            Console.WriteLine("Deleted " + Ids_Soft[i] + Id_User);
                                            SqlCommand Delete_Soft = new SqlCommand("DELETE FROM Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                                                Delete_Soft.ExecuteNonQuery();
                                            }



                                        }
                                        SqlCommand Delete_Desk = new SqlCommand("DELETE FROM Desktop WHERE dbo.Desktop.Id_Desktop = '" + iddesk + "'", Connection_Class.cn);
                                        Delete_Desk.ExecuteNonQuery();
                                        SqlCommand spare_Monitor = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Serial_Number,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Note) Select 'Monitor', dbo.Monitor.Serial_Number_Monitor,dbo.Monitor.Brand_Monitor,dbo.Monitor.Model_Monitor,dbo.Monitor.Note_Monitor+' old '+'" + Edit_Form.User_Data_Before[0] + "' from dbo.Monitor WHERE dbo.Monitor.Id_User = '" + Id_User + "'", Connection_Class.cn);
                                       spare_Monitor.ExecuteNonQuery();
                                       SqlCommand Delete_Monitor = new SqlCommand("DELETE FROM Monitor WHERE dbo.Monitor.Id_User = '" + Id_User + "'", Connection_Class.cn);
                                       Delete_Monitor.ExecuteNonQuery();

                                    Add_Software_Options_Old_User soft_old = new Add_Software_Options_Old_User();
                                        soft_old.Show();
                                        this.Hide();
                                        MessageBox.Show("Data Updated Successfully");


                                    }
                                    //////////////////Laptop to Laptop/////////////////////////////
                                    else
                                    {
                                        Edit_Form.b = false;
                                        int Id_lap = Conditions_Class.Get_Id(Id_lapt);
                                        SqlCommand Add_Lap_Spare = new SqlCommand("INSERT INTO  dbo.Spare(dbo.Spare.Type,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Serial_Number,dbo.Spare.Processor,dbo.Spare.Hard,dbo.Spare.Ram,dbo.Spare.Note ) VALUES('Laptop','" + Edit_Form.User_Data_Before[5] + "' ,'" + Edit_Form.User_Data_Before[6] + "','" + Edit_Form.User_Data_Before[4] + "','" + Edit_Form.User_Data_Before[7] + "','" + Edit_Form.User_Data_Before[9] + "','" + Edit_Form.User_Data_Before[8] + "','" + Edit_Form.User_Data_Before[10] + "'+' '+' Old '+ '  ' + '" + Edit_Form.User_Data_Before[0] + "');", Connection_Class.cn);
                                        Add_Lap_Spare.ExecuteNonQuery();
                                        SqlCommand cmd2 = new SqlCommand("UPDATE dbo.Laptops set Laptops.Serial_Number_Lap='" + details[5] + "', Laptops.Brand_Lap='" + details[3] + "' , Laptops.Model_Lap='" + details[4] + "',Laptops.Processor_Lap='" + details[6] + "',Laptops.Hard_Lap='" + details[7] + "',Laptops.Ram_Lap='" + details[8] + "',Laptops.Note_Lap='" + details[9] + "' WHERE Laptops.Id_User='" + Id_User + "' AND  Laptops.Id_Laptop='" + Id_lap + "';", Connection_Class.cn);
                                        cmd2.ExecuteNonQuery();
                                        SqlCommand delete_from_spare = new SqlCommand("Delete from dbo.Spare Where Spare.Type='" + details[2] + "'AND Spare.Brand='" + details[3] + "'AND Spare.Model='" + details[4] + "'AND Spare.Serial_Number='" + details[5] + "' AND Spare.Processor='" + details[6] + "'AND Spare.Hard='" + details[7] + "'AND Spare.Ram='" + details[8] + "'AND Spare.Note='" + details[9] + "'; ", Connection_Class.cn);
                                    delete_from_spare.ExecuteNonQuery();
                                        //int Id_lap = Conditions_Class.Get_Id(Id_lapt);
                                        SqlCommand ID_Soft_Lap = new SqlCommand("select Id_Soft from Soft_Laptop where Soft_Laptop.Id_Laptop='" + Id_lap + "'", Connection_Class.cn);
                                        SqlDataReader sdr3 = ID_Soft_Lap.ExecuteReader();
                                        List<int> Ids_Soft = new List<int>();
                                        //fill lists of ids and types 
                                        while (sdr3.Read())
                                        {
                                            Ids_Soft.Add(sdr3.GetInt32((sdr3.GetOrdinal("Id_Soft"))));

                                        }
                                        for (int i = 0; i < Ids_Soft.Count; i++)
                                        {
                                            SqlCommand spare_Soft = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Email,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note) Select dbo.Software.type,dbo.Software.Email,dbo.Software.Password,dbo.Software.[Key],dbo.Software.Version,'old '+'" + Edit_Form.User_Data_Before[0] + "' from dbo.Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
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
                                            Console.WriteLine("Deleted " + Ids_Soft[i] + Id_User);
                                            SqlCommand Delete_Soft = new SqlCommand("DELETE FROM Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                                                Delete_Soft.ExecuteNonQuery();
                                            }



                                        }
                                    

                                    Add_Software_Options_Old_User soft_old = new Add_Software_Options_Old_User();
                                        soft_old.Show();
                                        this.Hide();
                                        MessageBox.Show("Data Updated Successfully");

                                    }
                                }

                                if (details[2] == "Desktop")

                                {
                                // laptop to desktop
                                if (Desktop == null && Laptop != null)
                                {
                                    Edit_Form.b = true;
                                    int Id_lap = Conditions_Class.Get_Id(Id_lapt);
                                    //cn.Open();
                                    SqlCommand insert_into_desktop = new SqlCommand("INSERT INTO dbo.Desktop Values( '" + details[5] + "' , '" + details[3] + "' , '" + details[4] + "', '" + details[6] + "' , '" + details[8] + "','" + details[7] + "', '" + details[9] + "','" + Id_User + "')", Connection_Class.cn);
                                    insert_into_desktop.ExecuteNonQuery();
                                    SqlCommand delete_from_spare = new SqlCommand("Delete from dbo.Spare Where dbo.Spare.Type='" + details[2] + "'AND Spare.Brand='" + details[3] + "'AND Spare.Model='" + details[4] + "'AND Spare.Serial_Number='" + details[5] + "' AND Spare.Processor='" + details[6] + "'AND Spare.Hard='" + details[7] + "'AND Spare.Ram='" + details[8] + "'AND Spare.Note='" + details[9] + "'; ", Connection_Class.cn);
                                    delete_from_spare.ExecuteNonQuery();
                                    // cn.Close();
                                    SqlCommand Add_Lap_Spare = new SqlCommand("INSERT INTO  dbo.Spare(dbo.Spare.Type,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Serial_Number,dbo.Spare.Processor,dbo.Spare.Hard,dbo.Spare.Ram,dbo.Spare.Note ) VALUES('Laptop','" + Edit_Form.User_Data_Before[5] + "' ,'" + Edit_Form.User_Data_Before[6] + "','" + Edit_Form.User_Data_Before[4] + "','" + Edit_Form.User_Data_Before[7] + "','" + Edit_Form.User_Data_Before[9] + "','" + Edit_Form.User_Data_Before[8] + "','" + Edit_Form.User_Data_Before[10] + "'+' '+' Old '+ '  ' + '" + Edit_Form.User_Data_Before[0] + "');", Connection_Class.cn);
                                    Add_Lap_Spare.ExecuteNonQuery();
                                    SqlCommand ID_Soft_Lap = new SqlCommand("select Id_Soft from Soft_Laptop where Soft_Laptop.Id_Laptop='" + Id_lap + "'", Connection_Class.cn);
                                    SqlDataReader sdr3 = ID_Soft_Lap.ExecuteReader();
                                    List<int> Ids_Soft = new List<int>();
                                    //fill lists of ids and types 
                                    while (sdr3.Read())
                                    {
                                        Ids_Soft.Add(sdr3.GetInt32((sdr3.GetOrdinal("Id_Soft"))));
                                    }
                                    for (int i = 0; i < Ids_Soft.Count; i++)
                                    {
                                        SqlCommand spare_Soft = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Email,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note) Select dbo.Software.type,dbo.Software.Email,dbo.Software.Password,dbo.Software.[Key],dbo.Software.Version,'old '+'" + Edit_Form.User_Data_Before[0] + "' from dbo.Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
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

                                        if (Ids_Soft_also.Contains(Ids_Soft[i]) != true)
                                        {
                                            Console.WriteLine("Deleted " + Ids_Soft[i]+Id_User);
                                            SqlCommand Delete_Soft = new SqlCommand("DELETE FROM Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                                            Delete_Soft.ExecuteNonQuery();
                                        }



                                    }


                                    SqlCommand Delete_Laptop = new SqlCommand("DELETE FROM Laptops WHERE dbo.Laptops.Id_Laptop = '" + Id_lap + "'", Connection_Class.cn);
                                    Delete_Laptop.ExecuteNonQuery();
                                    //Edit_Spare_Hardware soft_old = new Edit_Spare_Hardware();
                                    //    soft_old.Show();
                                    //    this.Hide();
                                        MessageBox.Show("Data Updated Successfully");
                                        data_grid.ClearSelection();
                                        Form1 monitor_spare=new Form1();
                                    monitor_spare.Show();
                                    this.Hide();
                                    Connection_Class.Close();
                                }
                                    ////////////////desktop to desktop//////////////
                                    else
                                    {
                                        Edit_Form.b = true;
                                        SqlCommand insert_into_spare = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Serial_Number,dbo.Spare.Processor,dbo.Spare.Hard,dbo.Spare.Ram,dbo.Spare.Note ) VALUES('Desktop','" + Edit_Form.User_Data_Before[5] + "' ,'" + Edit_Form.User_Data_Before[6] + "','" + Edit_Form.User_Data_Before[4] + "','" + Edit_Form.User_Data_Before[7] + "','" + Edit_Form.User_Data_Before[9] + "','" + Edit_Form.User_Data_Before[8] + "','" + Edit_Form.User_Data_Before[10] + "'+' '+' Old '+ '  ' + '" + Edit_Form.User_Data_Before[0] + "');", Connection_Class.cn);
                                        insert_into_spare.ExecuteNonQuery();
                                        SqlCommand cmd2 = new SqlCommand("UPDATE dbo.Desktop set Desktop.Serial_Number_Desk='" + details[5] + "', Desktop.Brand_Desktop='" + details[3] + "' , Desktop.Model_Desktop='" + details[4] + "',Desktop.Processor_Desktop='" + details[6] + "',Desktop.Hard_Desktop='" + details[7] + "',Desktop.Ram_Desktop='" + details[8] + "',Desktop.Note_Desktop='" + details[9] + "' WHERE Desktop.Id_User='" + Id_User + "';", Connection_Class.cn);
                                        cmd2.ExecuteNonQuery();

                                        SqlCommand delete_from_spare = new SqlCommand("Delete from dbo.Spare Where Spare.Type='" + details[2] + "'AND Spare.Brand='" + details[3] + "'AND Spare.Model='" + details[4] + "'AND Spare.Serial_Number='" + details[5] + "' AND Spare.Processor='" + details[6] + "'AND Spare.Hard='" + details[7] + "'AND Spare.Ram='" + details[8] + "'AND Spare.Note='" + details[9] + "';  ", Connection_Class.cn);
                                        delete_from_spare.ExecuteNonQuery();

                                        int iddesk = Conditions_Class.Get_Id(Id_Desk);//Get_Id_Desktop
                                                                                      //Insert Desktop to spare

                                        SqlCommand ID_Soft_Lap = new SqlCommand("select Id_Soft from Soft_Desk where Soft_Desk.Id_Desktop='" + iddesk + "'", Connection_Class.cn);
                                        SqlDataReader sdr3 = ID_Soft_Lap.ExecuteReader();
                                        List<int> Ids_Soft = new List<int>();
                                        //fill lists of ids and types 
                                        while (sdr3.Read())
                                        {
                                            Ids_Soft.Add(sdr3.GetInt32((sdr3.GetOrdinal("Id_Soft"))));

                                        }
                                        for (int i = 0; i < Ids_Soft.Count; i++)
                                        {
                                            SqlCommand spare_Soft = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Email,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note) Select dbo.Software.type,dbo.Software.Email,dbo.Software.Password,dbo.Software.[Key],dbo.Software.Version,'old '+'" + Edit_Form.User_Data_Before[0] + "' from dbo.Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
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
                                            Console.WriteLine("Deleted " + Ids_Soft[i] + Id_User);
                                            SqlCommand Delete_Soft = new SqlCommand("DELETE FROM Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                                                Delete_Soft.ExecuteNonQuery();
                                            }



                                        }

                                        

                                        MessageBox.Show("Data Updated Successfully");
                                        data_grid.ClearSelection();
                                    Form1 monitor_spare = new Form1();
                                    monitor_spare.Show();
                                    this.Hide();
                                    
                                    Connection_Class.Close();
                                }

                                }
                            // the user hadn't monitor and i give him one from spare 
                            if (details[2] == "Monitor")

                            {
                                if (Monitor == null)
                                {
                                    //cn.Open();
                                    SqlCommand insert_into_Monitor = new SqlCommand("INSERT INTO dbo.Monitor Values( '" + details[5] + "' , '" + details[3] + "' , '" + details[4] + "','" + details[9] + "','" + Id_User + "')", Connection_Class.cn);
                                    insert_into_Monitor.ExecuteNonQuery();
                                    SqlCommand delete_from_spare = new SqlCommand("Delete from dbo.Spare Where Spare.Type='" + details[2] + "' AND Spare.Brand='" + details[3] + "' AND Spare.Model='" + details[4] + "' AND Spare.Serial_Number='" + details[5] + "'  AND Spare.Note='" + details[9] + "'; ", Connection_Class.cn);
                                    delete_from_spare.ExecuteNonQuery();
                                    // cn.Close();
                                    MessageBox.Show("Data Updated Successfully");
                                    data_grid.ClearSelection();
                                    Edit_Form edit = new Edit_Form();
                                    edit.Show();
                                    edit.Name.Text = Name1;
                                    edit.SearchName_Click(sender, e);
                                    this.Hide();

                                    Connection_Class.Close();



                                }
                                else
                                {
                                    SqlCommand insert_into_spare = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Serial_Number,dbo.Spare.Note ) VALUES('Monitor','" + Edit_Form.User_Data_Before[11] + "' ,'" + Edit_Form.User_Data_Before[12] + "','" + Edit_Form.User_Data_Before[13] + "','" + Edit_Form.User_Data_Before[14] + "'+' '+' Old '+ '  ' + '" + Name1 + "');", Connection_Class.cn);
                                    insert_into_spare.ExecuteNonQuery();
                                    SqlCommand cmd2 = new SqlCommand("UPDATE dbo.Monitor set  Monitor.Serial_Number_Monitor='" + details[5] + "',  Monitor.Brand_Monitor='" + details[3] + "' ,  Monitor.Model_Monitor='" + details[4] + "', Monitor.Note_Monitor='" + details[9] + "' WHERE  Monitor.Id_User='" + Id_User + "';", Connection_Class.cn);
                                    cmd2.ExecuteNonQuery();


                                    SqlCommand delete_from_spare = new SqlCommand("Delete from dbo.Spare Where Spare.Type='" + details[2] + "' AND Spare.Brand='" + details[3] + "'AND Spare.Model='" + details[4] + "'AND Spare.Serial_Number='" + details[5] + "' AND Spare.Note='" + details[9] + "'; ", Connection_Class.cn);
                                    delete_from_spare.ExecuteNonQuery();
                                    MessageBox.Show("Data Updated Successfully");
                                    data_grid.ClearSelection();
                                    Edit_Form edit = new Edit_Form();
                                    edit.Show();
                                    edit.Name.Text = Name1;
                                    edit.SearchName_Click(sender, e);
                                    this.Hide();
                                    Connection_Class.Close();

                                }

                            }

                        }
                        }
                    }
                }

            Connection_Class.Close();
        } 

        private void Edit_by_using_spare_Load(object sender, EventArgs e)
        {
            int n = 0;
            Connection_Class.DB_cn();
            Connection_Class.open();
            //get id user
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            pictureBox1OriginalRect = new Rectangle(pictureBox3.Location.X, pictureBox3.Location.Y, pictureBox3.Width, pictureBox3.Height);
            pictureBox2OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            Grid1OriginalRect = new Rectangle(data_grid.Location.X, data_grid.Location.Y, data_grid.Width, data_grid.Height);
            Grid2OriginalRect = new Rectangle(grid_2.Location.X, grid_2.Location.Y, grid_2.Width, grid_2.Height);
            button1OriginalRect = new Rectangle(Back.Location.X, Back.Location.Y, Back.Width, Back.Height);
            button2OriginalRect = new Rectangle(Save.Location.X, Save.Location.Y, Save.Width, Save.Height);

            //Get spare table
            Name1 = Edit_Form.userName;
           
            Console.WriteLine(Name1);
            Lap_sn=Edit_Form.lap_sn;
            Lap_b=Edit_Form.lap_b;
            Lap_m = Edit_Form.lap_m;
            Lap_p = Edit_Form.lap_p;
            Lap_h = Edit_Form.lap_h;
            Lap_r = Edit_Form.lap_r;
            Lap_n = Edit_Form.lap_n;
            Desk_sn = Edit_Form.desk_sn;
            Desk_b = Edit_Form.desk_b;
            Desk_m = Edit_Form.desk_m;
            Desk_p = Edit_Form.desk_p;
            Desk_h = Edit_Form.desk_h;
            Desk_r = Edit_Form.desk_r;
            Desk_n = Edit_Form.desk_n;
            Monitor_sn=Edit_Form.monitor_sn;
            Monitor_b = Edit_Form.monitor_b;
            Monitor_m = Edit_Form.monitor_m;
            Monitor_n = Edit_Form.monitor_n;
             Types= Edit_Form.types;
             Emails = Edit_Form.emails;
            Versions = Edit_Form.versions;
             Passwords = Edit_Form.passwords;
             Keys = Edit_Form.keys;
            dt1.Columns.Add("#");
            dt1.Columns.Add("Check", typeof(bool));
            dt1.Columns.Add("Type");
            dt1.Columns.Add("Brand");
            dt1.Columns.Add("Model");
            dt1.Columns.Add("Serial_Number");
            dt1.Columns.Add("Processor");
            dt1.Columns.Add("Hard");
            dt1.Columns.Add("Ram");
            dt1.Columns.Add("Note");

            List<Int32> Id_spare = new List<Int32>();
            SqlCommand lap_Ids = new SqlCommand("Select  Id_Spare from dbo.Spare WHERE Spare.Type='Monitor' or Spare.Type='Desktop' or Spare.Type='Laptop'", Connection_Class.cn);//Select id Users own this software
            SqlDataReader sdr1 = lap_Ids.ExecuteReader();
            while (sdr1.Read())

            {

                Id_spare.Add(sdr1.GetInt32((sdr1.GetOrdinal("Id_Spare"))));


            }
            for (int s = 0; s < Id_spare.Count; s++)
            {
                n++;
                SqlCommand Spare_Type = new SqlCommand("Select Type,Brand,Model,Serial_Number,Processor,Hard,Ram,Note from dbo.Spare where Spare.Id_Spare='"+ Id_spare [s]+ "' ;", Connection_Class.cn);//Command Query     

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
                dr["#"] = n;
                dr["Check"] = false;
                dr["Type"] = numb2[0];
                dr["Brand"] = numb2[1];
                dr["Model"] = numb2[2];
                //Fill device Type 
                dr["Serial_Number"] = numb2[3];
                dr["Processor"] = numb2[4];
                dr["Hard"] = numb2[5];
                dr["Ram"] = numb2[6];
                dr["Note"] = numb2[7];
                dt1.Rows.Add(dr);

                data_grid.DataSource = dt1;
                data_grid.Width = 800;
                data_grid.Columns[0].Width = 30;
                foreach (DataGridViewColumn c in data_grid.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                for (int o = 1; o < 10; o++)
                {
                    data_grid.Columns[o].Width = 205;
                }
            }

            ////////////////////////////////////
            dt2.Columns.Add("#");
            dt2.Columns.Add("Type");
            dt2.Columns.Add("Brand");
            dt2.Columns.Add("Model");
            dt2.Columns.Add("Serial_Number");
            dt2.Columns.Add("Processor");
            dt2.Columns.Add("Hard");
            dt2.Columns.Add("Ram");
            dt2.Columns.Add("Note");


            grid_2.DataSource = dt2;
            grid_2.Width = 800;
            data_grid.Width = 800;
            for (int o = 1; o < 9; o++)
            {
                grid_2.Columns[o].Width = 205;
            }
            Connection_Class.Close();



        }

        private void grid_2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void data_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void iTInventoryDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void laptopsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Edit_Spare_Hardware_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
        private void resizeChildControls()
        {
            resizeControl(pictureBox1OriginalRect, pictureBox3);
            resizeControl(pictureBox2OriginalRect, pictureBox1);
            resizeControl(Grid1OriginalRect, data_grid);
            resizeControl(Grid2OriginalRect, grid_2);
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
