namespace SuperMap.Desktop.ExportToTabular
{
    partial class _frmExportToTabular
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
            this.btnExportTo = new System.Windows.Forms.Button();
            this.lblX = new System.Windows.Forms.Label();
            this.cmbDatasource1 = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDatasource = new System.Windows.Forms.ComboBox();
            this.lbDataset = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLeftMove = new System.Windows.Forms.Button();
            this.btnRightMove = new System.Windows.Forms.Button();
            this.lbInsert = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExportTo
            // 
            this.btnExportTo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExportTo.Location = new System.Drawing.Point(517, 569);
            this.btnExportTo.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportTo.Name = "btnExportTo";
            this.btnExportTo.Size = new System.Drawing.Size(89, 38);
            this.btnExportTo.TabIndex = 0;
            this.btnExportTo.Text = "确定";
            this.btnExportTo.UseVisualStyleBackColor = true;
            this.btnExportTo.Click += new System.EventHandler(this.btnExportTo_Click);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("宋体", 11F);
            this.lblX.Location = new System.Drawing.Point(407, 29);
            this.lblX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(131, 22);
            this.lblX.TabIndex = 1;
            this.lblX.Text = "输出数据源:";
            // 
            // cmbDatasource1
            // 
            this.cmbDatasource1.FormattingEnabled = true;
            this.cmbDatasource1.Location = new System.Drawing.Point(542, 28);
            this.cmbDatasource1.Name = "cmbDatasource1";
            this.cmbDatasource1.Size = new System.Drawing.Size(190, 26);
            this.cmbDatasource1.TabIndex = 5;
            this.cmbDatasource1.Click += new System.EventHandler(this.cmbDatasource1_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(641, 569);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(89, 38);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "取消";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(40, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 22);
            this.label1.TabIndex = 8;
            this.label1.Text = "输入数据源:";
            // 
            // cmbDatasource
            // 
            this.cmbDatasource.FormattingEnabled = true;
            this.cmbDatasource.Location = new System.Drawing.Point(175, 27);
            this.cmbDatasource.Name = "cmbDatasource";
            this.cmbDatasource.Size = new System.Drawing.Size(192, 26);
            this.cmbDatasource.TabIndex = 9;
            //this.cmbDatasource.SelectedIndexChanged += new System.EventHandler(this.cmbDatasource_SelectedIndexChanged);
            this.cmbDatasource.Click += new System.EventHandler(this.cmbDatasource_Click);
            // 
            // lbDataset
            // 
            this.lbDataset.Font = new System.Drawing.Font("宋体", 9F);
            this.lbDataset.FormattingEnabled = true;
            this.lbDataset.ItemHeight = 18;
            this.lbDataset.Location = new System.Drawing.Point(22, 41);
            this.lbDataset.Name = "lbDataset";
            this.lbDataset.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbDataset.Size = new System.Drawing.Size(298, 400);
            this.lbDataset.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLeftMove);
            this.groupBox1.Controls.Add(this.btnRightMove);
            this.groupBox1.Controls.Add(this.lbInsert);
            this.groupBox1.Controls.Add(this.lbDataset);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 11F);
            this.groupBox1.Location = new System.Drawing.Point(32, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(735, 472);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据集选择";
            // 
            // btnLeftMove
            // 
            this.btnLeftMove.Location = new System.Drawing.Point(353, 234);
            this.btnLeftMove.Name = "btnLeftMove";
            this.btnLeftMove.Size = new System.Drawing.Size(45, 41);
            this.btnLeftMove.TabIndex = 13;
            this.btnLeftMove.Text = "<";
            this.btnLeftMove.UseVisualStyleBackColor = true;
            this.btnLeftMove.Click += new System.EventHandler(this.btnLeftMove_Click);
            // 
            // btnRightMove
            // 
            this.btnRightMove.Location = new System.Drawing.Point(353, 152);
            this.btnRightMove.Name = "btnRightMove";
            this.btnRightMove.Size = new System.Drawing.Size(45, 41);
            this.btnRightMove.TabIndex = 12;
            this.btnRightMove.Text = ">";
            this.btnRightMove.UseVisualStyleBackColor = true;
            this.btnRightMove.Click += new System.EventHandler(this.btnRightMove_Click);
            // 
            // lbInsert
            // 
            this.lbInsert.Font = new System.Drawing.Font("宋体", 9F);
            this.lbInsert.FormattingEnabled = true;
            this.lbInsert.ItemHeight = 18;
            this.lbInsert.Location = new System.Drawing.Point(422, 40);
            this.lbInsert.Name = "lbInsert";
            this.lbInsert.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbInsert.Size = new System.Drawing.Size(298, 400);
            this.lbInsert.TabIndex = 11;
            // 
            // _frmExportToTabular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 629);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbDatasource);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cmbDatasource1);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.btnExportTo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "_frmExportToTabular";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "转换为属性表数据";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExportTo;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.ComboBox cmbDatasource1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDatasource;
        private System.Windows.Forms.ListBox lbDataset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLeftMove;
        private System.Windows.Forms.Button btnRightMove;
        private System.Windows.Forms.ListBox lbInsert;
    }
}