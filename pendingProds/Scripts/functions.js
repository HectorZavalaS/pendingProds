function getVirtDir() {
    var Path = location.host;
    var VirtualDirectory;
    if (Path.indexOf("localhost") >= 0 && Path.indexOf(":") >= 0) {
        VirtualDirectory = "";

    }
    else {
        var pathname = window.location.pathname;
        var VirtualDir = pathname.split('/');
        VirtualDirectory = VirtualDir[1];
        VirtualDirectory = '/' + VirtualDirectory;
    }
    return VirtualDirectory;
}
function validateEnter(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla === 13) {
        if ($("#inputUser").val() == "")
            alertW("<div class='window-content' style='color:orange;font-weight:bold;'>Debes escribir un número de serie.</div>");
        else {
            $("#serial").val($("#inputUser").val());
            existCurWeek();
//            getHist($("#inputUser").val());
        }
        return true;
    } else {
        return false;
    }
}
function alertS(mensaje) {
    BootstrapDialog.alert({
        message: mensaje,
        type: BootstrapDialog.TYPE_SUCCESS, // <-- Default value is BootstrapDialog.TYPE_PRIMARY
        closable: true, // <-- Default value is false
        draggable: true, // <-- Default value is false
        buttonLabel: 'Aceptar' // <-- Default value is 'OK',

    });
}

function alertE(mensaje) {
    BootstrapDialog.alert({
        message: mensaje,
        type: BootstrapDialog.TYPE_DANGER, // <-- Default value is BootstrapDialog.TYPE_PRIMARY
        closable: true, // <-- Default value is false
        draggable: true, // <-- Default value is false
        buttonLabel: 'Aceptar' // <-- Default value is 'OK',

    });
}

function alertW(mensaje) {
    BootstrapDialog.alert({
        message: mensaje,
        type: BootstrapDialog.TYPE_WARNING, // <-- Default value is BootstrapDialog.TYPE_PRIMARY
        closable: true, // <-- Default value is false
        draggable: true, // <-- Default value is false
        buttonLabel: 'Aceptar' // <-- Default value is 'OK',

    });
}
function alertI(mensaje) {
    BootstrapDialog.alert({
        message: mensaje,
        type: BootstrapDialog.TYPE_INFO, // <-- Default value is BootstrapDialog.TYPE_PRIMARY
        closable: true, // <-- Default value is false
        draggable: true, // <-- Default value is false
        buttonLabel: 'Aceptar' // <-- Default value is 'OK',

    });
}
function createSelect(id) {
    $(id).attr('data-live-search', true);
    $(id).attr('data-size', '10');
    $(id).attr('data-live-search-style', 'contains');
    $(id).attr('data-style', 'btn-info');
    //$(id).css('width', '100%');
    $(id).selectpicker();
}
function updateSelect(id) {
    $(id).addClass('selectpicker');
    $(id).attr('data-live-search', true);
    $(id).attr('data-size', '10');
    $(id).attr('data-live-search-style', 'contains');
    $(id).attr('data-style', 'btn-info');
    $(id).selectpicker('refresh');
}

function getDefects() {
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/getDefects.ashx",
        success: function (data) {
            r = jQuery.parseJSON(data);
            if (r.result === "true") {
                $("#defects").html(r.html);
                createSelect("#defects");

            }
            //unblock();
            return false;
        },
        error: function () { }
    });
}

function getCategories() {
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/getCategories.ashx",
        success: function (data) {
            r = jQuery.parseJSON(data);
            if (r.result === "true") {
                $("#categories").html(r.html);
                createSelect("#categories");
                $("#categories").change(function () {

                    //alert($("#categories").val());
                    getDetCat($("#categories").val());
                    
                });

            }
            //unblock();
            return false;
        },
        error: function () { }
    });
}

function getDetCat(id_cat) {
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/getDetCat.ashx",
        data: { id_cat : id_cat },
        success: function (data) {
            r = jQuery.parseJSON(data);
            if (r.result === "true") {
                $("#defects").html("");
                $("#defects").html(r.html);
                $("#defects").re
                createSelect("#defects");
                updateSelect("#defects");

            }
            //unblock();
            return false;
        },
        error: function () { }
    });
}

