using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOProductVendor : AbstractBusinessObject
        {
                public AbstractBOProductVendor()
                        : base()
                {
                }

                public virtual void SetProperties(int productID,
                                                  int averageLeadTime,
                                                  int businessEntityID,
                                                  Nullable<decimal> lastReceiptCost,
                                                  Nullable<DateTime> lastReceiptDate,
                                                  int maxOrderQty,
                                                  int minOrderQty,
                                                  DateTime modifiedDate,
                                                  Nullable<int> onOrderQty,
                                                  decimal standardPrice,
                                                  string unitMeasureCode)
                {
                        this.AverageLeadTime = averageLeadTime;
                        this.BusinessEntityID = businessEntityID;
                        this.LastReceiptCost = lastReceiptCost;
                        this.LastReceiptDate = lastReceiptDate;
                        this.MaxOrderQty = maxOrderQty;
                        this.MinOrderQty = minOrderQty;
                        this.ModifiedDate = modifiedDate;
                        this.OnOrderQty = onOrderQty;
                        this.ProductID = productID;
                        this.StandardPrice = standardPrice;
                        this.UnitMeasureCode = unitMeasureCode;
                }

                public int AverageLeadTime { get; private set; }

                public int BusinessEntityID { get; private set; }

                public Nullable<decimal> LastReceiptCost { get; private set; }

                public Nullable<DateTime> LastReceiptDate { get; private set; }

                public int MaxOrderQty { get; private set; }

                public int MinOrderQty { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public Nullable<int> OnOrderQty { get; private set; }

                public int ProductID { get; private set; }

                public decimal StandardPrice { get; private set; }

                public string UnitMeasureCode { get; private set; }
        }
}

/*<Codenesium>
    <Hash>4eeb42592d2aadc03cc329a3f6996baa</Hash>
</Codenesium>*/