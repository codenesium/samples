using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
	public partial class ApiSpaceXSpaceFeatureRequestModel : AbstractApiRequestModel
	{
		public ApiSpaceXSpaceFeatureRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int spaceFeatureId,
			int spaceId,
			int studioId)
		{
			this.SpaceFeatureId = spaceFeatureId;
			this.SpaceId = spaceId;
			this.StudioId = studioId;
		}

		[Required]
		[JsonProperty]
		public int SpaceFeatureId { get; private set; }

		[Required]
		[JsonProperty]
		public int SpaceId { get; private set; }

		[Required]
		[JsonProperty]
		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>25ff5b0495aa195abed872bc8746bc22</Hash>
</Codenesium>*/