using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VFP.WinUI
{

    public enum InformTypeEnum
    {
        获取文件,
        获取视频时长,
        生成视频截图
    }

    public partial class MProcessAysn : Form
    {
        public MProcessAysn()
        {
            InitializeComponent();
        }

        #region 属性

        MFileDal _dal = new MFileDal();

        MVideoFileDispose _fileDispose;

        public static string _NewLine = System.Environment.NewLine;

        private List<MVideoFile> MVideoFileList
        {
            get
            {
                if (dgvFileList.DataSource != null) return dgvFileList.DataSource as List<MVideoFile>;
                return new List<MVideoFile>();
            }
            set
            {

            }
        }


        /// <summary>
        /// 文件保存目录
        /// </summary>
        private string SaveFileDirePath
        {
            get
            {
                if (Directory.Exists(txtSaveFileDire.Text))
                    return txtSaveFileDire.Text;
                else
                    return string.Empty;
            }
        }

        /// <summary>
        /// 文件目录
        /// </summary>
        private string DirePath
        {
            get
            {
                if (Directory.Exists(txtFileDire.Text))
                    return txtFileDire.Text;
                else
                    return string.Empty;
            }
        }



        #endregion

        #region 方法


        private void BindDgvFileList(List<MVideoFile> fileList)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    dgvFileList.DataSource = null;
                    dgvFileList.DataSource = fileList;
                }));
            }
            else
            {
                dgvFileList.DataSource = null;
                dgvFileList.DataSource = fileList;
            }
        }

        private void SetLableMess(string mess, bool setTime = false)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    lblMes.Text = mess + (setTime ? DateTime.Now.ToString(" yyyy-MM-dd HH:mm:ss.fff") : ""); ;
                    txtDisposeMes.Text += lblMes.Text + _NewLine;
                }));
            }
            else
            {
                lblMes.Text = mess + (setTime ? DateTime.Now.ToString(" yyyy-MM-dd HH:mm:ss.fff") : "");
                txtDisposeMes.Text += lblMes.Text + _NewLine;
            }
        }


        //设置进度条值
        private void SetProgressBar(ProgressBar pb, Label pbLbl, int value)
        {

            pb.Value = value;
            pbLbl.Text = value + " %";
        }


        /// <summary>
        /// 通知更新进度条
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void InformDisposeProgressInvoke(InformTypeEnum type, int value)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                switch (type)
                {
                    case InformTypeEnum.获取文件:
                        SetProgressBar(probGetFileList, lblprobGetFileList, value);
                        break;
                    case InformTypeEnum.生成视频截图:
                        SetProgressBar(probGetScreenshot, lblProbGetScreenshot, value);
                        break;
                    case InformTypeEnum.获取视频时长:
                        SetProgressBar(probGetDuration, lblProbGetDuration, value);
                        break;
                }
            }));
        }



        #endregion


        #region 事件

        private void MProcessAysn_Load(object sender, EventArgs e)
        {
            _fileDispose = new MVideoFileDispose(this);
        }


        private void btnFileDire_Click(object sender, EventArgs e)
        {
            if (fbdBrowser.ShowDialog() == DialogResult.OK)
            {
                txtFileDire.Text = fbdBrowser.SelectedPath;
                if (string.IsNullOrWhiteSpace(SaveFileDirePath))
                {
                    txtSaveFileDire.Text = txtFileDire.Text;
                }
            }
        }

        private void btnSaveFileDire_Click(object sender, EventArgs e)
        {
            if (fbdBrowser.ShowDialog() == DialogResult.OK)
            {
                txtSaveFileDire.Text = fbdBrowser.SelectedPath;
            }
        }

        private void btnRep_Click(object sender, EventArgs e)
        {
            if (MVideoFileList == null || MVideoFileList.Count == 0) return;
            Workbook workbook;
            Worksheet sheet;
            DataTable dt;
            new Func<bool>(() =>
            {
                SetLableMess("---开始导出任务---", true);
                workbook = new Workbook();
                sheet = (Worksheet)workbook.Worksheets[0];
                dt = DataTableMExtensions.ToDataTable(MVideoFileList);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sheet.Cells[0, i].PutValue(dt.Columns[i].ColumnName);
                }
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    for (int c = 0; c < dt.Columns.Count; c++)
                    {
                        sheet.Cells[r + 1, c].PutValue(dt.Rows[r][c].ToString());
                    }
                }
                workbook.Save(SaveFileDirePath + string.Format(@"\导出结果{0}.xlsx", DateTime.Now.ToString("yyyyMMdd")), SaveFormat.Xlsx);
                SetLableMess("【导出完成!】", true);
                return true;

            }).Invoke();
        }

        //获取文件
        private void btnGetFiles_Click(object sender, EventArgs e)
        {

            SetLableMess("---开始获取文件---", true);
            try
            {
                _fileDispose.ReadFileListAsync(DirePath, SaveFileDirePath, new AsyncCallback((result) =>
                {
                    if (result.IsCompleted)
                    {
                        var delegateSource = result.AsyncState as ReadFileListDelegate;
                        if (delegateSource != null)
                        {
                            var dataResult = delegateSource.EndInvoke(result);
                            if (dataResult != null)
                            {
                                BindDgvFileList(dataResult);
                                string mes = string.Format("【文件获取完成，文件总数{0}个,待生成截图:{1}】", dataResult.Count, dataResult.Where(c => !c.IsGenerateScreenShot).Count());
                                SetLableMess(mes, true);
                            }
                        }
                    }
                }));
            }
            catch (Exception ex)
            {
                SetLableMess(string.Format("【获取文件发生异常:{0}】", ex.Message), true);
            }
            
        }

        //获取视频时长
        private void btnGetDuration_Click(object sender, EventArgs e)
        {
            SetLableMess("---开始获取视频时长---", true);
            try
            {
                _fileDispose.GetDurationAsync(MVideoFileList, new AsyncCallback((result) =>
                {
                    if (result.IsCompleted)
                    {
                        var delegateSource = result.AsyncState as DisposeFileInfoDelegate;
                        if (delegateSource != null)
                        {
                            delegateSource.EndInvoke(result);
                            BindDgvFileList(MVideoFileList);
                            SetLableMess("【获取视频时长任务已完成！】", true);
                        }
                    }
                }));
            }
            catch (Exception ex)
            {
                SetLableMess(string.Format("【获取视频时长发生异常:{0}】", ex.Message), true);
            }
           
        }

        //获取截图
        private void btnCreateImg_Click(object sender, EventArgs e)
        {
            SetLableMess("---开始生成视频截图---", true);
            try
            {
                _fileDispose.GenerateScreenshotAsync(MVideoFileList, SaveFileDirePath, new AsyncCallback((result) =>
                {
                    if (result.IsCompleted)
                    {
                        var delegateSource = result.AsyncState as DisposeFileInfoDelegate;
                        if (delegateSource != null)
                        {
                            delegateSource.EndInvoke(result);
                            BindDgvFileList(MVideoFileList);
                            SetLableMess("【生成视频截图任务已完成！】", true);
                        }
                    }
                }));
            }
            catch (Exception ex)
            {
                SetLableMess(string.Format("【生成视频截图发生异常:{0}】", ex.Message), true);
            }
           
        }

        private void btnClearTxt_Click(object sender, EventArgs e)
        {
            txtDisposeMes.Text = string.Empty;
        }


        #endregion

        public delegate void UpdateDb();

        private void btnUpdateDb_Click(object sender, EventArgs e)
        {
            SetLableMess("---开始写入数据库---", true);
            try
            {
                _dal.UpdateVideoDurationAsync(MVideoFileList, new AsyncCallback((result) =>
                {
                    if (result.IsCompleted)
                    {
                        var delegateSource = result.AsyncState as UpdateVideoDurationDelegate;
                        if (delegateSource != null)
                        {
                            delegateSource.EndInvoke(result);
                            BindDgvFileList(MVideoFileList);
                            SetLableMess("【写入数据库任务已完成！】", true);
                        }
                    }
                }));
            }
            catch (Exception ex)
            {

                SetLableMess(string.Format("【写入数据库发生异常:{0}】",ex.Message), true);
            }
            
        }
    }




}
