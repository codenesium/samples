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
		public int AverageLeadTime { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int BusinessEntityID { get; private set; } = default(int);

		[JsonProperty]
		public decimal? LastReceiptCost { get; private set; } = default(decimal);

		[JsonProperty]
		public DateTime? LastReceiptDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public int MaxOrderQty { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int MinOrderQty { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[JsonProperty]
		public int? OnOrderQty { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public decimal StandardPrice { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public string UnitMeasureCode { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>88b5ebd772cb2e252e49974e047900c5</Hash>
</Codenesium>*/