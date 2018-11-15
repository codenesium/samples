using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("PurchaseOrderHeader", Schema="Purchasing")]
	public partial class PurchaseOrderHeader : AbstractEntity
	{
		public PurchaseOrderHeader()
		{
		}

		public virtual void SetProperties(
			int employeeID,
			decimal freight,
			DateTime modifiedDate,
			DateTime orderDate,
			int purchaseOrderID,
			int revisionNumber,
			DateTime? shipDate,
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

		[Column("EmployeeID")]
		public virtual int EmployeeID { get; private set; }

		[Column("Freight")]
		public virtual decimal Freight { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Column("OrderDate")]
		public virtual DateTime OrderDate { get; private set; }

		[Key]
		[Column("PurchaseOrderID")]
		public virtual int PurchaseOrderID { get; private set; }

		[Column("RevisionNumber")]
		public virtual int RevisionNumber { get; private set; }

		[Column("ShipDate")]
		public virtual DateTime? ShipDate { get; private set; }

		[Column("ShipMethodID")]
		public virtual int ShipMethodID { get; private set; }

		[Column("Status")]
		public virtual int Status { get; private set; }

		[Column("SubTotal")]
		public virtual decimal SubTotal { get; private set; }

		[Column("TaxAmt")]
		public virtual decimal TaxAmt { get; private set; }

		[Column("TotalDue")]
		public virtual decimal TotalDue { get; private set; }

		[Column("VendorID")]
		public virtual int VendorID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a875d1231e78132fc0b4549d8d7551d8</Hash>
</Codenesium>*/