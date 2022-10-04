using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace inventory2
{
    public partial class Spare_Hardware : Form
    {
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        private Rectangle button3OriginalRect;
        private Rectangle button4OriginalRect;
        private Rectangle PictureBox1OriginalRect;
        private Rectangle PictureBox2OriginalRect;
        private Rectangle dataGridview1OriginalRect;
        private Size formOriginalSize;
        public Spare_Hardware()
        {
            InitializeComponent();
            

        }
        //SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
        
        int f = 0;
        string Type;
        string SN;
        string Brand;
        string Model;
        string Processor;
        string Hard;
        string Ram;
        string Note;
        string cell1;
        string cell2;
        string cell3;
        string cell4;
        string cell5;
        string cell6;
        string cell7;
        string cell8;
        
        private void Back_Click(object sender, EventArgs e)
        {
            Spare back = new Spare();
            back.Show();
            this.Close();
        }

        private void Spare_Hardware_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size;
            PictureBox1OriginalRect = new Rectangle(pictureBox3.Location.X, pictureBox3.Location.Y, pictureBox3.Width, pictureBox3.Height);
            PictureBox2OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            button1OriginalRect = new Rectangle(Back.Location.X, Back.Location.Y, Back.Width, Back.Height);
            button2OriginalRect = new Rectangle(delete.Location.X, delete.Location.Y, delete.Width, delete.Height);
            button3OriginalRect = new Rectangle(edit.Location.X, edit.Location.Y, edit.Width, edit.Height);
            button4OriginalRect = new Rectangle(add.Location.X, add.Location.Y, add.Width, add.Height);
            dataGridview1OriginalRect = new Rectangle(data_grid.Location.X, data_grid.Location.Y, data_grid.Width, data_grid.Height);
            int numbers = 0;
            Connection_Class.Close();
            Connection_Class.DB_cn();
            Connection_Class.open();
            
            DataTable dt1 = new DataTable();
            //da.Fill(dt);
            dt1.Columns.Add("#");
            dt1.Columns.Add("Type");
            dt1.Columns.Add("Brand");
            dt1.Columns.Add("Model");
            dt1.Columns.Add("Serial_Number");
            dt1.Columns.Add("Processor");
            dt1.Columns.Add("Hard");
            dt1.Columns.Add("Ram");
            dt1.Columns.Add("Note");

            List<Int32> Id_Spare = new List<Int32>();
            SqlCommand lap_Ids = new SqlCommand("Select  Id_Spare from dbo.Spare where Spare.Type='Desktop' or Spare.Type='Laptop' or Spare.Type='Monitor'  ", Connection_Class.cn);//Select id Users own this software
            SqlDataReader sdr1 = lap_Ids.ExecuteReader();
            while (sdr1.Read())

            {

                Id_Spare.Add(sdr1.GetInt32((sdr1.GetOrdinal("Id_Spare"))));


            }
            if (Id_Spare.Count == 0)
            {
                data_grid.DataSource = dt1;
            }
            else
            {
                for (int s = 0; s < Id_Spare.Count; s++)
                {
                    numbers += 1;
                    SqlCommand Spare_Type = new SqlCommand("Select Type,Brand,Model,Serial_Number,Processor,Hard,Ram,Note from dbo.Spare Where  Spare.Id_Spare='" + Id_Spare[s] + "'", Connection_Class.cn);//Command Query     
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
                    for (int o = 1; o < 9; o++)
                    {
                        data_grid.Columns[o].Width = 205;
                    }
                    foreach (DataGridViewColumn c in data_grid.Columns)
                    {
                        c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                        c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
            }
            Connection_Class.Close();
        }

        private void add_Click(object sender, EventArgs e)
        {
            //numbers += 1;
            Connection_Class.DB_cn();
            Connection_Class.open();
            if (data_grid.Rows.Count > 0)
            {
                int x = data_grid.Rows.Count - 1;

                Type = data_grid.Rows[x - 1].Cells[1].Value.ToString();
                Console.WriteLine(Type);
                SN = data_grid.Rows[x - 1].Cells[4].Value.ToString();
                Brand = data_grid.Rows[x - 1].Cells[2].Value.ToString();
                Model = data_grid.Rows[x - 1].Cells[3].Value.ToString();
                Processor = data_grid.Rows[x - 1].Cells[5].Value.ToString();
                Hard = data_grid.Rows[x - 1].Cells[6].Value.ToString();
                Ram = data_grid.Rows[x - 1].Cells[7].Value.ToString();
                Note = data_grid.Rows[x - 1].Cells[8].Value.ToString();
                if (Type == "Desktop")
                {
                    SqlCommand insert_into_desktop = new SqlCommand("INSERT INTO dbo.Spare(Type,Serial_Number,Brand,Model,Processor,Ram,Hard,Note) VALUES('" + Type + "','" + SN + "','" + Brand + "', '" + Model + "', '" + Processor + "','" + Ram + "', '" + Hard + "', '" + Note + "');", Connection_Class.cn);//Command Query     
                    insert_into_desktop.ExecuteNonQuery();
                    MessageBox.Show("You added a desktop successfully to Stock");
                }
                else if (Type == "Laptop")
                {
                    SqlCommand insert_into_laptop = new SqlCommand("INSERT INTO dbo.Spare(Type,Serial_Number,Brand,Model,Processor,Ram,Hard,Note) VALUES('" + Type + "','" + SN + "','" + Brand + "', '" + Model + "', '" + Processor + "','" + Ram + "', '" + Hard + "', '" + Note + "');", Connection_Class.cn);//Command Query     
                    insert_into_laptop.ExecuteNonQuery();
                    MessageBox.Show("You added a Laptop successfully to Stock");
                }
                else if (Type == "Monitor")
                {
                    SqlCommand insert_into_laptop = new SqlCommand("INSERT INTO dbo.Spare(Type,Serial_Number,Brand,Model,Note) VALUES('" + Type + "','" + SN + "','" + Brand + "', '" + Model + "',  '" + Note + "');", Connection_Class.cn);//Command Query     
                    insert_into_laptop.ExecuteNonQuery();
                    MessageBox.Show("You added a monitor successfully to Stock");
                }
            }
            Spare_Hardware_Load(sender, e);
            Connection_Class.Close();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            Connection_Class.DB_cn();
            Connection_Class.open();
            foreach (DataGridViewRow r in data_grid.Rows)
            {

                if (r.Selected == true)
                {
                    f += 1;

                }

            }
            if (f == 0)
            {
                MessageBox.Show("You must select row that you want to delete it");

            }
            else
            {
                for (int i = 1; i <= f; i++)
                {
                    foreach (DataGridViewRow row in data_grid.SelectedRows)
                    {
                        Type = row.Cells[1].Value.ToString();

                        Brand = row.Cells[2].Value.ToString();
                        Model = row.Cells[3].Value.ToString();
                        SN = row.Cells[4].Value.ToString();
                        Processor = row.Cells[5].Value.ToString();
                        Ram = row.Cells[6].Value.ToString();
                        Hard = row.Cells[7].Value.ToString();
                        Note = row.Cells[8].Value.ToString();

                        SqlCommand delete = new SqlCommand("Delete from Spare where (Spare.Type='" + Type + "' AND Spare.Serial_Number='" + SN + "' AND Brand='" + Brand + "' AND Model='" + Model + "' AND Note= '" + Note + "') OR  (Processor='" + Processor + "' AND Ram= '" + Ram + "' AND Hard='" + Hard + "') ; ", Connection_Class.cn);
                        delete.ExecuteNonQuery();
                    }

                    
                }
                MessageBox.Show("Data deleted Successfully");
            }
            
            
            data_grid.ClearSelection();
            Spare_Hardware_Load(sender, e);
            Connection_Class.Close();

        }
        
        private void edit_Click(object sender, EventArgs e)
        {
            Connection_Class.DB_cn();
            Connection_Class.open();

            foreach (DataGridViewRow r in data_grid.Rows)
            {

                if (r.Selected == true)
                {
                    f += 1;

                }

            }
            if (f == 0)
            {
                MessageBox.Show("You must select row that you want to delete it");

            }
            else
            {
                for (int i = 1; i <= f; i++)
                {
                    foreach (DataGridViewRow row in data_grid.SelectedRows)
                    {

                        cell1 = row.Cells[1].Value.ToString();
                        cell2 = row.Cells[2].Value.ToString();
                        cell3 = row.Cells[3].Value.ToString();
                        cell4 = row.Cells[4].Value.ToString();
                        cell5 = row.Cells[5].Value.ToString();
                        cell6 = row.Cells[6].Value.ToString();
                        cell7 = row.Cells[7].Value.ToString();
                        cell8 = row.Cells[8].Value.ToString();
                        
                    }
                    SqlCommand update = new SqlCommand("Update  dbo.Spare set Spare.Hard='" + cell6 + "',Spare.Ram='" + cell7 + "' ,Spare.Note='" + cell8 + "'  WHERE Spare.Serial_Number='" + cell4+"' ; ", Connection_Class.cn);
                    update.ExecuteNonQuery();
                    
                }
                MessageBox.Show("Data edited Successfully");
            }
          

                Spare_Hardware_Load(sender, e);
            Connection_Class.Close();


        }

        private void data_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Spare_Hardware_Resize(object sender, EventArgs e)
        {
           // data_grid.Width = 1000;
            resizeChildControls();
        }
        private void resizeChildControls()
        {
            resizeControl(PictureBox1OriginalRect, pictureBox3);
            resizeControl(PictureBox2OriginalRect, pictureBox1);
            resizeControl(button1OriginalRect, Back);
            resizeControl(button2OriginalRect, delete);
            resizeControl(button3OriginalRect, edit);
            resizeControl(button4OriginalRect, add);
            resizeControl(dataGridview1OriginalRect, data_grid);


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


