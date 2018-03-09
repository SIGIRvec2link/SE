using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Task2
{
    class InsertData
    {
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        private static string keyUse = "12345678";
        private static string keyDe = "12345678";

        static public void insertData(string[] provinceArr, string[] cityArr, double[] longitudeArr, double[] latitudeArr, double[] gdpArr)
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
                    int tuplesCount = GetData.connectSQL();
                    string[] strEP0 = new string[tuplesCount];
                    string[] strEP1 = new string[tuplesCount];
                    string[] strEP2 = new string[tuplesCount];
                    string[] strEP3 = new string[tuplesCount];
                    string[] strEP4 = new string[tuplesCount];
                    string[] strOrg0 = new string[tuplesCount];
                    string[] strOrg1 = new string[tuplesCount];
                    string[] strOrg2 = new string[tuplesCount];
                    string[] strOrg3 = new string[tuplesCount];
                    string[] strOrg4 = new string[tuplesCount];
                    ArrayList listOrg5 = new ArrayList();
                    double[] longitude = new double[tuplesCount];
                    double[] latitude = new double[tuplesCount];
                    double longitudeTemp = 0;
                    double latitudeTemp = 0;
                    for (int i = 0; i < tuplesCount; i++)
                    {
                        strOrg0[i] = provinceArr[i];
                        strOrg1[i] = cityArr[i];
                        strOrg2[i] = longitudeArr[i].ToString();
                        strOrg3[i] = latitudeArr[i].ToString();
                        strOrg4[i] = gdpArr[i].ToString();

                        strEP0[i] = DESAlgorithm.EncryptDES(strOrg0[i], keyUse);
                        strEP1[i] = DESAlgorithm.EncryptDES(strOrg1[i], keyUse);
                        strEP2[i] = DESAlgorithm.EncryptDES(strOrg2[i], keyUse);
                        strEP3[i] = DESAlgorithm.EncryptDES(strOrg3[i], keyUse);
                        strEP4[i] = DESAlgorithm.EncryptDES(strOrg4[i], keyUse);

                        longitude[i] = Convert.ToDouble(strOrg2[i]);
                        latitude[i] = Convert.ToDouble(strOrg3[i]);

                        longitudeTemp = longitude[i];
                        latitudeTemp = latitude[i];

                        listOrg5.Add(MarchLabel.getLabel(longitudeTemp, latitudeTemp));
                    }
                    string[] strOrg5=(string[])listOrg5.ToArray(typeof(string));

                    for (int i = 0; i < tuplesCount; i++)
                    {
                        //加入密文数据（含桶标签）
                        command.CommandText = "insert into table5 (Province,City,Longitude,Latitude,GDP,BucketLabel)"
                            + "values ('" + strEP0[i] + "','" + strEP1[i] + "','" + strEP2[i] + "','" + strEP3[i] + "','" + strEP4[i] + "','" + strOrg5[i] + "')";
                        int n = command.ExecuteNonQuery();
                        Console.WriteLine("成功插入数据{0}行", n);
                        //加入明文数据（比密文数据表少桶标签一列）
                        command.CommandText = "insert into table6 (Province,City,Longitude,Latitude,GDP)"
                            + "values ('" + strOrg0[i] + "','" + strOrg1[i] + "','" + strOrg2[i] + "','" + strOrg3[i] + "','" + strOrg4[i] + "')";
                        n = command.ExecuteNonQuery();
                        Console.WriteLine("成功插入数据{0}行", n); 
                    }
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
