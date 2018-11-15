using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiSpecialOfferClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiSpecialOfferClientRequestModel()
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

		[JsonProperty]
		public string Category { get; private set; } = default(string);

		[JsonProperty]
		public string Description { get; private set; } = default(string);

		[JsonProperty]
		public decimal DiscountPct { get; private set; } = default(decimal);

		[JsonProperty]
		public DateTime EndDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int? MaxQty { get; private set; } = default(int);

		[JsonProperty]
		public int MinQty { get; private set; } = default(int);

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[JsonProperty]
		public DateTime StartDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Type { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>9af84574aa9228fa63cb4e76648e6f30</Hash>
</Codenesium>*/