using PWMIS.DataMap.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebDemo.DBRule
{
    public class DBHelp : DBManager
    {
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="sqlWhere"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageCurrent"></param>
        /// <param name="listCount"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public List<FgSys_BaseConfig> GetBaseConfigList(Dictionary<string, string> sqlWhere, int pageSize, int pageCurrent, ref int listCount, string[] orderBy)
        {
            try
            {                
                FgSys_BaseConfig entity = new FgSys_BaseConfig();

                OQLCompareFunc<FgSys_BaseConfig> cmpFun = (cmp, u) =>
                {
                    OQLCompare cmpResult = null;
                    if (sqlWhere.Keys.Contains("NodeCode") && !string.IsNullOrEmpty(sqlWhere["NodeCode"]))
                    {
                        cmpResult = cmpResult & cmp.Comparer(entity.NodeCode, OQLCompare.CompareType.Like, "%" + sqlWhere["NodeCode"] + "%");
                    }
                    if (sqlWhere.Keys.Contains("NodeDomain") && !string.IsNullOrEmpty(sqlWhere["NodeDomain"]))
                    {
                        cmpResult = cmpResult & cmp.Comparer(entity.NodeDomain, OQLCompare.CompareType.Like, "%" + sqlWhere["NodeDomain"] + "%");
                    }                    

                    return cmpResult;
                };

                OQL query;

                if (orderBy != null)
                {
                    query = OQL.From(entity).Select().Where(cmpFun).OrderBy(orderBy).END;
                }
                else
                {
                    query = OQL.From(entity).Select().Where(cmpFun).OrderBy(new string[1] { "NodeCode asc" }).END;
                }

                if (pageSize != 0 && pageCurrent != 0)
                {
                    //查询总条数
                    OQL qCount = OQL.From(entity).Select().Count(entity.NodeCode, "").Where(cmpFun).END;
                    listCount = Convert.ToInt32(EntityQuery<FgSys_BaseConfig>.QueryObject(qCount, db_dataReportWJW).NodeCode);//总条数

                    //构造分页
                    query.Limit(pageSize, pageCurrent);//分页大小，第几页
                    query.PageWithAllRecordCount = listCount;
                }

                //OQL query = OQL.From(entity).Select().END;

                List<FgSys_BaseConfig> list = EntityQuery<FgSys_BaseConfig>.QueryList(query, db_dataReportWJW);

                return list;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// 查询对象
        /// </summary>
        /// <param name="nodeCode"></param>
        /// <returns></returns>
        public FgSys_BaseConfig GetBaseConfig(string nodeCode)
        {
            try
            {
                FgSys_BaseConfig entity = new FgSys_BaseConfig() { NodeCode = nodeCode };

                if (!string.IsNullOrEmpty(nodeCode))
                {
                    OQL query = OQL.From(entity).Select().Where(entity.NodeCode).END;
                    entity = EntityQuery<FgSys_BaseConfig>.QueryObject(query, db_dataReportWJW);
                }

                return entity;
            }
            catch (Exception err)
            {

                throw err;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="nodeCodes"></param>
        public void DeleteBaseConfigs(string nodeCodes)
        {
            try
            {
                //开始事物
                db_dataReportWJW.BeginTransaction();

                FgSys_BaseConfig entity = new FgSys_BaseConfig();
                string[] nodeCodeArray = nodeCodes.Split(',');

                for (int i = 0; i < nodeCodeArray.Length; i++)
                {
                    OQLCompareFunc<FgSys_BaseConfig> cmpFun = (cmp, u) =>
                    {
                        OQLCompare cmpResult = null;
                        cmpResult = cmpResult & cmp.Comparer(entity.NodeCode, OQLCompare.CompareType.Equal, nodeCodeArray[i]);
                        return cmpResult;
                    };
                    OQL deleteQ = OQL.From(entity).Delete().Where(cmpFun).END;
                    EntityQuery<FgSys_BaseConfig>.ExecuteOql(deleteQ, db_dataReportWJW);
                }

                //提交事物
                db_dataReportWJW.Commit();
            }
            catch (Exception err)
            {
                //回滚事物
                db_dataReportWJW.Rollback();
                throw err;
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="nodeCodes"></param>
        public void UpdateBaseConfig(FgSys_BaseConfig entity)
        {
            try
            {
                OQL updateQ = OQL.From(entity).Delete().Where(entity.NodeCode).END;
                EntityQuery<FgSys_BaseConfig>.ExecuteOql(updateQ, db_dataReportWJW);                
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="nodeCodes"></param>
        public void InsertBaseConfig(FgSys_BaseConfig entity)
        {
            try
            {
                EntityQuery<FgSys_BaseConfig>.Instance.Insert(entity, db_dataReportWJW);
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        #region appinfo

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="sqlWhere"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageCurrent"></param>
        /// <param name="listCount"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public List<Common_AppInfo> GetAppInfoList(Dictionary<string, string> sqlWhere, int pageSize, int pageCurrent, ref int listCount, string[] orderBy)
        {
            try
            {
                Common_AppInfo entity = new Common_AppInfo();

                OQLCompareFunc<Common_AppInfo> cmpFun = (cmp, u) =>
                {
                    OQLCompare cmpResult = null;
                    if (sqlWhere.Keys.Contains("AppName") && !string.IsNullOrEmpty(sqlWhere["AppName"]))
                    {
                        cmpResult = cmpResult & cmp.Comparer(entity.AppName, OQLCompare.CompareType.Like, "%" + sqlWhere["AppName"] + "%");
                    }
                    if (sqlWhere.Keys.Contains("AppCode") && !string.IsNullOrEmpty(sqlWhere["AppCode"]))
                    {
                        cmpResult = cmpResult & cmp.Comparer(entity.AppCode, OQLCompare.CompareType.Like, "%" + sqlWhere["AppCode"] + "%");
                    }

                    return cmpResult;
                };

                OQL query;

                if (orderBy != null)
                {
                    query = OQL.From(entity).Select().Where(cmpFun).OrderBy(orderBy).END;
                }
                else
                {
                    query = OQL.From(entity).Select().Where(cmpFun).OrderBy(new string[1] { "AppSort asc" }).END;
                }

                if (pageSize != 0 && pageCurrent != 0)
                {
                    //查询总条数
                    OQL qCount = OQL.From(entity).Select().Count(entity.AppId, "").Where(cmpFun).END;
                    listCount = Convert.ToInt32(EntityQuery<Common_AppInfo>.QueryObject(qCount, db_dataReportWJW).AppId);//总条数

                    //构造分页
                    query.Limit(pageSize, pageCurrent);//分页大小，第几页
                    query.PageWithAllRecordCount = listCount;
                }

                //OQL query = OQL.From(entity).Select().END;

                List<Common_AppInfo> list = EntityQuery<Common_AppInfo>.QueryList(query, db_dataReportWJW);

                return list;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        #endregion
    }
}
