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
			int id,
			int capabilityId,
			int officerId)
		{
			this.Id = id;
			this.CapabilityId = capabilityId;
			this.OfficerId = officerId;
		}

		[JsonProperty]
		public int CapabilityId { get; private set; }

		[JsonProperty]
		public string CapabilityIdEntity { get; private set; } = RouteConstants.OffCapabilities;

		[JsonProperty]
		public ApiOffCapabilityServerResponseModel CapabilityIdNavigation { get; private set; }

		public void SetCapabilityIdNavigation(ApiOffCapabilityServerResponseModel value)
		{
			this.CapabilityIdNavigation = value;
		}

		[JsonProperty]
		public int Id { get; private set; }

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
    <Hash>12d9f8758ffd3ce3d8b8108cbe204197</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/