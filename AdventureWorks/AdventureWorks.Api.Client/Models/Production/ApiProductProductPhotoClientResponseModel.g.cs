using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiProductProductPhotoClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int productID,
			DateTime modifiedDate,
			bool primary,
			int productPhotoID)
		{
			this.ProductID = productID;
			this.ModifiedDate = modifiedDate;
			this.Primary = primary;
			this.ProductPhotoID = productPhotoID;

			this.ProductIDEntity = nameof(ApiResponse.Products);

			this.ProductPhotoIDEntity = nameof(ApiResponse.ProductPhotoes);
		}

		[JsonProperty]
		public ApiProductClientResponseModel ProductIDNavigation { get; private set; }

		public void SetProductIDNavigation(ApiProductClientResponseModel value)
		{
			this.ProductIDNavigation = value;
		}

		[JsonProperty]
		public ApiProductPhotoClientResponseModel ProductPhotoIDNavigation { get; private set; }

		public void SetProductPhotoIDNavigation(ApiProductPhotoClientResponseModel value)
		{
			this.ProductPhotoIDNavigation = value;
		}

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public bool Primary { get; private set; }

		[JsonProperty]
		public int ProductID { get; private set; }

		[JsonProperty]
		public string ProductIDEntity { get; set; }

		[JsonProperty]
		public int ProductPhotoID { get; private set; }

		[JsonProperty]
		public string ProductPhotoIDEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>8cd8260b188df31cd374413b812bd7fa</Hash>
</Codenesium>*/