function getSecLoc() {
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/getSecLoc.ashx",
        success: function (data) {
            r = jQuery.parseJSON(data);
            if (r.result === "true") {
                $("#secLoc").html(r.html);
                createSelect("#secLoc");

            }
            //unblock();
            return false;
        },
        error: function () { }
    });
}
function getModels() {
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/getModels.ashx",
        success: function (data) {
            r = jQuery.parseJSON(data);
            if (r.result === "true") {
                $("#models").html(r.html);
                createSelect("#models");

            }
            //unblock();
            return false;
        },
        error: function () { }
    });
}
function getDefectsCGS() {
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/getDefectsCgs.ashx",
        success: function (data) {
            r = jQuery.parseJSON(data);
            if (r.result === "true") {
                $("#defectsCgs").html(r.html);
                createSelect("#defectsCgs");

            }
            //unblock();
            return false;
        },
        error: function () { }
    });
}
function getEmployees() {
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/getEmpList.ashx",
        success: function (data) {
            r = jQuery.parseJSON(data);
            if (r.result === "true") {
                $("#sltEmployees").html(r.html);
                createSelect("#sltEmployees");
                getEmployeeByPayroll($("#sltEmployees").val());
                $("#sltEmployees").change(function () {
                    getEmployeeByPayroll($("#sltEmployees").val());
                });
            }
            $("#inpuLD").prop("disabled", true);
            $("#inputDep").prop("disabled", true);
            $("#inputArea").prop("disabled", true);
            //unblock();
            return false;
        },
        error: function () { }
    });
}
function getEmployeeByPayroll(payroll) {
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/getEmployeeData.ashx",
        data: { payroll : payroll },
        success: function (data) {
            r = jQuery.parseJSON(data);
            if (r.result === "true") {
                //$("#sltEmployees").html(r.html);
                //createSelect("#sltEmployees");
                //$("#inpuLD").val(r.position);
                //$("#inputDep").val(r.department);
                //$("#inputArea").val(r.area);
                setEmployeeInfo(r.position, r.department, r.area);
            }
            //unblock();
            return false;
        },
        error: function () { }
    });
}
function setEmployeeInfo(p,d,a) {
    $("#inpuLD").val(p);
    $("#inputDep").val(d);
    $("#inputArea").val(a);
}
function getHist(serial) {
    $("#infModel").hide("Fold");
    blockV2("Obteniendo trazabilidad...");
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/getTracHist.ashx",
        data: { serial: serial },
        success: function (data) {
            removeOverlay();
            r = jQuery.parseJSON(data);
            if (r.result === "true") {
                $("#getTable").html(r.html);
                $("#inputPN").html(r.partN);
                $("#inputDjG").html(r.djgroup);
                $("#djGroup").val(r.djgroup);
                $("#inputBin").html(r.bin);
                $("#numPCBS").val(r.numPCBS);
                $("#bin").val(r.bin);
                $("#inpuOD").focus();
                $('#tableHist').DataTable({
                    "paging": false,
                    "searching": false,
                    "lengthChange": false,
                    "pageLength": 5,
                    "info": false,
                    "autoWidth": true,
                    "ordering": false
                    //'language': { 'url': getVirtDir() + '/Scripts/Spanish.json' }
                });
                getSubAssy(r.djgroup);
            }
            else {
                $("#getTable").html("<br/><div class='alert alert-danger' role='alert' style='text-align:center;font-weight: bold;'>" + r.messageError + "</div>");
                $("#getTableOr").html("<br/><div class='alert alert-danger' role='alert' style='text-align:center;font-weight: bold;'>No se pudo obtener resultados de oracle.</div>");
                $("#inputPN").html("");
                $("#inputDjG").html("");
                $("#inputBin").html("");
                $("#infModel").show("Fold");
                $("#countAssem").val(r.count);
                $("#inputUser").val("");
                $("#inputUser").focus();
            }
            //unblock();
            return false;
        },
        error: function () { }
    });
}

