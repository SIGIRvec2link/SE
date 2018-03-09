using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Task1
{
    class Program
    {
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        private static string keyUse = "12345678";
        private static string keyDe = "12345678";
        
        static void Main(string[] args)
        {
            string connString = "Data Source=(local);Initial Catalog=Location;Integrated Security=true";
            SqlConnection connection = new SqlConnection(connString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "create table table1 (Province nvarchar(50),City nvarchar(50),Longitude nvarchar(50),Latitude nvarchar(50),GDP nvarchar(50),BucketLabel nvarchar(50))";
                try
                {
                    int n = command.ExecuteNonQuery();
                    Console.WriteLine("建表1成功！");
                    command.CommandText = "create table table4 (Province nvarchar(50),City nvarchar(50),Longitude nvarchar(50),Latitude nvarchar(50),GDP nvarchar(50))";
                    n = command.ExecuteNonQuery();
                    Console.WriteLine("建表4成功！");
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new AddData());
                }
                finally
                {
                    command.Dispose();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("出现异常:" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
