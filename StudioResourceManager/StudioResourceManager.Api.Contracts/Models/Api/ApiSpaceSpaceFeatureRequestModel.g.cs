using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiSpaceSpaceFeatureRequestModel : AbstractApiRequestModel
	{
		public ApiSpaceSpaceFeatureRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int spaceFeatureId,
			bool isDeleted)
		{
			this.SpaceFeatureId = spaceFeatureId;
			this.IsDeleted = isDeleted;
		}

		[Required]
		[JsonProperty]
		public int SpaceFeatureId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public bool IsDeleted { get; private set; } = default(bool);
	}
}

/*<Codenesium>
    <Hash>8479ef29234bc0b6f7ddeacd159db274</Hash>
</Codenesium>*/