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

		[JsonProperty]
		public ApiSelfReferenceServerResponseModel SelfReferenceIdNavigation { get; private set; }

		public void SetSelfReferenceIdNavigation(ApiSelfReferenceServerResponseModel value)
		{
			this.SelfReferenceIdNavigation = value;
		}

		[Required]
		[JsonProperty]
		public int? SelfReferenceId2 { get; private set; }

		[JsonProperty]
		public string SelfReferenceId2Entity { get; private set; } = RouteConstants.SelfReferences;

		[JsonProperty]
		public ApiSelfReferenceServerResponseModel SelfReferenceId2Navigation { get; private set; }

		public void SetSelfReferenceId2Navigation(ApiSelfReferenceServerResponseModel value)
		{
			this.SelfReferenceId2Navigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>837a46a1e216f81f92b51deb45d17b57</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/