using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOPurchaseOrderHeader: AbstractDTO
	{
		public DTOPurchaseOrderHeader() : base()
		{}

		public void SetProperties(int purchaseOrderID,
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
	}
}

/*<Codenesium>
    <Hash>ea841d05c0b1bfd5299f3c52a1340bd8</Hash>
</Codenesium>*/