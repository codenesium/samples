using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSpecialOfferProductResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int specialOfferID,
			DateTime modifiedDate,
			int productID,
			Guid rowguid)
		{
			this.SpecialOfferID = specialOfferID;
			this.ModifiedDate = modifiedDate;
			this.ProductID = productID;
			this.Rowguid = rowguid;

			this.SpecialOfferIDEntity = nameof(ApiResponse.SpecialOffers);
		}

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public int ProductID { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[JsonProperty]
		public int SpecialOfferID { get; private set; }

		[JsonProperty]
		public string SpecialOfferIDEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>284e9df899dd4c4602d3dbff78a4f0d8</Hash>
</Codenesium>*/