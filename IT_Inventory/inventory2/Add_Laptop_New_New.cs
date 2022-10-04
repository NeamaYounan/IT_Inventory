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
    public partial class Add_Laptop_New_New : Form
    {
        public Add_Laptop_New_New()
        {
            InitializeComponent();
        }
        //neama DB=DESKTOP-OG2M2CI
        //Katren DB=DESKTOP-9QTGSEL
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-OG2M2CI;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;Integrated Security=True");
        private void add_btn_Click(object sender, EventArgs e)
        {
            cn.Open();
            //Get Id User
            SqlCommand cmd1 = new SqlCommand("SELECT max(Id_User) from dbo.Users ;", cn);
            int i = Conditions_Class.Get_Id(cmd1);
            Console.WriteLine(i); //Print id user
            //Add new Laptop
            SqlCommand cmd2 = new SqlCommand("INSERT INTO  dbo.Laptops values( '" + sn_lap.Text + "', '" + brand_lab.Text + "','" + lap_model.Text + "','" + proc_lab.Text + "','" + lap_ram.Text + "','" + hard_lab .Text + "','"+note_lab.Text+ "','" + i + "')", cn);
            cmd2.ExecuteNonQuery();

            MessageBox.Show("Data Inserted Successfully.");

            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Add_Hardware_Options back = new Add_Hardware_Options();
            back.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Next_bu_Click(object sender, EventArgs e)
        {
            Add_Software_Options_New_User add_software = new Add_Software_Options_New_User();
            add_software.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Hardware_Options add_Hardware_Options = new Add_Hardware_Options();
            add_Hardware_Options.Show();
            this.Hide();
        }
    }
}
