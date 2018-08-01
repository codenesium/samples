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
			int spaceId)
		{
			this.SpaceFeatureId = spaceFeatureId;
			this.SpaceId = spaceId;
		}

		[JsonProperty]
		public int SpaceFeatureId { get; private set; }

		[JsonProperty]
		public int SpaceId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>967899f23be9b12dfb08091b3d8e374c</Hash>
</Codenesium>*/