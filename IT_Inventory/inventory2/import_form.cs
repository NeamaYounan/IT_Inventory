using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using ExcelDataReader;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;
using Dapper;
using Z.BulkOperations;
using Z.Dapper;
using Z.Dapper.Plus;

//using Microsoft.Office.Interop.Excel;
namespace inventory2
{
    public partial class import_form : Form
    {
        private Rectangle pictureBox1OriginalRect;
        private Rectangle pictureBox2OriginalRect;
        private Rectangle datagridviewOriginalRect;
        private Rectangle label1OriginalRect;
        private Rectangle label2OriginalRect;
        private Rectangle textBox1OriginalRect;
        private Rectangle comboBoxOriginalRect;
        private Rectangle button1OriginalRect;
        private Rectangle button2OriginalRect;
        private Rectangle button3OriginalRect;
        
        
        private Size formOriginalSize;
        public import_form()
        {
            InitializeComponent();
        }
        //SqlConnection Connection_Class.cn = new SqlConnection("Data Source=10.200.139.65,1433;MultipleActiveResultSets=true;Initial Catalog=IT_Inventory;persist security info=True;User ID=it;Password=123;");
        int numbers;
        public List<string> names = new List<string>();
        public List<string> titles = new List<string>();
        public List<string> locations = new List<string>();
        public List<string> sn = new List<string>();
        public List<string> brand = new List<string>();
        public List<string> model = new List<string>();
        public List<string> processor = new List<string>();
        public List<string> hard = new List<string>();
        public List<string> ram = new List<string>();
        public List<string> note_l_d = new List<string>();
        public List<string> brand_d = new List<string>();
        public List<string> model_d = new List<string>();
        public List<string> processor_d = new List<string>();
        public List<string> hard_d = new List<string>();
        public List<string> ram_d = new List<string>();
        public List<string> sn_d = new List<string>();
        public List<string> sn_m = new List<string>();
        public List<string> brand_m = new List<string>();
        public List<string> model_m = new List<string>();
        public List<string> id_user = new List<string>();
        public List<string> soft_d_l = new List<string>();
        public int i;
        public List<string> soft_table = new List<string>();
        DataTable dt;
        DataTableCollection tableCollection;
        private void browse_Click(object sender, EventArgs e)

