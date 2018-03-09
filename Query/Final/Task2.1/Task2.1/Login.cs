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

namespace Task2._1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private int flag = 0;

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string connString;
            connString = "Data Source=" + ServerTbx.Text + ";";
            connString += "Initial Catalog=" + DatabaseTbx.Text + ";";
            if (WinRbtn.Checked)
            {
                connString += "Integrated Security=true";
            }
            else
            {
                connString += "user id=" + UserNameTbx.Text + ";";
                connString += "password=" + PasswdTbx.Text;
            }
            SqlConnection connection = new SqlConnection(connString);
            try
            {
                connection.Open();
                MessageBox.Show("连接成功！");
                Query query = new Query();
                query.Show();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("连接失败。可能是服务器不存在或者连接已经打开。\r\n" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void SQLRbtn_CheckedChanged(object sender, EventArgs e)
        {
            UserNameTbx.Enabled = SQLRbtn.Checked;
            PasswdTbx.Enabled = SQLRbtn.Checked;
            flag = 1;
        }

        private void RegistBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("你将进行注册", "提示");
            this.Hide();
            Regist regist = new Regist();
            regist.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            WinRbtn.Checked = true;
            UserNameTbx.Enabled = false;
            PasswdTbx.Enabled = false;
            PasswdTbx.PasswordChar = '*';
        }
        //serverTbx-->databaseTbx
        private void ServerTbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 40)
                DatabaseTbx.Focus();
        }
        //serverTbx-->databaseTbx
        private void ServerTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                DatabaseTbx.Focus();
        }
        //databaseTbx-->serverTbx
        private void DatabaseTbx_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 38)
                ServerTbx.Focus();
        }
        //databaseTbx-->loginBtn
        private void DatabaseTbx_KeyPress(object sender, KeyPressEventArgs e)
        { 
            //如果只选择windows身份方式登录
            if (flag == 0)
            {
                if (e.KeyChar == (char)Keys.Enter)
                    LoginBtn_Click(sender, e);
            }
            //如果选择混合模式登入
            else
            {
                if (e.KeyChar == (char)Keys.Enter)
                    UserNameTbx.Focus(); 
            }
            
        }
        //databaseTbx-->loginBtn
        private void DatabaseTbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (flag == 0)
            {
                if (e.KeyValue == 40)
                    DatabaseTbx.Focus();
            }
            else
            {
                if (e.KeyValue == 40)
                    UserNameTbx.Focus();
            }
        }
        //usernameTbx-->passwordTbx
        private void UserNameTbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 40)
                PasswdTbx.Focus();
        }
        //usernameTbx-->passwordTbx
        private void UserNameTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                PasswdTbx.Focus();
        }
        //usernameTbx-->databaseTbx
        private void UserNameTbx_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 38)
                DatabaseTbx.Focus();
        }
        //passwordTbx-->usernameTbx
        private void PasswdTbx_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 38)
                UserNameTbx.Focus();
        }

        private void PasswdTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                LoginBtn_Click(sender, e);
        }
    }
}
