using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace Task1
{
    public partial class AddData : Form
    {
        public AddData()
        {
            InitializeComponent();
        }

        /*
         * 添加数据
         */
        private void addBtn_Click(object sender, EventArgs e)
        {
            //int tuplesNum = 54;//要添加到数据库中的元组数（数据集的大小）

            //string[] strOrg0 = new string[tuplesNum];
            //string[] strOrg1 = new string[tuplesNum];
            //string[] strOrg2 = new string[tuplesNum];
            //string[] strOrg3 = new string[tuplesNum];
            //string[] strOrg4 = new string[tuplesNum];

            /*
             * 以下分别为接受用户输入的省、市、经度、纬度、GDP的值
             */
            //ArrayList listStrOrg0 = new ArrayList();
            //ArrayList listStrOrg1= new ArrayList();
            //ArrayList listStrOrg2 = new ArrayList();
            //ArrayList listStrOrg3= new ArrayList();
            //ArrayList listStrOrg4 = new ArrayList();
            string province = provinceTbx.Text;
            string city = cityTbx.Text;
            string longitude = longitudeTbx.Text;
            string latitude = latitudeTbx.Text;
            string GDP = GDPTbx.Text;
            InsertData.insertData(province, city, longitude, latitude, GDP);//插入数据

            MessageBox.Show("插入数据成功！\r\n", "提示", MessageBoxButtons.OK);
            //清除控件中输入的内容
            provinceTbx.Clear();
            cityTbx.Clear();
            longitudeTbx.Clear();
            latitudeTbx.Clear();
            GDPTbx.Clear();
            //将输入焦点放到provinceTbx控件上
            provinceTbx.Focus();  
        }

        private void Province_Click(object sender, EventArgs e)
        {

        }
        //实现光标从省份textbox移动到城市textbox
        private void provinceTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                cityTbx.Focus();
        }
        //实现光标从省份textbox移动到城市textbox
        private void provinceTbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 40)
                cityTbx.Focus();
        }
        //cityTbx-->longitudeTbx
        private void cityTbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 40)
                longitudeTbx.Focus();
        }
        //cityTbx-->longitudeTbx
        private void cityTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                longitudeTbx.Focus();
        }
        //cityTbx-->provinceTbx
        private void cityTbx_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 38)
                provinceTbx.Focus();
        }
        //longitudeTbx-->cityTbx
        private void longitudeTbx_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 38)
                cityTbx.Focus();
        }
        //longitudeTbx-->latitudeTbx
        private void longitudeTbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 40)
                latitudeTbx.Focus();
        }
        //longitudeTbx-->latitudeTbx
        private void longitudeTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                latitudeTbx.Focus();
        }
        //latitudeTbx-->longitudeTbx
        private void latitudeTbx_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 38)
                longitudeTbx.Focus();
        }
        //latitudeTbx-->GDPTbx
        private void latitudeTbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 40)
                GDPTbx.Focus();
        }
        //latitudeTbx-->GDPTbx
        private void latitudeTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                GDPTbx.Focus();
        }
        //GDPTbx-->latitudeTbx
        private void GDPTbx_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 38)
                latitudeTbx.Focus();
        }
        //GDPTbx-->addBtn
        private void GDPTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                addBtn_Click(sender, e);
        }
    }
}
