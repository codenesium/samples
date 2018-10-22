using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TestsNS.Api.Contracts
{
	public partial class ApiSelfReferenceRequestModel : AbstractApiRequestModel
	{
		public ApiSelfReferenceRequestModel()
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
    <Hash>8464e77a9e397e2d9d3f2f776ec74b35</Hash>
</Codenesium>*/