function getDetailSubA(LINKAGE_SEQ) {
    //alert($("#input_" + LINKAGE_SEQ).val());
    blockV2("Obteniendo detalle...");
    var d = new Date();
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/getSubAssyDetail.ashx",
        data: { assyName: $("#assemName_" + LINKAGE_SEQ).text(), numPCBS: $("#numPCBS").val() },
        success: function (data) {
            removeOverlay();
            r = jQuery.parseJSON(data);
            if (r.result === "true") {

                bootbox.dialog({
                    title: 'Components for ' + $("#assemName_" + LINKAGE_SEQ).text(),
                    size:'large',
                    message: "<div style='float:right;'>" +
                        "PCB´S PANEL/METALCORE: <input  id='div_N" + LINKAGE_SEQ + "' type='text' value='" + $("#numPCBS").val() + "' class='form-control'/>" +
                        "</div>" +
                        r.html
                        + "<script type='text/javascript'> " +
                                "$(document).ready(function() {"+
                                    "var table = $('#tableSubADet').DataTable({ " +
                                        "'paging': false, " +
                                        "'searching': true, " +
                                        "'bAutoWidth': true, " +
                                        "'info': false, " +
                                        "'scrollY':'400px'," + 
                                        "'lengthChange': false, " +
                                        "dom: 't'," +
                                        "'columnDefs': [{targets: '_all', width: '16.666667%'}]," +
                                        "'ordering': false " +
                                    "});" +
                                    "$('#tableSADet').css('display', 'block');" +
                                    "table.columns.adjust();" +
                                    "$('.dataTables_scrollHeadInner').css('width', '942px');" +
                                    "var options = { container: $('#tableSubADet'), showIndeterminate: true }; " + 
                                    "$('#check-all').checkAll(options);" + 
                                    "$('#check-all').on('change', function () {" + 
                                    "    if ($(this).prop('checked')) {" + 
                                    "        $('.checkme').each(function () {" + 
                                    "            $(this).prop('checked', true).trigger('change');" + 
                                    "        });" + 
                                    "    } else {" + 
                                    "        $('.checkme').each(function () {" + 
                                    "            $(this).prop('checked', false).trigger('change');" + 
                                    "        });" + 
                                    "    }" + 
                                    "});" +
                        			"$(window).bind('resize', function () {" +
                                        "table.columns.adjust();" +
                                    "});" +
                                    "$('#btnOK').click(function () {" +
                                        "$('#mainCost_" + LINKAGE_SEQ + "').html($('#lblTotal').text());" +
                                        "$('#mainCostA_" + LINKAGE_SEQ + "').html($('#lblTotal').text()); " +
                                        "updateCosts($('#input_" + LINKAGE_SEQ + "').val(), $('#lblTotal').text());" +
                                        "bootbox.hideAll();" +
                                    "});" +
                                    "$('#btnCancel').click(function () {" +
                                        "bootbox.hideAll();" +
                                    "});" +
                                "});" +
                    "</script>"

                });
                

            }
            else
                $("#getTable").html(r.MessageError);
            //unblock();

            return false;
        },
        error: function () { }
    });
}

function getTotal(id) {
    var valComp = parseFloat($("#COST_" + id).text());
    var tot = parseFloat($("#lblTotal").text());
    var newtotal;

    if (!$("#check_sub_" + id).is(':checked')) {
        newtotal = tot - valComp;
    }
    else {
        newtotal = tot + valComp;
    }
    var total = parseFloat(newtotal);

    $("#lblTotal").text(Number(total).toFixed(4));
}

function updateTotal(id) {
    //alert(id + ", " + $("#inputQ_" + id).val());
    updateQtyComp(id, $("#inputQ_" + id).val());
    return;
}
function updateQtyComp(id,qty) {
    blockV2("Actualizando costos...");
    var stringHtml;
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/UpdateQtyComp.ashx",
        data: { id: id, qty: qty },
        success: function (data) {
            removeOverlay();
            r = jQuery.parseJSON(data);
            if (r.result === "true") {
                stringHtml = r.html;
                var count = Number($("#countComp").val());
                for (var i = 1; i < count; i++) {
                    var strCost = '#COST_' + i;
                    var strCostA = '#COST_ACUM_' + i;
                    $(strCost).html(eval('r.cost_' + i));
                    $(strCostA).html(eval('r.costA_' + i));
                    $("#lblTotal").html(eval('r.costA_' + i));
                }
            }
            else
                $("#getTable").html(r.MessageError);

            return "false";
        },
        error: function () { }
    });
    return stringHtml;
}
function getSubAssy(djGroup) {
    blockV2("Obteniendo Subensambles...");
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/getSubAssy.ashx",
        data: { djGroup: djGroup, numPCBS: $("#numPCBS").val() },
        success: function (data) {
            removeOverlay();
            r = jQuery.parseJSON(data);
            if (r.result === "true") {
                $("#getTableOr").html(r.html);
                var tableS = $('#tableSubA').DataTable({
                    "paging": false,
                    "searching": false,
                    "lengthChange": false,
                    "pageLength": 5,
                    "info": false,
                    "autoWidth": true,
                    "ordering": false
                    //'language': { 'url': getVirtDir() + '/Scripts/Spanish.json' }
                });

                $("#infModel").show("Fold");
                $("#tracModel").show("Fold");
                $("#countAssem").val(r.count);
                $("#pair_fg").val(r.pair_fg);
                $("#inputUser").val("");
                $("#inputUser").focus();
                $("#inpuOD").focus();

            }
            else
                $("#getTable").html(r.MessageError);
            //unblock();
            return false;
        },
        error: function () { }
    });
}

