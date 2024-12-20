using pendingProds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pendingProds.Controllers
{
    /// <summary>
    /// Summary description for getDefects
    /// </summary>
    public class getDefects : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            String json = "{";
            String html = "";
            siixsem_scrap_dbEntities m_db = new siixsem_scrap_dbEntities();
            try
            {

                var AllModels = m_db.getModFailures();
                foreach (getModFailures_Result row in AllModels)
                {
                    html += "<option value='" + row.se_id + "'>" + row.se_description + "</option>";
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