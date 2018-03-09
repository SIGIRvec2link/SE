namespace Task2._1
{
    partial class Query
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CityTbx = new System.Windows.Forms.TextBox();
            this.LongitudeTbx = new System.Windows.Forms.TextBox();
            this.LatitudeTbx = new System.Windows.Forms.TextBox();
            this.QueryBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.provinceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.longitudeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.latitudeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gDPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bucketLabelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.table1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.locationDataSet3 = new Task2._1.LocationDataSet3();
            this.locationDataSet2 = new Task2._1.LocationDataSet2();
            this.table1TableAdapter = new Task2._1.LocationDataSet2TableAdapters.table1TableAdapter();
            this.table1TableAdapter1 = new Task2._1.LocationDataSet3TableAdapters.table1TableAdapter();
            this.table5TableAdapter = new Task2._1.LocationDataSet3TableAdapters.table5TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "城市";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "经度";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "纬度";
            // 
            // CityTbx
            // 
            this.CityTbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CityTbx.Location = new System.Drawing.Point(96, 36);
            this.CityTbx.Name = "CityTbx";
            this.CityTbx.Size = new System.Drawing.Size(100, 21);
            this.CityTbx.TabIndex = 3;
            this.CityTbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CityTbx_KeyDown);
            this.CityTbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CityTbx_KeyPress);
            // 
            // LongitudeTbx
            // 
            this.LongitudeTbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LongitudeTbx.Location = new System.Drawing.Point(96, 81);
            this.LongitudeTbx.Name = "LongitudeTbx";
            this.LongitudeTbx.Size = new System.Drawing.Size(100, 21);
            this.LongitudeTbx.TabIndex = 4;
            this.LongitudeTbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LongitudeTbx_KeyDown);
            this.LongitudeTbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LongitudeTbx_KeyPress);
            this.LongitudeTbx.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LongitudeTbx_KeyUp);
            // 
            // LatitudeTbx
            // 
            this.LatitudeTbx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LatitudeTbx.Location = new System.Drawing.Point(96, 128);
            this.LatitudeTbx.Name = "LatitudeTbx";
            this.LatitudeTbx.Size = new System.Drawing.Size(100, 21);
            this.LatitudeTbx.TabIndex = 5;
            this.LatitudeTbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LatitudeTbx_KeyPress);
            this.LatitudeTbx.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LatitudeTbx_KeyUp);
            // 
            // QueryBtn
            // 
            this.QueryBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.QueryBtn.Location = new System.Drawing.Point(121, 173);
            this.QueryBtn.Name = "QueryBtn";
            this.QueryBtn.Size = new System.Drawing.Size(75, 23);
            this.QueryBtn.TabIndex = 6;
            this.QueryBtn.Text = "查询";
            this.QueryBtn.UseVisualStyleBackColor = true;
            this.QueryBtn.Click += new System.EventHandler(this.QueryBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.provinceDataGridViewTextBoxColumn,
            this.cityDataGridViewTextBoxColumn,
            this.longitudeDataGridViewTextBoxColumn,
            this.latitudeDataGridViewTextBoxColumn,
            this.gDPDataGridViewTextBoxColumn,
            this.bucketLabelDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.table1BindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(341, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(644, 464);
            this.dataGridView1.TabIndex = 7;
            // 
            // provinceDataGridViewTextBoxColumn
            // 
            this.provinceDataGridViewTextBoxColumn.DataPropertyName = "Province";
            this.provinceDataGridViewTextBoxColumn.HeaderText = "Province";
            this.provinceDataGridViewTextBoxColumn.Name = "provinceDataGridViewTextBoxColumn";
            // 
            // cityDataGridViewTextBoxColumn
            // 
            this.cityDataGridViewTextBoxColumn.DataPropertyName = "City";
            this.cityDataGridViewTextBoxColumn.HeaderText = "City";
            this.cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
            // 
            // longitudeDataGridViewTextBoxColumn
            // 
            this.longitudeDataGridViewTextBoxColumn.DataPropertyName = "Longitude";
            this.longitudeDataGridViewTextBoxColumn.HeaderText = "Longitude";
            this.longitudeDataGridViewTextBoxColumn.Name = "longitudeDataGridViewTextBoxColumn";
            // 
            // latitudeDataGridViewTextBoxColumn
            // 
            this.latitudeDataGridViewTextBoxColumn.DataPropertyName = "Latitude";
            this.latitudeDataGridViewTextBoxColumn.HeaderText = "Latitude";
            this.latitudeDataGridViewTextBoxColumn.Name = "latitudeDataGridViewTextBoxColumn";
            // 
            // gDPDataGridViewTextBoxColumn
            // 
            this.gDPDataGridViewTextBoxColumn.DataPropertyName = "GDP";
            this.gDPDataGridViewTextBoxColumn.HeaderText = "GDP";
            this.gDPDataGridViewTextBoxColumn.Name = "gDPDataGridViewTextBoxColumn";
            // 
            // bucketLabelDataGridViewTextBoxColumn
            // 
            this.bucketLabelDataGridViewTextBoxColumn.DataPropertyName = "BucketLabel";
            this.bucketLabelDataGridViewTextBoxColumn.HeaderText = "BucketLabel";
            this.bucketLabelDataGridViewTextBoxColumn.Name = "bucketLabelDataGridViewTextBoxColumn";
            // 
            // table1BindingSource
            // 
            this.table1BindingSource.DataMember = "table5";
            this.table1BindingSource.DataSource = this.locationDataSet3;
            // 
            // locationDataSet3
            // 
            this.locationDataSet3.DataSetName = "LocationDataSet3";
            this.locationDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // locationDataSet2
            // 
            this.locationDataSet2.DataSetName = "LocationDataSet2";
            this.locationDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // table1TableAdapter
            // 
            this.table1TableAdapter.ClearBeforeFill = true;
            // 
            // table1TableAdapter1
            // 
            this.table1TableAdapter1.ClearBeforeFill = true;
            // 
            // table5TableAdapter
            // 
            this.table5TableAdapter.ClearBeforeFill = true;
            // 
            // Query
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 507);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.QueryBtn);
            this.Controls.Add(this.LatitudeTbx);
            this.Controls.Add(this.LongitudeTbx);
            this.Controls.Add(this.CityTbx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Query";
            this.Text = "查询";
            this.Load += new System.EventHandler(this.Query_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationDataSet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CityTbx;
        private System.Windows.Forms.TextBox LongitudeTbx;
        private System.Windows.Forms.TextBox LatitudeTbx;
        private System.Windows.Forms.Button QueryBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private LocationDataSet2 locationDataSet2;
        private System.Windows.Forms.BindingSource table1BindingSource;
        private LocationDataSet2TableAdapters.table1TableAdapter table1TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn provinceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn longitudeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn latitudeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gDPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bucketLabelDataGridViewTextBoxColumn;
        private LocationDataSet3 locationDataSet3;
        private LocationDataSet3TableAdapters.table1TableAdapter table1TableAdapter1;
        private LocationDataSet3TableAdapters.table5TableAdapter table5TableAdapter;
    }
}