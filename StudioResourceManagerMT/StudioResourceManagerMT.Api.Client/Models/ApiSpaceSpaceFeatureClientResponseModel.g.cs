using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Client
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
    <Hash>177b6e8341cd7728718336cb3ef23534</Hash>
</Codenesium>*/