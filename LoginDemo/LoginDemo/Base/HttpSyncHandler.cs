﻿using LoginDemo.DataModel.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.SessionState;

namespace LoginDemo.Base
{
    public class HttpSyncHandler : IHttpHandler, IRequiresSessionState
    {
        public HttpSyncHandler()
        {
            Stopwatch = new Stopwatch();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        protected HttpRequest Request { get; set; }

        protected HttpResponse Response { get; set; }

        protected DateTime? ReceiveTime { get; set; }

        protected Stopwatch Stopwatch { get; set; }

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                // Assign values.
                this.ReceiveTime = DateTime.Now;
                this.Request = context.Request;
                this.Response = context.Response;

                switch (context.Request.HttpMethod.ToUpper())
                {
                    case "GET":
                        if (BeforeGet(context) == false) break;
                        Get(context);
                        AfterGet(context);
                        break;
                    case "POST":
                        if (BeforePost(context) == false) break;
                        Post(context);
                        AfterPost(context);
                        break;
                    default:
                        throw new Exception("不支持的操作：" + context.Request.HttpMethod);
                }
            }
            catch (Exception ex)
            {
                Logging.Write.Error(ex.Message + ex.StackTrace);
                BadRequest(this.Response, new JsonResponse() { code = RespCode.exception, message = "error" });
            }
        }

        /// <summary>
        /// GET
        /// </summary>
        /// <param name="context"></param>
        protected virtual void Get(HttpContext context)
        {
            this.Response.Write(string.Format("服务'{0}'运行正常。", this.GetType().Name));
        }

        /// <summary>
        /// POST
        /// </summary>
        /// <param name="context"></param>
        protected virtual void Post(HttpContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Before GET
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected virtual bool BeforeGet(HttpContext context)
        {
            return true;
        }

        /// <summary>
        /// After GET
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected virtual void AfterGet(HttpContext context)
        {
        }

        /// <summary>
        /// Before POST
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected virtual bool BeforePost(HttpContext context)
        {
            this.Stopwatch.Restart();
            return true;
        }

        /// <summary>
        /// After POST
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected virtual void AfterPost(HttpContext context)
        {
            this.Stopwatch.Stop();

            Logging.Write.Error("CaseCheckTime:" + this.Stopwatch.ElapsedMilliseconds);
        }

        /// <summary>
        /// OK : 200
        /// </summary>
        /// <param name="response"></param>
        /// <param name="msg"></param>
        protected virtual void OK(HttpResponse response, JsonResponse resp)
        {
            response.StatusCode = (int)HttpStatusCode.OK;
            response.Write(Utility.Serialize(resp));
        }

        /// <summary>
        /// BadRequest : 400
        /// </summary>
        /// <param name="response"></param>
        /// <param name="msg"></param>
        protected virtual void BadRequest(HttpResponse response, JsonResponse resp)
        {
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            response.Write(Utility.Serialize(resp));
        }

        /// <summary>
        /// InternalServerError : 500
        /// </summary>
        /// <param name="response"></param>
        /// <param name="msg"></param>
        protected virtual void InternalServerError(HttpResponse response, JsonResponse resp)
        {
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            response.Write(Utility.Serialize(resp));
        }

        /// <summary>
        /// 取得请求内容
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected virtual string GetReceivedContent(HttpContext context)
        {
            if (context.Request.HttpMethod.ToUpper() != "POST")
                return null;

            //Logging.Write.Error("Request.ContentEncoding:" + context.Request.ContentEncoding);
            //Logging.Write.Error("Request.UserHostAddress:" + context.Request.UserHostAddress);
            //Logging.Write.Error("Request.UserHostName:" + context.Request.UserHostName);

            using (var sr = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
            {
                return sr.ReadToEnd();
            }
        }
    }
}