using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VFP.WinUI
{

    public delegate List<MVideoFile> ReadFileListDelegate(string dirPath, string saveFilePath);

    public delegate void DisposeFileInfoDelegate(List<MVideoFile> list, string saveFilePath = "");


    /// <summary>
    /// 文件处理
    /// </summary>
    public class MVideoFileDispose
    {

        private MProcessAysn _currentMainForm;

        private CutPicture _cup;


        public MVideoFileDispose(MProcessAysn currentMainForm)
        {
            _currentMainForm = currentMainForm;
            _cup = new CutPicture();
        }


        public List<MVideoFile> ReadFileList(string dirPath, string saveFilePath)
        {
            List<MVideoFile> list = new List<MVideoFile>();
            if (string.IsNullOrEmpty(dirPath)) return list;
            List<FileInfo> files = AppHelp.GetFilesOnDire(dirPath, MFileType.Video);
            if (files == null || files.Count == 0) return list;
            MVideoFile mf = null;
            decimal i = 1.0m;
            foreach (var f in files)
            {
                mf = new MVideoFile() { };
                mf.Name = f.Name;
                mf.ExtendName = f.Extension;
                mf.PhysicsPath = f.FullName;
                mf.Size = f.Length;
                mf.IsGenerateScreenShot = File.Exists(saveFilePath + @"\" + f.Name.Substring(0, f.Name.LastIndexOf('.')) + ".jpg");
                list.Add(mf);
                _currentMainForm.InformDisposeProgressInvoke(InformTypeEnum.获取文件, (int)((i / files.Count) * 100));
                i++;
            }
            return list;
        }

    

        private void GenerateScreenshot(List<MVideoFile> list, string saveFilePath)
        {
            if (list == null) return;
            list = list.Where(c => !c.IsGenerateScreenShot).ToList();
            if (list.Count == 0) return;
            decimal i = 1.0m;
            _cup.RegisterProcess(new Process());
            foreach (var mf in list)
            {
                if (mf.Duration <= 0)
                {
                    mf.DurationStr = mf.GetVideoDurationStr(_cup, mf.PhysicsPath);
                }
                mf.ScreenshotsFileName = mf.GetVideoScreenshot(_cup,mf.PhysicsPath, mf.Duration, saveFilePath);
                mf.ScreenshotsFilePhysicsPath = saveFilePath + @"\" + mf.ScreenshotsFileName;
                mf.IsGenerateScreenShot = true;
                _currentMainForm.InformDisposeProgressInvoke(InformTypeEnum.生成视频截图, (int)((i / list.Count) * 100));
                i++;
            }
            _cup.DisposeProcess();
        }

        private void GetDuration(List<MVideoFile> list, string saveFilePath)
        {
            if (list == null) return;
            list = list.Where(c => c.Duration == 0).ToList();
            if (list.Count == 0) return;
            decimal i = 1.0m;
            _cup.RegisterProcess(new Process());
            foreach (var mf in list)
            {
                mf.DurationStr = mf.GetVideoDurationStr(_cup,mf.PhysicsPath);
                _currentMainForm.InformDisposeProgressInvoke(InformTypeEnum.获取视频时长, (int)((i / list.Count) * 100));
                i++;
            }
            _cup.DisposeProcess();
        }


        #region 异步实现

        public IAsyncResult ReadFileListAsync(string dirPath, string saveFilePath, AsyncCallback callback)
        {
            ReadFileListDelegate delegateObj = new ReadFileListDelegate(ReadFileList);
            return delegateObj.BeginInvoke(dirPath, saveFilePath, callback, delegateObj);
        }

        public IAsyncResult GenerateScreenshotAsync(List<MVideoFile> list, string saveFilePath, AsyncCallback callback)
        {
            DisposeFileInfoDelegate delegateObj = new DisposeFileInfoDelegate(GenerateScreenshot);
            return delegateObj.BeginInvoke(list, saveFilePath, callback, delegateObj);
        }

        public IAsyncResult GetDurationAsync(List<MVideoFile> list, AsyncCallback callback)
        {
            DisposeFileInfoDelegate delegateObj = new DisposeFileInfoDelegate(GetDuration);
            return delegateObj.BeginInvoke(list, "", callback, delegateObj);
        }

        #endregion




    }
}
