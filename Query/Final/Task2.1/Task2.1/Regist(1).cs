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
    public partial class Regist : Form
    {
        public Regist()
        {
            InitializeComponent();
        }

        private void RegistBtn_Click(object sender, EventArgs e)
        {
            string connStr = "Data Source=(local);Initial Catalog=Location;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                try
                {
                    command.CommandText = "create login " + RegistNameTbx.Text + " with password = '" + RegistPawdTbx.Text + "';";
                    object o = command.ExecuteScalar();
                }
                finally
                {
                    MessageBox.Show("注册成功");
                    this.Hide();
                    Login longin = new Login();
                    longin.Show();
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

        private void Regist_Load(object sender, EventArgs e)
        {
            RegistPawdTbx.PasswordChar = '*';
        }
        //registnameTbx-->registpasswdTbx
        private void RegistNameTbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 40)
                RegistPawdTbx.Focus();
        }
        //registnameTbx-->registpasswdTbx
        private void RegistNameTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                RegistPawdTbx.Focus();
        }
        //registpasswdTbx-->registnameTbx
        private void RegistPawdTbx_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 38)
                RegistNameTbx.Focus();
        }
        //registpasswdTbx-->registBtn
        private void RegistPawdTbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                RegistBtn_Click(sender, e);
        }
    }
}
