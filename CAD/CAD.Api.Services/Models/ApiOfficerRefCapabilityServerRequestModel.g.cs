using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiOfficerRefCapabilityServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiOfficerRefCapabilityServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int capabilityId,
			int officerId)
		{
			this.CapabilityId = capabilityId;
			this.OfficerId = officerId;
		}

		[Required]
		[JsonProperty]
		public int CapabilityId { get; private set; }

		[Required]
		[JsonProperty]
		public int OfficerId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>30416be163ea14fbcdf9a6ab43e16985</Hash>
</Codenesium>*/