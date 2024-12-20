using pendingProds.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;

namespace pendingProds.Controllers
{
    /// <summary>
    /// Summary description for getSubAssy
    /// </summary>
    public class getSubAssy : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            String json = "{";
            try
            {
                String djGroup = Convert.ToString(context.Request.Form["djGroup"]);
                String numPCBS = Convert.ToString(context.Request.Form["numPCBS"]);
                String PAIR_FG_NAME = "";
                COracle m_oracle = new COracle("192.168.0.25", "SEMPROD");
                DataTable m_subAssy = null;
                string b = string.Empty;

                try
                {
                    int temp = int.Parse(djGroup);
                }
                catch(Exception ex)
                {
                    for (int i = 0; i < djGroup.Length; i++)
                    {
                        if (Char.IsDigit(djGroup[i]))
                            b += djGroup[i];
                        else
                            break;
                    }

                    if (b.Length > 0)
                        djGroup = b;
                }

                m_subAssy = m_oracle.getSubAssy(djGroup,numPCBS);

                String htmlHead = "";
                String htmlBody = "";
                String html = "";
                String djgroup = "";
                String partN = "";
                int count = 0;


                String model = "";

                html += "<table id='tableSubA' class='table stripe display' style='width:100%;font-size:11px;'>";

                if (m_subAssy != null)
                {
                    htmlHead = "<thead>";
                    htmlHead += "<tr>";
                    htmlHead += "<th>Selection</th>";
                    htmlHead += "<th>ASSEMBLY NAME</th>";
                    htmlHead += "<th>ASSEMBLY DESCRIPTION</th>";
                    htmlHead += "<th>WIP ENTITY NAME</th>";
                    htmlHead += "<th>COST</th>";
                    htmlHead += "<th>COST_ACUM</th>";

                    htmlHead += "</tr>";
                    htmlHead += "</thead>";

                    htmlBody += "<tbody>";
                    int i = 0;
                    count = m_subAssy.Rows.Count;
                    foreach (DataRow row in m_subAssy.Rows)
                    {
                        String LINKAGE_SEQ = row["LINKAGE_SEQ"].ToString();
                        String ASSEMBLY_NAME = row["ASSEMBLY_NAME"].ToString();
                        Double COST = Convert.ToDouble(row["COST"]);
                        PAIR_FG_NAME = row["PAIR_FG_NAME"].ToString();
                        htmlBody += "<tr>";
                        htmlBody += "<td>" +
                                    "<section>" +
                                        "<div class='form-check'> " +
                                            "<input class='form-check-input' type='radio' name='radio_sub' id='radio_sub_" + LINKAGE_SEQ + "' value="+ LINKAGE_SEQ + ">" +
                                        "</div>" +
                                   "</section>" +
                                    "</td>";
                        if(COST > 0)
                            htmlBody += "<td style='font-weight:bold;'><a href='#' onclick='getDetailSubA(" + LINKAGE_SEQ + ");return;' ><label id='assemName_" + LINKAGE_SEQ + "'>" + ASSEMBLY_NAME + "</label></a></td>";
                        else
                            htmlBody += "<td style='font-weight:bold;'><label id='assemName_" + LINKAGE_SEQ + "'>" + ASSEMBLY_NAME + "</label></td>";
                        htmlBody += "<td style='font-weight:bold;'><label id='assemDesc_" + LINKAGE_SEQ + "'>" + row["ASSEMBLY_DESC"] + "</label></td>";
                        htmlBody += "<td style='font-weight:bold;'><label id='wipEnt_" + LINKAGE_SEQ + "'>" + row["WIP_ENTITY_NAME"] + "</label></td>";
                        htmlBody += "<td style='font-weight:bold;'><label id='mainCost_" + LINKAGE_SEQ + "'>" + row["COST"] + "</label></td>";
                        htmlBody += "<td style='font-weight:bold;'><label id='mainCostA_" + LINKAGE_SEQ + "'>" + row["COST_ACUM"] + "</label></td>";
                        htmlBody += "</tr>";
                        i++;
                    }
                    htmlBody += "</tbody>";
                }


                html += htmlHead + htmlBody + "</table>";
                json += "\"result\":\"true\",";
                json += "\"count\":\""+ count.ToString() +"\",";
                json += "\"pair_fg\":\"" + PAIR_FG_NAME + "\",";
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