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
			int spaceFeatureId)
		{
			this.SpaceFeatureId = spaceFeatureId;
		}

		[Required]
		[JsonProperty]
		public int SpaceFeatureId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>18f27155dbe8d5a2583fafe9c5fa4fbe</Hash>
</Codenesium>*/