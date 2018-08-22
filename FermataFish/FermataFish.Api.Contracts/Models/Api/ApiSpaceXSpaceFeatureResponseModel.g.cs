using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
	public partial class ApiSpaceXSpaceFeatureResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			int spaceFeatureId,
			int spaceId,
			int studioId)
		{
			this.Id = id;
			this.SpaceFeatureId = spaceFeatureId;
			this.SpaceId = spaceId;
			this.StudioId = studioId;

			this.SpaceFeatureIdEntity = nameof(ApiResponse.SpaceFeatures);
			this.SpaceIdEntity = nameof(ApiResponse.Spaces);
			this.StudioIdEntity = nameof(ApiResponse.Studios);
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

		[JsonProperty]
		public int StudioId { get; private set; }

		[JsonProperty]
		public string StudioIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>51912a2d1204e667511cd112fc6a57f6</Hash>
</Codenesium>*/