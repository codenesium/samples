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
			int spaceId,
			int spaceFeatureId)
		{
			this.Id = id.ToInt();

			this.SpaceId = new ReferenceEntity<int>(spaceId,
			                                        nameof(ApiResponse.Spaces));
			this.SpaceFeatureId = new ReferenceEntity<int>(spaceFeatureId,
			                                               nameof(ApiResponse.SpaceFeatures));
		}

		public int Id { get; set; }
		public ReferenceEntity<int> SpaceId { get; set; }
		public ReferenceEntity<int> SpaceFeatureId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSpaceIdValue { get; set; } = true;

		public bool ShouldSerializeSpaceId()
		{
			return this.ShouldSerializeSpaceIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSpaceFeatureIdValue { get; set; } = true;

		public bool ShouldSerializeSpaceFeatureId()
		{
			return this.ShouldSerializeSpaceFeatureIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeSpaceIdValue = false;
			this.ShouldSerializeSpaceFeatureIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>46f3338d699a93242c8fca2c7abb1c15</Hash>
</Codenesium>*/