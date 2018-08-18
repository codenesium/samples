using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductVendorRequestModel : AbstractApiRequestModel
	{
		public ApiProductVendorRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int averageLeadTime,
			int businessEntityID,
			decimal? lastReceiptCost,
			DateTime? lastReceiptDate,
			int maxOrderQty,
			int minOrderQty,
			DateTime modifiedDate,
			int? onOrderQty,
			decimal standardPrice,
			string unitMeasureCode)
		{
			this.AverageLeadTime = averageLeadTime;
			this.BusinessEntityID = businessEntityID;
			this.LastReceiptCost = lastReceiptCost;
			this.LastReceiptDate = lastReceiptDate;
			this.MaxOrderQty = maxOrderQty;
			this.MinOrderQty = minOrderQty;
			this.ModifiedDate = modifiedDate;
			this.OnOrderQty = onOrderQty;
			this.StandardPrice = standardPrice;
			this.UnitMeasureCode = unitMeasureCode;
		}

		[Required]
		[JsonProperty]
		public int AverageLeadTime { get; private set; }

		[Required]
		[JsonProperty]
		public int BusinessEntityID { get; private set; }

		[JsonProperty]
		public decimal? LastReceiptCost { get; private set; }

		[JsonProperty]
		public DateTime? LastReceiptDate { get; private set; }

		[Required]
		[JsonProperty]
		public int MaxOrderQty { get; private set; }

		[Required]
		[JsonProperty]
		public int MinOrderQty { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public int? OnOrderQty { get; private set; }

		[Required]
		[JsonProperty]
		public decimal StandardPrice { get; private set; }

		[Required]
		[JsonProperty]
		public string UnitMeasureCode { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e288b2c2ce2fe9fd74cf2904c36a65b3</Hash>
</Codenesium>*/