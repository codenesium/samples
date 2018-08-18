using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductModelIllustrationResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int productModelID,
			int illustrationID,
			DateTime modifiedDate)
		{
			this.ProductModelID = productModelID;
			this.IllustrationID = illustrationID;
			this.ModifiedDate = modifiedDate;
		}

		[JsonProperty]
		public int IllustrationID { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public int ProductModelID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>737b837b27a2e999652c884762d77feb</Hash>
</Codenesium>*/