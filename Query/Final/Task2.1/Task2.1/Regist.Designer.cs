namespace Task2._1
{
    partial class Regist
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
            this.RegistNameTbx = new System.Windows.Forms.TextBox();
            this.RegistPawdTbx = new System.Windows.Forms.TextBox();
            this.RegistBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码";
            // 
            // RegistNameTbx
            // 
            this.RegistNameTbx.Location = new System.Drawing.Point(93, 47);
            this.RegistNameTbx.Name = "RegistNameTbx";
            this.RegistNameTbx.Size = new System.Drawing.Size(100, 21);
            this.RegistNameTbx.TabIndex = 2;
            this.RegistNameTbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegistNameTbx_KeyDown);
            this.RegistNameTbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RegistNameTbx_KeyPress);
            // 
            // RegistPawdTbx
            // 
            this.RegistPawdTbx.Location = new System.Drawing.Point(93, 125);
            this.RegistPawdTbx.Name = "RegistPawdTbx";
            this.RegistPawdTbx.Size = new System.Drawing.Size(100, 21);
            this.RegistPawdTbx.TabIndex = 3;
            this.RegistPawdTbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RegistPawdTbx_KeyPress);
            this.RegistPawdTbx.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RegistPawdTbx_KeyUp);
            // 
            // RegistBtn
            // 
            this.RegistBtn.Location = new System.Drawing.Point(129, 183);
            this.RegistBtn.Name = "RegistBtn";
            this.RegistBtn.Size = new System.Drawing.Size(78, 22);
            this.RegistBtn.TabIndex = 4;
            this.RegistBtn.Text = "注册";
            this.RegistBtn.UseVisualStyleBackColor = true;
            this.RegistBtn.Click += new System.EventHandler(this.RegistBtn_Click);
            // 
            // Regist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 243);
            this.Controls.Add(this.RegistBtn);
            this.Controls.Add(this.RegistPawdTbx);
            this.Controls.Add(this.RegistNameTbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Regist";
            this.Text = "Regist";
            this.Load += new System.EventHandler(this.Regist_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RegistNameTbx;
        private System.Windows.Forms.TextBox RegistPawdTbx;
        private System.Windows.Forms.Button RegistBtn;
    }
}