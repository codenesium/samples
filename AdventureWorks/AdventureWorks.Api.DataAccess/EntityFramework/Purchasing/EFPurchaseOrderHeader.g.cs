using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("PurchaseOrderHeader", Schema="Purchasing")]
	public partial class EFPurchaseOrderHeader: AbstractEntityFrameworkPOCO
	{
		public EFPurchaseOrderHeader()
		{}

		public void SetProperties(
			int purchaseOrderID,
			int employeeID,
			decimal freight,
			DateTime modifiedDate,
			DateTime orderDate,
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

		[Column("EmployeeID", TypeName="int")]
		public int EmployeeID { get; set; }

		[Column("Freight", TypeName="money")]
		public decimal Freight { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("OrderDate", TypeName="datetime")]
		public DateTime OrderDate { get; set; }

		[Key]
		[Column("PurchaseOrderID", TypeName="int")]
		public int PurchaseOrderID { get; set; }

		[Column("RevisionNumber", TypeName="tinyint")]
		public int RevisionNumber { get; set; }

		[Column("ShipDate", TypeName="datetime")]
		public Nullable<DateTime> ShipDate { get; set; }

		[Column("ShipMethodID", TypeName="int")]
		public int ShipMethodID { get; set; }

		[Column("Status", TypeName="tinyint")]
		public int Status { get; set; }

		[Column("SubTotal", TypeName="money")]
		public decimal SubTotal { get; set; }

		[Column("TaxAmt", TypeName="money")]
		public decimal TaxAmt { get; set; }

		[Column("TotalDue", TypeName="money")]
		public decimal TotalDue { get; set; }

		[Column("VendorID", TypeName="int")]
		public int VendorID { get; set; }

		[ForeignKey("ShipMethodID")]
		public virtual EFShipMethod ShipMethod { get; set; }

		[ForeignKey("VendorID")]
		public virtual EFVendor Vendor { get; set; }
	}
}

/*<Codenesium>
    <Hash>b0607a89a114174bb84bd15ce8a2712f</Hash>
</Codenesium>*/