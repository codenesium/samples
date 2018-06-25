using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductVendorResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int averageLeadTime,
                        int businessEntityID,
                        decimal? lastReceiptCost,
                        DateTime? lastReceiptDate,
                        int maxOrderQty,
                        int minOrderQty,
                        DateTime modifiedDate,
                        int? onOrderQty,
                        int productID,
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

                public decimal? LastReceiptCost { get; private set; }

                public DateTime? LastReceiptDate { get; private set; }

                public int MaxOrderQty { get; private set; }

                public int MinOrderQty { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int? OnOrderQty { get; private set; }

                public int ProductID { get; private set; }

                public decimal StandardPrice { get; private set; }

                public string UnitMeasureCode { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeAverageLeadTimeValue { get; set; } = true;

                public bool ShouldSerializeAverageLeadTime()
                {
                        return this.ShouldSerializeAverageLeadTimeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

                public bool ShouldSerializeBusinessEntityID()
                {
                        return this.ShouldSerializeBusinessEntityIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLastReceiptCostValue { get; set; } = true;

                public bool ShouldSerializeLastReceiptCost()
                {
                        return this.ShouldSerializeLastReceiptCostValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLastReceiptDateValue { get; set; } = true;

                public bool ShouldSerializeLastReceiptDate()
                {
                        return this.ShouldSerializeLastReceiptDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeMaxOrderQtyValue { get; set; } = true;

                public bool ShouldSerializeMaxOrderQty()
                {
                        return this.ShouldSerializeMaxOrderQtyValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeMinOrderQtyValue { get; set; } = true;

                public bool ShouldSerializeMinOrderQty()
                {
                        return this.ShouldSerializeMinOrderQtyValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeOnOrderQtyValue { get; set; } = true;

                public bool ShouldSerializeOnOrderQty()
                {
                        return this.ShouldSerializeOnOrderQtyValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProductIDValue { get; set; } = true;

                public bool ShouldSerializeProductID()
                {
                        return this.ShouldSerializeProductIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStandardPriceValue { get; set; } = true;

                public bool ShouldSerializeStandardPrice()
                {
                        return this.ShouldSerializeStandardPriceValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeUnitMeasureCodeValue { get; set; } = true;

                public bool ShouldSerializeUnitMeasureCode()
                {
                        return this.ShouldSerializeUnitMeasureCodeValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeAverageLeadTimeValue = false;
                        this.ShouldSerializeBusinessEntityIDValue = false;
                        this.ShouldSerializeLastReceiptCostValue = false;
                        this.ShouldSerializeLastReceiptDateValue = false;
                        this.ShouldSerializeMaxOrderQtyValue = false;
                        this.ShouldSerializeMinOrderQtyValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeOnOrderQtyValue = false;
                        this.ShouldSerializeProductIDValue = false;
                        this.ShouldSerializeStandardPriceValue = false;
                        this.ShouldSerializeUnitMeasureCodeValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>5f7ed2e4c0df2f8bb4b883516c8bab3a</Hash>
</Codenesium>*/