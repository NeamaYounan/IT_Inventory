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

namespace inventory2
{
    public partial class Form1 : Form
    {
        private Rectangle pictureBox1OriginalRect;
        private Rectangle pictureBox2OriginalRect;
        private Rectangle grid10riginalRect;
        private Rectangle grid20riginalRect;
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        private Size formOriginalSize;
        public Form1()
        {
            InitializeComponent();
        }
        public List<string> details = new List<string>();
        int i;
        int f = 0;
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        private void Form1_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            pictureBox1OriginalRect = new Rectangle(pictureBox3.Location.X, pictureBox3.Location.Y, pictureBox3.Width, pictureBox3.Height);
            pictureBox2OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            grid10riginalRect = new Rectangle(data_grid.Location.X, data_grid.Location.Y, data_grid.Width, data_grid.Height);
            grid20riginalRect = new Rectangle(grid_2.Location.X, grid_2.Location.Y, grid_2.Width, grid_2.Height);
            button1OriginalRect = new Rectangle(Back.Location.X, Back.Location.Y, Back.Width, Back.Height);
            button2OriginalRect = new Rectangle(Save.Location.X, Save.Location.Y, Save.Width, Save.Height);
            Connection_Class.Close();
            Connection_Class.open();
            dt1.Columns.Add("Check", typeof(bool));
            dt1.Columns.Add("Type");
            dt1.Columns.Add("Brand");
            dt1.Columns.Add("Model");
            dt1.Columns.Add("Serial_Number");
            dt1.Columns.Add("Note");

            List<Int32> Id_spare = new List<Int32>();
            SqlCommand lap_Ids = new SqlCommand("Select  Id_Spare from dbo.Spare WHERE Spare.Type='Monitor' ", Connection_Class.cn);//Select id Users own this software
            SqlDataReader sdr1 = lap_Ids.ExecuteReader();
            while (sdr1.Read())

            {

                Id_spare.Add(sdr1.GetInt32((sdr1.GetOrdinal("Id_Spare"))));


            }
            for (int s = 0; s < Id_spare.Count; s++)
            {
                SqlCommand Spare_Type = new SqlCommand("Select Type,Brand,Model,Serial_Number,Note from dbo.Spare where Spare.Id_Spare='" + Id_spare[s] + "' ;", Connection_Class.cn);//Command Query     

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
                dr["Check"] = false;
                dr["Type"] = numb2[0];
                dr["Brand"] = numb2[1];
                dr["Model"] = numb2[2];
                //Fill device Type 
                dr["Serial_Number"] = numb2[3];
                dr["Note"] = numb2[4];
                dt1.Rows.Add(dr);

                data_grid.DataSource = dt1;
                for (int o = 1; o < 6; o++)
                {
                    data_grid.Columns[o].Width = 205;
                }
            }

            ////////////////////////////////////
            dt2.Columns.Add("Type");
            dt2.Columns.Add("Brand");
            dt2.Columns.Add("Model");
            dt2.Columns.Add("Serial_Number");
            dt2.Columns.Add("Note");


            grid_2.DataSource = dt2;
            for (int o = 1; o < 5; o++)
            {
                data_grid.Columns[o].Width = 205;
            }
            Connection_Class.Close();

        }

