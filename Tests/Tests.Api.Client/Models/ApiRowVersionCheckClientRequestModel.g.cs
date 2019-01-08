using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TestsNS.Api.Client
{
	public partial class ApiRowVersionCheckClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiRowVersionCheckClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string name,
			Guid rowVersion)
		{
			this.Name = name;
			this.RowVersion = rowVersion;
		}

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public Guid RowVersion { get; private set; } = default(Guid);
	}
}

/*<Codenesium>
    <Hash>d2662ebbbbf11f107ec49055d678729c</Hash>
</Codenesium>*/