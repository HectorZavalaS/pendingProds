using Newtonsoft.Json;
using pendingProds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace pendingProds.Controllers
{
    /// <summary>
    /// Summary description for getEmpList
    /// </summary>
    public class getEmpList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            String html = "";
            String json = "{";
            try { 
            var responseBody = Get_employyesAsync();
            Data employees = JsonConvert.DeserializeObject<Data>(responseBody.Result);
            foreach (Employee row in employees.data)
            {
                html += "<option value='" + row.id + "'>" + row.id + " - "+ row.attributes.full_name + "</option>";
            }
            json += "\"result\":\"true\",";
            json += "\"html\":\"" + html + "\"";
            }
            catch (Exception ex) {
                json += "\"result\":\"false\",";
                json += "\"MessageError\":\"" + ex.Message + "\"";
            }
            json += "}";
            context.Response.ContentType = "text/plain";
            context.Response.Write(json);
        }
        public async Task<string> Get_employyesAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://192.168.3.45:8555/hr/userstress").ConfigureAwait(continueOnCapturedContext: false);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody.ToString();
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