using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiSpecialOfferClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int specialOfferID,
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
			this.SpecialOfferID = specialOfferID;
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
		public string Category { get; private set; }

		[JsonProperty]
		public string Description { get; private set; }

		[JsonProperty]
		public decimal DiscountPct { get; private set; }

		[JsonProperty]
		public DateTime EndDate { get; private set; }

		[JsonProperty]
		public int? MaxQty { get; private set; }

		[JsonProperty]
		public int MinQty { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[JsonProperty]
		public int SpecialOfferID { get; private set; }

		[JsonProperty]
		public DateTime StartDate { get; private set; }

		[JsonProperty]
		public string Type { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ad0e31a423b16aa8cffecfa0ca981387</Hash>
</Codenesium>*/