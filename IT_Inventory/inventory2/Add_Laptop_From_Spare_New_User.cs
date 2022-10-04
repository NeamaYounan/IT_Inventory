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
//using System.Web.UI.WebControls;

namespace inventory2
{
    public partial class Add_Laptop_From_Spare_New_User : Form
    {
        private Rectangle PictureBox1OriginalRect;
        private Rectangle PictureBox2OriginalRect;
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        private Rectangle button4OriginalRect;
        private Rectangle datagridviewOriginalRect;
        private Rectangle  datagridview2OriginalRect;
        private Size formOriginalSize;
        public Add_Laptop_From_Spare_New_User()
        {
            InitializeComponent();

           // SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
           
        }
        
        int f = 0;
        int numbers = 0;
        //SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
        public static string Name2;
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        public List<string> details = new List<string>();
        int i;
        public static bool id_l_s = false;



        private void back_Click(object sender, EventArgs e)
        {
            Add_New_User_Options add = new Add_New_User_Options();
            add.Show();
            this.Hide();

        }

        public void Add_Laptop_From_Spare_New_User_Load(object sender, EventArgs e)
        {

            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            PictureBox1OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            PictureBox2OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            datagridviewOriginalRect = new Rectangle(Search_Grid.Location.X, Search_Grid.Location.Y, Search_Grid.Width, Search_Grid.Height);
            datagridview2OriginalRect = new Rectangle(grid_2.Location.X, grid_2.Location.Y, Search_Grid.Width, grid_2.Height);
            button1OriginalRect = new Rectangle(back.Location.X, back.Location.Y, back.Width, back.Height);
            button2OriginalRect = new Rectangle(undo.Location.X, undo.Location.Y, undo.Width, undo.Height);
            button4OriginalRect = new Rectangle(button1.Location.X, button1.Location.Y, button1.Width, button1.Height);
            
            Connection_Class.DB_cn();
            Connection_Class.open();
            Name2 = Add_User_Form.Name3;
            //Get spare type from Spare table
            dt1.Columns.Add("#");
            dt1.Columns.Add("Checked", typeof(bool));
            dt1.Columns.Add("Type");
            dt1.Columns.Add("Brand");
            dt1.Columns.Add("Model");
            dt1.Columns.Add("Serial_Number");
            dt1.Columns.Add("Processor");
            dt1.Columns.Add("Hard");
            dt1.Columns.Add("Ram");
            dt1.Columns.Add("Note");

            List<Int32> Id_lap = new List<Int32>();
            SqlCommand lap_Ids = new SqlCommand("Select  Id_Spare from dbo.Spare where Spare.Type='Laptop' ", Connection_Class.cn);//Select id Users own this software
            SqlDataReader sdr1 = lap_Ids.ExecuteReader();
            while (sdr1.Read())

            {

                Id_lap.Add(sdr1.GetInt32((sdr1.GetOrdinal("Id_Spare"))));


            }
            if (Id_lap.Count == 0)
            {
                Search_Grid.DataSource = dt1;
                for (int o = 1; o < 10; o++)
                {
                    Search_Grid.Columns[o].Width = 205;
                }
            }
            else
            {
                for (int s = 0; s < Id_lap.Count; s++)
                {
                    numbers += 1;
                    SqlCommand Spare_Type = new SqlCommand("Select Type,Brand,Model,Serial_Number,Processor,Hard,Ram,Note from dbo.Spare Where  Spare.Id_Spare='" + Id_lap[s] + "'", Connection_Class.cn);//Command Query     
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
                    dr["Checked"] = false;
                    
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

                    Search_Grid.DataSource = dt1;
                    Search_Grid.Width = 650;
                    Search_Grid.Columns[0].Width = 30;
                    foreach (DataGridViewColumn c in Search_Grid.Columns)
                    {
                        c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                        c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    for (int o = 1; o < 10; o++)
                    {
                        Search_Grid.Columns[o].Width = 205;
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
                grid_2.Width = 650;
                grid_2.Columns[0].Width = 30;
                foreach (DataGridViewColumn c in grid_2.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                for (int o = 1; o < 9; o++)
                {
                    grid_2.Columns[o].Width = 205;
                }
                Connection_Class.Close();


            }
        }

        private void button1_Click(object sender, EventArgs e)
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
                MessageBox.Show("First,You must check to choose Laptop you want ");
            }
            else if (f>1)
            {
                MessageBox.Show("You must choose only one device ");
                Add_Laptop_From_Spare_New_User add=new Add_Laptop_From_Spare_New_User();
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
                        dr1["Processor"] = details[6];
                        dr1["Hard"] = details[7];
                        dr1["Ram"] = details[8];
                        dr1["Note"] = details[9];
                        dt2.Rows.Add(dr1);
                        grid_2.DataSource = dt2;
                        Search_Grid.Rows.RemoveAt(row.Index);
                        for (int o = 1; o < 9; o++)
                        {
                            grid_2.Columns[o].Width = 205;
                        }
                        List<string> SNS = new List<string>();
                        SqlCommand desk_sn = new SqlCommand("SELECT Serial_Number_Lap from Laptops ; ", Connection_Class.cn);

                        SqlDataReader sdr = desk_sn.ExecuteReader();
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
                            id_l_s = true ;
                            SqlCommand get_id_user = new SqlCommand("select max(Id_User) from dbo.Users", Connection_Class.cn);
                            Int32 id = Conditions_Class.Get_Id(get_id_user);
                            Console.WriteLine(id);
                            SqlCommand insert_into_soft = new SqlCommand("INSERT INTO dbo.Laptops Values( '" + details[5]+ "' , '" + details[3] + "' , '" + details[4] + "', '" + details[6] + "' , '" + details[8] + "','" + details[7] + "', '" + details[9] + "','" + id + "')", Connection_Class.cn);
                            insert_into_soft.ExecuteNonQuery();

                            SqlCommand delete_from_spare = new SqlCommand("Delete from dbo.Spare Where Spare.type='" + details[2] + "'AND Spare.Brand='" + details[3] + "'AND Spare.Model='" + details[4] + "'AND Spare.Serial_Number='" + details[5] + "'AND Spare.Processor='" + details[6] + "'AND Spare.Hard='" + details[7] + "'AND Spare.Ram='" + details[8] + "'AND Spare.Note='" + details[9] + "' ", Connection_Class.cn);
                            delete_from_spare.ExecuteNonQuery();
                            MessageBox.Show("Data Inserted Successfully");
                            Add_Software_Options_New_User add = new Add_Software_Options_New_User();
                            add.Show();
                            this.Hide();

                        }
                    }
                }
            }
        }

