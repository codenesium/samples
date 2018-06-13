using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiSalesOrderDetailResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string carrierTrackingNumber,
                        decimal lineTotal,
                        DateTime modifiedDate,
                        short orderQty,
                        int productID,
                        Guid rowguid,
                        int salesOrderDetailID,
                        int salesOrderID,
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

                [JsonIgnore]
                public bool ShouldSerializeCarrierTrackingNumberValue { get; set; } = true;

                public bool ShouldSerializeCarrierTrackingNumber()
                {
                        return this.ShouldSerializeCarrierTrackingNumberValue;
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
                public bool ShouldSerializeRowguidValue { get; set; } = true;

                public bool ShouldSerializeRowguid()
                {
                        return this.ShouldSerializeRowguidValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSalesOrderDetailIDValue { get; set; } = true;

                public bool ShouldSerializeSalesOrderDetailID()
                {
                        return this.ShouldSerializeSalesOrderDetailIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSalesOrderIDValue { get; set; } = true;

                public bool ShouldSerializeSalesOrderID()
                {
                        return this.ShouldSerializeSalesOrderIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSpecialOfferIDValue { get; set; } = true;

                public bool ShouldSerializeSpecialOfferID()
                {
                        return this.ShouldSerializeSpecialOfferIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeUnitPriceValue { get; set; } = true;

                public bool ShouldSerializeUnitPrice()
                {
                        return this.ShouldSerializeUnitPriceValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeUnitPriceDiscountValue { get; set; } = true;

                public bool ShouldSerializeUnitPriceDiscount()
                {
                        return this.ShouldSerializeUnitPriceDiscountValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeCarrierTrackingNumberValue = false;
                        this.ShouldSerializeLineTotalValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeOrderQtyValue = false;
                        this.ShouldSerializeProductIDValue = false;
                        this.ShouldSerializeRowguidValue = false;
                        this.ShouldSerializeSalesOrderDetailIDValue = false;
                        this.ShouldSerializeSalesOrderIDValue = false;
                        this.ShouldSerializeSpecialOfferIDValue = false;
                        this.ShouldSerializeUnitPriceValue = false;
                        this.ShouldSerializeUnitPriceDiscountValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>f20ec1401c6b6c79269311855d1b68ab</Hash>
</Codenesium>*/