using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOSalesOrderDetail : AbstractBusinessObject
        {
                public AbstractBOSalesOrderDetail()
                        : base()
                {
                }

                public virtual void SetProperties(int salesOrderID,
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
                        this.CarrierTrackingNumber = carrierTrackingNumber;
                        this.LineTotal = lineTotal;
                        this.ModifiedDate = modifiedDate;
                        this.OrderQty = orderQty;
                        this.ProductID = productID;
                        this.Rowguid = rowguid;
                        this.SalesOrderDetailID = salesOrderDetailID;
                        this.SalesOrderID = salesOrderID;
                        this.SpecialOfferID = specialOfferID;
                        this.UnitPrice = unitPrice;
                        this.UnitPriceDiscount = unitPriceDiscount;
                }

                public string CarrierTrackingNumber { get; private set; }

                public decimal LineTotal { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public short OrderQty { get; private set; }

                public int ProductID { get; private set; }

                public Guid Rowguid { get; private set; }

                public int SalesOrderDetailID { get; private set; }

                public int SalesOrderID { get; private set; }

                public int SpecialOfferID { get; private set; }

                public decimal UnitPrice { get; private set; }

                public decimal UnitPriceDiscount { get; private set; }
        }
}

/*<Codenesium>
    <Hash>6cb0f4fd1cb5603a95de62c8dab9fa33</Hash>
</Codenesium>*/