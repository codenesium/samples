using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiPurchaseOrderDetailResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        DateTime dueDate,
                        decimal lineTotal,
                        DateTime modifiedDate,
                        short orderQty,
                        int productID,
                        int purchaseOrderDetailID,
                        int purchaseOrderID,
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

                [JsonIgnore]
                public bool ShouldSerializeDueDateValue { get; set; } = true;

                public bool ShouldSerializeDueDate()
                {
                        return this.ShouldSerializeDueDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLineTotalValue { get; set; } = true;

                public bool ShouldSerializeLineTotal()
                {
                        return this.ShouldSerializeLineTotalValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeOrderQtyValue { get; set; } = true;

                public bool ShouldSerializeOrderQty()
                {
                        return this.ShouldSerializeOrderQtyValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProductIDValue { get; set; } = true;

                public bool ShouldSerializeProductID()
                {
                        return this.ShouldSerializeProductIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePurchaseOrderDetailIDValue { get; set; } = true;

                public bool ShouldSerializePurchaseOrderDetailID()
                {
                        return this.ShouldSerializePurchaseOrderDetailIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePurchaseOrderIDValue { get; set; } = true;

                public bool ShouldSerializePurchaseOrderID()
                {
                        return this.ShouldSerializePurchaseOrderIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeReceivedQtyValue { get; set; } = true;

                public bool ShouldSerializeReceivedQty()
                {
                        return this.ShouldSerializeReceivedQtyValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRejectedQtyValue { get; set; } = true;

                public bool ShouldSerializeRejectedQty()
                {
                        return this.ShouldSerializeRejectedQtyValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStockedQtyValue { get; set; } = true;

                public bool ShouldSerializeStockedQty()
                {
                        return this.ShouldSerializeStockedQtyValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeUnitPriceValue { get; set; } = true;

                public bool ShouldSerializeUnitPrice()
                {
                        return this.ShouldSerializeUnitPriceValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeDueDateValue = false;
                        this.ShouldSerializeLineTotalValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeOrderQtyValue = false;
                        this.ShouldSerializeProductIDValue = false;
                        this.ShouldSerializePurchaseOrderDetailIDValue = false;
                        this.ShouldSerializePurchaseOrderIDValue = false;
                        this.ShouldSerializeReceivedQtyValue = false;
                        this.ShouldSerializeRejectedQtyValue = false;
                        this.ShouldSerializeStockedQtyValue = false;
                        this.ShouldSerializeUnitPriceValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>f7c4b525d3ff8e4ea648bcd0752b2722</Hash>
</Codenesium>*/