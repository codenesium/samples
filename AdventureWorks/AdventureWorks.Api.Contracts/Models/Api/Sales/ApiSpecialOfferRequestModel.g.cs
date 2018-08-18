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
		public string Category { get; private set; }

		[Required]
		[JsonProperty]
		public string Description { get; private set; }

		[Required]
		[JsonProperty]
		public decimal DiscountPct { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime EndDate { get; private set; }

		[JsonProperty]
		public int? MaxQty { get; private set; }

		[Required]
		[JsonProperty]
		public int MinQty { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime StartDate { get; private set; }

		[Required]
		[JsonProperty]
		public string Type { get; private set; }
	}
}

/*<Codenesium>
    <Hash>80c9a30d1d2bcb8b18ac3cfe50ea8f90</Hash>
</Codenesium>*/