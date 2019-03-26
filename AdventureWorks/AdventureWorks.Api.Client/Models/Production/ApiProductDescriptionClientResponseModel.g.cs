using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiProductDescriptionClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int productDescriptionID,
			string description,
			DateTime modifiedDate,
			Guid rowguid)
		{
			this.ProductDescriptionID = productDescriptionID;
			this.Description = description;
			this.ModifiedDate = modifiedDate;
			this.Rowguid = rowguid;
		}

		[JsonProperty]
		public string Description { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public int ProductDescriptionID { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>61752b6c87cf19cade6045556b8bdc2e</Hash>
</Codenesium>*/