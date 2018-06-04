using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiPurchaseOrderHeaderResponseModel: AbstractApiResponseModel
	{
		public ApiPurchaseOrderHeaderResponseModel() : base()
		{}

		public void SetProperties(
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
			this.EmployeeID = employeeID.ToInt();
			this.Freight = freight.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.OrderDate = orderDate.ToDateTime();
			this.PurchaseOrderID = purchaseOrderID.ToInt();
			this.RevisionNumber = revisionNumber.ToInt();
			this.ShipDate = shipDate.ToNullableDateTime();
			this.ShipMethodID = shipMethodID.ToInt();
			this.Status = status.ToInt();
			this.SubTotal = subTotal.ToDecimal();
			this.TaxAmt = taxAmt.ToDecimal();
			this.TotalDue = totalDue.ToDecimal();
			this.VendorID = vendorID.ToInt();
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

		public void DisableAllFields()
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
    <Hash>59a2e219b27050838e4d8b3f7cddecd7</Hash>
</Codenesium>*/