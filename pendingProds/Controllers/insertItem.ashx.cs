using pendingProds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pendingProds.Controllers
{
    /// <summary>
    /// Summary description for insertItem
    /// </summary>
    public class insertItem : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            String json = "{";
            try {
                String serial = Convert.ToString(context.Request.Form["serial"]);
                String djGroup = Convert.ToString(context.Request.Form["djGroup"]);
                String assem = Convert.ToString(context.Request.Form["assem"]);
                String assemDesc = Convert.ToString(context.Request.Form["assemDesc"]);
                String wipEnt = Convert.ToString(context.Request.Form["wipEnt"]);
                String bin = Convert.ToString(context.Request.Form["bin"]);
                Double cost = Convert.ToDouble(context.Request.Form["cost"]);
                String userKey = Convert.ToString(context.Request.Form["userKey"]);
                int idDefect = Convert.ToInt32(context.Request.Form["idDefect"]);
                String origin = Convert.ToString(context.Request.Form["origin"]);
                String model = Convert.ToString(context.Request.Form["model"]);
                String loc = Convert.ToString(context.Request.Form["loc"]);
                String pair_fg = Convert.ToString(context.Request.Form["pair_fg"]);

                siixsem_scrap_dbEntities m_db = new siixsem_scrap_dbEntities();

                int result = m_db.insert_item(serial, djGroup, assem, assemDesc,wipEnt, bin, cost, userKey,idDefect,origin,model,loc, pair_fg).First().RESULT;
                if (result == 1)
                {
                    json += "\"result\":\"true\"";
                }
                else
                {
                    json += "\"MessageError\":\"El serial ya se dio de alta.\",";
                    json += "\"result\":\"false\"";
                }
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