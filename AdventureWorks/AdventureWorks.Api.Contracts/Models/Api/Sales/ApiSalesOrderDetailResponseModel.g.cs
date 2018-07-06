using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesOrderDetailResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int salesOrderID,
                        string carrierTrackingNumber,
                        decimal lineTotal,
                        DateTime modifiedDate,
                        short orderQty,
                        int productID,
                        Guid rowguid,
                        int salesOrderDetailID,
                        int specialOfferID,
                        decimal unitPrice,
                        decimal unitPriceDiscount)
                {
                        this.SalesOrderID = salesOrderID;
                        this.CarrierTrackingNumber = carrierTrackingNumber;
                        this.LineTotal = lineTotal;
                        this.ModifiedDate = modifiedDate;
                        this.OrderQty = orderQty;
                        this.ProductID = productID;
                        this.Rowguid = rowguid;
                        this.SalesOrderDetailID = salesOrderDetailID;
                        this.SpecialOfferID = specialOfferID;
                        this.UnitPrice = unitPrice;
                        this.UnitPriceDiscount = unitPriceDiscount;

                        this.ProductIDEntity = nameof(ApiResponse.SpecialOfferProducts);
                        this.SalesOrderIDEntity = nameof(ApiResponse.SalesOrderHeaders);
                        this.SpecialOfferIDEntity = nameof(ApiResponse.SpecialOfferProducts);
                }

                public string CarrierTrackingNumber { get; private set; }

                public decimal LineTotal { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public short OrderQty { get; private set; }

                public int ProductID { get; private set; }

                public string ProductIDEntity { get; set; }

                public Guid Rowguid { get; private set; }

                public int SalesOrderDetailID { get; private set; }

                public int SalesOrderID { get; private set; }

                public string SalesOrderIDEntity { get; set; }

                public int SpecialOfferID { get; private set; }

                public string SpecialOfferIDEntity { get; set; }

                public decimal UnitPrice { get; private set; }

                public decimal UnitPriceDiscount { get; private set; }
        }
}

/*<Codenesium>
    <Hash>2846f170323753f741518cb4c9aeb36b</Hash>
</Codenesium>*/