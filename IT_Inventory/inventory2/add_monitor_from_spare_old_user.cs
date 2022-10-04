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
    public partial class add_monitor_from_spare_old_user : Form
    {
        public add_monitor_from_spare_old_user()
        {
            InitializeComponent();
            
            
            
        }
        string value1;
        string value2;
        string value3;
        string value4;
        string value5;


        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-OG2M2CI;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;Integrated Security=True");
        

        private void save_Click(object sender, EventArgs e)
        {
           

            cn.Open();
            //SqlCommand get_id_user = new SqlCommand("select Id_User from dbo.Users whwere Users.Name='" + Edit_Form.userName + "'", cn);
            //Int32 id = Conditions_Class.Get_Id(get_id_user);
            //Console.WriteLine(id);
            //SqlCommand Monitor_Found = new SqlCommand("select Id_User from dbo.Monitor whwere Users.Name='" + Edit_Form.userName + "'", cn);

            //SqlCommand insert_into_soft = new SqlCommand("INSERT INTO dbo.Monitor Values( '" + value4 + "' , '" + value2 + "' , '" + value3 + "','" + value5 + "','" + id + "')", cn);
            //insert_into_soft.ExecuteNonQuery();
            //MessageBox.Show("Data Inserted Successfully");

            //SqlCommand delete_from_spare = new SqlCommand("Delete from dbo.Spare Where Spare.type='" + value1 + "'AND Spare.Brand='" + value2 + "'AND Spare.Model='" + value3 + "'AND Spare.Serial_Number='" + value4 + "'AND Spare.Note='" + value5 + "'; ", cn);
            //delete_from_spare.ExecuteNonQuery();
            //Search_Grid.ClearSelection();
            cn.Close();
        }

        private void add_monitor_from_spare_old_user_Load(object sender, EventArgs e)
        {
            cn.Open();
            //Get spare type from Spare table
            SqlCommand Spare_Type = new SqlCommand("Select Type,Brand,Model,Serial_Number,Note from dbo.Spare Where Spare.Type='Monitor'", cn);//Command Query     
            //Search_Grid.DataSource = Spare_Type;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Spare_Type;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Search_Grid.DataSource = dt;
            Search_Grid.Width = 800;
            Search_Grid.Columns[0].Width = 30;
            foreach (DataGridViewColumn c in Search_Grid.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            for (int o = 1; o < 5; o++)
            {
                Search_Grid.Columns[o].Width = 205;
            }
            cn.Close();
        }

        private void next_Click(object sender, EventArgs e)
        {

        }
    }
}
