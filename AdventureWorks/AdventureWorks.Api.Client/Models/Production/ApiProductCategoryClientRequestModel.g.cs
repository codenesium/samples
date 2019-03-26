using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiProductCategoryClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiProductCategoryClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime modifiedDate,
			string name,
			Guid rowguid)
		{
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
		}

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);
	}
}

/*<Codenesium>
    <Hash>4499a19477fb6ff9c6874e7e18f9ee23</Hash>
</Codenesium>*/