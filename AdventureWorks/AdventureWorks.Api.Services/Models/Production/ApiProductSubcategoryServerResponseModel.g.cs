using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiProductSubcategoryServerResponseModel : AbstractApiServerResponseModel
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
		}

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int ProductCategoryID { get; private set; }

		[JsonProperty]
		public string ProductCategoryIDEntity { get; private set; } = RouteConstants.ProductCategories;

		[JsonProperty]
		public ApiProductCategoryServerResponseModel ProductCategoryIDNavigation { get; private set; }

		public void SetProductCategoryIDNavigation(ApiProductCategoryServerResponseModel value)
		{
			this.ProductCategoryIDNavigation = value;
		}

		[JsonProperty]
		public int ProductSubcategoryID { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>26f7c8e67173fe728693391ad0727005</Hash>
</Codenesium>*/