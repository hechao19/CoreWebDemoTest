
/* 
 使用前请先在项目工程中引用 PWMIS.Core.dll
 2017/11/9 11:01:11
*/

using System;
using PWMIS.Common;
using PWMIS.DataMap.Entity;
using System.Configuration;

namespace CoreWebDemo.DBRule
{
  [Serializable()]
  public partial class FgSys_BaseConfig : EntityBase
  {
    public FgSys_BaseConfig()
    {
            TableName = "FgSys_BaseConfig";
            if (ConfigurationManager.AppSettings["Schema"] == "1")
            {
                Schema="";
            }
            EntityMap=EntityMapType.Table;
            //IdentityName = "标识字段名";

            //PrimaryKeys.Add("主键字段名"); 
    PrimaryKeys.Add("NodeCode");

            
    }


      protected override void SetFieldNames()
      {
           PropertyNames = new string[] { "NodeType","NodeCode","NodeDomain" };
      }



      /// <summary>
      /// 节点类型
      /// </summary>
      public System.String NodeType
      {
          get{return getProperty<System.String>("NodeType");}
          set{setProperty("NodeType",value ,20);}
      }

      /// <summary>
      /// 节点代码
      /// </summary>
      public System.String NodeCode
      {
          get{return getProperty<System.String>("NodeCode");}
          set{setProperty("NodeCode",value ,20);}
      }

      /// <summary>
      /// 节点值域
      /// </summary>
      public System.String NodeDomain
      {
          get{return getProperty<System.String>("NodeDomain");}
          set{setProperty("NodeDomain",value ,50);}
      }


  }
}
