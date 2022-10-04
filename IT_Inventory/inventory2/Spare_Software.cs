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
    public partial class Spare_Software : Form
    {
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        private Rectangle button3OriginalRect;
        private Rectangle button4OriginalRect;
        private Rectangle PictureBox1OriginalRect;
        private Rectangle PictureBox2OriginalRect;
        private Rectangle dataGridview1OriginalRect;
        private Size formOriginalSize;
        public Spare_Software()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
        String Type;
        String Key;
        String Email ;
        String Password ;
        String Version;
        String Note;
        int  f=0;
        
        private void Back_Click(object sender, EventArgs e)
        {
            Spare back = new Spare();
            back.Show();
            this.Close();
        }

        private void add_Click(object sender, EventArgs e)
        { 
            Connection_Class.DB_cn();
            Connection_Class.open();
            if (data_grid.Rows.Count > 0)
            {
                int x = data_grid.Rows.Count - 1;

                 Type = data_grid.Rows[x - 1].Cells[1].Value.ToString();
                Console.WriteLine(Type);
                
                 Key = data_grid.Rows[x - 1].Cells[2].Value.ToString();
                 Email = data_grid.Rows[x - 1].Cells[3].Value.ToString();
                Password = data_grid.Rows[x - 1].Cells[4].Value.ToString();
                 Version = data_grid.Rows[x - 1].Cells[5].Value.ToString();
                 Note = data_grid.Rows[x - 1].Cells[6].Value.ToString();
                SqlCommand insert_into_desktop = new SqlCommand("INSERT INTO dbo.Spare (Type,[Key],Email,Password,Version,Note) VALUES('" + Type + "','" + Key + "','" + Email + "', '" + Password + "', '" + Version + "', '" + Note + "');",Connection_Class.cn);  //Command Query     
                insert_into_desktop.ExecuteNonQuery();
                MessageBox.Show("You added a "+Type+" successfully to Stock");
            }
            Spare_Software_Load(sender, e);
            Connection_Class.Close();

        }

        private void Spare_Software_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size;
            PictureBox1OriginalRect = new Rectangle(pictureBox3.Location.X, pictureBox3.Location.Y, pictureBox3.Width, pictureBox3.Height);
            PictureBox2OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            button1OriginalRect = new Rectangle(Back.Location.X, Back.Location.Y, Back.Width, Back.Height);
            button2OriginalRect = new Rectangle(delete.Location.X, delete.Location.Y, delete.Width, delete.Height);
            button4OriginalRect = new Rectangle(add.Location.X, add.Location.Y, add.Width, add.Height);
            dataGridview1OriginalRect = new Rectangle(data_grid.Location.X, data_grid.Location.Y, data_grid.Width, data_grid.Height);
            int numbers = 0;
            data_grid.Width = 900;
            //data_grid.Columns[0].Width = 30;
            //dataGridView3.Columns[0].Width = 30;
            //data_grid.Columns[0].Width = 30;
            foreach (DataGridViewColumn c in data_grid.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                c.Width = 100;
            }
            Connection_Class.DB_cn();
            Connection_Class.open();
            //SqlCommand Spare_Type = new SqlCommand("Select Type,[Key],Email,Password,Version,Note from dbo.Spare where Type!='Monitor' AND Type!='Desktop' AND Type!='Laptop';", cn);//Command Query     

            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = Spare_Type;
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //data_grid.DataSource = dt;
            DataTable dt1 = new DataTable();
            //da.Fill(dt);
            dt1.Columns.Add("#");
            dt1.Columns.Add("Type");
            dt1.Columns.Add("Key");
            dt1.Columns.Add("Email");
            dt1.Columns.Add("Password");
            dt1.Columns.Add("Version");
           
            dt1.Columns.Add("Note");

            List<Int32> Id_Spare = new List<Int32>();
            SqlCommand lap_Ids = new SqlCommand("Select  Id_Spare from dbo.Spare where Type!='Monitor' AND Type!='Desktop' AND Type!='Laptop'  ", Connection_Class.cn);//Select id Users own this software
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
                    SqlCommand Spare_Type = new SqlCommand("Select Type,[Key],Email,Password,Version,Note from dbo.Spare Where  Spare.Id_Spare='" + Id_Spare[s] + "'", Connection_Class.cn);//Command Query     
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
                    dr["Key"] = numb2[1];
                    dr["Email"] = numb2[2];
                    //Fill device Type 
                    dr["Password"] = numb2[3];
                    
                    dr["Version"] = numb2[4];
                   
                    dr["Note"] = numb2[5];
                    dt1.Rows.Add(dr);

                   
                }
                data_grid.DataSource = dt1;
                data_grid.Width = 695;
                data_grid.Columns[0].Width = 30;
                foreach (DataGridViewColumn c in data_grid.Columns)
                {
                    c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                for (int o = 1; o < 7; o++)
                {
                    data_grid.Columns[o].Width = 250;
                }
            }
            Connection_Class.Close();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            Connection_Class.DB_cn();
            Connection_Class.open();
            //Check if there is atleast one row selected
            foreach (DataGridViewRow r in data_grid.Rows)
            {
                
                if(r.Selected == true)
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
                        Key = row.Cells[2].Value.ToString();
                        Email = row.Cells[3].Value.ToString();
                        Password = row.Cells[4].Value.ToString();
                        Version = row.Cells[5].Value.ToString();
                        Note = row.Cells[6].Value.ToString();
                        SqlCommand delete = new SqlCommand("Delete from Spare where (Spare.Type='" + Type + "' AND Spare.[Key]='" + Key + "' AND Spare.Version='" + Version + "' AND Spare.Note= '" + Note + "'AND Spare.Email='" + Email + "' AND Spare.Password= '" + Password + "' ) ; ", Connection_Class.cn);
                        delete.ExecuteNonQuery();
                        

                    }

                }
                MessageBox.Show("Data deleted Successfully");
            }
           
            data_grid.ClearSelection();
                    Spare_Software_Load(sender, e);
            Connection_Class.Close();
        }
        private void Spare_Software_Resize(object sender, EventArgs e)
        {
            // data_grid.Width = 1000;
            resizeChildControls();
        }
        private void resizeChildControls()
        {
            resizeControl(PictureBox1OriginalRect, pictureBox3);
            resizeControl(PictureBox2OriginalRect, pictureBox2);
            resizeControl(button1OriginalRect, Back);
            resizeControl(button2OriginalRect, delete);
            
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
    
    

