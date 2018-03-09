using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Task2
{
    class GetData
    {
        static public SqlConnection conn;

        //首先获取多维数据的数量
        static public int connectSQL()
        {
            int tuplesCount = 0;//元组数目
            string connStr = "Data Source=(local);Initial Catalog=Location;Integrated Security=True";
            conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                try
                {
                    //command.CommandText = "select top 34 Province,City,Longitude,Latitude,GDP from table2";
                    command.CommandText = "select Longitude from table2";
                    //SqlDataReader reader = command.ExecuteReader();

                    //使用SqlDataAdapter将从数据库中读取的数据填入DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    DataTable dt1 = new DataTable("Longitude");
                    //dt.Columns["Longitude"].DataType = Type.GetType("System.double");
                    adapter.Fill(dt1);
                    //获取元组数目
                    tuplesCount = dt1.Rows.Count;
                }
                finally
                {
                    command.Dispose();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();

            }
            return tuplesCount;
        }

        //获取元组并存入两个数组
        static public int GetArray(ref string[] provinceArr, ref string[] cityArr, ref double[] longitudeArr, ref double[] latitudeArr, ref double[] gdpArr)
        {
            string connStr = "Data Source=(local);Initial Catalog=Location;Integrated Security=True";
            SqlConnection conn = GetData.conn;
            conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                try
                {
                    //command.CommandText = "select top 34 Province,City,Longitude,Latitude,GDP from table2";
                    command.CommandText = "select Province from table2";
                    //SqlDataReader reader = command.ExecuteReader();

                    //使用SqlDataAdapter将从数据库中读取的数据填入DataTable
                    //其实写一个有两列的DataTable也可以，就不必创建两个DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    DataTable dt0 = new DataTable("Province");
                    //dt.Columns["Longitude"].DataType = Type.GetType("System.double");
                    adapter.Fill(dt0);

                    command.CommandText = "select City from table2";
                    adapter.SelectCommand = command;
                    DataTable dt1 = new DataTable("City");
                    adapter.Fill(dt1);

                    command.CommandText = "select Longitude from table2";
                    adapter.SelectCommand = command;
                    DataTable dt2 = new DataTable("Longitude");
                    adapter.Fill(dt2);

                    command.CommandText = "select Latitude from table2";
                    adapter.SelectCommand = command;
                    DataTable dt3 = new DataTable("Latitude");
                    adapter.Fill(dt3);


                    command.CommandText = "select GDP from table2";
                    adapter.SelectCommand = command;
                    DataTable dt4 = new DataTable("GDP");
                    adapter.Fill(dt4);
                    //将DataTable单元格中的数据一一读出，因为是弱类型object，所以还需强制转换为double类型

                    //double i = double.Parse(dt.Rows[0][0].ToString());
                    for (int i = 0; i < dt0.Rows.Count; i++)
                    {
                        provinceArr[i] = dt0.Rows[i][0].ToString();
                        cityArr[i] = dt1.Rows[i][0].ToString();
                        longitudeArr[i] = double.Parse(dt2.Rows[i][0].ToString());
                        latitudeArr[i] = double.Parse(dt3.Rows[i][0].ToString());
                        gdpArr[i] = double.Parse(dt4.Rows[i][0].ToString());
                        //Console.WriteLine(latitudeArr[i]);
                    }
                }
                finally
                {
                    command.Dispose();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }

        static public void creatTable()
        {
            string connString = "Data Source=(local);Initial Catalog=Location;Integrated Security=true";
            SqlConnection connection = new SqlConnection(connString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "create table table5 (Province nvarchar(50),City nvarchar(50),Longitude nvarchar(50),Latitude nvarchar(50),GDP nvarchar(50),BucketLabel nvarchar(50))";
                try
                {
                    int n = command.ExecuteNonQuery();
                    Console.WriteLine("建表5成功！");
                    command.CommandText = "create table table6 (Province nvarchar(50),City nvarchar(50),Longitude nvarchar(50),Latitude nvarchar(50),GDP nvarchar(50))";
                    n = command.ExecuteNonQuery();
                    Console.WriteLine("建表6成功！");
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
