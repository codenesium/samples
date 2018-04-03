using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOPurchaseOrderHeader
	{
		public POCOPurchaseOrderHeader()
		{}

		public POCOPurchaseOrderHeader(int purchaseOrderID,
		                               int revisionNumber,
		                               int status,
		                               int employeeID,
		                               int vendorID,
		                               int shipMethodID,
		                               DateTime orderDate,
		                               Nullable<DateTime> shipDate,
		                               decimal subTotal,
		                               decimal taxAmt,
		                               decimal freight,
		                               decimal totalDue,
		                               DateTime modifiedDate)
		{
			this.PurchaseOrderID = purchaseOrderID.ToInt();
			this.RevisionNumber = revisionNumber;
			this.Status = status;
			this.EmployeeID = employeeID.ToInt();
			this.VendorID = vendorID.ToInt();
			this.ShipMethodID = shipMethodID.ToInt();
			this.OrderDate = orderDate.ToDateTime();
			this.ShipDate = shipDate.ToNullableDateTime();
			this.SubTotal = subTotal;
			this.TaxAmt = taxAmt;
			this.Freight = freight;
			this.TotalDue = totalDue;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int PurchaseOrderID {get; set;}
		public int RevisionNumber {get; set;}
		public int Status {get; set;}
		public int EmployeeID {get; set;}
		public int VendorID {get; set;}
		public int ShipMethodID {get; set;}
		public DateTime OrderDate {get; set;}
		public Nullable<DateTime> ShipDate {get; set;}
		public decimal SubTotal {get; set;}
		public decimal TaxAmt {get; set;}
		public decimal Freight {get; set;}
		public decimal TotalDue {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializePurchaseOrderIDValue {get; set;} = true;

		public bool ShouldSerializePurchaseOrderID()
		{
			return ShouldSerializePurchaseOrderIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRevisionNumberValue {get; set;} = true;

		public bool ShouldSerializeRevisionNumber()
		{
			return ShouldSerializeRevisionNumberValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStatusValue {get; set;} = true;

		public bool ShouldSerializeStatus()
		{
			return ShouldSerializeStatusValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEmployeeIDValue {get; set;} = true;

		public bool ShouldSerializeEmployeeID()
		{
			return ShouldSerializeEmployeeIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeVendorIDValue {get; set;} = true;

		public bool ShouldSerializeVendorID()
		{
			return ShouldSerializeVendorIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShipMethodIDValue {get; set;} = true;

		public bool ShouldSerializeShipMethodID()
		{
			return ShouldSerializeShipMethodIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOrderDateValue {get; set;} = true;

		public bool ShouldSerializeOrderDate()
		{
			return ShouldSerializeOrderDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShipDateValue {get; set;} = true;

		public bool ShouldSerializeShipDate()
		{
			return ShouldSerializeShipDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSubTotalValue {get; set;} = true;

		public bool ShouldSerializeSubTotal()
		{
			return ShouldSerializeSubTotalValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTaxAmtValue {get; set;} = true;

		public bool ShouldSerializeTaxAmt()
		{
			return ShouldSerializeTaxAmtValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFreightValue {get; set;} = true;

		public bool ShouldSerializeFreight()
		{
			return ShouldSerializeFreightValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTotalDueValue {get; set;} = true;

		public bool ShouldSerializeTotalDue()
		{
			return ShouldSerializeTotalDueValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializePurchaseOrderIDValue = false;
			this.ShouldSerializeRevisionNumberValue = false;
			this.ShouldSerializeStatusValue = false;
			this.ShouldSerializeEmployeeIDValue = false;
			this.ShouldSerializeVendorIDValue = false;
			this.ShouldSerializeShipMethodIDValue = false;
			this.ShouldSerializeOrderDateValue = false;
			this.ShouldSerializeShipDateValue = false;
			this.ShouldSerializeSubTotalValue = false;
			this.ShouldSerializeTaxAmtValue = false;
			this.ShouldSerializeFreightValue = false;
			this.ShouldSerializeTotalDueValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>c44f9abc41a75382520b436a3160eaa9</Hash>
</Codenesium>*/