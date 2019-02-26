using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiOfficerCapabilitiesServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int capabilityId,
			int officerId)
		{
			this.CapabilityId = capabilityId;
			this.OfficerId = officerId;
		}

		[JsonProperty]
		public int CapabilityId { get; private set; }

		[JsonProperty]
		public string CapabilityIdEntity { get; private set; } = RouteConstants.OfficerCapabilities;

		[JsonProperty]
		public ApiOfficerCapabilityServerResponseModel CapabilityIdNavigation { get; private set; }

		public void SetCapabilityIdNavigation(ApiOfficerCapabilityServerResponseModel value)
		{
			this.CapabilityIdNavigation = value;
		}

		[JsonProperty]
		public int OfficerId { get; private set; }

		[JsonProperty]
		public string OfficerIdEntity { get; private set; } = RouteConstants.Officers;

		[JsonProperty]
		public ApiOfficerServerResponseModel OfficerIdNavigation { get; private set; }

		public void SetOfficerIdNavigation(ApiOfficerServerResponseModel value)
		{
			this.OfficerIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>36f0d4004986ae0de79239534a05db20</Hash>
</Codenesium>*/