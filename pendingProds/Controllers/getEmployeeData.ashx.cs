using Newtonsoft.Json;
using pendingProds.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace pendingProds.Controllers
{
    /// <summary>
    /// Summary description for getEmployeeData
    /// </summary>
    public class getEmployeeData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            String payroll_id = Convert.ToString(context.Request.Form["payroll"]);
            string json = "{";
            try
            {
                var httpWebRequest = (System.Net.HttpWebRequest)WebRequest.Create("http://192.168.3.45:8555/hr/userstress");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string parameters = "{" +
                                  "\"data\":" +
                                    "{" +
                                            "\"attributes\":" +
                                             "{" +
                                                    "\"payroll\":" + payroll_id +
                                            "}" +
                                    "}" +
                                  "}";
                    streamWriter.Write(parameters);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var result = "";
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                Data employee = JsonConvert.DeserializeObject<Data>(result);
                json += "\"result\":\"true\",";
                json += "\"position\":\"" + employee.data.First().attributes.position_description_es + "\",";
                json += "\"department\":\"" + employee.data.First().attributes.department_description_es + "\",";
                json += "\"area\":\"" + employee.data.First().attributes.area_description_es + "\"";
            }
            catch(Exception ex)
            {
                json += "\"result\":\"false\",";
                json += "\"MessageError\":\"" + ex.Message + "\"";
            }
            json += "}";

            context.Response.ContentType = "text/plain";
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}