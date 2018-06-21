using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiPurchaseOrderHeaderResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int employeeID,
                        decimal freight,
                        DateTime modifiedDate,
                        DateTime orderDate,
                        int purchaseOrderID,
                        int revisionNumber,
                        Nullable<DateTime> shipDate,
                        int shipMethodID,
                        int status,
                        decimal subTotal,
                        decimal taxAmt,
                        decimal totalDue,
                        int vendorID)
                {
                        this.EmployeeID = employeeID;
                        this.Freight = freight;
                        this.ModifiedDate = modifiedDate;
                        this.OrderDate = orderDate;
                        this.PurchaseOrderID = purchaseOrderID;
                        this.RevisionNumber = revisionNumber;
                        this.ShipDate = shipDate;
                        this.ShipMethodID = shipMethodID;
                        this.Status = status;
                        this.SubTotal = subTotal;
                        this.TaxAmt = taxAmt;
                        this.TotalDue = totalDue;
                        this.VendorID = vendorID;
                }

                public int EmployeeID { get; private set; }

                public decimal Freight { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public DateTime OrderDate { get; private set; }

                public int PurchaseOrderID { get; private set; }

                public int RevisionNumber { get; private set; }

                public Nullable<DateTime> ShipDate { get; private set; }

                public int ShipMethodID { get; private set; }

                public int Status { get; private set; }

                public decimal SubTotal { get; private set; }

                public decimal TaxAmt { get; private set; }

                public decimal TotalDue { get; private set; }

                public int VendorID { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeEmployeeIDValue { get; set; } = true;

                public bool ShouldSerializeEmployeeID()
                {
                        return this.ShouldSerializeEmployeeIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeFreightValue { get; set; } = true;

                public bool ShouldSerializeFreight()
                {
                        return this.ShouldSerializeFreightValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeOrderDateValue { get; set; } = true;

                public bool ShouldSerializeOrderDate()
                {
                        return this.ShouldSerializeOrderDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePurchaseOrderIDValue { get; set; } = true;

                public bool ShouldSerializePurchaseOrderID()
                {
                        return this.ShouldSerializePurchaseOrderIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRevisionNumberValue { get; set; } = true;

                public bool ShouldSerializeRevisionNumber()
                {
                        return this.ShouldSerializeRevisionNumberValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeShipDateValue { get; set; } = true;

                public bool ShouldSerializeShipDate()
                {
                        return this.ShouldSerializeShipDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeShipMethodIDValue { get; set; } = true;

                public bool ShouldSerializeShipMethodID()
                {
                        return this.ShouldSerializeShipMethodIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStatusValue { get; set; } = true;

                public bool ShouldSerializeStatus()
                {
                        return this.ShouldSerializeStatusValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSubTotalValue { get; set; } = true;

                public bool ShouldSerializeSubTotal()
                {
                        return this.ShouldSerializeSubTotalValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTaxAmtValue { get; set; } = true;

                public bool ShouldSerializeTaxAmt()
                {
                        return this.ShouldSerializeTaxAmtValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTotalDueValue { get; set; } = true;

                public bool ShouldSerializeTotalDue()
                {
                        return this.ShouldSerializeTotalDueValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeVendorIDValue { get; set; } = true;

                public bool ShouldSerializeVendorID()
                {
                        return this.ShouldSerializeVendorIDValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeEmployeeIDValue = false;
                        this.ShouldSerializeFreightValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeOrderDateValue = false;
                        this.ShouldSerializePurchaseOrderIDValue = false;
                        this.ShouldSerializeRevisionNumberValue = false;
                        this.ShouldSerializeShipDateValue = false;
                        this.ShouldSerializeShipMethodIDValue = false;
                        this.ShouldSerializeStatusValue = false;
                        this.ShouldSerializeSubTotalValue = false;
                        this.ShouldSerializeTaxAmtValue = false;
                        this.ShouldSerializeTotalDueValue = false;
                        this.ShouldSerializeVendorIDValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>06b1e287a04e8e5e2582042866fe7560</Hash>
</Codenesium>*/