function getPQCReport() {
    blockV2("Obteniendo Reporte...");
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/getPQCReport.ashx",
        data: { PRODUCT_PN: $("#models").val(), DEFECT_CODE: $("#defectsCgs").val(), EVENT_DATE: $("#datePIni").val(), EVENT_DATE_FIN: $("#datePFin").val() },
        success: function (data) {
            removeOverlay();
            r = jQuery.parseJSON(data);
            if (r.result === "true") {
                $("#getTableOr").html(r.html);
                var tableS = $('#tableDefects').DataTable({
                    dom: 'Bfrtip',
                    buttons: [
                        'excel'
                    ],
                    "paging": true,
                    "searching": true,
                    "lengthChange": false,
                    "pageLength": 5,
                    "info": false,
                    "autoWidth": true,
                    "ordering": false
                    //'language': { 'url': getVirtDir() + '/Scripts/Spanish.json' }
                });

                $("#infModel").show("Fold");
            }
            else {
                $("#getTableOr").html("<br/><div class='alert alert-danger' role='alert' style='text-align:center;font-weight: bold;'>No se pudo obtener resultados.</div>");
            }
            //unblock();
            return false;
        },
        error: function () { }
    });
}

function inset_item(radioValue) {
    blockV2("Insertando item...");
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/insertItem.ashx",
        data: {
            serial: $("#serial").val(), djGroup: $("#djGroup").val(), assem: $("#assemName_" + radioValue).text(), assemDesc: $("#assemDesc_" + radioValue).text(),
            wipEnt: $("#wipEnt_" + radioValue).text(), bin: $("#bin").val(), cost: $("#mainCostA_" + radioValue).text(), userKey: $("#userKey").val(),
            idDefect: $("#defects").val(), origin: $("#inpuOD").val(), model: $("#inputPN").text(), loc: $("#inpuLD").val(), pair_fg: $("#pair_fg").val()
        },
        success: function (data) {
            removeOverlay();
            r = jQuery.parseJSON(data);
            if (r.result === "true") {
                alertS("<div class='window-content' style='color:green;font-weight:bold;'>Se inserto el serial con éxito.</div>");
                $("#infModel").hide("Fold");
                $("#inputUser").val("");
                $("#inpuOD").val("");
                $("#inpuLD").val("");
                $("#inputUser").focus();
            }
            else
                alertE("<div class='window-content' style='color:red;font-weight:bold;'>" + r.MessageError + "</div");
            //unblock();
            return false;
        },
        error: function () { }
    });
}

