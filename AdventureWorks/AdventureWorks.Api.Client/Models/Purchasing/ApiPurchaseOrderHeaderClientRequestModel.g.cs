using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiPurchaseOrderHeaderClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiPurchaseOrderHeaderClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
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
		public int EmployeeID { get; private set; } = default(int);

		[JsonProperty]
		public decimal Freight { get; private set; } = default(decimal);

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public DateTime OrderDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int RevisionNumber { get; private set; } = default(int);

		[JsonProperty]
		public DateTime? ShipDate { get; private set; } = null;

		[JsonProperty]
		public int ShipMethodID { get; private set; } = default(int);

		[JsonProperty]
		public int Status { get; private set; } = default(int);

		[JsonProperty]
		public decimal SubTotal { get; private set; } = default(decimal);

		[JsonProperty]
		public decimal TaxAmt { get; private set; } = default(decimal);

		[JsonProperty]
		public decimal TotalDue { get; private set; } = default(decimal);

		[JsonProperty]
		public int VendorID { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>9061efcfb7fbc92bc0347350adb841a1</Hash>
</Codenesium>*/