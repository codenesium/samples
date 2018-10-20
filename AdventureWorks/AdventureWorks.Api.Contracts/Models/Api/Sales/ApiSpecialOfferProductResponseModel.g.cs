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
		}

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public int ProductID { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[JsonProperty]
		public int SpecialOfferID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>97f693446cc58e848761cc0ce4f25ccc</Hash>
</Codenesium>*/