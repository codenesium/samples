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
			int purchaseOrderID,
			int employeeID,
			decimal freight,
			DateTime modifiedDate,
			DateTime orderDate,
			int revisionNumber,
			DateTime? shipDate,
			int shipMethodID,
			int status,
			decimal subTotal,
			decimal taxAmt,
			decimal totalDue,
			int vendorID)
		{
			this.PurchaseOrderID = purchaseOrderID;
			this.EmployeeID = employeeID;
			this.Freight = freight;
			this.ModifiedDate = modifiedDate;
			this.OrderDate = orderDate;
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

		[ForeignKey("ShipMethodID")]
		public virtual ShipMethod ShipMethodIDNavigation { get; private set; }

		public void SetShipMethodIDNavigation(ShipMethod item)
		{
			this.ShipMethodIDNavigation = item;
		}

		[ForeignKey("VendorID")]
		public virtual Vendor VendorIDNavigation { get; private set; }

		public void SetVendorIDNavigation(Vendor item)
		{
			this.VendorIDNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>45e44f0acf8e9a9bbbaa968e646c4a76</Hash>
</Codenesium>*/