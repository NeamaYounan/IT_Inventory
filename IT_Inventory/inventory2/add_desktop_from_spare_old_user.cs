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
    public partial class add_desktop_from_spare_old_user : Form
    {
        public add_desktop_from_spare_old_user()
        {
            InitializeComponent();
            SqlConnection cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
            {
                SqlCommand cmd = new SqlCommand("SELECT Name FROM dbo.Users", cn);
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    MyCollection.Add(reader.GetString(0));
                }
                name.AutoCompleteCustomSource = MyCollection;
            }
        }
        string value1;
        string value2;
        string value3;
        string value4;
        string value5;
        string value6;
        string value7;
        string value8;
        SqlConnection cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
        private void save_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in Search_Grid.SelectedRows)
            {
                value1 = row.Cells[0].Value.ToString();
                value2 = row.Cells[1].Value.ToString();
                value3 = row.Cells[2].Value.ToString();
                value4 = row.Cells[3].Value.ToString();
                value5 = row.Cells[4].Value.ToString();
                value6 = row.Cells[5].Value.ToString();
                value7 = row.Cells[6].Value.ToString();
                value8 = row.Cells[7].Value.ToString();
                //...
            }

            cn.Open();
            SqlCommand get_id_user = new SqlCommand("select Id_User from dbo.Users whwere Users.Name='" + name.Text + "'", cn);
            Int32 id = Conditions_Class.Get_Id(get_id_user);
            Console.WriteLine(id);
            SqlCommand insert_into_desk = new SqlCommand("INSERT INTO dbo.Desktop Values( '" + value4 + "' , '" + value3 + "' , '" + value2 + "', '" + value5 + "', '" + value7 + "','" + value6 + "',  '" + value8 + "','" + id + "')", cn);
            insert_into_desk.ExecuteNonQuery();

            SqlCommand delete_from_spare = new SqlCommand("Delete from dbo.Spare Where Spare.type='" + value1 + "'AND Spare.Brand='" + value2 + "'AND Spare.Model='" + value3 + "'AND Spare.Serial_Number='" + value4 + "'AND Spare.Processor='" + value5 + "'AND Spare.Hard='" + value6 + "'AND Spare.Ram='" + value7 + "'AND Spare.Note='" + value8 + "'; ", cn);
            delete_from_spare.ExecuteNonQuery();
            MessageBox.Show("Data Inserted Successfully");
            cn.Close();
        }

       

        private void add_desktop_from_spare_old_user_Load(object sender, EventArgs e)
        {
            cn.Open();
            
            //Get spare type from Spare table
            SqlCommand Spare_Type = new SqlCommand("Select Type,Brand,Model,Serial_Number,Processor,Hard,Ram,Note from dbo.Spare ", cn);//Command Query     
            //Search_Grid.DataSource = Spare_Type;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Spare_Type;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Search_Grid.DataSource = dt;
            cn.Close();
        }

        private void next_Click(object sender, EventArgs e)
        {
            Add_Monitor_Options monitor_Options = new Add_Monitor_Options();
            monitor_Options.Show();
            this.Hide();
        }
    }
}
