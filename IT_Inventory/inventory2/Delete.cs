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
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void Delete_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection_Class.DB_cn();
            Connection_Class.open();
            SqlCommand User = new SqlCommand("Select Id_User from dbo.Users where dbo.Users.Name = '" + Edit_Form.userName + "'", Connection_Class.cn);//Command Query                   
            object user_name = User.ExecuteScalar();
            if (user_name == null) //this user not found in database
            {
                this.Hide();
                MessageBox.Show("This name doesn't exist"); //show massage to not found user
            }
            else
            {
                int Id_User = Conditions_Class.Get_Id(User);//Get_Id_user
                if (Conditions_Class.Laptop_Found(Connection_Class.cn, Id_User) != null)//if user own laptop
                {
                    //get Id_Laptop
                    SqlCommand Laptop = new SqlCommand("Select Id_Laptop from dbo.Laptops where dbo.Laptops.Id_User = '" + Id_User + "'", Connection_Class.cn);//Command Query                   
                    int Id_Lap = Conditions_Class.Get_Id(Laptop);//Get_Id_Laptop
                    List<int> Ids_Soft = new List<int>();//define list to get ids software
                                                         //select ids to software that user own this LAptop
                    SqlCommand Soft = new SqlCommand("Select Id_Soft from dbo.Soft_Laptop where dbo.Soft_Laptop.Id_Laptop = '" + Id_Lap + "'", Connection_Class.cn);//Command Query                   
                    SqlDataReader sdr3 = Soft.ExecuteReader();
                    //fill lists of ids and types 
                    while (sdr3.Read())
                    {
                        Ids_Soft.Add(sdr3.GetInt32((sdr3.GetOrdinal("Id_Soft"))));

                    }
                    //insert softwares that user own it in spare 
                    //delete this softwares from tables (User_Soft,Laptop_soft,Software)
                    for (int i = 0; i < Ids_Soft.Count; i++)
                    {
                        SqlCommand spare_Soft = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Email,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note) Select dbo.Software.type,dbo.Software.Email,dbo.Software.Password,dbo.Software.[Key],dbo.Software.Version,'old '+'" + Edit_Form.userName + "' from dbo.Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                        spare_Soft.ExecuteNonQuery();
                        SqlCommand Delete_Lap_Soft = new SqlCommand("DELETE FROM Soft_Laptop WHERE dbo.Soft_Laptop.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                        Delete_Lap_Soft.ExecuteNonQuery();
                        SqlCommand Delete_User_Soft = new SqlCommand("DELETE FROM User_Soft WHERE dbo.User_Soft.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                        Delete_User_Soft.ExecuteNonQuery();
                        SqlCommand Delete_Soft = new SqlCommand("DELETE FROM Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                        Delete_Soft.ExecuteNonQuery();
                    }
                    //Insert Laptop to spare
                    SqlCommand spare_Laptop = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Serial_Number,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Processor,dbo.Spare.Ram,dbo.Spare.Hard,dbo.Spare.Note) Select 'Laptop', dbo.Laptops.Serial_Number_Lap,dbo.Laptops.Brand_Lap,dbo.Laptops.Model_Lap,dbo.Laptops.Processor_Lap,dbo.Laptops.Ram_Lap,dbo.Laptops.Hard_Lap,dbo.Laptops.Note_Lap+' old '+'" + Edit_Form.userName + "' from dbo.Laptops WHERE dbo.Laptops.Id_Laptop = '" + Id_Lap + "'", Connection_Class.cn);
                    spare_Laptop.ExecuteNonQuery();
                    //Delete Laptop From Laptops Table
                    SqlCommand Delete_Laptop = new SqlCommand("DELETE FROM Laptops WHERE dbo.Laptops.Id_Laptop = '" + Id_Lap + "'", Connection_Class.cn);
                    Delete_Laptop.ExecuteNonQuery();
                    if (Conditions_Class.Monitor_Found(Connection_Class.cn, Id_User) != null)
                    {
                        //Insert Monitor to spare
                        SqlCommand spare_Monitor = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Serial_Number,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Note) Select 'Monitor', dbo.Monitor.Serial_Number_Monitor,dbo.Monitor.Brand_Monitor,dbo.Monitor.Model_Monitor,dbo.Monitor.Note_Monitor +' old '+'" + Edit_Form.userName + "' from dbo.Monitor WHERE dbo.Monitor.Id_User = '" + Id_User + "'", Connection_Class.cn);
                        spare_Monitor.ExecuteNonQuery();
                        //Delete Monitor From Laptops Table
                        SqlCommand Delete_Monitor = new SqlCommand("DELETE FROM Monitor WHERE dbo.Monitor.Id_User = '" + Id_User + "'", Connection_Class.cn);
                        Delete_Monitor.ExecuteNonQuery();
                    }
                    //Delete Monitor From Laptops Table
                    SqlCommand Delete_User = new SqlCommand("DELETE FROM Users WHERE dbo.Users.Id_User = '" + Id_User + "'", Connection_Class.cn);
                    Delete_User.ExecuteNonQuery();
                    MessageBox.Show("Data Updated Successfully");
                    Connection_Class.Close();
                    this.Hide();
                    Edit_Form edit = new Edit_Form();
                    edit.Show();

                }
                else if (Conditions_Class.Desktop_Found(Connection_Class.cn, Id_User) != null)//check if User own Desktop
                {
                    //get Id_Desktop
                    SqlCommand Desktop = new SqlCommand("Select Id_Desktop from dbo.Desktop where dbo.Desktop.Id_User = '" + Id_User + "'", Connection_Class.cn);//Command Query                   
                    int Id_Desk = Conditions_Class.Get_Id(Desktop);//Get_Id_Desktop
                    List<int> Ids_Soft = new List<int>();//define list to get ids software
                                                         //select ids to software that user own this Desktop
                    SqlCommand Soft = new SqlCommand("Select Id_Soft from dbo.Soft_Desk where dbo.Soft_Desk.Id_Desktop = '" + Id_Desk + "'", Connection_Class.cn);//Command Query                   
                    SqlDataReader sdr3 = Soft.ExecuteReader();
                    //fill lists of ids and types 
                    while (sdr3.Read())
                    {
                        Ids_Soft.Add(sdr3.GetInt32((sdr3.GetOrdinal("Id_Soft"))));

                    }

                    //insert softwares that user own it in spare 
                    //delete this softwares from tables (User_Soft,Desk_soft,Software)
                    for (int i = 0; i < Ids_Soft.Count; i++)
                    {
                        SqlCommand spare_Soft = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Email,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note) Select dbo.Software.type,dbo.Software.Email,dbo.Software.Password,dbo.Software.[Key],dbo.Software.Version,'old '+'" + Edit_Form.userName + "' from dbo.Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                        spare_Soft.ExecuteNonQuery();
                        SqlCommand Delete_Desk_Soft = new SqlCommand("DELETE FROM Soft_Desk WHERE dbo.Soft_Desk.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                        Delete_Desk_Soft.ExecuteNonQuery();
                        SqlCommand Delete_User_Soft = new SqlCommand("DELETE FROM User_Soft WHERE dbo.User_Soft.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                        Delete_User_Soft.ExecuteNonQuery();
                        SqlCommand Delete_Soft = new SqlCommand("DELETE FROM Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                        Delete_Soft.ExecuteNonQuery();
                    }
                    //Insert Laptop to spare
                    SqlCommand spare_Desktop = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Serial_Number,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Processor,dbo.Spare.Ram,dbo.Spare.Hard,dbo.Spare.Note) Select 'Desktop', dbo.Desktop.Serial_Number_Desk,dbo.Desktop.Brand_Desktop,dbo.Desktop.Model_Desktop,dbo.Desktop.Processor_Desktop,dbo.Desktop.Ram_Desktop,dbo.Desktop.Hard_Desktop,dbo.Desktop.Note_Desktop+' old '+'" + Edit_Form.userName + "' from dbo.Desktop WHERE dbo.Desktop.Id_Desktop = '" + Id_Desk + "'", Connection_Class.cn);
                    spare_Desktop.ExecuteNonQuery();
                    //Delete Laptop From Laptops Table
                    SqlCommand Delete_Desktop = new SqlCommand("DELETE FROM Desktop WHERE dbo.Desktop.Id_Desktop = '" + Id_Desk + "'", Connection_Class.cn);
                    Delete_Desktop.ExecuteNonQuery();
                    if (Conditions_Class.Monitor_Found(Connection_Class.cn, Id_User) != null)
                    {
                        //Insert Monitor to spare
                        SqlCommand spare_Monitor = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Serial_Number,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Note) Select 'Monitor', dbo.Monitor.Serial_Number_Monitor,dbo.Monitor.Brand_Monitor,dbo.Monitor.Model_Monitor,dbo.Monitor.Note_Monitor +' old '+'" + Edit_Form.userName + "'  from dbo.Monitor WHERE dbo.Monitor.Id_User = '" + Id_User + "'", Connection_Class.cn);
                        spare_Monitor.ExecuteNonQuery();
                        //Delete Monitor From Laptops Table
                        SqlCommand Delete_Monitor = new SqlCommand("DELETE FROM Monitor WHERE dbo.Monitor.Id_User = '" + Id_User + "'", Connection_Class.cn);
                        Delete_Monitor.ExecuteNonQuery();
                    }
                    //Delete Monitor From Laptops Table
                    SqlCommand Delete_User = new SqlCommand("DELETE FROM Users WHERE dbo.Users.Id_User = '" + Id_User + "'", Connection_Class.cn);
                    Delete_User.ExecuteNonQuery();
                    MessageBox.Show("Data Updated Successfully");
                    Connection_Class.Close();
                    this.Hide();
                    Edit_Form edit = new Edit_Form();
                    edit.Show();

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection_Class.DB_cn();
            Connection_Class.open();
            SqlCommand User = new SqlCommand("Select Id_User from dbo.Users where dbo.Users.Name = '" + Edit_Form.userName + "'", Connection_Class.cn);//Command Query                   
            object user_name = User.ExecuteScalar();
            if (user_name == null) //this user not found in database
            {
                this.Hide();
                MessageBox.Show("This name doesn't exist"); //show massage to not found user
            }
            else
            {
                int Id_User = Conditions_Class.Get_Id(User);//Get_Id_user
                if (Conditions_Class.Laptop_Found(Connection_Class.cn, Id_User) != null)//if user own laptop
                {
                    //get Id_Laptop
                    SqlCommand Laptop = new SqlCommand("Select Id_Laptop from dbo.Laptops where dbo.Laptops.Id_User = '" + Id_User + "'", Connection_Class.cn);//Command Query                   
                    int Id_Lap = Conditions_Class.Get_Id(Laptop);//Get_Id_Laptop
                    List<int> Ids_Soft = new List<int>();//define list to get ids software
                                                         //select ids to software that user own this LAptop
                    SqlCommand Soft = new SqlCommand("Select Id_Soft from dbo.Soft_Laptop where dbo.Soft_Laptop.Id_Laptop = '" + Id_Lap + "'", Connection_Class.cn);//Command Query                   
                    SqlDataReader sdr3 = Soft.ExecuteReader();
                    //fill lists of ids and types 
                    while (sdr3.Read())
                    {
                        Ids_Soft.Add(sdr3.GetInt32((sdr3.GetOrdinal("Id_Soft"))));

                    }
                    //insert softwares that user own it in spare 
                    //delete this softwares from tables (User_Soft,Laptop_soft,Software)
                    for (int i = 0; i < Ids_Soft.Count; i++)
                    {
                        SqlCommand spare_Soft = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Email,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note) Select dbo.Software.type,dbo.Software.Email,dbo.Software.Password,dbo.Software.[Key],dbo.Software.Version,'old '+'" + Edit_Form.userName + "'+' Transfered ' from dbo.Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                        spare_Soft.ExecuteNonQuery();
                        SqlCommand Delete_Lap_Soft = new SqlCommand("DELETE FROM Soft_Laptop WHERE dbo.Soft_Laptop.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                        Delete_Lap_Soft.ExecuteNonQuery();
                        SqlCommand Delete_User_Soft = new SqlCommand("DELETE FROM User_Soft WHERE dbo.User_Soft.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                        Delete_User_Soft.ExecuteNonQuery();
                        SqlCommand Delete_Soft = new SqlCommand("DELETE FROM Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                        Delete_Soft.ExecuteNonQuery();
                    }
                    //Insert Laptop to spare
                    SqlCommand spare_Laptop = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Serial_Number,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Processor,dbo.Spare.Ram,dbo.Spare.Hard,dbo.Spare.Note) Select 'Laptop', dbo.Laptops.Serial_Number_Lap,dbo.Laptops.Brand_Lap,dbo.Laptops.Model_Lap,dbo.Laptops.Processor_Lap,dbo.Laptops.Ram_Lap,dbo.Laptops.Hard_Lap,dbo.Laptops.Note_Lap+' old '+'" + Edit_Form.userName + "'+' Transfered '  from dbo.Laptops WHERE dbo.Laptops.Id_Laptop = '" + Id_Lap + "'", Connection_Class.cn);
                    spare_Laptop.ExecuteNonQuery();
                    //Delete Laptop From Laptops Table
                    SqlCommand Delete_Laptop = new SqlCommand("DELETE FROM Laptops WHERE dbo.Laptops.Id_Laptop = '" + Id_Lap + "'", Connection_Class.cn);
                    Delete_Laptop.ExecuteNonQuery();
                    if (Conditions_Class.Monitor_Found(Connection_Class.cn, Id_User) != null)
                    {
                        //Insert Monitor to spare
                        SqlCommand spare_Monitor = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Serial_Number,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Note) Select 'Monitor', dbo.Monitor.Serial_Number_Monitor,dbo.Monitor.Brand_Monitor,dbo.Monitor.Model_Monitor,dbo.Monitor.Note_Monitor +' old '+'" + Edit_Form.userName + "'+' Transfered ' from dbo.Monitor WHERE dbo.Monitor.Id_User = '" + Id_User + "'", Connection_Class.cn);
                        spare_Monitor.ExecuteNonQuery();
                        //Delete Monitor From Laptops Table
                        SqlCommand Delete_Monitor = new SqlCommand("DELETE FROM Monitor WHERE dbo.Monitor.Id_User = '" + Id_User + "'", Connection_Class.cn);
                        Delete_Monitor.ExecuteNonQuery();
                    }
                    //Delete Monitor From Laptops Table
                    SqlCommand Delete_User = new SqlCommand("DELETE FROM Users WHERE dbo.Users.Id_User = '" + Id_User + "'", Connection_Class.cn);
                    Delete_User.ExecuteNonQuery();
                    MessageBox.Show("Data Updated Successfully");
                    Connection_Class.Close();
                    this.Hide();
                    Edit_Form edit = new Edit_Form();
                    edit.Show();
                }
                else if (Conditions_Class.Desktop_Found(Connection_Class.cn, Id_User) != null)//check if User own Desktop
                {
                    //get Id_Desktop
                    SqlCommand Desktop = new SqlCommand("Select Id_Desktop from dbo.Desktop where dbo.Desktop.Id_User = '" + Id_User + "'", Connection_Class.cn);//Command Query                   
                    int Id_Desk = Conditions_Class.Get_Id(Desktop);//Get_Id_Desktop
                    List<int> Ids_Soft = new List<int>();//define list to get ids software
                                                         //select ids to software that user own this Desktop
                    SqlCommand Soft = new SqlCommand("Select Id_Soft from dbo.Soft_Desk where dbo.Soft_Desk.Id_Desktop = '" + Id_Desk + "'", Connection_Class.cn);//Command Query                   
                    SqlDataReader sdr3 = Soft.ExecuteReader();
                    //fill lists of ids and types 
                    while (sdr3.Read())
                    {
                        Ids_Soft.Add(sdr3.GetInt32((sdr3.GetOrdinal("Id_Soft"))));

                    }

                    //insert softwares that user own it in spare 
                    //delete this softwares from tables (User_Soft,Desk_soft,Software)
                    for (int i = 0; i < Ids_Soft.Count; i++)
                    {
                        SqlCommand spare_Soft = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Email,dbo.Spare.Password,dbo.Spare.[Key],dbo.Spare.Version,dbo.Spare.Note) Select dbo.Software.type,dbo.Software.Email,dbo.Software.Password,dbo.Software.[Key],dbo.Software.Version,'old '+'" + Edit_Form.userName + "'+' Transfered ' from dbo.Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                        spare_Soft.ExecuteNonQuery();
                        SqlCommand Delete_Desk_Soft = new SqlCommand("DELETE FROM Soft_Desk WHERE dbo.Soft_Desk.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                        Delete_Desk_Soft.ExecuteNonQuery();
                        SqlCommand Delete_User_Soft = new SqlCommand("DELETE FROM User_Soft WHERE dbo.User_Soft.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                        Delete_User_Soft.ExecuteNonQuery();
                        SqlCommand Delete_Soft = new SqlCommand("DELETE FROM Software WHERE dbo.Software.Id_Soft = '" + Ids_Soft[i] + "'", Connection_Class.cn);
                        Delete_Soft.ExecuteNonQuery();
                    }
                    //Insert Laptop to spare
                    SqlCommand spare_Desktop = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Serial_Number,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Processor,dbo.Spare.Ram,dbo.Spare.Hard,dbo.Spare.Note) Select 'Desktop', dbo.Desktop.Serial_Number_Desk,dbo.Desktop.Brand_Desktop,dbo.Desktop.Model_Desktop,dbo.Desktop.Processor_Desktop,dbo.Desktop.Ram_Desktop,dbo.Desktop.Hard_Desktop,dbo.Desktop.Note_Desktop+' old '+'" + Edit_Form.userName + "'+' Transfered ' from dbo.Desktop WHERE dbo.Desktop.Id_Desktop = '" + Id_Desk + "'", Connection_Class.cn);
                    spare_Desktop.ExecuteNonQuery();
                    //Delete Laptop From Laptops Table
                    SqlCommand Delete_Desktop = new SqlCommand("DELETE FROM Desktop WHERE dbo.Desktop.Id_Desktop = '" + Id_Desk + "'", Connection_Class.cn);
                    Delete_Desktop.ExecuteNonQuery();
                    if (Conditions_Class.Monitor_Found(Connection_Class.cn, Id_User) != null)
                    {
                        //Insert Monitor to spare
                        SqlCommand spare_Monitor = new SqlCommand("INSERT INTO dbo.Spare (dbo.Spare.Type,dbo.Spare.Serial_Number,dbo.Spare.Brand,dbo.Spare.Model,dbo.Spare.Note) Select 'Monitor', dbo.Monitor.Serial_Number_Monitor,dbo.Monitor.Brand_Monitor,dbo.Monitor.Model_Monitor,dbo.Monitor.Note_Monitor +' old '+'" + Edit_Form.userName + "'+' Transfered ' from dbo.Monitor WHERE dbo.Monitor.Id_User = '" + Id_User + "'", Connection_Class.cn);
                        spare_Monitor.ExecuteNonQuery();
                        //Delete Monitor From Laptops Table
                        SqlCommand Delete_Monitor = new SqlCommand("DELETE FROM Monitor WHERE dbo.Monitor.Id_User = '" + Id_User + "'", Connection_Class.cn);
                        Delete_Monitor.ExecuteNonQuery();
                    }
                    //Delete Monitor From Laptops Table
                    SqlCommand Delete_User = new SqlCommand("DELETE FROM Users WHERE dbo.Users.Id_User = '" + Id_User + "'", Connection_Class.cn);
                    Delete_User.ExecuteNonQuery();
                    MessageBox.Show("Data Updated Successfully");
                    Connection_Class.Close();
                    this.Hide();
                    Edit_Form edit = new Edit_Form();
                    edit.Show();
                }
            }
        }
    }
}
