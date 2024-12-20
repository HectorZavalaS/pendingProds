using pendingProds.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace pendingProds.Controllers
{
    /// <summary>
    /// Summary description for updateCosts
    /// </summary>
    public class updateCosts : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            String json = "{";
            try
            {
                String assemName = Convert.ToString(context.Request.Form["assemName"]);
                String cost = Convert.ToString(context.Request.Form["cost"]);
                String html = "";
                int result = 0;

                siixsem_scrap_dbEntities m_dbScrap = new siixsem_scrap_dbEntities();

                result = m_dbScrap.updateAssemCost(assemName,Convert.ToDouble(cost)).First().RESULT;
                var costs = m_dbScrap.calculateCostAcum();

                foreach (calculateCostAcum_Result c in costs)
                {
                    json += "\"linkSeq"+c.LINKAGE_SEQ.ToString()+"\":\""+ c.LINKAGE_SEQ.ToString() + "\",";
                    json += "\"cost_" + c.LINKAGE_SEQ.ToString() + "\":\"" + c.COST.ToString() + "\",";
                    json += "\"costA_" + c.LINKAGE_SEQ.ToString() + "\":\"" + c.COSTA_ACUM.ToString() + "\",";
                }

                json += "\"result\":\"true\",";
                json += "\"html\":\"" + html + "\"";
            }
            catch (Exception ex) { }
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