using pendingProds.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace pendingProds.Controllers
{
    /// <summary>
    /// Summary description for getSubAssyDetail
    /// </summary>
    public class getSubAssyDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            String json = "{";
            try
            {
                String assyName = Convert.ToString(context.Request.Form["assyName"]);
                String numPCBS = Convert.ToString(context.Request.Form["numPCBS"]);
                COracle m_oracle = new COracle("192.168.0.25", "SEMPROD");
                DataTable m_subAssy = m_oracle.getComponentsByAssemName(assyName, numPCBS);


                String htmlHead = "";
                String htmlBody = "";
                String html = "";
                String djgroup = "";
                String COST_ACUM = "";


                String model = "";

                //html += "<section style='width:15%;'>" +
                //    "<div class='squaredOne'>" +
                //    "<input id='check-all' type='checkbox'>" +
                //    "<label for='check-all'></label>" +
                //    "</div>" +
                //    "</section>" +
                //    "<label style='width: 30%;position: absolute;margin-left: 30px;margin-top: -20px;'>Select all</label>";
                html += "<div id='tableSADet'><table id='tableSubADet' class='table display nowrap' style='font-size:11px; width:100%;'>";

                if (m_subAssy != null)
                {
                    htmlHead = "<thead class='tablehead'>";
                    htmlHead += "<tr>";
                    htmlHead += "<th>" +
                                    "<section style='width:15%;'>" +
                                        "<div class='squaredOne'>" +
                                        "<input id='check-all' type='checkbox' checked>" +
                                        "<label for='check-all'></label>" +
                                        "</div>" +
                                    "</section>" +
                                "</th>";
                    htmlHead += "<th>COMPONENT NAME</th>";
                    htmlHead += "<th>QTY</th>";
                    htmlHead += "<th>COST PER UNITY</th>";
                    htmlHead += "<th>COST</th>";
                    htmlHead += "<th>COST_ACUM</th>";
                    htmlHead += "</tr>";
                    htmlHead += "</thead>";

                    //htmlHead += "<tfoot class='tablehead'>";
                    //htmlHead += "<tr>";
                    //htmlHead += "<th>" +
                    //            "</th>";
                    //htmlHead += "<th>COMPONENT NAME</th>";
                    //htmlHead += "<th>QTY</th>";
                    //htmlHead += "<th>COST PER UNITY</th>";
                    //htmlHead += "<th>COST</th>";
                    //htmlHead += "<th>COST_ACUM</th>";
                    //htmlHead += "</tr>";
                    //htmlHead += "</tfoot>";

                    htmlBody += "<tbody>";
                    int i = 1;
                    foreach (DataRow row in m_subAssy.Rows)
                    {
                        String cod_component = row["cod_component"].ToString();
                        String DESCRIPTION = row["DESCRIPTION"].ToString();
                        String COST = row["COST"].ToString();
                        COST_ACUM = row["COST_ACUM"].ToString();
                        htmlBody += "<tr class='tablerows'>";

                        htmlBody += "<td><section>" +
                                        "<div class='squaredOne'> " +
                                            "<input class='checkme' onchange='getTotal(" + i.ToString() + ")' class='form-check-input' type='checkbox' id='check_sub_" + i.ToString() + "' checked>" +
                                            "<label for='check_sub_" + i.ToString() +"'></label>" +
                                        "</div>" +
                                    "</section></td>";
                        htmlBody += "<td style='font-weight:bold;'>" + DESCRIPTION + " - " + cod_component + "</td>";
                        htmlBody += "<td style='font-weight:bold;'><input onchange='updateTotal(" + i.ToString() + ")' id='inputQ_" + i.ToString() + "' type='text' value='" + row["component_quantity"].ToString() + "' class='form-control' /></td>";
                        htmlBody += "<td style='font-weight:bold;'><label id='qty_" + i.ToString() + "'>" + row["unit_price"].ToString() + "</label></td>";
                        //htmlBody += "<td style='font-weight:bold;'><input id='COST_" + i.ToString() + "' type='hidden' value='" + COST + "'>" + COST + "</td>";
                        htmlBody += "<td style='font-weight:bold;'><label id='COST_" + i.ToString() + "'>" + COST + "</label></td>";
                        htmlBody += "<td style='font-weight:bold;'><label id='COST_ACUM_" + i.ToString() + "'>" + COST_ACUM + "</label></td>";
                        htmlBody += "</tr>";
                        i++;
                    }
                    htmlBody += "</tbody>";
                    htmlBody += "<input id='countComp' type='hidden' value='" + i.ToString() + "'>";

                }

                html += htmlHead + htmlBody + "</table></div>";
                html += "<hr/>";

                html += "<div style='float:right;background-color:light-gray;'>"
                        + "    <label class='lblHigh'>TOTAL: </label>"
                        + "    <label class='lblHigh' id='lblTotal'>" + COST_ACUM + "</label>" 
                        + "</div>";
                html += "<div style='clear: both;'></div>";
                html += "<hr/>";

                html += "<div style='float:right;'>";
                html += "<button id='btnCancel' type='button' class='btn btn-warning' style='margin-right:15px;'>Cancel</button>";
                html += "<button id='btnOK' type='button' class='btn btn-success'>OK</button>";
                html += "<div style='clear: both;'></div>";
                html += "</div>";
                html += "<div style='clear: both;'></div>";

                json += "\"result\":\"true\",";
                json += "\"html\":\"" + html + "\"";
            }
            catch (Exception ex) {
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