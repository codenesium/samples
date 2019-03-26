using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class ApiSpaceSpaceFeatureServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiSpaceSpaceFeatureServerRequestModel()
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

		[Required]
		[JsonProperty]
		public int SpaceFeatureId { get; private set; }

		[Required]
		[JsonProperty]
		public int SpaceId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e1aba85a99eda841ef3ebe5ead4d034f</Hash>
</Codenesium>*/