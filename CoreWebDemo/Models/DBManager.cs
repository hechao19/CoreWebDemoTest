using PWMIS.DataProvider.Adapter;
using PWMIS.DataProvider.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebDemo.DBRule
{
    public abstract class DBManager
    {
        //数据上报业务DB
        //public static AdoHelper db_dataReport = MyDB.GetDBHelperByConnectionName("datareport");
        //卫计委上报库
        public static AdoHelper db_dataReportWJW = MyDB.GetDBHelperByConnectionName("reportWJW");
        //中间库
        //public static AdoHelper db_dataReportTemp = MyDB.GetDBHelperByConnectionName("reportTemp");
    }
}
