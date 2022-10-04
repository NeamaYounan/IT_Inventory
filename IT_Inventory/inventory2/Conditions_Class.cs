using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace inventory2
{
    internal class Conditions_Class
    {
        
        public static int Get_Id(SqlCommand Command)
        {
            SqlDataReader sdr = Command.ExecuteReader();
            string[] numb = new string[sdr.FieldCount];
            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    numb[i] = sdr[i].ToString();
                }
            }
            int Id_User = Int32.Parse(numb[0]);
            return Id_User ;
        }

        public static string Get_Name(SqlCommand Command)
        {
            SqlDataReader sdr1 = Command.ExecuteReader();
            string[] name = new string[sdr1.FieldCount];
            while (sdr1.Read())
            {
                for (int i = 0; i < sdr1.FieldCount; i++)
                {
                    name[i] = sdr1[i].ToString();
                }
            }
            sdr1.Close();
            string user_Name = name[0];
            return user_Name;
        }
        public static Object Laptop_Found(SqlConnection connection , int Id_User)
        {
            SqlCommand laptop_Cmd = new SqlCommand("Select Serial_Number_Lap from dbo.Laptops where Id_User = '" + Id_User + "'  ", connection);
            Object Laptop = laptop_Cmd.ExecuteScalar();
            return Laptop;

        }
        public static Object Desktop_Found(SqlConnection connection, int Id_User)
        {
            SqlCommand desktop_Cmd = new SqlCommand("Select Serial_Number_Desk from Desktop where Id_User = '" + Id_User + "' ", connection);
            Object desktop = desktop_Cmd.ExecuteScalar();
            return desktop;

        }
        public static Object Monitor_Found(SqlConnection connection, int Id_User)
        {
            SqlCommand monitor_Cmd = new SqlCommand("Select Serial_Number_Monitor from Monitor where Id_User = '" + Id_User + "' ", connection);
            Object monitor = monitor_Cmd.ExecuteScalar();
            return monitor;

        }
        public static DataTable Retrive_LaptopOnly(SqlConnection connection ,int Id_User)
        {
            SqlCommand Data = new SqlCommand("Select  Serial_Number_Lap,Brand_Lap,Model_Lap,Processor_Lap,Ram_Lap,Hard_Lap,Note_Lap,Name,Title,Location,Email,Password,[Key],type,Version from  dbo.Laptops  , dbo.Users ,dbo.Software  where  dbo.Laptops.Id_User = '" + Id_User + "' AND dbo.Users.Id_User='" + Id_User + "' AND dbo.Software.Id_Soft IN (Select Id_Soft from dbo.User_Soft where Id_User = '" + Id_User + "')  ", connection);
            SqlDataAdapter da = new SqlDataAdapter(Data);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public static DataTable Retrive_Laptop_Monitor(SqlConnection connection, int Id_User)
        {
            SqlCommand Data = new SqlCommand("Select Serial_Number_Lap,Brand_Lap,Model_Lap,Processor_Lap,Ram_Lap,Hard_Lap,Note_Lap,Name,Title,Location,Email,Password,[Key],type,Version ,Serial_Number_Monitor,Brand_Monitor,Model_Monitor,Note_Monitor from  dbo.Laptops, dbo.Users, dbo.Monitor, dbo.Software where  dbo.Laptops.Id_User = '" + Id_User + "' AND dbo.Monitor.Id_User ='" + Id_User + "'   AND dbo.Users.Id_User='" + Id_User + "' AND dbo.Software.Id_Soft IN (Select Id_Soft from dbo.User_Soft where Id_User = '" + Id_User + "')", connection);
            SqlDataAdapter da = new SqlDataAdapter(Data);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable Retrive_Laptop_Desktop(SqlConnection connection, int Id_User)
        {
            SqlCommand Data = new SqlCommand("Select Serial_Number_Desk, Brand_Desktop, Model_Desktop, Processor_Desktop, Ram_Desktop, Hard_Desktop, Note_Desktop, Serial_Number_Monitor,Brand_Monitor,Model_Monitor,Note_Monitor , Serial_Number_Lap,Brand_Lap,Model_Lap,Processor_Lap,Ram_Lap,Hard_Lap,Note_Lap,Name,Title,Location,Email,Password,[Key],type,Version from dbo.Desktop, dbo.Laptops , dbo.Monitor  , dbo.Users ,dbo.Software where   dbo.Desktop.Id_User = '" + Id_User + "' AND dbo.Laptops.Id_User = '" + Id_User + "' AND dbo.Monitor.Id_User ='" + Id_User + "'   AND dbo.Users.Id_User='" + Id_User + "' AND dbo.Software.Id_Soft IN (Select Id_Soft from dbo.User_Soft where Id_User = '" + Id_User + "')", connection);
            SqlDataAdapter da = new SqlDataAdapter(Data);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable Retrive_DesktopOnly(SqlConnection connection, int Id_User)
        {
            SqlCommand Data = new SqlCommand("Select Serial_Number_Desk, Brand_Desktop, Model_Desktop, Processor_Desktop, Ram_Desktop, Hard_Desktop, Note_Desktop, Serial_Number_Monitor,Brand_Monitor,Model_Monitor,Note_Monitor ,Name,Title,Location,Email,Password,[Key],type,Version from dbo.Desktop,   dbo.Monitor  , dbo.Users ,dbo.Software where   dbo.Desktop.Id_User = '" + Id_User + "'  AND dbo.Monitor.Id_User ='" + Id_User + "'   AND dbo.Users.Id_User='" + Id_User + "' AND dbo.Software.Id_Soft IN (Select Id_Soft from dbo.User_Soft where Id_User = '" + Id_User + "')", connection);
            SqlDataAdapter da = new SqlDataAdapter(Data);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        
        
        
    }

}

    
