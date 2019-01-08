using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Services
{
	public partial class ApiSelfReferenceServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			int? selfReferenceId,
			int? selfReferenceId2)
		{
			this.Id = id;
			this.SelfReferenceId = selfReferenceId;
			this.SelfReferenceId2 = selfReferenceId2;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public int? SelfReferenceId { get; private set; }

		[JsonProperty]
		public string SelfReferenceIdEntity { get; private set; } = RouteConstants.SelfReferences;

		[Required]
		[JsonProperty]
		public int? SelfReferenceId2 { get; private set; }

		[JsonProperty]
		public string SelfReferenceId2Entity { get; private set; } = RouteConstants.SelfReferences;
	}
}

/*<Codenesium>
    <Hash>05ec9bc701b3cf99f6bcbf4fdbabc892</Hash>
</Codenesium>*/