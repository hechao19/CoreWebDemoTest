﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreWebDemo.Models;
using CoreWebDemo.DBRule;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using RestSharp;
using CoreWebDemo.Common;
using System.Reflection;
using System.Globalization;
using System.ComponentModel;

namespace CoreWebDemo.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, reloadOnChange: true);
            Configuration = builder.Build();
        }

        public static IConfiguration Configuration { get; set; }               
        
        public IActionResult About()
        {
            try
            {
                //Dictionary<string, string> sqlWhere = new Dictionary<string, string>();
                //int listCount=0;
                //var dateList = DBHelp.GetAppInfoList(sqlWhere, 0, 0, ref listCount, null);
            }
            catch (Exception err)
            {
            }
           

            return View();
        }
        
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult TestAjax()
        {
            try
            {
                var configDefaule = Configuration.GetSection("Logging:LogLevel:Default").Value;
                var configDefaule1 = Configuration["Logging:LogLevel:Default"];

                Configuration["Logging:LogLevel:Default"] = "1";
            }
            catch (Exception err)
            {
            }


            return View();
        }

        #region 页面

        public IActionResult Index()
        {
            try
            {


                //var builder = new ConfigurationBuilder()
                //    .SetBasePath(Directory.GetCurrentDirectory())
                //    .AddJsonFile("appsettings.json");

                //Configuration = builder.Build();
            }
            catch (Exception err)
            {

            }

            return View();
        }

        public IActionResult EditBaseConfig()
        {
            try
            {
                var nodeCode = "";
                if (!string.IsNullOrEmpty(Request.Query["nodeCode"]))
                {
                    nodeCode = Request.Query["nodeCode"];
                }

                ViewData["NodeCode"] = nodeCode;
            }
            catch (Exception err)
            {

            }

            return View();
        }

        #endregion

        #region 方法

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <returns></returns>
        public string GetBaseConfigList()
        {
            try
            {
                var DBHelp = new DBHelp();

                string nodeCode = Request.Form["nodeCode"];
                string nodeDomain = Request.Form["nodeDomain"];

                int pageSize = 0, pageCurrent = 0, listCount = 0;
                if (!string.IsNullOrEmpty(Request.Form["pageSize"]))
                {
                    pageSize = Convert.ToInt32(Request.Form["pageSize"]);
                }
                if (!string.IsNullOrEmpty(Request.Form["pageCurrent"]))
                {
                    pageCurrent = Convert.ToInt32(Request.Form["pageCurrent"]);
                }

                Dictionary<string, string> sqlWhere = new Dictionary<string, string>();
                sqlWhere.Add("NodeCode", nodeCode);
                sqlWhere.Add("NodeDomain", nodeDomain);

                var dateList = DBHelp.GetBaseConfigList(sqlWhere, pageSize, pageCurrent, ref listCount, null);
                var returnJson = new { total = listCount, rows = dateList };

                return JsonConvert.SerializeObject(returnJson);
            }
            catch (Exception err)
            {
                //记录错误日志
                //Log4NetHelp.Error("", err);
                return "{\"Message\":\"1\",\"ErrorCode\":\"系统错误\"}";
            }
        }

        /// <summary>
        /// 查询对象
        /// </summary>
        /// <returns></returns>
        public string GetBaseConfig()
        {
            try
            {
                var DBHelp = new DBHelp();

                string nodeCode = Request.Form["nodeCode"];

                var baseConfig = DBHelp.GetBaseConfig(nodeCode);
                                
                return JsonConvert.SerializeObject(baseConfig);
            }
            catch (Exception err)
            {
                //记录错误日志
                //Log4NetHelp.Error("", err);
                return "{\"Message\":\"1\",\"ErrorCode\":\"系统错误\"}";
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public string DeleteBaseConfigs()
        {
            try
            {
                string nodeCodes = Request.Form["nodeCodes"];
                if (!string.IsNullOrEmpty(nodeCodes))
                {

                }

                return "{\"Message\":true}";
            }
            catch (Exception err)
            {
                return "{\"Message\":\"1\",\"ErrorCode\":\"系统错误\"}";
            }
        }

        //修改
        public string UpdateBaseConfig()
        {
            try
            {
                string nodeCode = Request.Form["NodeCode"];
                string nodeDomain = Request.Form["NodeDomain"];

                return "{\"Message\":true}";
            }
            catch (Exception err)
            {
                return "{\"Message\":\"1\",\"ErrorCode\":\"系统错误\"}";
            }
        }

        //新增
        public string AddBaseConfig()
        {
            try
            {
                string nodeCode = Request.Form["NodeCode"];
                string nodeDomain = Request.Form["NodeDomain"];

                return "{\"Message\":true}";
            }
            catch (Exception err)
            {
                return "{\"Message\":\"1\",\"ErrorCode\":\"系统错误\"}";
            }
        }

        public void TestOracle()
        {
            //Create a connection to Oracle 如何在没有SQL配置文件的情况下连接到Oracle DB
            string conString = "Data Source=ORCL28;User Id=c##FGCDRPUB;Password=111;";

            //如何用DB别名连接到Oracle DB。 How to connect to an Oracle DB with a DB alias.  
            //下面和上面的评论/注释 Uncomment below and comment above.  
            //数据源<服务名称别名> "Data Source=<service name alias>;";  
            using (OracleConnection con = new OracleConnection(conString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.BindByName = true;

                        //Use the command to display employee names from   
                        // the EMPLOYEES table  
                        cmd.CommandText = "select * from AppInfo where AppId <> :id";

                        // Assign id to the department number 50   
                        OracleParameter id = new OracleParameter("id", "1");
                        cmd.Parameters.Add(id);

                        //Execute the command and use DataReader to display the data  
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            //await context.Response.WriteAsync("Employee First Name: " + reader.GetString(0) + "\n");  

                        }

                        reader.Dispose();
                    }

                    catch (Exception ex)
                    {
                        //await context.Response.WriteAsync(ex.Message);  

                    }

                }
            }
        }

        #endregion

        [HttpPost]
        public string PostList(List<Test1> list)
        {
            try
            {
                RestAPIExecutor defaultAPIExecutor = new RestAPIExecutor("http://localhost:19479/");

                // 调用WebApi获取拥有权限菜单和功能列表数据
                var request = new RestRequest("api/UserManage/UpdateUserPwd", Method.POST);
                request.AddParameter("list", list);
                var response = defaultAPIExecutor.Execute(request);

                return "{\"Message\":1,\"ReturnState\":True}";
            }
            catch (Exception err)
            {

                return "{\"Message\":\"错误\",\"ReturnState\":false}";
            }
        }

        public void TestUpdateEntity()
        {
            try
            {
                var menuInfo = new AuthMenuInfo();
                var entityInfo= new AuthMenuInfo() { MenuID="111111"};
                var entityType = menuInfo.GetType();
                var entityProperties = entityType.GetProperties().Where(x => x.PropertyType.IsPublic && x.CanWrite);

                foreach (var item in entityProperties)
                {
                    if (Request.Query[item.Name].Count > 0)
                    {
                        item.SetValue(menuInfo, TypeConversion.To(Request.Query[item.Name].ToString(), item.PropertyType, CultureInfo.InvariantCulture));
                    }
                    else
                    {
                        item.SetValue(menuInfo, item.GetValue(entityInfo));
                    }
                }

                //MenuInfo nc = new MenuInfo();
                //Type t = nc.GetType();
                //object obj = Activator.CreateInstance(t);
                ////取得ID字段 
                //FieldInfo fi = t.GetField("ID");
                ////给ID字段赋值 
                //fi.SetValue(obj, "k001");
                ////取得MyName属性 
                //PropertyInfo pi1 = t.GetProperty("MyName");
                ////给MyName属性赋值 
                //pi1.SetValue(obj, "grayworm", null);
                //PropertyInfo pi2 = t.GetProperty("MyInfo");
                //pi2.SetValue(obj, "hi.baidu.com/grayworm", null);
                ////取得show方法 
                //MethodInfo mi = t.GetMethod("show");
                ////调用show方法 
                //mi.Invoke(obj, null);
            }
            catch (Exception err)
            {
                
            }
        }
        
        public void TestUpdateEntity1()
        {
            try
            {
                if (Request.Query["id"].Count <= 0)
                {

                }
                else
                {

                }
                
                //var entity = new MenuInfo();
                //entity.MenuID = "12345678";

                //var a = Mapper<MenuInfo, AuthMenuInfo>.Map(entity);
            }
            catch (Exception err)
            {

            }
        }
    }
}