        private void undo_Click(object sender, EventArgs e)
        {
            Connection_Class.DB_cn();
            Connection_Class.open();
            SqlCommand get_id = new SqlCommand("select Id_User from Users where Name ='" + Name2 + "'", Connection_Class.cn);
            int id = Conditions_Class.Get_Id(get_id);

            SqlCommand get_id_desk = new SqlCommand("select Id_User from Laptops where Laptops.Id_User='" + id + "' ", Connection_Class.cn);
            object id_obj = get_id_desk.ExecuteScalar();
            if (id_obj == null)
            {
                MessageBox.Show("You can't use Undo ");

            }
            else
            {
                SqlCommand get_id_user = new SqlCommand("Insert into Spare(Spare.Type,Spare.Serial_Number,Spare.Brand,Spare.Model,Spare.Processor,Spare.Ram,Spare.Hard,Spare.Note)select 'Laptop', Laptops.Serial_Number_Lap,Laptops.Brand_Lap,Laptops.Model_Lap,Laptops.Processor_Lap,Laptops.Ram_Lap,Laptops.Hard_Lap,ISNULL(Laptops.Note_Lap,'')+' '+'Old'+' '+'" + Name2 + "' From Laptops WHERE Laptops.Id_User in(SELECT Id_User from dbo.Users where Name='" + Name2 + "')", Connection_Class.cn);
                //Int32 id = Conditions_Class.Get_Id(get_id_user);
                //SqlCommand get_id_user = new SqlCommand("select max(Id_User) from dbo.Users", Connection_Class.cn);
                get_id_user.ExecuteNonQuery();
                SqlCommand delete_from_spare = new SqlCommand("Delete from dbo.Laptops Where dbo.Laptops.Id_User = '" + id + "'; ", Connection_Class.cn);
                delete_from_spare.ExecuteNonQuery();
                MessageBox.Show(" Undo Done ");
            }
            Add_Laptop_From_Spare_New_User_Load(sender, e);
            Connection_Class.cn.Close();
        }
        
        private void resizeChildControls()
        {
            resizeControl(PictureBox1OriginalRect, pictureBox1);
            resizeControl(PictureBox2OriginalRect, pictureBox2);
            resizeControl(datagridviewOriginalRect, Search_Grid);
            resizeControl(datagridview2OriginalRect, grid_2);
            resizeControl(button1OriginalRect, back);
            resizeControl(button2OriginalRect, undo);
            resizeControl(button4OriginalRect, button1);
            


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

        private void Add_Laptop_From_Spare_New_User_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }

        private void Search_Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