        private void Save_Click(object sender, EventArgs e)
        {
            Connection_Class.DB_cn();
            Connection_Class.open();
            SqlCommand User = new SqlCommand("Select  Id_User from dbo.Users WHERE dbo.Users.Name= '" + Edit_Form.userName + "'", Connection_Class.cn);
            Int32 Id_User = Conditions_Class.Get_Id(User);
            SqlCommand Id_monitor = new SqlCommand("Select  Id_Monitor from dbo.Monitor WHERE dbo.Monitor.Id_User= '" + Id_User + "';", Connection_Class.cn);
            object Monitor = Id_monitor.ExecuteScalar();
            foreach (DataGridViewRow r in data_grid.Rows)
            {

                if (Convert.ToBoolean(r.Cells[0].Value))
                {
                    f += 1;

                }

            }
            if (f == 0)
            {
                MessageBox.Show("First,You must check to choose monitor you want ");
            }
            else
            {
                foreach (DataGridViewRow row in data_grid.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        details.Clear();
                        for (i = 0; i < row.Cells.Count; i++)
                        {
                            details.Add(data_grid.Rows[row.Index].Cells[i].Value.ToString());


                            //Console.WriteLine(details[i].ToString());

                        }
                        DataRow dr1 = dt2.NewRow();
                        dr1["Type"] = details[1];
                        dr1["Brand"] = details[2];
                        //Fill device Type 
                        dr1["Model"] = details[3];
                        dr1["Serial_Number"] = details[4];
                        dr1["Note"] = details[5];
                        dt2.Rows.Add(dr1);
                        grid_2.DataSource = dt2;
                        data_grid.Rows.RemoveAt(row.Index);
                        for (int o = 1; o < 5; o++)
                        {
                            grid_2.Columns[o].Width = 205;
                        }
                        List<string> SNS = new List<string>();
                        SqlCommand monitor_sn = new SqlCommand("SELECT Serial_Number_Monitor from Monitor ; ", Connection_Class.cn);

                        SqlDataReader sdr = monitor_sn.ExecuteReader();
                        string[] numb = new string[sdr.FieldCount];

                        while (sdr.Read())
                        {
                            for (int l = 0; l < sdr.FieldCount; l++)
                            {

                                SNS.Add(sdr[l].ToString());
                            }

                        }

                        if (SNS.Contains(details[4]))
                        {
                            MessageBox.Show("Your Inventory has this Serial Number." + "\n" + "You can't duplicate Serial Number !!");
                        }

                        else
                        {

                            if (details[1] == "Monitor")

                            {

                                //cn.Open();
                                if (Monitor != null)
                                {
                                 SqlCommand insert_into_Spare_Monitor = new SqlCommand("INSERT INTO Spare (Spare.Type,Spare.Serial_Number,Spare.Brand,Spare.Model,Spare.Note) Values( 'Monitor','" + Edit_Form.User_Data_Before[11] + "' , '" + Edit_Form.User_Data_Before[12] + "','"+ Edit_Form.User_Data_Before[13] + "','"+ Edit_Form.User_Data_Before[14] + "old"+" "+ Edit_Form.userName+"' )", Connection_Class.cn);
                                 insert_into_Spare_Monitor.ExecuteNonQuery();

                                 SqlCommand update_into_Monitor = new SqlCommand("Update dbo.Monitor set Monitor.Serial_Number_Monitor='" + details[4] + "' , Monitor.Brand_Monitor='" + details[2] + "' ,Monitor.Model_Monitor='" + details[3] + "',Monitor.Note_Monitor='" + details[5] + "' WHERE  Monitor.Id_User='" + Id_User + "'", Connection_Class.cn);
                                 update_into_Monitor.ExecuteNonQuery();
                                }
                                else
                                {
                                    SqlCommand insert_into_Monitor = new SqlCommand("INSERT INTO dbo.Monitor Values( '" + details[4] + "' , '" + details[2] + "' , '" + details[3] + "','" + details[5] + "','" + Id_User + "')", Connection_Class.cn);
                                    insert_into_Monitor.ExecuteNonQuery();
                                }
                                
                                SqlCommand delete_from_spare = new SqlCommand("Delete from dbo.Spare Where Spare.Type='" + details[1] + "' AND Spare.Brand='" + details[2] + "' AND Spare.Model='" + details[3] + "' AND Spare.Serial_Number='" + details[4] + "'  AND Spare.Note='" + details[5] + "'; ", Connection_Class.cn);
                                delete_from_spare.ExecuteNonQuery();
                                // cn.Close();
                                MessageBox.Show("Data Updated Successfully");
                                data_grid.ClearSelection();
                                Add_Software_Options_Old_User soft_old = new Add_Software_Options_Old_User();
                                soft_old.Show();
                                this.Hide();
                                //Edit_by_using_spare_Load(sender, e);
                                Connection_Class.Close();




                            }
                        }

                    }
                }
                Connection_Class.Close();
            }
        }
        private void resizeChildControls()
        {
            resizeControl(pictureBox1OriginalRect, pictureBox3);
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

        private void Form1_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
    }

}