        {
            this.data_grid.ColumnHeadersHeight = 20;

            using (OpenFileDialog openFileDialog1 = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fname.Text = openFileDialog1.FileName;
                    try
                    {
                        using (var stream = File.Open(openFileDialog1.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration { UseHeaderRow = true }

                                });
                                tableCollection = result.Tables;
                                comboBox1.Items.Clear();
                                foreach (DataTable table in tableCollection)
                                {
                                    comboBox1.Items.Add(table.TableName);
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("First you must close the excel file that you want to import");
                        fname.Text = "";
                    }

                }

            }
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {    //create datatable
           //DataTable dt1 = new DataTable();
           dt = tableCollection[comboBox1.SelectedItem.ToString()];
           data_grid.DataSource = dt;
            //data_grid.ColumnHeadersVisible = false;
            //add user Details Columns
            //dt1.Columns.Add("Name");
            //dt1.Columns.Add("Title");
            //dt1.Columns.Add("Location");
            //dt1.Columns.Add("Serial Number");
            //dt1.Columns.Add("Brand");
            //dt1.Columns.Add("Model");
            //dt1.Columns.Add("Processor");
            //dt1.Columns.Add(" Ram");
            //dt1.Columns.Add("Hard");
            //dt1.Columns.Add(" Note");

            //dt1.Columns.Add("Monitor Serial Number");
            //dt1.Columns.Add("Monitor Brand");
            //dt1.Columns.Add("Monitor Model");
            //dt1.Columns.Add("Monitor Note");

            ////add Windows software columns
            //dt1.Columns.Add("Windows Type");
            //dt1.Columns.Add("Windows Key");
            //dt1.Columns.Add("Windows Version");
            ////add office software columns
            //dt1.Columns.Add("Office Type");
            //dt1.Columns.Add("Office Key");
            //dt1.Columns.Add("Office Email");
            //dt1.Columns.Add("Office Password");
            //dt1.Columns.Add("Office Version");

            ////add PDF software Columns
            //dt1.Columns.Add("PDF Type");
            //dt1.Columns.Add("PDF Key");
            ////dt1.Columns.Add("PDF Email");
            ////dt1.Columns.Add("PDF Password");
            //dt1.Columns.Add("PDF Version");

            ////add AntiVirus software columns
            //dt1.Columns.Add("AntiVirus Type");
            ////dt1.Columns.Add("AntiVirus Key");
            ////dt1.Columns.Add("AntiVirus Email");
            ////dt1.Columns.Add("AntiVirus Password");
            //dt1.Columns.Add("AntiVirus Version");

            ////add Cad software columns
            //dt1.Columns.Add("Cad Type");
            //dt1.Columns.Add("Cad Key");
            //dt1.Columns.Add("Cad Email");
            //dt1.Columns.Add("Cad Password");
            //dt1.Columns.Add("Cad Version");

            ////add Other1 software columns
            //dt1.Columns.Add("Other1 Type");
            //dt1.Columns.Add("Other1 Key");
            //dt1.Columns.Add("Other1 Email");
            //dt1.Columns.Add("Other1 Password");
            //dt1.Columns.Add("Other1 Version");

            ////add Other2 software columns
            //dt1.Columns.Add("Other2 Type");
            //dt1.Columns.Add("Other2 Key");
            //dt1.Columns.Add("Other2 Email");
            //dt1.Columns.Add("Other2 Password");
            //dt1.Columns.Add("Other2 Version");

            ////add other3 software columns
            //dt1.Columns.Add("Other3 Type");
            //dt1.Columns.Add("Other3 Key");
            //dt1.Columns.Add("Other3 Email");
            //dt1.Columns.Add("Other3 Password");
            //dt1.Columns.Add("Other3 Version");

            //this.data_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            //this.data_grid.ColumnHeadersHeight = this.data_grid.ColumnHeadersHeight * 2;
            //this.data_grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            //this.data_grid.CellPainting += new DataGridViewCellPaintingEventHandler(Search_Grid_CellPainting);
            //this.data_grid.Paint += new PaintEventHandler(Search_Grid_Paint);
            //this.data_grid.Scroll += new ScrollEventHandler(data_grid_Scroll);
            //this.data_grid.ColumnWidthChanged += new DataGridViewColumnEventHandler(Search_Grid_ColumnWidthChanged);

            //data_grid.ColumnHeadersDefaultCellStyle.BackColor = Color.Pink;
            //data_grid.EnableHeadersVisualStyles = false;
            data_grid.Columns[0].HeaderText = " ";
            data_grid.Columns[1].HeaderText = " User";
            data_grid.Columns[2].HeaderText = " ";
            data_grid.Columns[3].HeaderText = " ";
            data_grid.Columns[4].HeaderText = " ";
            data_grid.Columns[5].HeaderText = " ";
            data_grid.Columns[6].HeaderText = " Hardware";
            data_grid.Columns[7].HeaderText = " ";
            data_grid.Columns[8].HeaderText = " ";
            data_grid.Columns[9].HeaderText = " ";
            data_grid.Columns[10].HeaderText = " ";
            data_grid.Columns[11].HeaderText = " Monitor";
            data_grid.Columns[12].HeaderText = " ";
            data_grid.Columns[13].HeaderText = " ";
            data_grid.Columns[14].HeaderText = " ";
            data_grid.Columns[15].HeaderText = "Operating System ";
            data_grid.Columns[16].HeaderText = " ";
            data_grid.Columns[17].HeaderText = "Antivirus ";
            data_grid.Columns[18].HeaderText = " ";
            data_grid.Columns[19].HeaderText = "";
            data_grid.Columns[20].HeaderText = " MS Office ";
            data_grid.Columns[21].HeaderText = "";
            data_grid.Columns[22].HeaderText = " ";
            data_grid.Columns[23].HeaderText = " ";
            data_grid.Columns[24].HeaderText = " ";
            data_grid.Columns[25].HeaderText = " ";
            data_grid.Columns[26].HeaderText = "PDF ";
            data_grid.Columns[27].HeaderText = " ";
            data_grid.Columns[28].HeaderText = "";
            data_grid.Columns[29].HeaderText = " ";
            data_grid.Columns[30].HeaderText = "Cad&Gstar ";
            data_grid.Columns[31].HeaderText = " ";
            data_grid.Columns[32].HeaderText = " ";
            data_grid.Columns[33].HeaderText = " ";
            data_grid.Columns[34].HeaderText = "";
            data_grid.Columns[35].HeaderText = " ";
            data_grid.Columns[36].HeaderText = "";
            data_grid.Columns[37].HeaderText = " ";
            data_grid.Columns[38].HeaderText = " ";
            data_grid.Columns[39].HeaderText = " ";
            data_grid.Columns[40].HeaderText = " Other";
            data_grid.Columns[41].HeaderText = " ";
            data_grid.Columns[42].HeaderText = "";
            data_grid.Columns[43].HeaderText = " ";
            data_grid.Columns[44].HeaderText = "";
            data_grid.Columns[45].HeaderText = " ";
            data_grid.Columns[46].HeaderText = " ";
            data_grid.Columns[47].HeaderText = " ";








        }

        private void Back_Click(object sender, EventArgs e)
        {
            Inventory_CURD back = new Inventory_CURD();
            back.Show();
            this.Hide();
        }
        public int rowIndex_l;
        public int rowIndex_d;
        private void imp_Click(object sender, EventArgs e)
        {
            Connection_Class.DB_cn();
            Connection_Class.open();
            for (i = 0; i < data_grid.Rows.Count - 1; i++)
            {
                if (data_grid.Rows[i].Cells[0] != null)
                {

                    if (data_grid.Rows[i].Cells[0].Value.ToString() == "Laptops")
                    {
                        rowIndex_l = data_grid.Rows[i].Index;
                        Console.WriteLine(rowIndex_l.ToString());
                    }
                    if (data_grid.Rows[i].Cells[0].Value.ToString() == "Desktops")
                    {
                        rowIndex_d = data_grid.Rows[i].Index;
                        Console.WriteLine(rowIndex_d.ToString());
                    }
                }
            }



            ///////////////////////////////////////////////////////////////////////////////////////


            //ADD LAPTOP DETAILS IN  LISTS


            for (int j = rowIndex_l + 1; j < rowIndex_d; j++)
            {
                names.Add(data_grid.Rows[j].Cells[0].Value.ToString());
                titles.Add(data_grid.Rows[j].Cells[1].Value.ToString());
                locations.Add(data_grid.Rows[j].Cells[2].Value.ToString());
                sn_m.Add(data_grid.Rows[j].Cells[9].Value.ToString());
                brand_m.Add(data_grid.Rows[j].Cells[10].Value.ToString());
                model_m.Add(data_grid.Rows[j].Cells[11].Value.ToString());
                sn.Add(data_grid.Rows[j].Cells[3].Value.ToString());
                brand.Add(data_grid.Rows[j].Cells[4].Value.ToString());
                model.Add(data_grid.Rows[j].Cells[5].Value.ToString());
                processor.Add(data_grid.Rows[j].Cells[6].Value.ToString());
                hard.Add(data_grid.Rows[j].Cells[7].Value.ToString());
                ram.Add(data_grid.Rows[j].Cells[8].Value.ToString());
                note_l_d.Add(data_grid.Rows[j].Cells[12].Value.ToString());
            }
            //software list
            for (int i = rowIndex_l + 1; i < rowIndex_d; i++)
            {
                for (int x = 1; x < 36; x++)
                {
                    soft_d_l.Add(data_grid.Rows[i].Cells[12 + x].Value.ToString());

                }

            }
            for (int i = rowIndex_d+1; i < data_grid.Rows.Count-1; i++)
            {
                for (int x = 1; x < 36; x++)
                {
                    soft_d_l.Add(data_grid.Rows[i].Cells[12 + x].Value.ToString());

                }
                 
            }
            Console.Write(soft_d_l.Count);
            for (int I = 0; I < soft_d_l.Count; I++)
            {
                Console.WriteLine(soft_d_l[I]);
            }
            //ADD DESKTOP DETAILS IN LISTS
            for (int j = rowIndex_d + 1; j < data_grid.Rows.Count - 1; j++)
            {
                names.Add(data_grid.Rows[j].Cells[0].Value.ToString());
                titles.Add(data_grid.Rows[j].Cells[1].Value.ToString());
                locations.Add(data_grid.Rows[j].Cells[2].Value.ToString());
                sn_m.Add(data_grid.Rows[j].Cells[9].Value.ToString());
                brand_m.Add(data_grid.Rows[j].Cells[10].Value.ToString());
                model_m.Add(data_grid.Rows[j].Cells[11].Value.ToString());
                sn.Add(data_grid.Rows[j].Cells[3].Value.ToString());
                brand.Add(data_grid.Rows[j].Cells[4].Value.ToString());
                model.Add(data_grid.Rows[j].Cells[5].Value.ToString());
                processor.Add(data_grid.Rows[j].Cells[6].Value.ToString());
                hard.Add(data_grid.Rows[j].Cells[7].Value.ToString());
                ram.Add(data_grid.Rows[j].Cells[8].Value.ToString());
                note_l_d.Add(data_grid.Rows[j].Cells[12].Value.ToString());
            }
            for (int Z = 0; Z < names.Count; Z++)
            {
                if (Z >= 0 && Z < rowIndex_d - 2)
                {
                    SqlCommand cmd1 = new SqlCommand("insert into Users Values('" + names[Z] + "','" + titles[Z] + "','" + locations[Z] + "')", Connection_Class.cn);
                    cmd1.ExecuteNonQuery();

                    if (sn[Z] != null && sn[Z] != "")
                    {

                        SqlCommand cmd2 = new SqlCommand("insert into Laptops (Laptops.Serial_Number_Lap,Laptops.Brand_Lap,Laptops.Model_Lap,Laptops.Processor_Lap,Laptops.Hard_Lap,Laptops.Ram_Lap,Laptops.note_Lap,Laptops.Id_User) Select '" + sn[Z] + "','" + brand[Z] + "','" + model[Z] + "','" + processor[Z] + "','" + hard[Z] + "','" + ram[Z] + "','" + note_l_d[Z] + "',Id_User from Users where Users.Name='" + names[Z] + "' ;", Connection_Class.cn);
                        cmd2.ExecuteNonQuery();
                        if (sn_m[Z] != null && sn_m[Z] != "")
                        {

                            SqlCommand cmd3 = new SqlCommand("insert into Monitor (Monitor.Serial_Number_Monitor,Monitor.Brand_Monitor,Monitor.Model_Monitor,Monitor.note_Monitor,Monitor.Id_User) Select '" + sn_m[Z] + "','" + brand_m[Z] + "','" + model_m[Z] + "','" + note_l_d[Z] + "',Id_User from Users where Users.Name='" + names[Z] + "' ;", Connection_Class.cn);
                            cmd3.ExecuteNonQuery();
                        }
                        soft_table.Clear();
                        SqlCommand cmd = new SqlCommand("Select dbo.Software.[Key] from dbo.Software", Connection_Class.cn);
                        object soft_t = cmd.ExecuteScalar();
                        if (soft_t != null)
                        {
                            SqlDataReader sdr5 = cmd.ExecuteReader();
                            string[] numb5 = new string[sdr5.FieldCount];
                            while (sdr5.Read())
                            {
                                for (int l = 0; l < sdr5.FieldCount; l++)
                                {
                                    numb5[l] = sdr5[l].ToString();
                                    soft_table.Add(numb5[l]);
                                }
                            }
                            //for (int X = 0; X < soft_table.Count; X++)
                            //{
                            //    Console.WriteLine(soft_table[X].ToString() + "BBBBB");
                            //}
                        }
                        for (int m = Z*35; m < (Z * 35)+6; m += 3)
                        {

                            
                            if (m == Z * 35)
                            {
                                if (!soft_table.Contains(soft_d_l[m + 2]))
                                {
                                    //Console.WriteLine(m.ToString(), soft_d_l[m + 2], soft_d_l[m ], soft_d_l[m + 1] ,"Win");
                                    Console.WriteLine("HI wINDOWS");
                                    SqlCommand cmd9 = new SqlCommand("insert into Software Values('" + "" + "','" + "" + "','" + soft_d_l[m + 2] + "','" + soft_d_l[m] + "','" + soft_d_l[m + 1] + "')", Connection_Class.cn);
                                    cmd9.ExecuteNonQuery();
                                    SqlCommand cmd6 = new SqlCommand("insert into User_Soft(Id_Soft,Id_User) Select Id_Soft, Id_User from Users,Software where Users.Name = '" + names[Z] + "' AND Software.Type='" + soft_d_l[m] + "' AND Software.[Key]='" + soft_d_l[m + 2] + "' AND Software.Version='" + soft_d_l[m + 1] + "'; ", Connection_Class.cn);
                                    cmd6.ExecuteNonQuery();
                                    SqlCommand cmd7 = new SqlCommand("insert into Soft_Laptop(Id_Soft,Id_Laptop) Select Id_Soft, Id_Laptop from Laptops,Software where Laptops.Id_User IN(select Id_User from Users where Users.Name = '" + names[Z] + "' ) AND Software.Type='" + soft_d_l[m] + "'  AND Software.[Key]='" + soft_d_l[m + 2] + "' AND Software.Version='" + soft_d_l[m + 1] + "'; ", Connection_Class.cn);
                                    cmd7.ExecuteNonQuery();
                                }
                                else
                                {
                                    SqlCommand cmd6 = new SqlCommand("insert into User_Soft(Id_Soft,Id_User) Select Id_Soft, Id_User from Users,Software where Users.Name = '" + names[Z] + "' AND Software.Type='" + soft_d_l[m] + "' AND Software.[Key]='" + soft_d_l[m + 2] + "' AND Software.Version='" + soft_d_l[m + 1] + "'; ", Connection_Class.cn);
                                    cmd6.ExecuteNonQuery();
                                    SqlCommand cmd7 = new SqlCommand("insert into Soft_Laptop(Id_Soft,Id_Laptop) Select Id_Soft, Id_Laptop from Laptops,Software where Laptops.Id_User IN(select Id_User from Users where Users.Name = '" + names[Z] + "' ) AND Software.Type='" + soft_d_l[m] + "'  AND Software.[Key]='" + soft_d_l[m + 2] + "' AND Software.Version='" + soft_d_l[m + 1] + "'; ", Connection_Class.cn);
                                    cmd7.ExecuteNonQuery();
                                }
                            }

                            else
                            {
                                if (!soft_table.Contains(soft_d_l[m + 2]))
                                {
                                    SqlCommand cmd9 = new SqlCommand("insert into Software Values('" + "" + "','" + "" + "','" + "" + "','" + soft_d_l[m] + "','" + soft_d_l[m + 1] + "')", Connection_Class.cn);
                                    cmd9.ExecuteNonQuery();
                                    SqlCommand cmd6 = new SqlCommand("insert into User_Soft(Id_Soft,Id_User) Select Id_Soft, Id_User from Users,Software where Users.Name = '" + names[Z] + "' AND Software.Type='" + soft_d_l[m] + "'  AND Software.Version='" + soft_d_l[m + 1] + "'; ", Connection_Class.cn);
                                    cmd6.ExecuteNonQuery();
                                    SqlCommand cmd7 = new SqlCommand("insert into Soft_Laptop(Id_Soft,Id_Laptop) Select Id_Soft, Id_Laptop from Laptops,Software where Laptops.Id_User IN(select Id_User from Users where Users.Name = '" + names[Z] + "' ) AND Software.Type='" + soft_d_l[m] + "' AND Software.Version='" + soft_d_l[m + 1] + "'; ", Connection_Class.cn);
                                    cmd7.ExecuteNonQuery();
                                }
                                else
                                {
                                    SqlCommand cmd6 = new SqlCommand("insert into User_Soft(Id_Soft,Id_User) Select Id_Soft, Id_User from Users,Software where Users.Name = '" + names[Z] + "' AND Software.Type='" + soft_d_l[m] + "' AND Software.[Key]='" + soft_d_l[m + 2] + "' AND Software.Version='" + soft_d_l[m + 1] + "'; ", Connection_Class.cn);
                                    cmd6.ExecuteNonQuery();
                                    SqlCommand cmd7 = new SqlCommand("insert into Soft_Laptop(Id_Soft,Id_Laptop) Select Id_Soft, Id_Laptop from Laptops,Software where Laptops.Id_User IN(select Id_User from Users where Users.Name = '" + names[Z] + "' ) AND Software.Type='" + soft_d_l[m] + "'  AND Software.[Key]='" + soft_d_l[m + 2] + "' AND Software.Version='" + soft_d_l[m + 1] + "'; ", Connection_Class.cn);
                                    cmd7.ExecuteNonQuery();
                                }
                            }
                        }
                        //Antivirus and windows case to add two empty values in software table
                        for (int N = (Z * 35)+5; N<(Z * 35) + 35; N += 5)
                        {
                            
                            if (soft_d_l[N] != "")
                            {
                                if (!soft_table.Contains(soft_d_l[N + 2]))
                                {
                                    SqlCommand cmd5 = new SqlCommand("insert into Software Values('" + soft_d_l[N + 3] + "','" + soft_d_l[N + 4] + "','" + soft_d_l[N + 2] + "','" + soft_d_l[N] + "','" + soft_d_l[N + 1] + "')", Connection_Class.cn);
                                    cmd5.ExecuteNonQuery();
                                    SqlCommand cmd6 = new SqlCommand("insert into User_Soft(Id_Soft,Id_User) Select Id_Soft, Id_User from Users,Software where Users.Name = '" + names[Z] + "' AND Software.Type='" + soft_d_l[N] + "' AND Software.Email='" + soft_d_l[N + 3] + "' AND Software.[Key]='" + soft_d_l[N + 2] + "' AND Software.Password='" + soft_d_l[N + 4] + "'AND Software.Version='" + soft_d_l[N + 1] + "'; ", Connection_Class.cn);
                                    cmd6.ExecuteNonQuery();
                                    SqlCommand cmd7 = new SqlCommand("insert into Soft_Laptop(Id_Soft,Id_Laptop) Select Id_Soft, Id_Laptop from Laptops,Software where Laptops.Id_User IN(select Id_User from Users where Users.Name = '" + names[Z] + "' ) AND Software.Type='" + soft_d_l[N] + "' AND Software.Email='" + soft_d_l[N + 3] + "' AND Software.[Key]='" + soft_d_l[N + 2] + "' AND Software.Password='" + soft_d_l[N + 4] + "'AND Software.Version='" + soft_d_l[N + 1] + "'; ", Connection_Class.cn);
                                    cmd7.ExecuteNonQuery();
                                }
                                else
                                {
                                    SqlCommand cmd6 = new SqlCommand("insert into User_Soft(Id_Soft,Id_User) Select Id_Soft, Id_User from Users,Software where Users.Name = '" + names[Z] + "' AND Software.Type='" + soft_d_l[N] + "' AND Software.[Key]='" + soft_d_l[N + 2] + "' AND Software.Version='" + soft_d_l[N + 1] + "'; ", Connection_Class.cn);
                                    cmd6.ExecuteNonQuery();
                                    SqlCommand cmd7 = new SqlCommand("insert into Soft_Laptop(Id_Soft,Id_Laptop) Select Id_Soft, Id_Laptop from Laptops,Software where Laptops.Id_User IN(select Id_User from Users where Users.Name = '" + names[Z] + "' ) AND Software.Type='" + soft_d_l[N] + "'  AND Software.[Key]='" + soft_d_l[N + 2] + "' AND Software.Version='" + soft_d_l[N + 1] + "'; ", Connection_Class.cn);
                                    cmd7.ExecuteNonQuery();
                                }

                            }

                        }
                    }


                }


                //////////////////////////////////// 

                else
                {
                    if (sn[Z] != null && sn[Z] != "")

                    {
                        SqlCommand cmd1 = new SqlCommand("insert into Users Values('" + names[Z] + "','" + titles[Z] + "','" + locations[Z] + "')", Connection_Class.cn);
                        cmd1.ExecuteNonQuery();
                        SqlCommand cmd5 = new SqlCommand("insert into Desktop (Desktop.Serial_Number_Desk,Desktop.Brand_Desktop,Desktop.Model_Desktop,Desktop.Processor_Desktop,Desktop.Hard_Desktop,Desktop.Ram_Desktop,Desktop.note_Desktop,Desktop.Id_User) Select '" + sn[Z] + "','" + brand[Z] + "','" + model[Z] + "','" + processor[Z] + "','" + hard[Z] + "','" + ram[Z] + "','" + note_l_d[Z] + "',Id_User from Users where Users.Name='" + names[Z] + "' ;", Connection_Class.cn);
                        cmd5.ExecuteNonQuery();
                        if (sn_m[Z] != null && sn_m[Z] != "")
                        {

                            SqlCommand cmd3 = new SqlCommand("insert into Monitor (Monitor.Serial_Number_Monitor,Monitor.Brand_Monitor,Monitor.Model_Monitor,Monitor.note_Monitor,Monitor.Id_User) Select '" + sn_m[Z] + "','" + brand_m[Z] + "','" + model_m[Z] + "','" + note_l_d[Z] + "',Id_User from Users where Users.Name='" + names[Z] + "' ;", Connection_Class.cn);
                            cmd3.ExecuteNonQuery();
                        }

                        for (int m = Z * 35; m < (Z * 35) + 6; m += 3)
                        {


                            if (m == Z * 35)
                            {
                                if (!soft_table.Contains(soft_d_l[m + 2]))
                                {
                                    
                                    Console.WriteLine("HI wINDOWS");
                                    SqlCommand cmd9 = new SqlCommand("insert into Software Values('" + "" + "','" + "" + "','" + soft_d_l[m + 2] + "','" + soft_d_l[m] + "','" + soft_d_l[m + 1] + "')", Connection_Class.cn);
                                    cmd9.ExecuteNonQuery();
                                    SqlCommand cmd6 = new SqlCommand("insert into User_Soft(Id_Soft,Id_User) Select Id_Soft, Id_User from Users,Software where Users.Name = '" + names[Z] + "' AND Software.Type='" + soft_d_l[m] + "' AND Software.[Key]='" + soft_d_l[m + 2] + "' AND Software.Version='" + soft_d_l[m + 1] + "'; ", Connection_Class.cn);
                                    cmd6.ExecuteNonQuery();
                                    SqlCommand cmd7 = new SqlCommand("insert into Soft_Desk(Id_Soft,Id_Desktop) Select Id_Soft, Id_Desktop from Desktop,Software where Desktop.Id_User IN(select Id_User from Users where Users.Name = '" + names[Z] + "' ) AND Software.Type='" + soft_d_l[m] + "'  AND Software.[Key]='" + soft_d_l[m + 2] + "' AND Software.Version='" + soft_d_l[m + 1] + "'; ", Connection_Class.cn);
                                    cmd7.ExecuteNonQuery();
                                }
                                else
                                {
                                    SqlCommand cmd6 = new SqlCommand("insert into User_Soft(Id_Soft,Id_User) Select Id_Soft, Id_User from Users,Software where Users.Name = '" + names[Z] + "' AND Software.Type='" + soft_d_l[m] + "' AND Software.[Key]='" + soft_d_l[m + 2] + "' AND Software.Version='" + soft_d_l[m + 1] + "'; ", Connection_Class.cn);
                                    cmd6.ExecuteNonQuery();
                                    SqlCommand cmd7 = new SqlCommand("insert into Soft_Desk(Id_Soft,Id_Desktop) Select Id_Soft, Id_Desktop from Desktop,Software where Desktop.Id_User IN(select Id_User from Users where Users.Name = '" + names[Z] + "' ) AND Software.Type='" + soft_d_l[m] + "'  AND Software.[Key]='" + soft_d_l[m + 2] + "' AND Software.Version='" + soft_d_l[m + 1] + "'; ", Connection_Class.cn);
                                    cmd7.ExecuteNonQuery();
                                }
                            }

                            else
                            {
                                if (!soft_table.Contains(soft_d_l[m + 2]))
                                {
                                    SqlCommand cmd9 = new SqlCommand("insert into Software Values('" + "" + "','" + "" + "','" + "" + "','" + soft_d_l[m] + "','" + soft_d_l[m + 1] + "')", Connection_Class.cn);
                                    cmd9.ExecuteNonQuery();
                                    SqlCommand cmd6 = new SqlCommand("insert into User_Soft(Id_Soft,Id_User) Select Id_Soft, Id_User from Users,Software where Users.Name = '" + names[Z] + "' AND Software.Type='" + soft_d_l[m] + "'  AND Software.Version='" + soft_d_l[m + 1] + "'; ", Connection_Class.cn);
                                    cmd6.ExecuteNonQuery();
                                    SqlCommand cmd7 = new SqlCommand("insert into Soft_Desk(Id_Soft,Id_Desktop) Select Id_Soft, Id_Desktop from Desktop,Software where Desktop.Id_User IN(select Id_User from Users where Users.Name = '" + names[Z] + "' ) AND Software.Type='" + soft_d_l[m] + "'  AND Software.Version='" + soft_d_l[m + 1] + "'; ", Connection_Class.cn);
                                    cmd7.ExecuteNonQuery();
                                }
                                else
                                {
                                    SqlCommand cmd6 = new SqlCommand("insert into User_Soft(Id_Soft,Id_User) Select Id_Soft, Id_User from Users,Software where Users.Name = '" + names[Z] + "' AND Software.Type='" + soft_d_l[m] + "' AND Software.[Key]='" + soft_d_l[m + 2] + "' AND Software.Version='" + soft_d_l[m + 1] + "'; ", Connection_Class.cn);
                                    cmd6.ExecuteNonQuery();
                                    SqlCommand cmd7 = new SqlCommand("insert into Soft_Desk(Id_Soft,Id_Desktop) Select Id_Soft, Id_Desktop from Desktop,Software where Desktop.Id_User IN(select Id_User from Users where Users.Name = '" + names[Z] + "' ) AND Software.Type='" + soft_d_l[m] + "'  AND Software.Version='" + soft_d_l[m + 1] + "'; ", Connection_Class.cn);
                                    cmd7.ExecuteNonQuery();
                                }
                            }
                        }
                        //Antivirus and windows case to add two empty values in software table
                        for (int N = (Z * 35) + 5; N < (Z * 35) + 35; N += 5)
                        {

                            if (soft_d_l[N] != "")
                            {
                                if (!soft_table.Contains(soft_d_l[N + 2]))
                                {
                                    SqlCommand cmd54 = new SqlCommand("insert into Software Values('" + soft_d_l[N + 3] + "','" + soft_d_l[N + 4] + "','" + soft_d_l[N + 2] + "','" + soft_d_l[N] + "','" + soft_d_l[N + 1] + "')", Connection_Class.cn);
                                    cmd54.ExecuteNonQuery();
                                    SqlCommand cmd6 = new SqlCommand("insert into User_Soft(Id_Soft,Id_User) Select Id_Soft, Id_User from Users,Software where Users.Name = '" + names[Z] + "' AND Software.Type='" + soft_d_l[N] + "' AND Software.Email='" + soft_d_l[N + 3] + "' AND Software.[Key]='" + soft_d_l[N + 2] + "' AND Software.Password='" + soft_d_l[N + 4] + "'AND Software.Version='" + soft_d_l[N + 1] + "'; ", Connection_Class.cn);
                                    cmd6.ExecuteNonQuery();
                                    SqlCommand cmd7 = new SqlCommand("insert into Soft_Desk(Id_Soft,Id_Desktop) Select Id_Soft, Id_Desktop from Desktop,Software where Desktop.Id_User IN(select Id_User from Users where Users.Name = '" + names[Z] + "' ) AND Software.Type='" + soft_d_l[N] + "' AND Software.Email='" + soft_d_l[N + 3] + "' AND Software.[Key]='" + soft_d_l[N + 2] + "' AND Software.Password='" + soft_d_l[N + 4] + "'AND Software.Version='" + soft_d_l[N + 1] + "'; ", Connection_Class.cn);
                                    cmd7.ExecuteNonQuery();
                                }
                                else
                                {
                                    SqlCommand cmd6 = new SqlCommand("insert into User_Soft(Id_Soft,Id_User) Select Id_Soft, Id_User from Users,Software where Users.Name = '" + names[Z] + "' AND Software.Type='" + soft_d_l[N] + "' AND Software.[Key]='" + soft_d_l[N + 2] + "' AND Software.Version='" + soft_d_l[N + 1] + "'; ", Connection_Class.cn);
                                    cmd6.ExecuteNonQuery();
                                    SqlCommand cmd7 = new SqlCommand("insert into Soft_Desk(Id_Soft,Id_Desktop) Select Id_Soft, Id_Desktop from Desktop,Software where Desktop.Id_User IN(select Id_User from Users where Users.Name = '" + names[Z] + "' ) AND Software.Type='" + soft_d_l[N] + "' AND Software.Email='" + soft_d_l[N + 3] + "' AND Software.[Key]='" + soft_d_l[N + 2] + "' AND Software.Password='" + soft_d_l[N + 4] + "'AND Software.Version='" + soft_d_l[N + 1] + "'; ", Connection_Class.cn);
                                    cmd7.ExecuteNonQuery();
                                }

                            }

                        }
                    }


               
            }

            }



            MessageBox.Show("Data imported successfully");
                Connection_Class.Close();
            }
        ////////////////////////////////////////////////////////////////////////////////////////////
        ///// Autosize
        private void import_form_Resize(object sender, EventArgs e)
        {
            resizeChildControls();
        }
        private void resizeChildControls()
        {
            resizeControl(pictureBox1OriginalRect, pictureBox2);
            resizeControl(pictureBox2OriginalRect, pictureBox1);
            resizeControl(datagridviewOriginalRect, data_grid);
            resizeControl(label1OriginalRect, label1);
            resizeControl(label2OriginalRect, label2);
            resizeControl(textBox1OriginalRect, fname);
            resizeControl(comboBoxOriginalRect, comboBox1);
            resizeControl(button1OriginalRect, browse);
            resizeControl(button2OriginalRect, imp);
            resizeControl(button3OriginalRect, Back);

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

        private void import_form_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size; //Point(this.Size.Width,this.Size.Height);
            pictureBox1OriginalRect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            pictureBox2OriginalRect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            datagridviewOriginalRect = new Rectangle(data_grid.Location.X, data_grid.Location.Y, data_grid.Width, data_grid.Height);
            label1OriginalRect = new Rectangle(label1.Location.X, label1.Location.Y, label1.Width, label1.Height);
            label2OriginalRect = new Rectangle(label2.Location.X, label2.Location.Y, label2.Width, label2.Height);
            textBox1OriginalRect = new Rectangle(fname.Location.X, fname.Location.Y, fname.Width, fname.Height);
            comboBoxOriginalRect = new Rectangle(comboBox1.Location.X, comboBox1.Location.Y, comboBox1.Width, comboBox1.Height);
            button1OriginalRect = new Rectangle(browse.Location.X, browse.Location.Y, browse.Width, browse.Height);
            button2OriginalRect = new Rectangle(imp.Location.X, imp.Location.Y, imp.Width, imp.Height);
            button3OriginalRect = new Rectangle(Back.Location.X, Back.Location.Y, Back.Width, Back.Height);
            
           
           
        }
    }
    }
                        
        
                    
             

       

                    
            
        

    
            
        
    



