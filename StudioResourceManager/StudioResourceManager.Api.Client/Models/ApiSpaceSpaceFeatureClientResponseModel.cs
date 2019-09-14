using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Client
{
	public partial class ApiSpaceSpaceFeatureClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int spaceFeatureId,
			int spaceId)
		{
			this.Id = id;
			this.SpaceFeatureId = spaceFeatureId;
			this.SpaceId = spaceId;

			this.SpaceFeatureIdEntity = nameof(ApiResponse.SpaceFeatures);

			this.SpaceIdEntity = nameof(ApiResponse.Spaces);
		}

		[JsonProperty]
		public ApiSpaceFeatureClientResponseModel SpaceFeatureIdNavigation { get; private set; }

		public void SetSpaceFeatureIdNavigation(ApiSpaceFeatureClientResponseModel value)
		{
			this.SpaceFeatureIdNavigation = value;
		}

		[JsonProperty]
		public ApiSpaceClientResponseModel SpaceIdNavigation { get; private set; }

		public void SetSpaceIdNavigation(ApiSpaceClientResponseModel value)
		{
			this.SpaceIdNavigation = value;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int SpaceFeatureId { get; private set; }

		[JsonProperty]
		public string SpaceFeatureIdEntity { get; set; }

		[JsonProperty]
		public int SpaceId { get; private set; }

		[JsonProperty]
		public string SpaceIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>30204ef2e262af676aa1fe0ca635790d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/