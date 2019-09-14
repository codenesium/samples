using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiOfficerCapabilitiesClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int capabilityId,
			int officerId)
		{
			this.Id = id;
			this.CapabilityId = capabilityId;
			this.OfficerId = officerId;

			this.CapabilityIdEntity = nameof(ApiResponse.OffCapabilities);

			this.OfficerIdEntity = nameof(ApiResponse.Officers);
		}

		[JsonProperty]
		public ApiOffCapabilityClientResponseModel CapabilityIdNavigation { get; private set; }

		public void SetCapabilityIdNavigation(ApiOffCapabilityClientResponseModel value)
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
		public int Id { get; private set; }

		[JsonProperty]
		public int OfficerId { get; private set; }

		[JsonProperty]
		public string OfficerIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>6329da44fe5c27dbcd12279083b3a14b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/