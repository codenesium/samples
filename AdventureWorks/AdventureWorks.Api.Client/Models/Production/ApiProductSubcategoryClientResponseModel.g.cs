using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiProductSubcategoryClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int productSubcategoryID,
			DateTime modifiedDate,
			string name,
			int productCategoryID,
			Guid rowguid)
		{
			this.ProductSubcategoryID = productSubcategoryID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.ProductCategoryID = productCategoryID;
			this.Rowguid = rowguid;

			this.ProductCategoryIDEntity = nameof(ApiResponse.ProductCategories);
		}

		[JsonProperty]
		public ApiProductCategoryClientResponseModel ProductCategoryIDNavigation { get; private set; }

		public void SetProductCategoryIDNavigation(ApiProductCategoryClientResponseModel value)
		{
			this.ProductCategoryIDNavigation = value;
		}

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int ProductCategoryID { get; private set; }

		[JsonProperty]
		public string ProductCategoryIDEntity { get; set; }

		[JsonProperty]
		public int ProductSubcategoryID { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f668bb2eb329107c65f9d73735252a13</Hash>
</Codenesium>*/