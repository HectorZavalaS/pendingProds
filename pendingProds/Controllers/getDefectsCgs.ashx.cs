using pendingProds.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace pendingProds.Controllers
{
    /// <summary>
    /// Summary description for getDefectsCgs
    /// </summary>
    public class getDefectsCgs : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            String json = "{";
            String html = "";
            CCogiscanCGS m_server_2 = new CCogiscanCGS();
            try
            {

                DataTable AllModels = m_server_2.getDefectsCGS();
                html += "<option value='ALL'>" + "ALL" + "</option>";
                foreach (DataRow row in AllModels.Rows)
                {
                    html += "<option value='" + row["DEFECT_CODE"] + "'>" + row["DEFECT_CODE"] + " - " + row["DEFECT_DESC"].ToString().Trim().Replace("\"", "'").Replace("\r\n","") + "</option>";
                }

                json += "\"result\":\"true\",";
                json += "\"html\":\"" + html + "\"";
            }
            catch (Exception ex)
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