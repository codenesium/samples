using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductVendorResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int productID,
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
			this.ProductID = productID;
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

		[JsonProperty]
		public int AverageLeadTime { get; private set; }

		[JsonProperty]
		public int BusinessEntityID { get; private set; }

		[Required]
		[JsonProperty]
		public decimal? LastReceiptCost { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime? LastReceiptDate { get; private set; }

		[JsonProperty]
		public int MaxOrderQty { get; private set; }

		[JsonProperty]
		public int MinOrderQty { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public int? OnOrderQty { get; private set; }

		[JsonProperty]
		public int ProductID { get; private set; }

		[JsonProperty]
		public decimal StandardPrice { get; private set; }

		[JsonProperty]
		public string UnitMeasureCode { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8371b53487ca87e7e23b8fa8209329e2</Hash>
</Codenesium>*/