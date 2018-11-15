using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiProductCategoryServerResponseModel : AbstractApiServerResponseModel
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
    <Hash>14fde68fdbbb0e7672a8e57d0ac160b5</Hash>
</Codenesium>*/