using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOPurchaseOrderHeader: AbstractPOCO
	{
		public POCOPurchaseOrderHeader() : base()
		{}

		public POCOPurchaseOrderHeader(
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

		public int EmployeeID { get; set; }
		public decimal Freight { get; set; }
		public DateTime ModifiedDate { get; set; }
		public DateTime OrderDate { get; set; }
		public int PurchaseOrderID { get; set; }
		public int RevisionNumber { get; set; }
		public Nullable<DateTime> ShipDate { get; set; }
		public int ShipMethodID { get; set; }
		public int Status { get; set; }
		public decimal SubTotal { get; set; }
		public decimal TaxAmt { get; set; }
		public decimal TotalDue { get; set; }
		public int VendorID { get; set; }

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
    <Hash>2c5f3a2a62679b595fdd92105883686a</Hash>
</Codenesium>*/