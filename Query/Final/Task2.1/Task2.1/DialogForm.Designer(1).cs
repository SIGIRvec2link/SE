namespace Task2._1
{
    partial class DialogForm
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
            this.GDPTbx = new System.Windows.Forms.TextBox();
            this.GDPlab = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GDPTbx
            // 
            this.GDPTbx.Enabled = false;
            this.GDPTbx.Location = new System.Drawing.Point(152, 88);
            this.GDPTbx.Name = "GDPTbx";
            this.GDPTbx.Size = new System.Drawing.Size(100, 21);
            this.GDPTbx.TabIndex = 0;
            // 
            // GDPlab
            // 
            this.GDPlab.AutoSize = true;
            this.GDPlab.Location = new System.Drawing.Point(40, 93);
            this.GDPlab.Name = "GDPlab";
            this.GDPlab.Size = new System.Drawing.Size(23, 12);
            this.GDPlab.TabIndex = 1;
            this.GDPlab.Text = "GDP";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 31);
            this.button1.TabIndex = 2;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 256);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GDPlab);
            this.Controls.Add(this.GDPTbx);
            this.Name = "DialogForm";
            this.Text = "DialogForm";
            this.Load += new System.EventHandler(this.DialogForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GDPlab;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox GDPTbx;
    }
}