using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections;

namespace Task2._1
{
    public partial class Query : Form
    {
        private static byte[] KeysED = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        private static string keyUse = "12345678";
        private static string keyDe = "12345678";

        /*
         * 以行为单位读取本地文件内容，并以行为单元存入集合中
         * 读取方式：
                    ArrayList list = read();
         */
        static ArrayList read()
        {
            StreamReader objReader = new StreamReader("D:\\BukectInfo3.txt");
            string sLine = "";
            ArrayList LineList = new ArrayList();
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null && !sLine.Equals(""))
                    LineList.Add(sLine);
            }
            objReader.Close();
            return LineList;
        }

        public Query()
        {
            InitializeComponent();
        }

        private void QueryBtn_Click(object sender, EventArgs e)
        {
            string connStr = "Data Source=(local);Initial Catalog=Location;Integrated Security=true";
            SqlConnection conn = new SqlConnection(connStr);
            //显示查询的GDP明文
            string gdpDe = string.Empty;
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                try
                {
                    //获取用户界面查询时文本框输入的数据
                    string city = CityTbx.Text;
                    double longitude = Convert.ToDouble(LongitudeTbx.Text.ToString());
                    double latitude = Convert.ToDouble(LatitudeTbx.Text.ToString());
                    //读取本地的桶标签信息
                    ArrayList list = read();
                    //将读取的信息存储在字符串数组中
                    string[] sentences = (string[])list.ToArray(typeof(string));
                    string[][] wordsStr = new string[list.Count * 5][];
                    for (int i = 0; i < list.Count; i++)
                    {
                        wordsStr[i] = sentences[i].Split(' ');//将所有的数据存放在数组WordsStr中
                    }
                    //查询点所属的桶标签bucketLabel
                    string bucketLabel = String.Empty;
                    Query query = new Query();
                    for (int i = 0; i < list.Count; i++)
                    {
                        /*
                         * 考虑该点所属范围的优先级（由高到低）：R2，R3，...Rn，R1(n个桶)
                         */
                        if ((Convert.ToDouble(wordsStr[(i + 1) % list.Count][0]) <= longitude) && (Convert.ToDouble(wordsStr[(i + 1) % list.Count][2]) >= longitude)
                            && (Convert.ToDouble(wordsStr[(i + 1) % list.Count][1]) >= latitude) && (Convert.ToDouble((i + 1) % list.Count) <= latitude))
                        {
                            //如果输入的数据在这个范围内，那么桶标签就为二维数组wordsStr第五列对应的数据
                            bucketLabel = wordsStr[(i + 1) % list.Count][4];
                            break;
                        }
                    }
                    //说明输入的数据在数据库中并不存在
                    if (bucketLabel == null)
                    {
                        MessageBox.Show("请检查输入的经纬度");
                        this.Hide();
                        query.Show(); 
                    }


                    //将用户查询界面输入的数据（城市）和查询的数据匹配，成功就显示该市的GDP
                    command.CommandText = "select Province,City,Longitude,Latitude,GDP,BucketLabel from table5 where BucketLabel = '" + bucketLabel + "'";
                    //SqlDataReader reader = command.ExecuteReader();
                    //使用SqlDataAdapter将数据库中读取的数据填入DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    DataTable dt1 = new DataTable("Province,City,Longitude,Latitude,GDP,BucketLabel");
                    adapter.Fill(dt1);
                    string tmp = System.Text.Encoding.Default.GetString(KeysED);
                    /*
                     * 
                     */
                    //将DataTable单元格中的数据一一读出，读出的类型为弱类型object
                    ArrayList cityList = new ArrayList();
                    //ArrayList中存放的元素是加密的，我们需要一一解密
                    tmp = System.Text.Encoding.Default.GetString(KeysED);
                    //存放解密字符串的数组
                    string[] strDe = new string[dt1.Rows.Count];//DataTable里存放的元组数目：dt1.Rows.Count就是数据库中与输入数据所属桶标签相同的元组数
                    bool flag = false;//标记输入的城市和位置是否匹配，如果匹配就为真，否则为假
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        //将所有桶标签为"bucketLabel"的元组的城市存入cityList中
                        cityList.Add(dt1.Rows[i][1].ToString());//city是第一列
                        //将存放加密元素City的ArrayList转换为字符串数组cityStr
                        string[] cityStr = (string[])cityList.ToArray(typeof(string));
                        strDe[i] = DESAlgorithm.DecryptDES(cityStr[i], keyDe);
                        //通过将strDe数组中的元素和用户界面输入的City比较，匹配成功返回strDe的下标i，并通过i来确定GDP的位置
                        if (strDe[i] == city)
                        {
                            flag = true;//城市和地理位置是匹配的
                            //向Grid网格中填写加密的数据（包含误报元组）
                            dataGridView1.DataSource = ds.Tables[0];
                            //找到要查询的元组的位置，返回该城市的加密GDP字符串
                            //DataTable中的第二列就是GDP
                            string gdp = dt1.Rows[i][4].ToString();//加密的GDP字符串，GDP属性位于第四列
                            string longitudeS=dt1.Rows[i][2].ToString();//来自服务器的longitude加密字符串，Longitude属性位于第二列
                            string latitudeS=dt1.Rows[i][3].ToString();//来自服务器的latitude加密字符串，Latitude属性位于第三列
                            gdpDe = DESAlgorithm.DecryptDES(gdp, keyDe);//解密的GDP字符串
                            string longitudeDe = DESAlgorithm.DecryptDES(longitudeS, keyDe);//解密的longitude字符串
                            string latitudeDe = DESAlgorithm.DecryptDES(latitudeS, keyDe);//解密的latitude字符串
                            if ((longitudeDe != LongitudeTbx.Text) || (latitudeDe != LatitudeTbx.Text))
                            {
                                flag = false;
                            }
                            //MessageBox.Show("GDP\r\n" + gdpDe);
                            //this.Hide();
                            //query.Show();
                        }
                    }
                    if (!flag)
                    {
                        MessageBox.Show("城市与位置不匹配");
                        this.Hide();
                        query.Show();
                    }
                    else
                    {
                        DialogForm dialog = new DialogForm();
                        dialog.Owner = this;
                        dialog.GDPTbx.Text = gdpDe;
                        dialog.Show();
                    }
                }
                finally
                {
                    command.Dispose();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("出现异常" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Query_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'locationDataSet3.table5' table. You can move, or remove it, as needed.
            this.table5TableAdapter.Fill(this.locationDataSet3.table5);
            // TODO: This line of code loads data into the 'locationDataSet3.table1' table. You can move, or remove it, as needed.
            this.table1TableAdapter1.Fill(this.locationDataSet3.table1);
            // TODO: This line of code loads data into the 'locationDataSet2.table1' table. You can move, or remove it, as needed.
            this.table1TableAdapter.Fill(this.locationDataSet2.table1);
        }
        //cityTbx-->longitudeTbx
        private void CityTbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 40)
                LongitudeTbx.Focus();
        }
        //cityTbx-->longitudeTbx
        private void CityTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                LongitudeTbx.Focus();
        }
        //longitudeTbx-->latitudeTbx
        private void LongitudeTbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 40)
                LatitudeTbx.Focus();
        }
        //longitudeTbx-->latitudeTbx
        private void LongitudeTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                LatitudeTbx.Focus();
        }
        //longitudeTbx-->cityTbx
        private void LongitudeTbx_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 38)
                CityTbx.Focus();
        }
        //latitudeTbx-->longitudeTbx
        private void LatitudeTbx_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 38)
                LongitudeTbx.Focus();
        }
        //latitudeTbx-->queryBtn
        private void LatitudeTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                QueryBtn_Click(sender, e);
        }

    }
}
