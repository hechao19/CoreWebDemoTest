using System;
using System.Collections.Generic;

namespace CoreWebDemo.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class Test1
    {
        public int id { get; set; }
        public string name { get; set; }
        public string idx { get; set; }

        public List<Test1> test1List { get; set; }
    }

    /// <summary>
    /// 菜单信息表
    /// </summary>
    public class MenuInfo
    {
        /// <summary>
        /// 主键，唯一ID
        /// </summary>
        public System.String MenuID { get; set; }

        /// <summary>
        /// 关联AppInfo表AppID
        /// </summary>
        public System.String AppID { get; set; }

        /// <summary>
        /// 数据为0时为根节点
        /// </summary>
        public System.String MenuPID { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public System.String MenuName { get; set; }

        /// <summary>
        /// 菜单，详情页
        /// </summary>
        public System.String MenuType { get; set; }

        /// <summary>
        /// 菜单代码
        /// </summary>
        public System.String MenuCode { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public System.String MenuIcon { get; set; }

        /// <summary>
        /// 菜单排序
        /// </summary>
        public System.Int32? MenuSort { get; set; }

        /// <summary>
        /// 站内程序APPID，关联AppInfo表AppID
        /// </summary>
        public System.String FromAppID { get; set; }

        /// <summary>
        /// 菜单URL
        /// </summary>
        public System.String MenuUrl { get; set; }

        /// <summary>
        /// 菜单路径
        /// </summary>
        public System.String MenuPath { get; set; }

        /// <summary>
        /// 0：本身   1：站内   2：外站
        /// </summary>
        public System.Int32? CallWay { get; set; }

        /// <summary>
        /// 语种名称1
        /// </summary>
        public System.String LanguageName1 { get; set; }

        /// <summary>
        /// 语种名称2
        /// </summary>
        public System.String LanguageName2 { get; set; }

        /// <summary>
        /// 关联OperatorInfo表OperatorID
        /// </summary>
        public System.Int32? OperatorID { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public System.DateTime? OperatorTime { get; set; }

        /// <summary>
        /// 0：不传   1：传   
        /// </summary>
        public System.Int32 IsParameter { get; set; }

        /// <summary>
        /// 0：无效   1：有效 
        /// </summary>
        public System.Int32 Status { get; set; }

        
    }

    /// <summary>
    /// 菜单权限类
    /// </summary>
    public class AuthMenuInfo
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        public System.String MenuID { get; set; }

        /// <summary>
        /// 父级菜单ID,  一级菜单的时候为0
        /// </summary>
        public System.String MenuPID { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public System.String MenuName { get; set; }

        /// <summary>
        /// 菜单类型 （菜单，详情页）
        /// </summary>
        public System.String MenuType { get; set; }

        /// <summary>
        /// 菜单代码
        /// </summary>
        public System.String MenuCode { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public System.String MenuIcon { get; set; }

        /// <summary>
        /// 菜单排序
        /// </summary>
        public System.Int32 MenuSort { get; set; }

        /// <summary>
        /// 菜单URL
        /// </summary>
        public System.String MenuUrl { get; set; }

        /// <summary>
        /// 菜单路径（可作为域名路径存放，有域名的时候是外链）
        /// </summary>
        public System.String MenuPath { get; set; }

        /// <summary>
        /// 调用方式
        /// </summary>
        public System.String CallWay { get; set; }

        /// <summary>
        /// 站内程序APPID，关联AppInfo表AppID
        /// </summary>
        public System.String FromAppID { get; set; }

        /// <summary>
        /// 子元素集合
        /// </summary>
        public List<AuthMenuInfo> Children { get; set; }
        
        /// <summary>
        /// 是否拥有权限
        /// </summary>
        public Boolean IsHaveAuthority { get; set; }

    }
}