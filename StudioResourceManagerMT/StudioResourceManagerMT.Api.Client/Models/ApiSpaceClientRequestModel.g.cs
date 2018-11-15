using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial class ApiSpaceClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiSpaceClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string description,
			string name)
		{
			this.Description = description;
			this.Name = name;
		}

		[JsonProperty]
		public string Description { get; private set; } = default(string);

		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>4b977c9e2058774789a0901b201422b6</Hash>
</Codenesium>*/