using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiOfficerCapabilitiesServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiOfficerCapabilitiesServerRequestModel()
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
    <Hash>6a68df4d80512bdb59dd984956f79fc3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/