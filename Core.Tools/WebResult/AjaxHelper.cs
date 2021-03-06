﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core.Tools.WebResult
{
    //所有Ajax都要返回这个类型的对象
    public class AjaxHelper
    {
        public static JsonResult JsonResult(HttpStatusCode statusCode, string msg, object data = null)
        {
            var result = new AjaxResult
            {
                StatusCode = statusCode,
                Msg = msg,
                Data = data
            };
            var settings = new JsonSerializerSettings //新的实例
            {
                //忽略循环引用，如果设置为Error，则遇到循环引用的时候报错（建议设置为Error，这样更规范）
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                //获取日期System.DateTime和System.DateTimeOffset值的格式在json化是的格式
                DateFormatString = "yyyy/MM/dd HH:mm",
                //json中属性开头字母小写的驼峰命名
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()//实例化newtonsoft类
            };
            //返回状态码,提示，数据,以及json序列化设置
            return new JsonResult(result, settings);
        }

        public static JsonResult MvcJsonResult(HttpStatusCode statusCode, string msg, object data)
        {
            var result = new AjaxResult
            {
                StatusCode = statusCode,
                Msg = msg,
                Data = data
            };
            return new JsonNetResult { Value = result };
        }

        public class AjaxResult
        {
            /// <summary>
            /// 状态码
            /// </summary>
            public HttpStatusCode StatusCode { get; set; }

            /// <summary>
            /// 消息
            /// </summary>
            public string Msg { get; set; }

            /// <summary>
            /// 执行返回的数据
            /// </summary>
            public object Data { get; set; }
        }
    }
}
