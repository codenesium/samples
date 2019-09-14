using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestsNS.Api.Client
{
	public partial class ApiSelfReferenceClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int? selfReferenceId,
			int? selfReferenceId2)
		{
			this.Id = id;
			this.SelfReferenceId = selfReferenceId;
			this.SelfReferenceId2 = selfReferenceId2;

			this.SelfReferenceIdEntity = nameof(ApiResponse.SelfReferences);

			this.SelfReferenceId2Entity = nameof(ApiResponse.SelfReferences);
		}

		[JsonProperty]
		public ApiSelfReferenceClientResponseModel SelfReferenceIdNavigation { get; private set; }

		public void SetSelfReferenceIdNavigation(ApiSelfReferenceClientResponseModel value)
		{
			this.SelfReferenceIdNavigation = value;
		}

		[JsonProperty]
		public ApiSelfReferenceClientResponseModel SelfReferenceId2Navigation { get; private set; }

		public void SetSelfReferenceId2Navigation(ApiSelfReferenceClientResponseModel value)
		{
			this.SelfReferenceId2Navigation = value;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int? SelfReferenceId { get; private set; }

		[JsonProperty]
		public string SelfReferenceIdEntity { get; set; }

		[JsonProperty]
		public int? SelfReferenceId2 { get; private set; }

		[JsonProperty]
		public string SelfReferenceId2Entity { get; set; }
	}
}

/*<Codenesium>
    <Hash>880416525ec9112380f437d11afb1754</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/