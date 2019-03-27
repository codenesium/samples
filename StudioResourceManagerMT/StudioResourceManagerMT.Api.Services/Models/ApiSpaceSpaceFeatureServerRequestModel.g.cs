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
    <Hash>4c5b9e34d9424a3d7d2fbefcd3796fa4</Hash>
</Codenesium>*/