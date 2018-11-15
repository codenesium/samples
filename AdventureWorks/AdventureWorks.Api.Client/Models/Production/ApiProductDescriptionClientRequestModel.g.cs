using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiProductDescriptionClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiProductDescriptionClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string description,
			DateTime modifiedDate,
			Guid rowguid)
		{
			this.Description = description;
			this.ModifiedDate = modifiedDate;
			this.Rowguid = rowguid;
		}

		[JsonProperty]
		public string Description { get; private set; } = default(string);

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);
	}
}

/*<Codenesium>
    <Hash>81ac81383bb127fd5a96dccf1c90cc8c</Hash>
</Codenesium>*/