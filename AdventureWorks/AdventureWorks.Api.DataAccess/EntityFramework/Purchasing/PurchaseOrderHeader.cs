using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("PurchaseOrderHeader", Schema="Purchasing")]
	public partial class PurchaseOrderHeader: AbstractEntity
	{
		public PurchaseOrderHeader()
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

		[Column("EmployeeID", TypeName="int")]
		public int EmployeeID { get; private set; }

		[Column("Freight", TypeName="money")]
		public decimal Freight { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("OrderDate", TypeName="datetime")]
		public DateTime OrderDate { get; private set; }

		[Key]
		[Column("PurchaseOrderID", TypeName="int")]
		public int PurchaseOrderID { get; private set; }

		[Column("RevisionNumber", TypeName="tinyint")]
		public int RevisionNumber { get; private set; }

		[Column("ShipDate", TypeName="datetime")]
		public Nullable<DateTime> ShipDate { get; private set; }

		[Column("ShipMethodID", TypeName="int")]
		public int ShipMethodID { get; private set; }

		[Column("Status", TypeName="tinyint")]
		public int Status { get; private set; }

		[Column("SubTotal", TypeName="money")]
		public decimal SubTotal { get; private set; }

		[Column("TaxAmt", TypeName="money")]
		public decimal TaxAmt { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("TotalDue", TypeName="money")]
		public decimal TotalDue { get; private set; }

		[Column("VendorID", TypeName="int")]
		public int VendorID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ce7b27e79c30e1a8ff3408633987ecc7</Hash>
</Codenesium>*/