function updateCosts(assemName, cost) {
    blockV2("Actualizando costos...");
    var stringHtml;
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/updateCosts.ashx",
        data: { assemName: assemName, cost: cost },
        success: function (data) {
            removeOverlay();
            r = jQuery.parseJSON(data);
            removeOverlay();
            if (r.result === "true") {
                stringHtml = r.html;
                var count = Number($("#countAssem").val());
                for (var i = count; i > 0; i--) {
                    var strCost = '#mainCost_' + i;
                    var strCostA = '#mainCostA_' + i;
                    $(strCost).html(eval('r.cost_' + i));
                    $(strCostA).html(eval('r.costA_' + i)); 
                }
            }
            else
                $("#getTable").html(r.MessageError);
            
            return "false";
        },
        error: function () { }
    });
    return stringHtml;
}
function blockV2(text) {
    $("<table id='overlay'><tbody><tr><td>"
        + "<div class='cssload-wrap'>" +
        "<div class= 'translate' >" +
        "<div class='scale'></div>" +
        "    </div >" +
        "</div >" +
        "<div class='cssload-wrap'>" +
        "    <div class='translate'>" +
        "        <div class='scale'></div>" +
        "    </div>" +
        "</div>" +
        "<div class='cssload-wrap'>" +
        "    <div class='translate'>" +
        "        <div class='scale'></div>" +
        "    </div>" +
        "</div>" +
        "<div class='cssload-wrap'>" +
        "    <div class='translate'>" +
        "        <div class='scale'></div>" +
        "    </div>" +
        "</div>" +
        "<div class='cssload-wrap'>" +
        "    <div class='translate'>" +
        "        <div class='scale'></div>" +
        "    </div>" +
        "</div>" +
        "<div class='cssload-wrap'>" +
        "    <div class='translate'>" +
        "        <div class='scale'></div>" +
        "    </div>" +
        "</div>" +
        "<div class='cssload-wrap'>" +
        "    <div class='translate'>" +
        "        <div class='scale'></div>" +
        "    </div>" +
        "</div>" +
        "<div class='cssload-wrap'>" +
        "    <div class='translate'>" +
        "        <div class='scale'></div>" +
        "    </div>" +
        "</div>" +
        "<div class='cssload-wrap'>" +
        "    <div class='translate'>" +
        "        <div class='scale'></div>" +
        "    </div>" +
        "</div>" +
        "<br/><br/><br/><div id='txtOver'>" + text + "</div>" +
        "</td></tr></tbody></table>").css({
            "position": "fixed",
            "top": "0px",
            "left": "0px",
            "width": "100%",
            "height": "100%",
            "background-color": "rgba(0,0,0,.5)",
            "z-index": "10000",
            "vertical-align": "middle",
            "text-align": "center",
            "color": "#fff",
            "font-size": "40px",
            "font-weight": "bold",
            "cursor": "wait"
        }).appendTo("body");
}
function removeOverlay() {
    $("#overlay").remove();
}

function getDlgLogin() {
    blockV2("");
    $.ajax({
        method: "GET",
        url: getVirtDir() + "/Account/Login",
        success: function (data) {
            removeOverlay();
            bootbox.dialog({
                title: 'Login',
                message: data
            });
            return false;
        },
        error: function () { }
    });
}  

function login(user, password) {
    blockV2("Validando Usuario...");
    var result = "false";
    $.ajax({
        url: getVirtDir() + "/Controllers/login.ashx",
        type: "POST",
        data: { user: user, password: password},
        async: false,
        success: function (data) {
            removeOverlay();
            var r = jQuery.parseJSON(data);

            //return r.result == "true";
            if (r.result === "true") {
                   result = "true";
            }
            else
                result = "false";
        },
        error: function () {
            result = "false";
        }
    });
    return result;
}

function checkLogin() {
    var r,result;
    //alert("ya funciono jquery en un dialogo!!");
    //if (!jQuery("#formLogin").validationEngine('validate')) {
    //    return false;
    //}
    //alert($("#Email").val());
    if ($("#Email").val() == "") {
        alertE("<div class='window-content'>El usuario no debe estar vacio!!</div>");
        result = "false";
    }
    else {
        r = login($("#Email").val(), $("#Password").val());
        //alert(r);
        if (r === "false") {
            result = "false";
            alertE("<div class='window-content'>El usuario no existe!!</div>");
            $("#Email").val("");
            $("#Password").val("");
            $("#Email").focus();
        }
        else {
            $("#userKey").val($("#Email").val());
            result = "true";
        }
    }
    return result;
};
function existCurWeek() {
    //alert("Week");
    $.ajax({
        method: "POST",
        url: getVirtDir() + "/Controllers/existCurWeek.ashx",
        success: function (data) {
            r = jQuery.parseJSON(data);
            if (r.result === "false") {
                alertI("<div class='window-content'>No existe información de costos para la semana.</div>");
            }
            else {
                getHist($("#inputUser").val());
            }
            //unblock();
            return false;
        },
        error: function () { }
    });
    return false;
}