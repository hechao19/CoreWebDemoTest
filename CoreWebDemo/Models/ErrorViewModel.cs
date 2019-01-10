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
    /// �˵���Ϣ��
    /// </summary>
    public class MenuInfo
    {
        /// <summary>
        /// ������ΨһID
        /// </summary>
        public System.String MenuID { get; set; }

        /// <summary>
        /// ����AppInfo��AppID
        /// </summary>
        public System.String AppID { get; set; }

        /// <summary>
        /// ����Ϊ0ʱΪ���ڵ�
        /// </summary>
        public System.String MenuPID { get; set; }

        /// <summary>
        /// �˵�����
        /// </summary>
        public System.String MenuName { get; set; }

        /// <summary>
        /// �˵�������ҳ
        /// </summary>
        public System.String MenuType { get; set; }

        /// <summary>
        /// �˵�����
        /// </summary>
        public System.String MenuCode { get; set; }

        /// <summary>
        /// �˵�ͼ��
        /// </summary>
        public System.String MenuIcon { get; set; }

        /// <summary>
        /// �˵�����
        /// </summary>
        public System.Int32? MenuSort { get; set; }

        /// <summary>
        /// վ�ڳ���APPID������AppInfo��AppID
        /// </summary>
        public System.String FromAppID { get; set; }

        /// <summary>
        /// �˵�URL
        /// </summary>
        public System.String MenuUrl { get; set; }

        /// <summary>
        /// �˵�·��
        /// </summary>
        public System.String MenuPath { get; set; }

        /// <summary>
        /// 0������   1��վ��   2����վ
        /// </summary>
        public System.Int32? CallWay { get; set; }

        /// <summary>
        /// ��������1
        /// </summary>
        public System.String LanguageName1 { get; set; }

        /// <summary>
        /// ��������2
        /// </summary>
        public System.String LanguageName2 { get; set; }

        /// <summary>
        /// ����OperatorInfo��OperatorID
        /// </summary>
        public System.Int32? OperatorID { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public System.DateTime? OperatorTime { get; set; }

        /// <summary>
        /// 0������   1����   
        /// </summary>
        public System.Int32 IsParameter { get; set; }

        /// <summary>
        /// 0����Ч   1����Ч 
        /// </summary>
        public System.Int32 Status { get; set; }

        
    }

    /// <summary>
    /// �˵�Ȩ����
    /// </summary>
    public class AuthMenuInfo
    {
        /// <summary>
        /// �˵�ID
        /// </summary>
        public System.String MenuID { get; set; }

        /// <summary>
        /// �����˵�ID,  һ���˵���ʱ��Ϊ0
        /// </summary>
        public System.String MenuPID { get; set; }

        /// <summary>
        /// �˵�����
        /// </summary>
        public System.String MenuName { get; set; }

        /// <summary>
        /// �˵����� ���˵�������ҳ��
        /// </summary>
        public System.String MenuType { get; set; }

        /// <summary>
        /// �˵�����
        /// </summary>
        public System.String MenuCode { get; set; }

        /// <summary>
        /// �˵�ͼ��
        /// </summary>
        public System.String MenuIcon { get; set; }

        /// <summary>
        /// �˵�����
        /// </summary>
        public System.Int32 MenuSort { get; set; }

        /// <summary>
        /// �˵�URL
        /// </summary>
        public System.String MenuUrl { get; set; }

        /// <summary>
        /// �˵�·��������Ϊ����·����ţ���������ʱ����������
        /// </summary>
        public System.String MenuPath { get; set; }

        /// <summary>
        /// ���÷�ʽ
        /// </summary>
        public System.String CallWay { get; set; }

        /// <summary>
        /// վ�ڳ���APPID������AppInfo��AppID
        /// </summary>
        public System.String FromAppID { get; set; }

        /// <summary>
        /// ��Ԫ�ؼ���
        /// </summary>
        public List<AuthMenuInfo> Children { get; set; }
        
        /// <summary>
        /// �Ƿ�ӵ��Ȩ��
        /// </summary>
        public Boolean IsHaveAuthority { get; set; }

    }
}