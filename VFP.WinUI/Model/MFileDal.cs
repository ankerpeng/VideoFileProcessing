using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFP.WinUI
{

    public delegate void UpdateVideoDurationDelegate(List<MVideoFile> list);

    public class MFileDal
    {
        //更新视频时长
        public bool UpdateVideoDuration(MVideoFile ent)
        {
            if (ent.IsSaveData) return true;
            try
            {

                /*
                 DELETE ies_resource.dbo.FileTimeLength WHERE FileName=@FileName; 
insert into dbo.FileTimeLength(  [FileName] , TimeLength )  
 values (@FileName , @TimeLength);
                 */
                string cmdText = @"
update ies_resource.dbo.[file] 
set TimeLength=@TimeLength where filename=@FileName;
";
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@FileName",ent.Name),
                    new SqlParameter("@TimeLength",ent.Duration)
                };
                SqlHelp.ExecuteNonQuery(cmdText, para);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //更新视频时长
        public void UpdateVideoDuration(List<MVideoFile> list)
        {
            if (list == null || list.Count == 0) return;
            foreach (var item in list)
            {
                if (!item.IsSaveData && item.Duration > 0)
                {
                    UpdateVideoDuration(item);
                    item.IsSaveData = true;
                }

            }
        }

        public IAsyncResult UpdateVideoDurationAsync(List<MVideoFile> list,AsyncCallback callback)
        {
            UpdateVideoDurationDelegate delegateObj = new UpdateVideoDurationDelegate(UpdateVideoDuration);
            return delegateObj.BeginInvoke(list, callback, delegateObj);
        }
    }
}
