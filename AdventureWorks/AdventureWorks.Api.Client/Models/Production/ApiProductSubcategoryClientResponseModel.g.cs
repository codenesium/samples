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
		}

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int ProductCategoryID { get; private set; }

		[JsonProperty]
		public int ProductSubcategoryID { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>bb325d6f2d6555f5d12aab1195002eb4</Hash>
</Codenesium>*/