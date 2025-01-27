﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pendingProds.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class siixsem_scrap_dbEntities : DbContext
    {
        public siixsem_scrap_dbEntities()
            : base("name=siixsem_scrap_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<insert_item_Result> insert_item(string serial, string djGroup, string assembly, string assemDesc, string we, string bin, Nullable<double> cost, string user, Nullable<int> idDefect, string origin, string model, string loc, string pair_fg)
        {
            var serialParameter = serial != null ?
                new ObjectParameter("serial", serial) :
                new ObjectParameter("serial", typeof(string));
    
            var djGroupParameter = djGroup != null ?
                new ObjectParameter("djGroup", djGroup) :
                new ObjectParameter("djGroup", typeof(string));
    
            var assemblyParameter = assembly != null ?
                new ObjectParameter("assembly", assembly) :
                new ObjectParameter("assembly", typeof(string));
    
            var assemDescParameter = assemDesc != null ?
                new ObjectParameter("assemDesc", assemDesc) :
                new ObjectParameter("assemDesc", typeof(string));
    
            var weParameter = we != null ?
                new ObjectParameter("we", we) :
                new ObjectParameter("we", typeof(string));
    
            var binParameter = bin != null ?
                new ObjectParameter("bin", bin) :
                new ObjectParameter("bin", typeof(string));
    
            var costParameter = cost.HasValue ?
                new ObjectParameter("cost", cost) :
                new ObjectParameter("cost", typeof(double));
    
            var userParameter = user != null ?
                new ObjectParameter("user", user) :
                new ObjectParameter("user", typeof(string));
    
            var idDefectParameter = idDefect.HasValue ?
                new ObjectParameter("idDefect", idDefect) :
                new ObjectParameter("idDefect", typeof(int));
    
            var originParameter = origin != null ?
                new ObjectParameter("origin", origin) :
                new ObjectParameter("origin", typeof(string));
    
            var modelParameter = model != null ?
                new ObjectParameter("model", model) :
                new ObjectParameter("model", typeof(string));
    
            var locParameter = loc != null ?
                new ObjectParameter("loc", loc) :
                new ObjectParameter("loc", typeof(string));
    
            var pair_fgParameter = pair_fg != null ?
                new ObjectParameter("pair_fg", pair_fg) :
                new ObjectParameter("pair_fg", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<insert_item_Result>("insert_item", serialParameter, djGroupParameter, assemblyParameter, assemDescParameter, weParameter, binParameter, costParameter, userParameter, idDefectParameter, originParameter, modelParameter, locParameter, pair_fgParameter);
        }
    
        public virtual int insertItemTemp(Nullable<int> ls, string assemName, string assemDesc, string wp, Nullable<double> cost, Nullable<double> costAcum, Nullable<int> numPCBS)
        {
            var lsParameter = ls.HasValue ?
                new ObjectParameter("ls", ls) :
                new ObjectParameter("ls", typeof(int));
    
            var assemNameParameter = assemName != null ?
                new ObjectParameter("assemName", assemName) :
                new ObjectParameter("assemName", typeof(string));
    
            var assemDescParameter = assemDesc != null ?
                new ObjectParameter("assemDesc", assemDesc) :
                new ObjectParameter("assemDesc", typeof(string));
    
            var wpParameter = wp != null ?
                new ObjectParameter("wp", wp) :
                new ObjectParameter("wp", typeof(string));
    
            var costParameter = cost.HasValue ?
                new ObjectParameter("cost", cost) :
                new ObjectParameter("cost", typeof(double));
    
            var costAcumParameter = costAcum.HasValue ?
                new ObjectParameter("costAcum", costAcum) :
                new ObjectParameter("costAcum", typeof(double));
    
            var numPCBSParameter = numPCBS.HasValue ?
                new ObjectParameter("numPCBS", numPCBS) :
                new ObjectParameter("numPCBS", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertItemTemp", lsParameter, assemNameParameter, assemDescParameter, wpParameter, costParameter, costAcumParameter, numPCBSParameter);
        }
    
        public virtual int reset_temp_or()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("reset_temp_or");
        }
    
        public virtual ObjectResult<calculateCostAcum_Result> calculateCostAcum()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<calculateCostAcum_Result>("calculateCostAcum");
        }
    
        public virtual ObjectResult<updateAssemCost_Result> updateAssemCost(string assemName, Nullable<double> cost)
        {
            var assemNameParameter = assemName != null ?
                new ObjectParameter("assemName", assemName) :
                new ObjectParameter("assemName", typeof(string));
    
            var costParameter = cost.HasValue ?
                new ObjectParameter("cost", cost) :
                new ObjectParameter("cost", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<updateAssemCost_Result>("updateAssemCost", assemNameParameter, costParameter);
        }
    
        public virtual ObjectResult<getModFailures_Result> getModFailures()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getModFailures_Result>("getModFailures");
        }
    
        public virtual ObjectResult<calculateCostAcumComp_Result> calculateCostAcumComp()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<calculateCostAcumComp_Result>("calculateCostAcumComp");
        }
    
        public virtual int insertCompTemp(string compName, Nullable<double> qty, Nullable<double> cost_unity, Nullable<double> cost_tot, Nullable<double> costAcum)
        {
            var compNameParameter = compName != null ?
                new ObjectParameter("compName", compName) :
                new ObjectParameter("compName", typeof(string));
    
            var qtyParameter = qty.HasValue ?
                new ObjectParameter("qty", qty) :
                new ObjectParameter("qty", typeof(double));
    
            var cost_unityParameter = cost_unity.HasValue ?
                new ObjectParameter("cost_unity", cost_unity) :
                new ObjectParameter("cost_unity", typeof(double));
    
            var cost_totParameter = cost_tot.HasValue ?
                new ObjectParameter("cost_tot", cost_tot) :
                new ObjectParameter("cost_tot", typeof(double));
    
            var costAcumParameter = costAcum.HasValue ?
                new ObjectParameter("costAcum", costAcum) :
                new ObjectParameter("costAcum", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertCompTemp", compNameParameter, qtyParameter, cost_unityParameter, cost_totParameter, costAcumParameter);
        }
    
        public virtual int reset_temp_comp()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("reset_temp_comp");
        }
    
        public virtual ObjectResult<updateCompCost_Result> updateCompCost(Nullable<double> id, Nullable<double> qty)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(double));
    
            var qtyParameter = qty.HasValue ?
                new ObjectParameter("qty", qty) :
                new ObjectParameter("qty", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<updateCompCost_Result>("updateCompCost", idParameter, qtyParameter);
        }
    
        public virtual ObjectResult<getSectorLocations_Result> getSectorLocations()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getSectorLocations_Result>("getSectorLocations");
        }
    
        public virtual ObjectResult<getPQCReport_Result> getPQCReport(string dateIni, string dateFin, string pRODUCT_PN, string dEFECT_CODE)
        {
            var dateIniParameter = dateIni != null ?
                new ObjectParameter("dateIni", dateIni) :
                new ObjectParameter("dateIni", typeof(string));
    
            var dateFinParameter = dateFin != null ?
                new ObjectParameter("dateFin", dateFin) :
                new ObjectParameter("dateFin", typeof(string));
    
            var pRODUCT_PNParameter = pRODUCT_PN != null ?
                new ObjectParameter("PRODUCT_PN", pRODUCT_PN) :
                new ObjectParameter("PRODUCT_PN", typeof(string));
    
            var dEFECT_CODEParameter = dEFECT_CODE != null ?
                new ObjectParameter("DEFECT_CODE", dEFECT_CODE) :
                new ObjectParameter("DEFECT_CODE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getPQCReport_Result>("getPQCReport", dateIniParameter, dateFinParameter, pRODUCT_PNParameter, dEFECT_CODEParameter);
        }
    
        public virtual ObjectResult<getLevelProfile_Result> getLevelProfile(Nullable<int> group_id)
        {
            var group_idParameter = group_id.HasValue ?
                new ObjectParameter("group_id", group_id) :
                new ObjectParameter("group_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getLevelProfile_Result>("getLevelProfile", group_idParameter);
        }
    
        public virtual ObjectResult<checkCurWeek_Result> checkCurWeek()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<checkCurWeek_Result>("checkCurWeek");
        }
    
        public virtual ObjectResult<getMPNCost_Result> getMPNCost(string mPN, Nullable<int> wEEK, Nullable<int> nUM_COMP, Nullable<int> yEAR)
        {
            var mPNParameter = mPN != null ?
                new ObjectParameter("MPN", mPN) :
                new ObjectParameter("MPN", typeof(string));
    
            var wEEKParameter = wEEK.HasValue ?
                new ObjectParameter("WEEK", wEEK) :
                new ObjectParameter("WEEK", typeof(int));
    
            var nUM_COMPParameter = nUM_COMP.HasValue ?
                new ObjectParameter("NUM_COMP", nUM_COMP) :
                new ObjectParameter("NUM_COMP", typeof(int));
    
            var yEARParameter = yEAR.HasValue ?
                new ObjectParameter("YEAR", yEAR) :
                new ObjectParameter("YEAR", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getMPNCost_Result>("getMPNCost", mPNParameter, wEEKParameter, nUM_COMPParameter, yEARParameter);
        }
    
        public virtual ObjectResult<string> takeLastWeek()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("takeLastWeek");
        }
    
        public virtual ObjectResult<getCatDetail_Result> getCatDetail(Nullable<int> idCat)
        {
            var idCatParameter = idCat.HasValue ?
                new ObjectParameter("idCat", idCat) :
                new ObjectParameter("idCat", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getCatDetail_Result>("getCatDetail", idCatParameter);
        }
    
        public virtual ObjectResult<getCategories_Result> getCategories()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getCategories_Result>("getCategories");
        }
    }
}
