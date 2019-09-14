using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>672a16f26a349a29e4be08843e239411</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/