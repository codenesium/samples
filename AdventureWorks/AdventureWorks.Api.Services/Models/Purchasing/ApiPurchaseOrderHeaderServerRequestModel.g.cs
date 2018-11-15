using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiPurchaseOrderHeaderServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiPurchaseOrderHeaderServerRequestModel()
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

		[Required]
		[JsonProperty]
		public int EmployeeID { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public decimal Freight { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public DateTime OrderDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public int RevisionNumber { get; private set; } = default(int);

		[JsonProperty]
		public DateTime? ShipDate { get; private set; } = null;

		[Required]
		[JsonProperty]
		public int ShipMethodID { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int Status { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public decimal SubTotal { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public decimal TaxAmt { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public decimal TotalDue { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public int VendorID { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>4c7e2d9ad396ee39118380dadeb05fa9</Hash>
</Codenesium>*/