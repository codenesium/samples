using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiOfficerCapabilityClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int capabilityId,
			int officerId)
		{
			this.CapabilityId = capabilityId;
			this.OfficerId = officerId;

			this.CapabilityIdEntity = nameof(ApiResponse.OfficerCapabilities);

			this.OfficerIdEntity = nameof(ApiResponse.Officers);
		}

		[JsonProperty]
		public ApiOfficerCapabilityClientResponseModel CapabilityIdNavigation { get; private set; }

		public void SetCapabilityIdNavigation(ApiOfficerCapabilityClientResponseModel value)
		{
			this.CapabilityIdNavigation = value;
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
    <Hash>97b76b88b5d860c1561cfef8833d5f5e</Hash>
</Codenesium>*/