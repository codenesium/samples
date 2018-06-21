using Codenesium.DataConversionExtensions.AspNetCore;
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
                                                  decimal receivedQty,
                                                  decimal rejectedQty,
                                                  decimal stockedQty,
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

                public decimal ReceivedQty { get; private set; }

                public decimal RejectedQty { get; private set; }

                public decimal StockedQty { get; private set; }

                public decimal UnitPrice { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9476153a30bd9a2d87acbbec434e985b</Hash>
</Codenesium>*/