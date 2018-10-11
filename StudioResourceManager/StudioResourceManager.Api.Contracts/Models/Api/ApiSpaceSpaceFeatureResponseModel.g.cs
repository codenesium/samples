using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiSpaceSpaceFeatureResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int spaceId,
			int spaceFeatureId)
		{
			this.SpaceId = spaceId;
			this.SpaceFeatureId = spaceFeatureId;

			this.SpaceFeatureIdEntity = nameof(ApiResponse.SpaceFeatures);
			this.SpaceIdEntity = nameof(ApiResponse.Spaces);
		}

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
    <Hash>6f20126b28c5df9719f68c94cf90526e</Hash>
</Codenesium>*/