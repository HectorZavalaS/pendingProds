using pendingProds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pendingProds.Controllers
{
    /// <summary>
    /// Summary description for getDetCat
    /// </summary>
    public class getDetCat : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            String json = "{";
            String html = "";
            siixsem_scrap_dbEntities m_db = new siixsem_scrap_dbEntities();
            int m_id_cat = Convert.ToInt32(context.Request.Form["id_cat"]);

            try
            {
                var AllModels = m_db.getCatDetail(m_id_cat);
                foreach (getCatDetail_Result row in AllModels)
                {
                    html += "<option value='" + row.ID + "'>" + row.DESCRIPTION + "</option>";
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