using pendingProds.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace pendingProds.Controllers
{
    /// <summary>
    /// Summary description for getPQCReport
    /// </summary>
    public class getPQCReport : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            String json = "{";
            try
            {
                String PRODUCT_PN = Convert.ToString(context.Request.Form["PRODUCT_PN"]);
                String DEFECT_CODE = Convert.ToString(context.Request.Form["DEFECT_CODE"]);
                String EVENT_DATE = Convert.ToString(context.Request.Form["EVENT_DATE"]);
                String EVENT_DATE_FIN = Convert.ToString(context.Request.Form["EVENT_DATE_FIN"]);
                CCogiscanCGSDW m_db_serv_11 = new CCogiscanCGSDW();

                String[] fecha = EVENT_DATE.Split('/');
                EVENT_DATE = string.Format("{0:00}", fecha[2]) + "-" + string.Format("{0:00}", fecha[0]) + "-" + string.Format("{0:00}", fecha[1]); 

                fecha = EVENT_DATE_FIN.Split('/');
                EVENT_DATE_FIN = string.Format("{0:00}", fecha[2]) + "-" + string.Format("{0:00}", fecha[0]) + "-" + string.Format("{0:00}", fecha[1]);


                DataTable m_Report = m_db_serv_11.getPQCReport(PRODUCT_PN,DEFECT_CODE,EVENT_DATE, EVENT_DATE_FIN);

                String htmlHead = "";
                String htmlBody = "";
                String html = "";


                if (m_Report != null)
                {
                    html += "<table id='tableDefects' class='table stripe display nowrap' style='width:100%;font-size:11px;margin-top:20px;'>";
                    htmlHead = "<thead>";
                    htmlHead += "<tr>";
                    htmlHead += "<th>MODELO</th>";
                    htmlHead += "<th>SERIAL</th>";
                    htmlHead += "<th>FECHA</th>";
                    htmlHead += "<th>DEFECTO</th>";
                    htmlHead += "<th>USUARIO</th>";
                    htmlHead += "<th>SESION</th>";
                    htmlHead += "</tr>";
                    htmlHead += "</thead>";

                    htmlBody += "<tbody>";
                    foreach (DataRow row in m_Report.Rows)
                    {
                        htmlBody += "<tr>";
                        htmlBody += "<td style='color:blue;font-weight:bold;'>" + row["PRODUCT_PN"] + "</td>";
                        htmlBody += "<td style='font-weight:bold;'>" + row["PRODUCT_ID"] + "</td>";
                        htmlBody += "<td style='font-weight:bold;'>" + row["EVENT_TMST"] + "</td>";
                        htmlBody += "<td style='font-weight:bold;'>" + row["DEFECT_CODE"].ToString().Replace("\r\n", "").Trim() + "</td>";
                        htmlBody += "<td style='font-weight:bold;'>" + row["USER_ID"] + "</td>";
                        htmlBody += "<td style='font-weight:bold;'>" + row["SESION"] + "</td>";
                        htmlBody += "</tr>";
                    }
                    htmlBody += "</tbody>";

                    html += htmlHead + htmlBody + "</table>";

                    json += "\"result\":\"true\",";
                    json += "\"html\":\"" + html + "\"";
                }
                else
                {
                    json += "\"result\":\"false\",";
                    json += "\"messageError\":\"" + "No se encontrron resultados para la consulta." + "\"";
                }
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