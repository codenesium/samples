using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiPurchaseOrderHeaderClientResponseModel : AbstractApiClientResponseModel
	{
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

		[JsonProperty]
		public int EmployeeID { get; private set; }

		[JsonProperty]
		public decimal Freight { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public DateTime OrderDate { get; private set; }

		[JsonProperty]
		public int PurchaseOrderID { get; private set; }

		[JsonProperty]
		public int RevisionNumber { get; private set; }

		[JsonProperty]
		public DateTime? ShipDate { get; private set; }

		[JsonProperty]
		public int ShipMethodID { get; private set; }

		[JsonProperty]
		public int Status { get; private set; }

		[JsonProperty]
		public decimal SubTotal { get; private set; }

		[JsonProperty]
		public decimal TaxAmt { get; private set; }

		[JsonProperty]
		public decimal TotalDue { get; private set; }

		[JsonProperty]
		public int VendorID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>bf165b230ad79f9295c1dc769f32c71e</Hash>
</Codenesium>*/