using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Task1
{
    /*
     * 向数据库中插入加密的数据
     */
    class InsertData
    {
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        private static string keyUse = "12345678";
        private static string keyDe = "12345678";

        static public void insertData(string strOrg0, string strOrg1, string strOrg2, string strOrg3, string strOrg4)
        {
            string connString = "Data Source=(local);Initial Catalog=Location;Integrated Security=true";
            SqlConnection connection = new SqlConnection(connString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                try
                {
                    string tmp = System.Text.Encoding.Default.GetString(Keys);
                    string strEP0 = DESAlgorithm.EncryptDES(strOrg0, keyUse);
                    string strEP1 = DESAlgorithm.EncryptDES(strOrg1, keyUse);
                    string strEP2 = DESAlgorithm.EncryptDES(strOrg2, keyUse);
                    string strEP3 = DESAlgorithm.EncryptDES(strOrg3, keyUse);
                    string strEP4 = DESAlgorithm.EncryptDES(strOrg4, keyUse);
                    string strOrg5 = MarchLabel.getLabel(strOrg2, strOrg3);
                    //加入密文数据（含桶标签）
                    command.CommandText = "insert into table1 (Province,City,Longitude,Latitude,GDP,BucketLabel)"
                        + "values ('" + strEP0 + "','" + strEP1 + "','" + strEP2 + "','" + strEP3 + "','" + strEP4 + "','" + strOrg5 + "')";
                    int n = command.ExecuteNonQuery();
                    Console.WriteLine("成功插入数据{0}行", n);
                    //加入明文数据（比密文数据表少桶标签一列）
                    command.CommandText = "insert into table4 (Province,City,Longitude,Latitude,GDP)"
                        + "values ('" + strOrg0 + "','" + strOrg1 + "','" + strOrg2 + "','" + strOrg3 + "','" + strOrg4 + "')";
                    n = command.ExecuteNonQuery();
                    Console.WriteLine("成功插入数据{0}行", n);
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
