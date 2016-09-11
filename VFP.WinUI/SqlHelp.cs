using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFP.WinUI
{
    public static class SqlHelp
    {
        private static  readonly string ConnStr = ConfigurationManager.ConnectionStrings["ies_resourceconn"].ConnectionString;


        public static int ExecuteNonQuery(string cmdText,SqlParameter[] para)
        {
            try
            {
                using (var conn =new SqlConnection(ConnStr))
                {
                   conn.Open();
                   using (var cmd = new SqlCommand(cmdText,conn))
                   {
                       if (para != null)
                           cmd.Parameters.AddRange(para);
                        return 1; // cmd.ExecuteNonQuery();
                   }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
