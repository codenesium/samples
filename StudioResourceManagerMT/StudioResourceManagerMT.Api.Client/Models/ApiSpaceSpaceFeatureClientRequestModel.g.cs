using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial class ApiSpaceSpaceFeatureClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiSpaceSpaceFeatureClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int spaceFeatureId)
		{
			this.SpaceFeatureId = spaceFeatureId;
		}

		[JsonProperty]
		public int SpaceFeatureId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>72d5d7338fcbbd5c9ee3c016d45964af</Hash>
</Codenesium>*/