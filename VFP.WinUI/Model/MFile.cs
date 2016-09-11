using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFP.WinUI
{
    public class MFile
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 物理路径
        /// </summary>
        public string PhysicsPath { get; set; }

        /// <summary>
        /// 大小(byte)
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// 文件扩展名（如：.txt 字符）
        /// </summary>
        public string ExtendName { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public MFileType MFileType
        {
            get
            {
                if (string.IsNullOrEmpty(ExtendName))
                {
                    return MFileType.None;
                }
                return AppHelp.GetMFileType(ExtendName);
            }
        }

    }

    public enum MFileType
    {
        /// <summary>
        /// 无
        /// </summary>
        None = 0,
        /// <summary>
        /// 视频
        /// </summary>
        Video = 1,
        /// <summary>
        /// 音频
        /// </summary>
        Voice = 2,
        /// <summary>
        /// 文档
        /// </summary>
        Document = 3
    }

    /// <summary>
    /// 视频文件
    /// </summary>
    public class MVideoFile : MFile
    {
        /// <summary>
        /// 时长
        /// </summary>
        public int Duration 
        { 
            get 
            {
                if (!string.IsNullOrWhiteSpace(DurationStr))
                {
                    TimeSpan r = new TimeSpan();
                    TimeSpan.TryParse(DurationStr,out r);
                    return (int)r.TotalSeconds;
                }
                else return 0;
            } 
            set { } 
        }

        /// <summary>
        /// 时长 00:00:00
        /// </summary>
        public string DurationStr { get; set; }

        /// <summary>
        /// 是否生成截图
        /// </summary>
        public bool IsGenerateScreenShot { get; set; }

        /// <summary>
        /// 截图文件名称(jpg格式)
        /// </summary>
        public string ScreenshotsFileName { get; set; }

        public string ScreenshotsFilePhysicsPath { get; set; }

        /// <summary>
        /// 是否保存数据入库
        /// </summary>
        public bool IsSaveData { get; set; }

    }

    public static class MVideoFileExt
    {
        public static string GetVideoDurationStr(this MVideoFile vf, CutPicture cutp, string fileNamePath)
        {
            string vDuration = "";
            try
            {
                vDuration = cutp.GetVideoDuration(fileNamePath);
            }
            catch
            {
            }
            return vDuration;
        }

      

        public static string GetVideoScreenshot(this MVideoFile vf, CutPicture cutp, string fileNamePath, int videoDuration, string saveDire)
        {
            string videoScreenshot = string.Empty;
            string filetitle = System.IO.Path.GetFileNameWithoutExtension(fileNamePath);
            string sFileNew = saveDire + "\\" + filetitle + ".jpg";
            if (File.Exists(sFileNew))
                return filetitle + ".jpg"; //若存在直接返回文件名称
            try
            {
                if (videoDuration > 60)
                    cutp.Cut(fileNamePath, sFileNew, 400, 300, 60.001f);
                else
                    cutp.Cut(fileNamePath, sFileNew, 400, 300, 1.001f);
            }
            catch (Exception e)
            {
            }
            return filetitle + ".jpg";
        }


    }


}
