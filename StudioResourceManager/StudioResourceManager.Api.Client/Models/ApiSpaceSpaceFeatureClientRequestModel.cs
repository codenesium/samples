using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Client
{
	public partial class ApiSpaceSpaceFeatureClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiSpaceSpaceFeatureClientRequestModel()
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
    <Hash>04cd30d42de005ae1f95b00c39c75ffa</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/