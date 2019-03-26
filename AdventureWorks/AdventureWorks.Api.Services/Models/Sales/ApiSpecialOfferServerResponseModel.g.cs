using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiSpecialOfferServerResponseModel : AbstractApiServerResponseModel
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
			string reservedType,
			Guid rowguid,
			DateTime startDate)
		{
			this.SpecialOfferID = specialOfferID;
			this.Category = category;
			this.Description = description;
			this.DiscountPct = discountPct;
			this.EndDate = endDate;
			this.MaxQty = maxQty;
			this.MinQty = minQty;
			this.ModifiedDate = modifiedDate;
			this.ReservedType = reservedType;
			this.Rowguid = rowguid;
			this.StartDate = startDate;
		}

		[JsonProperty]
		public string Category { get; private set; }

		[JsonProperty]
		public string Description { get; private set; }

		[JsonProperty]
		public decimal DiscountPct { get; private set; }

		[JsonProperty]
		public DateTime EndDate { get; private set; }

		[Required]
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
		public string ReservedType { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7b8758f9f2b380abee5d6f8ead63905c</Hash>
</Codenesium>*/