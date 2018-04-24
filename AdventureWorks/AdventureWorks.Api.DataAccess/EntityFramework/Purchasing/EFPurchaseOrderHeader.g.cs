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
			this.EmployeeID = employeeID.ToInt();
			this.VendorID = vendorID.ToInt();
			this.ShipMethodID = shipMethodID.ToInt();
			this.OrderDate = orderDate.ToDateTime();
			this.ShipDate = shipDate.ToNullableDateTime();
			this.SubTotal = subTotal.ToDecimal();
			this.TaxAmt = taxAmt.ToDecimal();
			this.Freight = freight.ToDecimal();
			this.TotalDue = totalDue.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("PurchaseOrderID", TypeName="int")]
		public int PurchaseOrderID { get; set; }

		[Column("RevisionNumber", TypeName="tinyint")]
		public int RevisionNumber { get; set; }

		[Column("Status", TypeName="tinyint")]
		public int Status { get; set; }

		[Column("EmployeeID", TypeName="int")]
		public int EmployeeID { get; set; }

		[Column("VendorID", TypeName="int")]
		public int VendorID { get; set; }

		[Column("ShipMethodID", TypeName="int")]
		public int ShipMethodID { get; set; }

		[Column("OrderDate", TypeName="datetime")]
		public DateTime OrderDate { get; set; }

		[Column("ShipDate", TypeName="datetime")]
		public Nullable<DateTime> ShipDate { get; set; }

		[Column("SubTotal", TypeName="money")]
		public decimal SubTotal { get; set; }

		[Column("TaxAmt", TypeName="money")]
		public decimal TaxAmt { get; set; }

		[Column("Freight", TypeName="money")]
		public decimal Freight { get; set; }

		[Column("TotalDue", TypeName="money")]
		public decimal TotalDue { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("EmployeeID")]
		public virtual EFEmployee Employee { get; set; }

		[ForeignKey("VendorID")]
		public virtual EFVendor Vendor { get; set; }

		[ForeignKey("ShipMethodID")]
		public virtual EFShipMethod ShipMethod { get; set; }
	}
}

/*<Codenesium>
    <Hash>6b4e2234b8d42b62b606e7c35f59c546</Hash>
</Codenesium>*/