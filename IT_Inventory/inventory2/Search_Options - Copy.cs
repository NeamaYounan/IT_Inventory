using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory2
{
    public partial class Search_Options : Form
    {
        public Search_Options()
        {
            InitializeComponent();
        }

        private void Hardware_Click(object sender, EventArgs e)
        {
            Hardware_Search search = new Hardware_Search();
            search.Show();
            this.Hide();
        }

        private void User_Name_Click(object sender, EventArgs e)
        {
            Search_Name search = new Search_Name();
            search.Show();
            this.Hide();
        }

        private void Software_Click(object sender, EventArgs e)
        {
            Software_Search search = new Software_Search();
            search.Show();
            this.Hide();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Inventory_CURD search = new Inventory_CURD();
            search.Show();
            this.Hide();
        }
    }
}
