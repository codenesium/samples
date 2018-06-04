using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOPurchaseOrderHeader: AbstractBusinessObject
	{
		public BOPurchaseOrderHeader() : base()
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
	}
}

/*<Codenesium>
    <Hash>319fc56632ad66f36eb091e6faa0148e</Hash>
</Codenesium>*/