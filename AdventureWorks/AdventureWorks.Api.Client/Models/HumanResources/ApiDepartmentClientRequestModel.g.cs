using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiDepartmentClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiDepartmentClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string groupName,
			DateTime modifiedDate,
			string name)
		{
			this.GroupName = groupName;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		[JsonProperty]
		public string GroupName { get; private set; } = default(string);

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>abcf9f38d36eb226b13a16957d36f810</Hash>
</Codenesium>*/