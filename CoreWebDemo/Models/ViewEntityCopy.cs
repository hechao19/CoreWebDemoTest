/***************************************************** 
** 命名空间: Fugle.DataReport.Common 
** 文 件 名：ViewEntityCopy 
** 内容简述：实体对象映射类
** 版    本：V1.0 
** 创 建 人：杨佳 
** 创建日期：2017/8/02 09:34:06 
** 修改记录： 
日期        版本      修改人    修改内容    
*****************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWMIS.Core.Extensions;
using System.Collections;

namespace Fugle.DataReport.Common
{   
    /// <summary>
    /// 实体对象映射类
    /// </summary>
    public static  class ViewEntityCopy
    {
        /// <summary>
        ///  类型映射
        /// </summary>
        public static T MapTo<T>(object obj) where T : class, new()
        {
            if (obj == null) return default(T);
            return obj.CopyTo<T>();
        }
        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static List<T> MapToList<T>(this IEnumerable source) where T : class, new()
        {
            List<T> list = new List<T>();
            foreach (var item in source)
            {
                list.Add(item.CopyTo<T>());
            }

            return list;
        }
    }
}
