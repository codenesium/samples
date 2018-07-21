using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiPurchaseOrderDetailResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int purchaseOrderID,
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
                        this.PurchaseOrderID = purchaseOrderID;
                        this.DueDate = dueDate;
                        this.LineTotal = lineTotal;
                        this.ModifiedDate = modifiedDate;
                        this.OrderQty = orderQty;
                        this.ProductID = productID;
                        this.PurchaseOrderDetailID = purchaseOrderDetailID;
                        this.ReceivedQty = receivedQty;
                        this.RejectedQty = rejectedQty;
                        this.StockedQty = stockedQty;
                        this.UnitPrice = unitPrice;
                }

                [JsonProperty]
                public DateTime DueDate { get; private set; }

                [JsonProperty]
                public decimal LineTotal { get; private set; }

                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [JsonProperty]
                public short OrderQty { get; private set; }

                [JsonProperty]
                public int ProductID { get; private set; }

                [JsonProperty]
                public int PurchaseOrderDetailID { get; private set; }

                [JsonProperty]
                public int PurchaseOrderID { get; private set; }

                [JsonProperty]
                public decimal ReceivedQty { get; private set; }

                [JsonProperty]
                public decimal RejectedQty { get; private set; }

                [JsonProperty]
                public decimal StockedQty { get; private set; }

                [JsonProperty]
                public decimal UnitPrice { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c48b696219c88f11f4a7ecfe1e185428</Hash>
</Codenesium>*/