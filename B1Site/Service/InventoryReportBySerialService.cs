using B1Site.Connection;
using B1Site.Models.InventoryReportBySerial;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace B1Site.Service
{
    public class InventoryReportBySerialService : IInventoryReportBySerialService
    {
        #region Bind Master Data
        public Task<List<ModelMaster>> GetModelMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT DISTINCT(ISNULL(U_Model,'')) AS Model  FROM OITM WHERE ISNULL(U_Model,'')<>''  ORDER BY ISNULL(U_Model,'')");
            List<ModelMaster> modelMasters = new List<ModelMaster>();
            foreach (DataRow a in dt.Rows)
            {
                modelMasters.Add(new ModelMaster
                {
                    Name = a[0].ToString()
                });
            }
            return Task.FromResult(modelMasters);
        }

        public Task<List<MainGroupMaster>> GetMainGroupsAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT DISTINCT(ISNULL(ItmsGrpNam,'')) As itmsgrp FROM OITM T0 INNER JOIN OITB T1 ON T0.ItmsGrpCod=T1.ItmsGrpCod");
            List<MainGroupMaster> mainGroups = new List<MainGroupMaster>();
            foreach (DataRow a in dt.Rows)
            {
                mainGroups.Add(new MainGroupMaster
                {
                    Name = a[0].ToString()
                });
            }
            return Task.FromResult(mainGroups);
        }

        public Task<List<VendorCodeMaster>> GetVendorCodeMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT DISTINCT(ISNULL(U_VendorCode1,'')) AS VendorCode  FROM OITM WHERE ISNULL(U_VendorCode1,'')<>''");
            List<VendorCodeMaster> vendorCodeMasters = new List<VendorCodeMaster>();
            foreach (DataRow a in dt.Rows)
            {
                vendorCodeMasters.Add(new VendorCodeMaster
                {
                    Name = a[0].ToString()
                });
            }
            return Task.FromResult(vendorCodeMasters);
        }

        public Task<List<RegionMaster>> GetRegionMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT Location As Region FROM OLCT");
            List<RegionMaster> regionMasters = new List<RegionMaster>();
            foreach (DataRow a in dt.Rows)
            {
                regionMasters.Add(new RegionMaster
                {
                    Name = a[0].ToString()
                });
            }
            return Task.FromResult(regionMasters);
        }

        public Task<List<WarehouseIDMaster>> GetWarehouseIDMastersAsync()
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("SELECT WhsCode,WhsName FROM OWHS");
            List<WarehouseIDMaster> warehouseIDMasters = new List<WarehouseIDMaster>();
            foreach (DataRow a in dt.Rows)
            {
                warehouseIDMasters.Add(new WarehouseIDMaster
                {
                    Code=a[0].ToString(),
                    Name = a[1].ToString()
                });
            }
            return Task.FromResult(warehouseIDMasters);
        }
        #endregion
        #region Bind Report Ajax
        public Task<string> GetInventoryReportBySerialsAsync(DateTime datefrom, DateTime dateto, string itemgroup, string model, string vendorcode, string warehouse)
        {
            ClsCRUD clsCRUD = new ClsCRUD();
            var dt = clsCRUD.Getdata("EXEC [USP_Inventory_Serial_Batch_Cost_Combine_R1_WebReport] '"+datefrom+"','"+dateto+"','"+itemgroup+"','"+model+"','"+vendorcode+"','"+warehouse+"'");
            List<InventoryReportBySerial> inventoryReportBySerials = new List<InventoryReportBySerial>();
            foreach (DataRow a in dt.Rows)
            {
                try
                {
                    inventoryReportBySerials.Add(new InventoryReportBySerial
                    {
                        ItemCode = a[0].ToString(),
                        VenderCode = a[1].ToString(),
                        ItemGroup = a[2].ToString(),
                        Category = a[3].ToString(),
                        SubCategory = a[4].ToString(),
                        Description = a[5].ToString(),
                        Year = a[6].ToString(),
                        Model = a[7].ToString(),
                        SerailNumber = a[8].ToString(),
                        Warehouse = a[9].ToString(),
                        BinLocation = a[10].ToString(),
                        Shelf = "",
                        Qty = Convert.ToInt32(a[12].ToString()),
                    });
                }catch(Exception ex)
                {
                    var a1 = ex.Message;
                }
                
            }
            return Task.FromResult(Utf8Json.JsonSerializer.ToJsonString(inventoryReportBySerials));
        }
        #endregion
    }
}
