using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiProductCategoryClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int productCategoryID,
			DateTime modifiedDate,
			string name,
			Guid rowguid)
		{
			this.ProductCategoryID = productCategoryID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
		}

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int ProductCategoryID { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d968dddf6ff43d4320e2d1557f861eb3</Hash>
</Codenesium>*/