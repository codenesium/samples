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
    <Hash>315403f43895f209a6c9ef0bb7be700e</Hash>
</Codenesium>*/