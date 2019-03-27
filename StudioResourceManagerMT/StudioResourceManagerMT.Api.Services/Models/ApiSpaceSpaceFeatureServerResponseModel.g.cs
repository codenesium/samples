using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class ApiSpaceSpaceFeatureServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int spaceId,
			int spaceFeatureId)
		{
			this.SpaceId = spaceId;
			this.SpaceFeatureId = spaceFeatureId;
		}

		[JsonProperty]
		public int SpaceFeatureId { get; private set; }

		[JsonProperty]
		public string SpaceFeatureIdEntity { get; private set; } = RouteConstants.SpaceFeatures;

		[JsonProperty]
		public ApiSpaceFeatureServerResponseModel SpaceFeatureIdNavigation { get; private set; }

		public void SetSpaceFeatureIdNavigation(ApiSpaceFeatureServerResponseModel value)
		{
			this.SpaceFeatureIdNavigation = value;
		}

		[JsonProperty]
		public int SpaceId { get; private set; }

		[JsonProperty]
		public string SpaceIdEntity { get; private set; } = RouteConstants.Spaces;

		[JsonProperty]
		public ApiSpaceServerResponseModel SpaceIdNavigation { get; private set; }

		public void SetSpaceIdNavigation(ApiSpaceServerResponseModel value)
		{
			this.SpaceIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>25487a77c5b64b038e30ce490094541c</Hash>
</Codenesium>*/