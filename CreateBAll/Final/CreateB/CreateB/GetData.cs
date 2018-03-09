using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CreateB
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
        static public int GetArray(ref double[] longitudeArr, ref double[] latitudeArr)
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
                    command.CommandText = "select Longitude from table2";
                    //SqlDataReader reader = command.ExecuteReader();

                    //使用SqlDataAdapter将从数据库中读取的数据填入DataTable
                    //其实写一个有两列的DataTable也可以，就不必创建两个DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    DataTable dt1 = new DataTable("Longitude");
                    //dt.Columns["Longitude"].DataType = Type.GetType("System.double");
                    adapter.Fill(dt1);

                    command.CommandText = "select Latitude from table2";
                    adapter.SelectCommand = command;
                    DataTable dt2 = new DataTable("Latitude");
                    adapter.Fill(dt2);


                    //将DataTable单元格中的数据一一读出，因为是弱类型object，所以还需强制转换为double类型

                    //double i = double.Parse(dt.Rows[0][0].ToString());
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        longitudeArr[i] = double.Parse(dt1.Rows[i][0].ToString());
                        latitudeArr[i] = double.Parse(dt2.Rows[i][0].ToString());
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


    }
}
