namespace ReporteDeVentas
{
    partial class FrmReporteVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReporteVentas));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.campo1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.campo2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.campo2ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.campo3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridCampo = new System.Windows.Forms.DataGridView();
            this.Campo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selecciona = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CampoBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Button5 = new System.Windows.Forms.Button();
            this.dataGridView = new ADGV.AdvancedDataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbTipoMovimiento = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCampo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Desde";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.hasta);
            this.groupBox1.Controls.Add(this.dtpDesde);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(488, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 93);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fecha";
            // 
            // hasta
            // 
            this.hasta.CustomFormat = "dd-MM-yyyy";
            this.hasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.hasta.Location = new System.Drawing.Point(51, 48);
            this.hasta.MaxDate = new System.DateTime(9998, 1, 1, 0, 0, 0, 0);
            this.hasta.Name = "hasta";
            this.hasta.Size = new System.Drawing.Size(88, 20);
            this.hasta.TabIndex = 13;
            this.hasta.Value = new System.DateTime(2018, 9, 5, 0, 0, 0, 0);
            // 
            // dtpDesde
            // 
            this.dtpDesde.CustomFormat = "dd-MM-yyyy";
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.Location = new System.Drawing.Point(54, 19);
            this.dtpDesde.MaxDate = new System.DateTime(9998, 1, 1, 0, 0, 0, 0);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(85, 20);
            this.dtpDesde.TabIndex = 12;
            this.dtpDesde.Value = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasta";
            // 
            // campo1ToolStripMenuItem
            // 
            this.campo1ToolStripMenuItem.Name = "campo1ToolStripMenuItem";
            this.campo1ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // campo2ToolStripMenuItem
            // 
            this.campo2ToolStripMenuItem.Name = "campo2ToolStripMenuItem";
            this.campo2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.campo2ToolStripMenuItem.Text = "campo 1";
            // 
            // campo2ToolStripMenuItem1
            // 
            this.campo2ToolStripMenuItem1.Name = "campo2ToolStripMenuItem1";
            this.campo2ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.campo2ToolStripMenuItem1.Text = "campo2";
            // 
            // campo3ToolStripMenuItem
            // 
            this.campo3ToolStripMenuItem.Name = "campo3ToolStripMenuItem";
            this.campo3ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.campo3ToolStripMenuItem.Text = "campo3";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(642, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 21);
            this.button1.TabIndex = 11;
            this.button1.Text = "Ver Reporte";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridCampo
            // 
            this.dataGridCampo.AllowUserToAddRows = false;
            this.dataGridCampo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridCampo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCampo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridCampo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Campo,
            this.selecciona,
            this.CampoBD});
            this.dataGridCampo.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridCampo.Location = new System.Drawing.Point(488, 155);
            this.dataGridCampo.Name = "dataGridCampo";
            this.dataGridCampo.Size = new System.Drawing.Size(278, 280);
            this.dataGridCampo.TabIndex = 13;
            // 
            // Campo
            // 
            this.Campo.HeaderText = "Campo";
            this.Campo.Name = "Campo";
            // 
            // selecciona
            // 
            this.selecciona.HeaderText = "Seleccionar";
            this.selecciona.Name = "selecciona";
            this.selecciona.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.selecciona.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CampoBD
            // 
            this.CampoBD.HeaderText = "CampoBD";
            this.CampoBD.Name = "CampoBD";
            this.CampoBD.Visible = false;
            // 
            // Button5
            // 
            this.Button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Button5.BackgroundImage")));
            this.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Button5.Location = new System.Drawing.Point(647, 12);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(76, 74);
            this.Button5.TabIndex = 18;
            this.Button5.UseVisualStyleBackColor = true;
            this.Button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.DefaultCellBehavior = ADGV.ADGVColumnHeaderCellBehavior.SortingFiltering;
            this.dataGridView.DefaultDateTimeGrouping = ADGV.ADGVFilterMenuDateTimeGrouping.Second;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(470, 423);
            this.dataGridView.StandardTab = true;
            this.dataGridView.TabIndex = 19;
            this.dataGridView.SortStringChanged += new System.EventHandler(this.dataGridView_SortStringChanged);
            this.dataGridView.FilterStringChanged += new System.EventHandler(this.dataGridView_FilterStringChanged);
            this.dataGridView.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView_ColumnAdded);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cbTipoMovimiento);
            this.groupBox2.Location = new System.Drawing.Point(488, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(153, 50);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo de Movimiento";
            // 
            // cbTipoMovimiento
            // 
            this.cbTipoMovimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoMovimiento.FormattingEnabled = true;
            this.cbTipoMovimiento.Location = new System.Drawing.Point(6, 18);
            this.cbTipoMovimiento.Name = "cbTipoMovimiento";
            this.cbTipoMovimiento.Size = new System.Drawing.Size(133, 21);
            this.cbTipoMovimiento.TabIndex = 0;
            // 
            // FrmReporteVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(778, 447);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.Button5);
            this.Controls.Add(this.dataGridCampo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReporteVentas";
            this.Text = "Reporte de Ventas";
            this.Load += new System.EventHandler(this.FrmReporteVentas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCampo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem campo1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem campo2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem campo2ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem campo3ToolStripMenuItem;
        internal System.Windows.Forms.DateTimePicker hasta;
        internal System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridCampo;
        internal System.Windows.Forms.Button Button5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Campo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selecciona;
        private System.Windows.Forms.DataGridViewTextBoxColumn CampoBD;
        public ADGV.AdvancedDataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbTipoMovimiento;
    }
}

