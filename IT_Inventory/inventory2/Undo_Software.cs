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
    public partial class Undo : Form
    {
        public Undo()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
        public static string Name2;
        private void back_Click(object sender, EventArgs e)
        {
            Add_Software_From_Spare_new_user add = new Add_Software_From_Spare_new_user();
            add.Show();
            this.Hide();
        }

        private void next_bu_Click(object sender, EventArgs e)
        {

        }

        private void Undo_Load(object sender, EventArgs e)
        {
            //cn.Open();
            //Name2 = Add_User_Form.Name3;
            //SqlCommand get_id = new SqlCommand("select Id_User from Users where Name ='" + Name2 + "'", cn);
            //int id = Conditions_Class.Get_Id(get_id);


            //SqlCommand Software_Type = new SqlCommand("Select Type,Password,Email,[Key],Version from dbo.Software,User_Soft where Software.Id_Soft in (select Id_Soft from User_Soft where Id_User='"+id+"') ", cn);//Command Query     

            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = Software_Type;
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //Search_Grid.DataSource = dt;

            //cn.Close();

        }
    }
}
