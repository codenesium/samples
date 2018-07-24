using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOPurchaseOrderDetail : AbstractBusinessObject
        {
                public AbstractBOPurchaseOrderDetail()
                        : base()
                {
                }

                public virtual void SetProperties(int purchaseOrderID,
                                                  DateTime dueDate,
                                                  decimal lineTotal,
                                                  DateTime modifiedDate,
                                                  short orderQty,
                                                  int productID,
                                                  int purchaseOrderDetailID,
                                                  double receivedQty,
                                                  double rejectedQty,
                                                  double stockedQty,
                                                  decimal unitPrice)
                {
                        this.DueDate = dueDate;
                        this.LineTotal = lineTotal;
                        this.ModifiedDate = modifiedDate;
                        this.OrderQty = orderQty;
                        this.ProductID = productID;
                        this.PurchaseOrderDetailID = purchaseOrderDetailID;
                        this.PurchaseOrderID = purchaseOrderID;
                        this.ReceivedQty = receivedQty;
                        this.RejectedQty = rejectedQty;
                        this.StockedQty = stockedQty;
                        this.UnitPrice = unitPrice;
                }

                public DateTime DueDate { get; private set; }

                public decimal LineTotal { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public short OrderQty { get; private set; }

                public int ProductID { get; private set; }

                public int PurchaseOrderDetailID { get; private set; }

                public int PurchaseOrderID { get; private set; }

                public double ReceivedQty { get; private set; }

                public double RejectedQty { get; private set; }

                public double StockedQty { get; private set; }

                public decimal UnitPrice { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c64e290539b3d6f53ce5b781c8422b8c</Hash>
</Codenesium>*/