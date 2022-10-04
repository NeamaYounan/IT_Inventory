using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace inventory2
{
    internal class Connection_Class
    {
        public static SqlConnection cn = new SqlConnection();
        public static void DB_cn()
        {
            cn = new SqlConnection("Data Source=10.200.139.104,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
        }
        public static void open()
        {
            if(cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
        }
        public static void Close()
        {
            if(cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
    }
}
