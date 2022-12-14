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
    public partial class Add_New_Monitor_From_Spare_New_User : Form
    {
        private Rectangle PictureBox1OriginalRect;
        private Rectangle PictureBox2OriginalRect;
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        private Rectangle button4OriginalRect;
        private Rectangle datagridviewOriginalRect;
        private Rectangle datagridview1OriginalRect;
        private Size formOriginalSize;
        public Add_New_Monitor_From_Spare_New_User()
        {
            InitializeComponent();
            //SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
            
        }
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        public List<string> details = new List<string>();
        int i;
        int f = 0;
        int numbers = 0;
        //SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
        public static string Name2;

        
        private void Add_New_Monitor_From_Spare_New_User_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            PictureBox1OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            PictureBox2OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            button1OriginalRect = new Rectangle(back.Location.X, back.Location.Y, back.Width, back.Height);
            button2OriginalRect = new Rectangle(undo.Location.X, undo.Location.Y, undo.Width, undo.Height);
            button4OriginalRect = new Rectangle(next.Location.X, next.Location.Y, next.Width, next.Height);
            datagridviewOriginalRect = new Rectangle(Search_Grid.Location.X, Search_Grid.Location.Y, Search_Grid.Width, Search_Grid.Height);
            datagridview1OriginalRect = new Rectangle(grid_2.Location.X, grid_2.Location.Y, grid_2.Width, grid_2.Height);
            Connection_Class.DB_cn();
            Connection_Class.open();
            Name2 = Add_User_Form.Name3;
            //Get spare type from Spare table
            dt1.Columns.Add("#");
            dt1.Columns.Add("Check", typeof(bool));
            dt1.Columns.Add("Type");
            dt1.Columns.Add("Brand");
            dt1.Columns.Add("Model");
            dt1.Columns.Add("Serial_Number");
            dt1.Columns.Add("Note");
            
            List<Int32> Id_monitor = new List<Int32>();
            SqlCommand monitor_Ids = new SqlCommand("Select  Id_Spare from dbo.Spare where Spare.Type='Monitor' ", Connection_Class.cn);//Select id Users own this software
            SqlDataReader sdr1 = monitor_Ids.ExecuteReader();
            while (sdr1.Read())

            {

                Id_monitor.Add(sdr1.GetInt32((sdr1.GetOrdinal("Id_Spare"))));


            }
            if (Id_monitor.Count == 0)
            {
                Search_Grid.DataSource = dt1;
                for (int o = 1; o < 7; o++)
                {
                    Search_Grid.Columns[o].Width = 300;
                }
            }
            else
            {
                for (int s = 0; s < Id_monitor.Count; s++)
                {
                    numbers+=1;
                    SqlCommand Spare_Type = new SqlCommand("Select Type,Brand,Model,Serial_Number,Note from dbo.Spare Where Spare.Id_Spare='"+ Id_monitor[s] + "'  ", Connection_Class.cn);//Command Query     
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
                    dr["Brand"] = numb2[1];
                    dr["Model"] = numb2[2];
                    //Fill device Type 
                    dr["Serial_Number"] = numb2[3];
                    dr["Note"] = numb2[4];
                    dt1.Rows.Add(dr);

                    Search_Grid.DataSource = dt1;
                    Search_Grid.Width = 650;
                    Search_Grid.Columns[0].Width = 30;
                    foreach (DataGridViewColumn c in Search_Grid.Columns)
                    {
                        c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                        c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    for (int o = 1; o < 7; o++)
                    {
                        Search_Grid.Columns[o].Width = 300;
                    }

                }
            }

            ////////////////////////////////////
            dt2.Columns.Add("#");
            dt2.Columns.Add("Type");
            dt2.Columns.Add("Brand");
            dt2.Columns.Add("Model");
            dt2.Columns.Add("Serial_Number");
            dt2.Columns.Add("Note");
            //add Device type column
            
            grid_2.DataSource = dt2;
            grid_2.Width = 650;
            grid_2.Columns[0].Width = 30;
            foreach (DataGridViewColumn c in grid_2.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            for (int o = 1; o < 6; o++)
            {
                grid_2.Columns[o].Width = 300;
            }
            Connection_Class.Close();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Add_Monitor_Options m = new Add_Monitor_Options();
            m.Show();
            this.Hide();

                
        }

        private void next_Click(object sender, EventArgs e)
        {
            Connection_Class.DB_cn();
            Connection_Class.open();
            foreach (DataGridViewRow r in Search_Grid.Rows)
            {

                if (Convert.ToBoolean(r.Cells[1].Value))
                {
                    f += 1;

                }

            }
            if (f == 0)
            {
                MessageBox.Show("First,You must check to choose monitor you want ");
            }
            else if (f > 1)
            {
                MessageBox.Show("You must choose only one device ");
                Add_New_Monitor_From_Spare_New_User add = new Add_New_Monitor_From_Spare_New_User();
                add.Show();
                this.Hide();
            }
            else
            {
                foreach (DataGridViewRow row in Search_Grid.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[1].Value))
                    {
                        details.Clear();
                        for (i = 0; i < row.Cells.Count; i++)
                        {
                            details.Add(Search_Grid.Rows[row.Index].Cells[i].Value.ToString());


                            //Console.WriteLine(details[i].ToString());

                        }
                        DataRow dr1 = dt2.NewRow();
                        dr1["#"] = 1;
                        dr1["Type"] = details[2];
                        dr1["Brand"] = details[3];
                        //Fill device Type 
                        dr1["Model"] = details[4];
                        dr1["Serial_Number"] = details[5];
                        dr1["Note"] = details[6];
                        dt2.Rows.Add(dr1);
                        grid_2.DataSource = dt2;
                        Search_Grid.Rows.RemoveAt(row.Index);
                        for (int o = 1; o < 6; o++)
                        {
                            grid_2.Columns[o].Width = 300;
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


                            SqlCommand get_id_user = new SqlCommand("select max(Id_User) from dbo.Users", Connection_Class.cn);
                            Int32 id = Conditions_Class.Get_Id(get_id_user);
                            Console.WriteLine(id);
                            SqlCommand insert_into_soft = new SqlCommand("INSERT INTO dbo.Monitor Values( '" + details[5] + "' , '" + details[3] + "','" + details[4] + "' , '" + details[6] + "','" + id + "')", Connection_Class.cn);
                            insert_into_soft.ExecuteNonQuery();
                            MessageBox.Show("Data Inserted Successfully");
                            SqlCommand delete_from_spare = new SqlCommand("Delete from dbo.Spare Where Spare.Type='" + details[2] + "' AND Spare.Brand='" + details[3] + "' AND Spare.Model='" + details[4] + "' AND Spare.Serial_Number='" + details[5] + "' AND Spare.Note='" + details[6] + "'; ", Connection_Class.cn);
                            delete_from_spare.ExecuteNonQuery();
                            Add_Software_Options_New_User add = new Add_Software_Options_New_User();
                            add.Show();
                            this.Hide();
                        }
                    }
                 
                }
            }
            Connection_Class.Close();
        }

        private void undo_Click(object sender, EventArgs e)
        {
            Connection_Class.DB_cn();
            Connection_Class.open();
            SqlCommand get_id = new SqlCommand("select Id_User from Users where Name ='" + Name2 + "'", Connection_Class.cn);
            int id = Conditions_Class.Get_Id(get_id);

            SqlCommand get_id_desk = new SqlCommand("select Id_User from Monitor where Monitor.Id_User='" + id + "' ", Connection_Class.cn);
            object id_obj = get_id_desk.ExecuteScalar();
            if (id_obj == null)
            {
                MessageBox.Show("You can't use Undo ");

            }
            else
            {
                SqlCommand get_id_user = new SqlCommand("Insert into Spare(Spare.Type,Spare.Serial_Number,Spare.Brand,Spare.Model,Spare.Note)select 'Monitor', Monitor.Serial_Number_Monitor,Monitor.Brand_Monitor,Monitor.Model_Monitor,ISNULL(Monitor.Note_Monitor,'')+' '+'Old'+' '+'" + Name2 + "' From Monitor WHERE Monitor.Id_User in(SELECT Id_User from dbo.Users where Name='" + Name2 + "')", Connection_Class.cn);
                //Int32 id = Conditions_Class.Get_Id(get_id_user);
                //SqlCommand get_id_user = new SqlCommand("select max(Id_User) from dbo.Users", Connection_Class.cn);
                get_id_user.ExecuteNonQuery();
                SqlCommand delete_from_spare = new SqlCommand("Delete from dbo.Monitor Where dbo.Monitor.Id_User = '" + id + "'; ", Connection_Class.cn);
                delete_from_spare.ExecuteNonQuery();
                MessageBox.Show(" Undo Done ");
            }

            Connection_Class.Close();
        }
        private void Add_New_Monitor_From_Spare_New_User_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
        private void resizeChildControls()
        {
            resizeControl(PictureBox1OriginalRect, pictureBox1);
            resizeControl(PictureBox2OriginalRect, pictureBox2);
            resizeControl(button1OriginalRect, back);
            resizeControl(button2OriginalRect, undo);
            resizeControl(button4OriginalRect, next);
            resizeControl(datagridviewOriginalRect, Search_Grid);
            resizeControl(datagridview1OriginalRect, grid_2);



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
