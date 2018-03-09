namespace Task1
{
    partial class AddData
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
            this.provinceTbx = new System.Windows.Forms.TextBox();
            this.cityTbx = new System.Windows.Forms.TextBox();
            this.longitudeTbx = new System.Windows.Forms.TextBox();
            this.latitudeTbx = new System.Windows.Forms.TextBox();
            this.GDPTbx = new System.Windows.Forms.TextBox();
            this.Province = new System.Windows.Forms.Label();
            this.City = new System.Windows.Forms.Label();
            this.Longitude = new System.Windows.Forms.Label();
            this.Latitude = new System.Windows.Forms.Label();
            this.GDP = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // provinceTbx
            // 
            this.provinceTbx.Location = new System.Drawing.Point(109, 34);
            this.provinceTbx.Name = "provinceTbx";
            this.provinceTbx.Size = new System.Drawing.Size(100, 21);
            this.provinceTbx.TabIndex = 0;
            this.provinceTbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.provinceTbx_KeyDown);
            this.provinceTbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.provinceTbx_KeyPress);
            // 
            // cityTbx
            // 
            this.cityTbx.Location = new System.Drawing.Point(109, 81);
            this.cityTbx.Name = "cityTbx";
            this.cityTbx.Size = new System.Drawing.Size(100, 21);
            this.cityTbx.TabIndex = 1;
            this.cityTbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cityTbx_KeyDown);
            this.cityTbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cityTbx_KeyPress);
            this.cityTbx.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cityTbx_KeyUp);
            // 
            // longitudeTbx
            // 
            this.longitudeTbx.Location = new System.Drawing.Point(109, 122);
            this.longitudeTbx.Name = "longitudeTbx";
            this.longitudeTbx.Size = new System.Drawing.Size(100, 21);
            this.longitudeTbx.TabIndex = 2;
            this.longitudeTbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.longitudeTbx_KeyDown);
            this.longitudeTbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.longitudeTbx_KeyPress);
            this.longitudeTbx.KeyUp += new System.Windows.Forms.KeyEventHandler(this.longitudeTbx_KeyUp);
            // 
            // latitudeTbx
            // 
            this.latitudeTbx.Location = new System.Drawing.Point(109, 172);
            this.latitudeTbx.Name = "latitudeTbx";
            this.latitudeTbx.Size = new System.Drawing.Size(100, 21);
            this.latitudeTbx.TabIndex = 3;
            this.latitudeTbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.latitudeTbx_KeyDown);
            this.latitudeTbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.latitudeTbx_KeyPress);
            this.latitudeTbx.KeyUp += new System.Windows.Forms.KeyEventHandler(this.latitudeTbx_KeyUp);
            // 
            // GDPTbx
            // 
            this.GDPTbx.Location = new System.Drawing.Point(109, 213);
            this.GDPTbx.Name = "GDPTbx";
            this.GDPTbx.Size = new System.Drawing.Size(100, 21);
            this.GDPTbx.TabIndex = 4;
            this.GDPTbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GDPTbx_KeyPress);
            this.GDPTbx.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GDPTbx_KeyUp);
            // 
            // Province
            // 
            this.Province.AutoSize = true;
            this.Province.Location = new System.Drawing.Point(12, 43);
            this.Province.Name = "Province";
            this.Province.Size = new System.Drawing.Size(53, 12);
            this.Province.TabIndex = 5;
            this.Province.Text = "Province";
            this.Province.Click += new System.EventHandler(this.Province_Click);
            // 
            // City
            // 
            this.City.AutoSize = true;
            this.City.Location = new System.Drawing.Point(12, 90);
            this.City.Name = "City";
            this.City.Size = new System.Drawing.Size(29, 12);
            this.City.TabIndex = 6;
            this.City.Text = "City";
            // 
            // Longitude
            // 
            this.Longitude.AutoSize = true;
            this.Longitude.Location = new System.Drawing.Point(12, 131);
            this.Longitude.Name = "Longitude";
            this.Longitude.Size = new System.Drawing.Size(59, 12);
            this.Longitude.TabIndex = 7;
            this.Longitude.Text = "Longitude";
            // 
            // Latitude
            // 
            this.Latitude.AutoSize = true;
            this.Latitude.Location = new System.Drawing.Point(12, 181);
            this.Latitude.Name = "Latitude";
            this.Latitude.Size = new System.Drawing.Size(53, 12);
            this.Latitude.TabIndex = 8;
            this.Latitude.Text = "Latitude";
            // 
            // GDP
            // 
            this.GDP.AutoSize = true;
            this.GDP.Location = new System.Drawing.Point(12, 222);
            this.GDP.Name = "GDP";
            this.GDP.Size = new System.Drawing.Size(23, 12);
            this.GDP.TabIndex = 9;
            this.GDP.Text = "GDP";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(134, 259);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 10;
            this.addBtn.Text = "添加";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // AddData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 285);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.GDP);
            this.Controls.Add(this.Latitude);
            this.Controls.Add(this.Longitude);
            this.Controls.Add(this.City);
            this.Controls.Add(this.Province);
            this.Controls.Add(this.GDPTbx);
            this.Controls.Add(this.latitudeTbx);
            this.Controls.Add(this.longitudeTbx);
            this.Controls.Add(this.cityTbx);
            this.Controls.Add(this.provinceTbx);
            this.Name = "AddData";
            this.Text = "AddData";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox provinceTbx;
        private System.Windows.Forms.TextBox cityTbx;
        private System.Windows.Forms.TextBox longitudeTbx;
        private System.Windows.Forms.TextBox latitudeTbx;
        private System.Windows.Forms.TextBox GDPTbx;
        private System.Windows.Forms.Label Province;
        private System.Windows.Forms.Label City;
        private System.Windows.Forms.Label Longitude;
        private System.Windows.Forms.Label Latitude;
        private System.Windows.Forms.Label GDP;
        private System.Windows.Forms.Button addBtn;
    }
}