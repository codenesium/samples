using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSpecialOfferRequestModel : AbstractApiRequestModel
	{
		public ApiSpecialOfferRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string category,
			string description,
			decimal discountPct,
			DateTime endDate,
			int? maxQty,
			int minQty,
			DateTime modifiedDate,
			Guid rowguid,
			DateTime startDate,
			string type)
		{
			this.Category = category;
			this.Description = description;
			this.DiscountPct = discountPct;
			this.EndDate = endDate;
			this.MaxQty = maxQty;
			this.MinQty = minQty;
			this.ModifiedDate = modifiedDate;
			this.Rowguid = rowguid;
			this.StartDate = startDate;
			this.Type = type;
		}

		[Required]
		[JsonProperty]
		public string Category { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Description { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public decimal DiscountPct { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public DateTime EndDate { get; private set; } = default(DateTime);

		[JsonProperty]
		public int? MaxQty { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public int MinQty { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[Required]
		[JsonProperty]
		public DateTime StartDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public string Type { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>8a400ad1983f4b60e21b62d37156422a</Hash>
</Codenesium>*/