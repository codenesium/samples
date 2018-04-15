using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOPurchaseOrderHeader
	{
		public POCOPurchaseOrderHeader()
		{}

		public POCOPurchaseOrderHeader(
			int purchaseOrderID,
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
			this.RevisionNumber = revisionNumber.ToInt();
			this.Status = status.ToInt();
			this.OrderDate = orderDate.ToDateTime();
			this.ShipDate = shipDate.ToNullableDateTime();
			this.SubTotal = subTotal.ToDecimal();
			this.TaxAmt = taxAmt.ToDecimal();
			this.Freight = freight.ToDecimal();
			this.TotalDue = totalDue.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.EmployeeID = new ReferenceEntity<int>(employeeID,
			                                           nameof(ApiResponse.Employees));
			this.VendorID = new ReferenceEntity<int>(vendorID,
			                                         nameof(ApiResponse.Vendors));
			this.ShipMethodID = new ReferenceEntity<int>(shipMethodID,
			                                             nameof(ApiResponse.ShipMethods));
		}

		public int PurchaseOrderID { get; set; }
		public int RevisionNumber { get; set; }
		public int Status { get; set; }
		public ReferenceEntity<int> EmployeeID { get; set; }
		public ReferenceEntity<int> VendorID { get; set; }
		public ReferenceEntity<int> ShipMethodID { get; set; }
		public DateTime OrderDate { get; set; }
		public Nullable<DateTime> ShipDate { get; set; }
		public decimal SubTotal { get; set; }
		public decimal TaxAmt { get; set; }
		public decimal Freight { get; set; }
		public decimal TotalDue { get; set; }
		public DateTime ModifiedDate { get; set; }

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
		public bool ShouldSerializeStatusValue { get; set; } = true;

		public bool ShouldSerializeStatus()
		{
			return this.ShouldSerializeStatusValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEmployeeIDValue { get; set; } = true;

		public bool ShouldSerializeEmployeeID()
		{
			return this.ShouldSerializeEmployeeIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeVendorIDValue { get; set; } = true;

		public bool ShouldSerializeVendorID()
		{
			return this.ShouldSerializeVendorIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShipMethodIDValue { get; set; } = true;

		public bool ShouldSerializeShipMethodID()
		{
			return this.ShouldSerializeShipMethodIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOrderDateValue { get; set; } = true;

		public bool ShouldSerializeOrderDate()
		{
			return this.ShouldSerializeOrderDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShipDateValue { get; set; } = true;

		public bool ShouldSerializeShipDate()
		{
			return this.ShouldSerializeShipDateValue;
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
		public bool ShouldSerializeFreightValue { get; set; } = true;

		public bool ShouldSerializeFreight()
		{
			return this.ShouldSerializeFreightValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTotalDueValue { get; set; } = true;

		public bool ShouldSerializeTotalDue()
		{
			return this.ShouldSerializeTotalDueValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
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
    <Hash>b758707b4c23d12a31bd35f1cb8a39ae</Hash>
</Codenesium>*/