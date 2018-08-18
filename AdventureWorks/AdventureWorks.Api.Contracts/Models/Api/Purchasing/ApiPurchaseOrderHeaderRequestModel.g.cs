using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiPurchaseOrderHeaderRequestModel : AbstractApiRequestModel
	{
		public ApiPurchaseOrderHeaderRequestModel()
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
		public int EmployeeID { get; private set; }

		[Required]
		[JsonProperty]
		public decimal Freight { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime OrderDate { get; private set; }

		[Required]
		[JsonProperty]
		public int RevisionNumber { get; private set; }

		[JsonProperty]
		public DateTime? ShipDate { get; private set; }

		[Required]
		[JsonProperty]
		public int ShipMethodID { get; private set; }

		[Required]
		[JsonProperty]
		public int Status { get; private set; }

		[Required]
		[JsonProperty]
		public decimal SubTotal { get; private set; }

		[Required]
		[JsonProperty]
		public decimal TaxAmt { get; private set; }

		[Required]
		[JsonProperty]
		public decimal TotalDue { get; private set; }

		[Required]
		[JsonProperty]
		public int VendorID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>486de302da66e5486cc899058d889d64</Hash>
</Codenesium>*/