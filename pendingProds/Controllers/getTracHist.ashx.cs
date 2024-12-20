using pendingProds.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace pendingProds.Controllers
{
    /// <summary>
    /// Summary description for getTracHist
    /// </summary>
    public class getTracHist : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            String json = "{";
            try
            {
                String serial = Convert.ToString(context.Request.Form["serial"]);
                COracle m_oracle = new COracle("192.168.0.25", "SEMPROD");
                CCogiscanCGSDW m_db_serv_11 = new CCogiscanCGSDW();
                DataTable m_history = m_db_serv_11.getTracHistory(serial);
                CCogiscanCGS m_db_serv2 = new CCogiscanCGS();
                DataTable bines = null;

                String htmlHead = "";
                String htmlBody = "";
                String html = "";
                String djgroup = "";
                String partN = "";


                String model = "";



                if (m_history != null)
                {
                    html += "<table id='tableHist' class='table stripe display' style='width:100%;font-size:11px;'>";
                    htmlHead = "<thead>";
                    htmlHead += "<tr>";
                    //foreach (DataColumn dc in m_history.Columns)
                    //htmlHead += "<th>BATCH_ID</th>";
                    //htmlHead += "<th>PRODUCT_PN</th>";
                    htmlHead += "<th>PRODUCT_ID</th>";
                    htmlHead += "<th>OPERATION_NAME</th>";
                    htmlHead += "<th>TOOL_ID</th>";
                    htmlHead += "</tr>";
                    htmlHead += "</thead>";

                    htmlBody += "<tbody>";
                    foreach (DataRow row in m_history.Rows)
                    {
                        djgroup = row["BATCH_ID"].ToString();
                        partN = row["PRODUCT_PN"].ToString().Replace("\r","").Replace("\n","");
                        htmlBody += "<tr>";
                        //htmlBody += "<td style='font-weight:bold;'>" + row["BATCH_ID"] + "</td>";
                        //htmlBody += "<td style='font-weight:bold;'>" + row["PRODUCT_PN"] + "</td>";
                        htmlBody += "<td style='color:blue;font-weight:bold;'>" + row["PRODUCT_ID"] + "</td>";
                        htmlBody += "<td style='font-weight:bold;'>" + row["OPERATION_NAME"] + " " + row["ROUTE_STEP_DESC"] + "</td>";
                        htmlBody += "<td style='font-weight:bold;'>" + row["TOOL_ID"] + "</td>";
                        //htmlBody += "<td style='font-weight:bold;'>" + row["ROUTE_NAME"] + "</td>";
                        htmlBody += "</tr>";
                    }
                    htmlBody += "</tbody>";

                    html += htmlHead + htmlBody + "</table>";

                    CModelInfo modelInf = m_db_serv2.getInfoModel(partN);
                    string b = string.Empty;

                    try
                    {
                        int temp = int.Parse(djgroup);
                    }
                    catch (Exception ex)
                    {
                        for (int i = 0; i < djgroup.Length; i++)
                        {
                            if (Char.IsDigit(djgroup[i])) b += djgroup[i];
                            else break;
                        }
                        if (b.Length > 0) djgroup = b;
                    }
                    bines = m_oracle.getBinByDJGroup(djgroup);
                    String strBin = "";

                    if (bines != null)
                    {
                        foreach (DataRow bin in bines.Rows)
                            strBin += bin["BIN"].ToString() + " - ";
                         strBin = strBin.Substring(0, strBin.Length - 3);
                         strBin = strBin.Replace(" - N/A","");
                    }
                    else strBin = "N/A";

                    json += "\"result\":\"true\",";
                    json += "\"djgroup\":\"" + djgroup + "\",";
                    json += "\"partN\":\"" + partN + "\",";
                    json += "\"bin\":\"" + strBin + "\",";
                    json += "\"numPCBS\":\"" + modelInf.NUMBER_BOARDS.ToString() + "\",";
                    json += "\"html\":\"" + html + "\"";
                }
                else
                {
                    json += "\"result\":\"false\",";
                    json += "\"messageError\":\"" + "No se encontro historial de la PCB en COGISCAN." + "\"";
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