using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiProductProductPhotoServerResponseModel : AbstractApiServerResponseModel
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
		}

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public bool Primary { get; private set; }

		[JsonProperty]
		public int ProductID { get; private set; }

		[JsonProperty]
		public string ProductIDEntity { get; private set; } = RouteConstants.Products;

		[JsonProperty]
		public ApiProductServerResponseModel ProductIDNavigation { get; private set; }

		public void SetProductIDNavigation(ApiProductServerResponseModel value)
		{
			this.ProductIDNavigation = value;
		}

		[JsonProperty]
		public int ProductPhotoID { get; private set; }

		[JsonProperty]
		public string ProductPhotoIDEntity { get; private set; } = RouteConstants.ProductPhotoes;

		[JsonProperty]
		public ApiProductPhotoServerResponseModel ProductPhotoIDNavigation { get; private set; }

		public void SetProductPhotoIDNavigation(ApiProductPhotoServerResponseModel value)
		{
			this.ProductPhotoIDNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>02c4bbf1020c8814928c7b3410f3f5d9</Hash>
</Codenesium>*/