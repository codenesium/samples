using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TestsNS.Api.Client
{
	public partial class ApiSelfReferenceClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiSelfReferenceClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int? selfReferenceId,
			int? selfReferenceId2)
		{
			this.SelfReferenceId = selfReferenceId;
			this.SelfReferenceId2 = selfReferenceId2;
		}

		[JsonProperty]
		public int? SelfReferenceId { get; private set; } = default(int);

		[JsonProperty]
		public int? SelfReferenceId2 { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>e0f860bc22991660f655c0665b45f6f5</Hash>
</Codenesium>*/