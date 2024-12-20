using pendingProds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pendingProds.Controllers
{
    /// <summary>
    /// Descripción breve de getSecLoc
    /// </summary>
    public class getSecLoc : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            String json = "{";
            String html = "";
            siixsem_scrap_dbEntities m_db = new siixsem_scrap_dbEntities();
            try
            {

                var secLocs = m_db.getSectorLocations();
                foreach (getSectorLocations_Result row in secLocs)
                {
                    html += "<option value='" + row.se_id_sector + "'>" + row.se_description + "</option>";
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