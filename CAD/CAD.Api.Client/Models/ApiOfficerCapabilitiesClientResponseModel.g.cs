using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiOfficerCapabilitiesClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int capabilityId,
			int officerId)
		{
			this.CapabilityId = capabilityId;
			this.OfficerId = officerId;

			this.OfficerIdEntity = nameof(ApiResponse.Officers);
		}

		[JsonProperty]
		public ApiOfficerClientResponseModel OfficerIdNavigation { get; private set; }

		public void SetOfficerIdNavigation(ApiOfficerClientResponseModel value)
		{
			this.OfficerIdNavigation = value;
		}

		[JsonProperty]
		public int CapabilityId { get; private set; }

		[JsonProperty]
		public string CapabilityIdEntity { get; set; }

		[JsonProperty]
		public int OfficerId { get; private set; }

		[JsonProperty]
		public string OfficerIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>49633cc2dddb1fbcd3b2aa88e155cc14</Hash>
</Codenesium>*/