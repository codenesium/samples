using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class POCOSpaceXSpaceFeature
	{
		public POCOSpaceXSpaceFeature()
		{}

		public POCOSpaceXSpaceFeature(
			int id,
			int spaceFeatureId,
			int spaceId)
		{
			this.Id = id.ToInt();

			this.SpaceFeatureId = new ReferenceEntity<int>(spaceFeatureId,
			                                               nameof(ApiResponse.SpaceFeatures));
			this.SpaceId = new ReferenceEntity<int>(spaceId,
			                                        nameof(ApiResponse.Spaces));
		}

		public int Id { get; set; }
		public ReferenceEntity<int> SpaceFeatureId { get; set; }
		public ReferenceEntity<int> SpaceId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSpaceFeatureIdValue { get; set; } = true;

		public bool ShouldSerializeSpaceFeatureId()
		{
			return this.ShouldSerializeSpaceFeatureIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSpaceIdValue { get; set; } = true;

		public bool ShouldSerializeSpaceId()
		{
			return this.ShouldSerializeSpaceIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeSpaceFeatureIdValue = false;
			this.ShouldSerializeSpaceIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>6c095c7933971b20163289869225416b</Hash>
</Codenesium>*/