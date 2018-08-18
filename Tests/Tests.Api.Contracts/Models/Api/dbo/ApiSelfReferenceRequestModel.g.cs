using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		public int? SelfReferenceId { get; private set; }

		[JsonProperty]
		public int? SelfReferenceId2 { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b5044f1a4f02546a3c89aef9d0f781ef</Hash>
</Codenesium>*/