using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiOfficerRefCapabilityClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiOfficerRefCapabilityClientRequestModel()
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

		[JsonProperty]
		public int CapabilityId { get; private set; }

		[JsonProperty]
		public int OfficerId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>827c487d760b7b722a6824ca83327f2d</Hash>
</Codenesium>*/