namespace VFP.WinUI
{
    partial class MProcessAysn
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
            this.btnSaveFileDire = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSaveFileDire = new System.Windows.Forms.TextBox();
            this.btnFileDire = new System.Windows.Forms.Button();
            this.txtFileDire = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMes = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvFileList = new System.Windows.Forms.DataGridView();
            this.txtDisposeMes = new System.Windows.Forms.TextBox();
            this.lblprobGetFileList = new System.Windows.Forms.Label();
            this.probGetFileList = new System.Windows.Forms.ProgressBar();
            this.btnGetFiles = new System.Windows.Forms.Button();
            this.fbdBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.btnRep = new System.Windows.Forms.Button();
            this.btnClearTxt = new System.Windows.Forms.Button();
            this.btnGetDuration = new System.Windows.Forms.Button();
            this.btnCreateImg = new System.Windows.Forms.Button();
            this.lblProbGetDuration = new System.Windows.Forms.Label();
            this.probGetDuration = new System.Windows.Forms.ProgressBar();
            this.lblProbGetScreenshot = new System.Windows.Forms.Label();
            this.probGetScreenshot = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveFileDire
            // 
            this.btnSaveFileDire.Location = new System.Drawing.Point(482, 41);
            this.btnSaveFileDire.Name = "btnSaveFileDire";
            this.btnSaveFileDire.Size = new System.Drawing.Size(75, 23);
            this.btnSaveFileDire.TabIndex = 11;
            this.btnSaveFileDire.Text = "浏览";
            this.btnSaveFileDire.UseVisualStyleBackColor = true;
            this.btnSaveFileDire.Click += new System.EventHandler(this.btnSaveFileDire_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "文件保存目录";
            // 
            // txtSaveFileDire
            // 
            this.txtSaveFileDire.Location = new System.Drawing.Point(194, 44);
            this.txtSaveFileDire.Name = "txtSaveFileDire";
            this.txtSaveFileDire.Size = new System.Drawing.Size(267, 21);
            this.txtSaveFileDire.TabIndex = 9;
            // 
            // btnFileDire
            // 
            this.btnFileDire.Location = new System.Drawing.Point(482, 14);
            this.btnFileDire.Name = "btnFileDire";
            this.btnFileDire.Size = new System.Drawing.Size(75, 23);
            this.btnFileDire.TabIndex = 8;
            this.btnFileDire.Text = "浏览";
            this.btnFileDire.UseVisualStyleBackColor = true;
            this.btnFileDire.Click += new System.EventHandler(this.btnFileDire_Click);
            // 
            // txtFileDire
            // 
            this.txtFileDire.Location = new System.Drawing.Point(194, 16);
            this.txtFileDire.Name = "txtFileDire";
            this.txtFileDire.Size = new System.Drawing.Size(267, 21);
            this.txtFileDire.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "待处理文件目录";
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(75, 136);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(17, 12);
            this.lblMes.TabIndex = 19;
            this.lblMes.Text = "..";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "信息：";
            // 
            // dgvFileList
            // 
            this.dgvFileList.AllowUserToAddRows = false;
            this.dgvFileList.AllowUserToDeleteRows = false;
            this.dgvFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFileList.Location = new System.Drawing.Point(32, 157);
            this.dgvFileList.Name = "dgvFileList";
            this.dgvFileList.ReadOnly = true;
            this.dgvFileList.RowTemplate.Height = 23;
            this.dgvFileList.Size = new System.Drawing.Size(699, 224);
            this.dgvFileList.TabIndex = 17;
            // 
            // txtDisposeMes
            // 
            this.txtDisposeMes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDisposeMes.Location = new System.Drawing.Point(32, 387);
            this.txtDisposeMes.Multiline = true;
            this.txtDisposeMes.Name = "txtDisposeMes";
            this.txtDisposeMes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDisposeMes.Size = new System.Drawing.Size(665, 71);
            this.txtDisposeMes.TabIndex = 20;
            // 
            // lblprobGetFileList
            // 
            this.lblprobGetFileList.AutoSize = true;
            this.lblprobGetFileList.Location = new System.Drawing.Point(123, 109);
            this.lblprobGetFileList.Name = "lblprobGetFileList";
            this.lblprobGetFileList.Size = new System.Drawing.Size(17, 12);
            this.lblprobGetFileList.TabIndex = 23;
            this.lblprobGetFileList.Text = "0%";
            // 
            // probGetFileList
            // 
            this.probGetFileList.Location = new System.Drawing.Point(32, 103);
            this.probGetFileList.Name = "probGetFileList";
            this.probGetFileList.Size = new System.Drawing.Size(87, 23);
            this.probGetFileList.TabIndex = 22;
            // 
            // btnGetFiles
            // 
            this.btnGetFiles.Location = new System.Drawing.Point(32, 77);
            this.btnGetFiles.Name = "btnGetFiles";
            this.btnGetFiles.Size = new System.Drawing.Size(102, 23);
            this.btnGetFiles.TabIndex = 21;
            this.btnGetFiles.Text = "获取文件";
            this.btnGetFiles.UseVisualStyleBackColor = true;
            this.btnGetFiles.Click += new System.EventHandler(this.btnGetFiles_Click);
            // 
            // btnRep
            // 
            this.btnRep.Location = new System.Drawing.Point(576, 19);
            this.btnRep.Name = "btnRep";
            this.btnRep.Size = new System.Drawing.Size(75, 41);
            this.btnRep.TabIndex = 27;
            this.btnRep.Text = "导出结果";
            this.btnRep.UseVisualStyleBackColor = true;
            this.btnRep.Click += new System.EventHandler(this.btnRep_Click);
            // 
            // btnClearTxt
            // 
            this.btnClearTxt.Location = new System.Drawing.Point(704, 388);
            this.btnClearTxt.Name = "btnClearTxt";
            this.btnClearTxt.Size = new System.Drawing.Size(27, 70);
            this.btnClearTxt.TabIndex = 28;
            this.btnClearTxt.Text = "清除文本";
            this.btnClearTxt.UseVisualStyleBackColor = true;
            this.btnClearTxt.Click += new System.EventHandler(this.btnClearTxt_Click);
            // 
            // btnGetDuration
            // 
            this.btnGetDuration.Location = new System.Drawing.Point(242, 77);
            this.btnGetDuration.Name = "btnGetDuration";
            this.btnGetDuration.Size = new System.Drawing.Size(78, 23);
            this.btnGetDuration.TabIndex = 29;
            this.btnGetDuration.Text = "获取时长";
            this.btnGetDuration.UseVisualStyleBackColor = true;
            this.btnGetDuration.Click += new System.EventHandler(this.btnGetDuration_Click);
            // 
            // btnCreateImg
            // 
            this.btnCreateImg.Location = new System.Drawing.Point(414, 77);
            this.btnCreateImg.Name = "btnCreateImg";
            this.btnCreateImg.Size = new System.Drawing.Size(63, 23);
            this.btnCreateImg.TabIndex = 30;
            this.btnCreateImg.Text = "生成截图";
            this.btnCreateImg.UseVisualStyleBackColor = true;
            this.btnCreateImg.Click += new System.EventHandler(this.btnCreateImg_Click);
            // 
            // lblProbGetDuration
            // 
            this.lblProbGetDuration.AutoSize = true;
            this.lblProbGetDuration.Location = new System.Drawing.Point(333, 112);
            this.lblProbGetDuration.Name = "lblProbGetDuration";
            this.lblProbGetDuration.Size = new System.Drawing.Size(17, 12);
            this.lblProbGetDuration.TabIndex = 32;
            this.lblProbGetDuration.Text = "0%";
            // 
            // probGetDuration
            // 
            this.probGetDuration.Location = new System.Drawing.Point(242, 106);
            this.probGetDuration.Name = "probGetDuration";
            this.probGetDuration.Size = new System.Drawing.Size(87, 23);
            this.probGetDuration.TabIndex = 31;
            // 
            // lblProbGetScreenshot
            // 
            this.lblProbGetScreenshot.AutoSize = true;
            this.lblProbGetScreenshot.Location = new System.Drawing.Point(505, 112);
            this.lblProbGetScreenshot.Name = "lblProbGetScreenshot";
            this.lblProbGetScreenshot.Size = new System.Drawing.Size(17, 12);
            this.lblProbGetScreenshot.TabIndex = 34;
            this.lblProbGetScreenshot.Text = "0%";
            // 
            // probGetScreenshot
            // 
            this.probGetScreenshot.Location = new System.Drawing.Point(414, 106);
            this.probGetScreenshot.Name = "probGetScreenshot";
            this.probGetScreenshot.Size = new System.Drawing.Size(87, 23);
            this.probGetScreenshot.TabIndex = 33;
            // 
            // MProcessAysn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 470);
            this.Controls.Add(this.lblProbGetScreenshot);
            this.Controls.Add(this.probGetScreenshot);
            this.Controls.Add(this.lblProbGetDuration);
            this.Controls.Add(this.probGetDuration);
            this.Controls.Add(this.btnCreateImg);
            this.Controls.Add(this.btnGetDuration);
            this.Controls.Add(this.btnClearTxt);
            this.Controls.Add(this.btnRep);
            this.Controls.Add(this.lblprobGetFileList);
            this.Controls.Add(this.probGetFileList);
            this.Controls.Add(this.btnGetFiles);
            this.Controls.Add(this.txtDisposeMes);
            this.Controls.Add(this.lblMes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvFileList);
            this.Controls.Add(this.btnSaveFileDire);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSaveFileDire);
            this.Controls.Add(this.btnFileDire);
            this.Controls.Add(this.txtFileDire);
            this.Controls.Add(this.label1);
            this.Name = "MProcessAysn";
            this.Text = "MProcessAysn";
            this.Load += new System.EventHandler(this.MProcessAysn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveFileDire;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSaveFileDire;
        private System.Windows.Forms.Button btnFileDire;
        private System.Windows.Forms.TextBox txtFileDire;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvFileList;
        private System.Windows.Forms.TextBox txtDisposeMes;
        private System.Windows.Forms.Label lblprobGetFileList;
        private System.Windows.Forms.ProgressBar probGetFileList;
        private System.Windows.Forms.Button btnGetFiles;
        private System.Windows.Forms.FolderBrowserDialog fbdBrowser;
        private System.Windows.Forms.Button btnRep;
        private System.Windows.Forms.Button btnClearTxt;
        private System.Windows.Forms.Button btnGetDuration;
        private System.Windows.Forms.Button btnCreateImg;
        private System.Windows.Forms.Label lblProbGetDuration;
        private System.Windows.Forms.ProgressBar probGetDuration;
        private System.Windows.Forms.Label lblProbGetScreenshot;
        private System.Windows.Forms.ProgressBar probGetScreenshot;
    }
}