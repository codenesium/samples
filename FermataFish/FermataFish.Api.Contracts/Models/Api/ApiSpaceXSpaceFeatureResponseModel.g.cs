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
			this.SpaceFeatureId = spaceFeatureId.ToInt();
			this.SpaceId = spaceId.ToInt();

			this.SpaceFeatureIdEntity = nameof(ApiResponse.SpaceFeatures);
			this.SpaceIdEntity = nameof(ApiResponse.Spaces);
		}

		public int Id { get; private set; }
		public int SpaceFeatureId { get; private set; }
		public string SpaceFeatureIdEntity { get; set; }
		public int SpaceId { get; private set; }
		public string SpaceIdEntity { get; set; }

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
    <Hash>3be2c2559ade94974c7912139f152675</Hash>
</Codenesium>*/