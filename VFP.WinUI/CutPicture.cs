using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFP.WinUI
{
    public class CutPicture
    {
        private string _ffmpegPath;


        /// <summary>
        /// 已默认配置ffmpeg工具路径
        /// </summary>
        public CutPicture()
        {
            _ffmpegPath = AppDomain.CurrentDomain.BaseDirectory + "Config\\ffmpeg.exe";
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ffmpegfullPath">ffmpeg工具路径</param>
        public CutPicture(string ffmpegfullPath)
        {
            _ffmpegPath = ffmpegfullPath;
        }


        /// <summary>
        /// 捕获图片
        /// </summary>
        /// <param name="videofullPath">视屏路径</param>
        /// <param name="savePicFullPath">保存的图片路径</param>
        /// <param name="picWidth">图片宽度</param>
        /// <param name="picHeight">图片高度</param>
        /// <param name="frameNumber">捕获的帧数(秒)</param>
        /// <returns></returns>
        public string Cut(string videofullPath, string savePicFullPath, int picWidth, int picHeight, float frameNumber)
        {
            string result = string.Empty;
            if (!File.Exists(_ffmpegPath) || !File.Exists(videofullPath))
            {
                return "ffmpeg is not find or video is not find!";
            }

            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(_ffmpegPath);
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            //此处组合成ffmpeg.exe文件需要的参数即可,此处命令在ffmpeg 0.4.9调试通过 
            string FlvImgSize = picWidth.ToString() + "x" + picHeight.ToString();
            startInfo.Arguments = " -i " + videofullPath + " -y -f image2 -ss " + frameNumber + " -t 0.001  -s " + FlvImgSize + " " + savePicFullPath;

            try
            {
                System.Diagnostics.Process.Start(startInfo);
            }
            catch (Exception e)
            {
                result = "start error: " + e.Message;
            }

            return result;
        }

        public string GetVideoDuration(string sourceFile)
        {
            using (System.Diagnostics.Process ffmpeg = new System.Diagnostics.Process())
            {
                String duration;  // soon will hold our video's duration in the form "HH:MM:SS.UU"
                String result;  // temp variable holding a string representation of our video's duration
                StreamReader errorreader;  // StringWriter to hold output from ffmpeg

                ffmpeg.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                ffmpeg.StartInfo.CreateNoWindow = true;

                // we want to execute the process without opening a shell
                ffmpeg.StartInfo.UseShellExecute = false;
                //ffmpeg.StartInfo.ErrorDialog = false;
                ffmpeg.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                // redirect StandardError so we can parse it
                // for some reason the output comes through over StandardError
                ffmpeg.StartInfo.RedirectStandardError = true;

                // set the file name of our process, including the full path
                // (as well as quotes, as if you were calling it from the command-line)
                ffmpeg.StartInfo.FileName = _ffmpegPath;

                // set the command-line arguments of our process, including full paths of any files
                // (as well as quotes, as if you were passing these arguments on the command-line)
                ffmpeg.StartInfo.Arguments = "-i " + sourceFile;

                // start the process
                ffmpeg.Start();

                // now that the process is started, we can redirect output to the StreamReader we defined
                errorreader = ffmpeg.StandardError;

                // wait until ffmpeg comes back
                ffmpeg.WaitForExit();

                // read the output from ffmpeg, which for some reason is found in Process.StandardError
                result = errorreader.ReadToEnd();

                // a little convoluded, this string manipulation...
                // working from the inside out, it:
                // takes a substring of result, starting from the end of the "Duration: " label contained within,
                // (execute "ffmpeg.exe -i somevideofile" on the command-line to verify for yourself that it is there)
                // and going the full length of the timestamp

                duration = result.Substring(result.IndexOf("Duration: ") + ("Duration: ").Length, ("00:00:00").Length);
                return duration;
            }
        }



    }
}
