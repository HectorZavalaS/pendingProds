using pendingProds.Class;
using pendingProds.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace pendingProds.Controllers
{
    /// <summary>
    /// Summary description for getModels
    /// </summary>
    public class getModels : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            String json = "{";
            String html = "";
            siixsem_scrap_dbEntities m_db = new siixsem_scrap_dbEntities();
            CCogiscanCGS m_server_2 = new CCogiscanCGS();
            try
            {

                DataTable AllModels = m_server_2.getModels();
                html += "<option value='ALL'>" + "ALL" + "</option>";
                foreach (DataRow row in AllModels.Rows)
                {
                    html += "<option value='" + row["PRODUCT_PN"] + "'>" + row["PRODUCT_PN"] + "</option>";
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