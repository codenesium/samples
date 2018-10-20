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
			int spaceFeatureId,
			bool isDeleted)
		{
			this.SpaceId = spaceId;
			this.SpaceFeatureId = spaceFeatureId;
			this.IsDeleted = isDeleted;

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

		[JsonProperty]
		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ab066b556a55e8555b58610f0116a598</Hash>
</Codenesium>*/