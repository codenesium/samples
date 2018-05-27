using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class ApiSpaceXSpaceFeatureResponseModel: AbstractApiResponseModel
	{
		public ApiSpaceXSpaceFeatureResponseModel() : base()
		{}

		public void SetProperties(
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
    <Hash>1071d24820162b0fe816643c1935bb2b</Hash>
</Codenesium>*/