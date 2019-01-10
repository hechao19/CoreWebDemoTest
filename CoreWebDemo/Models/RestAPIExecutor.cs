/***************************************************** 
** 命名空间: Fugle.Public.Common
** 文 件 名：RedisKey 
** 内容简述：redis 缓存信息维护类
** 版    本：V1.0.0
** 创 建 人： 许四光
** 创建日期：2018/7/31 17:47:48 
** 修改记录： 
日期        版本      修改人    修改内容    
*****************************************************/

using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebDemo.Common
{
    public class RestAPIExecutor
    {
        /// <summary>
        /// 接口基地址 格式：http://www.xxx.com/
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// 默认的时间参数格式
        /// </summary>
        public string DefaultDateParameterFormat { get; set; }

        /// <summary>
        /// 默认验证器
        /// </summary>
        public IAuthenticator DefaultAuthenticator { get; set; }

        /// <summary>
        /// 调用客户端
        /// </summary>
        private RestClient client;

        public RestAPIExecutor(string baseURI, IAuthenticator authenticator = null, string DateParameterFormat = null)
        {
            BaseUrl = baseURI;
            DefaultAuthenticator = authenticator;
            client = new RestClient(BaseUrl);

            if (DefaultAuthenticator != null)
                client.Authenticator = DefaultAuthenticator;

            if (DateParameterFormat != null)
                DefaultDateParameterFormat = DateParameterFormat;
        }

        /// <summary>
        /// 返回内容
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IRestResponse Execute(RestRequest request)
        {
            //request.DateFormat = string.IsNullOrEmpty(DefaultDateParameterFormat) ? "yyyy-MM-dd HH:mm:ss" : DefaultDateParameterFormat;
            var response = client.Execute(request);
            return response;
        }
        /// <summary>
        /// 返回对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public T Execute<T>(RestRequest request) where T : new()
        {
            //request.DateFormat = string.IsNullOrEmpty(DefaultDateParameterFormat) ? "yyyy-MM-dd HH:mm:ss" : DefaultDateParameterFormat;
            var response = client.Execute<T>(request);
            return response.Data;
        }

        /// <summary>
        /// 异步调用 返回
        /// </summary>
        /// <param name="request"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public RestRequestAsyncHandle ExecuteAsync(IRestRequest request, Action<IRestResponse> action)
        {
            //request.DateFormat = string.IsNullOrEmpty(DefaultDateParameterFormat) ? "yyyy-MM-dd HH:mm:ss" : DefaultDateParameterFormat;
            return client.ExecuteAsync(request, action);
        }

        /// <summary>
        /// 异步调用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public RestRequestAsyncHandle ExecuteAsync<T>(RestRequest request, Action<IRestResponse<T>> action) where T : new()
        {
            //request.DateFormat = string.IsNullOrEmpty(DefaultDateParameterFormat) ? "yyyy-MM-dd HH:mm:ss" : DefaultDateParameterFormat;
            return client.ExecuteAsync<T>(request, action);
        }

        /// <summary>
        /// 异步任务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<T> GetTaskAsync<T>(RestRequest request) where T : new()
        {
            //request.DateFormat = string.IsNullOrEmpty(DefaultDateParameterFormat) ? "yyyy-MM-dd HH:mm:ss" : DefaultDateParameterFormat;
            return client.GetTaskAsync<T>(request);
        }


        /// <summary>
        /// 下载数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public byte[] DownloadData(RestRequest request)
        {
            return client.DownloadData(request);
        }
    }
}
