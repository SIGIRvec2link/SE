namespace Task2._1
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.WinRbtn = new System.Windows.Forms.RadioButton();
            this.SQLRbtn = new System.Windows.Forms.RadioButton();
            this.ServerTbx = new System.Windows.Forms.TextBox();
            this.DatabaseTbx = new System.Windows.Forms.TextBox();
            this.UserNameTbx = new System.Windows.Forms.TextBox();
            this.PasswdTbx = new System.Windows.Forms.TextBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.RegistBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "数据库";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "用户名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "密码";
            // 
            // WinRbtn
            // 
            this.WinRbtn.AutoSize = true;
            this.WinRbtn.Location = new System.Drawing.Point(30, 99);
            this.WinRbtn.Name = "WinRbtn";
            this.WinRbtn.Size = new System.Drawing.Size(113, 16);
            this.WinRbtn.TabIndex = 4;
            this.WinRbtn.TabStop = true;
            this.WinRbtn.Text = "Windows身份验证";
            this.WinRbtn.UseVisualStyleBackColor = true;
            // 
            // SQLRbtn
            // 
            this.SQLRbtn.AutoSize = true;
            this.SQLRbtn.Location = new System.Drawing.Point(30, 132);
            this.SQLRbtn.Name = "SQLRbtn";
            this.SQLRbtn.Size = new System.Drawing.Size(131, 16);
            this.SQLRbtn.TabIndex = 5;
            this.SQLRbtn.TabStop = true;
            this.SQLRbtn.Text = "SQL Server身份验证";
            this.SQLRbtn.UseVisualStyleBackColor = true;
            this.SQLRbtn.CheckedChanged += new System.EventHandler(this.SQLRbtn_CheckedChanged);
            // 
            // ServerTbx
            // 
            this.ServerTbx.Location = new System.Drawing.Point(101, 27);
            this.ServerTbx.Name = "ServerTbx";
            this.ServerTbx.Size = new System.Drawing.Size(100, 21);
            this.ServerTbx.TabIndex = 6;
            this.ServerTbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ServerTbx_KeyDown);
            this.ServerTbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ServerTbx_KeyPress);
            // 
            // DatabaseTbx
            // 
            this.DatabaseTbx.Location = new System.Drawing.Point(101, 60);
            this.DatabaseTbx.Name = "DatabaseTbx";
            this.DatabaseTbx.Size = new System.Drawing.Size(100, 21);
            this.DatabaseTbx.TabIndex = 7;
            this.DatabaseTbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DatabaseTbx_KeyDown);
            this.DatabaseTbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DatabaseTbx_KeyPress);
            this.DatabaseTbx.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DatabaseTbx_KeyUp);
            // 
            // UserNameTbx
            // 
            this.UserNameTbx.Location = new System.Drawing.Point(101, 159);
            this.UserNameTbx.Name = "UserNameTbx";
            this.UserNameTbx.Size = new System.Drawing.Size(100, 21);
            this.UserNameTbx.TabIndex = 8;
            this.UserNameTbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserNameTbx_KeyDown);
            this.UserNameTbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UserNameTbx_KeyPress);
            this.UserNameTbx.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UserNameTbx_KeyUp);
            // 
            // PasswdTbx
            // 
            this.PasswdTbx.Location = new System.Drawing.Point(101, 189);
            this.PasswdTbx.Name = "PasswdTbx";
            this.PasswdTbx.Size = new System.Drawing.Size(100, 21);
            this.PasswdTbx.TabIndex = 9;
            this.PasswdTbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PasswdTbx_KeyPress);
            this.PasswdTbx.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PasswdTbx_KeyUp);
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(30, 227);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(75, 23);
            this.LoginBtn.TabIndex = 10;
            this.LoginBtn.Text = "登录";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // RegistBtn
            // 
            this.RegistBtn.Location = new System.Drawing.Point(126, 227);
            this.RegistBtn.Name = "RegistBtn";
            this.RegistBtn.Size = new System.Drawing.Size(75, 23);
            this.RegistBtn.TabIndex = 11;
            this.RegistBtn.Text = "注册";
            this.RegistBtn.UseVisualStyleBackColor = true;
            this.RegistBtn.Click += new System.EventHandler(this.RegistBtn_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 262);
            this.Controls.Add(this.RegistBtn);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.PasswdTbx);
            this.Controls.Add(this.UserNameTbx);
            this.Controls.Add(this.DatabaseTbx);
            this.Controls.Add(this.ServerTbx);
            this.Controls.Add(this.SQLRbtn);
            this.Controls.Add(this.WinRbtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "登录";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton WinRbtn;
        private System.Windows.Forms.RadioButton SQLRbtn;
        private System.Windows.Forms.TextBox ServerTbx;
        private System.Windows.Forms.TextBox DatabaseTbx;
        private System.Windows.Forms.TextBox UserNameTbx;
        private System.Windows.Forms.TextBox PasswdTbx;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Button RegistBtn;
    }
}

