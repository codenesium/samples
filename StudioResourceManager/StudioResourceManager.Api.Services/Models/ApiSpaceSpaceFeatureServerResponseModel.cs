using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class ApiSpaceSpaceFeatureServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			int spaceFeatureId,
			int spaceId)
		{
			this.Id = id;
			this.SpaceFeatureId = spaceFeatureId;
			this.SpaceId = spaceId;
		}

		[JsonProperty]
		public int Id { get; private set; }

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
    <Hash>e295d2e4823b186c7fd20ecf4161fc3a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/