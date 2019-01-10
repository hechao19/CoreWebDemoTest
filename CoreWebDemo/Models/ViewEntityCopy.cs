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

using System.ComponentModel;
using System.Globalization;

namespace CoreWebDemo.Common
{
    /// <summary>
    /// 实体对象映射类
    /// </summary>
    public static class ViewEntityCopy
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

    /// <summary>
    /// 通用类型转换
    /// </summary>
    public class TypeConversion
    {
        /// <summary>
        /// 类型转换
        /// </summary>
        /// <param name="value">要转换的值</param>
        /// <param name="destinationType">转换的目标类型</param>
        /// <returns></returns>
        public static object To(object value, Type destinationType)
        {
            return To(value, destinationType, CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// 类型转换
        /// </summary>
        /// <param name="value">要转换的值</param>
        /// <param name="destinationType">转换的目标类型</param>
        /// <param name="culture">区域信息</param>
        /// <returns></returns>
        public static object To(object value, Type destinationType, CultureInfo culture)
        {
            if (value != null)
            {
                var sourceType = value.GetType();

                var destinationConverter = TypeDescriptor.GetConverter(destinationType);
                if (destinationConverter != null && destinationConverter.CanConvertFrom(value.GetType()))
                    return destinationConverter.ConvertFrom(null, culture, value);

                var sourceConverter = TypeDescriptor.GetConverter(sourceType);
                if (sourceConverter != null && sourceConverter.CanConvertTo(destinationType))
                    return sourceConverter.ConvertTo(null, culture, value, destinationType);

                if (destinationType.IsEnum && value is int)
                    return Enum.ToObject(destinationType, (int)value);

                if (!destinationType.IsInstanceOfType(value))
                    return Convert.ChangeType(value, destinationType, culture);
            }
            return value;
        }
        /// <summary>
        /// 类型转换
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="value">要转换的值</param>
        /// <returns></returns>
        public static T To<T>(object value)
        {
            return (T)To(value, typeof(T));
        }
    }
}
