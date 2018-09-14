
/* 
 使用前请先在项目工程中引用 PWMIS.Core.dll
 2015/11/30 13:34:47
*/

using System;
using PWMIS.Common;
using PWMIS.DataMap.Entity;
using System.Configuration;

namespace CoreWebDemo.DBRule
{
  [Serializable()]
  public partial class Common_AppInfo : EntityBase
  {
    public Common_AppInfo()
    {
            TableName = "AppInfo";
            if (ConfigurationManager.AppSettings["Schema"] == "1")
            {
                Schema="Common";
            }
            EntityMap=EntityMapType.Table;
            //IdentityName = "标识字段名";

            //PrimaryKeys.Add("主键字段名");
    PrimaryKeys.Add("AppId");

            
    }


      protected override void SetFieldNames()
      {
          PropertyNames = new string[] { "AppId", "AuthorityId", "AppName", "AppCode", "AppType", "DevelopCompany", "AppPath", "AppHomePage", "AppIcon", "AppSort", "InputCode1", "InputCode2", "LanguageName1", "LanguageName2", "OperatorId", "OperatorTime", "IsShow", "Status", "SingleValidateUrl" };
      }



      /// <summary>
      /// 程序ID
      /// </summary>
      public System.String AppId
      {
          get{return getProperty<System.String>("AppId");}
          set{setProperty("AppId",value ,36);}
      }

      /// <summary>
      /// 权限ID
      /// </summary>
      public System.String AuthorityId
      {
          get{return getProperty<System.String>("AuthorityId");}
          set{setProperty("AuthorityId",value ,36);}
      }

      /// <summary>
      /// 程序名称
      /// </summary>
      public System.String AppName
      {
          get{return getProperty<System.String>("AppName");}
          set{setProperty("AppName",value ,80);}
      }

      /// <summary>
      /// 程序代码
      /// </summary>
      public System.String AppCode
      {
          get{return getProperty<System.String>("AppCode");}
          set{setProperty("AppCode",value ,80);}
      }

      /// <summary>
      /// 程序类型
      /// </summary>
      public System.String AppType
      {
          get{return getProperty<System.String>("AppType");}
          set{setProperty("AppType",value ,30);}
      }

      /// <summary>
      /// 开发公司
      /// </summary>
      public System.String DevelopCompany
      {
          get{return getProperty<System.String>("DevelopCompany");}
          set{setProperty("DevelopCompany",value ,80);}
      }

      /// <summary>
      /// 程序路径（作为域名存放,该程序下的菜单沿用这里的域名）
      /// </summary>
      public System.String AppPath
      {
          get{return getProperty<System.String>("AppPath");}
          set{setProperty("AppPath",value ,100);}
      }

      /// <summary>
      /// 程序主页
      /// </summary>
      public System.String AppHomePage
      {
          get{return getProperty<System.String>("AppHomePage");}
          set{setProperty("AppHomePage",value ,255);}
      }

      /// <summary>
      /// 程序图标
      /// </summary>
      public System.String AppIcon
      {
          get{return getProperty<System.String>("AppIcon");}
          set{setProperty("AppIcon",value ,80);}
      }

      /// <summary>
      /// 排序号
      /// </summary>
      public System.Int32 AppSort
      {
          get{return getProperty<System.Int32>("AppSort");}
          set{setProperty("AppSort",value );}
      }

      /// <summary>
      /// 输入码1
      /// </summary>
      public System.String InputCode1
      {
          get{return getProperty<System.String>("InputCode1");}
          set{setProperty("InputCode1",value ,18);}
      }

      /// <summary>
      /// 输入码2
      /// </summary>
      public System.String InputCode2
      {
          get{return getProperty<System.String>("InputCode2");}
          set{setProperty("InputCode2",value ,18);}
      }

      /// <summary>
      /// 语种名称1
      /// </summary>
      public System.String LanguageName1
      {
          get{return getProperty<System.String>("LanguageName1");}
          set{setProperty("LanguageName1",value ,80);}
      }

      /// <summary>
      /// 语种名称2
      /// </summary>
      public System.String LanguageName2
      {
          get{return getProperty<System.String>("LanguageName2");}
          set{setProperty("LanguageName2",value ,80);}
      }

      /// <summary>
      /// 操作人ID
      /// </summary>
      public System.Int32 OperatorId
      {
          get{return getProperty<System.Int32>("OperatorId");}
          set{setProperty("OperatorId",value );}
      }

      /// <summary>
      /// 操作时间
      /// </summary>
      public System.DateTime OperatorTime
      {
          get{return getProperty<System.DateTime>("OperatorTime");}
          set{setProperty("OperatorTime",value );}
      }

      /// <summary>
      /// 是否显示
      /// </summary>
      public System.String IsShow
      {
          get { return getProperty<System.String>("IsShow"); }
          set { setProperty("IsShow", value); }
      }

      /// <summary>
      /// 状态：1有效 0无效
      /// </summary>
      public System.Int32 Status
      {
          get{return getProperty<System.Int32>("Status");}
          set{setProperty("Status",value );}
      }

      /// <summary>
      /// 单点验证路径
      /// </summary>
      public System.String SingleValidateUrl
      {
          get { return getProperty<System.String>("SingleValidateUrl"); }
          set { setProperty("SingleValidateUrl", value); }
      }
  }
}
